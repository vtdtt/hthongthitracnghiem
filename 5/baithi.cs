using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace _5_csproj
{
    public class cauhoi
    {
        public string Id { get; set; }
        public string MonId { get; set; }
        public string NoiDung { get; set; }
        public string DapAnA { get; set; }
        public string DapAnB { get; set; }
        public string DapAnC { get; set; }
        public string DapAnD { get; set; }
        public string DapAnDung { get; set; }
    }
    public class baithi
    {
        private const string connectionString = @"Data Source=localhost;Initial Catalog=htthi;Integrated Security=True";
        public static List<cauhoi> Danhsach = new List<cauhoi>();
        public static Dictionary<int, string> DapAn = new Dictionary<int, string>();
        public static readonly TimeSpan ThoiGianLamBai = TimeSpan.FromSeconds(10);
        public static DateTime thoigianketthuc;
        public static bool danop = false;
        public static void batdau(int MonId)
        {
            Danhsach.Clear();
            DapAn.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM cauhoi WHERE MonId = @mon order by Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mon", MonId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cauhoi ch = new cauhoi
                            {
                                Id = reader["Id"].ToString(),
                                MonId = reader["MonId"].ToString(),
                                NoiDung = reader["NoiDung"].ToString(),
                                DapAnA = reader["DapAnA"].ToString(),
                                DapAnB = reader["DapAnB"].ToString(),
                                DapAnC = reader["DapAnC"].ToString(),
                                DapAnD = reader["DapAnD"].ToString(),
                                DapAnDung = reader["DapAnDung"].ToString()
                            };
                            Danhsach.Add(ch);
                        }
                    }
                }
            }
            danop = false;
            thoigianketthuc = DateTime.Now.Add(ThoiGianLamBai);

        }
        public static void nopbai()
        {
            if (danop) return;
            danop = true;
            int tong = Danhsach.Count;
            int dung = 0;
            int chualam = 0;
            for(int i = 0; i < tong; i++)
            {
                if (DapAn.ContainsKey(i))
                {
                    if (DapAn[i].Trim().ToUpper() == 
                        Danhsach[i].DapAnDung.Trim().ToUpper())
                    {
                        dung++;
                    }
                }
                else
                {
                    chualam++;
                }
            }
                int sai = tong - dung - chualam;
                double diem = tong > 0 ? (double)dung / tong * 10 : 0;
                MessageBox.Show(
                    $"Tổng số câu hỏi: {tong}\n" +
                    $"Số câu đúng: {dung}\n" +
                    $"Số câu sai: {sai}\n" +
                    $"Số câu chưa làm: {chualam}\n" +
                    $"Điểm số: {diem:F2}", 
                    "Kết quả", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
        }
    }
}
        

