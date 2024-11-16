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
    public partial class Uploaddetai : Form
    {
        SqlConnection conn;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable tb = new DataTable();
        SqlCommand com;
        public Uploaddetai()
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
        }

        public void Clear()
        {
            txtMadetai.Clear();
            txtMieuTa.Clear();
            txtTen.Clear();
            txtTenGV.Clear();
            cboMaGV.Items.Clear();

        }

        public void LoadMaGV()
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "SELECT DISTINCT magv FROM GiangVien";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cboMaGV.Items.Add(reader["magv"].ToString());
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Uploaddetai_Load(object sender, EventArgs e)
        {
            Hienthi();
            Clear();
            LoadMaGV();

        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string ngaybatdau = dtpNgayBatDau.Value.ToString("yyyy/MM/dd");
            string ngayketthuc = dtpNgayKetThuc.Value.ToString("yyyy/MM/dd");
            string insertString;
            insertString = "insert into DeTai values('" + txtMadetai.Text + "', '" + cboMaGV.Text + "', N'" + txtTen.Text + "', N'" + txtMieuTa.Text + "', '" + ngaybatdau + "', '" + ngayketthuc + "')";
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

        private void cboMaGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedID = cboMaGV.SelectedItem.ToString();
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "SELECT tengv FROM GiangVien WHERE magv = @IDGiangVien";
            com = new SqlCommand(query, conn);
            com.Parameters.AddWithValue("IDGiangVien", selectedID);
            SqlDataReader reader2 = com.ExecuteReader();
            if (reader2.Read())
            {
                txtTenGV.Text = reader2["tengv"].ToString();
            }
            reader2.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
            deleteString = "delete from DeTai where madetai = '" + txtMadetai.Text + "' ";
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
            insertSearch = "SELECT * FROM DeTai WHERE madetai LIKE @keyword";
            SqlCommand cmd = new SqlCommand(insertSearch, conn);
            cmd.Parameters.AddWithValue("@keyword", "%" + txtMadetai.Text + "%");
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMadetai.ReadOnly = true;
            cboMaGV.DroppedDown = true;
            txtTenGV.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMadetai.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            cboMaGV.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtTen.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtMieuTa.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            dtpNgayBatDau.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            dtpNgayKetThuc.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }
    }
}
