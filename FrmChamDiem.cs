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
    public partial class FrmChamDiem : Form
    {
        SqlConnection conn;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable tb = new DataTable();
        SqlCommand com;
        public FrmChamDiem()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=LAPTOP-IK9U00KH\\TEST2;Initial Catalog =QLDETAI; Integrated Security = True");
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

        private void FrmChamDiem_Load(object sender, EventArgs e)
        {
            LoadMaDeTai();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            int diem = int.Parse(txtDiem.Text);
            //Xac dinh chuoi truy van
            string updateString;
            updateString = "Update ChiTietDeTai set Diem = " +txtDiem.Text+ " WHERE mssv = '" + cbomssv.Text + "' ";
            // Khai bao commamnd moi

            SqlCommand cmd = new SqlCommand(updateString, conn);
            //Goi ExecuteNonQuery de gui command
            try
            {
                cmd.ExecuteNonQuery();
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
                MessageBox.Show("That bai");
            }
        }

        private void cboMaDeTai_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra kết nối trước khi mở
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                // Lấy giá trị được chọn trong comboBox cboMaDeTai
                string selectedMaDeTai = cboMaDeTai.SelectedItem.ToString();

                // Câu truy vấn lấy danh sách mssv theo madetai
                string query = "SELECT mssv FROM ChiTietDeTai WHERE madetai = @madetai";

                // Tạo SqlCommand và thêm tham số
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@madetai", selectedMaDeTai);

                // Tạo SqlDataAdapter để lấy dữ liệu
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);

                // Xóa các mục cũ trong comboBox cbomssv
                cbomssv.Items.Clear();

                // Thêm các mssv mới vào comboBox cbomssv
                foreach (DataRow row in dt.Rows)
                {
                    cbomssv.Items.Add(row["mssv"].ToString());
                }

                // Đặt mục đầu tiên là mục được chọn (nếu có)
                if (cbomssv.Items.Count > 0)
                {
                    cbomssv.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đóng kết nối
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
    }
}
