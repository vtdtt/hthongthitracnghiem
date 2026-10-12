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


namespace _5
{
    public partial class dangky : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=login_system;Integrated Security=True";
        public dangky()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dangky_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button1;
            cangiua();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void cangiua()
        { 
            panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string email = textBox1.Text.Trim();
            string taikhoan = textBox2.Text.Trim();
            string matkhau = textBox3.Text;
            string nhaplaimatkhau = textBox4.Text;
            if (email == "" || taikhoan == "" || matkhau == "" || nhaplaimatkhau == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            if (matkhau != nhaplaimatkhau)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO users(email,username,password_hash)
                                VALUES (@email, @username, @password_hash)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@username", taikhoan);
                    string passwordHash = BCrypt.Net.BCrypt.HashPassword(matkhau);
                    cmd.Parameters.AddWithValue("@password_hash", passwordHash);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đăng ký thành công");
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == 2627)
                        {
                            MessageBox.Show("Tài khoản đã tồn tại");
                        }
                        else
                        {
                            MessageBox.Show("Lỗi khi đăng ký: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dangnhap f = new dangnhap();
            f.Show();
            f.Location = this.Location;
            f.Size = this.Size;
            this.Hide();
        }

        private void dangky_SizeChanged(object sender, EventArgs e)
        {
            cangiua();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?",
               "Xác nhận",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
