using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace QLBH
{
    public partial class đondathang : Form
    {
        public đondathang()
        {
            InitializeComponent();
        }
        public Functions.SqlServer db;
        public banhang dh;

        public DialogResult ShowAdd(Form papa)
        {
            them.Text = "Thêm SV";
            return this.ShowDialog(papa);
        }

        public DialogResult ShowEdit(Form papa)
        {
            them.Text = "Cập nhật";
            sohoadon.Text = dh.sohoadon;
            makhachhang.Text = dh.makhachhang;
            manhanvien.Text = dh.manhanvien;
            ngaydathang.Text = dh.ngaydathang;
            ngaygiaohang.Text = dh.ngaygiaohang;
            ngaychuyenhang.Text = dh.ngaychuyenhang;
            noigiaohang.Text = dh.noigiaohang;
            return this.ShowDialog(papa);
        }
        private void them_Click(object sender, EventArgs e)
        {
            string sohoadonn = sohoadon.Text;
            string Makhachhang = makhachhang.Text;
            string Manhanvien = manhanvien.Text;
            string Ngaydathang = ngaydathang.Text;
            string ngaygiaohangg = ngaygiaohang.Text;
            string ngaychuyenhangg = ngaychuyenhang.Text;
            string noigiaohangg = noigiaohang.Text;


            // Lưu giá trị maHang và tenHang vào Tag của các ô nhập liệu
            sohoadon.Tag = sohoadonn;
            makhachhang.Tag = Makhachhang;
            manhanvien.Tag = Manhanvien;
            ngaydathang.Tag = Ngaydathang;
            ngaygiaohang.Tag = ngaygiaohangg;
            ngaychuyenhang.Tag = ngaychuyenhangg;
            noigiaohang.Tag = noigiaohangg;

            dh = new banhang();
            dh.sohoadon = sohoadonn;
            dh.makhachhang = Makhachhang;
            dh.manhanvien = Manhanvien;
            dh.ngaydathang = Ngaydathang;
            dh.ngaygiaohang = ngaygiaohangg;
            dh.ngaychuyenhang = ngaychuyenhangg;
            dh.noigiaohang = noigiaohangg;

            // Ghi thông tin vào cơ sở dữ liệu
            string connectionString = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";

            string query = "INSERT INTO dondathang (sohoadon,makhachhang,manhanvien,ngaydathang,ngaygiaohang,ngaychuyenhang,noigiaohang)" +
                " VALUES (@sohoadon,@makhachhang,@manhanvien,@ngaydathang,@ngaygiaohang,@ngaychuyenhang,@noigiaohang)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@sohoadon", sohoadonn);
                    command.Parameters.AddWithValue("@makhachhang", Makhachhang);
                    command.Parameters.AddWithValue("@manhanvien", Manhanvien);
                    command.Parameters.AddWithValue("@ngaydathang", Ngaydathang);
                    command.Parameters.AddWithValue("@ngaygiaohang", ngaygiaohangg);
                    command.Parameters.AddWithValue("@ngaychuyenhang", ngaychuyenhangg);
                    command.Parameters.AddWithValue("@noigiaohang", noigiaohangg);


                    command.ExecuteNonQuery(); // Execute the INSERT command
                }

            }

            MessageBox.Show("Thông tin đã được ghi vào cơ sở dữ liệu.");
        }

        private void sohoadon_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ctddh ctddh = new ctddh(); //Khởi tạo đối tượng
            ctddh.ShowDialog(); //Hiển thị
        }
    }
}
