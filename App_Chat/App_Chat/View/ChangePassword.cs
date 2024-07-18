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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace App_Chat.View
{
    public partial class ChangePassword : Form
    {
        public ChangePassword(TcpClient client, User user)
        {
            InitializeComponent();
            this.client = client;
            this.user = user;
            reader = new StreamReader(this.client.GetStream());
            writer = new StreamWriter(this.client.GetStream());
            writer.AutoFlush = true;
        }
        StreamReader reader;
        StreamWriter writer;
        private TcpClient client;
        private User user;

        private async void btn_confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_old_pwd.Text))
            {
                lb_warning.Text = "Vui lòng nhập mật khẩu";
                lb_warning.Visible = true;
                return;
            }
            try
            {
                await CheckPasswordAsync("Change Pwd", tb_old_pwd.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        private async Task CheckPasswordAsync(string rq, string pwd)
        {

            try
            {
                await Task.Run(() =>
                {
                    writer.WriteLine(rq);
                    user.pwd = pwd;
                    string data = JsonConvert.SerializeObject(user);
                    writer.WriteLine(data);
                });

                string response = await Task.Run(() => reader.ReadLine());
                if (!string.IsNullOrEmpty(response))
                {
                    if (response == "Successfully")
                    {
                        panel2.Visible = true;
                        label1.Enabled = false;
                        btn_confirm.Enabled = false;
                        tb_old_pwd.Enabled = false;
                        lb_warning.Visible = false;
                    }
                    else if (response == "Successfully_Close")
                    {
                        this.Close();
                    }
                    else
                    {
                        lb_warning.Text = "Mật khẩu không chính xác! Vui lòng thử lại";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while checking password: {ex.Message}");
            }
        }
        private async void btn_change_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_new_pwd.Text.Trim()) || string.IsNullOrEmpty(tb_re_new_pwd.Text.Trim()))
            {
                lb_warning_2.Text = "!Vui lònhg nhập đầy đủ thông tin";
                lb_warning_2.Visible = true;
            }
            else
            {
                if (tb_new_pwd.Text.Trim() == tb_re_new_pwd.Text.Trim())
                {
                    await CheckPasswordAsync("Update Pwd", tb_new_pwd.Text.Trim());
                }
                else
                {
                    lb_warning_2.Text = "Mật khẩu mới và xác nhận không khớp";
                    lb_warning_2.Visible = true;
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
            this.Hide();
        }

        private void tb_new_pwd_TextChanged(object sender, EventArgs e)
        {
            string password = tb_new_pwd.Text;

            if (password.Length < 8)
            {
                lb_warning_2.Text = ".Mật khẩu cần ít nhất 8 ký tự";
                lb_warning_2.Visible = true;
                return;
            }
            else if (!password.Any(char.IsUpper))
            {
                lb_warning_2.Text = ".Mật khẩu cần ít nhất một ký tự hoa";
                lb_warning_2.Visible = true;
                return;
            }
            else if (!password.Any(char.IsLower))
            {
                lb_warning_2.Text = ".Mật khẩu cần ít nhất một ký tự thường";
                lb_warning_2.Visible = true;
                return;
            }
            else if (!password.Any(char.IsDigit))
            {
                lb_warning_2.Text = ".Mật khẩu cần ít nhất một số";
                lb_warning_2.Visible = true;
                return;
            }
            else
            {
                // Nếu mật khẩu đáp ứng tất cả các điều kiện, xóa thông báo lỗi
                lb_warning_2.Text = "";
            }
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
        }
    }
}
