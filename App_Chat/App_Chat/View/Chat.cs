using App_Chat.Model;
using App_Chat.UserControls;
using Bunifu.UI.WinForms;
using NAudio.Wave;
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
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace App_Chat.View
{
    public partial class Chat : Form
    {
        public Chat(TcpClient tcpClient, TcpClient tcpClient1, User user, string avatar)
        {
            InitializeComponent();
            this.your_account_name = user;
            lb_name.Text = your_account_name.userName;
            if (!string.IsNullOrEmpty(avatar))
            {
                bunifuPictureBox1.Image = StringToImage(avatar);
                bunifuPictureBox2.Image = bunifuPictureBox1.Image;
            }
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
            user_list = JsonConvert.DeserializeObject<List<string>>(users);

            writer.WriteLine("Friend List");

            string friends = reader.ReadLine();
            friend_list = JsonConvert.DeserializeObject<List<string>>(friends);

            writer.WriteLine("Notifications");

            string notificaitons = reader.ReadLine();
            noti_list = JsonConvert.DeserializeObject<List<string>>(notificaitons);

            writer.WriteLine("Load Group");

            string data = reader.ReadLine();
            groups = JsonConvert.DeserializeObject<List<Group>>(data);

            groups_members = new Dictionary<string, Group>();

        }
        Thread receiveThread;
        Thread receiveThread2;

        private Dictionary<BoxChat, FlowLayoutPanel> user_boardChat;
        private Dictionary<string, FlowLayoutPanel> receiver_boardChat;
        private Dictionary<string, Group> groups_members;
        private List<NewFriend> Users;
        private List<BoxChat> boxchats;
        private List<string> box_chat = new List<string>();
        private TcpClient tcpClient;
        private TcpClient tcpClient1;
        private StreamWriter writer;
        private StreamReader reader;
        private StreamWriter writer_1;
        private StreamReader reader_1;
        private User your_account_name;
        private bool isRunning = false;

        private List<string> user_list;
        private List<string> friend_list;
        private List<string> noti_list;
        List<Group> groups;
        Image new_avatar;

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
                bunifuLabel3.Text = lb_name.Text;
                bunifuPictureBox4.Image = bunifuPictureBox3.Image;
            }
        }
        private void bunifuPictureBox2_MouseEnter(object sender, EventArgs e)
        {
            bunifuPictureBox2.BackColor = SystemColors.Control;
        }
        private void bunifuPictureBox2_MouseLeave(object sender, EventArgs e)
        {
            bunifuPictureBox2.BackColor = SystemColors.Window;
        }
        private void btn_display_box_chat_MouseEnter(object sender, EventArgs e)
        {
            btn_display_box_chat.BackColor = SystemColors.Control;
        }
        private void btn_display_box_chat_MouseLeave(object sender, EventArgs e)
        {
            btn_display_box_chat.BackColor = SystemColors.Window;
        }
        private void btn_display_list_user_MouseEnter(object sender, EventArgs e)
        {
            btn_display_list_user.BackColor = SystemColors.Control;
        }

        private void btn_display_list_user_MouseLeave(object sender, EventArgs e)
        {
            btn_display_list_user.BackColor = SystemColors.Window;
        }

        private void add_MouseEnter(object sender, EventArgs e)
        {
            add.BackColor = SystemColors.Control;
        }

        private void add_MouseLeave(object sender, EventArgs e)
        {
            add.BackColor = SystemColors.Control;
        }

        //find section
        private void tb_find_message_TextChange(object sender, EventArgs e)
        {
            if (receiver_boardChat.ContainsKey(lb_remote_name.Text.Trim()))
            {
                foreach (Control control in receiver_boardChat[lb_remote_name.Text].Controls)
                {
                    if (control is ReceiveMessage re && re.getLabel().Contains(tb_find_message.Text))
                    {
                        re.Visible = true;
                    }
                    else if (control is SendMessage se && se.getLabel().Contains(tb_find_message.Text))
                    {
                        se.Visible = true;
                    }
                    else
                    {
                        control.Visible = false;
                    }
                }
            }
        }
        private void tb_enter_friend_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in Users)
            {
                string temp = item.get_user_id();
                if (temp.Contains(tb_enter_friend.Text.Trim()))
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
            }
        }

        private void tb_enter_userid_TextChanged(object sender, EventArgs e)
        {
            foreach (var item in boxchats)
            {
                string temp = item.getName();
                if (temp.Contains(tb_enter_userid.Text.Trim()))
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
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
            panel21.Controls.Add(flowLayoutPanel);
            return flowLayoutPanel;
        }
        private void load_users()
        {
            Users = new List<NewFriend>();
            foreach (var item in user_list)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    if (item != your_account_name.userID && !friend_list.Contains(item))
                    {
                        if (noti_list.Contains(item))
                        {
                            Invoke(new Action(() =>
                            {
                                NewFriend newFriend = new NewFriend(tcpClient, your_account_name);
                                Users.Add(newFriend);
                                newFriend.setLabel(item);
                                fpn_show_users.Controls.Add(newFriend);
                                newFriend.setButton("Chấp nhận");
                                newFriend.setButton2(true);
                            }));
                        }
                        else
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
            }
        }
        private void load_groups()
        {
            if (groups == null) { return; }
            foreach (var item in groups)
            {
                if (item != null)
                {
                    Invoke(new Action(() =>
                    {
                        BoxChat boxChat = new BoxChat();
                        boxChat.Click += show_panel_click;
                        boxChat.setName(item.groupName);

                        FlowLayoutPanel flowLayoutPanel = createFlowLayoutPanel();
                        boxchats.Add(boxChat);
                        user_boardChat.Add(boxChat, flowLayoutPanel);
                        receiver_boardChat.Add(item.groupName, flowLayoutPanel);

                        panel_box_chat.Controls.Add(boxChat);
                    }));
                    Thread thread = new Thread(() => load_message_group(item));
                    thread.Start();
                }
            }
        }
        private void load_message_group(Group item)
        {
            writer.WriteLine("Load Message Group");
            writer.WriteLine(item.groupName);

            string data = "";
            data = reader.ReadLine();
            string[] messages = data.Split('|');
            foreach (string message in messages)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    string userid = message.Substring(message.IndexOf(":") + 1);
                    string text = message.Substring(0, message.IndexOf(":"));
                    if (userid == your_account_name.userID)
                    {
                        SendMessage se = new SendMessage();
                        se.setLabel(text, userid);
                        receiver_boardChat[item.groupName].Controls.Add(se);
                    }
                    else
                    {
                        ReceiveMessage se = new ReceiveMessage();
                        se.setLabel(userid, text);
                        receiver_boardChat[item.groupName].Controls.Add(se);
                    }
                }
            }
            groups_members.Add(item.groupName, item);
        }
        private void load_box_chat()
        {
            foreach (var item in friend_list)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    Invoke(new Action(() =>
                    {
                        BoxChat boxChat = new BoxChat();
                        boxChat.Click += show_panel_click;
                        boxChat.setName(item);

                        FlowLayoutPanel flowLayoutPanel = createFlowLayoutPanel();
                        boxchats.Add(boxChat);
                        user_boardChat.Add(boxChat, flowLayoutPanel);
                        receiver_boardChat.Add(item, flowLayoutPanel);
                        panel_box_chat.Controls.Add(boxChat);
                    }));
                    Thread thread = new Thread(() => load_message_friend(item));
                    thread.Start();
                }
            }
        }
        private void load_message_friend(string item)
        {
            writer.WriteLine("Load Message");
            writer.WriteLine(item);

            string data = "";
            data = reader.ReadLine();
            string[] messages = data.Split('|');
            foreach (string message in messages)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    string userid = message.Substring(message.IndexOf(":") + 1);
                    string text = message.Substring(0, message.IndexOf(":"));
                    if (userid == your_account_name.userID)
                    {
                        Invoke(new Action(() =>
                        {
                            SendMessage se = new SendMessage();
                            se.setLabel(text, userid);
                            receiver_boardChat[item].Controls.Add(se);
                        }));
                    }
                    else
                    {
                        Invoke(new Action(() =>
                        {
                            ReceiveMessage se = new ReceiveMessage();
                            se.setLabel(userid, text);
                            receiver_boardChat[item].Controls.Add(se);
                        }));
                    }
                }
            }
        }
        private void show_panel_click(object sender, EventArgs e)
        {
            BoxChat clicked_box_chat = (BoxChat)sender;
            bunifuPictureBox3.Image = clicked_box_chat.get_avatar();
            if (user_boardChat.ContainsKey(clicked_box_chat))
            {
                panel13.Visible = true;
                foreach (var item in user_boardChat)
                {
                    if (item.Key == clicked_box_chat && friend_list.Contains(item.Key.get_user_id()))
                    {
                        panel7.Visible = true;
                        panel17.Visible = false;
                        item.Value.Visible = true;
                        panel21.Visible = true;
                        lb_remote_name.Text = clicked_box_chat.getName();
                        lb_user_id.Text = clicked_box_chat.get_user_id();
                        tb_enter_message.Clear();
                    }
                    else if (item.Key == clicked_box_chat && !friend_list.Contains(item.Key.get_user_id()))
                    {
                        panel7.Visible = true;
                        panel17.Visible = false;
                        item.Value.Visible = true;
                        panel21.Visible = true;
                        lb_remote_name.Text = clicked_box_chat.getName();
                        lb_user_id.Text = clicked_box_chat.get_user_id();
                        tb_enter_message.Clear();
                    }
                    else
                    {
                        item.Value.Visible = false;
                    }
                }
            }
        }
        private void add_Click(object sender, EventArgs e)
        {
            CreateGroup createGroup = new CreateGroup(your_account_name, writer, reader, friend_list);
            createGroup.Show();
        }
        private void btn_send_Click_1(object sender1, EventArgs e)
        {
            if (!groups_members.ContainsKey(lb_remote_name.Text))
            {
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
                    if (receiver_boardChat.ContainsKey(receiver.userName))
                    {
                        SendMessage se = new SendMessage();
                        se.setLabel(tb_enter_message.Text, your_account_name.userID);
                        receiver_boardChat[receiver.userName].Controls.Add(se);
                        tb_enter_message.Clear();
                    }
                }
            }
            else
            {
                User sender = new User()
                {
                    userID = your_account_name.userID,
                    userName = your_account_name.userName,
                };
                MessageGroup messageGroup = new MessageGroup()
                {
                    groupName = lb_remote_name.Text,
                    content = tb_enter_message.Text,
                    userSend = sender,
                    dateSend = DateTime.Now,
                    receiver_id_list = groups_members[lb_remote_name.Text].members_userid,
                };
                string data = JsonConvert.SerializeObject(messageGroup);
                writer.WriteLine("Message For Group");
                writer.WriteLine(data);
                if (receiver_boardChat.ContainsKey(messageGroup.groupName))
                {
                    SendMessage se = new SendMessage();
                    se.setLabel(tb_enter_message.Text, your_account_name.userID);
                    receiver_boardChat[messageGroup.groupName].Controls.Add(se);
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
                        if (receiver_boardChat.ContainsKey(sender.userID))
                        {
                            Invoke(new Action(() =>
                            {
                                ReceiveMessage re = new ReceiveMessage();
                                re.setLabel(received_message.content, sender.userID);
                                receiver_boardChat[sender.userID].Controls.Add(re);
                            }));
                        }
                    }
                    else if (rs_from_server.CompareTo("Message For Group") == 0)
                    {
                        string content_from_server = reader.ReadLine();
                        MessageGroup received_message = JsonConvert.DeserializeObject<MessageGroup>(content_from_server);
                        User sender = received_message.userSend;
                        if (receiver_boardChat.ContainsKey(received_message.groupName))
                        {
                            Invoke(new Action(() =>
                            {
                                ReceiveMessage re = new ReceiveMessage();
                                re.setLabel(received_message.content, sender.userID);
                                receiver_boardChat[received_message.groupName].Controls.Add(re);
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
                                    item.setButton("Chấp nhận");
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
                    else if (rs_from_server == "Accepted")
                    {
                        string data_from_server = reader.ReadLine();
                        User user = JsonConvert.DeserializeObject<User>(data_from_server);
                        if (user_list.Contains(user.userID))
                        {
                            int i = 0;
                            foreach (var item in Users)
                            {
                                string temp = item.get_user_id();
                                if (temp == user.userID)
                                {
                                    Invoke(new Action(() =>
                                    {
                                        BoxChat boxChat = new BoxChat();
                                        boxChat.Click += show_panel_click;
                                        boxChat.setName(temp);

                                        FlowLayoutPanel flowLayoutPanel = createFlowLayoutPanel();
                                        user_boardChat.Add(boxChat, flowLayoutPanel);
                                        receiver_boardChat.Add(temp, flowLayoutPanel);

                                        panel_box_chat.Controls.Add(boxChat);

                                        fpn_show_users.Controls.Remove(Users[i]);
                                    }));
                                    i++;
                                    break;
                                }
                            }
                        }
                    }
                    else if (rs_from_server == "CreatedGroupForUserCreate")
                    {
                        string group_data = reader.ReadLine();
                        Invoke(new Action(() =>
                        {
                            Group created_group = JsonConvert.DeserializeObject<Group>(group_data);
                            groups_members.Add(created_group.groupName, created_group);

                            FlowLayoutPanel flowLayoutPanel = createFlowLayoutPanel();
                            BoxChat boxChat = new BoxChat();
                            boxChat.Click += show_panel_click;
                            boxChat.setName(created_group.groupName);

                            boxchats.Add(boxChat);
                            user_boardChat.Add(boxChat, flowLayoutPanel);
                            receiver_boardChat.Add(created_group.groupName, flowLayoutPanel);

                            panel_box_chat.Controls.Add(boxChat);
                        }));
                    }
                    else if (rs_from_server == "Created Group")
                    {
                        string group_data = reader.ReadLine();
                        Invoke(new Action(() =>
                        {
                            Group created_group = JsonConvert.DeserializeObject<Group>(group_data);
                            groups_members.Add(created_group.groupName, created_group);

                            FlowLayoutPanel flowLayoutPanel = createFlowLayoutPanel();
                            BoxChat boxChat = new BoxChat();
                            boxChat.Click += show_panel_click;
                            boxChat.setName(created_group.groupName);

                            boxchats.Add(boxChat);
                            user_boardChat.Add(boxChat, flowLayoutPanel);
                            receiver_boardChat.Add(created_group.groupName, flowLayoutPanel);

                            panel_box_chat.Controls.Add(boxChat);
                        }));
                    }
                    else if (rs_from_server == "Image")
                    {
                        string receiver = reader.ReadLine();
                        string data = reader.ReadLine();
                        if (groups_members.ContainsKey(receiver))
                        {
                            MessageImageForGroup messageImageForGroup = JsonConvert.DeserializeObject<MessageImageForGroup>(data);
                            Invoke(new Action(() =>
                            {
                                Image temp_image = StringToImage(messageImageForGroup.content);
                                ReceiveImage receiveImage = new ReceiveImage();
                                receiveImage.set_image(temp_image);
                                receiveImage.set_label_name(messageImageForGroup.userSend.userID);

                                receiver_boardChat[receiver].Controls.Add(receiveImage);
                            }));
                        }
                        else
                        {
                            MessageImageForFriend messageImageForFriend = JsonConvert.DeserializeObject<MessageImageForFriend>(data);
                            if (receiver_boardChat.ContainsKey(messageImageForFriend.userSend.userID))
                            {
                                Invoke(new Action(() =>
                                {
                                    Image temp_image = StringToImage(messageImageForFriend.content);
                                    ReceiveImage receiveImage = new ReceiveImage();
                                    receiveImage.set_image(temp_image);
                                    receiveImage.set_label_name(messageImageForFriend.userSend.userID);

                                    receiver_boardChat[messageImageForFriend.userSend.userID].Controls.Add(receiveImage);
                                }));
                            }
                        }
                    }
                    else if (rs_from_server == "Icon")
                    {
                        string sender = reader.ReadLine();
                        string icon_name = reader.ReadLine();
                        if (receiver_boardChat.ContainsKey(sender))
                        {
                            Invoke(new Action(() =>
                            {

                                Receive_Icon receive_Icon = new Receive_Icon();
                                Image icon = Image.FromFile(icon_name);
                                receive_Icon.set_icon(icon);
                                receiver_boardChat[sender].Controls.Add(receive_Icon);
                            }));
                        }
                    }
                    else if (rs_from_server == "File")
                    {
                        string data = reader.ReadLine();
                        string receiver = reader.ReadLine().Trim();
                        NetworkStream networkStream = tcpClient.GetStream();
                        if (!groups_members.ContainsKey(receiver))
                        {
                            MessageFileForFriend messageFileForFriend = JsonConvert.DeserializeObject<MessageFileForFriend>(data);
                            string filePath = Path.Combine("Resources\\", messageFileForFriend.filename);
                            byte[] buffer = new byte[52428800];
                            int bytesRead;
                            long bytesReceived = 0;

                            FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                            while ((bytesReceived < messageFileForFriend.fileSize) &&
                                   (bytesRead = networkStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                fileStream.Write(buffer, 0, bytesRead);
                                bytesReceived += bytesRead;
                            }
                            fileStream.Close();

                            if (receiver_boardChat.ContainsKey(messageFileForFriend.userSend.userID))
                            {
                                Invoke(new Action(() =>
                                {
                                    ReceiveMessage receiveMessage = new ReceiveMessage();
                                    receiveMessage.set_filename(messageFileForFriend.filename, messageFileForFriend.userSend.userID);
                                    receiver_boardChat[messageFileForFriend.userSend.userID].Controls.Add(receiveMessage);
                                }));
                            }
                        }
                        else
                        {
                            MessageFileForGroup messageFileForGroup = JsonConvert.DeserializeObject<MessageFileForGroup>(data);
                            string filePath = Path.Combine("Resources\\", messageFileForGroup.filename);
                            byte[] buffer = new byte[52428800];
                            int bytesRead;
                            long bytesReceived = 0;

                            FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                            while ((bytesReceived < messageFileForGroup.fileSize) &&
                                   (bytesRead = networkStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                fileStream.Write(buffer, 0, bytesRead);
                                bytesReceived += bytesRead;
                            }
                            fileStream.Close();

                            if (receiver_boardChat.ContainsKey(messageFileForGroup.groupName))
                            {
                                Invoke(new Action(() =>
                                {
                                    ReceiveMessage receiveMessage = new ReceiveMessage();
                                    receiveMessage.set_filename(messageFileForGroup.filename, messageFileForGroup.userSend.userID);
                                    receiver_boardChat[messageFileForGroup.groupName].Controls.Add(receiveMessage);
                                }));
                            }
                        }
                    }
                    else if (rs_from_server == "Change Username")
                    {
                        string result = reader.ReadLine();
                        if (result == "Changed Username Successfully")
                        {
                            string new_username = reader.ReadLine();
                            lb_name.Text = new_username;
                        }
                        else
                        {
                            MessageBox.Show("Error");
                        }
                    }
                    else if (rs_from_server == "Updated Avatar")
                    {
                        bunifuPictureBox1.Image = new_avatar;
                        bunifuPictureBox2.Image = new_avatar;
                    }
                }
            }
            catch
            {

            }
        }
        private Image StringToImage(string data)
        {
            try
            {
                byte[] imageBytes = Convert.FromBase64String(data);
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Image image = Image.FromStream(ms);
                    return image;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return null;
            }
        }
        private void Chat_Load(object sender, EventArgs e)
        {
            user_boardChat = new Dictionary<BoxChat, FlowLayoutPanel>();
            receiver_boardChat = new Dictionary<string, FlowLayoutPanel>();
            boxchats = new List<BoxChat>();

            CheckForIllegalCrossThreadCalls = false;
            Thread load_box_chat_thread = new Thread(load_box_chat);
            load_box_chat_thread.Start();
            load_box_chat_thread.IsBackground = true;

            Thread load_show_users_thread = new Thread(load_users);
            load_show_users_thread.Start();
            load_show_users_thread.IsBackground = true;

            Thread load_show_groups_thread = new Thread(load_groups);
            load_show_groups_thread.Start();
            load_show_groups_thread.IsBackground = true;

            isRunning = true;
            receiveThread = new Thread(receive);
            receiveThread.Start();
            receiveThread.IsBackground = true;

            receiveThread2 = new Thread(receive2);
            receiveThread2.Start();
            receiveThread2.IsBackground = true;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            writer.WriteLine("Quit");
            writer_1.WriteLine("Quit");
            tcpClient.Close();
            tcpClient1.Close();
            Application.Exit();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            writer.WriteLine("Quit");
            writer_1.WriteLine("Quit");
            tcpClient.Close();
            tcpClient1.Close();
            Thread LGThread = new Thread(() => Application.Run(new Login()));
            LGThread.ApartmentState = ApartmentState.STA;
            LGThread.Start();
            this.Close();
        }

        private void btn_change_pwd_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword(tcpClient, your_account_name);
            changePassword.ShowDialog();
        }
        private void attachment_Click(object sender, EventArgs e)
        {
            if (panel17.Visible)
            {
                panel17.Visible = false;
            }
            else
            {
                panel17.Visible = true;
            }
        }

        private void SendImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            {
                openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (receiver_boardChat.ContainsKey(lb_remote_name.Text))
                    {
                        SendImage sendImage = new SendImage();
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

                        pictureBox.Image = Image.FromFile(openFileDialog.FileName);
                        string path = openFileDialog.FileName;
                        string filename = Path.GetFileName(path);
                        sendImage.set_picturebox(pictureBox.Image);
                        sendImage.set_label_name(your_account_name.userID);
                        Invoke(new Action(() =>
                        {
                            receiver_boardChat[lb_remote_name.Text].Controls.Add(sendImage);
                        }));
                        try
                        {
                            string imageData = ImageToBase64String(sendImage.get_picturebox());
                            writer.AutoFlush = true;
                            User receiver = new User()
                            {
                                userName = lb_remote_name.Text,
                            };
                            if (friend_list.Contains(lb_remote_name.Text))
                            {
                                MessageImageForFriend message = new MessageImageForFriend()
                                {
                                    content = imageData,
                                    userSend = your_account_name,
                                    dateSend = DateTime.Now,
                                    filename = filename,
                                    userReceive = receiver,
                                };
                                string data = JsonConvert.SerializeObject(message);
                                writer.WriteLine("Image");
                                writer.WriteLine(lb_remote_name.Text);
                                writer.WriteLine(data);
                            }
                            else if (groups_members.ContainsKey(lb_remote_name.Text))
                            {
                                MessageImageForGroup message = new MessageImageForGroup()
                                {
                                    content = imageData,
                                    userSend = your_account_name,
                                    dateSend = DateTime.Now,
                                    filename = filename,
                                    groupName = lb_remote_name.Text,
                                    receiver_id_list = groups_members[lb_remote_name.Text].members_userid,
                                };
                                string data = JsonConvert.SerializeObject(message);
                                writer.WriteLine("Image");
                                writer.WriteLine(lb_remote_name.Text);
                                writer.WriteLine(data);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }
        private string ImageToBase64String(Image image)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] imageBytes = ms.ToArray();
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
                return null;
            }
        }
        private void ClickIcon(object sender, EventArgs e)
        {
            BunifuImageButton bt = (BunifuImageButton)sender;
            SendIcon(bt.Tag.ToString());
            panel19.Visible = false;
        }
        private void SendIcon(string name)
        {
            if (receiver_boardChat.ContainsKey(lb_remote_name.Text))
            {
                Image icon = Image.FromFile(name);

                Send_Icon sendIcon = new Send_Icon();
                sendIcon.set_icon(icon);
                Invoke(new Action(() =>
                {
                    receiver_boardChat[lb_remote_name.Text].Controls.Add(sendIcon);
                }));

                writer.WriteLine("Icon");
                writer.WriteLine(your_account_name.userID);
                writer.WriteLine(lb_remote_name.Text);
                writer.WriteLine(name);
            }
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = openFileDialog.FileName;
                if (receiver_boardChat.ContainsKey(lb_remote_name.Text))
                {
                    try
                    {
                        if (friend_list.Contains(lb_remote_name.Text))
                        {

                            FileInfo fileInfo = new FileInfo(filepath);
                            string file_name = fileInfo.Name;
                            long file_size = fileInfo.Length;

                            User receiver = new User()
                            {
                                userName = lb_remote_name.Text,
                                userID = lb_remote_name.Text,
                            };
                            MessageFileForFriend messageFileForFriend = new MessageFileForFriend()
                            {
                                userSend = your_account_name,
                                userReceive = receiver,
                                filename = file_name,
                                fileSize = file_size,
                            };
                            string data = JsonConvert.SerializeObject(messageFileForFriend);

                            SendMessage sendMessage = new SendMessage();
                            sendMessage.set_filename(messageFileForFriend.filename, messageFileForFriend.filename);
                            receiver_boardChat[messageFileForFriend.userReceive.userID].Controls.Add(sendMessage);

                            writer.WriteLine("File");
                            writer.WriteLine(data);
                            writer.WriteLine(lb_remote_name.Text);

                            byte[] buffer = new byte[52428800];
                            int byteReads;
                            NetworkStream networkStream = tcpClient.GetStream();

                            FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                            while ((byteReads = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                networkStream.Write(buffer, 0, byteReads);
                            }
                        }
                        else
                        {
                            FileInfo fileInfo = new FileInfo(filepath);
                            string file_name = fileInfo.Name;
                            long file_size = fileInfo.Length;

                            User receiver = new User()
                            {
                                userName = lb_remote_name.Text,
                                userID = lb_remote_name.Text,
                            };
                            MessageFileForGroup messageFileForGroup = new MessageFileForGroup()
                            {
                                userSend = your_account_name,
                                receiver_id_list = groups_members[lb_remote_name.Text].members_userid,
                                filename = file_name,
                                fileSize = file_size,
                                groupName = lb_remote_name.Text,
                            };
                            string data = JsonConvert.SerializeObject(messageFileForGroup);

                            SendMessage sendMessage = new SendMessage();
                            sendMessage.set_filename(messageFileForGroup.filename, messageFileForGroup.filename);
                            receiver_boardChat[messageFileForGroup.groupName].Controls.Add(sendMessage);

                            writer.WriteLine("File");
                            writer.WriteLine(data);
                            writer.WriteLine(messageFileForGroup.groupName);

                            byte[] buffer = new byte[52428800];
                            int byteReads;
                            NetworkStream networkStream = tcpClient.GetStream();

                            FileStream fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                            while ((byteReads = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                networkStream.Write(buffer, 0, byteReads);
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void btn_change_name_Click(object sender, EventArgs e)
        {
            Invoke(new Action(() =>
            {
                ChangeName changeName = new ChangeName(your_account_name, writer, bunifuPictureBox1.Image);
                changeName.Show();
            }));
        }

        private void btn_change_avatar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                new_avatar = Image.FromFile(openFileDialog.FileName);
                string avatar_data = ImageToBase64String(new_avatar);

                writer.WriteLine("Set Avatar");
                writer.WriteLine(avatar_data);
            }
        }
        private void tb_enter_message_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_enter_message.Text))
            {
                Invoke(new Action(() =>
                {
                    btn_send.Enabled = false;
                }));
            }
            else
            {
                Invoke(new Action(() =>
                {
                    btn_send.Enabled = true;
                }));
            }
        }
        private void receive2()
        {
            while (isRunning)
            {
                
            }

        }
    }
}
