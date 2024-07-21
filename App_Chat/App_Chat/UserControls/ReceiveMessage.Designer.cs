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
            this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
            this.lb_receive_message = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuPanel2
            // 
            this.bunifuPanel2.AutoSize = true;
            this.bunifuPanel2.BackgroundColor = System.Drawing.Color.LightGray;
            this.bunifuPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel2.BackgroundImage")));
            this.bunifuPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel2.BorderColor = System.Drawing.Color.Transparent;
            this.bunifuPanel2.BorderRadius = 35;
            this.bunifuPanel2.BorderThickness = 0;
            this.bunifuPanel2.Controls.Add(this.lb_receive_message);
            this.bunifuPanel2.Location = new System.Drawing.Point(79, 4);
            this.bunifuPanel2.Name = "bunifuPanel2";
            this.bunifuPanel2.ShowBorders = true;
            this.bunifuPanel2.Size = new System.Drawing.Size(123, 50);
            this.bunifuPanel2.TabIndex = 3;
            // 
            // lb_receive_message
            // 
            this.lb_receive_message.AllowParentOverrides = false;
            this.lb_receive_message.AutoEllipsis = false;
            this.lb_receive_message.Cursor = System.Windows.Forms.Cursors.Default;
            this.lb_receive_message.CursorType = System.Windows.Forms.Cursors.Default;
            this.lb_receive_message.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold);
            this.lb_receive_message.Location = new System.Drawing.Point(17, 14);
            this.lb_receive_message.Margin = new System.Windows.Forms.Padding(0, 3, 18, 14);
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
            this.Controls.Add(this.bunifuPanel2);
            this.Name = "ReceiveMessage";
            this.Size = new System.Drawing.Size(1000, 59);
            this.bunifuPanel2.ResumeLayout(false);
            this.bunifuPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel2;
        private Bunifu.UI.WinForms.BunifuLabel lb_receive_message;
    }
}
