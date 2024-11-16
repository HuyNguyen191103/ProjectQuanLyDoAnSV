namespace QLDoAnSV
{
    partial class Login
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.rdoGV = new System.Windows.Forms.RadioButton();
            this.rdoSV = new System.Windows.Forms.RadioButton();
            this.rdoAdmin = new System.Windows.Forms.RadioButton();
            this.BtnDangnhap = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(128)))), ((int)(((byte)(158)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 577);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome!";
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(158)))));
            this.button1.Location = new System.Drawing.Point(815, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(355, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(441, 48);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đăng nhập tài khoản";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(288, 201);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(567, 76);
            this.panel2.TabIndex = 99;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(158)))));
            this.txtEmail.Location = new System.Drawing.Point(75, 21);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(415, 33);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.Tag = "";
            this.txtEmail.Text = "Email";
            this.txtEmail.Enter += new System.EventHandler(this.txtSdt_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.TxtSdt_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QLDoAnSV.Properties.Resources.user_icon;
            this.pictureBox1.Location = new System.Drawing.Point(18, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.txtMK);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Location = new System.Drawing.Point(288, 304);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(567, 72);
            this.panel3.TabIndex = 99;
            // 
            // txtMK
            // 
            this.txtMK.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(158)))));
            this.txtMK.Location = new System.Drawing.Point(75, 14);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(415, 33);
            this.txtMK.TabIndex = 2;
            this.txtMK.Text = "Mật khẩu";
            this.txtMK.TextChanged += new System.EventHandler(this.txtMK_TextChanged);
            this.txtMK.Enter += new System.EventHandler(this.TxtMK_enter);
            this.txtMK.Leave += new System.EventHandler(this.TxtMK_Leave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::QLDoAnSV.Properties.Resources.mbrilock_99595;
            this.pictureBox2.Location = new System.Drawing.Point(18, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 34);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // rdoGV
            // 
            this.rdoGV.AutoSize = true;
            this.rdoGV.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoGV.Location = new System.Drawing.Point(489, 397);
            this.rdoGV.Name = "rdoGV";
            this.rdoGV.Size = new System.Drawing.Size(149, 33);
            this.rdoGV.TabIndex = 4;
            this.rdoGV.TabStop = true;
            this.rdoGV.Text = "Giảng viên";
            this.rdoGV.UseVisualStyleBackColor = true;
            // 
            // rdoSV
            // 
            this.rdoSV.AutoSize = true;
            this.rdoSV.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoSV.Location = new System.Drawing.Point(670, 397);
            this.rdoSV.Name = "rdoSV";
            this.rdoSV.Size = new System.Drawing.Size(136, 33);
            this.rdoSV.TabIndex = 5;
            this.rdoSV.TabStop = true;
            this.rdoSV.Text = "Sinh Viên";
            this.rdoSV.UseVisualStyleBackColor = true;
            // 
            // rdoAdmin
            // 
            this.rdoAdmin.AutoSize = true;
            this.rdoAdmin.Font = new System.Drawing.Font("Microsoft Tai Le", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoAdmin.Location = new System.Drawing.Point(352, 397);
            this.rdoAdmin.Name = "rdoAdmin";
            this.rdoAdmin.Size = new System.Drawing.Size(106, 33);
            this.rdoAdmin.TabIndex = 3;
            this.rdoAdmin.TabStop = true;
            this.rdoAdmin.Text = "Admin";
            this.rdoAdmin.UseVisualStyleBackColor = true;
            // 
            // BtnDangnhap
            // 
            this.BtnDangnhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(158)))));
            this.BtnDangnhap.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnDangnhap.ForeColor = System.Drawing.Color.White;
            this.BtnDangnhap.Location = new System.Drawing.Point(425, 444);
            this.BtnDangnhap.Name = "BtnDangnhap";
            this.BtnDangnhap.Size = new System.Drawing.Size(281, 107);
            this.BtnDangnhap.TabIndex = 6;
            this.BtnDangnhap.Text = "Đăng nhập";
            this.BtnDangnhap.UseVisualStyleBackColor = false;
            this.BtnDangnhap.Click += new System.EventHandler(this.btnDangnhap_click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 578);
            this.Controls.Add(this.rdoAdmin);
            this.Controls.Add(this.rdoGV);
            this.Controls.Add(this.rdoSV);
            this.Controls.Add(this.BtnDangnhap);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Symbol", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.RadioButton rdoGV;
        private System.Windows.Forms.RadioButton rdoSV;
        private System.Windows.Forms.RadioButton rdoAdmin;
        private System.Windows.Forms.Button BtnDangnhap;
    }
}

