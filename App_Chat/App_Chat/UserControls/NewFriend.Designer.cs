namespace App_Chat.UserControls
{
    partial class NewFriend
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewFriend));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.lb_user_id = new Bunifu.UI.WinForms.BunifuLabel();
            this.lb_name = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.btn_add_friend = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btn_cancel = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_user_id
            // 
            this.lb_user_id.AllowParentOverrides = false;
            this.lb_user_id.AutoEllipsis = false;
            this.lb_user_id.CursorType = null;
            this.lb_user_id.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_user_id.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lb_user_id.Location = new System.Drawing.Point(84, 38);
            this.lb_user_id.Name = "lb_user_id";
            this.lb_user_id.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb_user_id.Size = new System.Drawing.Size(86, 20);
            this.lb_user_id.TabIndex = 5;
            this.lb_user_id.Text = "bunifuLabel2";
            this.lb_user_id.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lb_user_id.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // lb_name
            // 
            this.lb_name.AllowParentOverrides = false;
            this.lb_name.AutoEllipsis = false;
            this.lb_name.Cursor = System.Windows.Forms.Cursors.Default;
            this.lb_name.CursorType = System.Windows.Forms.Cursors.Default;
            this.lb_name.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_name.Location = new System.Drawing.Point(84, 12);
            this.lb_name.Name = "lb_name";
            this.lb_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb_name.Size = new System.Drawing.Size(86, 20);
            this.lb_name.TabIndex = 4;
            this.lb_name.Text = "bunifuLabel1";
            this.lb_name.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lb_name.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuPictureBox1
            // 
            this.bunifuPictureBox1.AllowFocused = false;
            this.bunifuPictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bunifuPictureBox1.AutoSizeHeight = true;
            this.bunifuPictureBox1.BorderRadius = 30;
            this.bunifuPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuPictureBox1.Image")));
            this.bunifuPictureBox1.IsCircle = true;
            this.bunifuPictureBox1.Location = new System.Drawing.Point(19, 5);
            this.bunifuPictureBox1.Name = "bunifuPictureBox1";
            this.bunifuPictureBox1.Size = new System.Drawing.Size(60, 60);
            this.bunifuPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuPictureBox1.TabIndex = 3;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
            // 
            // btn_add_friend
            // 
            this.btn_add_friend.AllowAnimations = true;
            this.btn_add_friend.AllowMouseEffects = true;
            this.btn_add_friend.AllowToggling = false;
            this.btn_add_friend.AnimationSpeed = 200;
            this.btn_add_friend.AutoGenerateColors = false;
            this.btn_add_friend.AutoRoundBorders = false;
            this.btn_add_friend.AutoSizeLeftIcon = true;
            this.btn_add_friend.AutoSizeRightIcon = true;
            this.btn_add_friend.BackColor = System.Drawing.Color.Transparent;
            this.btn_add_friend.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btn_add_friend.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_add_friend.BackgroundImage")));
            this.btn_add_friend.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_add_friend.ButtonText = "Kết bạn";
            this.btn_add_friend.ButtonTextMarginLeft = 0;
            this.btn_add_friend.ColorContrastOnClick = 45;
            this.btn_add_friend.ColorContrastOnHover = 45;
            this.btn_add_friend.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btn_add_friend.CustomizableEdges = borderEdges1;
            this.btn_add_friend.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_add_friend.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_add_friend.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_add_friend.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_add_friend.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btn_add_friend.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_add_friend.ForeColor = System.Drawing.Color.White;
            this.btn_add_friend.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_add_friend.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btn_add_friend.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btn_add_friend.IconMarginLeft = 11;
            this.btn_add_friend.IconPadding = 10;
            this.btn_add_friend.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_add_friend.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btn_add_friend.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btn_add_friend.IconSize = 25;
            this.btn_add_friend.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_add_friend.IdleBorderRadius = 20;
            this.btn_add_friend.IdleBorderThickness = 1;
            this.btn_add_friend.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btn_add_friend.IdleIconLeftImage = null;
            this.btn_add_friend.IdleIconRightImage = null;
            this.btn_add_friend.IndicateFocus = false;
            this.btn_add_friend.Location = new System.Drawing.Point(210, 5);
            this.btn_add_friend.Name = "btn_add_friend";
            this.btn_add_friend.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_add_friend.OnDisabledState.BorderRadius = 20;
            this.btn_add_friend.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_add_friend.OnDisabledState.BorderThickness = 1;
            this.btn_add_friend.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_add_friend.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_add_friend.OnDisabledState.IconLeftImage = null;
            this.btn_add_friend.OnDisabledState.IconRightImage = null;
            this.btn_add_friend.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_add_friend.onHoverState.BorderRadius = 20;
            this.btn_add_friend.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_add_friend.onHoverState.BorderThickness = 1;
            this.btn_add_friend.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_add_friend.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btn_add_friend.onHoverState.IconLeftImage = null;
            this.btn_add_friend.onHoverState.IconRightImage = null;
            this.btn_add_friend.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_add_friend.OnIdleState.BorderRadius = 20;
            this.btn_add_friend.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_add_friend.OnIdleState.BorderThickness = 1;
            this.btn_add_friend.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btn_add_friend.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btn_add_friend.OnIdleState.IconLeftImage = null;
            this.btn_add_friend.OnIdleState.IconRightImage = null;
            this.btn_add_friend.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_add_friend.OnPressedState.BorderRadius = 20;
            this.btn_add_friend.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_add_friend.OnPressedState.BorderThickness = 1;
            this.btn_add_friend.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_add_friend.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btn_add_friend.OnPressedState.IconLeftImage = null;
            this.btn_add_friend.OnPressedState.IconRightImage = null;
            this.btn_add_friend.Size = new System.Drawing.Size(89, 27);
            this.btn_add_friend.TabIndex = 6;
            this.btn_add_friend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_add_friend.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_add_friend.TextMarginLeft = 0;
            this.btn_add_friend.TextPadding = new System.Windows.Forms.Padding(0);
            this.btn_add_friend.UseDefaultRadiusAndThickness = true;
            this.btn_add_friend.Click += new System.EventHandler(this.btn_add_friend_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.AllowAnimations = true;
            this.btn_cancel.AllowMouseEffects = true;
            this.btn_cancel.AllowToggling = false;
            this.btn_cancel.AnimationSpeed = 200;
            this.btn_cancel.AutoGenerateColors = false;
            this.btn_cancel.AutoRoundBorders = false;
            this.btn_cancel.AutoSizeLeftIcon = true;
            this.btn_cancel.AutoSizeRightIcon = true;
            this.btn_cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_cancel.BackColor1 = System.Drawing.Color.DodgerBlue;
            this.btn_cancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_cancel.BackgroundImage")));
            this.btn_cancel.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_cancel.ButtonText = "Hủy";
            this.btn_cancel.ButtonTextMarginLeft = 0;
            this.btn_cancel.ColorContrastOnClick = 45;
            this.btn_cancel.ColorContrastOnHover = 45;
            this.btn_cancel.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btn_cancel.CustomizableEdges = borderEdges2;
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_cancel.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_cancel.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_cancel.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_cancel.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btn_cancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancel.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btn_cancel.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btn_cancel.IconMarginLeft = 11;
            this.btn_cancel.IconPadding = 10;
            this.btn_cancel.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cancel.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btn_cancel.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btn_cancel.IconSize = 25;
            this.btn_cancel.IdleBorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_cancel.IdleBorderRadius = 20;
            this.btn_cancel.IdleBorderThickness = 1;
            this.btn_cancel.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btn_cancel.IdleIconLeftImage = null;
            this.btn_cancel.IdleIconRightImage = null;
            this.btn_cancel.IndicateFocus = false;
            this.btn_cancel.Location = new System.Drawing.Point(210, 39);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_cancel.OnDisabledState.BorderRadius = 20;
            this.btn_cancel.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_cancel.OnDisabledState.BorderThickness = 1;
            this.btn_cancel.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_cancel.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_cancel.OnDisabledState.IconLeftImage = null;
            this.btn_cancel.OnDisabledState.IconRightImage = null;
            this.btn_cancel.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_cancel.onHoverState.BorderRadius = 20;
            this.btn_cancel.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_cancel.onHoverState.BorderThickness = 1;
            this.btn_cancel.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_cancel.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.onHoverState.IconLeftImage = null;
            this.btn_cancel.onHoverState.IconRightImage = null;
            this.btn_cancel.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_cancel.OnIdleState.BorderRadius = 20;
            this.btn_cancel.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_cancel.OnIdleState.BorderThickness = 1;
            this.btn_cancel.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btn_cancel.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.OnIdleState.IconLeftImage = null;
            this.btn_cancel.OnIdleState.IconRightImage = null;
            this.btn_cancel.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_cancel.OnPressedState.BorderRadius = 20;
            this.btn_cancel.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_cancel.OnPressedState.BorderThickness = 1;
            this.btn_cancel.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_cancel.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.OnPressedState.IconLeftImage = null;
            this.btn_cancel.OnPressedState.IconRightImage = null;
            this.btn_cancel.Size = new System.Drawing.Size(89, 27);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_cancel.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_cancel.TextMarginLeft = 0;
            this.btn_cancel.TextPadding = new System.Windows.Forms.Padding(0);
            this.btn_cancel.UseDefaultRadiusAndThickness = true;
            this.btn_cancel.Visible = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // NewFriend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_add_friend);
            this.Controls.Add(this.lb_user_id);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.bunifuPictureBox1);
            this.Name = "NewFriend";
            this.Size = new System.Drawing.Size(325, 71);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuLabel lb_user_id;
        private Bunifu.UI.WinForms.BunifuLabel lb_name;
        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btn_add_friend;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btn_cancel;
    }
}
