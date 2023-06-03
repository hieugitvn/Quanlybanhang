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
    public partial class nhacungcap : Form
    {
        public nhacungcap()
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
            string query = "SELECT * FROM nhacungcap";

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
        private void nhacungcap_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void them_Click(object sender, EventArgs e)
        {
            string zMacongty = Macongty.Text;
            string ztencongty = tencongty.Text;
            string ztengiaodich = tengiaodich.Text;
            string zemail = email.Text;
            string zfax = fax.Text;
            string zdiachi = diachi.Text;
            string zdienthoai = dienthoai.Text;

            // Lưu giá trị maHang và tenHang vào Tag của các ô nhập liệu
            Macongty.Tag = zMacongty;
            tencongty.Tag = ztencongty;
            tengiaodich.Tag = ztengiaodich;
            email.Tag = zemail;
            fax.Tag = zfax;
            diachi.Tag = zdiachi;
            dienthoai.Tag = zdienthoai;

            lh = new banhang();
            lh.Macongty = zMacongty;
            lh.tencongty = ztencongty;
            lh.tengiaodich = ztengiaodich;
            lh.email = zemail;
            lh.fax = zfax;
            lh.diachi = zdiachi;
            lh.dienthoai = zdienthoai;
            // Ghi thông tin vào cơ sở dữ liệu
            string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";

            string query = "INSERT INTO nhacungcap (Macongty,tencongty,tengiaodich,email,fax,diachi,dienthoai)" +
                " VALUES (@Macongty,@tencongty,@tengiaodich,@email,@diachi,@dienthoai,@fax)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Macongty", zMacongty);
                    command.Parameters.AddWithValue("@tencongty", ztencongty);
                    command.Parameters.AddWithValue("@tengiaodich", ztengiaodich);
                    command.Parameters.AddWithValue("@email", zemail);
                    command.Parameters.AddWithValue("@fax", zfax);
                    command.Parameters.AddWithValue("@diachi", zdiachi);
                    command.Parameters.AddWithValue("@dienthoai", zdienthoai);
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
                string Macongty = dataGridView1.Rows[rowIndex].Cells["Macongty"].Value.ToString();
                string tencongty = dataGridView1.Rows[rowIndex].Cells["tencongty"].Value.ToString();
                string tengiaodich = dataGridView1.Rows[rowIndex].Cells["tengiaodich"].Value.ToString();
                string email = dataGridView1.Rows[rowIndex].Cells["email"].Value.ToString();
                string fax = dataGridView1.Rows[rowIndex].Cells["fax"].Value.ToString();
                string diachi = dataGridView1.Rows[rowIndex].Cells["diachi"].Value.ToString();
                string dienthoai = dataGridView1.Rows[rowIndex].Cells["dienthoai"].Value.ToString();
                // Xóa hàng từ DataTable và DataGridView
                dataGridView1.Rows.RemoveAt(rowIndex);

                // Xóa dữ liệu tương ứng từ SQL Server
                string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";
                string deleteQuery = "DELETE FROM nhacungcap WHERE Macongty = @Macongty";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Macongty", Macongty);
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
                    string Macongty = row["Macongty"].ToString();
                    string tencongty = row["tencongty"].ToString();
                    string tengiaodich = row["tengiaodich"].ToString();
                    string email = row["email"].ToString();
                    string fax = row["fax"].ToString();
                    string diachi = row["diachi"].ToString();
                    string dienthoai = row["dienthoai"].ToString();

                    // Cập nhật dữ liệu trong SQL Server
                    string updateQuery = @"UPDATE nhacungcap SET 
                                    tencongty = @tencongty,
                                    tengiaodich = @tengiaodich,
                                    email = @email,
                                    fax = @fax,
                                    diachi = @diachi,
                                    dienthoai = @dienthoai
                                  WHERE Macongty = @Macongty";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Macongty", Macongty);
                        command.Parameters.AddWithValue("@tencongty", tencongty);
                        command.Parameters.AddWithValue("@tengiaodich", tengiaodich);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@fax", fax);
                        command.Parameters.AddWithValue("@diachi", diachi);
                        command.Parameters.AddWithValue("@dienthoai", dienthoai);
                        command.ExecuteNonQuery(); // Thực thi câu truy vấn UPDATE
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

        private void hienthi_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private DataTable SearchData(string keyword)
        {
            DataTable result = new DataTable();

            try
            {
                string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    // Thực hiện truy vấn tìm kiếm dữ liệu theo từ khóa
                    string query = "SELECT * FROM nhacungcap WHERE Macongty LIKE @Keyword OR tencongty LIKE @Keyword OR tengiaodich LIKE @Keyword OR email LIKE @Keyword OR fax LIKE @Keyword OR diachi LIKE @Keyword OR dienthoai LIKE @Keyword";
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        // Sử dụng tham số để tránh tình trạng SQL Injection
                        cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

                        // Sử dụng SqlDataAdapter để lấy dữ liệu từ truy vấn
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(result);
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
            }

            return result;
        }
        private void timkiem_Click(object sender, EventArgs e)
        {
            string keyword = tk.Text;
            DataTable result = SearchData(keyword);
            dataGridView1.DataSource = result;
        }

        private void tk_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
