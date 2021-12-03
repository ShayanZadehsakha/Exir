namespace Exir
{
    partial class Cash_Desk
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.Txt_Cash_Desk = new Telerik.WinControls.UI.RadTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Dgb_Cash_Desk = new Telerik.WinControls.UI.RadGridView();
            this.Btn_Apply = new System.Windows.Forms.Button();
            this.Btn_Remove = new System.Windows.Forms.Button();
            this.popupNotifier1 = new Tulpep.NotificationWindow.PopupNotifier();
            this.popupNotifier2 = new Tulpep.NotificationWindow.PopupNotifier();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Cash_Desk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgb_Cash_Desk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgb_Cash_Desk.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Txt_Cash_Desk
            // 
            this.Txt_Cash_Desk.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Cash_Desk.Location = new System.Drawing.Point(12, 12);
            this.Txt_Cash_Desk.Name = "Txt_Cash_Desk";
            this.Txt_Cash_Desk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Txt_Cash_Desk.Size = new System.Drawing.Size(511, 35);
            this.Txt_Cash_Desk.TabIndex = 76;
            this.Txt_Cash_Desk.ThemeName = "Fluent";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("IRRoya", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(530, 17);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(75, 26);
            this.label2.TabIndex = 77;
            this.label2.Text = "نام صندوق :";
            // 
            // Dgb_Cash_Desk
            // 
            this.Dgb_Cash_Desk.AutoScroll = true;
            this.Dgb_Cash_Desk.BackColor = System.Drawing.Color.White;
            this.Dgb_Cash_Desk.Location = new System.Drawing.Point(12, 62);
            // 
            // 
            // 
            this.Dgb_Cash_Desk.MasterTemplate.AllowAddNewRow = false;
            this.Dgb_Cash_Desk.MasterTemplate.AllowCellContextMenu = false;
            this.Dgb_Cash_Desk.MasterTemplate.AllowDeleteRow = false;
            this.Dgb_Cash_Desk.MasterTemplate.AllowDragToGroup = false;
            this.Dgb_Cash_Desk.MasterTemplate.AllowEditRow = false;
            this.Dgb_Cash_Desk.MasterTemplate.AllowRowResize = false;
            this.Dgb_Cash_Desk.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.HeaderText = "نام صندوق";
            gridViewTextBoxColumn1.Name = "Group_Name";
            gridViewTextBoxColumn1.Width = 593;
            this.Dgb_Cash_Desk.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
            this.Dgb_Cash_Desk.MasterTemplate.ShowRowHeaderColumn = false;
            this.Dgb_Cash_Desk.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.Dgb_Cash_Desk.Name = "Dgb_Cash_Desk";
            this.Dgb_Cash_Desk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Dgb_Cash_Desk.ShowGroupPanel = false;
            this.Dgb_Cash_Desk.Size = new System.Drawing.Size(595, 340);
            this.Dgb_Cash_Desk.TabIndex = 78;
            this.Dgb_Cash_Desk.ThemeName = "Fluent";
            this.Dgb_Cash_Desk.SelectionChanged += new System.EventHandler(this.Dgb_Cash_Desk_SelectionChanged);
            // 
            // Btn_Apply
            // 
            this.Btn_Apply.BackColor = System.Drawing.Color.LightGray;
            this.Btn_Apply.BackgroundImage = global::Exir.Properties.Resources._026_approved;
            this.Btn_Apply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Apply.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Apply.ForeColor = System.Drawing.Color.LightGray;
            this.Btn_Apply.Location = new System.Drawing.Point(333, 410);
            this.Btn_Apply.Name = "Btn_Apply";
            this.Btn_Apply.Size = new System.Drawing.Size(96, 63);
            this.Btn_Apply.TabIndex = 79;
            this.Btn_Apply.UseVisualStyleBackColor = false;
            this.Btn_Apply.Click += new System.EventHandler(this.Btn_Apply_Click);
            // 
            // Btn_Remove
            // 
            this.Btn_Remove.BackColor = System.Drawing.Color.LightGray;
            this.Btn_Remove.BackgroundImage = global::Exir.Properties.Resources._024_rejected;
            this.Btn_Remove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Remove.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Remove.ForeColor = System.Drawing.Color.LightGray;
            this.Btn_Remove.Location = new System.Drawing.Point(170, 410);
            this.Btn_Remove.Name = "Btn_Remove";
            this.Btn_Remove.Size = new System.Drawing.Size(96, 63);
            this.Btn_Remove.TabIndex = 80;
            this.Btn_Remove.UseVisualStyleBackColor = false;
            this.Btn_Remove.Click += new System.EventHandler(this.Btn_Remove_Click);
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
            // Cash_Desk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(619, 485);
            this.Controls.Add(this.Btn_Remove);
            this.Controls.Add(this.Btn_Apply);
            this.Controls.Add(this.Dgb_Cash_Desk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_Cash_Desk);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(627, 518);
            this.MinimumSize = new System.Drawing.Size(627, 518);
            this.Name = "Cash_Desk";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.RootElement.MaxSize = new System.Drawing.Size(627, 518);
            this.ShowIcon = false;
            this.Text = "";
            this.ThemeName = "Fluent";
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Cash_Desk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgb_Cash_Desk.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dgb_Cash_Desk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox Txt_Cash_Desk;
        private System.Windows.Forms.Label label2;
        private Telerik.WinControls.UI.RadGridView Dgb_Cash_Desk;
        private System.Windows.Forms.Button Btn_Apply;
        private System.Windows.Forms.Button Btn_Remove;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier1;
        private Tulpep.NotificationWindow.PopupNotifier popupNotifier2;
    }
}