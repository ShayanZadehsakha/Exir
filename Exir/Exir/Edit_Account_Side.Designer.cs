namespace Exir
{
    partial class Edit_Account_Side
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
            this.components = new System.ComponentModel.Container();
            this.Txt_Mobile_Phone = new Telerik.WinControls.UI.RadTextBox();
            this.Txt_Home_Phone = new Telerik.WinControls.UI.RadTextBox();
            this.Txt_Email = new Telerik.WinControls.UI.RadTextBox();
            this.Txt_Code = new Telerik.WinControls.UI.RadTextBox();
            this.Cmb_Account_Side = new System.Windows.Forms.ComboBox();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Apply = new System.Windows.Forms.Button();
            this.popupNotifier1 = new Tulpep.NotificationWindow.PopupNotifier();
            this.popupNotifier2 = new Tulpep.NotificationWindow.PopupNotifier();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.Txt_Description = new Telerik.WinControls.UI.RadTextBox();
            this.Txt_Address = new Telerik.WinControls.UI.RadTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Mobile_Phone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Home_Phone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Email)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Description)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Address)).BeginInit();
            this.SuspendLayout();
            // 
            // Txt_Mobile_Phone
            // 
            this.Txt_Mobile_Phone.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Mobile_Phone.Location = new System.Drawing.Point(12, 122);
            this.Txt_Mobile_Phone.Name = "Txt_Mobile_Phone";
            this.Txt_Mobile_Phone.NullText = "تلفن همراه";
            this.Txt_Mobile_Phone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Mobile_Phone.Size = new System.Drawing.Size(155, 35);
            this.Txt_Mobile_Phone.TabIndex = 43;
            this.Txt_Mobile_Phone.ThemeName = "Fluent";
            this.Txt_Mobile_Phone.TextChanged += new System.EventHandler(this.antyslash);
            // 
            // Txt_Home_Phone
            // 
            this.Txt_Home_Phone.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Home_Phone.Location = new System.Drawing.Point(201, 122);
            this.Txt_Home_Phone.Name = "Txt_Home_Phone";
            this.Txt_Home_Phone.NullText = "تلفن ثابت";
            this.Txt_Home_Phone.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Home_Phone.Size = new System.Drawing.Size(155, 35);
            this.Txt_Home_Phone.TabIndex = 42;
            this.Txt_Home_Phone.ThemeName = "Fluent";
            this.Txt_Home_Phone.TextChanged += new System.EventHandler(this.antyslash);
            // 
            // Txt_Email
            // 
            this.Txt_Email.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Email.Location = new System.Drawing.Point(12, 75);
            this.Txt_Email.Name = "Txt_Email";
            this.Txt_Email.NullText = "پست الکترونیک";
            this.Txt_Email.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Email.Size = new System.Drawing.Size(155, 35);
            this.Txt_Email.TabIndex = 40;
            this.Txt_Email.ThemeName = "Fluent";
            this.Txt_Email.TextChanged += new System.EventHandler(this.antyslash);
            // 
            // Txt_Code
            // 
            this.Txt_Code.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Code.Location = new System.Drawing.Point(201, 75);
            this.Txt_Code.Name = "Txt_Code";
            this.Txt_Code.NullText = "کد";
            this.Txt_Code.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Code.Size = new System.Drawing.Size(155, 35);
            this.Txt_Code.TabIndex = 41;
            this.Txt_Code.ThemeName = "Fluent";
            this.Txt_Code.TextChanged += new System.EventHandler(this.antyslash);
            // 
            // Cmb_Account_Side
            // 
            this.Cmb_Account_Side.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.Cmb_Account_Side.FormattingEnabled = true;
            this.Cmb_Account_Side.Location = new System.Drawing.Point(11, 21);
            this.Cmb_Account_Side.Name = "Cmb_Account_Side";
            this.Cmb_Account_Side.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cmb_Account_Side.Size = new System.Drawing.Size(344, 34);
            this.Cmb_Account_Side.Sorted = true;
            this.Cmb_Account_Side.TabIndex = 46;
            this.Cmb_Account_Side.Text = " نام طرف حساب";
            this.Cmb_Account_Side.TextChanged += new System.EventHandler(this.anty_slash_cmb);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackgroundImage = global::Exir.Properties.Resources._024_rejected;
            this.Btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cancel.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Cancel.ForeColor = System.Drawing.SystemColors.Control;
            this.Btn_Cancel.Location = new System.Drawing.Point(56, 367);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(96, 63);
            this.Btn_Cancel.TabIndex = 49;
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_Apply
            // 
            this.Btn_Apply.BackgroundImage = global::Exir.Properties.Resources._026_approved;
            this.Btn_Apply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Apply.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Apply.ForeColor = System.Drawing.SystemColors.Control;
            this.Btn_Apply.Location = new System.Drawing.Point(204, 367);
            this.Btn_Apply.Name = "Btn_Apply";
            this.Btn_Apply.Size = new System.Drawing.Size(96, 63);
            this.Btn_Apply.TabIndex = 48;
            this.Btn_Apply.UseVisualStyleBackColor = true;
            this.Btn_Apply.Click += new System.EventHandler(this.Btn_Apply_Click);
            // 
            // popupNotifier1
            // 
            this.popupNotifier1.BodyColor = System.Drawing.Color.LightGray;
            this.popupNotifier1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.popupNotifier1.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.popupNotifier1.ButtonHoverColor = System.Drawing.Color.Red;
            this.popupNotifier1.ContentColor = System.Drawing.Color.Black;
            this.popupNotifier1.ContentFont = new System.Drawing.Font("Lalezar", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popupNotifier1.ContentHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.popupNotifier1.ContentPadding = new System.Windows.Forms.Padding(0, -2, 0, 0);
            this.popupNotifier1.ContentText = "sample text";
            this.popupNotifier1.HeaderColor = System.Drawing.Color.White;
            this.popupNotifier1.HeaderHeight = 1;
            this.popupNotifier1.Image = global::Exir.Properties.Resources.alarm__1_;
            this.popupNotifier1.ImagePadding = new System.Windows.Forms.Padding(20, 20, 0, 0);
            this.popupNotifier1.IsRightToLeft = true;
            this.popupNotifier1.OptionsMenu = null;
            this.popupNotifier1.ShowGrip = false;
            this.popupNotifier1.ShowOptionsButton = true;
            this.popupNotifier1.Size = new System.Drawing.Size(500, 110);
            this.popupNotifier1.TitleColor = System.Drawing.Color.Black;
            this.popupNotifier1.TitleFont = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popupNotifier1.TitleText = "title sample";
            // 
            // popupNotifier2
            // 
            this.popupNotifier2.BodyColor = System.Drawing.Color.LightGray;
            this.popupNotifier2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.popupNotifier2.ButtonBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.popupNotifier2.ButtonHoverColor = System.Drawing.Color.Red;
            this.popupNotifier2.ContentColor = System.Drawing.Color.Black;
            this.popupNotifier2.ContentFont = new System.Drawing.Font("Lalezar", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popupNotifier2.ContentHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.popupNotifier2.ContentPadding = new System.Windows.Forms.Padding(0, -2, 0, 0);
            this.popupNotifier2.ContentText = "sample text";
            this.popupNotifier2.HeaderColor = System.Drawing.Color.White;
            this.popupNotifier2.HeaderHeight = 1;
            this.popupNotifier2.Image = global::Exir.Properties.Resources.checked__1_;
            this.popupNotifier2.ImagePadding = new System.Windows.Forms.Padding(30, 30, 0, 0);
            this.popupNotifier2.IsRightToLeft = true;
            this.popupNotifier2.OptionsMenu = null;
            this.popupNotifier2.ShowGrip = false;
            this.popupNotifier2.ShowOptionsButton = true;
            this.popupNotifier2.Size = new System.Drawing.Size(500, 110);
            this.popupNotifier2.TitleColor = System.Drawing.Color.Black;
            this.popupNotifier2.TitleFont = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popupNotifier2.TitleText = "title sample";
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // Txt_Description
            // 
            this.Txt_Description.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Description.Location = new System.Drawing.Point(11, 254);
            this.Txt_Description.Multiline = true;
            this.Txt_Description.Name = "Txt_Description";
            this.Txt_Description.NullText = "توضیحات";
            this.Txt_Description.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.Txt_Description.RootElement.StretchVertically = true;
            this.Txt_Description.Size = new System.Drawing.Size(344, 83);
            this.Txt_Description.TabIndex = 51;
            this.Txt_Description.ThemeName = "Fluent";
            this.Txt_Description.TextChanged += new System.EventHandler(this.antyslash);
            // 
            // Txt_Address
            // 
            this.Txt_Address.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Address.Location = new System.Drawing.Point(11, 163);
            this.Txt_Address.Multiline = true;
            this.Txt_Address.Name = "Txt_Address";
            this.Txt_Address.NullText = "آدرس";
            this.Txt_Address.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.Txt_Address.RootElement.StretchVertically = true;
            this.Txt_Address.Size = new System.Drawing.Size(344, 83);
            this.Txt_Address.TabIndex = 50;
            this.Txt_Address.ThemeName = "Fluent";
            this.Txt_Address.TextChanged += new System.EventHandler(this.antyslash);
            // 
            // Edit_Account_Side
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 450);
            this.Controls.Add(this.Txt_Description);
            this.Controls.Add(this.Txt_Address);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Apply);
            this.Controls.Add(this.Cmb_Account_Side);
            this.Controls.Add(this.Txt_Mobile_Phone);
            this.Controls.Add(this.Txt_Home_Phone);
            this.Controls.Add(this.Txt_Email);
            this.Controls.Add(this.Txt_Code);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(367, 450);
            this.MinimumSize = new System.Drawing.Size(367, 450);
            this.Name = "Edit_Account_Side";
            this.Text = "Edit_Account_Side";
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Mobile_Phone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Home_Phone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Email)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Description)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Address)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadTextBox Txt_Mobile_Phone;
        private Telerik.WinControls.UI.RadTextBox Txt_Home_Phone;
        private Telerik.WinControls.UI.RadTextBox Txt_Email;
        private Telerik.WinControls.UI.RadTextBox Txt_Code;
        private System.Windows.Forms.ComboBox Cmb_Account_Side;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Apply;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier1;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier2;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Telerik.WinControls.UI.RadTextBox Txt_Description;
        private Telerik.WinControls.UI.RadTextBox Txt_Address;
    }
}