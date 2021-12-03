namespace Exir
{
    partial class Edit_Groups
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
            this.fluentTheme1 = new Telerik.WinControls.Themes.FluentTheme();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Apply = new System.Windows.Forms.Button();
            this.popupNotifier2 = new Tulpep.NotificationWindow.PopupNotifier();
            this.popupNotifier1 = new Tulpep.NotificationWindow.PopupNotifier();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.Cmb_Group_In_Groups = new System.Windows.Forms.ComboBox();
            this.Txt_Groups = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackgroundImage = global::Exir.Properties.Resources._023_online_shopping;
            this.Btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cancel.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Cancel.ForeColor = System.Drawing.SystemColors.Control;
            this.Btn_Cancel.Location = new System.Drawing.Point(259, 113);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(96, 63);
            this.Btn_Cancel.TabIndex = 13;
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_Apply
            // 
            this.Btn_Apply.BackgroundImage = global::Exir.Properties.Resources._018_shopping_bag;
            this.Btn_Apply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Apply.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Apply.ForeColor = System.Drawing.SystemColors.Control;
            this.Btn_Apply.Location = new System.Drawing.Point(90, 113);
            this.Btn_Apply.Name = "Btn_Apply";
            this.Btn_Apply.Size = new System.Drawing.Size(96, 63);
            this.Btn_Apply.TabIndex = 14;
            this.Btn_Apply.UseVisualStyleBackColor = true;
            this.Btn_Apply.Click += new System.EventHandler(this.Btn_Apply_Click);
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
            this.popupNotifier2.Size = new System.Drawing.Size(500, 100);
            this.popupNotifier2.TitleColor = System.Drawing.Color.Black;
            this.popupNotifier2.TitleFont = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popupNotifier2.TitleText = "title sample";
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
            this.popupNotifier1.Size = new System.Drawing.Size(400, 100);
            this.popupNotifier1.TitleColor = System.Drawing.Color.Black;
            this.popupNotifier1.TitleFont = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popupNotifier1.TitleText = "title sample";
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this;
            this.bunifuDragControl1.Vertical = true;
            // 
            // Cmb_Group_In_Groups
            // 
            this.Cmb_Group_In_Groups.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.Cmb_Group_In_Groups.FormattingEnabled = true;
            this.Cmb_Group_In_Groups.Location = new System.Drawing.Point(12, 12);
            this.Cmb_Group_In_Groups.Name = "Cmb_Group_In_Groups";
            this.Cmb_Group_In_Groups.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cmb_Group_In_Groups.Size = new System.Drawing.Size(402, 34);
            this.Cmb_Group_In_Groups.Sorted = true;
            this.Cmb_Group_In_Groups.TabIndex = 29;
            this.Cmb_Group_In_Groups.Text = "گروه";
            this.Cmb_Group_In_Groups.TextChanged += new System.EventHandler(this.anty_slash);
            // 
            // Txt_Groups
            // 
            this.Txt_Groups.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.Txt_Groups.FormattingEnabled = true;
            this.Txt_Groups.Location = new System.Drawing.Point(12, 61);
            this.Txt_Groups.Name = "Txt_Groups";
            this.Txt_Groups.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Groups.Size = new System.Drawing.Size(402, 34);
            this.Txt_Groups.Sorted = true;
            this.Txt_Groups.TabIndex = 30;
            this.Txt_Groups.Text = "زیر گروه";
            this.Txt_Groups.TextChanged += new System.EventHandler(this.anty_slash);
            // 
            // Edit_Groups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(426, 183);
            this.Controls.Add(this.Txt_Groups);
            this.Controls.Add(this.Cmb_Group_In_Groups);
            this.Controls.Add(this.Btn_Apply);
            this.Controls.Add(this.Btn_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(426, 183);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(426, 183);
            this.Name = "Edit_Groups";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(426, 183);
            this.ShowIcon = false;
            this.Text = "";
            this.ThemeName = "Fluent";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.FluentTheme fluentTheme1;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button Btn_Apply;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier2;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.ComboBox Cmb_Group_In_Groups;
        private System.Windows.Forms.ComboBox Txt_Groups;
    }
}