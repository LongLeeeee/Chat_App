using App_Chat.Model;
using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Newtonsoft.Json;

namespace App_Chat.View
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private TcpClient tcpClient;
        private TcpClient tcpClient_1;
        private StreamWriter writer;
        private StreamReader reader;
        private StreamWriter writer_1;
        private StreamReader reader_1;
        private void ConnectToServer(ref TcpClient Client,ref  StreamReader r, ref StreamWriter w)
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
        private void Baoloi()
        {
            tb_pwd.Clear();
            tb_username.Clear();
            lb_warning.Visible = true;
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (tcpClient != null)
            {
                tcpClient.Close();
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (tb_username.Text == "" || tb_pwd.Text == "")
            {
                Baoloi();
                return;
            }
            // tạo thread để gửi và nhận thông tin đăng nhập
            Thread threadLogin = new Thread(login);
            threadLogin.Start();
            threadLogin.IsBackground = true;
        }
        private void login()
        {
            ConnectToServer(ref this.tcpClient,ref  reader, ref writer);
            if (!tcpClient.Connected)
            {
                MessageBox.Show("Đăng nhập thất bại! Xin vui lòng đăng nhập lại.");
                return;
            }
            User login_user = new User()
            {
                userID = tb_username.Text,
                pwd = tb_pwd.Text,
            };
            string loginString = JsonConvert.SerializeObject(login_user);
            writer.WriteLine("Login");
            writer.WriteLine(loginString);

            // đọc phản hồi từ server

            string rs_from_server = reader.ReadLine();
            if (rs_from_server.CompareTo("Login successfully") == 0)
            {
                ConnectToServer(ref this.tcpClient_1, ref this.reader_1, ref this.writer_1);
                if (!this.tcpClient_1.Connected)
                {
                    MessageBox.Show("Đăng nhập thất bại! Xin vui lòng đăng nhập lại.");
                    return;
                }
                User thread2_user = login_user;
                string thread2_user_string = JsonConvert.SerializeObject(thread2_user);
                writer_1.WriteLine("Establish");
                writer_1.WriteLine(loginString);

                rs_from_server = reader_1.ReadLine();
                if (rs_from_server.CompareTo("Successfully") == 0)
                {
                    Invoke(new Action(() =>
                    {
                        if (tcpClient.Connected && tcpClient_1.Connected)
                        {
                            Chat chat = new Chat(tcpClient, tcpClient_1, login_user);
                            chat.Show();
                            this.Hide();
                        }
                    }));
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại! Xin vui lòng đăng nhập lại.");
                    return;
                }
            }
            else
            {
                // hiển thị label báo lỗi
                Invoke(new Action(() =>
                {
                    Baoloi();
                }));
            }
        }
        private void btn_register_Click(object sender, EventArgs e)
        {
            Thread DKThread = new Thread(() => Application.Run(new Register()));
            DKThread.ApartmentState = ApartmentState.STA;
            DKThread.Start();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
        }
    }
}
