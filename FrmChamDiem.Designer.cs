namespace QLDoAnSV
{
    partial class FrmChamDiem
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMaDeTai = new System.Windows.Forms.ComboBox();
            this.cbomssv = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiem = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtDiem);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbomssv);
            this.groupBox1.Controls.Add(this.cboMaDeTai);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(657, 231);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chấm điểm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã đề tài:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "MSSV:";
            // 
            // cboMaDeTai
            // 
            this.cboMaDeTai.FormattingEnabled = true;
            this.cboMaDeTai.Location = new System.Drawing.Point(110, 41);
            this.cboMaDeTai.Name = "cboMaDeTai";
            this.cboMaDeTai.Size = new System.Drawing.Size(121, 33);
            this.cboMaDeTai.TabIndex = 2;
            this.cboMaDeTai.SelectedIndexChanged += new System.EventHandler(this.cboMaDeTai_SelectedIndexChanged);
            // 
            // cbomssv
            // 
            this.cbomssv.FormattingEnabled = true;
            this.cbomssv.Location = new System.Drawing.Point(430, 38);
            this.cbomssv.Name = "cbomssv";
            this.cbomssv.Size = new System.Drawing.Size(121, 33);
            this.cbomssv.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Điểm:";
            // 
            // txtDiem
            // 
            this.txtDiem.Location = new System.Drawing.Point(110, 108);
            this.txtDiem.Name = "txtDiem";
            this.txtDiem.Size = new System.Drawing.Size(121, 30);
            this.txtDiem.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(46, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "Xác nhận";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmChamDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmChamDiem";
            this.Text = "FrmChamDiem";
            this.Load += new System.EventHandler(this.FrmChamDiem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDiem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbomssv;
        private System.Windows.Forms.ComboBox cboMaDeTai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}