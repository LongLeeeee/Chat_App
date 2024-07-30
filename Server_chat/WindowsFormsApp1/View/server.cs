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
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;

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
                            string avatar = "";
                            tcpclients.Add(login_user_data.userID, tcpClient);
                            checkDB.get_data_user(ref login_user_data);
                            checkDB.get_avatar(login_user_data, ref avatar);
                            string response = "Login successfully";
                            writer.WriteLine(response);
                            login_data_from_client = JsonConvert.SerializeObject(login_user_data);
                            writer.WriteLine(login_data_from_client);
                            writer.WriteLine(avatar);
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
                    else if (rq_from_client == "Message For Group")
                    {
                        string message_from_client = reader.ReadLine();
                        MessageGroup new_message = JsonConvert.DeserializeObject<MessageGroup>(message_from_client);
                        Invoke(new Action(() =>
                        {
                            richTextBox1.AppendText($"Nguoi gui: {new_message.userSend.userID}," +
                                                $" Noi dung: {new_message.content}, " +
                                                $"Nhom: {new_message.groupName}, " +
                                                $"Room: {new_message.dateSend}\r\n");
                        }));
                        foreach (var item in new_message.receiver_id_list)
                        {
                            if (item != userID && tcpclients.ContainsKey(item))
                            {
                                StreamWriter writer1 = new StreamWriter(tcpclients[item].GetStream());
                                writer1.AutoFlush = true;
                                writer1.WriteLine("Message For Group");
                                writer1.WriteLine(message_from_client);
                            }
                        }
                        checkDB.connectToDB();
                        checkDB.save_message_group(new_message);
                        checkDB.DisconnectToDB();
                    }
                    else if (rq_from_client == "List User")
                    {
                        checkDB.connectToDB();
                        List<string> user_list = checkDB.getUSer();
                        writer.WriteLine(JsonConvert.SerializeObject(user_list));
                    }
                    else if (rq_from_client == "Friend List")
                    {
                        List<string> friend_list = new List<string>();
                        checkDB.connectToDB();
                        checkDB.get_friends(userID, ref friend_list);
                        checkDB.DisconnectToDB();
                        writer.WriteLine(JsonConvert.SerializeObject(friend_list));
                    }
                    else if (rq_from_client == "Notifications")
                    {
                        List<string> notifications = new List<string>();
                        checkDB.connectToDB();
                        checkDB.get_notificaiton(userID, ref notifications);
                        checkDB.DisconnectToDB();
                        writer.WriteLine(JsonConvert.SerializeObject(notifications));
                    }
                    else if (rq_from_client == "Load Message")
                    {
                        string remote_user = reader.ReadLine();
                        writer.WriteLine("Load Message");
                        string data = "";
                        checkDB.connectToDB();
                        checkDB.get_messages(userID, remote_user, ref data);
                        checkDB.DisconnectToDB();
                        writer.WriteLine(data);
                    }
                    else if (rq_from_client == "Load Message Group")
                    {
                        string group_name = reader.ReadLine();
                        writer.WriteLine("Load Message Group");
                        string data = "";
                        checkDB.connectToDB();
                        checkDB.get_messages_group(ref data, group_name,userID);
                        checkDB.DisconnectToDB();
                        writer.WriteLine(data);
                    }
                    else if (rq_from_client == "Load Group")
                    {
                        List<Group> groupname_members = new List<Group>(); 
                        checkDB.get_infor_group(userID,ref groupname_members);
                        string data = JsonConvert.SerializeObject(groupname_members);
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
                    else if (rq_from_client == "Change Pwd")
                    {
                        string data_user = reader.ReadLine();
                        User user = JsonConvert.DeserializeObject<User>(data_user);  
                        bool is_success = false;    
                        checkDB.connectToDB();
                        checkDB.Authetication(user, ref is_success);
                        checkDB.DisconnectToDB();
                        Thread.Sleep(1000);
                        if (is_success)
                        {
                            writer.WriteLine("Successfully");
                        }
                        else
                        {
                            writer.WriteLine("Unsuccessfully");
                        }
                    }
                    else if (rq_from_client == "Update Pwd")
                    {
                        string data = reader.ReadLine();
                        User user = JsonConvert.DeserializeObject<User>(data);
                        checkDB.connectToDB();
                        checkDB.updateData(user);
                        checkDB.DisconnectToDB();
                        writer.WriteLine("Successfully_Close");
                    }
                    else if (rq_from_client == "Create Group")
                    {
                        string group_data = reader.ReadLine();
                        Group new_group = JsonConvert.DeserializeObject<Group>(group_data);
                        Invoke(new Action(() =>
                        {
                            richTextBox1.AppendText($"{new_group.creator.userID} đã yêu cầu tạo 1 group với tên {new_group.groupName}.\r\n");
                        }));
                        bool is_exist = false;
                        bool is_success = false;   
                        checkDB.connectToDB();
                        checkDB.Add_Group_Table(ref is_exist, ref is_success, new_group);
                        checkDB.DisconnectToDB();
                        if (!is_exist && is_success)
                        {
                            Invoke(new Action(() =>
                            {
                                richTextBox1.AppendText($"{new_group.groupName} đã được tạo.\r\n");
                            }));

                            writer.WriteLine("CreatedGroupForUserCreate");
                            writer.WriteLine(group_data);
                            foreach (var item in new_group.members_userid)
                            {
                                if (item != userID && tcpclients.ContainsKey(item))
                                {
                                    StreamWriter writer1 = new StreamWriter(tcpclients[item].GetStream());
                                    writer1.AutoFlush = true;
                                    writer1.WriteLine("Created Group");
                                    writer1.WriteLine(group_data);
                                }
                            }
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                richTextBox1.AppendText($"{new_group.groupName} tạo không thành công.\r\n");
                            }));
                        }
                    }
                    else if (rq_from_client == "Image")
                    {
                        string receiver = reader.ReadLine();
                        string data = reader.ReadLine();
                        Invoke(new Action(() =>
                        {
                            richTextBox1.AppendText($"{userID} đã gửi 1 ảnh đến {receiver}\r\n");
                        }));
                        if (tcpclients.ContainsKey(receiver))
                        {
                            MessageImageForFriend message = JsonConvert.DeserializeObject<MessageImageForFriend>(data);
                            StreamWriter writer1 = new StreamWriter(tcpclients[receiver].GetStream());
                            writer1.AutoFlush = true;
                            writer1.WriteLine("Image");
                            writer1.WriteLine(receiver);
                            writer1.WriteLine(data);
                        }
                        else
                        {
                            MessageImageForGroup message = JsonConvert.DeserializeObject<MessageImageForGroup>(data);
                            foreach (var item in message.receiver_id_list)
                            {
                                if (item != userID)
                                {
                                    StreamWriter writer1 = new StreamWriter(tcpclients[item].GetStream());
                                    writer1.AutoFlush = true;
                                    writer1.WriteLine("Image");
                                    writer1.WriteLine(receiver);
                                    writer1.WriteLine(data);
                                }
                            }
                        }
                    }
                    else if (rq_from_client == "Icon")
                    {
                        string sender = reader.ReadLine();
                        string receiver = reader.ReadLine();
                        string icon_name = reader.ReadLine();

                        if (tcpclients.ContainsKey(receiver))
                        {
                            StreamWriter writer1 = new StreamWriter(tcpclients[receiver].GetStream());
                            writer1.AutoFlush = true;
                            writer1.WriteLine("Icon");
                            writer1.WriteLine(sender);
                            writer1.WriteLine(icon_name);
                        }
                    }
                    else if (rq_from_client == "File")
                    {
                        string data = reader.ReadLine();
                        string receiver = reader.ReadLine();
                        checkDB.connectToDB();
                        if (tcpclients.ContainsKey(receiver)) {

                            MessageFileForFriend messageFileForFriend = JsonConvert.DeserializeObject<MessageFileForFriend>(data);

                            string file_path = Path.Combine("Resources\\", messageFileForFriend.filename);
                            byte[] buffer = new byte[52428800];
                            int bytesRead;

                            long bytesReceived = 0;

                            NetworkStream networkStream = client.GetStream();
                            FileStream fileStream = new FileStream(file_path, FileMode.Create, FileAccess.Write);
                            while (bytesReceived < messageFileForFriend.fileSize && (bytesRead = networkStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                fileStream.Write(buffer, 0, bytesRead);
                                bytesReceived += bytesRead;
                            }
                            fileStream.Close();
                            Invoke(new Action(() =>
                            {
                                richTextBox1.AppendText(messageFileForFriend.userSend.userID + " vừa gửi 1 file: " + messageFileForFriend.filename + " đến " + messageFileForFriend.userReceive.userID + ".\r\n");
                            }));
                            NetworkStream networkStream1 = tcpclients[receiver].GetStream();   
                            StreamWriter writer1 = new StreamWriter(tcpclients[receiver].GetStream());
                            writer1.AutoFlush = true;
                            writer1.WriteLine("File");
                            writer1.WriteLine(data);
                            writer1.WriteLine(receiver); 
                            FileStream ft = new FileStream(file_path, FileMode.Open, FileAccess.Read);
                            while ((bytesRead = ft.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                networkStream1.Write(buffer, 0, bytesRead);
                            }
                            fileStream.Close();
                        }
                        else if (!tcpclients.ContainsKey(receiver))
                        {

                        }
                        else
                        {
                            MessageFileForGroup messageFileForGroup = JsonConvert.DeserializeObject<MessageFileForGroup>(data);
                            string file_path = Path.Combine("Resources\\", messageFileForGroup.filename);
                            byte[] buffer = new byte[52428800];
                            int bytesRead;

                            long bytesReceived = 0;

                            NetworkStream networkStream = client.GetStream();
                            FileStream fileStream = new FileStream(file_path, FileMode.Create, FileAccess.Write);
                            while (bytesReceived < messageFileForGroup.fileSize && (bytesRead = networkStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                fileStream.Write(buffer, 0, bytesRead);
                                bytesReceived += bytesRead;
                            }
                            fileStream.Close();
                            Invoke(new Action(() =>
                            {
                                richTextBox1.AppendText(messageFileForGroup.userSend.userID + " vừa gửi 1 file: " + messageFileForGroup.filename + " đến " + messageFileForGroup.groupName + ".\r\n");
                            }));
                            foreach (var item in messageFileForGroup.receiver_id_list)
                            {
                                if (tcpclients.ContainsKey(item) && item != userID)
                                {
                                    NetworkStream networkStream1 = tcpclients[item].GetStream();
                                    StreamWriter writer1 = new StreamWriter(tcpclients[item].GetStream());
                                    writer1.AutoFlush = true;
                                    writer1.WriteLine("File");
                                    writer1.WriteLine(data);
                                    writer1.WriteLine(messageFileForGroup.groupName);
                                    FileStream ft = new FileStream(file_path, FileMode.Open, FileAccess.Read);
                                    while ((bytesRead = ft.Read(buffer, 0, buffer.Length)) > 0)
                                    {
                                        networkStream1.Write(buffer, 0, bytesRead);
                                    }
                                    fileStream.Close();
                                }
                            }
                        }
                    }
                    else if (rq_from_client == "Change Username")
                    {
                        string data = reader.ReadLine();
                        User user_request = JsonConvert.DeserializeObject<User>(data);
                        bool is_success = false;
                        checkDB.connectToDB();
                        checkDB.Authetication(user_request, ref is_success);
                        checkDB.DisconnectToDB();
                        if (is_success)
                        {
                            checkDB.connectToDB();
                            checkDB.update_Username(user_request);
                            checkDB.DisconnectToDB();

                            writer.WriteLine("Change Username");
                            writer.WriteLine("Changed Username Successfully");
                            writer.WriteLine(user_request.userName);
                        }
                        else
                        {
                            writer.WriteLine("Change Username");
                            writer.WriteLine("Error");
                        }
                    }
                    else if (rq_from_client == "Set Avatar")
                    {
                        string avatar_data = reader.ReadLine();
                        checkDB.set_avatar(userID, avatar_data);
                        writer.WriteLine("Updated Avatar");
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
                    if (rq_from_client == "Incomming Call")
                    {
                        string userid = reader.ReadLine();
                        Invoke(new Action(() =>
                        {
                            richTextBox1.AppendText(userID + " đang gọi đến " + userid + ".\r\n");
                        }));
                        if (tcpclients_2.ContainsKey(userid))
                        {
                            StreamWriter writer1 = new StreamWriter(tcpclients_2[userid].GetStream());
                            writer1.WriteLine("Incomming Call");
                            writer1.WriteLine(userID);
                            writer1.Flush();
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                richTextBox1.AppendText(userid + " không bắt máy.\r\n");
                            }));
                        }
                    }
                    else if (rq_from_client == "Pick up")
                    {
                        string userid = reader.ReadLine();

                        Invoke(new Action(() =>
                        {
                            richTextBox1.AppendText(userID + " vừa nghe cuộc gọi của " + userid + ".\r\n");
                        }));
                        StreamWriter writer1 = new StreamWriter(tcpclients_2[userid].GetStream());
                        writer1.WriteLine("Pick up");
                        writer1.Flush();
                    }
                    else if (rq_from_client == "Sender hang up")
                    {
                        string userid = reader.ReadLine();
                        Invoke(new Action(() =>
                        {
                            richTextBox1.AppendText(userID + " vừa tắt.\r\n");
                        }));
                        if (tcpclients_2.ContainsKey(userid))
                        {
                            StreamWriter writer1 = new StreamWriter(tcpclients_2[userid].GetStream());
                            writer1.AutoFlush = true;
                            writer1.WriteLine("Sender hang up");
                        }
                        else
                        {
                            Invoke(new Action(() =>
                            {
                                richTextBox1.AppendText(userID + " tắt máy.\r\n");
                            }));
                        }
                    }
                    else if (rq_from_client == "Receiver hang up")
                    {
                        string userid = reader.ReadLine();
                        Invoke(new Action(() =>
                        {
                            richTextBox1.AppendText(userID + " vừa tắt.\r\n");
                        }));
                        StreamWriter writer1 = new StreamWriter(tcpclients_2[userid].GetStream());
                        writer1.AutoFlush = true;
                        writer1.WriteLine("Receiver hang up");
                    }
                    else if (rq_from_client == "Quit")
                    {
                        tcpclients_2.Remove(userID);
                        client.Close();
                    }
                    else if (rq_from_client == "Calling")
                    {
                        string userid = reader.ReadLine();

                        NetworkStream stream1 = client.GetStream();
                        byte[] buffer = new byte[1024];
                        int bytesRead;
                        bool iscalling = true;

                        while (iscalling)
                        {
                            bytesRead = stream1.Read(buffer, 0, buffer.Length);
                            string signal = Encoding.UTF8.GetString(buffer);
                            if (signal == "End Call")
                            {
                                Invoke(new Action(() =>
                                {
                                    richTextBox1.AppendText(userID + " vừa tắt cuộc gọi.\r\n");
                                }));
                                iscalling = false;
                                break;
                            }
                            else
                            {
                                NetworkStream networkStream2 = tcpclients_2[userid].GetStream();
                                networkStream2.Write(buffer, 0, buffer.Length);
                            }
                        }
                    }
                }
                catch
                {

                }
            }
        }
    }
}
