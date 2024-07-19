using App_Chat.Model;
using App_Chat.UserControls;
using Bunifu.UI.WinForms;
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
    public partial class CreateGroup : Form
    {
        public CreateGroup(User creator, StreamWriter writer, StreamReader reader, string[] friend_list)
        {
            InitializeComponent();
            this.writer = writer;
            this.reader = reader;
            this.friend_list = friend_list;
            this.creator = creator;
        }
        private StreamWriter writer;
        private StreamReader reader;
        private string[] friend_list;
        private List<member> selected_users;
        private List<member> list;
        Dictionary<string, BunifuPictureBox> pairs;
        private User creator;
        private member create_member(string user_id)
        {
            member new_member = new member();
            new_member.set_user_id(user_id);
            return new_member;
        }
        private BunifuPictureBox create_picturebox(string userid)
        {
            BunifuPictureBox bunifuPictureBox = new BunifuPictureBox();
            bunifuPictureBox.Size = new Size(70, 70);
            return bunifuPictureBox;
        }
        private void CreateGroup_Load(object sender, EventArgs e)
        {
            if (friend_list != null)
            {
                pairs = new Dictionary<string, BunifuPictureBox>();
                selected_users = new List<member>();
                list = new List<member>();
                foreach (var item in friend_list)
                {
                    if (item != "")
                    {
                        member temp_member = create_member(item);
                        temp_member.Click += add_click;
                        flowLayoutPanel1.Controls.Add(temp_member);
                        list.Add(temp_member);
                    }
                }
            }
        }
        private void add_click(object sender, EventArgs e)
        {
            member clicked_member = (member)sender;
            if (flowLayoutPanel1.Controls.Contains(clicked_member))
            {
                if (clicked_member.set_status().Visible)
                {
                    clicked_member.set_status().Visible = false;
                    selected_users.Remove(clicked_member);
                    clicked_member.BackColor = SystemColors.ControlLightLight;

                    if (pairs.ContainsKey(clicked_member.get_user_id()))
                    {
                        flowLayoutPanel2.Controls.Remove(pairs[clicked_member.get_user_id()]);
                        selected_users.Remove(clicked_member);
                        pairs.Remove(clicked_member.get_user_id());
                    }                    
                }
                else
                {
                    clicked_member.set_status().Visible = true;
                    selected_users.Add(clicked_member);

                    BunifuPictureBox bunifuPictureBox = create_picturebox(clicked_member.get_user_id());
                    pairs.Add(clicked_member.get_user_id(), bunifuPictureBox);
                    flowLayoutPanel2.Controls.Add(bunifuPictureBox);
                }
            }
        }
        private void btn_create_group_Click(object sender, EventArgs e)
        {
            List<string> members = new List<string>();
            for (int i = 0; i < selected_users.Count; i++)
            {
                members.Add(selected_users[i].get_user_id());
            }
            members.Add(this.creator.userID);
            Group new_group = new Group()
            {
                groupName = tb_enter_group_name.Text.Trim(),
                creator = this.creator,
                members_userid = members,
            }; 
            string group_data = JsonConvert.SerializeObject(new_group);
            writer.WriteLine("Create Group");
            writer.WriteLine(group_data);
            this.Close();
        }
    }
}
