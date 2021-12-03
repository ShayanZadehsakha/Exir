namespace Exir
{
    partial class Custom_MessageBox
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
            this.Lbl_Messeage = new System.Windows.Forms.Label();
            this.Btn_Apply = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Lbl_Question = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // Lbl_Messeage
            // 
            this.Lbl_Messeage.AutoSize = true;
            this.Lbl_Messeage.Dock = System.Windows.Forms.DockStyle.Right;
            this.Lbl_Messeage.Font = new System.Drawing.Font("Lalezar", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Messeage.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Lbl_Messeage.Location = new System.Drawing.Point(461, 0);
            this.Lbl_Messeage.Name = "Lbl_Messeage";
            this.Lbl_Messeage.Size = new System.Drawing.Size(65, 33);
            this.Lbl_Messeage.TabIndex = 0;
            this.Lbl_Messeage.Text = "مسیج";
            // 
            // Btn_Apply
            // 
            this.Btn_Apply.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Btn_Apply.BackgroundImage = global::Exir.Properties.Resources._026_approved;
            this.Btn_Apply.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Apply.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Apply.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Btn_Apply.Location = new System.Drawing.Point(152, 175);
            this.Btn_Apply.Name = "Btn_Apply";
            this.Btn_Apply.Size = new System.Drawing.Size(73, 57);
            this.Btn_Apply.TabIndex = 184;
            this.Btn_Apply.UseVisualStyleBackColor = false;
            this.Btn_Apply.Click += new System.EventHandler(this.Btn_Apply_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Btn_Cancel.BackgroundImage = global::Exir.Properties.Resources._024_rejected;
            this.Btn_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Cancel.Font = new System.Drawing.Font("Lalezar", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Cancel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Btn_Cancel.Location = new System.Drawing.Point(298, 175);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(73, 57);
            this.Btn_Cancel.TabIndex = 185;
            this.Btn_Cancel.UseVisualStyleBackColor = false;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Remove_Management_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-1, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 73);
            this.panel1.TabIndex = 186;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Lbl_Question);
            this.panel2.Location = new System.Drawing.Point(-1, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(528, 89);
            this.panel2.TabIndex = 187;
            // 
            // Lbl_Question
            // 
            this.Lbl_Question.AutoSize = true;
            this.Lbl_Question.Font = new System.Drawing.Font("Lalezar", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Question.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Lbl_Question.Location = new System.Drawing.Point(154, 29);
            this.Lbl_Question.Name = "Lbl_Question";
            this.Lbl_Question.Size = new System.Drawing.Size(218, 33);
            this.Lbl_Question.TabIndex = 1;
            this.Lbl_Question.Text = "آیا فاکتور را پاک می کنید ؟";
            // 
            // Custom_MessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(526, 241);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Btn_Apply);
            this.Controls.Add(this.Btn_Cancel);
            this.Controls.Add(this.Lbl_Messeage);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Custom_MessageBox";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "";
            this.ThemeName = "Fluent";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl_Messeage;
        private System.Windows.Forms.Button Btn_Apply;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Lbl_Question;
    }
}
