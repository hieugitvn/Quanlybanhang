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
        public Functions.SqlServer db; //để bố truyền sang
        public banhang bh;
        public DialogResult ShowAdd(Form papa)
        {
            //this.Icon = Properties.Resources.add_icon;
             this.Text = "Thêm 1 sv mới";
            button1.Text = "Thêm SV";
          //  LoadNganh(null);
            return this.ShowDialog(papa);
        }
        public DialogResult ShowEdit(Form papa)
        {
           // this.Icon = Properties.Resources.edit_icon;
           // this.Text = $"Sửa thông tin sv: {sv.masv} - {sv.hoten}";
            button1.Text = "Cập nhật";
            //cập nhật các giá trị lên form
            textBox1.Text = bh.mahang;
            textBox2.Text = bh.tenhang;
           // dateNS.Value = sv.ngaysinh;
           // if (sv.gt)
            //    gtNam.Checked = true;
           // else
             //   gtNu.Checked = true;

           // LoadNganh(bh.maNganh);
            return this.ShowDialog(papa);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bh = new banhang();
            bh.mahang  = textBox1.Text;
            bh.tenhang  = textBox2.Text;
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
