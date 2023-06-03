namespace QLBH
{
    partial class loaihang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sua = new System.Windows.Forms.Button();
            this.xoa = new System.Windows.Forms.Button();
            this.them = new System.Windows.Forms.Button();
            this.tenloaihang = new System.Windows.Forms.TextBox();
            this.maloaihang = new System.Windows.Forms.TextBox();
            this.text1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.hienthi = new System.Windows.Forms.Button();
            this.tk = new System.Windows.Forms.TextBox();
            this.timkiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // sua
            // 
            this.sua.Location = new System.Drawing.Point(337, 415);
            this.sua.Name = "sua";
            this.sua.Size = new System.Drawing.Size(75, 23);
            this.sua.TabIndex = 8;
            this.sua.Text = "Sửa";
            this.sua.UseVisualStyleBackColor = true;
            this.sua.Click += new System.EventHandler(this.sua_Click);
            // 
            // xoa
            // 
            this.xoa.Location = new System.Drawing.Point(153, 415);
            this.xoa.Name = "xoa";
            this.xoa.Size = new System.Drawing.Size(75, 23);
            this.xoa.TabIndex = 7;
            this.xoa.Text = "Xóa";
            this.xoa.UseVisualStyleBackColor = true;
            this.xoa.Click += new System.EventHandler(this.button2_Click);
            // 
            // them
            // 
            this.them.Location = new System.Drawing.Point(9, 415);
            this.them.Name = "them";
            this.them.Size = new System.Drawing.Size(75, 23);
            this.them.TabIndex = 6;
            this.them.Text = "Thêm";
            this.them.UseVisualStyleBackColor = true;
            this.them.Click += new System.EventHandler(this.them_Click);
            // 
            // tenloaihang
            // 
            this.tenloaihang.Location = new System.Drawing.Point(337, 6);
            this.tenloaihang.Name = "tenloaihang";
            this.tenloaihang.Size = new System.Drawing.Size(100, 22);
            this.tenloaihang.TabIndex = 22;
            this.tenloaihang.TextChanged += new System.EventHandler(this.soluong_TextChanged);
            // 
            // maloaihang
            // 
            this.maloaihang.Location = new System.Drawing.Point(105, 12);
            this.maloaihang.Name = "maloaihang";
            this.maloaihang.Size = new System.Drawing.Size(100, 22);
            this.maloaihang.TabIndex = 21;
            // 
            // text1
            // 
            this.text1.AutoSize = true;
            this.text1.Location = new System.Drawing.Point(243, 12);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(89, 16);
            this.text1.TabIndex = 20;
            this.text1.Text = "Tên loại hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Mã loại hàng";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(27, 171);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(761, 190);
            this.dataGridView1.TabIndex = 23;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(599, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Lưu ý:Nếu cần sửa thì thay đổi dữ liệu trực tiếp  trên DataGridView và bấm nút sử" +
    "a để hoàn tất thao tác";
            // 
            // hienthi
            // 
            this.hienthi.Location = new System.Drawing.Point(452, 415);
            this.hienthi.Name = "hienthi";
            this.hienthi.Size = new System.Drawing.Size(75, 23);
            this.hienthi.TabIndex = 54;
            this.hienthi.Text = "Hiển thị";
            this.hienthi.UseVisualStyleBackColor = true;
            this.hienthi.Click += new System.EventHandler(this.hienthi_Click);
            // 
            // tk
            // 
            this.tk.Location = new System.Drawing.Point(678, 415);
            this.tk.Name = "tk";
            this.tk.Size = new System.Drawing.Size(100, 22);
            this.tk.TabIndex = 53;
            this.tk.TextChanged += new System.EventHandler(this.tk_TextChanged);
            // 
            // timkiem
            // 
            this.timkiem.Location = new System.Drawing.Point(597, 415);
            this.timkiem.Name = "timkiem";
            this.timkiem.Size = new System.Drawing.Size(75, 23);
            this.timkiem.TabIndex = 52;
            this.timkiem.Text = "Tìm kiếm";
            this.timkiem.UseVisualStyleBackColor = true;
            this.timkiem.Click += new System.EventHandler(this.timkiem_Click);
            // 
            // loaihang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hienthi);
            this.Controls.Add(this.tk);
            this.Controls.Add(this.timkiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tenloaihang);
            this.Controls.Add(this.maloaihang);
            this.Controls.Add(this.text1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sua);
            this.Controls.Add(this.xoa);
            this.Controls.Add(this.them);
            this.Name = "loaihang";
            this.Text = "Loại Hàng";
            this.Load += new System.EventHandler(this.loaihang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button sua;
        private System.Windows.Forms.Button xoa;
        private System.Windows.Forms.Button them;
        private System.Windows.Forms.TextBox tenloaihang;
        private System.Windows.Forms.TextBox maloaihang;
        private System.Windows.Forms.Label text1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button hienthi;
        private System.Windows.Forms.TextBox tk;
        private System.Windows.Forms.Button timkiem;
    }
}