using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

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

        public void get_data_user1(ref List<User> users)
        {
            connectToDB();
            string query = $"select * from Users";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            while (sqlreader.Read())
            {
                User temp = new User();
                temp.userID = sqlreader["USERID"].ToString();
                temp.userName = sqlreader["USERNAME"].ToString();
                temp.email = sqlreader["EMAIL"].ToString();
                temp.pwd = sqlreader["PWD"].ToString();

                users.Add(temp);
            }
            sqlConnection.Close();
        }
        public void get_notificaiton1(ref List<Notification> list)
        {
            connectToDB();
            string query = $"select * from Notifications";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            while (sqlreader.Read())
            {
                Notification temp = new Notification();
                temp.sender = new User();
                temp.receiver = new User(); 
                temp.sender.userID = sqlreader["USERID_SEND"].ToString();
                temp.receiver.userID = sqlreader["USERID_RECEIVE"].ToString();
                temp.content = sqlreader["CONTENT"].ToString();
                string date = sqlreader["CREATIONDATE"].ToString();
                temp.sendDate = DateTime.Parse(date);

                list.Add(temp);
            }
            sqlConnection.Close();
        }
        public void get_infor_group1(ref List<Group> groupname_members)
        {
            connectToDB();
            List<string> group_names = new List<string>();
            string query = $"select GROUPNAME from List_Group";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            while (sqlreader.Read())
            {
                string temp = sqlreader["GROUPNAME"].ToString();
                group_names.Add(temp);
            }
            sqlConnection.Close();
            foreach (var item in group_names)
            {
                connectToDB();
                List<string> temp1 = new List<string>();
                query = $"select * from List_Group, List_User_A_Group where List_Group.GROUPNAME = List_User_A_Group.GROUPNAME and List_Group.GROUPNAME = '{item}'";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlreader = sqlCommand.ExecuteReader();
                Group group = new Group();
                while (sqlreader.Read())
                {
                    group = new Group();
                    group.creator = new User();
                    group.groupName = sqlreader["GROUPNAME"].ToString();
                    group.creator.userID = sqlreader["USERID_CREATION"].ToString();
                    group.creationDate = DateTime.Parse(sqlreader["CREATIONDATE"].ToString());
                    string temp = sqlreader["USERID"].ToString();
                    temp1.Add(temp);
                }
                group.members_userid = temp1;
                groupname_members.Add(group);
                sqlConnection.Close();
            }
        }
        public void get_data_user(ref User user)
        {
            connectToDB();
            string query = $"select * from Users where USERID = '{user.userID}'";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            while (sqlreader.Read())
            {
                user.userName = sqlreader["USERNAME"].ToString();
                user.email = sqlreader["EMAIL"].ToString();
            }
            sqlConnection.Close();
        }
        public void get_avatar(User user, ref string data)
        {
            connectToDB();
            string query = $"select avatar from Avatar where USERID = '{user.userID}'";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            while (sqlreader.Read())
            {
                data = sqlreader["avatar"].ToString().Trim();
            }
            sqlConnection.Close();
        }
        public void set_avatar(string userid, string data)
        {
            connectToDB();
            string query = $"insert into Avatar(USERID, avatar) values ('{userid}','{data}')";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("USERID", userid);
            sqlCommand.Parameters.AddWithValue("avata", data);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
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
        public void del_friend(string user1, string user2)
        {
            connectToDB();
            string query = $"select USERID_1, USERID_2 from Friends where USERID_1 = '{user1}' and USERID_2 = '{user2}'";
            string query1 = $"select USERID_1, USERID_2 from Friends where USERID_1 = '{user2}' and USERID_2 = '{user1}'";
            string query2 = $"delete from Friends where USERID_1 = '{user1}' and USERID_2 = '{user2}'";
            string query3 = $"delete from Friends where USERID_1 = '{user2}' and USERID_2 = '{user1}'";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            if (sqlreader.Read())
            {
                sqlConnection.Close();
                connectToDB();
                sqlCommand = new SqlCommand(query2, sqlConnection);
                sqlCommand.Parameters.AddWithValue("USERID_1", user1);
                sqlCommand.Parameters.AddWithValue("USERID_2", user2);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            else
            {
                sqlConnection.Close();
                connectToDB();
                sqlCommand = new SqlCommand(query1, sqlConnection);
                sqlreader = sqlCommand.ExecuteReader();
                if (sqlreader.Read())
                {
                    sqlConnection.Close();
                    connectToDB();
                    sqlCommand = new SqlCommand(query3, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("USERID_1", user2);
                    sqlCommand.Parameters.AddWithValue("USERID_2", user1);
                    sqlCommand.ExecuteNonQuery();
                }
                sqlConnection.Close();
            }
        }
        public void del_conversation(string roomkey, ref bool issuccess)
        {
            connectToDB();
            string query = $"delete from Messages_Friend where ROOMKEY = '{roomkey}'";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("ROOMKEY", roomkey);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            issuccess = true;
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
        public void save_message_group(MessageGroup messageGroup)
        {
            string query = $"insert into Messages_Group (GROUPNAME, CONTENT, SENDDATE, USERID_SEND) values ('{messageGroup.groupName}','{messageGroup.content}','{messageGroup.dateSend}','{messageGroup.userSend.userID}')";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("GROUPNAME", messageGroup.groupName);
            sqlCommand.Parameters.AddWithValue("CONTENT", messageGroup.content);
            sqlCommand.Parameters.AddWithValue("SENDDATE", messageGroup.dateSend);
            sqlCommand.Parameters.AddWithValue("USERID_SEND", messageGroup.userSend.userID);
            sqlCommand.ExecuteNonQuery();
        }
        public void get_messages(string userid_login, string another_userid, ref string data)
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
            string query = $"select USERID_RECEIVE, USERID_SEND, CONTENT from Messages_Friend where ROOMKEY = '{ROOMKEY}'";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            while (sqlreader.Read())
            {
                string temp = sqlreader["CONTENT"].ToString();
                string user = sqlreader["USERID_SEND"].ToString();
                string temp1 = "";
                if (user == userid_login)
                {
                    temp1 = temp + " :" + user;
                }
                else
                {
                    temp1 = user + ": " + temp;
                }
                if (string.IsNullOrEmpty(temp1))
                {
                    return;
                }
                data += temp1 + "|";
            }
        }
        public void get_messages_group(ref string data, string group_name, string sender)
        {
            string query = $"select USERID_SEND, CONTENT from Messages_Group where GROUPNAME = '{group_name}'";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            if (!sqlreader.Read())
            {
                return;
            }
            else
            {
                while (sqlreader.Read())
                {
                    string temp = sqlreader["CONTENT"].ToString();
                    string user = sqlreader["USERID_SEND"].ToString();
                    string temp1 = "";
                    if (user == sender)
                    {
                        temp1 = temp + " :" + user;
                    }
                    else
                    {
                        temp1 = user + ": " + temp;
                    }
                    if (string.IsNullOrEmpty(temp1))
                    {
                        return;
                    }
                    data += temp1 + "|";
                }
            }
        }
        public void updateData(User user)
        {
            string query = $"update Users set PWD = '{user.pwd}' where USERID = '{user.userID}'";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("PWD", user.pwd);
            sqlCommand.ExecuteNonQuery();
        }
        public void update_Username(User user)
        {
            string query = $"update Users set USERNAME = '{user.userName}' where USERID = '{user.userID}'";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.Parameters.AddWithValue("USERNAME", user.userName);
            sqlCommand.ExecuteNonQuery();
        }
        public List<string> getUSer()
        {
            List<string> data = new List<string>();
            string query = $"select USERID from Users";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            while (sqlreader.Read())
            {
                string temp_userID = sqlreader["USERID"].ToString();
                data.Add(temp_userID);
            }
            return data;
        }
        public void get_infor_group(string userid, ref List<Group> groupname_members)
        {
            connectToDB();
            List<string> group_names = new List<string>();
            string query = $"select GROUPNAME from List_User_A_Group where USERID = '{userid}' ";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            while (sqlreader.Read())
            {
                string temp = sqlreader["GROUPNAME"].ToString();
                group_names.Add(temp);
            }
            sqlConnection.Close();

            foreach (var item in group_names)
            {
                connectToDB();
                List<string>temp1= new List<string>();
                query = $"select * from List_Group, List_User_A_Group where List_Group.GROUPNAME = List_User_A_Group.GROUPNAME and List_Group.GROUPNAME = '{item}'";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlreader = sqlCommand.ExecuteReader();
                Group group = new Group();
                while (sqlreader.Read())
                {
                    group = new Group();
                    group.groupName = sqlreader["GROUPNAME"].ToString();
                    string temp = sqlreader["USERID"].ToString();
                    temp1.Add(temp);
                }
                group.members_userid = temp1;
                groupname_members.Add(group);
                sqlConnection.Close();
            }
        }
        public void get_friends(string userID, ref List<string> list)
        {
            string query = $"select USERID_1, USERNAME from Friends, Users where Friends.USERID_2 = Users.USERID and USERID_2 = '{userID}'";
            string query1 = $"select USERID_2, USERNAME from Friends, Users where Friends.USERID_1 = Users.USERID and USERID_1 = '{userID}'";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            while (sqlreader.Read())
            {
                string id = sqlreader["USERID_1"].ToString();
                list.Add(id);
            }
            sqlConnection.Close();

            connectToDB();
            sqlCommand = new SqlCommand(query1, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            while (sqlreader.Read())
            {
                string id = sqlreader["USERID_2"].ToString();
                list.Add(id);    
            }
        }
        public void get_notificaiton(string user_id, ref List<string> list)
        {
            string query = $"select USERID_RECEIVE, USERID_SEND from Notifications where USERID_RECEIVE = '{user_id}' or USERID_SEND = '{user_id}'";
            sqlCommand = new SqlCommand(query, sqlConnection);  
            sqlreader = sqlCommand.ExecuteReader();
            while (sqlreader.Read())
            {
                string id1 = sqlreader["USERID_RECEIVE"].ToString();
                string id2 = sqlreader["USERID_SEND"].ToString();
                if (id1 == user_id)
                {
                    list.Add(id2);
                }
                else if (id2 == user_id)
                {
                    list.Add(id1);
                }
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
                string content = "Add Friend";
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
        public void Add_Group_Table(ref bool is_exist, ref bool is_success, Group new_group)
        {
            DateTime dateTime = DateTime.Now;
            string query = $"select GROUPNAME from List_Group where GROUPNAME = '{new_group.groupName}'";
            sqlCommand = new SqlCommand(query, sqlConnection);
            sqlreader = sqlCommand.ExecuteReader();
            Group temp = new Group();
            while (sqlreader.Read())
            {
                temp.groupName = sqlreader["GROUPNAME"].ToString();
            }
            sqlConnection.Close();

            if (!string.IsNullOrEmpty(temp.groupName))
            {
                is_exist = true;
            }
            else
            {
                connectToDB();
                query = $"insert into List_Group (GROUPNAME,USERID_CREATION,CREATIONDATE) values ('{new_group.groupName}','{new_group.creator.userID}', '{dateTime}')";
                sqlCommand = new SqlCommand (query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("GROUPNAME", new_group.groupName);
                sqlCommand.Parameters.AddWithValue("USERID_CREATION", new_group.creator.userID);
                sqlCommand.Parameters.AddWithValue("CREATIONDATE", dateTime);
                sqlCommand.ExecuteNonQuery();
                is_success = true;
                sqlConnection.Close();

                Thread thread = new Thread(() => Add_List_User_A_Group_Table(new_group));
                thread.Start();
                thread.IsBackground = true;
            }
        }
        private void Add_List_User_A_Group_Table(Group new_group)
        {
            foreach (var item in new_group.members_userid)
            {
                connectToDB();
                string query = $"insert into List_User_A_Group (GROUPNAME,USERID) values ('{new_group.groupName}','{item}')";
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("GROUPNAME", new_group.groupName);
                sqlCommand.Parameters.AddWithValue("USERID", item);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
    }
}
