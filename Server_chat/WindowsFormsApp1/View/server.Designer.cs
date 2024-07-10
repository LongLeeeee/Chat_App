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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_start = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(28, 80);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(745, 358);
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
            this.btn_start.ButtonText = "Start";
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
            this.btn_start.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btn_start.IdleBorderRadius = 10;
            this.btn_start.IdleBorderThickness = 1;
            this.btn_start.IdleFillColor = System.Drawing.Color.DodgerBlue;
            this.btn_start.IdleIconLeftImage = null;
            this.btn_start.IdleIconRightImage = null;
            this.btn_start.IndicateFocus = false;
            this.btn_start.Location = new System.Drawing.Point(623, 24);
            this.btn_start.Name = "btn_start";
            this.btn_start.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btn_start.OnDisabledState.BorderRadius = 10;
            this.btn_start.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_start.OnDisabledState.BorderThickness = 1;
            this.btn_start.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btn_start.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btn_start.OnDisabledState.IconLeftImage = null;
            this.btn_start.OnDisabledState.IconRightImage = null;
            this.btn_start.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_start.onHoverState.BorderRadius = 10;
            this.btn_start.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_start.onHoverState.BorderThickness = 1;
            this.btn_start.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.btn_start.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btn_start.onHoverState.IconLeftImage = null;
            this.btn_start.onHoverState.IconRightImage = null;
            this.btn_start.OnIdleState.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btn_start.OnIdleState.BorderRadius = 10;
            this.btn_start.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_start.OnIdleState.BorderThickness = 1;
            this.btn_start.OnIdleState.FillColor = System.Drawing.Color.DodgerBlue;
            this.btn_start.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btn_start.OnIdleState.IconLeftImage = null;
            this.btn_start.OnIdleState.IconRightImage = null;
            this.btn_start.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_start.OnPressedState.BorderRadius = 10;
            this.btn_start.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btn_start.OnPressedState.BorderThickness = 1;
            this.btn_start.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.btn_start.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btn_start.OnPressedState.IconLeftImage = null;
            this.btn_start.OnPressedState.IconRightImage = null;
            this.btn_start.Size = new System.Drawing.Size(150, 39);
            this.btn_start.TabIndex = 1;
            this.btn_start.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_start.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_start.TextMarginLeft = 0;
            this.btn_start.TextPadding = new System.Windows.Forms.Padding(0);
            this.btn_start.UseDefaultRadiusAndThickness = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.richTextBox1);
            this.Name = "server";
            this.Text = "server";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btn_start;
    }
}