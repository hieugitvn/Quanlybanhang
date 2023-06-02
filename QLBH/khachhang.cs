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
    public partial class khachhang : Form
    {
        public khachhang()
        {
            InitializeComponent();
        }
        public Functions.SqlServer db;
        public banhang kh;
        private void LoadData()
        {
            // Kết nối đến cơ sở dữ liệu
            string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";

            // Câu truy vấn SQL để truy vấn dữ liệu từ bảng SQL
            string query = "SELECT * FROM khachhang";

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
                string makhachhang = dataGridView1.Rows[rowIndex].Cells["makhachhang"].Value.ToString();
                string Tencongty = dataGridView1.Rows[rowIndex].Cells["Tencongty"].Value.ToString();
                string tengiaodich = dataGridView1.Rows[rowIndex].Cells["tengiaodich"].Value.ToString();
                string diachi = dataGridView1.Rows[rowIndex].Cells["diachi"].Value.ToString();
                string email = dataGridView1.Rows[rowIndex].Cells["email"].Value.ToString();
                string dienthoai = dataGridView1.Rows[rowIndex].Cells["dienthoai"].Value.ToString();
                string fax = dataGridView1.Rows[rowIndex].Cells["fax"].Value.ToString();
                // Xóa hàng từ DataTable và DataGridView
                dataGridView1.Rows.RemoveAt(rowIndex);

                // Xóa dữ liệu tương ứng từ SQL Server
                string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";
                string deleteQuery = "DELETE FROM khachhang WHERE makhachhang = @makhachhang";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@makhachhang", makhachhang);
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
                    string makhachhang = row["makhachhang"].ToString();
                    string Tencongty = row["Tencongty"].ToString();
                    string tengiaodich = row["tengiaodich"].ToString();
                    string diachi = row["diachi"].ToString();
                    string email = row["email"].ToString();
                    string dienthoai = row["dienthoai"].ToString();
                    string fax = row["fax"].ToString();

                    // Cập nhật dữ liệu trong SQL Server
                    string updateQuery = @"UPDATE khachhang SET 
                                    Tencongty = @Tencongty,
                                    tengiaodich = @tengiaodich,
                                    diachi = @diachi,
                                    email = @email,
                                    dienthoai = @dienthoai,
                                    fax = @fax
                                  WHERE makhachhang = @makhachhang";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@makhachhang", makhachhang);
                        command.Parameters.AddWithValue("@Tencongty", Tencongty);
                        command.Parameters.AddWithValue("@tengiaodich", tengiaodich);
                        command.Parameters.AddWithValue("@diachi", diachi);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@dienthoai", dienthoai);
                        command.Parameters.AddWithValue("@fax", fax);
                        command.ExecuteNonQuery(); // Thực thi câu truy vấn UPDATE
                    }
                }
            }

            MessageBox.Show("Dữ liệu đã được cập nhật.");
        }
        private void makhachhang_TextChanged(object sender, EventArgs e)
        {

        }

        private void them_Click(object sender, EventArgs e)
        {
            string makhachhangg = makhachhang.Text;
            string Tencongtyy = Tencongty.Text;
            string tengiaodichh = tengiaodich.Text;
            string diachii = diachi.Text;
            string emaill = email.Text;
            string dienthoaii = dienthoai.Text;
            string faxx = fax.Text;



            makhachhang.Tag = makhachhangg;
            Tencongty.Tag = Tencongtyy;
            tengiaodich.Tag = tengiaodichh;
            diachi.Tag = diachii;
            email.Tag = emaill;
            dienthoai.Tag = dienthoaii;
            fax.Tag = faxx;

            kh = new banhang();
            kh.makhachhang = makhachhangg;
            kh.Tencongty = Tencongtyy;
            kh.tengiaodich = tengiaodichh;
            kh.diachi = diachii;
            kh.email = emaill;
            kh.dienthoai = dienthoaii;
            kh.fax = faxx;
            // Ghi thông tin vào cơ sở dữ liệu
            string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";

            string query = "INSERT INTO khachhang (makhachhang,Tencongty,tengiaodich,diachi,email,dienthoai,fax)" +
                " VALUES (@makhachhang,@Tencongty,@tengiaodich,@diachi,@email,@dienthoai,@fax)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@makhachhang", makhachhangg);
                    command.Parameters.AddWithValue("@Tencongty", Tencongtyy);
                    command.Parameters.AddWithValue("@tengiaodich", tengiaodichh);
                    command.Parameters.AddWithValue("@diachi", diachii);
                    command.Parameters.AddWithValue("@email", emaill);
                    command.Parameters.AddWithValue("@dienthoai", dienthoaii);
                    command.Parameters.AddWithValue("@fax", faxx);

                    command.ExecuteNonQuery(); // Execute the INSERT command
                }

            }

            MessageBox.Show("Thông tin đã được ghi vào cơ sở dữ liệu.");
            LoadData();
        }

        private void tencongty_TextChanged(object sender, EventArgs e)
        {

        }

        private void khachhang_Load(object sender, EventArgs e)
        {
            LoadData();
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
