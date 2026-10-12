using _5;
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

namespace _5_csproj
{
    public partial class creative : Form
    {
        string connectionString = @"Data Source=localhost;Initial Catalog=htthi;Integrated Security=True";
        public creative()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ban co chac chan muon thoat",
               "xac nhan",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void guna2HtmlLabel9_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            string tenmon = comboBox1.SelectedValue?.ToString() ?? "";
            string MonId = textBox2.Text.Trim();
            string NoiDung = textBox3.Text.Trim();
            string DapAnA = textBox4.Text.Trim();
            string DapAnB = textBox5.Text.Trim();
            string DapAnC = textBox6.Text.Trim();
            string DapAnD = textBox7.Text.Trim();
            string DapAnDung = textBox8.Text.Trim();
            if(tenmon == "" || MonId == "" || NoiDung == "" || DapAnA == "" ||
                DapAnB == "" || DapAnC == "" || DapAnD == "" || DapAnDung == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE cauhoi SET tenmon = @tenmon, MonId = @MonId, NoiDung = @NoiDung, DapAnA = @DapAnA, DapAnB = @DapAnB, DapAnC = @DapAnC, DapAnD = @DapAnD, DapAnDung = @DapAnDung WHERE MonId = @MonId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@tenmon", tenmon);
                    cmd.Parameters.AddWithValue("@MonId", MonId);
                    cmd.Parameters.AddWithValue("@NoiDung", NoiDung);
                    cmd.Parameters.AddWithValue("@DapAnA", DapAnA);
                    cmd.Parameters.AddWithValue("@DapAnB", DapAnB);
                    cmd.Parameters.AddWithValue("@DapAnC", DapAnC);
                    cmd.Parameters.AddWithValue("@DapAnD", DapAnD);
                    cmd.Parameters.AddWithValue("@DapAnDung", DapAnDung);
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật câu hỏi thành công!");
                            LoadData();
                            Lammoi();
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật câu hỏi thất bại.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            string tenmon = comboBox1.SelectedValue?.ToString() ?? "";
            string MonId = textBox2.Text.Trim();
            string NoiDung = textBox3.Text.Trim();
            string DapAnA = textBox4.Text.Trim();
            string DapAnB = textBox5.Text.Trim();
            string DapAnC = textBox6.Text.Trim();
            string DapAnD = textBox7.Text.Trim();
            string DapAnDung = textBox8.Text.Trim();
            if ( tenmon == "" || MonId == "" || NoiDung == "" || DapAnA == "" ||
                DapAnB == "" || DapAnC == "" || DapAnD == "" || DapAnDung == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO cauhoi ( MonId, NoiDung, DapAnA, DapAnB, DapAnC, DapAnD, DapAnDung) " +
                               "VALUES ( @MonId, @NoiDung, @DapAnA, @DapAnB, @DapAnC, @DapAnD, @DapAnDung)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //cmd.Parameters.AddWithValue("@tenmon", tenmon);
                    cmd.Parameters.AddWithValue("@MonId", MonId);
                    cmd.Parameters.AddWithValue("@NoiDung", NoiDung);
                    cmd.Parameters.AddWithValue("@DapAnA", DapAnA);
                    cmd.Parameters.AddWithValue("@DapAnB", DapAnB);
                    cmd.Parameters.AddWithValue("@DapAnC", DapAnC);
                    cmd.Parameters.AddWithValue("@DapAnD", DapAnD);
                    cmd.Parameters.AddWithValue("@DapAnDung", DapAnDung);
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm câu hỏi thành công!");
                            LoadData();
                            Lammoi();
                        }
                        else
                        {
                            MessageBox.Show("Thêm câu hỏi thất bại.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sql = "SELECT monthi.tenmon, cauhoi.MonId, cauhoi.Id, cauhoi.NoiDung, cauhoi.DapAnA, cauhoi.DapAnB, cauhoi.DapAnC, cauhoi.DapAnD, cauhoi.DapAnDung FROM monthi INNER JOIN cauhoi ON monthi.Id = cauhoi.MonId";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                { 
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Columns.Clear();
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = dt;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.Columns["Id"].Visible = false;
                }
            }
        }

        private void creative_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT tenmon FROM monthi", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "tenmon";
                    comboBox1.ValueMember = "tenmon";
                    comboBox2.DataSource = dt;
                    comboBox2.DisplayMember = "tenmon";
                    comboBox2.ValueMember = "tenmon";
                }
            }
            catch (Exception ex)
            { 
                MessageBox.Show("loi " + ex.Message);
            }
        }
        private void Lammoi()
        {
            LoadData();
            comboBox1.SelectedIndex = -1;
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa câu hỏi này không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string MonId = textBox2.Text.Trim();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM cauhoi WHERE noidung = @NoiDung and MonId = @MonId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NoiDung", textBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@MonId", textBox2.Text.Trim());
                        try
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Xóa câu hỏi thành công!");
                                LoadData();
                                Lammoi();
                            }
                            else
                            {
                                MessageBox.Show("Xóa câu hỏi thất bại.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                comboBox1.Text = row.Cells["tenmon"].Value.ToString();
                textBox2.Text = row.Cells["MonId"].Value.ToString();
                textBox3.Text = row.Cells["NoiDung"].Value.ToString();
                textBox4.Text = row.Cells["DapAnA"].Value.ToString();
                textBox5.Text = row.Cells["DapAnB"].Value.ToString();
                textBox6.Text = row.Cells["DapAnC"].Value.ToString();
                textBox7.Text = row.Cells["DapAnD"].Value.ToString();
                textBox8.Text = row.Cells["DapAnDung"].Value.ToString();
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            hetthi f = new hetthi();
            f.Show();
            f.Location = this.Location;
            f.Size = this.Size;
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            f.Location = this.Location;
            f.Size = this.Size;
            this.Hide();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ban co chac chan muon thoat",
                "xac nhan",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            dangnhap f = new dangnhap();
            f.Show();
            f.Location = this.Location;
            f.Size = this.Size;
            this.Hide();
        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            string MonId = textBox1.Text.Trim();
            string tenmon = comboBox2.SelectedValue?.ToString();
            if(tenmon == "" && MonId == "")
            {
                MessageBox.Show("nhap monthi hoac MonId de tim kiem");
            }
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT monthi.tenmon, cauhoi.MonId FROM monthi INNER JOIN cauhoi ON monthi.Id = cauhoi.MonId  WHERE 1=1";
                if(tenmon != "")
                {
                    sql += " AND tenmon LIKE @tenmon";
                }
                if(MonId != "")
                {
                    sql += " AND MonId LIKE @MonId";
                }
                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if(tenmon != "")
                    {
                        cmd.Parameters.AddWithValue("@tenmon", "%" + tenmon + "%");
                    }
                    if(MonId != "")
                    {
                        cmd.Parameters.AddWithValue("@MonId", "%" + MonId + "%");
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.Columns.Clear();
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = dt;
                    dataGridView1.ReadOnly = true;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            LoadData();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();

        }

        private void guna2HtmlLabel10_Click(object sender, EventArgs e)
        {

        }
    }
}

