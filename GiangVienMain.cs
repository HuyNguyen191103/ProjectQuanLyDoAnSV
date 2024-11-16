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
    public partial class GiangVienMain : Form
    {
        SqlConnection conn;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable tb = new DataTable();
        SqlCommand com;
        SqlDataAdapter ad2 = new SqlDataAdapter();
        DataTable tb2 = new DataTable();
        SqlCommand com2;
        public GiangVienMain()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=LAPTOP-IK9U00KH\\TEST2;Initial Catalog =QLDETAI; Integrated Security = True");
        }

        public void Hienthi2()
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            tb2.Clear();
            com2 = conn.CreateCommand();
            com2.CommandText = "SELECT * FROM ChiTietDeTai";
            com2.ExecuteNonQuery();
            ad2.SelectCommand = com2;
            ad2.Fill(tb2);
            dataGridView1.DataSource = tb2;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Uploaddetai uploaddetai = new Uploaddetai();
            uploaddetai.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dangThongbao dangThongbao = new dangThongbao();
            dangThongbao.ShowDialog();
        }

        private void GiangVienMain_Load(object sender, EventArgs e)
        {
            Hienthi2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmHoiDong frmHoiDong = new FrmHoiDong();
            frmHoiDong.ShowDialog();
        }
    }
}
