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
    public partial class FrmDangKyDeTai : Form
    {
        SqlConnection conn;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable tb = new DataTable();
        SqlCommand com;
        SqlDataAdapter ad2 = new SqlDataAdapter();
        DataTable tb2 = new DataTable();
        SqlCommand com2;
        public FrmDangKyDeTai()
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
            com.CommandText = "SELECT * FROM DeTai";
            com.ExecuteNonQuery();
            ad.SelectCommand = com;
            ad.Fill(tb);
            dataGridView1.DataSource = tb;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public void Hienthi2() {
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
            dataGridView2.DataSource = tb2;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public void LoadMaDeTai()
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "SELECT DISTINCT madetai FROM DeTai";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cboMaDeTai.Items.Add(reader["madetai"].ToString());
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

        public void Clear()
        {
            cboMaDeTai.Items.Clear();
            txtMaGV.Clear();
            txtmssv1.Clear();
            txtmssv2.Clear();
            txtmssv3.Clear();
        }

        private void FrmDangKyDeTai_Load(object sender, EventArgs e)
        {
            Clear();
            Hienthi();
            Hienthi2();
            LoadMaDeTai();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cboMaDeTai_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedID = cboMaDeTai.SelectedItem.ToString();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "SELECT magv FROM DeTai WHERE madetai = @IDGiangVien";
            com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("IDGiangVien", selectedID);
            SqlDataReader reader2 = com.ExecuteReader();
            if (reader2.Read())
            {
                txtMaGV.Text = reader2["magv"].ToString();
            }
            reader2.Close();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            try
            {
                // Lấy ngày tháng từ DateTimePicker
                string madetai = cboMaDeTai.Text;
                string magv = txtMaGV.Text;

                // Danh sách mã sinh viên để insert
                List<string> dsMSSV = new List<string> { txtmssv1.Text, txtmssv2.Text, txtmssv3.Text };

                // Lấy số lượng sinh viên hiện tại trong cùng mã đề tài và mã giảng viên
                string countQuery = "SELECT COUNT(mssv) FROM ChitietDeTai WHERE madetai = @madetai AND magv = @magv";
                SqlCommand countCmd = new SqlCommand(countQuery, conn);
                countCmd.Parameters.AddWithValue("@madetai", madetai);
                countCmd.Parameters.AddWithValue("@magv", magv);
                int currentCount = (int)countCmd.ExecuteScalar();

                // Kiểm tra nếu thêm số sinh viên này có vượt quá giới hạn
                if (currentCount + dsMSSV.Count > 3)
                {
                    MessageBox.Show("Đề tài này đã đủ số lượng sinh viên đăng ký (tối đa 3).");
                }
                else
                {
                    // Thực hiện insert cho từng MSSV trong danh sách
                    foreach (string mssv in dsMSSV)
                    {
                        if (!string.IsNullOrEmpty(mssv))
                        {
                            string insertQuery = "INSERT INTO ChitietDeTai (madetai, magv, mssv) VALUES (@madetai, @magv, @mssv)";
                            SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                            insertCmd.Parameters.AddWithValue("@madetai", madetai);
                            insertCmd.Parameters.AddWithValue("@magv", magv);
                            insertCmd.Parameters.AddWithValue("@mssv", mssv);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                    // Hiển thị thông báo thành công và làm mới dữ liệu hiển thị
                    Clear();
                    Hienthi2();
                    MessageBox.Show("Đăng ký thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đăng ký thất bại: " + ex.Message);
            }
            finally
            {
                // Kiểm tra kết nối trước khi đóng
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
