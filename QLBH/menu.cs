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
            //Functions.Connect();
        }

        private void tùyChọnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void thoat_Click(object sender, EventArgs e)
        {
            //Functions.Disconnect(); //Đóng kết nối
            Application.Exit(); //Thoát
        }

        private void mặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mathang mathang = new mathang(); //Khởi tạo đối tượng
           mathang.ShowDialog(); //Hiển thị
        }
    }
}
