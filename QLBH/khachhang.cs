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
        public DialogResult ShowAdd(Form papa)
        {
            them.Text = "Thêm SV";
            return this.ShowDialog(papa);
        }

        public DialogResult ShowEdit(Form papa)
        {
            them.Text = "Cập nhật";
            makhachhang.Text = kh.makhachhang;
            Tencongty.Text = kh.Tencongty;
            tengiaodich.Text = kh.tengiaodich;
            diachi.Text = kh.diachi;
            email.Text = kh.email;
            dienthoai.Text = kh.dienthoai;
            fax.Text = kh.fax;
            return this.ShowDialog(papa);
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


            // Lưu giá trị maHang và tenHang vào Tag của các ô nhập liệu
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
        }

        private void tencongty_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
