using App_Chat.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.BunifuGradientPanel.Transitions;

namespace App_Chat.UserControls
{
    public partial class NewFriend : UserControl
    {
        public NewFriend(TcpClient tcpClient, User user)
        {
            InitializeComponent();
            this.tcpClient = tcpClient;
            this.user = user;
            lb_name.Text = user.userName;
            lb_user_id.Text = user.userID;
        }
        private TcpClient tcpClient;
        private User user;
        StreamWriter writer;
        StreamReader reader;
        public void setButton(string text)
        {
            btn_add_friend.Text = text;
        }
        public void setButton2(bool is_visible)
        {
            btn_cancel.Visible = is_visible;
        }
        public void setLabel(string text)
        {
            lb_user_id.Text = text;
        }
        public string get_user_id()
        {
            return lb_user_id.Text;
        }
        private void btn_add_friend_Click(object sender, EventArgs e)
        {
            reader = new StreamReader(tcpClient.GetStream());
            writer = new StreamWriter(tcpClient.GetStream());
            writer.AutoFlush = true;
            //btn_cancel.Visible = true;
            //btn_add_friend.Text = "Đã gửi";
            writer.WriteLine("Add Friend");
            User r = new User()
            {
                userID = lb_user_id.Text,
                userName = lb_name.Text,
            };
            string _sender = JsonConvert.SerializeObject(user);
            string _receiver = JsonConvert.SerializeObject(r);
            writer.WriteLine(_sender);
            writer.WriteLine(_receiver);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            //btn_add_friend.Text = "Kết bạn";
            //btn_cancel.Visible = false;
            reader = new StreamReader(tcpClient.GetStream());
            writer = new StreamWriter(tcpClient.GetStream());
            writer.AutoFlush = true;
            writer.WriteLine("Cancel AddFriend");
            User r = new User()
            {
                userID = lb_user_id.Text,
                userName = lb_name.Text,
            };
            string _sender = JsonConvert.SerializeObject(user);
            string _receiver = JsonConvert.SerializeObject(r);
            writer.WriteLine(_sender);
            writer.WriteLine(_receiver);
        }
    }
}
