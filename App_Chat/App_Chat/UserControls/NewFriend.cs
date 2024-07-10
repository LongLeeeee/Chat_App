using App_Chat.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public void setButton(string text)
        {
            btn_add_friend.Text = text;
        }
        public string get_user_id()
        {
            return lb_user_id.Text;
        }
        private void btn_add_friend_Click(object sender, EventArgs e)
        {
            btn_cancel.Visible = true;
            btn_add_friend.Text = "Đã gửi";
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            btn_add_friend.Text = "Kết bạn";
            btn_cancel.Visible = false;
        }
    }
}
