namespace Exir
{
    partial class Payment_Factor
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
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.Txt_Check_Price = new Telerik.WinControls.UI.RadTextBox();
            this.Txt_Bank_Account_Price = new Telerik.WinControls.UI.RadTextBox();
            this.Txt_Cash_Price = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Cmb_Bank_Account = new System.Windows.Forms.ComboBox();
            this.Cmb_Cash_Desk = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_Price = new Telerik.WinControls.UI.RadTextBox();
            this.Btn_Apply_Buy = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Lbl_Price_In_String = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Cmb_Check = new System.Windows.Forms.ComboBox();
            this.popupNotifier1 = new Tulpep.NotificationWindow.PopupNotifier();
            this.popupNotifier2 = new Tulpep.NotificationWindow.PopupNotifier();
            this.fluentTheme1 = new Telerik.WinControls.Themes.FluentTheme();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Check_Price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Bank_Account_Price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Cash_Price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Price)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label20.Location = new System.Drawing.Point(171, 120);
            this.label20.Name = "label20";
            this.label20.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label20.Size = new System.Drawing.Size(51, 33);
            this.label20.TabIndex = 113;
            this.label20.Text = "مبلغ :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label21.Location = new System.Drawing.Point(171, 71);
            this.label21.Name = "label21";
            this.label21.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label21.Size = new System.Drawing.Size(51, 33);
            this.label21.TabIndex = 112;
            this.label21.Text = "مبلغ :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label22.Location = new System.Drawing.Point(171, 19);
            this.label22.Name = "label22";
            this.label22.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label22.Size = new System.Drawing.Size(51, 33);
            this.label22.TabIndex = 111;
            this.label22.Text = "مبلغ :";
            // 
            // Txt_Check_Price
            // 
            this.Txt_Check_Price.BackColor = System.Drawing.SystemColors.Menu;
            this.Txt_Check_Price.Enabled = false;
            this.Txt_Check_Price.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Check_Price.Location = new System.Drawing.Point(8, 115);
            this.Txt_Check_Price.Name = "Txt_Check_Price";
            this.Txt_Check_Price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Check_Price.Size = new System.Drawing.Size(157, 41);
            this.Txt_Check_Price.TabIndex = 109;
            this.Txt_Check_Price.ThemeName = "Fluent";
            this.Txt_Check_Price.TextChanged += new System.EventHandler(this.Txt_Cash_Price_TextChanged);
            // 
            // Txt_Bank_Account_Price
            // 
            this.Txt_Bank_Account_Price.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Bank_Account_Price.Location = new System.Drawing.Point(8, 67);
            this.Txt_Bank_Account_Price.Name = "Txt_Bank_Account_Price";
            this.Txt_Bank_Account_Price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Bank_Account_Price.Size = new System.Drawing.Size(157, 41);
            this.Txt_Bank_Account_Price.TabIndex = 110;
            this.Txt_Bank_Account_Price.ThemeName = "Fluent";
            this.Txt_Bank_Account_Price.TextChanged += new System.EventHandler(this.Txt_Cash_Price_TextChanged);
            // 
            // Txt_Cash_Price
            // 
            this.Txt_Cash_Price.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Cash_Price.Location = new System.Drawing.Point(8, 14);
            this.Txt_Cash_Price.Name = "Txt_Cash_Price";
            this.Txt_Cash_Price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Cash_Price.Size = new System.Drawing.Size(157, 41);
            this.Txt_Cash_Price.TabIndex = 108;
            this.Txt_Cash_Price.ThemeName = "Fluent";
            this.Txt_Cash_Price.TextChanged += new System.EventHandler(this.Txt_Cash_Price_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(446, 119);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(52, 33);
            this.label1.TabIndex = 107;
            this.label1.Text = "چک :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(446, 70);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(59, 33);
            this.label2.TabIndex = 105;
            this.label2.Text = "بانکی :";
            // 
            // Cmb_Bank_Account
            // 
            this.Cmb_Bank_Account.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.Cmb_Bank_Account.FormattingEnabled = true;
            this.Cmb_Bank_Account.Location = new System.Drawing.Point(224, 67);
            this.Cmb_Bank_Account.Name = "Cmb_Bank_Account";
            this.Cmb_Bank_Account.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cmb_Bank_Account.Size = new System.Drawing.Size(216, 39);
            this.Cmb_Bank_Account.Sorted = true;
            this.Cmb_Bank_Account.TabIndex = 104;
            // 
            // Cmb_Cash_Desk
            // 
            this.Cmb_Cash_Desk.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.Cmb_Cash_Desk.FormattingEnabled = true;
            this.Cmb_Cash_Desk.Location = new System.Drawing.Point(224, 15);
            this.Cmb_Cash_Desk.Name = "Cmb_Cash_Desk";
            this.Cmb_Cash_Desk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cmb_Cash_Desk.Size = new System.Drawing.Size(216, 39);
            this.Cmb_Cash_Desk.Sorted = true;
            this.Cmb_Cash_Desk.TabIndex = 102;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(446, 18);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(58, 33);
            this.label3.TabIndex = 103;
            this.label3.Text = "نقدی :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(404, 165);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(109, 33);
            this.label4.TabIndex = 115;
            this.label4.Text = "مبلغ باقیمانده :";
            // 
            // Txt_Price
            // 
            this.Txt_Price.BackColor = System.Drawing.SystemColors.Menu;
            this.Txt_Price.Enabled = false;
            this.Txt_Price.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Price.Location = new System.Drawing.Point(8, 161);
            this.Txt_Price.Name = "Txt_Price";
            this.Txt_Price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Price.Size = new System.Drawing.Size(390, 41);
            this.Txt_Price.TabIndex = 114;
            this.Txt_Price.ThemeName = "Fluent";
            this.Txt_Price.TextChanged += new System.EventHandler(this.Txt_Price_TextChanged);
            // 
            // Btn_Apply_Buy
            // 
            this.Btn_Apply_Buy.BackgroundImage = global::Exir.Properties.Resources._026_approved;
            this.Btn_Apply_Buy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Apply_Buy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Apply_Buy.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Apply_Buy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Btn_Apply_Buy.Location = new System.Drawing.Point(205, 257);
            this.Btn_Apply_Buy.Name = "Btn_Apply_Buy";
            this.Btn_Apply_Buy.Size = new System.Drawing.Size(96, 63);
            this.Btn_Apply_Buy.TabIndex = 117;
            this.Btn_Apply_Buy.UseVisualStyleBackColor = true;
            this.Btn_Apply_Buy.Click += new System.EventHandler(this.Btn_Apply_Buy_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.Lbl_Price_In_String);
            this.panel1.Location = new System.Drawing.Point(12, 212);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 26);
            this.panel1.TabIndex = 119;
            // 
            // Lbl_Price_In_String
            // 
            this.Lbl_Price_In_String.AutoSize = true;
            this.Lbl_Price_In_String.Dock = System.Windows.Forms.DockStyle.Right;
            this.Lbl_Price_In_String.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.Lbl_Price_In_String.Location = new System.Drawing.Point(386, 0);
            this.Lbl_Price_In_String.Name = "Lbl_Price_In_String";
            this.Lbl_Price_In_String.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lbl_Price_In_String.Size = new System.Drawing.Size(0, 33);
            this.Lbl_Price_In_String.TabIndex = 45;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.label11.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(411, 212);
            this.label11.Name = "label11";
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(110, 33);
            this.label11.TabIndex = 118;
            this.label11.Text = "مبلغ به حروف :";
            // 
            // Cmb_Check
            // 
            this.Cmb_Check.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.Cmb_Check.FormattingEnabled = true;
            this.Cmb_Check.Location = new System.Drawing.Point(224, 115);
            this.Cmb_Check.Name = "Cmb_Check";
            this.Cmb_Check.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cmb_Check.Size = new System.Drawing.Size(216, 39);
            this.Cmb_Check.Sorted = true;
            this.Cmb_Check.TabIndex = 120;
            this.Cmb_Check.SelectedIndexChanged += new System.EventHandler(this.Cmb_Check_SelectedIndexChanged);
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
            // Payment_Factor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(499, 327);
            this.Controls.Add(this.Cmb_Check);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Btn_Apply_Buy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Txt_Price);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.Txt_Check_Price);
            this.Controls.Add(this.Txt_Bank_Account_Price);
            this.Controls.Add(this.Txt_Cash_Price);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Cmb_Bank_Account);
            this.Controls.Add(this.Cmb_Cash_Desk);
            this.Controls.Add(this.label3);
            this.MaximizeBox = false;
            this.Name = "Payment_Factor";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.Text = "";
            this.ThemeName = "Fluent";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Payment_Factor_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Check_Price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Bank_Account_Price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Cash_Price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Price)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private Telerik.WinControls.UI.RadTextBox Txt_Check_Price;
        private Telerik.WinControls.UI.RadTextBox Txt_Bank_Account_Price;
        private Telerik.WinControls.UI.RadTextBox Txt_Cash_Price;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Cmb_Bank_Account;
        private System.Windows.Forms.ComboBox Cmb_Cash_Desk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Telerik.WinControls.UI.RadTextBox Txt_Price;
        private System.Windows.Forms.Button Btn_Apply_Buy;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Lbl_Price_In_String;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox Cmb_Check;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier1;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier2;
        private Telerik.WinControls.Themes.FluentTheme fluentTheme1;
    }
}