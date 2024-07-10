namespace App_Chat
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
            this.lb_latest_message = new Bunifu.UI.WinForms.BunifuLabel();
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
            // lb_latest_message
            // 
            this.lb_latest_message.AllowParentOverrides = false;
            this.lb_latest_message.AutoEllipsis = false;
            this.lb_latest_message.CursorType = null;
            this.lb_latest_message.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_latest_message.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lb_latest_message.Location = new System.Drawing.Point(84, 38);
            this.lb_latest_message.Name = "lb_latest_message";
            this.lb_latest_message.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb_latest_message.Size = new System.Drawing.Size(86, 20);
            this.lb_latest_message.TabIndex = 2;
            this.lb_latest_message.Text = "bunifuLabel2";
            this.lb_latest_message.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lb_latest_message.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // BoxChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_latest_message);
            this.Controls.Add(this.lb_name);
            this.Controls.Add(this.bunifuPictureBox1);
            this.Name = "BoxChat";
            this.Size = new System.Drawing.Size(325, 71);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPictureBox bunifuPictureBox1;
        private Bunifu.UI.WinForms.BunifuLabel lb_name;
        private Bunifu.UI.WinForms.BunifuLabel lb_latest_message;
    }
}
