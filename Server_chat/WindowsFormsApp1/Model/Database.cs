using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
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
    }
}
