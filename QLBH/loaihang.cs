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
        public lhang lh;
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
        private void loaihang_Load(object sender, EventArgs e)
        {

        }

        private void them_Click(object sender, EventArgs e)
        {
            string Tenloaihang = tenloaihang.Text;
            string Maloaihang    = maloaihang.Text;



            // Lưu giá trị maHang và tenHang vào Tag của các ô nhập liệu
            tenloaihang.Tag = Tenloaihang;
            maloaihang.Tag = Maloaihang;


            lh = new lhang();
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
        }

        private void soluong_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
