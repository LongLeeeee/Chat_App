using Bunifu.UI.WinForms.BunifuButton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Chat.UserControls
{
    public partial class member : UserControl
    {
        public member()
        {
            InitializeComponent();
        }
        private void member_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = SystemColors.Control;
        }
        private void member_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor= SystemColors.ControlLightLight; 
        }
        public void set_user_id(string userid)
        {
            lb_user_id.Text = userid;
        }
        public string get_user_id()
        {
            return lb_user_id.Text;
        }
        public BunifuButton set_status()
        {
            return bunifuButton1;
        }
    }
}
