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

namespace QLBH
{
    public partial class ctddh : Form
    {
        public ctddh()
        {
            InitializeComponent();
        }
        public Functions.SqlServer db;
        public banhang dh;
        private void LoadData()
        {
            // Kết nối đến cơ sở dữ liệu
            string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";

            // Câu truy vấn SQL để truy vấn dữ liệu từ bảng SQL
            string query = "SELECT * FROM ctddh";

            // Tạo đối tượng DataTable để lưu trữ dữ liệu từ kết quả truy vấn SQL
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Tạo đối tượng SqlDataAdapter để thực thi câu truy vấn SQL và điền dữ liệu vào đối tượng DataTable
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                // Điền dữ liệu vào đối tượng DataTable
                dataAdapter.Fill(dataTable);
            }

            // Gán đối tượng DataTable làm nguồn dữ liệu cho bảng DataGridView
            dataGridView1.DataSource = dataTable;
        }
        private void DeleteSelectedRow()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                // Lấy giá trị từ ô đầu tiên của hàng được chọn (giả sử là cột mã loại hàng)
                string Sohoadon = dataGridView1.Rows[rowIndex].Cells["Sohoadon"].Value.ToString();
                string mahang = dataGridView1.Rows[rowIndex].Cells["mahang"].Value.ToString();
                string giaban = dataGridView1.Rows[rowIndex].Cells["giaban"].Value.ToString();
                string soluong = dataGridView1.Rows[rowIndex].Cells["soluong"].Value.ToString();
                string mucgiamgia = dataGridView1.Rows[rowIndex].Cells["mucgiamgia"].Value.ToString();

                // Xóa hàng từ DataTable và DataGridView
                dataGridView1.Rows.RemoveAt(rowIndex);

                // Xóa dữ liệu tương ứng từ SQL Server
                string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";
                string deleteQuery = "DELETE FROM ctddh WHERE Sohoadon = @Sohoadon";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Sohoadon", Sohoadon);
                        command.ExecuteNonQuery(); // Execute the DELETE command
                    }
                }
            }
            MessageBox.Show("Dữ liệu đã được xóa.");
        }
        private void UpdateData()
        {
            // Lấy dữ liệu từ DataGridView
            DataTable dataTable = (DataTable)dataGridView1.DataSource;

            // Kết nối đến cơ sở dữ liệu
            string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Vòng lặp để cập nhật từng hàng trong DataTable
                foreach (DataRow row in dataTable.Rows)
                {
                    // Lấy giá trị từ các ô trong hàng
                    string Sohoadon = row["Sohoadon"].ToString();
                    string mahang = row["mahang"].ToString();
                    string giaban = row["giaban"].ToString();
                    string soluong = row["soluong"].ToString();
                    string mucgiamgia = row["mucgiamgia"].ToString();


                    // Cập nhật dữ liệu trong SQL Server
                    string updateQuery = @"UPDATE ctddh SET 
                                    mahang = @mahang,
                                    giaban = @giaban,
                                    soluong = @soluong,
                                    mucgiamgia = @mucgiamgia
                                  WHERE Sohoadon = @Sohoadon";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Sohoadon", Sohoadon);
                        command.Parameters.AddWithValue("@mahang", mahang);
                        command.Parameters.AddWithValue("@giaban", giaban);
                        command.Parameters.AddWithValue("@soluong", soluong);
                        command.Parameters.AddWithValue("@mucgiamgia", mucgiamgia);
                        command.ExecuteNonQuery(); // Thực thi câu truy vấn UPDATE
                    }
                }
            }

            MessageBox.Show("Dữ liệu đã được cập nhật.");
        }
            private void ctddh_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void them_Click(object sender, EventArgs e)
        {
            string sohoadonn = sohoadon.Text;
            string zmahang = mahang.Text;
            string zgiaban = giaban.Text;
            string zsoluong = soluong.Text;
            string zmucgiamgia = mucgiamgia.Text;


            // Lưu giá trị Sohoadon và mahang vào Tag của các ô nhập liệu
            sohoadon.Tag = sohoadonn;
            mahang.Tag = zmahang;
            giaban.Tag = zgiaban;
            soluong.Tag = zsoluong;
            mucgiamgia.Tag = zmucgiamgia;

            dh = new banhang();
            dh.sohoadon = sohoadonn;
            dh.mahang = zmahang;
            dh.giaban = zgiaban;
            dh.soluong = zsoluong;
            dh.mucgiamgia = zmucgiamgia;


            // Ghi thông tin vào cơ sở dữ liệu
            string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";

            string query = "INSERT INTO ctddh (sohoadon,mahang,giaban,soluong,zmucgiamgia)" +
                " VALUES (@sohoadon,@mahang,@giaban,@soluong,@zmucgiamgia)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sohoadon", sohoadonn);
                    command.Parameters.AddWithValue("@mahang", zmahang);
                    command.Parameters.AddWithValue("@giaban", zgiaban);
                    command.Parameters.AddWithValue("@soluong", zsoluong);
                    command.Parameters.AddWithValue("@mucgiamgia", zmucgiamgia);


                    command.ExecuteNonQuery(); // Execute the INSERT command
                }

            }

            MessageBox.Show("Thông tin đã được ghi vào cơ sở dữ liệu.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteSelectedRow();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateData();
            LoadData();
        }
    }
}
