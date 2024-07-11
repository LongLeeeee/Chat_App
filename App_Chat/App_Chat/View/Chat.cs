using App_Chat.Model;
using App_Chat.UserControls;
using Bunifu.UI.WinForms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Chat.View
{
    public partial class Chat : Form
    {
        public Chat(TcpClient tcpClient, TcpClient tcpClient1 ,User user)
        {
            InitializeComponent();
            this.your_account_name = user;
            this.tcpClient1 = tcpClient1;
            this.tcpClient = tcpClient;

            writer = new StreamWriter(tcpClient.GetStream());
            reader = new StreamReader(tcpClient.GetStream());
            writer.AutoFlush = true;

            writer_1 = new StreamWriter(tcpClient1.GetStream());
            reader_1 = new StreamReader(tcpClient1.GetStream());
            writer_1.AutoFlush = true;

            writer.WriteLine("List User");

            string users = reader.ReadLine();
            user_list = users.Split('|');
        }
        private Dictionary<BoxChat, FlowLayoutPanel> user_boardChat;
        private Dictionary<string, FlowLayoutPanel> receiver_boardChat;
        private List<NewFriend> Users;
        private List<string> box_chat = new List<string>();
        private TcpClient tcpClient;
        private TcpClient tcpClient1;
        private StreamWriter writer;
        private StreamReader reader;
        private StreamWriter writer_1;
        private StreamReader reader_1;
        private User your_account_name;
        private bool isRunning = false;

        string[] user_list;

        private void btn_find_msg_Click(object sender, EventArgs e)
        {
            if (panel8.Visible == false)
            {
                panel8.Visible = true;
            }
            else
            {
                panel8.Visible = false;
            }
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {

        }

        private void btn_find_new_user_Click(object sender, EventArgs e)
        {

        }
        private void btn_display_box_chat_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
            }
            else
            {
                pn_display_user.Visible = false;
                panel2.Visible = true;
            }
        }

        private void btn_display_list_user_Click(object sender, EventArgs e)
        {
            if (pn_display_user.Visible == true)
            {
                pn_display_user.Visible = false;
            }
            else
            {
                pn_display_user.Visible = true;
                panel2.Visible = false;
            }
        }
        private void add_Click(object sender, EventArgs e)
        {

        }
        private void bunifuPictureBox2_Click_1(object sender, EventArgs e)
        {
            if (panel_personal_properties.Visible == true)
            {
                panel_personal_properties.Visible = false;
            }
            else
            {
                panel_personal_properties.Visible = true;
            }
        }

        private void img_friend_properties_Click(object sender, EventArgs e)
        {
            if (panel6.Visible == true)
            {
                panel6.Visible = false;
            }
            else
            {
                panel6.Visible = true;
            }
        }
        private FlowLayoutPanel createFlowLayoutPanel()
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.AllowDrop = true;
            flowLayoutPanel.Dock = DockStyle.Fill;
            flowLayoutPanel.Visible = false;
            panel15.Controls.Add(flowLayoutPanel);
            return flowLayoutPanel;
        }
        private void load_users()
        {
            Users = new List<NewFriend>();
            foreach (var item in user_list)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    Invoke(new Action(() =>
                    {
                        NewFriend newFriend = new NewFriend(tcpClient, your_account_name);
                        Users.Add(newFriend);
                        newFriend.setLabel(item);
                        fpn_show_users.Controls.Add(newFriend);
                    }));
                }
            }
        }
        private void load_box_chat()
        {
            user_boardChat = new Dictionary<BoxChat, FlowLayoutPanel>();
            receiver_boardChat = new Dictionary<string, FlowLayoutPanel>();
            foreach (var item in user_list)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    Invoke(new Action(() =>
                    {
                        BoxChat boxChat = new BoxChat();
                        boxChat.Click += show_panel_click;
                        boxChat.setName(item);

                        FlowLayoutPanel flowLayoutPanel = createFlowLayoutPanel();
                        user_boardChat.Add(boxChat, flowLayoutPanel);
                        receiver_boardChat.Add(item, flowLayoutPanel);

                        panel_box_chat.Controls.Add(boxChat);
                    }));
                }
            }
        }
        private void show_panel_click(object sender, EventArgs e)
        {
            BoxChat clicked_box_chat = (BoxChat)sender;
            if (user_boardChat.ContainsKey(clicked_box_chat))
            {
                user_boardChat[clicked_box_chat].Visible = true;
                lb_remote_name.Text = clicked_box_chat.getName();
                tb_enter_message.Clear();
            }
        }
        private void btn_send_Click_1(object sender1, EventArgs e)
        {
            writer = new StreamWriter(tcpClient.GetStream());
            User sender = new User()
            {
                userID = your_account_name.userID,
                userName = your_account_name.userName,
            };
            User receiver = new User()
            {
                userID = lb_remote_name.Text,
                userName = lb_remote_name.Text,
            };
            if (user_list.Contains(lb_remote_name.Text))
            {
                MessageFriend new_message = new MessageFriend()
                {
                    userSend = sender,
                    content = tb_enter_message.Text,
                    dateSend = DateTime.Now,
                    userReceive = receiver,
                };
                string messString = JsonConvert.SerializeObject(new_message);
                writer.WriteLine("Message");
                writer.WriteLine(messString);
                writer.Flush();
                if (receiver_boardChat.ContainsKey(receiver.userName))
                {
                    SendMessage se = new SendMessage();
                    se.setLabel(tb_enter_message.Text);
                    receiver_boardChat[receiver.userName].Controls.Add(se);
                    tb_enter_message.Clear();
                }
            }
        }
        private void receive()
        {
            try
            {
                while (isRunning)
                {
                    string rs_from_server = this.reader.ReadLine();
                    if (rs_from_server.CompareTo("Message") == 0)
                    {
                        string content_from_server = reader.ReadLine();
                        MessageFriend received_message = JsonConvert.DeserializeObject<MessageFriend>(content_from_server);
                        User sender = received_message.userSend;
                        MessageBox.Show(receiver_boardChat.ContainsKey(sender.userID).ToString());
                        if (receiver_boardChat.ContainsKey(sender.userID))
                        {
                            Invoke(new Action(() =>
                            {
                                ReceiveMessage re = new ReceiveMessage();
                                re.setLabel(received_message.content);
                                receiver_boardChat[sender.userID].Controls.Add(re);
                            }));
                        }
                    }
                    else if (rs_from_server == "Sended AddF")
                    {
                        string data_from_server = reader.ReadLine();
                        User user = JsonConvert.DeserializeObject<User>(data_from_server);
                        if (user_list.Contains(user.userID))
                        {
                            foreach (var item in Users)
                            {
                                string temp = item.get_user_id();
                                if (temp == user.userID)
                                {
                                    item.setButton("Đã gửi");
                                    Invoke(new Action(() =>
                                    {
                                        item.setButton2(true);
                                    }));
                                    break;
                                }
                            }
                        }
                    }
                    else if (rs_from_server == "Add Friend")
                    {
                        string data_from_server = reader.ReadLine();
                        User user = JsonConvert.DeserializeObject<User>(data_from_server);
                        if (user_list.Contains(user.userID))
                        {
                            foreach (var item in Users)
                            {
                                string temp = item.get_user_id();
                                if (temp == user.userID)
                                {
                                    item.setButton("Chấp Nhận");
                                    Invoke(new Action(() =>
                                    {
                                        item.setButton2(true);
                                    }));
                                }
                                break;
                            }
                        }
                    }
                    else if (rs_from_server == "Cancel AddFriend")
                    {
                        string data_from_server = reader.ReadLine();
                        User user = JsonConvert.DeserializeObject<User>(data_from_server);
                        MessageBox.Show(user_list.Contains(user.userID).ToString());
                        if (user_list.Contains(user.userID))
                        {
                            foreach (var item in Users)
                            {
                                string temp = item.get_user_id();
                                if (temp == user.userID)
                                {
                                    item.setButton("Kết bạn");
                                    Invoke(new Action(() =>
                                    {
                                        item.setButton2(false);
                                    }));
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {

            }
        }
        private void Chat_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread load_box_chat_thread = new Thread(load_box_chat);
            load_box_chat_thread.Start();
            load_box_chat_thread.IsBackground = true;

            Thread load_show_users_thread = new Thread(load_users);
            load_show_users_thread.Start();
            load_show_users_thread.IsBackground = true;

            isRunning = true;
            Thread receiveThread = new Thread(receive);
            receiveThread.Start();
            receiveThread.IsBackground = true;
        }
    }
}
