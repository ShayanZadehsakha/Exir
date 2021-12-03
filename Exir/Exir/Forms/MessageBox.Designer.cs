namespace Exir.Forms
{
    partial class MessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageBox));
            this.btn_Accept = new System.Windows.Forms.Button();
            this.btn_Refuse = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Accept
            // 
            this.btn_Accept.BackColor = System.Drawing.Color.White;
            this.btn_Accept.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Accept.BackgroundImage")));
            this.btn_Accept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Accept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Accept.ForeColor = System.Drawing.Color.White;
            this.btn_Accept.Location = new System.Drawing.Point(431, 109);
            this.btn_Accept.Name = "btn_Accept";
            this.btn_Accept.Size = new System.Drawing.Size(69, 63);
            this.btn_Accept.TabIndex = 11;
            this.btn_Accept.UseVisualStyleBackColor = false;
            this.btn_Accept.Click += new System.EventHandler(this.btn_Accept_Click);
            // 
            // btn_Refuse
            // 
            this.btn_Refuse.BackColor = System.Drawing.Color.White;
            this.btn_Refuse.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Refuse.BackgroundImage")));
            this.btn_Refuse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Refuse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Refuse.ForeColor = System.Drawing.Color.White;
            this.btn_Refuse.Location = new System.Drawing.Point(220, 109);
            this.btn_Refuse.Name = "btn_Refuse";
            this.btn_Refuse.Size = new System.Drawing.Size(69, 63);
            this.btn_Refuse.TabIndex = 12;
            this.btn_Refuse.UseVisualStyleBackColor = false;
            this.btn_Refuse.Click += new System.EventHandler(this.btn_Refuse_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Shabnam", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(17, 14);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(712, 28);
            this.label2.TabIndex = 9;
            this.label2.Text = "با انتخاب \"مرا بخاطر بسپار\" برای ورود به حساب شما نیازی به نام کاربری و رمز عبور " +
    "نیست";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Shabnam Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(174, 62);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(389, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "در تنطیمات حساب کاربری خود می توانید آن را غیرفعال کنید";
            // 
            // MessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(746, 182);
            this.Controls.Add(this.btn_Accept);
            this.Controls.Add(this.btn_Refuse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageBox";
            this.Text = "MessageBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_Accept;
        private Button btn_Refuse;
        public Label label2;
        public Label label1;
    }
}