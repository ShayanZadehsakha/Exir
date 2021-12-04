namespace Exir.Forms
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
            this.pnl_Login = new System.Windows.Forms.Panel();
            this.txt_Username = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Login = new Telerik.WinControls.UI.RadButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Password = new Telerik.WinControls.UI.RadTextBox();
            this.chk_Remember_Me = new Telerik.WinControls.UI.RadCheckBox();
            this.btn_Secure_Password = new System.Windows.Forms.Button();
            this.materialTheme1 = new Telerik.WinControls.Themes.MaterialTheme();
            this.crystalTheme1 = new Telerik.WinControls.Themes.CrystalTheme();
            this.pnl_Login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Username)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Login)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Remember_Me)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_Login
            // 
            this.pnl_Login.BackColor = System.Drawing.Color.White;
            this.pnl_Login.Controls.Add(this.txt_Username);
            this.pnl_Login.Controls.Add(this.label2);
            this.pnl_Login.Controls.Add(this.btn_Login);
            this.pnl_Login.Controls.Add(this.label1);
            this.pnl_Login.Controls.Add(this.txt_Password);
            this.pnl_Login.Controls.Add(this.chk_Remember_Me);
            this.pnl_Login.Controls.Add(this.btn_Secure_Password);
            this.pnl_Login.Location = new System.Drawing.Point(0, 0);
            this.pnl_Login.Name = "pnl_Login";
            this.pnl_Login.Size = new System.Drawing.Size(593, 485);
            this.pnl_Login.TabIndex = 8;
            // 
            // txt_Username
            // 
            this.txt_Username.Font = new System.Drawing.Font("Shabnam", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Username.Location = new System.Drawing.Point(64, 35);
            this.txt_Username.Name = "txt_Username";
            this.txt_Username.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.txt_Username.RootElement.FocusBorderWidth = 2;
            this.txt_Username.Size = new System.Drawing.Size(400, 49);
            this.txt_Username.TabIndex = 4;
            this.txt_Username.ThemeName = "Material";
            ((Telerik.WinControls.UI.RadTextBoxElement)(txt_Username.GetChildAt(0))).FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(61)))));
            ((Telerik.WinControls.UI.RadTextBoxElement)(txt_Username.GetChildAt(0))).FocusBorderWidth = 2;
            ((Telerik.WinControls.Primitives.FillPrimitive)(txt_Username.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(txt_Username.GetChildAt(0).GetChildAt(2))).BottomWidth = 3F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(txt_Username.GetChildAt(0).GetChildAt(2))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(100)))), ((int)(((byte)(141)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(txt_Username.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(100)))), ((int)(((byte)(141)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(txt_Username.GetChildAt(0).GetChildAt(2))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Shabnam", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(488, 176);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(86, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "رمز عبور :";
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(100)))), ((int)(((byte)(141)))));
            this.btn_Login.ForeColor = System.Drawing.Color.White;
            this.btn_Login.Location = new System.Drawing.Point(138, 350);
            this.btn_Login.Name = "btn_Login";
            // 
            // 
            // 
            this.btn_Login.RootElement.BorderHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(61)))));
            this.btn_Login.RootElement.BorderHighlightThickness = 0;
            this.btn_Login.RootElement.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(61)))));
            this.btn_Login.RootElement.FocusBorderWidth = 0;
            this.btn_Login.RootElement.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(61)))));
            this.btn_Login.Size = new System.Drawing.Size(336, 88);
            this.btn_Login.TabIndex = 6;
            this.btn_Login.Text = "ورود";
            this.btn_Login.ThemeName = "Material";
            this.btn_Login.UseCompatibleTextRendering = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            this.btn_Login.MouseEnter += new System.EventHandler(this.btn_Login_MouseEnter);
            this.btn_Login.MouseLeave += new System.EventHandler(this.btn_Login_MouseLeave);
            ((Telerik.WinControls.UI.RadButtonElement)(btn_Login.GetChildAt(0))).Text = "ورود";
            ((Telerik.WinControls.UI.RadButtonElement)(btn_Login.GetChildAt(0))).ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(61)))));
            ((Telerik.WinControls.UI.RadButtonElement)(btn_Login.GetChildAt(0))).FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(61)))));
            ((Telerik.WinControls.UI.RadButtonElement)(btn_Login.GetChildAt(0))).FocusBorderWidth = 0;
            ((Telerik.WinControls.UI.RadButtonElement)(btn_Login.GetChildAt(0))).BorderHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(61)))));
            ((Telerik.WinControls.UI.RadButtonElement)(btn_Login.GetChildAt(0))).BorderHighlightThickness = 0;
            ((Telerik.WinControls.Primitives.TextPrimitive)(btn_Login.GetChildAt(0).GetChildAt(1).GetChildAt(1))).LineLimit = false;
            ((Telerik.WinControls.Primitives.TextPrimitive)(btn_Login.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Font = new System.Drawing.Font("Shabnam Medium", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            ((Telerik.WinControls.Primitives.TextPrimitive)(btn_Login.GetChildAt(0).GetChildAt(1).GetChildAt(1))).Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            ((Telerik.WinControls.Primitives.FocusPrimitive)(btn_Login.GetChildAt(0).GetChildAt(3))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(61)))));
            ((Telerik.WinControls.Primitives.FocusPrimitive)(btn_Login.GetChildAt(0).GetChildAt(3))).CanFocus = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Shabnam", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(472, 56);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(103, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام کاربری :";
            // 
            // txt_Password
            // 
            this.txt_Password.Font = new System.Drawing.Font("Shabnam", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txt_Password.Location = new System.Drawing.Point(64, 160);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.txt_Password.RootElement.FocusBorderWidth = 2;
            this.txt_Password.Size = new System.Drawing.Size(400, 49);
            this.txt_Password.TabIndex = 3;
            this.txt_Password.ThemeName = "Material";
            ((Telerik.WinControls.UI.RadTextBoxElement)(txt_Password.GetChildAt(0))).FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(61)))));
            ((Telerik.WinControls.UI.RadTextBoxElement)(txt_Password.GetChildAt(0))).FocusBorderWidth = 2;
            ((Telerik.WinControls.Primitives.FillPrimitive)(txt_Password.GetChildAt(0).GetChildAt(1))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(txt_Password.GetChildAt(0).GetChildAt(2))).BottomWidth = 3F;
            ((Telerik.WinControls.Primitives.BorderPrimitive)(txt_Password.GetChildAt(0).GetChildAt(2))).BottomColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(100)))), ((int)(((byte)(141)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(txt_Password.GetChildAt(0).GetChildAt(2))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(100)))), ((int)(((byte)(141)))));
            ((Telerik.WinControls.Primitives.BorderPrimitive)(txt_Password.GetChildAt(0).GetChildAt(2))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            // 
            // chk_Remember_Me
            // 
            this.chk_Remember_Me.Font = new System.Drawing.Font("Shabnam", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chk_Remember_Me.Location = new System.Drawing.Point(216, 266);
            this.chk_Remember_Me.Name = "chk_Remember_Me";
            this.chk_Remember_Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.chk_Remember_Me.RootElement.BorderHighlightThickness = 0;
            this.chk_Remember_Me.RootElement.FocusBorderWidth = 0;
            this.chk_Remember_Me.Size = new System.Drawing.Size(173, 28);
            this.chk_Remember_Me.TabIndex = 5;
            this.chk_Remember_Me.Text = " مرا به خاطر بسپار";
            this.chk_Remember_Me.ThemeName = "Crystal";
            this.chk_Remember_Me.UseCompatibleTextRendering = false;
            ((Telerik.WinControls.UI.RadCheckBoxElement)(chk_Remember_Me.GetChildAt(0))).Text = " مرا به خاطر بسپار";
            ((Telerik.WinControls.UI.RadCheckBoxElement)(chk_Remember_Me.GetChildAt(0))).FocusBorderWidth = 0;
            ((Telerik.WinControls.UI.RadCheckBoxElement)(chk_Remember_Me.GetChildAt(0))).BorderHighlightThickness = 0;
            ((Telerik.WinControls.UI.RadCheckBoxElement)(chk_Remember_Me.GetChildAt(0))).Font = new System.Drawing.Font("Shabnam", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            ((Telerik.WinControls.UI.RadCheckmark)(chk_Remember_Me.GetChildAt(0).GetChildAt(1).GetChildAt(1))).FocusBorderWidth = 0;
            ((Telerik.WinControls.UI.RadCheckmark)(chk_Remember_Me.GetChildAt(0).GetChildAt(1).GetChildAt(1))).BorderHighlightThickness = 0;
            ((Telerik.WinControls.Primitives.FillPrimitive)(chk_Remember_Me.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(100)))), ((int)(((byte)(141)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(chk_Remember_Me.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(100)))), ((int)(((byte)(141)))));
            ((Telerik.WinControls.Primitives.FillPrimitive)(chk_Remember_Me.GetChildAt(0).GetChildAt(1).GetChildAt(1).GetChildAt(0))).SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            // 
            // btn_Secure_Password
            // 
            this.btn_Secure_Password.BackgroundImage = global::Exir.Properties.Resources.visibility;
            this.btn_Secure_Password.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Secure_Password.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Secure_Password.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Secure_Password.Location = new System.Drawing.Point(8, 160);
            this.btn_Secure_Password.Name = "btn_Secure_Password";
            this.btn_Secure_Password.Size = new System.Drawing.Size(48, 56);
            this.btn_Secure_Password.TabIndex = 4;
            this.btn_Secure_Password.Tag = "";
            this.btn_Secure_Password.UseVisualStyleBackColor = true;
            this.btn_Secure_Password.Click += new System.EventHandler(this.btn_Secure_Password_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 485);
            this.Controls.Add(this.pnl_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "Login";
            this.pnl_Login.ResumeLayout(false);
            this.pnl_Login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Username)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Login)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Remember_Me)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Panel pnl_Login;
        public Telerik.WinControls.UI.RadTextBox txt_Username;
        public Label label2;
        public Telerik.WinControls.UI.RadButton btn_Login;
        public Label label1;
        public Telerik.WinControls.UI.RadTextBox txt_Password;
        public Telerik.WinControls.UI.RadCheckBox chk_Remember_Me;
        public Button btn_Secure_Password;
        public Telerik.WinControls.Themes.MaterialTheme materialTheme1;
        public Telerik.WinControls.Themes.CrystalTheme crystalTheme1;
    }
}