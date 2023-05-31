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
            them.Text = "Thêm SV";
            return this.ShowDialog(papa);
        }

        public DialogResult ShowEdit(Form papa)
        {
            them.Text = "Cập nhật";
            mahang.Text = bh.mahang;
            tenhang.Text = bh.tenhang;
            macongty.Text = bh.macongty;
            donvitinh.Text = bh.donvitinh;
            soluong.Text = bh.soluong;
            maloaihang.Text = bh.maloaihang;
            giaban.Text = bh.giaban;
            gianhap.Text = bh.gianhap;
            return this.ShowDialog(papa);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string maHang = mahang.Text;
            string tenHang = tenhang.Text;
            string Macongty = macongty.Text;
            string Donvitinh = donvitinh.Text;
            string Soluong = soluong.Text;
            string Maloaihang= maloaihang.Text;
            string Gianhap = gianhap.Text;
            string Giaban= giaban.Text;


            // Lưu giá trị maHang và tenHang vào Tag của các ô nhập liệu
            mahang.Tag = maHang;
            tenhang.Tag = tenHang;
            macongty.Tag = Macongty;
            donvitinh.Tag = Donvitinh;
            soluong.Tag = Soluong;
            maloaihang.Tag = Maloaihang;
            gianhap.Tag = Gianhap;
            giaban.Tag = Giaban;

            bh = new banhang();
            bh.mahang = maHang;
            bh.tenhang = tenHang;
            bh.macongty= Macongty;
            bh.donvitinh= Donvitinh;
            bh.soluong = Soluong;
            bh.maloaihang = Maloaihang;
            bh.gianhap = Gianhap;
            bh.giaban = Giaban;
            // Ghi thông tin vào cơ sở dữ liệu
            string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";

            string query = "INSERT INTO mathang (mahang,tenhang,macongty,donvitinh,soluong,maloaihang,gianhap,giaban)" +
                " VALUES (@mahang,@tenhang,@macongty,@donvitinh,@soluong,@maloaihang,@gianhap,@giaban)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@mahang", maHang);
                    command.Parameters.AddWithValue("@tenhang", tenHang);
                    command.Parameters.AddWithValue("@macongty", Macongty);
                    command.Parameters.AddWithValue("@donvitinh", Donvitinh);
                    command.Parameters.AddWithValue("@soluong", Soluong);
                    command.Parameters.AddWithValue("@maloaihang", Maloaihang);
                    command.Parameters.AddWithValue("@gianhap", Gianhap);
                    command.Parameters.AddWithValue("@giaban", Giaban);

                    command.ExecuteNonQuery(); // Execute the INSERT command
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
    }
}