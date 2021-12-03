namespace Exir
{
    partial class Edit_Heading_Detailed
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
            this.Lbl_Accounts = new System.Windows.Forms.Label();
            this.Cmb_Accounts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Cmb_Defenite_Account = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Cmb_Detailed_Account = new System.Windows.Forms.ComboBox();
            this.Btn_Edit = new System.Windows.Forms.Button();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.popupNotifier1 = new Tulpep.NotificationWindow.PopupNotifier();
            this.popupNotifier2 = new Tulpep.NotificationWindow.PopupNotifier();
            this.Lbl_Code_Det = new System.Windows.Forms.Label();
            this.Num_Code_Det = new Telerik.WinControls.UI.RadSpinEditor();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Code_Det)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Accounts
            // 
            this.Lbl_Accounts.AutoSize = true;
            this.Lbl_Accounts.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.Lbl_Accounts.Location = new System.Drawing.Point(681, 33);
            this.Lbl_Accounts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Accounts.Name = "Lbl_Accounts";
            this.Lbl_Accounts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lbl_Accounts.Size = new System.Drawing.Size(91, 33);
            this.Lbl_Accounts.TabIndex = 34;
            this.Lbl_Accounts.Text = "حساب کل :";
            // 
            // Cmb_Accounts
            // 
            this.Cmb_Accounts.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.Cmb_Accounts.FormattingEnabled = true;
            this.Cmb_Accounts.Location = new System.Drawing.Point(9, 23);
            this.Cmb_Accounts.Margin = new System.Windows.Forms.Padding(4);
            this.Cmb_Accounts.Name = "Cmb_Accounts";
            this.Cmb_Accounts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cmb_Accounts.Size = new System.Drawing.Size(659, 39);
            this.Cmb_Accounts.Sorted = true;
            this.Cmb_Accounts.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(675, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(101, 33);
            this.label1.TabIndex = 36;
            this.label1.Text = "حساب معین :";
            // 
            // Cmb_Defenite_Account
            // 
            this.Cmb_Defenite_Account.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.Cmb_Defenite_Account.FormattingEnabled = true;
            this.Cmb_Defenite_Account.Location = new System.Drawing.Point(9, 79);
            this.Cmb_Defenite_Account.Margin = new System.Windows.Forms.Padding(4);
            this.Cmb_Defenite_Account.Name = "Cmb_Defenite_Account";
            this.Cmb_Defenite_Account.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cmb_Defenite_Account.Size = new System.Drawing.Size(659, 39);
            this.Cmb_Defenite_Account.Sorted = true;
            this.Cmb_Defenite_Account.TabIndex = 35;
            this.Cmb_Defenite_Account.SelectedIndexChanged += new System.EventHandler(this.Cmb_Defenite_Account_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(669, 139);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(115, 33);
            this.label2.TabIndex = 38;
            this.label2.Text = "حساب تفصیلی :";
            // 
            // Cmb_Detailed_Account
            // 
            this.Cmb_Detailed_Account.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.Cmb_Detailed_Account.FormattingEnabled = true;
            this.Cmb_Detailed_Account.Location = new System.Drawing.Point(9, 135);
            this.Cmb_Detailed_Account.Margin = new System.Windows.Forms.Padding(4);
            this.Cmb_Detailed_Account.Name = "Cmb_Detailed_Account";
            this.Cmb_Detailed_Account.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cmb_Detailed_Account.Size = new System.Drawing.Size(659, 39);
            this.Cmb_Detailed_Account.Sorted = true;
            this.Cmb_Detailed_Account.TabIndex = 37;
            // 
            // Btn_Edit
            // 
            this.Btn_Edit.BackColor = System.Drawing.Color.Silver;
            this.Btn_Edit.BackgroundImage = global::Exir.Properties.Resources._051_rejected;
            this.Btn_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Edit.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Edit.ForeColor = System.Drawing.Color.Silver;
            this.Btn_Edit.Location = new System.Drawing.Point(192, 252);
            this.Btn_Edit.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Edit.Name = "Btn_Edit";
            this.Btn_Edit.Size = new System.Drawing.Size(131, 76);
            this.Btn_Edit.TabIndex = 45;
            this.Btn_Edit.UseVisualStyleBackColor = false;
            this.Btn_Edit.Click += new System.EventHandler(this.Btn_Edit_Click);
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackgroundImage = global::Exir.Properties.Resources._024_rejected;
            this.Btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cancel.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Cancel.ForeColor = System.Drawing.Color.Silver;
            this.Btn_Cancel.Location = new System.Drawing.Point(449, 252);
            this.Btn_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(131, 76);
            this.Btn_Cancel.TabIndex = 46;
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Remove_Click);
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
            // Lbl_Code_Det
            // 
            this.Lbl_Code_Det.AutoSize = true;
            this.Lbl_Code_Det.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Lbl_Code_Det.Location = new System.Drawing.Point(12, 192);
            this.Lbl_Code_Det.Name = "Lbl_Code_Det";
            this.Lbl_Code_Det.Size = new System.Drawing.Size(0, 23);
            this.Lbl_Code_Det.TabIndex = 47;
            // 
            // Num_Code_Det
            // 
            this.Num_Code_Det.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Num_Code_Det.Location = new System.Drawing.Point(168, 186);
            this.Num_Code_Det.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.Num_Code_Det.Name = "Num_Code_Det";
            this.Num_Code_Det.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Num_Code_Det.Size = new System.Drawing.Size(500, 32);
            this.Num_Code_Det.TabIndex = 49;
            this.Num_Code_Det.ThemeName = "Fluent";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(681, 185);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(90, 33);
            this.label7.TabIndex = 48;
            this.label7.Text = "کد حساب :";
            // 
            // Edit_Heading_Detailed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(783, 346);
            this.Controls.Add(this.Lbl_Code_Det);
            this.Controls.Add(this.Num_Code_Det);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Edit);
            this.Controls.Add(this.Cmb_Detailed_Account);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cmb_Defenite_Account);
            this.Controls.Add(this.Lbl_Accounts);
            this.Controls.Add(this.Cmb_Accounts);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Edit_Heading_Detailed";
            this.Text = "Edit_Heading_Detailed";
            ((System.ComponentModel.ISupportInitialize)(this.Num_Code_Det)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Accounts;
        private System.Windows.Forms.ComboBox Cmb_Accounts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cmb_Defenite_Account;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Cmb_Detailed_Account;
        private System.Windows.Forms.Button Btn_Edit;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Button Btn_Cancel;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier1;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier2;
        private System.Windows.Forms.Label Lbl_Code_Det;
        private Telerik.WinControls.UI.RadSpinEditor Num_Code_Det;
        private System.Windows.Forms.Label label7;
    }
}