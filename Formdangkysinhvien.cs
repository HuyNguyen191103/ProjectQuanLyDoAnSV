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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QLDoAnSV
{
    public partial class Formdangkysinhvien : Form
    {
        SqlConnection conn;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable tb = new DataTable();
        SqlCommand com;
        public Formdangkysinhvien()
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
            com.CommandText = "SELECT * FROM SinhVien";
            com.ExecuteNonQuery();
            ad.SelectCommand = com;
            ad.Fill(tb);
            dataGridView1.DataSource = tb;
        }

        public void Clear()
        {
            txtcccd.Clear();
            txtdiachi.Clear();
            txtemail.Clear();
            txthoten.Clear();
            txtmssv.Clear();
            txtpass.Clear();
            txtPic.Clear();
            txtsdt.Clear();
            cboMaCN.Items.Clear();

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
                    cboMaCN.Items.Add(reader["manganh"].ToString());
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

      

        private void textBox1_ReadOnlyChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Bitmap(*.bmp) |*.bmp|JPEG(*.jpg) |*.jpg|GIF(*.gif) |*.gif|All files(*.*) |*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.Title = "Chọn ảnh đại diện";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                txtPic.Text = openFileDialog.FileName;
            }
        }

        private void Formdangkysinhvien_Load(object sender, EventArgs e)
        {
            Hienthi();
            Clear();
            LoadMaNganh();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string gioitinh;
            if(rdoNam.Checked)
            {
                gioitinh = "Nam";
            } else if (rdoNu.Checked)
            {
                gioitinh = "Nữ";
            } else gioitinh = "Khác";


            string ngay = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            string insertString;
            insertString = "insert into SinhVien values('" + txtmssv.Text + "', '" + cboMaCN.Text + "', N'" + txthoten.Text + "', '" + txtsdt.Text + "', '" + txtemail.Text + "', N'" + gioitinh + "', '" + ngay + "', N'" + txtdiachi.Text + "', N'" + txtPic.Text + "', '" + txtpass.Text + "', '" +txtcccd.Text+ "')";
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
            deleteString = "delete from SinhVien where mssv = '" + txtmssv.Text + "' ";
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

            // xác định giới tính
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string gioitinh;
            if (rdoNam.Checked)
            {
                gioitinh = "Nam";
            }
            else if (rdoNu.Checked)
            {
                gioitinh = "Nữ";
            }
            else gioitinh = "Khác";


            string ngay = dateTimePicker1.Value.ToString("yyyy/MM/dd");

            //Xac dinh chuoi truy van
            string updateString;
            updateString = "update SinhVien set manganh = '" + cboMaCN.Text + "', hoten = N'" + txthoten.Text + "', sdt =  '" + txtsdt.Text + "', email ='" + txtemail.Text + "', gioitinh = '" + gioitinh + "', ngaysinh = '" + ngay + "', diachi = N'" + txtdiachi.Text + "', anhdaidien = '" + txtPic.Text + "', pass = '" + txtpass.Text + "' where mssv = '" + txtmssv.Text + "' ";
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
            insertSearch = "SELECT * FROM SinhVien WHERE mssv LIKE @keyword";
            SqlCommand cmd = new SqlCommand(insertSearch, conn);
            cmd.Parameters.AddWithValue("@keyword", "%" + txtmssv.Text + "%");
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
            txtmssv.ReadOnly = true;
            txtcccd.ReadOnly = true;
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtmssv.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            cboMaCN.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txthoten.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txtsdt.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txtemail.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            string gioitinh = dataGridView1.Rows[i].Cells[5].Value.ToString();
            // Cập nhật trạng thái của RadioButton dựa trên giá trị
            if (gioitinh == "Nam")
            {
                rdoNam.Checked = true;
                rdoNu.Checked = false;
                rdoKhac.Checked = false;
            }
            else if (gioitinh == "Nữ")
            {
                rdoNam.Checked = false;
                rdoNu.Checked = true;
                rdoKhac.Checked = false;
            }
            else
            {
                rdoNam.Checked = false;
                rdoNu.Checked = false;
                rdoKhac.Checked = true;
            }

            dateTimePicker1.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txtdiachi.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            txtPic.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            pictureBox1.Image = Image.FromFile(txtPic.Text);
            txtpass.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            txtcccd.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
