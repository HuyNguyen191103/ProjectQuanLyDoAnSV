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
    public partial class Frmdangkychuyennganh : Form
    {
        SqlConnection conn;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable tb = new DataTable();
        SqlCommand com;
        public Frmdangkychuyennganh()
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
            com.CommandText = "SELECT * FROM ChuyenNganh";
            com.ExecuteNonQuery();
            ad.SelectCommand = com;
            ad.Fill(tb);
            dataGridView1.DataSource = tb;
        }

        public void Clear()
        {
            txtma.Clear();
            txtten.Clear();
        }

        private void Frmdangkychuyennganh_Load(object sender, EventArgs e)
        {
            Hienthi();
            Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string insertString;
            insertString = "insert into ChuyenNganh values(N'" + txtma.Text + "',N'" + txtten.Text + "')";
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

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtma.ReadOnly = true;
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //Xac dinh chuoi truy van
            string updateString;
            updateString = "update ChuyenNganh set tennganh =N'" + txtten.Text + "' where manganh = '"+ txtma.Text+ "'";
            //Khai bao commamnd moi
            SqlCommand cmd = new SqlCommand(updateString, conn);
            //Goi ExecuteNonQuery de gui command
            try
            {
                cmd.ExecuteNonQuery();
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //Xac dinh chuoi truy van
            string deleteString;
            deleteString = "delete from ChuyenNganh where manganh = '" + txtma.Text + "' ";
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
            insertSearch = "SELECT * FROM ChuyenNganh WHERE manganh LIKE @keyword";
            SqlCommand cmd = new SqlCommand(insertSearch, conn);
            cmd.Parameters.AddWithValue("@keyword", "%" + txtma.Text + "%");
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
            txtma.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtma.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtten.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
        }
    }
}
