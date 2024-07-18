namespace App_Chat.View
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_warning = new System.Windows.Forms.Label();
            this.tb_pwd = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btn_login = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.tb_username = new Bunifu.UI.WinForms.BunifuTextBox();
            this.lb_pwd = new System.Windows.Forms.Label();
            this.lb_userID = new System.Windows.Forms.Label();
            this.lb_title_login = new System.Windows.Forms.Label();
            this.lb_title_re3 = new System.Windows.Forms.Label();
            this.lb_title_re2 = new System.Windows.Forms.Label();
            this.lb_title_re1 = new System.Windows.Forms.Label();
            this.btn_register = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuGradientPanel1 = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.bunifuGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lb_warning);
            this.panel2.Controls.Add(this.tb_pwd);
            this.panel2.Controls.Add(this.btn_login);
            this.panel2.Controls.Add(this.tb_username);
            this.panel2.Controls.Add(this.lb_pwd);
            this.panel2.Controls.Add(this.lb_userID);
            this.panel2.Controls.Add(this.lb_title_login);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(292, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(583, 508);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(250, 415);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "? Quên mật khẩu";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // lb_warning
            // 
            this.lb_warning.AutoSize = true;
            this.lb_warning.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_warning.ForeColor = System.Drawing.Color.Red;
            this.lb_warning.Location = new System.Drawing.Point(106, 321);
            this.lb_warning.Name = "lb_warning";
            this.lb_warning.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lb_warning.Size = new System.Drawing.Size(195, 17);
            this.lb_warning.TabIndex = 8;
            this.lb_warning.Text = "Nhập sai email hoặc mật khẩu";
            this.lb_warning.Visible = false;
            // 
            // tb_pwd
            // 
            this.tb_pwd.AcceptsReturn = false;
            this.tb_pwd.AcceptsTab = false;
            this.tb_pwd.AnimationSpeed = 200;
            this.tb_pwd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.tb_pwd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.tb_pwd.BackColor = System.Drawing.Color.Transparent;
            this.tb_pwd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tb_pwd.BackgroundImage")));
            this.tb_pwd.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.tb_pwd.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.tb_pwd.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.tb_pwd.BorderColorIdle = System.Drawing.Color.Silver;
            this.tb_pwd.BorderRadius = 15;
            this.tb_pwd.BorderThickness = 1;
            this.tb_pwd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tb_pwd.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_pwd.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.tb_pwd.DefaultText = "";
            this.tb_pwd.FillColor = System.Drawing.Color.White;
            this.tb_pwd.HideSelection = true;
            this.tb_pwd.IconLeft = null;
            this.tb_pwd.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_pwd.IconPadding = 10;
            this.tb_pwd.IconRight = null;
            this.tb_pwd.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_pwd.Lines = new string[0];
            this.tb_pwd.Location = new System.Drawing.Point(106, 281);
            this.tb_pwd.MaxLength = 32767;
            this.tb_pwd.MinimumSize = new System.Drawing.Size(1, 1);
            this.tb_pwd.Modified = false;
            this.tb_pwd.Multiline = false;
            this.tb_pwd.Name = "tb_pwd";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.tb_pwd.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.tb_pwd.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.tb_pwd.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.tb_pwd.OnIdleState = stateProperties4;
            this.tb_pwd.Padding = new System.Windows.Forms.Padding(3);
            this.tb_pwd.PasswordChar = '●';
            this.tb_pwd.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.tb_pwd.PlaceholderText = "Enter text";
            this.tb_pwd.ReadOnly = false;
            this.tb_pwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_pwd.SelectedText = "";
            this.tb_pwd.SelectionLength = 0;
            this.tb_pwd.SelectionStart = 0;
            this.tb_pwd.ShortcutsEnabled = true;
            this.tb_pwd.Size = new System.Drawing.Size(374, 37);
            this.tb_pwd.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.tb_pwd.TabIndex = 7;
            this.tb_pwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_pwd.TextMarginBottom = 0;
            this.tb_pwd.TextMarginLeft = 3;
            this.tb_pwd.TextMarginTop = 0;
            this.tb_pwd.TextPlaceholder = "Enter text";
            this.tb_pwd.UseSystemPasswordChar = false;
            this.tb_pwd.WordWrap = true;
            // 
            // btn_login
            // 
            this.btn_login.AllowAnimations = true;
            this.btn_login.AllowMouseEffects = true;
            this.btn_login.AllowToggling = false;
            this.btn_login.AnimationSpeed = 200;
            this.btn_login.AutoGenerateColors = false;
            this.btn_login.AutoRoundBorders = false;
            this.btn_login.AutoSizeLeftIcon = true;
            this.btn_login.AutoSizeRightIcon = true;
            this.btn_login.BackColor = System.Drawing.Color.Transparent;
            this.btn_login.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btn_login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_login.BackgroundImage")));
            this.btn_login.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_login.ButtonText = "Đăng nhập";
            this.btn_login.ButtonTextMarginLeft = 0;
            this.btn_login.ColorContrastOnClick = 45;
            this.btn_login.ColorContrastOnHover = 45;
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btn_login.CustomizableEdges = borderEdges1;
            this.btn_login.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_login.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_login.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_login.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_login.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btn_login.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.ForeColor = System.Drawing.Color.White;
            this.btn_login.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_login.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btn_login.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btn_login.IconMarginLeft = 11;
            this.btn_login.IconPadding = 10;
            this.btn_login.IconRightAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_login.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btn_login.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btn_login.IconSize = 25;
            this.btn_login.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_login.IdleBorderRadius = 35;
            this.btn_login.IdleBorderThickness = 1;
            this.btn_login.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btn_login.IdleIconLeftImage = null;
            this.btn_login.IdleIconRightImage = null;
            this.btn_login.IndicateFocus = false;
            this.btn_login.Location = new System.Drawing.Point(215, 361);
            this.btn_login.Name = "btn_login";
            this.btn_login.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_login.OnDisabledState.BorderRadius = 35;
            this.btn_login.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_login.OnDisabledState.BorderThickness = 1;
            this.btn_login.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_login.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_login.OnDisabledState.IconLeftImage = null;
            this.btn_login.OnDisabledState.IconRightImage = null;
            this.btn_login.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_login.onHoverState.BorderRadius = 35;
            this.btn_login.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_login.onHoverState.BorderThickness = 1;
            this.btn_login.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_login.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btn_login.onHoverState.IconLeftImage = null;
            this.btn_login.onHoverState.IconRightImage = null;
            this.btn_login.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_login.OnIdleState.BorderRadius = 35;
            this.btn_login.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_login.OnIdleState.BorderThickness = 1;
            this.btn_login.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btn_login.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btn_login.OnIdleState.IconLeftImage = null;
            this.btn_login.OnIdleState.IconRightImage = null;
            this.btn_login.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_login.OnPressedState.BorderRadius = 35;
            this.btn_login.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_login.OnPressedState.BorderThickness = 1;
            this.btn_login.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_login.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btn_login.OnPressedState.IconLeftImage = null;
            this.btn_login.OnPressedState.IconRightImage = null;
            this.btn_login.Size = new System.Drawing.Size(166, 49);
            this.btn_login.TabIndex = 0;
            this.btn_login.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_login.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_login.TextMarginLeft = 0;
            this.btn_login.TextPadding = new System.Windows.Forms.Padding(0);
            this.btn_login.UseDefaultRadiusAndThickness = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // tb_username
            // 
            this.tb_username.AcceptsReturn = false;
            this.tb_username.AcceptsTab = false;
            this.tb_username.AnimationSpeed = 200;
            this.tb_username.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.tb_username.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.tb_username.BackColor = System.Drawing.Color.Transparent;
            this.tb_username.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tb_username.BackgroundImage")));
            this.tb_username.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.tb_username.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.tb_username.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.tb_username.BorderColorIdle = System.Drawing.Color.Silver;
            this.tb_username.BorderRadius = 15;
            this.tb_username.BorderThickness = 1;
            this.tb_username.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.tb_username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_username.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.tb_username.DefaultText = "";
            this.tb_username.FillColor = System.Drawing.Color.White;
            this.tb_username.HideSelection = true;
            this.tb_username.IconLeft = null;
            this.tb_username.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_username.IconPadding = 10;
            this.tb_username.IconRight = null;
            this.tb_username.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.tb_username.Lines = new string[0];
            this.tb_username.Location = new System.Drawing.Point(106, 201);
            this.tb_username.MaxLength = 32767;
            this.tb_username.MinimumSize = new System.Drawing.Size(1, 1);
            this.tb_username.Modified = false;
            this.tb_username.Multiline = false;
            this.tb_username.Name = "tb_username";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.tb_username.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.tb_username.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.tb_username.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.tb_username.OnIdleState = stateProperties8;
            this.tb_username.Padding = new System.Windows.Forms.Padding(3);
            this.tb_username.PasswordChar = '\0';
            this.tb_username.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.tb_username.PlaceholderText = "Enter text";
            this.tb_username.ReadOnly = false;
            this.tb_username.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_username.SelectedText = "";
            this.tb_username.SelectionLength = 0;
            this.tb_username.SelectionStart = 0;
            this.tb_username.ShortcutsEnabled = true;
            this.tb_username.Size = new System.Drawing.Size(374, 37);
            this.tb_username.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.tb_username.TabIndex = 6;
            this.tb_username.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_username.TextMarginBottom = 0;
            this.tb_username.TextMarginLeft = 3;
            this.tb_username.TextMarginTop = 0;
            this.tb_username.TextPlaceholder = "Enter text";
            this.tb_username.UseSystemPasswordChar = false;
            this.tb_username.WordWrap = true;
            // 
            // lb_pwd
            // 
            this.lb_pwd.AutoSize = true;
            this.lb_pwd.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pwd.Location = new System.Drawing.Point(106, 258);
            this.lb_pwd.Name = "lb_pwd";
            this.lb_pwd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lb_pwd.Size = new System.Drawing.Size(103, 17);
            this.lb_pwd.TabIndex = 5;
            this.lb_pwd.Text = "Nhập mật khẩu";
            // 
            // lb_userID
            // 
            this.lb_userID.AutoSize = true;
            this.lb_userID.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_userID.Location = new System.Drawing.Point(106, 178);
            this.lb_userID.Name = "lb_userID";
            this.lb_userID.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lb_userID.Size = new System.Drawing.Size(105, 17);
            this.lb_userID.TabIndex = 4;
            this.lb_userID.Text = "Nhập username";
            // 
            // lb_title_login
            // 
            this.lb_title_login.AutoSize = true;
            this.lb_title_login.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_title_login.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lb_title_login.Location = new System.Drawing.Point(145, 113);
            this.lb_title_login.Name = "lb_title_login";
            this.lb_title_login.Size = new System.Drawing.Size(307, 32);
            this.lb_title_login.TabIndex = 3;
            this.lb_title_login.Text = "Đăng nhập vào ứng dụng";
            // 
            // lb_title_re3
            // 
            this.lb_title_re3.AutoSize = true;
            this.lb_title_re3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_title_re3.Location = new System.Drawing.Point(93, 246);
            this.lb_title_re3.Name = "lb_title_re3";
            this.lb_title_re3.Size = new System.Drawing.Size(105, 21);
            this.lb_title_re3.TabIndex = 4;
            this.lb_title_re3.Text = "với chúng tôi";
            // 
            // lb_title_re2
            // 
            this.lb_title_re2.AutoSize = true;
            this.lb_title_re2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_title_re2.Location = new System.Drawing.Point(10, 219);
            this.lb_title_re2.Name = "lb_title_re2";
            this.lb_title_re2.Size = new System.Drawing.Size(278, 21);
            this.lb_title_re2.TabIndex = 3;
            this.lb_title_re2.Text = "Tạo tài khoản mới cho bạn để kết nối";
            // 
            // lb_title_re1
            // 
            this.lb_title_re1.AutoSize = true;
            this.lb_title_re1.Font = new System.Drawing.Font("Segoe UI Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_title_re1.Location = new System.Drawing.Point(80, 168);
            this.lb_title_re1.Name = "lb_title_re1";
            this.lb_title_re1.Size = new System.Drawing.Size(137, 40);
            this.lb_title_re1.TabIndex = 2;
            this.lb_title_re1.Text = "Đăng Ký";
            // 
            // btn_register
            // 
            this.btn_register.AllowAnimations = true;
            this.btn_register.AllowMouseEffects = true;
            this.btn_register.AllowToggling = false;
            this.btn_register.AnimationSpeed = 200;
            this.btn_register.AutoGenerateColors = false;
            this.btn_register.AutoRoundBorders = false;
            this.btn_register.AutoSizeLeftIcon = true;
            this.btn_register.AutoSizeRightIcon = true;
            this.btn_register.BackColor = System.Drawing.Color.Transparent;
            this.btn_register.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btn_register.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_register.BackgroundImage")));
            this.btn_register.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_register.ButtonText = "Đăng kí";
            this.btn_register.ButtonTextMarginLeft = 0;
            this.btn_register.ColorContrastOnClick = 45;
            this.btn_register.ColorContrastOnHover = 45;
            this.btn_register.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btn_register.CustomizableEdges = borderEdges2;
            this.btn_register.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_register.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_register.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_register.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_register.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btn_register.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_register.ForeColor = System.Drawing.Color.White;
            this.btn_register.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_register.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btn_register.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btn_register.IconMarginLeft = 11;
            this.btn_register.IconPadding = 10;
            this.btn_register.IconRightAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_register.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btn_register.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btn_register.IconSize = 25;
            this.btn_register.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_register.IdleBorderRadius = 35;
            this.btn_register.IdleBorderThickness = 1;
            this.btn_register.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btn_register.IdleIconLeftImage = null;
            this.btn_register.IdleIconRightImage = null;
            this.btn_register.IndicateFocus = false;
            this.btn_register.Location = new System.Drawing.Point(62, 281);
            this.btn_register.Name = "btn_register";
            this.btn_register.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_register.OnDisabledState.BorderRadius = 35;
            this.btn_register.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_register.OnDisabledState.BorderThickness = 1;
            this.btn_register.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_register.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_register.OnDisabledState.IconLeftImage = null;
            this.btn_register.OnDisabledState.IconRightImage = null;
            this.btn_register.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_register.onHoverState.BorderRadius = 35;
            this.btn_register.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_register.onHoverState.BorderThickness = 1;
            this.btn_register.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_register.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btn_register.onHoverState.IconLeftImage = null;
            this.btn_register.onHoverState.IconRightImage = null;
            this.btn_register.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_register.OnIdleState.BorderRadius = 35;
            this.btn_register.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_register.OnIdleState.BorderThickness = 1;
            this.btn_register.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btn_register.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btn_register.OnIdleState.IconLeftImage = null;
            this.btn_register.OnIdleState.IconRightImage = null;
            this.btn_register.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_register.OnPressedState.BorderRadius = 35;
            this.btn_register.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_register.OnPressedState.BorderThickness = 1;
            this.btn_register.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_register.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btn_register.OnPressedState.IconLeftImage = null;
            this.btn_register.OnPressedState.IconRightImage = null;
            this.btn_register.Size = new System.Drawing.Size(168, 49);
            this.btn_register.TabIndex = 5;
            this.btn_register.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_register.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_register.TextMarginLeft = 0;
            this.btn_register.TextPadding = new System.Windows.Forms.Padding(0);
            this.btn_register.UseDefaultRadiusAndThickness = true;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bunifuGradientPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 508);
            this.panel1.TabIndex = 1;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.BorderRadius = 1;
            this.bunifuGradientPanel1.Controls.Add(this.btn_register);
            this.bunifuGradientPanel1.Controls.Add(this.lb_title_re2);
            this.bunifuGradientPanel1.Controls.Add(this.lb_title_re3);
            this.bunifuGradientPanel1.Controls.Add(this.lb_title_re1);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.DarkSlateBlue;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.DarkTurquoise;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.DodgerBlue;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(292, 508);
            this.bunifuGradientPanel1.TabIndex = 0;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 508);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Login";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.bunifuGradientPanel1.ResumeLayout(false);
            this.bunifuGradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btn_login;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lb_title_re3;
        private System.Windows.Forms.Label lb_title_re2;
        private System.Windows.Forms.Label lb_title_re1;
        private System.Windows.Forms.Label lb_userID;
        private System.Windows.Forms.Label lb_title_login;
        private Bunifu.UI.WinForms.BunifuTextBox tb_username;
        private System.Windows.Forms.Label lb_pwd;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btn_register;
        private System.Windows.Forms.Label lb_warning;
        private Bunifu.UI.WinForms.BunifuTextBox tb_pwd;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.UI.WinForms.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.Label label1;
    }
}