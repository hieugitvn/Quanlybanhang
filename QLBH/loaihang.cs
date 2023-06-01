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
        public DialogResult ShowAdd(Form papa)
        {
            them.Text = "Thêm SV";
            return this.ShowDialog(papa);
        }

        public DialogResult ShowEdit(Form papa)
        {
            them.Text = "Cập nhật";

            tenloaihang.Text = lh.tenloaihang;
            maloaihang.Text = lh.maloaihang;
            return this.ShowDialog(papa);
        }
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

    }
}
