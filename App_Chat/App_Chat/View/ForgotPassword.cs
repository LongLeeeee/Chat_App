using App_Chat.Model;
using Bunifu.UI.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace App_Chat.View
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();

        }
        private TcpClient tcpClient;
        private StreamReader reader;
        private StreamWriter writer;
        private string resetCode;
        private void ConnectToServer()
        {
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 8080);
            }
            catch
            {
                MessageBox.Show("Máy chủ không hoạt động!");
                return;
            }
            reader = new StreamReader(tcpClient.GetStream());
            writer = new StreamWriter(tcpClient.GetStream());
            writer.AutoFlush = true;
        }
        private void btn_send_OTP_Click(object sender, EventArgs e)
        {
            ConnectToServer();
            if (string.IsNullOrEmpty(tb_email.Text) || string.IsNullOrEmpty(tb_username.Text))
            {
                MessageBox.Show("Vui lòng điền email và username");
                return;
            }
            User user = new User()
            {
                userID = tb_username.Text,
                email = tb_email.Text,
            };
            string change_pass_string = JsonConvert.SerializeObject(user);
            writer.WriteLine("ForgotPassword");
            writer.WriteLine(change_pass_string);

            string rs_from_server = reader.ReadLine();
            if (rs_from_server.CompareTo("Accepted") == 0)
            {
                tb_email.ReadOnly = true;
                tb_username.ReadOnly = true;
                btn_send_OTP.Enabled = false;
                btn_change_pwd.Visible = true;
                tb_new_pwd.Visible = true;
                tb_re_new_pwd.Visible = true;
                tb_OTP.Visible = true;
                this.resetCode = GenerateCode();
                SendEmail(user.email, this.resetCode);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập chính xác email và uesrname");
            }
        }
        public string GenerateCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var code = new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
            return code;
        }
        private void SendEmail(string mailTo, string code)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("22520813@gm.uit.edu.vn", "Ứng dụng trò chuyện trực tuyến thông qua mạng LAN");
                mail.To.Add(mailTo);
                mail.Subject = "OTP";
                mail.Body = $"Xin chào,\n\nMã đặt lại mật khẩu của bạn là: {code}";
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new NetworkCredential("22520813@gm.uit.edu.vn", "1419743210");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

            }
            catch (Exception ex)
            {

                MessageBox.Show($"Gửi Email thất bại: {ex.Message}\r\n");
            }
        }
        private void ResetPwd()
        {
            User reset_pwd_User = new User()
            {
                email = tb_email.Text,
                pwd = tb_new_pwd.Text,
                userID = tb_username.Text,
            };
            string reset_pwd_data = JsonConvert.SerializeObject(reset_pwd_User);
            writer.WriteLine("Reset Pwd");
            writer.WriteLine(reset_pwd_data);

            string rs_from_server = reader.ReadLine();
            if (rs_from_server == "Reset successfully")
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show("Bạn đã đặt lại mật khẩu thành công!");
                    this.Hide();
                }));
            }
            else
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show("Bạn đã đặt lại mật khẩu thất bại!");
                    this.Hide();
                    return;
                }));
            }
        }
        private void tb_new_pwd_TextChanged(object sender, EventArgs e)
        {
            string password = tb_new_pwd.Text;

            if (password.Length < 8)
            {
                lb_warning.Text = "Mật khẩu cần ít nhất 8 ký tự.";
                lb_warning.Visible = true;
                return;
            }
            else if (!password.Any(char.IsUpper))
            {
                lb_warning.Text = "Mật khẩu cần ít nhất một ký tự hoa.";
                lb_warning.Visible = true;
                return;
            }
            else if (!password.Any(char.IsLower))
            {
                lb_warning.Text = "Mật khẩu cần ít nhất một ký tự thường.";
                lb_warning.Visible = true;
                return;
            }
            else if (!password.Any(char.IsDigit))
            {
                lb_warning.Text = "Mật khẩu cần ít nhất một số.";
                lb_warning.Visible = true;
                return;
            }
            else
            {
                // Nếu mật khẩu đáp ứng tất cả các điều kiện, xóa thông báo lỗi
                lb_warning.Text = "";
                lb_warning.Visible = true;
            }
        }

        private void btn_change_pwd_Click(object sender, EventArgs e)
        {
            ConnectToServer();
            if (string.IsNullOrEmpty(tb_OTP.Text))
            {
                lb_warning.Text = "Vui lòng điền mã!";
                lb_warning.Visible = true;
                return;
            }
            if (this.resetCode != tb_OTP.Text)
            {
                lb_warning.Visible = true;
                lb_warning.Text = "Mã đặt lại mật khẩu của bạn không chính xác";
                tb_OTP.Clear();
                return;
            }
            if (string.IsNullOrEmpty(tb_new_pwd.Text))
            {
                lb_warning.Text = "Vui lòng điền mật khẩu mới";
                lb_warning.Visible = true;
                return;
            }
            if (tb_new_pwd.Text.Trim().CompareTo(tb_re_new_pwd.Text.Trim()) == 0 && this.resetCode == tb_OTP.Text.Trim())
            {
                ResetPwd();
            }
            else
            {
                lb_warning.Visible = true;
                lb_warning.Text = "Mật khẩu xác nhận không chính xác!";
                return;
            }
        }
    }
}
