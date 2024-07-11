using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Chat
{
    public partial class BoxChat : UserControl
    {
        public BoxChat()
        {
            InitializeComponent();
        }
        public string getName()
        {
            return lb_name.Text; 
        }
        public void setName(string name)
        {
            lb_name.Text = name;
        }
        public string get_user_id()
        {
            return lb_user_id.Text;
        }
        public void set_user_id(string text)
        {
            lb_user_id.Text = text;
        }
    }
}
