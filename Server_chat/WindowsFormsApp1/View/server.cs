using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using Newtonsoft.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WindowsFormsApp1
{
    public partial class server : Form
    {
        public server()
        {
            InitializeComponent();
        }

        //phần tcp
        private TcpListener tcpListener;
        private TcpClient tcpClient;
        private bool isServerRunninng = false;
        bool check = true;
        Dictionary<string, TcpClient> tcpclients;
        Dictionary<string, TcpClient> tcpclients_2;

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (isServerRunninng)
            {
                isServerRunninng = false;
                tcpListener.Stop();
                Invoke(new Action(() =>
                {
                    richTextBox1.AppendText($"{DateTime.Now} : Server stop listen on port 8080.\r\n");
                }));
                btn_start.Text = "Listen";
            }
            else
            {
                isServerRunninng = true;
                Thread serverThread = new Thread(listen);
                serverThread.Start();
                serverThread.IsBackground = true;
                Invoke(new Action(() =>
                {
                    richTextBox1.AppendText($"{DateTime.Now} : Server is listening on port 8080.\r\n");
                }));
                btn_start.Text = "Stop";
            }
        }
        private void listen()
        {
            tcpListener = new TcpListener(new IPEndPoint(IPAddress.Any, 8080));
            tcpListener.Start();

            tcpclients = new Dictionary<string, TcpClient>();
            tcpclients_2 = new Dictionary<string, TcpClient>();
            while (isServerRunninng)
            {
                try
                {
                    tcpClient = tcpListener.AcceptTcpClient();
                    StreamReader reader = new StreamReader(tcpClient.GetStream());
                    StreamWriter writer = new StreamWriter(tcpClient.GetStream());
                    writer.AutoFlush = true;

                    string rqFromClient = reader.ReadLine();

                    if (rqFromClient == "Login")
                    {
                        string login_data_from_client = reader.ReadLine();
                        User login_user_data = JsonConvert.DeserializeObject<User>(login_data_from_client);
                        bool success = false;
                        Database checkDB = new Database();
                        checkDB.connectToDB();
                        checkDB.Authetication(login_user_data, ref success);
                        checkDB.DisconnectToDB();
                        if (success)
                        {
                            tcpclients.Add(login_user_data.userID, tcpClient);
                            string response = "Login successfully";
                            writer.WriteLine(response);
                            Invoke(new Action(() =>
                            {
                                richTextBox1.AppendText(login_user_data.userID + " vừa đăng nhập.\r\n");
                            }));
                            Thread receiveThread = new Thread(() => recievedDataFromClient(login_user_data.userID));
                            receiveThread.Start();
                            receiveThread.IsBackground = true;
                        }
                        else if (!success)
                        {
                            string response = "Register failed";
                            writer.WriteLine(response);
                        }
                    }
                    if (rqFromClient == "Establish")
                    {
                        string login_data_from_client = reader.ReadLine();
                        User login_user_data = JsonConvert.DeserializeObject<User>(login_data_from_client);

                        if (tcpclients.ContainsKey(login_user_data.userID))
                        {
                            tcpclients_2.Add(login_user_data.userID, tcpClient);
                            string response = "Successfully";
                            writer.WriteLine(response);
                            Thread receiveThread = new Thread(() => recievedDataFromClient1(login_user_data.userID));
                            receiveThread.Start();
                            receiveThread.IsBackground = true;
                        }
                    }
                    else if (rqFromClient == "Register")
                    {
                        string register_data_from_client = reader.ReadLine();
                        User register_user_data = JsonConvert.DeserializeObject<User>(register_data_from_client);
                        bool success = false;
                        Database checkDB = new Database();
                        checkDB.connectToDB();
                        checkDB.Authetication(register_user_data, ref success);
                        checkDB.DisconnectToDB();
                        if (!success)
                        {
                            string response = "Register successfully";
                            writer.WriteLine(response);
                            checkDB.connectToDB();
                            checkDB.saveData(register_user_data);
                            checkDB.DisconnectToDB();
                            tcpclients.Add(register_user_data.userID, tcpClient);

                            Invoke(new Action(() =>
                            {
                                richTextBox1.AppendText(register_user_data.userID + " vừa đăng kí.\r\n");
                            }));
                            Thread receiveThread = new Thread(() => recievedDataFromClient(register_user_data.userID));
                            receiveThread.Start();
                            receiveThread.IsBackground = true;
                        }
                        else
                        {
                            string response = "Register failed";
                            writer.WriteLine(response);
                        }
                    }
                    else if (rqFromClient == "ForgotPassword")
                    {
                        string change_data_from_client = reader.ReadLine();
                        User change_user_data = JsonConvert.DeserializeObject<User>(change_data_from_client);
                        bool success = false;
                        Database checkDB = new Database();
                        checkDB.connectToDB();
                        checkDB.Authetication(change_user_data, ref success);
                        checkDB.DisconnectToDB();
                        if (success)
                        {
                            string response = "Accepted";
                            writer.WriteLine(response);
                            Invoke(new Action(() =>
                            {
                                richTextBox1.AppendText(change_user_data.userID + " yêu cầu đặt lại mật khẩu.\r\n");
                            }));
                        }
                        else
                        {
                            string response = "Not Accepted";
                            writer.WriteLine(response);
                        }
                    }
                    else if (rqFromClient == "Reset Pwd")
                    {
                        string reset_data_from_client = reader.ReadLine();
                        Database checkDB = new Database();
                        User reset_data_user = JsonConvert.DeserializeObject<User>(reset_data_from_client);
                        checkDB.connectToDB();
                        checkDB.updateData(reset_data_user);
                        checkDB.DisconnectToDB();
                        Invoke(new Action(() =>
                        {
                            richTextBox1.AppendText(reset_data_user.userID + " đã đặt lại mật khẩu.\r\n");
                        }));
                        writer.WriteLine("Reset successfully");
                    }
                    else if (rqFromClient == "Quit")
                    {
                        tcpClient.Close();
                    }
                }
                catch
                {

                }
            }
        }
        private void recievedDataFromClient(string userID)
        {
            TcpClient client = tcpclients[userID];
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());
            writer.AutoFlush = true;
            while (client.Connected)
            {
                try
                {
                    string rq_from_client = reader.ReadLine();
                    Database checkDB = new Database();
                    if (rq_from_client == "Message")
                    {
                        string message_from_client = reader.ReadLine();
                        MessageFriend new_message = JsonConvert.DeserializeObject<MessageFriend>(message_from_client);
                        Invoke(new Action(() =>
                        {
                            richTextBox1.AppendText($"Nguoi gui: {new_message.userSend.userName}," +
                                                $" Noi dung: {new_message.content}, " +
                                                $"Nguoi nhan: {new_message.userReceive.userName} " +
                                                $"Room: {new_message.dateSend}\r\n");
                        }));
                        if (tcpclients.ContainsKey(new_message.userReceive.userID))
                        {
                            StreamWriter receiver = new StreamWriter(tcpclients[new_message.userReceive.userID].GetStream());
                            receiver.AutoFlush = true;
                            receiver.WriteLine("Message");
                            receiver.WriteLine(message_from_client);
                            checkDB.connectToDB();
                            checkDB.save_message(new_message.userReceive, new_message.userSend, new_message.content);
                            checkDB.DisconnectToDB();
                        }
                        else
                        {
                            checkDB.connectToDB();
                            checkDB.save_message(new_message.userReceive, new_message.userSend, new_message.content);
                            checkDB.DisconnectToDB();
                        }
                    }
                    else if (rq_from_client == "List User")
                    {
                        checkDB.connectToDB();
                        string user_list = checkDB.getUSer();
                        writer.WriteLine(user_list);
                    }
                    else if (rq_from_client == "Friend List")
                    {
                        string[] friend_list = new string[100];
                        checkDB.connectToDB();
                        checkDB.get_friends(userID, ref friend_list);
                        checkDB.DisconnectToDB();
                        string encode_string = "";
                        foreach (var item in friend_list)
                        {
                            encode_string += item + "|";
                        }
                        writer.WriteLine(encode_string);
                    }
                    else if (rq_from_client == "Notifications")
                    {
                        string[] notifications = new string[100];
                        string data = "";
                        checkDB.connectToDB();
                        checkDB.get_notificaiton(userID, ref notifications);
                        checkDB.DisconnectToDB();
                        foreach (var item in notifications)
                        {
                            data += item + "|";
                        }
                        writer.WriteLine(data);
                    }
                    else if (rq_from_client == "Load Message")
                    {
                        string remote_user = reader.ReadLine();
                        writer.WriteLine("Load Message");
                        writer.WriteLine(remote_user);
                        string data = "";
                        checkDB.connectToDB();
                        checkDB.get_messages(userID, remote_user, ref data);
                        checkDB.DisconnectToDB();
                        if (string.IsNullOrEmpty(data))
                        {
                            writer.WriteLine("Null");
                            break;
                        }
                        writer.WriteLine(data);
                    }
                    else if (rq_from_client == "Add Friend")
                    {
                        string data_sender = reader.ReadLine();
                        string data_receiver = reader.ReadLine();
                        User user = JsonConvert.DeserializeObject<User>(data_sender);
                        User user1 = JsonConvert.DeserializeObject<User>(data_receiver);
                        if (tcpclients.ContainsKey(user1.userID))
                        {
                            StreamWriter writer1 = new StreamWriter(tcpclients[user1.userID].GetStream());
                            writer1.AutoFlush = true;
                            writer1.WriteLine("Add Friend");
                            writer1.WriteLine(data_sender);
                            Invoke(new Action(() =>
                            {
                                richTextBox1.AppendText($"{user.userID} vừa gửi lời mời kết bạn đên {user1.userID}\r\n");
                            }));
                            writer.WriteLine("Sended AddF");
                            writer.WriteLine(data_receiver);
                        }
                        else
                        {
                            bool success = false;
                            Database update = new Database();
                            update.connectToDB();
                            update.add_Notification(user1, user, ref success);
                            update.DisconnectToDB();
                            if (success)
                            {
                                writer.WriteLine("Sended AddF");
                                writer.WriteLine(data_receiver);
                                Invoke(new Action(() =>
                                {
                                    richTextBox1.AppendText($"{user.userID} vừa gửi lời mời kết bạn đên {user1.userID}\r\n");
                                }));
                            }
                        }
                    }
                    else if (rq_from_client == "Cancel AddFriend")
                    {
                        string data_sender = reader.ReadLine();
                        string data_receiver = reader.ReadLine();
                        User user = JsonConvert.DeserializeObject<User>(data_sender);
                        User user1 = JsonConvert.DeserializeObject<User>(data_receiver);
                        if (tcpclients.ContainsKey(user1.userID))
                        {
                            StreamWriter writer1 = new StreamWriter(tcpclients[user1.userID].GetStream());
                            writer1.AutoFlush = true;
                            writer1.WriteLine("Cancel AddFriend");
                            writer1.WriteLine(data_sender);
                            Invoke(new Action(() =>
                            {
                                richTextBox1.AppendText($"{user.userID} không chấp nhận lời mời kết bạn đên {user1.userID}\r\n");
                            }));
                            writer.WriteLine("Cancel AddFriend");
                            writer.WriteLine(data_receiver);
                        }
                        else
                        {
                            Database del = new Database();
                            bool is_success = false;
                            del.connectToDB();
                            del.Del_Notification(user1, user, ref is_success);
                            del.DisconnectToDB();
                            MessageBox.Show(is_success.ToString());
                            if (is_success)
                            {
                                MessageBox.Show(is_success.ToString());
                                Invoke(new Action(() =>
                                {
                                    richTextBox1.AppendText($"{user.userID} không chấp nhận lời mời kết bạn đên {user1.userID}\r\n");
                                }));
                                writer.WriteLine("Cancel AddFriend");
                                writer.WriteLine(data_receiver);
                            }
                        }
                    }
                    else if (rq_from_client == "Accepted")
                    {
                        string data_sender = reader.ReadLine();
                        string data_receiver = reader.ReadLine();
                        User user = JsonConvert.DeserializeObject<User>(data_sender);
                        User user1 = JsonConvert.DeserializeObject<User>(data_receiver);
                        Database database = new Database();
                        if (tcpclients.ContainsKey(user1.userID))
                        {
                            StreamWriter writer1 = new StreamWriter(tcpclients[user1.userID].GetStream());
                            writer1.AutoFlush = true;
                            writer1.WriteLine("Accepted");
                            writer1.WriteLine(data_sender);

                            bool is_success = false;
                            database.connectToDB();
                            database.Add_Friend_Table(user, user1, ref is_success);
                            database.DisconnectToDB();

                            if (is_success)
                            {
                                Invoke(new Action(() =>
                                {
                                    richTextBox1.AppendText($"{user.userID} chấp nhận lời mời kết bạn đên {user1.userID}\r\n");
                                }));
                                writer.WriteLine("Accepted");
                                writer.WriteLine(data_receiver);
                            }
                        }
                        else
                        {
                            bool is_success = false;
                            database.connectToDB();
                            database.Add_Friend_Table(user1, user, ref is_success);
                            database.DisconnectToDB();
                            if (is_success)
                            {
                                Invoke(new Action(() =>
                                {
                                    richTextBox1.AppendText($"{user.userID} chấp nhận lời mời kết bạn đên {user1.userID}\r\n");
                                }));
                                writer.WriteLine("Accepted");
                                writer.WriteLine(data_receiver);
                            }
                        }
                    }
                    else if (rq_from_client == "Quit")
                    {
                        tcpclients.Remove(userID);
                        client.Close();
                    }
                }
                catch
                {

                }
            }
        }
        private void recievedDataFromClient1(string userID)
        {
            TcpClient client = tcpclients_2[userID];
            StreamReader reader = new StreamReader(client.GetStream());
            StreamWriter writer = new StreamWriter(client.GetStream());
            writer.AutoFlush = true;
            while (client.Connected)
            {
                try
                {
                    string rq_from_client = reader.ReadLine();

                    if (rq_from_client == "Add Friend")
                    {
                        string data = reader.ReadLine();
                        MessageBox.Show(data);
                    }
                    else if (rq_from_client == "Quit")
                    {
                        tcpclients_2.Remove(userID);
                        client.Close();
                    }
                }
                catch
                {

                }
            }
        }
    }
}
