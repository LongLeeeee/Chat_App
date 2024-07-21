namespace App_Chat.UserControls
{
    partial class ReceiveImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiveImage));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_receive_message = new Bunifu.UI.WinForms.BunifuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(123, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(313, 200);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lb_receive_message
            // 
            this.lb_receive_message.AllowParentOverrides = false;
            this.lb_receive_message.AutoEllipsis = false;
            this.lb_receive_message.Cursor = System.Windows.Forms.Cursors.Default;
            this.lb_receive_message.CursorType = System.Windows.Forms.Cursors.Default;
            this.lb_receive_message.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lb_receive_message.Location = new System.Drawing.Point(15, 167);
            this.lb_receive_message.Margin = new System.Windows.Forms.Padding(0, 3, 18, 14);
            this.lb_receive_message.Name = "lb_receive_message";
            this.lb_receive_message.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb_receive_message.Size = new System.Drawing.Size(87, 20);
            this.lb_receive_message.TabIndex = 3;
            this.lb_receive_message.Text = "bunifuLabel1";
            this.lb_receive_message.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lb_receive_message.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // ReceiveImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_receive_message);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ReceiveImage";
            this.Size = new System.Drawing.Size(1000, 200);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuLabel lb_receive_message;
    }
}
