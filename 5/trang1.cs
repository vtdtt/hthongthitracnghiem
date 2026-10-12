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
    public partial class trang1 : Form
    {
        string connectionString = @"Data Source=localhost;Initial Catalog=htthi;Integrated Security=True";
        int MonId;
        DataTable dt = new DataTable();
        int idx = 0;
        string[] dapAnChon;
        private System.Windows.Forms.Timer timerlambai;
        public trang1(int MonId)
        {
            InitializeComponent();
            this.MonId = MonId;
            timerlambai = new System.Windows.Forms.Timer();
            timerlambai.Interval = 1000;
            timerlambai.Tick += Timerlambai_Tick;
            this.FormClosed += (s, e) => timerlambai.Dispose();
        }
        private void capnhatdongho()
        {
            TimeSpan conlai = baithi.thoigianketthuc - DateTime.Now;
            if (conlai <= TimeSpan.Zero)
            {
                timerlambai.Stop();
                luuDapAn();
                MessageBox.Show("Hết thời gian làm bài! Bài thi sẽ được nộp tự động.");
                baithi.nopbai();
                this.Close();
            }
            else
            {
                label3.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", conlai.Hours, conlai.Minutes, conlai.Seconds);
            }
        }

        private void Timerlambai_Tick(object sender, EventArgs e)
        {
            if (!this.Visible) return;
            if (DateTime.Now >= baithi.thoigianketthuc)
            {
                timerlambai.Stop();
                luuDapAn();
                MessageBox.Show("Hết thời gian làm bài! Bài thi sẽ được nộp tự động.");
                baithi.nopbai();
                this.Close();
            }
            else
            {
                capnhatdongho();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            luuDapAn();
            if(idx > 0)
            {
                HienCau(idx-1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            luuDapAn();

            if (baithi.danop)
            {
                MessageBox.Show("Bạn đã nộp bài rồi!");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn nộp bài không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                baithi.nopbai();
                timerlambai.Stop();
                if (baithi.danop)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;
                    radioButton3.Enabled = false;
                    radioButton4.Enabled = false;
                }
  
            }
        }
        private void luuDapAn()
        {
            if (idx < 0 || idx >= baithi.Danhsach.Count)
                return;

            string dapAn = radioButton1.Checked ? "A" :
                           radioButton2.Checked ? "B" :
                           radioButton3.Checked ? "C" :
                           radioButton4.Checked ? "D" : null;

            if (dapAn != null)
                baithi.DapAn[idx] = dapAn;
            else
                baithi.DapAn.Remove(idx);
        }
        private void trang1_Load(object sender, EventArgs e)
        {
            try
            {
                baithi.batdau(MonId);
                timerlambai.Start();
                capnhatdongho();


                MessageBox.Show(
                    "Mã môn: " + MonId +
                    "\nSố câu hỏi tải được: " + baithi.Danhsach.Count);

                if (baithi.Danhsach.Count == 0)
                {
                    MessageBox.Show("Không tải được câu hỏi từ database!");
                    return;
                }

                idx = 0;
                HienCau(idx);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải câu hỏi: " + ex.Message);
            }
        }
        private void HienCau(int index)
        {
            if (baithi.Danhsach.Count == 0)
                return;

            if (index < 0 || index >= baithi.Danhsach.Count)
                return;

            idx = index;

            cauhoi ch = baithi.Danhsach[idx];

            label2.Text = $"Câu {index + 1}: {ch.NoiDung}";
            

            radioButton1.Text = "A. " + ch.DapAnA;
            radioButton2.Text = "B. " + ch.DapAnB;
            radioButton3.Text = "C. " + ch.DapAnC;
            radioButton4.Text = "D. " + ch.DapAnD;

            // Khôi phục đáp án đã chọn
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            if (baithi.DapAn.TryGetValue(idx, out string dapAn))
            {
                radioButton1.Checked = dapAn == "A";
                radioButton2.Checked = dapAn == "B";
                radioButton3.Checked = dapAn == "C";
                radioButton4.Checked = dapAn == "D";
            }

            // Bật/tắt nút theo vị trí câu hỏi
            button1.Enabled = idx > 0;
            button2.Enabled = idx < baithi.Danhsach.Count - 1;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            luuDapAn();
            if (idx < baithi.Danhsach.Count - 1)
            {
                HienCau(idx+1);
            }   

        }

        private void trang1_Load_1(object sender, EventArgs e)
        {
            try
            {
                baithi.batdau(MonId);
                timerlambai.Start();
                capnhatdongho();

                if (baithi.Danhsach.Count == 0)
                {
                    MessageBox.Show("Không tải được câu hỏi từ database!");
                    return;
                }

                idx = 0;
                HienCau(idx);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải câu hỏi: " + ex.Message);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
    

    


    


