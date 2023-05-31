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

        public DialogResult ShowAdd(Form papa)
        {
            button1.Text = "Thêm SV";
            return this.ShowDialog(papa);
        }

        public DialogResult ShowEdit(Form papa)
        {
            button1.Text = "Cập nhật";
            textBox1.Text = bh.mahang;
            textBox2.Text = bh.tenhang;
            return this.ShowDialog(papa);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maHang = textBox1.Text;
            string tenHang = textBox2.Text;

            // Lưu giá trị maHang và tenHang vào Tag của các ô nhập liệu
            textBox1.Tag = maHang;
            textBox2.Tag = tenHang;

            bh = new banhang();
            bh.mahang = maHang;
            bh.tenhang = tenHang;

            // Ghi thông tin vào cơ sở dữ liệu
            string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";

            string query = "INSERT INTO mathang (mahang, tenhang) VALUES (@mahang, @tenhang)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mahang", maHang);
                    command.Parameters.AddWithValue("@tenhang", tenHang);
                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Thông tin đã được ghi vào cơ sở dữ liệu.");
        }

        private void mathang_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

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
      
    }
}
