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
    public partial class dangThongbao : Form
    {
        SqlConnection conn;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable tb = new DataTable();
        SqlCommand com;
        public dangThongbao()
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
            com.CommandText = "SELECT * FROM ThongBao";
            com.ExecuteNonQuery();
            ad.SelectCommand = com;
            ad.Fill(tb);
            dataGridView1.DataSource = tb;
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

        public void Clear()
        {
            txtNoiDung.Clear();
            txtTieuDe.Clear();
            cboMaGV.Items.Clear();
        }

        private void dangThongbao_Load(object sender, EventArgs e)
        {
            Hienthi();
            Clear();
            LoadMaGV();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string ngay = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            string insertString;
            insertString = "insert into ThongBao values(N'" + txtTieuDe.Text + "', N'" + txtNoiDung.Text + "', '" + ngay + "', '" + cboMaGV.Text + "')";
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            //Xac dinh chuoi truy van
            string deleteString;
            deleteString = "delete from ThongBao where tieude = '" + txtTieuDe.Text + "' ";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTieuDe.ReadOnly = true;
            txtNoiDung.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtTieuDe.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtNoiDung.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            cboMaGV.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
        }
    }
}
