namespace Exir.Forms
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pnl_View = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pic_Close = new System.Windows.Forms.PictureBox();
            this.pic_Minimize = new System.Windows.Forms.PictureBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pnl_View.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Minimize)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_View
            // 
            this.pnl_View.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(100)))), ((int)(((byte)(141)))));
            this.pnl_View.Controls.Add(this.label1);
            this.pnl_View.Location = new System.Drawing.Point(46, 26);
            this.pnl_View.Name = "pnl_View";
            this.pnl_View.Size = new System.Drawing.Size(593, 485);
            this.pnl_View.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Shabnam", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(235, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "محل پنل ها";
            this.label1.Visible = false;
            // 
            // pic_Close
            // 
            this.pic_Close.BackColor = System.Drawing.Color.Transparent;
            this.pic_Close.BackgroundImage = global::Exir.Properties.Resources.Close_Blue;
            this.pic_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_Close.Location = new System.Drawing.Point(964, 26);
            this.pic_Close.Name = "pic_Close";
            this.pic_Close.Size = new System.Drawing.Size(30, 30);
            this.pic_Close.TabIndex = 18;
            this.pic_Close.TabStop = false;
            this.pic_Close.Click += new System.EventHandler(this.pic_Close_Click);
            this.pic_Close.MouseEnter += new System.EventHandler(this.pic_Close_MouseEnter);
            this.pic_Close.MouseLeave += new System.EventHandler(this.pic_Close_MouseLeave);
            // 
            // pic_Minimize
            // 
            this.pic_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.pic_Minimize.BackgroundImage = global::Exir.Properties.Resources.Minimize_Blue;
            this.pic_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_Minimize.Location = new System.Drawing.Point(928, 26);
            this.pic_Minimize.Name = "pic_Minimize";
            this.pic_Minimize.Size = new System.Drawing.Size(30, 30);
            this.pic_Minimize.TabIndex = 17;
            this.pic_Minimize.TabStop = false;
            this.pic_Minimize.Click += new System.EventHandler(this.pic_Minimize_Click);
            this.pic_Minimize.MouseEnter += new System.EventHandler(this.pic_Minimize_MouseEnter);
            this.pic_Minimize.MouseLeave += new System.EventHandler(this.pic_Minimize_MouseLeave);
            // 
            // linkLabel3
            // 
            this.linkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(61)))));
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Font = new System.Drawing.Font("Shabnam", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel3.Location = new System.Drawing.Point(12, 557);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.linkLabel3.Size = new System.Drawing.Size(239, 28);
            this.linkLabel3.TabIndex = 16;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "نام کاربری را فراموش کردید؟!";
            this.linkLabel3.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(61)))));
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(61)))));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Shabnam", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel2.Location = new System.Drawing.Point(281, 557);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.linkLabel2.Size = new System.Drawing.Size(222, 28);
            this.linkLabel2.TabIndex = 15;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "رمز عبور را فراموش کردید؟!";
            this.linkLabel2.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(61)))));
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(61)))));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Shabnam", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.linkLabel1.Location = new System.Drawing.Point(540, 557);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.linkLabel1.Size = new System.Drawing.Size(126, 28);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "ثبت نام کنید!";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(48)))), ((int)(((byte)(61)))));
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1023, 646);
            this.Controls.Add(this.pnl_View);
            this.Controls.Add(this.pic_Close);
            this.Controls.Add(this.pic_Minimize);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.pnl_View.ResumeLayout(false);
            this.pnl_View.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Minimize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel pnl_View;
        private Label label1;
        private PictureBox pic_Close;
        private PictureBox pic_Minimize;
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel2;
        private LinkLabel linkLabel1;
    }
}