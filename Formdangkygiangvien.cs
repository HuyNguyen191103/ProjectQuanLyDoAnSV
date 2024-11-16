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
    public partial class Formdangkygiangvien : Form
    {
        SqlConnection conn;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable tb = new DataTable();
        SqlCommand com;
        public Formdangkygiangvien()
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
            com.CommandText = "SELECT * FROM GiangVien";
            com.ExecuteNonQuery();
            ad.SelectCommand = com;
            ad.Fill(tb);
            dataGridView1.DataSource = tb;
        }

        public void Clear()
        {
            txtemail.Clear();
            txthoten.Clear();
            txtMaGV.Clear();
            txtpass.Clear();
            txtsdt.Clear();
            cboMaNganh.Items.Clear();
        }

        public void LoadMaNganh()
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string query = "SELECT DISTINCT manganh FROM ChuyenNganh";
            SqlCommand cmd = new SqlCommand(query, conn);
            try
            {

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cboMaNganh.Items.Add(reader["manganh"].ToString());
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

        private void label6_Click(object sender, EventArgs e)
        {
                    }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Formdangkygiangvien_Load(object sender, EventArgs e)
        {
            Hienthi();
            Clear();
            LoadMaNganh();
        }



        private void cboMaNganh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string insertString;
            insertString = "insert into GiangVien values('" + txtMaGV.Text + "',N'" + txthoten.Text + "','" + txtsdt.Text + "','" + txtemail.Text + "', '" + cboMaNganh.Text + "', '" + txtpass.Text + "')";
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
            deleteString = "delete from GiangVien where magv = '" + txtMaGV.Text + "' ";
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //Xac dinh chuoi truy van
            string updateString;
            updateString = "update GiangVien set magv ='" + txtMaGV.Text + "', tengv =N'" + txthoten.Text + "', sdt= '" + txtsdt.Text + "', email= '" + txtemail.Text + "', manganh= '" + cboMaNganh.Text + "', pass= '" + txtpass.Text + "' where magv = '" + txtMaGV.Text + "' ";
            // Khai bao commamnd moi
            SqlCommand cmd = new SqlCommand(updateString, conn);
            //Goi ExecuteNonQuery de gui command
            try
            {
                cmd.ExecuteNonQuery();
                Hienthi();
                Clear();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string insertSearch;
            insertSearch = "SELECT * FROM GiangVien WHERE tengv LIKE @keyword";
            SqlCommand cmd = new SqlCommand(insertSearch, conn);
            cmd.Parameters.AddWithValue("@keyword", "%" + txthoten.Text + "%");
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
            txtMaGV.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaGV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txthoten.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtsdt.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtemail.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            cboMaNganh.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtpass.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
