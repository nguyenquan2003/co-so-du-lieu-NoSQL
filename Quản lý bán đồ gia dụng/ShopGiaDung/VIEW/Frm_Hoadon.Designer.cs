
namespace ShopGiaDung.VIEW
{
    partial class Frm_Hoadon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Hoadon));
            this.flowLayoutPanel_DSHangHoa = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridView_danhsachmuahang = new System.Windows.Forms.DataGridView();
            this.button_bohang = new System.Windows.Forms.Button();
            this.label_tongtien = new System.Windows.Forms.Label();
            this.textBox_tongtien = new System.Windows.Forms.TextBox();
            this.label_Mucgiam = new System.Windows.Forms.Label();
            this.textBox_SDT = new System.Windows.Forms.TextBox();
            this.button_Thanhtoan = new System.Windows.Forms.Button();
            this.printDocument_Hoadon = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog_hoadon = new System.Windows.Forms.PrintPreviewDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMucGiam = new System.Windows.Forms.TextBox();
            this.txtTenKM = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSoLuongQT = new System.Windows.Forms.TextBox();
            this.txtTenQuaTang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Khuyenmai = new System.Windows.Forms.ComboBox();
            this.button_timkhuyenmai = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_danhsachmuahang)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel_DSHangHoa
            // 
            this.flowLayoutPanel_DSHangHoa.AutoScroll = true;
            this.flowLayoutPanel_DSHangHoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel_DSHangHoa.Location = new System.Drawing.Point(3, 2);
            this.flowLayoutPanel_DSHangHoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel_DSHangHoa.Name = "flowLayoutPanel_DSHangHoa";
            this.flowLayoutPanel_DSHangHoa.Size = new System.Drawing.Size(711, 997);
            this.flowLayoutPanel_DSHangHoa.TabIndex = 0;
            this.flowLayoutPanel_DSHangHoa.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel_DSHangHoa_Paint);
            // 
            // dataGridView_danhsachmuahang
            // 
            this.dataGridView_danhsachmuahang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_danhsachmuahang.Location = new System.Drawing.Point(719, 2);
            this.dataGridView_danhsachmuahang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView_danhsachmuahang.Name = "dataGridView_danhsachmuahang";
            this.dataGridView_danhsachmuahang.RowHeadersWidth = 51;
            this.dataGridView_danhsachmuahang.RowTemplate.Height = 24;
            this.dataGridView_danhsachmuahang.Size = new System.Drawing.Size(1292, 325);
            this.dataGridView_danhsachmuahang.TabIndex = 1;
            this.dataGridView_danhsachmuahang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_danhsachmuahang_CellClick);
            // 
            // button_bohang
            // 
            this.button_bohang.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_bohang.Location = new System.Drawing.Point(721, 335);
            this.button_bohang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_bohang.Name = "button_bohang";
            this.button_bohang.Size = new System.Drawing.Size(368, 74);
            this.button_bohang.TabIndex = 2;
            this.button_bohang.Text = "Bỏ hàng";
            this.button_bohang.UseVisualStyleBackColor = true;
            this.button_bohang.Click += new System.EventHandler(this.button_bohang_Click);
            // 
            // label_tongtien
            // 
            this.label_tongtien.AutoSize = true;
            this.label_tongtien.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tongtien.Location = new System.Drawing.Point(754, 474);
            this.label_tongtien.Name = "label_tongtien";
            this.label_tongtien.Size = new System.Drawing.Size(208, 46);
            this.label_tongtien.TabIndex = 5;
            this.label_tongtien.Text = "Tổng tiền: ";
            // 
            // textBox_tongtien
            // 
            this.textBox_tongtien.Location = new System.Drawing.Point(1012, 461);
            this.textBox_tongtien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_tongtien.Multiline = true;
            this.textBox_tongtien.Name = "textBox_tongtien";
            this.textBox_tongtien.Size = new System.Drawing.Size(212, 59);
            this.textBox_tongtien.TabIndex = 6;
            // 
            // label_Mucgiam
            // 
            this.label_Mucgiam.AutoSize = true;
            this.label_Mucgiam.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Mucgiam.Location = new System.Drawing.Point(754, 570);
            this.label_Mucgiam.Name = "label_Mucgiam";
            this.label_Mucgiam.Size = new System.Drawing.Size(276, 46);
            this.label_Mucgiam.TabIndex = 5;
            this.label_Mucgiam.Text = "Số điện thoại: ";
            // 
            // textBox_SDT
            // 
            this.textBox_SDT.Location = new System.Drawing.Point(1012, 558);
            this.textBox_SDT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_SDT.Multiline = true;
            this.textBox_SDT.Name = "textBox_SDT";
            this.textBox_SDT.Size = new System.Drawing.Size(212, 59);
            this.textBox_SDT.TabIndex = 6;
            this.textBox_SDT.Text = "0977630350";
            // 
            // button_Thanhtoan
            // 
            this.button_Thanhtoan.Font = new System.Drawing.Font("Microsoft YaHei UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Thanhtoan.Location = new System.Drawing.Point(762, 763);
            this.button_Thanhtoan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Thanhtoan.Name = "button_Thanhtoan";
            this.button_Thanhtoan.Size = new System.Drawing.Size(327, 120);
            this.button_Thanhtoan.TabIndex = 2;
            this.button_Thanhtoan.Text = "Thanh toán";
            this.button_Thanhtoan.UseVisualStyleBackColor = true;
            this.button_Thanhtoan.Click += new System.EventHandler(this.button_Thanhtoan_Click);
            // 
            // printDocument_Hoadon
            // 
            this.printDocument_Hoadon.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog_hoadon
            // 
            this.printPreviewDialog_hoadon.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog_hoadon.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog_hoadon.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog_hoadon.Enabled = true;
            this.printPreviewDialog_hoadon.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog_hoadon.Icon")));
            this.printPreviewDialog_hoadon.Name = "printPreviewDialog_hoadon";
            this.printPreviewDialog_hoadon.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtMucGiam);
            this.groupBox1.Controls.Add(this.txtTenKM);
            this.groupBox1.Location = new System.Drawing.Point(1296, 426);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(616, 191);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin khuyến mãi áp dụng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mức giảm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên khuyến mãi";
            // 
            // txtMucGiam
            // 
            this.txtMucGiam.Enabled = false;
            this.txtMucGiam.Location = new System.Drawing.Point(198, 130);
            this.txtMucGiam.Name = "txtMucGiam";
            this.txtMucGiam.Size = new System.Drawing.Size(343, 26);
            this.txtMucGiam.TabIndex = 1;
            // 
            // txtTenKM
            // 
            this.txtTenKM.Enabled = false;
            this.txtTenKM.Location = new System.Drawing.Point(198, 63);
            this.txtTenKM.Name = "txtTenKM";
            this.txtTenKM.Size = new System.Drawing.Size(343, 26);
            this.txtTenKM.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSoLuongQT);
            this.groupBox2.Controls.Add(this.txtTenQuaTang);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(1296, 654);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(616, 208);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin quà tặng áp dụng";
            // 
            // txtSoLuongQT
            // 
            this.txtSoLuongQT.Enabled = false;
            this.txtSoLuongQT.Location = new System.Drawing.Point(198, 125);
            this.txtSoLuongQT.Name = "txtSoLuongQT";
            this.txtSoLuongQT.Size = new System.Drawing.Size(37, 26);
            this.txtSoLuongQT.TabIndex = 11;
            // 
            // txtTenQuaTang
            // 
            this.txtTenQuaTang.Enabled = false;
            this.txtTenQuaTang.Location = new System.Drawing.Point(198, 57);
            this.txtTenQuaTang.Name = "txtTenQuaTang";
            this.txtTenQuaTang.Size = new System.Drawing.Size(343, 26);
            this.txtTenQuaTang.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Số lượng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tên Quà Tặng";
            // 
            // comboBox_Khuyenmai
            // 
            this.comboBox_Khuyenmai.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Khuyenmai.FormattingEnabled = true;
            this.comboBox_Khuyenmai.Location = new System.Drawing.Point(1466, 346);
            this.comboBox_Khuyenmai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_Khuyenmai.Name = "comboBox_Khuyenmai";
            this.comboBox_Khuyenmai.Size = new System.Drawing.Size(349, 63);
            this.comboBox_Khuyenmai.TabIndex = 3;
            this.comboBox_Khuyenmai.Visible = false;
            this.comboBox_Khuyenmai.SelectedIndexChanged += new System.EventHandler(this.comboBox_Khuyenmai_SelectedIndexChanged);
            // 
            // button_timkhuyenmai
            // 
            this.button_timkhuyenmai.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_timkhuyenmai.Location = new System.Drawing.Point(1096, 335);
            this.button_timkhuyenmai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_timkhuyenmai.Name = "button_timkhuyenmai";
            this.button_timkhuyenmai.Size = new System.Drawing.Size(364, 74);
            this.button_timkhuyenmai.TabIndex = 2;
            this.button_timkhuyenmai.Text = "Tìm khuyến mãi";
            this.button_timkhuyenmai.UseVisualStyleBackColor = true;
            this.button_timkhuyenmai.Visible = false;
            this.button_timkhuyenmai.Click += new System.EventHandler(this.button_timkhuyenmai_Click);
            // 
            // Frm_Hoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1015);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_SDT);
            this.Controls.Add(this.textBox_tongtien);
            this.Controls.Add(this.label_Mucgiam);
            this.Controls.Add(this.label_tongtien);
            this.Controls.Add(this.comboBox_Khuyenmai);
            this.Controls.Add(this.button_Thanhtoan);
            this.Controls.Add(this.button_timkhuyenmai);
            this.Controls.Add(this.button_bohang);
            this.Controls.Add(this.dataGridView_danhsachmuahang);
            this.Controls.Add(this.flowLayoutPanel_DSHangHoa);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_Hoadon";
            this.Text = "Frm_Hoadon";
            this.Load += new System.EventHandler(this.Frm_Hoadon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_danhsachmuahang)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_DSHangHoa;
        private System.Windows.Forms.DataGridView dataGridView_danhsachmuahang;
        private System.Windows.Forms.Button button_bohang;
        private System.Windows.Forms.Label label_tongtien;
        private System.Windows.Forms.TextBox textBox_tongtien;
        private System.Windows.Forms.Label label_Mucgiam;
        private System.Windows.Forms.TextBox textBox_SDT;
        private System.Windows.Forms.Button button_Thanhtoan;
        private System.Drawing.Printing.PrintDocument printDocument_Hoadon;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog_hoadon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMucGiam;
        private System.Windows.Forms.TextBox txtTenKM;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSoLuongQT;
        private System.Windows.Forms.TextBox txtTenQuaTang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Khuyenmai;
        private System.Windows.Forms.Button button_timkhuyenmai;
    }
}