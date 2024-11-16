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
    public partial class FrmHoiDong : Form
    {
        SqlConnection conn;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable tb = new DataTable();
        SqlCommand com;
        SqlDataAdapter ad2 = new SqlDataAdapter();
        DataTable tb2 = new DataTable();
        SqlCommand com2;
        public FrmHoiDong()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=LAPTOP-IK9U00KH\\TEST2;Initial Catalog =QLDETAI; Integrated Security = True");
        }

        public void Hienthi()
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            tb.Clear();
            com = conn.CreateCommand();
            com.CommandText = "SELECT * FROM HoiDong";
            com.ExecuteNonQuery();
            ad.SelectCommand = com;
            ad.Fill(tb);
            dataGridView1.DataSource = tb;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
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
            com2.CommandText = "SELECT * FROM ChiTietHoiDong";
            com2.ExecuteNonQuery();
            ad2.SelectCommand = com2;
            ad2.Fill(tb2);
            dataGridView2.DataSource = tb2;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public void Clear()
        {
            txtMaGV.Clear();
            txtMaHoiDong.Clear();
            txtTenHoiDong.Clear();
            cboMaHoiDong.Items.Clear();
        }

        public void LoadMaHoiDong()
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "SELECT DISTINCT mahoidong FROM HoiDong";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cboMaHoiDong.Items.Add(reader["mahoidong"].ToString());
                }
                reader.Close();
                //Kiem tra ket noi truoc khi dong
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thất bại" + ex.Message);
            }
        }

        private void FrmHoiDong_Load(object sender, EventArgs e)
        {
            Clear();
            Hienthi();
            Hienthi2();
            LoadMaHoiDong();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string insertString;
            insertString = "INSERT into HoiDong values('" + txtMaHoiDong.Text + "', N'" + txtTenHoiDong.Text + "')";
            //Khai bao commamnd moi
            SqlCommand cmd = new SqlCommand(insertString, conn);
            //Goi ExecuteNonQuery de gui command
            try
            {
                cmd.ExecuteNonQuery();
                Clear();
                Hienthi();
                //Kiem tra ket noi truoc khi dong
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                //Hien thi thong bao
                MessageBox.Show("Thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai" + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //Xac dinh chuoi truy van
            string deleteString;
            deleteString = "delete from HoiDong where mahoidong = '" + txtMaHoiDong.Text + "' ";
            //Khai bao commamnd moi
            SqlCommand cmd = new SqlCommand(deleteString, conn);
            //Goi ExecuteNonQuery de gui command
            try
            {
                cmd.ExecuteNonQuery();
                Clear();
                Hienthi();
                //Kiem tra ket noi truoc khi dong
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                //Hien thi thong bao
                MessageBox.Show("Thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai, " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string insertSearch;
            insertSearch = "SELECT * FROM HoiDong WHERE mahoidong LIKE @keyword";
            SqlCommand cmd = new SqlCommand(insertSearch, conn);
            cmd.Parameters.AddWithValue("@keyword", "%" + txtMaHoiDong.Text + "%");
            //Goi ExecuteNonQuery de gui command
            try
            {
                ad = new SqlDataAdapter(cmd);
                tb = new DataTable();
                ad.Fill(tb);
                dataGridView1.DataSource = tb;
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai, " + ex.Message);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string insertString;
            insertString = "INSERT into ChiTietHoiDong values('" + txtMaGV.Text + "', N'" + cboMaHoiDong.Text + "')";
            //Khai bao commamnd moi
            SqlCommand cmd = new SqlCommand(insertString, conn);
            //Goi ExecuteNonQuery de gui command
            try
            {
                cmd.ExecuteNonQuery();
                Clear();
                Hienthi();
                //Kiem tra ket noi truoc khi dong
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                //Hien thi thong bao
                MessageBox.Show("Thanh cong");
            }
            catch (Exception ex)
            {
                MessageBox.Show("That bai" + ex.Message);
            }
        }
    }
}
