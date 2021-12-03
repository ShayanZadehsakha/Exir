namespace Exir
{
    partial class Edit_Heading_Total_Account
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
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.Lbl_Accounts = new System.Windows.Forms.Label();
            this.Cmb_Accounts = new System.Windows.Forms.ComboBox();
            this.Btn_Edit = new System.Windows.Forms.Button();
            this.popupNotifier1 = new Tulpep.NotificationWindow.PopupNotifier();
            this.popupNotifier2 = new Tulpep.NotificationWindow.PopupNotifier();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Num_Code_Tot = new Telerik.WinControls.UI.RadSpinEditor();
            this.label6 = new System.Windows.Forms.Label();
            this.Chk_Creditor = new System.Windows.Forms.CheckBox();
            this.Chk_Debtor = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Code_Tot)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // Lbl_Accounts
            // 
            this.Lbl_Accounts.AutoSize = true;
            this.Lbl_Accounts.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.Lbl_Accounts.Location = new System.Drawing.Point(669, 20);
            this.Lbl_Accounts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Accounts.Name = "Lbl_Accounts";
            this.Lbl_Accounts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Lbl_Accounts.Size = new System.Drawing.Size(91, 33);
            this.Lbl_Accounts.TabIndex = 35;
            this.Lbl_Accounts.Text = "حساب کل :";
            // 
            // Cmb_Accounts
            // 
            this.Cmb_Accounts.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.Cmb_Accounts.FormattingEnabled = true;
            this.Cmb_Accounts.Location = new System.Drawing.Point(15, 15);
            this.Cmb_Accounts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cmb_Accounts.Name = "Cmb_Accounts";
            this.Cmb_Accounts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cmb_Accounts.Size = new System.Drawing.Size(649, 39);
            this.Cmb_Accounts.Sorted = true;
            this.Cmb_Accounts.TabIndex = 34;
            this.Cmb_Accounts.TextChanged += new System.EventHandler(this.Cmb_Accounts_SelectedIndexChanged);
            // 
            // Btn_Edit
            // 
            this.Btn_Edit.BackColor = System.Drawing.Color.Silver;
            this.Btn_Edit.BackgroundImage = global::Exir.Properties.Resources._051_rejected;
            this.Btn_Edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Edit.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Edit.ForeColor = System.Drawing.Color.Silver;
            this.Btn_Edit.Location = new System.Drawing.Point(172, 213);
            this.Btn_Edit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Edit.Name = "Btn_Edit";
            this.Btn_Edit.Size = new System.Drawing.Size(131, 76);
            this.Btn_Edit.TabIndex = 45;
            this.Btn_Edit.UseVisualStyleBackColor = false;
            this.Btn_Edit.Click += new System.EventHandler(this.Btn_Edit_Click);
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
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackgroundImage = global::Exir.Properties.Resources._024_rejected;
            this.Btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cancel.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Cancel.ForeColor = System.Drawing.Color.Silver;
            this.Btn_Cancel.Location = new System.Drawing.Point(427, 213);
            this.Btn_Cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(131, 76);
            this.Btn_Cancel.TabIndex = 47;
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Num_Code_Tot
            // 
            this.Num_Code_Tot.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Num_Code_Tot.Location = new System.Drawing.Point(15, 76);
            this.Num_Code_Tot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Num_Code_Tot.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.Num_Code_Tot.Name = "Num_Code_Tot";
            this.Num_Code_Tot.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Num_Code_Tot.Size = new System.Drawing.Size(651, 32);
            this.Num_Code_Tot.TabIndex = 51;
            this.Num_Code_Tot.ThemeName = "Fluent";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(669, 78);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(90, 33);
            this.label6.TabIndex = 50;
            this.label6.Text = "کد حساب :";
            // 
            // Chk_Creditor
            // 
            this.Chk_Creditor.AutoSize = true;
            this.Chk_Creditor.Font = new System.Drawing.Font("IRRoya", 12F, System.Drawing.FontStyle.Bold);
            this.Chk_Creditor.Location = new System.Drawing.Point(201, 146);
            this.Chk_Creditor.Name = "Chk_Creditor";
            this.Chk_Creditor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Chk_Creditor.Size = new System.Drawing.Size(88, 38);
            this.Chk_Creditor.TabIndex = 4;
            this.Chk_Creditor.Text = "بستانکار";
            this.Chk_Creditor.UseVisualStyleBackColor = true;
            // 
            // Chk_Debtor
            // 
            this.Chk_Debtor.AutoSize = true;
            this.Chk_Debtor.Font = new System.Drawing.Font("IRRoya", 12F, System.Drawing.FontStyle.Bold);
            this.Chk_Debtor.Location = new System.Drawing.Point(453, 146);
            this.Chk_Debtor.Name = "Chk_Debtor";
            this.Chk_Debtor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Chk_Debtor.Size = new System.Drawing.Size(83, 38);
            this.Chk_Debtor.TabIndex = 3;
            this.Chk_Debtor.Text = "بدهکار";
            this.Chk_Debtor.UseVisualStyleBackColor = true;
            // 
            // Edit_Heading_Total_Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(772, 318);
            this.Controls.Add(this.Chk_Creditor);
            this.Controls.Add(this.Num_Code_Tot);
            this.Controls.Add(this.Chk_Debtor);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Btn_Edit);
            this.Controls.Add(this.Lbl_Accounts);
            this.Controls.Add(this.Cmb_Accounts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Edit_Heading_Total_Account";
            this.Text = "Edit_Heading";
            ((System.ComponentModel.ISupportInitialize)(this.Num_Code_Tot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Label Lbl_Accounts;
        private System.Windows.Forms.ComboBox Cmb_Accounts;
        private System.Windows.Forms.Button Btn_Edit;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier1;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier2;
        private System.Windows.Forms.Button Btn_Cancel;
        private Telerik.WinControls.UI.RadSpinEditor Num_Code_Tot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox Chk_Creditor;
        private System.Windows.Forms.CheckBox Chk_Debtor;
    }
}