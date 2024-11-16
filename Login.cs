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
    public partial class Login : Form
    {
        SqlConnection conn;
        public Login()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=LAPTOP-IK9U00KH\\TEST2;Initial Catalog =QLDETAI; Integrated Security = True");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Display a confirmation dialog
            DialogResult result = MessageBox.Show("Bạn có muốn thoát ứng dụng?", "Xác nhận thoát", MessageBoxButtons.YesNo);

            // Check if the user clicked "Yes"
            if (result == DialogResult.Yes)
            {
                this.Close(); // Close the application if "Yes" is clicked
            }
        }
        private void txtSdt_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.FromArgb(41, 128, 158);
            }
        }
        private void TxtSdt_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = Color.FromArgb(41, 128, 158);
            }
        }

        private void TxtMK_enter(object sender, EventArgs e)
        {
            if (txtMK.Text == "Mật khẩu")
            {
                txtMK.Text = "";
                txtMK.ForeColor = Color.FromArgb(41, 128, 158);
                txtMK.UseSystemPasswordChar = true;
            }
        }
        private void TxtMK_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMK.Text))
            {
                txtMK.Text = "Mật khẩu";
                txtMK.ForeColor = Color.FromArgb(41, 128, 158);
                txtMK.UseSystemPasswordChar = false;
            }
        }

        private void txtMK_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btnDangnhap_click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string pass = txtMK.Text;
            //Kiem tra ket noi truoc khi mo
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if(rdoAdmin.Checked)
            {
                string query = "SELECT COUNT(*) FROM Admin WHERE email = @email AND password = @pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    // Thực thi truy vấn và kiểm tra kết quả
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        Admin frm = new Admin();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại hoặc mật khẩu không đúng!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            } else if (rdoGV.Checked)
            {
                string query = "SELECT COUNT(*) FROM GiangVien WHERE email = @email AND pass = @pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                try
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    // Thực thi truy vấn và kiểm tra kết quả
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Đăng nhập thành công!");
                        GiangVienMain frm = new GiangVienMain();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Số điện thoại hoặc mật khẩu không đúng!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            } else if(rdoSV.Checked)
            {
                string query = @"
                                    SELECT SV.*, CTDT.madetai
                                    FROM SinhVien SV
                                    LEFT JOIN ChiTietDeTai CTDT ON SV.mssv = CTDT.mssv
                                    WHERE SV.email = @Email AND SV.pass = @Pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                
                try
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    // Thực thi truy vấn và kiểm tra kết quả
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Đăng nhập thành công, tạo đối tượng sinh viên và lưu thông tin
                        UserSinhVien userSinhVien = new UserSinhVien
                        {
                            mssv = reader["mssv"].ToString(),
                            maNganh = reader["manganh"].ToString(),
                            hoTen = reader["hoten"].ToString(),
                            sdt = reader["sdt"].ToString(),
                            email = reader["email"].ToString(),
                            ngaysinh = DateTime.Parse(reader["ngaysinh"].ToString()),
                            diaChi = reader["diachi"].ToString(),
                            cccd = reader["cmnd"].ToString(),
                            linkAnh = reader["anhdaidien"].ToString(),
                            Madetai = reader["madetai"]?.ToString() ?? "Không có đề tài"
                        };
                        reader.Close();
                        

                        Sinhvien frm = new Sinhvien(userSinhVien);
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Email hoặc mật khẩu không đúng!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui long chon vai tro dang nhap");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
    

