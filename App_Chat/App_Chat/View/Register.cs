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
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_Chat.View
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        
        string OTP;
        private TcpClient tcpClient;
        private TcpClient tcpClient_1;
        private StreamWriter writer;
        private StreamReader reader;
        private StreamWriter writer_1;
        private StreamReader reader_1;

        private void ConnectToServer(ref TcpClient Client, ref StreamReader r, ref StreamWriter w)
        {
            Client = new TcpClient();
            try
            {
                Client.Connect(IPAddress.Parse("127.0.0.1"), 8080);
            }
            catch
            {
                MessageBox.Show("Máy chủ không hoạt động!");
                return;
            }
            r = new StreamReader(Client.GetStream());
            w = new StreamWriter(Client.GetStream());
            w.AutoFlush = true;
        }
        private void Warning()
        {
            lb_warning1.Visible = true;
            lb_warning2.Visible = true;
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            Thread LGThread = new Thread(() => Application.Run(new Login()));
            LGThread.ApartmentState = ApartmentState.STA;
            LGThread.Start();
            this.Close();
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
            }
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tb_username.Text) || string.IsNullOrEmpty(tb_email.Text) || string.IsNullOrEmpty(tb_pwd.Text) ||
                string.IsNullOrEmpty(tb_repwd.Text) /*|| string.IsNullOrEmpty(tb_otp_code.Text)*/)
            {
                Warning();
                return;
            }
            ConnectToServer(ref this.tcpClient,ref this.reader, ref this.writer);
            User register_user = new User()
            {
                userID = tb_username.Text,
                userName = tb_username.Text,
                creationDate = DateTime.Now,
                email = tb_email.Text,
                pwd = tb_pwd.Text,
            };
            // gửi thông điệp yêu cầu đăng kí và thông tin đắng kí
            string register_string = JsonConvert.SerializeObject(register_user);
            writer.WriteLine("Register");
            writer.WriteLine(register_string);

            //Nhận phản hồi từ server
            string response_from_server = reader.ReadLine();
            if (response_from_server.CompareTo("Register successfully") == 0)
            {
                ConnectToServer(ref this.tcpClient_1,ref this.reader_1,ref this.writer_1);
                if (!this.tcpClient_1.Connected)
                {
                    MessageBox.Show(".Đăng nhập thất bại! Xin vui lòng đăng nhập lại");
                    return;
                }
                User thread2_user = register_user;
                string thread2_user_string = JsonConvert.SerializeObject(thread2_user);
                writer_1.WriteLine("Establish");
                writer_1.WriteLine(register_string);

                response_from_server = reader_1.ReadLine();
                if (response_from_server.CompareTo("Successfully") == 0)
                {
                    Invoke(new Action(() =>
                    {
                        if (tcpClient.Connected && tcpClient_1.Connected)
                        {
                            Chat chat = new Chat(tcpClient, tcpClient_1, register_user);
                            chat.Show();
                            this.Hide();
                        }
                    }));
                }
                else
                {
                    MessageBox.Show(".Đăng nhập thất bại! Xin vui lòng đăng nhập lại");
                    return;
                }
            }
            else
            {
                Invoke(new Action(() =>
                {
                    MessageBox.Show("Đăng ký không thành công");

                }));
            }
        }

        private void btn_sendOTP_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mã OTP sẽ được gửi qua Email của bạn!");
            OTP = GenerateCode();
            new Thread(() => SendEmail(tb_email.Text.Trim(), OTP)).Start();
        }
        public string GenerateCode()
        {
            const string chars = "0123456789";
            var random = new Random();
            var code = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());
            return code;
        }
        private void SendEmail(string toEmail, string code)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("22520813@gm.uit.edu.vn", "Ứng dụng trò chuyện trực tiếp thông qua mạng LAN");
                mail.To.Add(toEmail);
                mail.Subject = "OTP";
                mail.Body = $"Chào mừng bạn đến với ứng dụng của chúng tôi,\n\nMã OTP của bạn là: {code}";
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

        private void tb_email_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tb_pwd_TextChanged(object sender, EventArgs e)
        {
            lb_warning1.Visible = true;
            string password = tb_pwd.Text;

            if (password.Length < 8)
            {
                lb_warning1.Text = ".Mật khẩu cần ít nhất 8 ký tự";
                return;
            }
            else if (!password.Any(char.IsUpper))
            {
                lb_warning1.Text = ".Mật khẩu cần ít nhất một ký tự hoa";
                return;
            }
            else if (!password.Any(char.IsLower))
            {
                lb_warning1.Text = ".Mật khẩu cần ít nhất một ký tự thường";
                return;
            }
            else if (!password.Any(char.IsDigit))
            {
                lb_warning1.Text = ".Mật khẩu cần ít nhất một số";
                return;
            }
            else
            {
                // Nếu mật khẩu đáp ứng tất cả các điều kiện, xóa thông báo lỗi
                lb_warning1.Text = "";
            }
        }
    }
}
