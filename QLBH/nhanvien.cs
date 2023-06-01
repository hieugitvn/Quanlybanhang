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
    public partial class nhanvien : Form
    {

        public nhanvien()
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
            string query = "SELECT * FROM nhanvien";

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
        private void nhanvien_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void manhanvien_TextChanged(object sender, EventArgs e)
        {

        }

        private void them_Click(object sender, EventArgs e)
        {
            string zmanhanvien = manhanvien.Text;
            string zho = ho.Text;
            string zten = ten.Text;
            string zngaysinh = ngaysinh.Text;
            string zngaylamviec = ngaylamviec.Text;
            string zdiachi = diachi.Text;
            string zdienthoai = dienthoai.Text;
            string zluongcoban = luongcoban.Text;
            string zphucap = phucap.Text;

            // Lưu giá trị maHang và tenHang vào Tag của các ô nhập liệu
            manhanvien.Tag = zmanhanvien;
            ho.Tag = zho;
            ten.Tag = zten;
            ngaysinh.Tag = zngaysinh;
            ngaylamviec.Tag = zngaylamviec;
            diachi.Tag = zdiachi;
            dienthoai.Tag = zdienthoai;
            luongcoban.Tag = zluongcoban;
            phucap.Tag = zphucap;

            lh = new banhang();
            lh.manhanvien = zmanhanvien;
            lh.ho = zho;
            lh.ten = zten;
            lh.ngaysinh = zngaysinh;
            lh.ngaylamviec = zngaylamviec;
            lh.diachi = zdiachi;
            lh.dienthoai = zdienthoai;
            lh.luongcoban = zluongcoban;
            lh.phucap = zphucap;
            // Ghi thông tin vào cơ sở dữ liệu
            string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";

            string query = "INSERT INTO nhanvien (manhanvien,ho,ten,ngaysinh,ngaylamviec,diachi,dienthoai,luongcoban,phucap)" +
                " VALUES (@manhanvien,@ho,@ten,@ngaysinh,@diachi,@ten,@dienthoai,@luongcoban,@phucap)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@manhanvien", zmanhanvien);
                    command.Parameters.AddWithValue("@ho", zho);
                    command.Parameters.AddWithValue("@ten", zten);
                    command.Parameters.AddWithValue("@ngaysinh", zngaysinh);
                    command.Parameters.AddWithValue("@ngaylamviec", zngaylamviec);
                    command.Parameters.AddWithValue("@diachi", zdiachi);
                    command.Parameters.AddWithValue("@dienthoai", zdienthoai);
                    command.Parameters.AddWithValue("@luongcoban", zluongcoban);
                    command.Parameters.AddWithValue("@phucap", zphucap);
                    command.ExecuteNonQuery(); // Execute the INSERT command
                }

            }
            MessageBox.Show("Thông tin đã được ghi vào cơ sở dữ liệu.");
            LoadData();
        }
        private void DeleteSelectedRow()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;

                // Lấy giá trị từ ô đầu tiên của hàng được chọn (giả sử là cột mã loại hàng)
                string manhanvien = dataGridView1.Rows[rowIndex].Cells["manhanvien"].Value.ToString();
                string ho = dataGridView1.Rows[rowIndex].Cells["ho"].Value.ToString();
                string ten = dataGridView1.Rows[rowIndex].Cells["ten"].Value.ToString();
                string ngaysinh   = dataGridView1.Rows[rowIndex].Cells["ngaysinh"].Value.ToString();
                string ngaylamviec = dataGridView1.Rows[rowIndex].Cells["ngaylamviec"].Value.ToString();
                string diachi = dataGridView1.Rows[rowIndex].Cells["diachi"].Value.ToString();
                string dienthoai = dataGridView1.Rows[rowIndex].Cells["dienthoai"].Value.ToString();
                string luongcoban = dataGridView1.Rows[rowIndex].Cells["luongcoban"].Value.ToString();
                string phucap = dataGridView1.Rows[rowIndex].Cells["phucap"].Value.ToString();
                // Xóa hàng từ DataTable và DataGridView
                dataGridView1.Rows.RemoveAt(rowIndex);

                // Xóa dữ liệu tương ứng từ SQL Server
                string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";
                string deleteQuery = "DELETE FROM nhanvien WHERE manhanvien = @manhanvien";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@manhanvien", manhanvien);
                        command.ExecuteNonQuery(); // Execute the DELETE command
                    }
                }
            }
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
                    string manhanvien = row["manhanvien"].ToString();
                    string ho = row["ho"].ToString();
                    string ten = row["ten"].ToString();
                    string ngaysinh = row["ngaysinh"].ToString();
                    string ngaylamviec = row["ngaylamviec"].ToString();
                    string diachi = row["diachi"].ToString();
                    string dienthoai = row["dienthoai"].ToString();
                    string luongcoban = row["luongcoban"].ToString();
                    string phucap = row["phucap"].ToString();
                    // Cập nhật dữ liệu trong SQL Server
                    string updateQuery = @"UPDATE nhanvien SET 
                        ho = @ho,
                        ten = @ten,
                        ngaysinh = @ngaysinh,
                        ngaylamviec = @ngaylamviec,
                        diachi = @diachi,
                        dienthoai = @dienthoai,
                        luongcoban = @luongcoban,
                        phucap = @phucap
                      WHERE manhanvien = @manhanvien";


                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@manhanvien", manhanvien);
                        command.Parameters.AddWithValue("@ho", ho);
                        command.Parameters.AddWithValue("@ten", ten);
                        command.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                        command.Parameters.AddWithValue("@ngaylamviec", ngaylamviec);
                        command.Parameters.AddWithValue("@diachi", diachi);
                        command.Parameters.AddWithValue("@dienthoai", dienthoai);
                        command.Parameters.AddWithValue("@luongcoban", luongcoban);
                        command.Parameters.AddWithValue("@phucap", phucap);
                        command.ExecuteNonQuery(); // Execute the UPDATE command
                    }
                }
            }

            MessageBox.Show("Dữ liệu đã được cập nhật.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateData();
            LoadData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Thoát
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
