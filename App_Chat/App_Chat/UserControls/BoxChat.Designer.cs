﻿namespace App_Chat
{
    partial class BoxChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BoxChat));
            this.bunifuPictureBox1 = new Bunifu.UI.WinForms.BunifuPictureBox();
            this.lb_name = new Bunifu.UI.WinForms.BunifuLabel();
            this.lb_user_id = new Bunifu.UI.WinForms.BunifuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).BeginInit();
            this.SuspendLayout();
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
            this.bunifuPictureBox1.TabIndex = 0;
            this.bunifuPictureBox1.TabStop = false;
            this.bunifuPictureBox1.Type = Bunifu.UI.WinForms.BunifuPictureBox.Types.Circle;
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
            this.lb_name.TabIndex = 1;
            this.lb_name.Text = "bunifuLabel1";
            this.lb_name.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lb_name.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
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
            this.lb_user_id.TabIndex = 2;
            this.lb_user_id.Text = "bunifuLabel2";
            this.lb_user_id.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lb_user_id.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // BoxChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.lb_user_id);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.bunifuPictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "BoxChat";
            this.Size = new System.Drawing.Size(325, 71);
            this.MouseEnter += new System.EventHandler(this.BoxChat_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.BoxChat_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        private Bunifu.UI.WinForms.BunifuLabel lb_name;
        private Bunifu.UI.WinForms.BunifuLabel lb_user_id;
    }
}
