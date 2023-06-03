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
     public partial class mathang : Form
    {
        public mathang()
        {
            InitializeComponent();
        }

        public Functions.SqlServer db;
        public banhang bh;
        private void LoadData()
        {
            // Kết nối đến cơ sở dữ liệu
            string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";

            // Câu truy vấn SQL để truy vấn dữ liệu từ bảng SQL
            string query = "SELECT * FROM mathang";

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
                string mahang = dataGridView1.Rows[rowIndex].Cells["mahang"].Value.ToString();
                string tenhang = dataGridView1.Rows[rowIndex].Cells["tenhang"].Value.ToString();
                string macongty = dataGridView1.Rows[rowIndex].Cells["macongty"].Value.ToString();
                string maloaihang = dataGridView1.Rows[rowIndex].Cells["maloaihang"].Value.ToString();
                string soluong = dataGridView1.Rows[rowIndex].Cells["soluong"].Value.ToString();
                string donvitinh = dataGridView1.Rows[rowIndex].Cells["donvitinh"].Value.ToString();
                string gianhap = dataGridView1.Rows[rowIndex].Cells["gianhap"].Value.ToString();
                // Xóa hàng từ DataTable và DataGridView
                dataGridView1.Rows.RemoveAt(rowIndex);

                // Xóa dữ liệu tương ứng từ SQL Server
                string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";
                string deleteQuery = "DELETE FROM mathang WHERE mahang = @mahang";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@mahang", mahang);
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
                    string mahang = row["mahang"].ToString();
                    string tenhang = row["tenhang"].ToString();
                    string macongty = row["macongty"].ToString();
                    string maloaihang = row["maloaihang"].ToString();
                    string soluong = row["soluong"].ToString();
                    string donvitinh = row["donvitinh"].ToString();
                    string gianhap = row["gianhap"].ToString();

                    // Cập nhật dữ liệu trong SQL Server
                    string updateQuery = @"UPDATE mathang SET 
                                    tenhang = @tenhang,
                                    macongty = @macongty,
                                    maloaihang = @maloaihang,
                                    soluong = @soluong,
                                    donvitinh = @donvitinh,
                                    gianhap = @gianhap
                                  WHERE mahang = @mahang";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@mahang", mahang);
                        command.Parameters.AddWithValue("@tenhang", tenhang);
                        command.Parameters.AddWithValue("@macongty", macongty);
                        command.Parameters.AddWithValue("@maloaihang", maloaihang);
                        command.Parameters.AddWithValue("@soluong", soluong);
                        command.Parameters.AddWithValue("@donvitinh", donvitinh);
                        command.Parameters.AddWithValue("@gianhap", gianhap);
                        command.ExecuteNonQuery(); // Thực thi câu truy vấn UPDATE
                    }
                }
            }

            MessageBox.Show("Dữ liệu đã được cập nhật.");
        }
        // Phương thức thực hiện tìm kiếm dữ liệu
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
                    string query = "SELECT * FROM mathang WHERE mahang LIKE @Keyword OR tenhang LIKE @Keyword OR macongty LIKE @Keyword OR donvitinh LIKE @Keyword OR soluong LIKE @Keyword OR maloaihang LIKE @Keyword OR gianhap LIKE @Keyword";
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
        private void button1_Click(object sender, EventArgs e)
        {
            string zmahang = mahang.Text;
            string ztenhang = tenhang.Text;
            string zmacongty = macongty.Text;
            string zdonvitinh = donvitinh.Text;
            string zsoluong = soluong.Text;
            string zmaloaihang = maloaihang.Text;
            string zgianhap = gianhap.Text;


            // Lưu giá trị maHang và tenHang vào Tag của các ô nhập liệu
            mahang.Tag = zmahang;
            tenhang.Tag = ztenhang;
            macongty.Tag = zmacongty;
            donvitinh.Tag = zdonvitinh;
            soluong.Tag = zsoluong;
            maloaihang.Tag = zmaloaihang;
            gianhap.Tag = zgianhap;

            bh = new banhang();
            bh.mahang = zmahang;
            bh.tenhang = ztenhang;
            bh.macongty= zmacongty;
            bh.donvitinh= zdonvitinh;
            bh.soluong = zsoluong;
            bh.maloaihang = zmaloaihang;
            bh.gianhap = zgianhap;
            // Ghi thông tin vào cơ sở dữ liệu
            string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";

            string query = "INSERT INTO mathang (mahang,tenhang,macongty,donvitinh,soluong,maloaihang,gianhap)" +
                " VALUES (@mahang,@tenhang,@macongty,@donvitinh,@soluong,@maloaihang,@gianhap)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mahang", zmahang);
                    command.Parameters.AddWithValue("@tenhang", ztenhang);
                    command.Parameters.AddWithValue("@macongty", zmacongty);
                    command.Parameters.AddWithValue("@donvitinh", zdonvitinh);
                    command.Parameters.AddWithValue("@soluong", zsoluong);
                    command.Parameters.AddWithValue("@maloaihang", zmaloaihang);
                    command.Parameters.AddWithValue("@gianhap", zgianhap);


                    command.ExecuteNonQuery(); // Execute the INSERT command
                }

            }

            MessageBox.Show("Thông tin đã được ghi vào cơ sở dữ liệu.");
            LoadData();
        }

        private void mathang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateData();
            LoadData();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void maloaihang_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            loaihang loaihang = new loaihang(); //Khởi tạo đối tượng
            loaihang.ShowDialog(); //Hiển thị
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteSelectedRow();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            nhacungcap loaihang = new nhacungcap(); //Khởi tạo đối tượng
            loaihang.ShowDialog(); //Hiển thị
        }

        private void hienthi_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void tk_TextChanged(object sender, EventArgs e)
        {

        }
        // Xử lý sự kiện Click của Button tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = tk.Text; // Lấy từ khóa tìm kiếm từ TextBox

            // Thực hiện tìm kiếm và hiển thị kết quả trên DataGridView
            DataTable result = SearchData(keyword);
            dataGridView1.DataSource = result;
        }

      

        private void timkiem_Click(object sender, EventArgs e)
        {
            string keyword = tk.Text;
            DataTable result = SearchData(keyword);
            dataGridView1.DataSource = result;
        }
    }
}