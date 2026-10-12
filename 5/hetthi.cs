using _5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace _5_csproj
{
    public partial class hetthi : Form
    {
        public hetthi()
        {
            InitializeComponent();
            
        }
        private void Form2_load(object sender, EventArgs e)
        {
            
        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            f.Location = this.Location;
            f.Size = this.Size;
            this.Hide();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            dangnhap f = new dangnhap();
            f.Show();
            f.Location = this.Location;
            f.Size = this.Size;
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;  
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            trang1 f = new trang1(1); 
            f.Show();
            f.Location = this.Location;
            f.Size = this.Size;
            this.Hide();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            creative f = new creative();
            f.Show();
            f.Location = this.Location;
            f.Size = this.Size;
            this.Hide();
        }

        private void hetthi_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            trang1 f = new trang1(2);
            f.Show();
            f.Location = this.Location;
            f.Size = this.Size;
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            trang1 f = new trang1(3);
            f.Show();
            f.Location = this.Location;
            f.Size = this.Size;
            this.Hide();
        }
    }
}
