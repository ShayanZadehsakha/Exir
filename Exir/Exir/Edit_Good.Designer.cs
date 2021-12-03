namespace Exir
{
    partial class Edit_Good
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
            this.Num_Stock = new Telerik.WinControls.UI.RadSpinEditor();
            this.Txt_Price = new Telerik.WinControls.UI.RadTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Cmb_Groups = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Cmb_Group = new System.Windows.Forms.ComboBox();
            this.Cmb_Good = new System.Windows.Forms.ComboBox();
            this.Btn_Apply = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.popupNotifier2 = new Tulpep.NotificationWindow.PopupNotifier();
            this.popupNotifier1 = new Tulpep.NotificationWindow.PopupNotifier();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.fluentTheme1 = new Telerik.WinControls.Themes.FluentTheme();
            ((System.ComponentModel.ISupportInitialize)(this.Num_Stock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Price)).BeginInit();
            this.SuspendLayout();
            // 
            // Num_Stock
            // 
            this.Num_Stock.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.Num_Stock.Location = new System.Drawing.Point(257, 65);
            this.Num_Stock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Num_Stock.Name = "Num_Stock";
            this.Num_Stock.Size = new System.Drawing.Size(140, 35);
            this.Num_Stock.TabIndex = 31;
            this.Num_Stock.ThemeName = "Fluent";
            // 
            // Txt_Price
            // 
            this.Txt_Price.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Price.Location = new System.Drawing.Point(23, 63);
            this.Txt_Price.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_Price.Name = "Txt_Price";
            this.Txt_Price.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Price.Size = new System.Drawing.Size(160, 43);
            this.Txt_Price.TabIndex = 32;
            this.Txt_Price.ThemeName = "Fluent";
            this.Txt_Price.TextChanged += new System.EventHandler(this.Txt_Price_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(191, 68);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(58, 33);
            this.label5.TabIndex = 33;
            this.label5.Text = "قیمت :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(423, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(53, 33);
            this.label2.TabIndex = 37;
            this.label2.Text = "گروه :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(396, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(76, 33);
            this.label1.TabIndex = 34;
            this.label1.Text = "موجودی :";
            // 
            // Cmb_Groups
            // 
            this.Cmb_Groups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Groups.DropDownWidth = 130;
            this.Cmb_Groups.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.Cmb_Groups.FormattingEnabled = true;
            this.Cmb_Groups.Location = new System.Drawing.Point(23, 111);
            this.Cmb_Groups.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cmb_Groups.Name = "Cmb_Groups";
            this.Cmb_Groups.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cmb_Groups.Size = new System.Drawing.Size(159, 39);
            this.Cmb_Groups.Sorted = true;
            this.Cmb_Groups.TabIndex = 35;
            this.Cmb_Groups.SelectedIndexChanged += new System.EventHandler(this.Cmb_Groups_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(404, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(70, 33);
            this.label4.TabIndex = 39;
            this.label4.Text = "نام کالا :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(179, 116);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(70, 33);
            this.label3.TabIndex = 38;
            this.label3.Text = "زیرگروه :";
            // 
            // Cmb_Group
            // 
            this.Cmb_Group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_Group.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.Cmb_Group.FormattingEnabled = true;
            this.Cmb_Group.Location = new System.Drawing.Point(257, 108);
            this.Cmb_Group.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cmb_Group.Name = "Cmb_Group";
            this.Cmb_Group.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cmb_Group.Size = new System.Drawing.Size(163, 39);
            this.Cmb_Group.Sorted = true;
            this.Cmb_Group.TabIndex = 36;
            this.Cmb_Group.SelectedIndexChanged += new System.EventHandler(this.Cmb_Group_SelectedIndexChanged);
            // 
            // Cmb_Good
            // 
            this.Cmb_Good.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.Cmb_Good.FormattingEnabled = true;
            this.Cmb_Good.Location = new System.Drawing.Point(23, 11);
            this.Cmb_Good.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cmb_Good.Name = "Cmb_Good";
            this.Cmb_Good.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Cmb_Good.Size = new System.Drawing.Size(373, 39);
            this.Cmb_Good.Sorted = true;
            this.Cmb_Good.TabIndex = 42;
            this.Cmb_Good.SelectedIndexChanged += new System.EventHandler(this.Cmb_Good_SelectedIndexChanged);
            this.Cmb_Good.TextChanged += new System.EventHandler(this.Cmb_Good_TextChanged);
            // 
            // Btn_Apply
            // 
            this.Btn_Apply.BackgroundImage = global::Exir.Properties.Resources._018_shopping_bag;
            this.Btn_Apply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Apply.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Apply.ForeColor = System.Drawing.SystemColors.Control;
            this.Btn_Apply.Location = new System.Drawing.Point(43, 169);
            this.Btn_Apply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Apply.Name = "Btn_Apply";
            this.Btn_Apply.Size = new System.Drawing.Size(164, 97);
            this.Btn_Apply.TabIndex = 41;
            this.Btn_Apply.UseVisualStyleBackColor = true;
            this.Btn_Apply.Click += new System.EventHandler(this.Btn_Apply_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackgroundImage = global::Exir.Properties.Resources._023_online_shopping;
            this.Btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cancel.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Cancel.ForeColor = System.Drawing.SystemColors.Control;
            this.Btn_Cancel.Location = new System.Drawing.Point(288, 169);
            this.Btn_Cancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(164, 97);
            this.Btn_Cancel.TabIndex = 40;
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click);
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
            // Edit_Good
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 274);
            this.Controls.Add(this.Cmb_Good);
            this.Controls.Add(this.Btn_Apply);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Num_Stock);
            this.Controls.Add(this.Txt_Price);
            this.Controls.Add(this.Cmb_Group);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cmb_Groups);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(503, 274);
            this.MinimumSize = new System.Drawing.Size(503, 274);
            this.Name = "Edit_Good";
            this.Text = "Edit_Good";
            ((System.ComponentModel.ISupportInitialize)(this.Num_Stock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Price)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadSpinEditor Num_Stock;
        private Telerik.WinControls.UI.RadTextBox Txt_Price;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Cmb_Groups;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Btn_Apply;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.ComboBox Cmb_Group;
        private System.Windows.Forms.ComboBox Cmb_Good;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier2;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Telerik.WinControls.Themes.FluentTheme fluentTheme1;
    }
}