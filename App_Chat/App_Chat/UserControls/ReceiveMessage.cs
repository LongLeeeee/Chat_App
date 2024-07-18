using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Chat.UserControls
{
    public partial class ReceiveMessage : UserControl
    {
        public ReceiveMessage()
        {
            InitializeComponent();
        }
        public void setLabel(string content, string userid)
        {
            lb_receive_message.Text = userid + ": " + content;
        }
        public string getLabel()
        {
            return lb_receive_message.Text;
        }
    }
}
