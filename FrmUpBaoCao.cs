using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordApp = Microsoft.Office.Interop.Word.Application;
using Word = Microsoft.Office.Interop.Word;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Win32;



namespace QLDoAnSV
{
    public partial class FrmUpBaoCao : Form
    {
        SqlConnection conn;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable tb = new DataTable();
        SqlCommand com;
        public FrmUpBaoCao()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=LAPTOP-IK9U00KH\\TEST2;Initial Catalog =QLDETAI; Integrated Security = True");
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            
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
            com.CommandText = "SELECT * FROM BaoCao";
            com.ExecuteNonQuery();
            ad.SelectCommand = com;
            ad.Fill(tb);
            dataGridView1.DataSource = tb;
        }

        public void Clear()
        {
            txtChuDe.Clear();
            txtmssv.Clear();
            txtUpload.Clear();
        }

        private void btnNopBai_Click(object sender, EventArgs e)
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            string insertString;
            insertString = "insert into BaoCao values(N'" + txtChuDe.Text + "', N'" + txtUpload.Text + "', '" + txtmssv.Text + "')";
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            string insertSearch;
            insertSearch = "SELECT * FROM BaoCao WHERE mssv LIKE @keyword";
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

        private void FrmUpBaoCao_Load(object sender, EventArgs e)
        {

        }
    }
}
