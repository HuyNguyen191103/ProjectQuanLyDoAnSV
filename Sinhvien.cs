using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDoAnSV
{
    public partial class Sinhvien : Form
    {
        private UserSinhVien sv;

        SqlConnection conn;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable tb = new DataTable();
        SqlCommand com;
        public Sinhvien(UserSinhVien userSinhVien)
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=LAPTOP-IK9U00KH\\TEST2;Initial Catalog =QLDETAI; Integrated Security = True");
            sv = userSinhVien;

        }

        private void Sinhvien_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            txtcccd.ReadOnly = true;
            txtdiachi.ReadOnly = true;
            txtemail.ReadOnly = true;
            txthoten.ReadOnly = true;
            txtmanganh.ReadOnly = true;
            txtmssv.ReadOnly = true;
            txtngaysinh.ReadOnly = true;
            txtsdt.ReadOnly = true;
            txtDeTai.ReadOnly = true;

            // gán thông tin
            txtcccd.Text = sv.cccd;
            txtdiachi.Text = sv.diaChi;
            txtemail.Text = sv.diaChi;
            txthoten.Text = sv.hoTen;
            txtmanganh.Text = sv.maNganh;
            txtmssv.Text = sv.mssv;
            txtsdt.Text = sv.sdt;
            txtngaysinh.Text =  sv.ngaysinh.ToString("dd/MM/yyyy");
            txtDeTai.Text = sv.Madetai;

            // kiểm tra và gán ảnh vào
            if (!string.IsNullOrEmpty(sv.linkAnh) && System.IO.File.Exists(sv.linkAnh))
            {
                pictureBox1.Image = Image.FromFile(sv.linkAnh);
            }
            else
            {
                pictureBox1.Image = null; // Để PictureBox trống nếu không có ảnh
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            groupBox2.BringToFront();  // Đảm bảo groupBox2 ở trên cùng
            groupBox1.SendToBack();    // Đảm bảo groupBox1 ở phía dưới
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            
            groupBox2.BringToFront();// Đảm bảo groupBox2 hiển thị lên trên cùng
            this.Refresh();

            ////Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            tb.Clear();
            com = conn.CreateCommand();
            com.CommandText = "SELECT * FROM ThongBao";
            com.ExecuteNonQuery();
            ad.SelectCommand = com;
            ad.Fill(tb);
            dataGridView1.DataSource = tb;
            //Kiem tra ket noi truoc khi dong
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            groupBox1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDangKyDeTai frmDangKyDeTai = new FrmDangKyDeTai();
            frmDangKyDeTai.ShowDialog();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmUpBaoCao frmUpBaoCao = new FrmUpBaoCao();
            frmUpBaoCao.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
