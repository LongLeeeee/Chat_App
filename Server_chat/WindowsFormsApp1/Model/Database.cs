using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Model
{
    public class Database
    {
        public SqlConnection sqlConnection {  get; set; }
        public SqlCommand sqlCommand { get; set; }
        private string path = @"Data Source=LONGLEEEE;Initial Catalog=App_Chat;Integrated Security=True;Encrypt=False";
        public SqlDataReader sqlreader { get; set; }

        public void connectToDB()
        {
            sqlConnection = new SqlConnection(this.path);
            sqlConnection.Open();
        }
        public void DisconnectToDB()
        {
            sqlConnection.Close();
        }
        public void Authetication(User user1, ref bool succes)
        {
            string query = $"select * from Users where USERID = '{user1.userID}'";
            sqlCommand = new SqlCommand(query,sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            while (sqlreader.Read())
            {
                User user = new User();

                user.userID = sqlreader["USERID"].ToString();
                user.userName = sqlreader["USERNAME"].ToString();
                user.email = sqlreader["EMAIL"].ToString();
                user.pwd = sqlreader["PWD"].ToString();
                if (user != null && user.pwd == user1.pwd)
                {
                    succes = true;
                }
                else if (user == null && user.pwd != user1.pwd)
                {
                    succes = false;
                }
                if (user != null && user.email == user1.email)
                {
                    succes = true;
                }
            }
        }
        public void saveData(User user)
        {
            string query = $"insert into Users(USERID,USERNAME,EMAIL,PWD) values ('{user.userID}','{user.userName}','{user.email}','{user.pwd}')";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("USERID", user.userID);
            sqlCommand.Parameters.AddWithValue("USERNAME", user.userName);
            sqlCommand.Parameters.AddWithValue("EMAIL", user.email);
            sqlCommand.Parameters.AddWithValue("PWD", user.pwd);
            sqlCommand.ExecuteNonQuery();
        }
        public void save_message(User receiver, User sender, string content)
        {
            string ROOMKEY = "";
            if (receiver.userID.CompareTo(sender.userID) > 0)
            {
                ROOMKEY = sender.userID+"_"+receiver.userID;
            }
            else if (receiver.userID.CompareTo(sender.userID) < 0)
            {
                ROOMKEY = receiver.userID+"_"+sender.userID;
            }
            DateTime dateTime = DateTime.Now;
            string query = $"insert into Messages_Friend(ROOMKEY, USERID_RECEIVE, USERID_SEND, SENDDATE, CONTENT) values ('{ROOMKEY}','{receiver.userID}','{sender.userID}','{dateTime}','{content}')";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("ROOMKEY", ROOMKEY);
            sqlCommand.Parameters.AddWithValue("USERID_RECEIVE", receiver.userID);
            sqlCommand.Parameters.AddWithValue("USERID_SEND", sender.userID);
            sqlCommand.Parameters.AddWithValue("SENDDATE", dateTime);
            sqlCommand.Parameters.AddWithValue("CONTENT", content);
            sqlCommand.ExecuteNonQuery();
        }
        public void get_messages(string userid_login, string another_userid)
        {
            string ROOMKEY = "";
            if (userid_login.CompareTo(another_userid) > 0)
            {
                ROOMKEY = another_userid + "_" + userid_login;
            }
            else if (userid_login.CompareTo(another_userid) < 0)
            {
                ROOMKEY = userid_login + "_" + another_userid;
            }
            string query = $"select * from Messages_Friend where ROOMKEY = '{ROOMKEY}'";

        }
        public void updateData(User user)
        {
            string query = $"update Users set PWD = '{user.pwd}' where USERID = '{user.userID}'";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("PWD", user.pwd);
            sqlCommand.ExecuteNonQuery();
        }
        public string getUSer()
        {
            string temp = "";
            string query = $"select USERID from Users";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            while (sqlreader.Read())
            {
                string temp_userID = sqlreader["USERID"].ToString();
                temp += temp_userID + "|";
            }
            return temp;
        }
        public void get_friends(string userID, ref string[] list)
        {
            string query = $"select USERID_1, USERNAME from Friends, Users where Friends.USERID_2 = Users.USERID and USERID_2 = '{userID}'";
            string query1 = $"select USERID_2, USERNAME from Friends, Users where Friends.USERID_1 = Users.USERID and USERID_1 = '{userID}'";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            int i = 0;
            while (sqlreader.Read())
            {
                string id = sqlreader["USERID_1"].ToString();
                list[i] = id;
                i++;
            }
            sqlConnection.Close();

            connectToDB();
            sqlCommand = new SqlCommand(query1, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            while (sqlreader.Read())
            {
                string id = sqlreader["USERID_2"].ToString();
                list[i] = id;
                i++;
            }
        }
        public void get_notificaiton(string user_id, ref string[] list)
        {
            string query = $"select USERID_RECEIVE, USERID_SEND from Notifications where USERID_RECEIVE = '{user_id}' or USERID_SEND = '{user_id}'";
            sqlCommand = new SqlCommand(query, sqlConnection);  
            sqlreader = sqlCommand.ExecuteReader();
            int i = 0;
            while (sqlreader.Read())
            {
                string id1 = sqlreader["USERID_RECEIVE"].ToString();
                string id2 = sqlreader["USERID_SEND"].ToString();
                if (id1 == user_id)
                {
                    list[i] = id2;
                }
                else if (id2 == user_id)
                {
                    list[i] = id1;
                }
                i++;
            }
        }
        public void add_Notification(User user1, User user2, ref bool success)
        {
            string query = $"select * from Users where USERID = '{user1.userID}'";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            sqlreader.Read();
            User temp_user1 = new User();
            temp_user1.userID = sqlreader["USERID"].ToString();
            temp_user1.userName = sqlreader["USERNAME"].ToString();
            temp_user1.email = sqlreader["EMAIL"].ToString();
            temp_user1.pwd = sqlreader["PWD"].ToString();
            sqlConnection.Close();

            connectToDB();
            query = $"select * from Users where USERID = '{user2.userID}'";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            sqlreader.Read();
            User temp_user2 = new User();
            temp_user2.userID = sqlreader["USERID"].ToString();
            temp_user2.userName = sqlreader["USERNAME"].ToString();
            temp_user2.email = sqlreader["EMAIL"].ToString();
            temp_user2.pwd = sqlreader["PWD"].ToString();
            sqlConnection.Close();
            if (temp_user1 != null && temp_user2 != null)
            {
                connectToDB();
                DateTime dateTime = DateTime.Now;
                string content = $"{user2.userID} đã gửi lời mời kết bạn đến {user1.userID}";
                query = $"insert into Notifications(USERID_RECEIVE, USERID_SEND, CREATIONDATE, CONTENT) values ('{user1.userID}','{user2.userID}','{dateTime}','{content}')";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("USERID_RECEIVE", user1.userID);
                sqlCommand.Parameters.AddWithValue("USERID_SEND", user2.userID);
                sqlCommand.Parameters.AddWithValue("CREATIONDATE", dateTime);
                sqlCommand.Parameters.AddWithValue("CONTENT",content);
                sqlCommand.ExecuteNonQuery();
                success = true;
            }
        }
        public void Del_Notification(User sender, User receiver, ref bool success)
        {
            string query1 = $"delete from Notifications where USERID_RECEIVE = '{sender.userID}' and USERID_SEND = '{receiver.userID}'";
            string query = $"delete from Notifications where USERID_RECEIVE = '{receiver.userID}' and USERID_SEND = '{sender.userID}'";
            bool s = true;
            sqlCommand = new SqlCommand(query1, sqlConnection);
            sqlCommand.Parameters.AddWithValue("USERID_RECEIVE", sender.userID);
            sqlCommand.Parameters.AddWithValue("USERID_SEND", receiver.userID);
            sqlCommand.ExecuteNonQuery();
            s = true;
            if (!s)
            {
                DisconnectToDB();
                connectToDB();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("USERID_SEND", sender.userID);
                sqlCommand.Parameters.AddWithValue("USERID_USERID_RECEIVESEND", receiver.userID);
                sqlCommand.ExecuteNonQuery();
            }
            success = true;
        }
        public void Add_Friend_Table(User sender, User receiver, ref bool success)
        {
            DateTime dateTime = DateTime.Now;
            string query = $"insert into Friends (USERID_1, USERID_2, SENDDATE) values ('{receiver.userID}', '{sender.userID}','{dateTime}')";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("USERID_1", receiver.userID);
            sqlCommand.Parameters.AddWithValue("USERID_2", sender.userID);
            sqlCommand.Parameters.AddWithValue("SENDDATE", dateTime);
            sqlCommand.ExecuteNonQuery();
            success = true;
        }
    }
}
