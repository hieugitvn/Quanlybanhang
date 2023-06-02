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
using System.Net.NetworkInformation;

namespace QLBH
{
    public partial class đondathang : Form
    {
        public đondathang()
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
            string query = "SELECT * FROM dondathang";

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
                string manhanvien = dataGridView1.Rows[rowIndex].Cells["manhanvien"].Value.ToString();
                string ngaydathang = dataGridView1.Rows[rowIndex].Cells["ngaydathang"].Value.ToString();
                string ngaygiaohang = dataGridView1.Rows[rowIndex].Cells["ngaygiaohang"].Value.ToString();
                string ngaychuyenhang = dataGridView1.Rows[rowIndex].Cells["ngaychuyenhang"].Value.ToString();
                string noigiaohang = dataGridView1.Rows[rowIndex].Cells["noigiaohang"].Value.ToString();
                string makhachhang = dataGridView1.Rows[rowIndex].Cells["makhachhang"].Value.ToString();
                // Xóa hàng từ DataTable và DataGridView
                dataGridView1.Rows.RemoveAt(rowIndex);

                // Xóa dữ liệu tương ứng từ SQL Server
                string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";
                string deleteQuery = "DELETE FROM dondathang WHERE Sohoadon = @Sohoadon";

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
                    string manhanvien = row["manhanvien"].ToString();
                    string ngaydathang = row["ngaydathang"].ToString();
                    string ngaygiaohang = row["ngaygiaohang"].ToString();
                    string ngaychuyenhang = row["ngaychuyenhang"].ToString();
                    string noigiaohang = row["noigiaohang"].ToString();
                    string makhachhang = row["makhachhang"].ToString();

                    // Cập nhật dữ liệu trong SQL Server
                    string updateQuery = @"UPDATE dondathang SET 
                                    manhanvien = @manhanvien,
                                    ngaydathang = @ngaydathang,
                                    ngaygiaohang = @ngaygiaohang,
                                    ngaychuyenhang = @ngaychuyenhang,
                                    noigiaohang = @noigiaohang,
                                    makhachhang = @makhachhang
                                  WHERE Sohoadon = @Sohoadon";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Sohoadon", Sohoadon);
                        command.Parameters.AddWithValue("@manhanvien", manhanvien);
                        command.Parameters.AddWithValue("@ngaydathang", ngaydathang);
                        command.Parameters.AddWithValue("@ngaygiaohang", ngaygiaohang);
                        command.Parameters.AddWithValue("@ngaychuyenhang", ngaychuyenhang);
                        command.Parameters.AddWithValue("@noigiaohang", noigiaohang);
                        command.Parameters.AddWithValue("@makhachhang", makhachhang);
                        command.ExecuteNonQuery(); // Thực thi câu truy vấn UPDATE
                    }
                }
            }

            MessageBox.Show("Dữ liệu đã được cập nhật.");
        }
        private void them_Click(object sender, EventArgs e)
        {
            string sohoadonn = sohoadon.Text;
            string zmakhachhang = makhachhang.Text;
            string Manhanvien = manhanvien.Text;
            string Ngaydathang = ngaydathang.Text;
            string ngaygiaohangg = ngaygiaohang.Text;
            string ngaychuyenhangg = ngaychuyenhang.Text;
            string noigiaohangg = noigiaohang.Text;


            // Lưu giá trị Sohoadon và manhanvien vào Tag của các ô nhập liệu
            sohoadon.Tag = sohoadonn;
            makhachhang.Tag = zmakhachhang;
            manhanvien.Tag = Manhanvien;
            ngaydathang.Tag = Ngaydathang;
            ngaygiaohang.Tag = ngaygiaohangg;
            ngaychuyenhang.Tag = ngaychuyenhangg;
            noigiaohang.Tag = noigiaohangg;

            dh = new banhang();
            dh.sohoadon = sohoadonn;
            dh.makhachhang = zmakhachhang;
            dh.manhanvien = Manhanvien;
            dh.ngaydathang = Ngaydathang;
            dh.ngaygiaohang = ngaygiaohangg;
            dh.ngaychuyenhang = ngaychuyenhangg;
            dh.noigiaohang = noigiaohangg;

            // Ghi thông tin vào cơ sở dữ liệu
            string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";

            string query = "INSERT INTO dondathang (sohoadon,makhachhang,manhanvien,ngaydathang,ngaygiaohang,ngaychuyenhang,noigiaohang)" +
                " VALUES (@sohoadon,@makhachhang,@manhanvien,@ngaydathang,@ngaygiaohang,@ngaychuyenhang,@noigiaohang)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sohoadon", sohoadonn);
                    command.Parameters.AddWithValue("@makhachhang", zmakhachhang);
                    command.Parameters.AddWithValue("@manhanvien", Manhanvien);
                    command.Parameters.AddWithValue("@ngaydathang", Ngaydathang);
                    command.Parameters.AddWithValue("@ngaygiaohang", ngaygiaohangg);
                    command.Parameters.AddWithValue("@ngaychuyenhang", ngaychuyenhangg);
                    command.Parameters.AddWithValue("@noigiaohang", noigiaohangg);


                    command.ExecuteNonQuery(); // Execute the INSERT command
                }

            }

            MessageBox.Show("Thông tin đã được ghi vào cơ sở dữ liệu.");
        }

        private void sohoadon_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ctddh ctddh = new ctddh(); //Khởi tạo đối tượng
            ctddh.ShowDialog(); //Hiển thị
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteSelectedRow();
        }

        private void đondathang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UpdateData();
            LoadData();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
