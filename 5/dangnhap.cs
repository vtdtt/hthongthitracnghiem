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
using _5_csproj;
using BCrypt.Net;

namespace _5
{
    public partial class dangnhap : Form
    {
        string connectionString = "Data Source=localhost;Initial Catalog=login_system;Integrated Security=True";
        public dangnhap()
        {
            InitializeComponent();
            this.Load += dangnhap_Load;
            this.SizeChanged += dangnhap_SizeChanged_1;
        }

        private void dangnhap_Load(object sender, EventArgs e)
        {
            this.ActiveControl = button1;
            cangiua();
        }

        private void cangiua()
        {
           panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
            panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
        }
      

        private void dangnhap_SizeChanged_1(object sender, EventArgs e)
        {
            cangiua();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
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
        private void dangnhap_shown(object sender, EventArgs e)
        {
            cangiua();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dangky f = new dangky();
            f.Show();
            f.Location = this.Location;
            f.Size = this.Size;
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?",
               "Xác nhận",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string taikhoan = textBox1.Text.Trim();
            string matkhau = textBox2.Text;
            if (taikhoan == "" || matkhau == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT password_hash
                    FROM users
                    WHERE username = @username
                    AND is_active = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", taikhoan);
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("Tai khoan nay khong ton tai");
                        return;
                    }
                    string passwordHash = result.ToString();
                    bool dungmatkhau = BCrypt.Net.BCrypt.Verify(matkhau, passwordHash);
                    if (dungmatkhau)
                    {
                        MessageBox.Show("Đăng nhập thành công");
                        Form1 f = new Form1();
                        f.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai mật khẩu");
                    }

                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
