using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.SqlClient;
namespace QLBH
{
    public partial class menu : Form
    {
        const string cnStr = @"Data Source=aff;Initial Catalog=Quanlybanhang;Integrated Security=True;";
        Functions.SqlServer db = new Functions.SqlServer(cnStr);
        public menu()
        {
            InitializeComponent();
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }

        private void tùyChọnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void thoat_Click(object sender, EventArgs e)
        {

            Application.Exit(); //Thoát
        }

        private void mặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            mathang mathang = new mathang(); //Khởi tạo đối tượng
           mathang.ShowDialog(); //Hiển thị
           this.Show();

        }

        private void đơnHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            đondathang đondathang = new đondathang(); //Khởi tạo đối tượng
            đondathang.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            khachhang khachhang = new khachhang(); //Khởi tạo đối tượng
            khachhang.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            nhanvien nhanvien = new nhanvien(); //Khởi tạo đối tượng
            nhanvien.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            nhacungcap nhacungcap = new nhacungcap(); //Khởi tạo đối tượng
            nhacungcap.ShowDialog(); //Hiển thị
            this.Show();
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
