using App_Chat.Model;
using Newtonsoft.Json;
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

namespace App_Chat.View
{
    public partial class ChangeName : Form
    {
        public ChangeName(User user, StreamWriter writer, Image image)
        {
            InitializeComponent();
            this.writer = writer;
            this.user = user;
            this.image = image;
        }
        private User user;
        private StreamWriter writer;
        private Image image;
        private void btn_send_name_Click(object sender, EventArgs e)
        {
            user.userName = tb_enter_name.Text;

            string data = JsonConvert.SerializeObject(user);
            writer.WriteLine("Change Username");
            writer.WriteLine(data);

            this.Close();
        }

        private void ChangeName_Load(object sender, EventArgs e)
        {
            lb_name.Text = user.userName;
            bunifuPictureBox1.Image = image;
        }
    }
}
