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
    public partial class SendImage : UserControl
    {
        public SendImage()
        {
            InitializeComponent();
        }
        public void set_picturebox(Image image)
        {
            pictureBox1.Image = image;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        public void set_label_name(string name)
        {
            lb_send_message.Text = name;
        }
        public Image get_picturebox()
        {
            return pictureBox1.Image;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(saveFileDialog.FileName);
                MessageBox.Show("Ảnh đã được tải xuống thành công!");
            }
        }
    }
}
