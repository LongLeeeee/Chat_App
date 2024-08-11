namespace WindowsFormsApp1
{
    partial class server
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(server));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_start = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.display = new System.Windows.Forms.TabControl();
            this.users = new System.Windows.Forms.TabPage();
            this.user_list = new System.Windows.Forms.DataGridView();
            this.User_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewImageColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noti = new System.Windows.Forms.TabPage();
            this.noti_list = new System.Windows.Forms.DataGridView();
            this.Sender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reciever = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Send_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groups = new System.Windows.Forms.TabPage();
            this.group_list = new System.Windows.Forms.ListView();
            this.group_list_display = new System.Windows.Forms.DataGridView();
            this.Group_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_ID_Created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Creation_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Members = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.display.SuspendLayout();
            this.users.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.user_list)).BeginInit();
            this.noti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.noti_list)).BeginInit();
            this.groups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.group_list_display)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(943, 96);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(332, 738);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // btn_start
            // 
            this.btn_start.AllowAnimations = true;
            this.btn_start.AllowMouseEffects = true;
            this.btn_start.AllowToggling = false;
            this.btn_start.AnimationSpeed = 200;
            this.btn_start.AutoGenerateColors = false;
            this.btn_start.AutoRoundBorders = false;
            this.btn_start.AutoSizeLeftIcon = true;
            this.btn_start.AutoSizeRightIcon = true;
            this.btn_start.BackColor = System.Drawing.Color.Transparent;
            this.btn_start.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btn_start.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_start.BackgroundImage")));
            this.btn_start.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_start.ButtonText = "Bắt đầu";
            this.btn_start.ButtonTextMarginLeft = 0;
            this.btn_start.ColorContrastOnClick = 45;
            this.btn_start.ColorContrastOnHover = 45;
            this.btn_start.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btn_start.CustomizableEdges = borderEdges1;
            this.btn_start.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_start.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_start.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_start.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_start.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btn_start.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_start.ForeColor = System.Drawing.Color.White;
            this.btn_start.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_start.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btn_start.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btn_start.IconMarginLeft = 11;
            this.btn_start.IconPadding = 10;
            this.btn_start.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_start.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btn_start.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btn_start.IconSize = 25;
            this.btn_start.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_start.IdleBorderRadius = 15;
            this.btn_start.IdleBorderThickness = 1;
            this.btn_start.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btn_start.IdleIconLeftImage = null;
            this.btn_start.IdleIconRightImage = null;
            this.btn_start.IndicateFocus = false;
            this.btn_start.Location = new System.Drawing.Point(943, 12);
            this.btn_start.Name = "btn_start";
            this.btn_start.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_start.OnDisabledState.BorderRadius = 15;
            this.btn_start.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_start.OnDisabledState.BorderThickness = 1;
            this.btn_start.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_start.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_start.OnDisabledState.IconLeftImage = null;
            this.btn_start.OnDisabledState.IconRightImage = null;
            this.btn_start.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_start.onHoverState.BorderRadius = 15;
            this.btn_start.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_start.onHoverState.BorderThickness = 1;
            this.btn_start.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_start.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btn_start.onHoverState.IconLeftImage = null;
            this.btn_start.onHoverState.IconRightImage = null;
            this.btn_start.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_start.OnIdleState.BorderRadius = 15;
            this.btn_start.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_start.OnIdleState.BorderThickness = 1;
            this.btn_start.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btn_start.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btn_start.OnIdleState.IconLeftImage = null;
            this.btn_start.OnIdleState.IconRightImage = null;
            this.btn_start.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_start.OnPressedState.BorderRadius = 15;
            this.btn_start.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_start.OnPressedState.BorderThickness = 1;
            this.btn_start.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_start.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btn_start.OnPressedState.IconLeftImage = null;
            this.btn_start.OnPressedState.IconRightImage = null;
            this.btn_start.Size = new System.Drawing.Size(332, 61);
            this.btn_start.TabIndex = 1;
            this.btn_start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_start.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_start.TextMarginLeft = 0;
            this.btn_start.TextPadding = new System.Windows.Forms.Padding(0);
            this.btn_start.UseDefaultRadiusAndThickness = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // display
            // 
            this.display.Controls.Add(this.users);
            this.display.Controls.Add(this.noti);
            this.display.Controls.Add(this.groups);
            this.display.Location = new System.Drawing.Point(12, 74);
            this.display.Name = "display";
            this.display.SelectedIndex = 0;
            this.display.Size = new System.Drawing.Size(907, 760);
            this.display.TabIndex = 3;
            // 
            // users
            // 
            this.users.Controls.Add(this.user_list);
            this.users.Location = new System.Drawing.Point(4, 22);
            this.users.Name = "users";
            this.users.Padding = new System.Windows.Forms.Padding(3);
            this.users.Size = new System.Drawing.Size(899, 734);
            this.users.TabIndex = 0;
            this.users.Text = "Users";
            this.users.UseVisualStyleBackColor = true;
            // 
            // user_list
            // 
            this.user_list.AllowUserToAddRows = false;
            this.user_list.AllowUserToDeleteRows = false;
            this.user_list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.user_list.BackgroundColor = System.Drawing.Color.White;
            this.user_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.user_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User_ID,
            this.Name,
            this.Status,
            this.Email,
            this.Password});
            this.user_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.user_list.GridColor = System.Drawing.Color.Gainsboro;
            this.user_list.Location = new System.Drawing.Point(3, 3);
            this.user_list.Name = "user_list";
            this.user_list.Size = new System.Drawing.Size(893, 728);
            this.user_list.TabIndex = 1;
            // 
            // User_ID
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.User_ID.DefaultCellStyle = dataGridViewCellStyle1;
            this.User_ID.FillWeight = 70F;
            this.User_ID.HeaderText = "User_ID";
            this.User_ID.Name = "User_ID";
            // 
            // Name
            // 
            this.Name.FillWeight = 70F;
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            // 
            // Status
            // 
            this.Status.FillWeight = 50F;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Email
            // 
            this.Email.FillWeight = 200F;
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Password
            // 
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.Password.DefaultCellStyle = dataGridViewCellStyle2;
            this.Password.FillWeight = 200F;
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            // 
            // noti
            // 
            this.noti.Controls.Add(this.noti_list);
            this.noti.Location = new System.Drawing.Point(4, 22);
            this.noti.Name = "noti";
            this.noti.Padding = new System.Windows.Forms.Padding(3);
            this.noti.Size = new System.Drawing.Size(899, 734);
            this.noti.TabIndex = 1;
            this.noti.Text = "Notifications";
            this.noti.UseVisualStyleBackColor = true;
            // 
            // noti_list
            // 
            this.noti_list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.noti_list.BackgroundColor = System.Drawing.Color.White;
            this.noti_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.noti_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sender,
            this.Reciever,
            this.Send_Date,
            this.Content});
            this.noti_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noti_list.GridColor = System.Drawing.Color.WhiteSmoke;
            this.noti_list.Location = new System.Drawing.Point(3, 3);
            this.noti_list.Name = "noti_list";
            this.noti_list.ReadOnly = true;
            this.noti_list.Size = new System.Drawing.Size(893, 728);
            this.noti_list.TabIndex = 0;
            // 
            // Sender
            // 
            this.Sender.HeaderText = "Sender";
            this.Sender.Name = "Sender";
            this.Sender.ReadOnly = true;
            // 
            // Reciever
            // 
            this.Reciever.HeaderText = "Reciever";
            this.Reciever.Name = "Reciever";
            this.Reciever.ReadOnly = true;
            // 
            // Send_Date
            // 
            this.Send_Date.HeaderText = "Send_Date";
            this.Send_Date.Name = "Send_Date";
            this.Send_Date.ReadOnly = true;
            // 
            // Content
            // 
            this.Content.HeaderText = "Content";
            this.Content.Name = "Content";
            this.Content.ReadOnly = true;
            // 
            // groups
            // 
            this.groups.Controls.Add(this.group_list_display);
            this.groups.Controls.Add(this.group_list);
            this.groups.Location = new System.Drawing.Point(4, 22);
            this.groups.Name = "groups";
            this.groups.Padding = new System.Windows.Forms.Padding(3);
            this.groups.Size = new System.Drawing.Size(899, 734);
            this.groups.TabIndex = 2;
            this.groups.Text = "Groups";
            this.groups.UseVisualStyleBackColor = true;
            // 
            // group_list
            // 
            this.group_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_list.HideSelection = false;
            this.group_list.Location = new System.Drawing.Point(3, 3);
            this.group_list.Name = "group_list";
            this.group_list.Size = new System.Drawing.Size(893, 728);
            this.group_list.TabIndex = 0;
            this.group_list.UseCompatibleStateImageBehavior = false;
            // 
            // group_list_display
            // 
            this.group_list_display.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.group_list_display.BackgroundColor = System.Drawing.Color.White;
            this.group_list_display.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.group_list_display.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Group_Name,
            this.User_ID_Created,
            this.Creation_Date,
            this.Members});
            this.group_list_display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.group_list_display.GridColor = System.Drawing.Color.WhiteSmoke;
            this.group_list_display.Location = new System.Drawing.Point(3, 3);
            this.group_list_display.Name = "group_list_display";
            this.group_list_display.Size = new System.Drawing.Size(893, 728);
            this.group_list_display.TabIndex = 1;
            // 
            // Group_Name
            // 
            this.Group_Name.HeaderText = "Group_Name";
            this.Group_Name.Name = "Group_Name";
            this.Group_Name.ReadOnly = true;
            // 
            // User_ID_Created
            // 
            this.User_ID_Created.HeaderText = "User_ID_Created";
            this.User_ID_Created.Name = "User_ID_Created";
            this.User_ID_Created.ReadOnly = true;
            // 
            // Creation_Date
            // 
            this.Creation_Date.HeaderText = "Creation_Date";
            this.Creation_Date.Name = "Creation_Date";
            this.Creation_Date.ReadOnly = true;
            // 
            // Members
            // 
            this.Members.HeaderText = "Members";
            this.Members.Name = "Members";
            this.Members.ReadOnly = true;
            // 
            // server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 846);
            this.Controls.Add(this.display);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.richTextBox1);
            this.Text = "server";
            this.Load += new System.EventHandler(this.server_Load);
            this.display.ResumeLayout(false);
            this.users.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.user_list)).EndInit();
            this.noti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.noti_list)).EndInit();
            this.groups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.group_list_display)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btn_start;
        private System.Windows.Forms.TabControl display;
        private System.Windows.Forms.TabPage users;
        private System.Windows.Forms.TabPage noti;
        private System.Windows.Forms.TabPage groups;
        private System.Windows.Forms.ListView group_list;
        private System.Windows.Forms.DataGridView user_list;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewImageColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridView noti_list;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reciever;
        private System.Windows.Forms.DataGridViewTextBoxColumn Send_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
        private System.Windows.Forms.DataGridView group_list_display;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_ID_Created;
        private System.Windows.Forms.DataGridViewTextBoxColumn Creation_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Members;
    }
}