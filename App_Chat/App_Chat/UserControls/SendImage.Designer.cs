namespace App_Chat.UserControls
{
    partial class SendImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendImage));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_send_message = new Bunifu.UI.WinForms.BunifuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(571, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(313, 200);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lb_send_message
            // 
            this.lb_send_message.AllowParentOverrides = false;
            this.lb_send_message.AutoEllipsis = false;
            this.lb_send_message.Cursor = System.Windows.Forms.Cursors.Default;
            this.lb_send_message.CursorType = System.Windows.Forms.Cursors.Default;
            this.lb_send_message.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lb_send_message.ForeColor = System.Drawing.Color.Black;
            this.lb_send_message.Location = new System.Drawing.Point(902, 173);
            this.lb_send_message.Margin = new System.Windows.Forms.Padding(15, 3, 15, 15);
            this.lb_send_message.Name = "lb_send_message";
            this.lb_send_message.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb_send_message.Size = new System.Drawing.Size(87, 20);
            this.lb_send_message.TabIndex = 1;
            this.lb_send_message.Text = "bunifuLabel1";
            this.lb_send_message.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lb_send_message.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // SendImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_send_message);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SendImage";
            this.Size = new System.Drawing.Size(1000, 200);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuLabel lb_send_message;
    }
}
