﻿using System;
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
    public partial class SendMessage : UserControl
    {
        public SendMessage()
        {
            InitializeComponent();
        }
        public void setLabel(string content, string userid)
        {
            lb_send_message.Text = content + " :" + userid ;
        }
    }
}
