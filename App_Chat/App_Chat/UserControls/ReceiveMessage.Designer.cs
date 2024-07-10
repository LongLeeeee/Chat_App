namespace App_Chat.UserControls
{
    partial class ReceiveMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceiveMessage));
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.lb_receive_message = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuPanel1.AutoSize = true;
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel1.BorderRadius = 35;
            this.bunifuPanel1.BorderThickness = 0;
            this.bunifuPanel1.Controls.Add(this.lb_receive_message);
            this.bunifuPanel1.Location = new System.Drawing.Point(46, 4);
            this.bunifuPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(120, 50);
            this.bunifuPanel1.TabIndex = 2;
            // 
            // lb_receive_message
            // 
            this.lb_receive_message.AllowParentOverrides = false;
            this.lb_receive_message.AutoEllipsis = false;
            this.lb_receive_message.Cursor = System.Windows.Forms.Cursors.Default;
            this.lb_receive_message.CursorType = System.Windows.Forms.Cursors.Default;
            this.lb_receive_message.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lb_receive_message.ForeColor = System.Drawing.Color.White;
            this.lb_receive_message.Location = new System.Drawing.Point(16, 15);
            this.lb_receive_message.Margin = new System.Windows.Forms.Padding(15, 3, 15, 15);
            this.lb_receive_message.Name = "lb_receive_message";
            this.lb_receive_message.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lb_receive_message.Size = new System.Drawing.Size(87, 20);
            this.lb_receive_message.TabIndex = 0;
            this.lb_receive_message.Text = "bunifuLabel1";
            this.lb_receive_message.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lb_receive_message.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // ReceiveMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bunifuPanel1);
            this.Name = "ReceiveMessage";
            this.Size = new System.Drawing.Size(1000, 59);
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Bunifu.UI.WinForms.BunifuLabel lb_receive_message;
    }
}
