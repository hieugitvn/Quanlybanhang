using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLBH
{
    public partial class loaihang : Form
    {
        public loaihang()
        {
            InitializeComponent();
        }
        public Functions.SqlServer db;
        public banhang lh;
        private void LoadData()
        {
            // Kết nối đến cơ sở dữ liệu
            string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";

            // Câu truy vấn SQL để truy vấn dữ liệu từ bảng SQL
            string query = "SELECT * FROM loaihang";

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
        private void loaihang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void them_Click(object sender, EventArgs e)
        {
            string Tenloaihang = tenloaihang.Text;
            string Maloaihang    = maloaihang.Text;



            // Lưu giá trị maHang và tenHang vào Tag của các ô nhập liệu
            tenloaihang.Tag = Tenloaihang;
            maloaihang.Tag = Maloaihang;


            lh = new banhang();
            lh.tenloaihang = Tenloaihang;
            lh.maloaihang = Maloaihang;

            // Ghi thông tin vào cơ sở dữ liệu
            string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";

            string query = "INSERT INTO loaihang (tenloaihang,maloaihang)" +
                " VALUES (@tenloaihang,@maloaihang)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tenloaihang", Tenloaihang);
                    command.Parameters.AddWithValue("@maloaihang", Maloaihang);

                    command.ExecuteNonQuery(); // Execute the INSERT command
                }

            }
            MessageBox.Show("Thông tin đã được ghi vào cơ sở dữ liệu.");
            LoadData();
        }

        private void soluong_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DeleteSelectedRow()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                // Lấy giá trị từ ô đầu tiên của hàng được chọn (giả sử là cột mã loại hàng)
                string maloaihang = dataGridView1.Rows[rowIndex].Cells["maloaihang"].Value.ToString();
                string tenloaihang = dataGridView1.Rows[rowIndex].Cells["tenloaihang"].Value.ToString();

                // Xóa hàng từ DataTable và DataGridView
                dataGridView1.Rows.RemoveAt(rowIndex);

                // Xóa dữ liệu tương ứng từ SQL Server
                string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";
                string deleteQuery = "DELETE FROM loaihang WHERE maloaihang = @maloaihang";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@maloaihang", maloaihang);
                        command.ExecuteNonQuery(); // Execute the DELETE command
                    }
                }
            }
            MessageBox.Show("Dữ liệu đã được xóa.");
        }


        private void button2_Click(object sender, EventArgs e)
        {
            DeleteSelectedRow();
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
                    string maloaihang = row["maloaihang"].ToString();
                    string tenloaihang = row["tenloaihang"].ToString();

                    // Cập nhật dữ liệu trong SQL Server
                    string updateQuery = "UPDATE loaihang SET tenloaihang = @tenloaihang WHERE maloaihang = @maloaihang";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@tenloaihang", tenloaihang);
                        command.Parameters.AddWithValue("@maloaihang", maloaihang);

                        command.ExecuteNonQuery(); // Execute the UPDATE command
                    }
                }
            }

            MessageBox.Show("Dữ liệu đã được cập nhật.");
        }



        private void sua_Click(object sender, EventArgs e)
        {
            UpdateData();
            LoadData();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Thoát
        }
    }
}
