
namespace ShopGiaDung.VIEW
{
    partial class Frm_SanPham
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_chonanh = new System.Windows.Forms.Button();
            this.comboBox_chonkhuyenmai = new System.Windows.Forms.ComboBox();
            this.textBox_TênSP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_Soluong = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_gia = new System.Windows.Forms.TextBox();
            this.button_themmoi = new System.Windows.Forms.Button();
            this.button_Them = new System.Windows.Forms.Button();
            this.button_xoa = new System.Windows.Forms.Button();
            this.button_sua = new System.Windows.Forms.Button();
            this.dataGridView_sanpham = new System.Windows.Forms.DataGridView();
            this.pictureBox_AnhSP = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider3 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Soluong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sanpham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AnhSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).BeginInit();
            this.SuspendLayout();
            // 
            // button_chonanh
            // 
            this.button_chonanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_chonanh.Location = new System.Drawing.Point(769, 308);
            this.button_chonanh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_chonanh.Name = "button_chonanh";
            this.button_chonanh.Size = new System.Drawing.Size(219, 52);
            this.button_chonanh.TabIndex = 1;
            this.button_chonanh.Text = "Chọn Ảnh";
            this.button_chonanh.UseVisualStyleBackColor = true;
            this.button_chonanh.Click += new System.EventHandler(this.button_chonanh_Click);
            // 
            // comboBox_chonkhuyenmai
            // 
            this.comboBox_chonkhuyenmai.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_chonkhuyenmai.FormattingEnabled = true;
            this.comboBox_chonkhuyenmai.Location = new System.Drawing.Point(305, 160);
            this.comboBox_chonkhuyenmai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_chonkhuyenmai.Name = "comboBox_chonkhuyenmai";
            this.comboBox_chonkhuyenmai.Size = new System.Drawing.Size(419, 40);
            this.comboBox_chonkhuyenmai.TabIndex = 2;
            this.comboBox_chonkhuyenmai.SelectedIndexChanged += new System.EventHandler(this.comboBox_chonkhuyenmai_SelectedIndexChanged);
            // 
            // textBox_TênSP
            // 
            this.textBox_TênSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_TênSP.Location = new System.Drawing.Point(305, 87);
            this.textBox_TênSP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_TênSP.Name = "textBox_TênSP";
            this.textBox_TênSP.Size = new System.Drawing.Size(419, 39);
            this.textBox_TênSP.TabIndex = 3;
            this.textBox_TênSP.TextChanged += new System.EventHandler(this.textBox_TênSP_TextChanged);
            this.textBox_TênSP.MouseLeave += new System.EventHandler(this.textBox_TênSP_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(209, 32);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên sản phẩm: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Giá: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(469, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "Số lượng:";
            // 
            // numericUpDown_Soluong
            // 
            this.numericUpDown_Soluong.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown_Soluong.Location = new System.Drawing.Point(659, 260);
            this.numericUpDown_Soluong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numericUpDown_Soluong.Name = "numericUpDown_Soluong";
            this.numericUpDown_Soluong.Size = new System.Drawing.Size(65, 39);
            this.numericUpDown_Soluong.TabIndex = 4;
            this.numericUpDown_Soluong.ValueChanged += new System.EventHandler(this.numericUpDown_Soluong_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(45, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(249, 32);
            this.label6.TabIndex = 0;
            this.label6.Text = "Chọn khuyến mãi: ";
            // 
            // textBox_gia
            // 
            this.textBox_gia.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_gia.Location = new System.Drawing.Point(305, 257);
            this.textBox_gia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_gia.Name = "textBox_gia";
            this.textBox_gia.Size = new System.Drawing.Size(132, 39);
            this.textBox_gia.TabIndex = 3;
            this.textBox_gia.TextChanged += new System.EventHandler(this.textBox_gia_TextChanged);
            // 
            // button_themmoi
            // 
            this.button_themmoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_themmoi.Location = new System.Drawing.Point(276, 545);
            this.button_themmoi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_themmoi.Name = "button_themmoi";
            this.button_themmoi.Size = new System.Drawing.Size(205, 79);
            this.button_themmoi.TabIndex = 1;
            this.button_themmoi.Text = "Thêm mới";
            this.button_themmoi.UseVisualStyleBackColor = true;
            this.button_themmoi.Click += new System.EventHandler(this.button_themmoi_Click);
            // 
            // button_Them
            // 
            this.button_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Them.Location = new System.Drawing.Point(519, 545);
            this.button_Them.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Them.Name = "button_Them";
            this.button_Them.Size = new System.Drawing.Size(205, 79);
            this.button_Them.TabIndex = 1;
            this.button_Them.Text = "Thêm SP";
            this.button_Them.UseVisualStyleBackColor = true;
            this.button_Them.Click += new System.EventHandler(this.button_Them_Click);
            // 
            // button_xoa
            // 
            this.button_xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_xoa.Location = new System.Drawing.Point(757, 545);
            this.button_xoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_xoa.Name = "button_xoa";
            this.button_xoa.Size = new System.Drawing.Size(200, 79);
            this.button_xoa.TabIndex = 1;
            this.button_xoa.Text = "Xóa";
            this.button_xoa.UseVisualStyleBackColor = true;
            this.button_xoa.Click += new System.EventHandler(this.button_xoa_Click);
            // 
            // button_sua
            // 
            this.button_sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_sua.Location = new System.Drawing.Point(39, 545);
            this.button_sua.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_sua.Name = "button_sua";
            this.button_sua.Size = new System.Drawing.Size(197, 79);
            this.button_sua.TabIndex = 1;
            this.button_sua.Text = "Sửa";
            this.button_sua.UseVisualStyleBackColor = true;
            this.button_sua.Click += new System.EventHandler(this.button_sua_Click);
            // 
            // dataGridView_sanpham
            // 
            this.dataGridView_sanpham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView_sanpham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_sanpham.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_sanpham.Location = new System.Drawing.Point(1007, 87);
            this.dataGridView_sanpham.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView_sanpham.Name = "dataGridView_sanpham";
            this.dataGridView_sanpham.RowHeadersWidth = 51;
            this.dataGridView_sanpham.RowTemplate.Height = 24;
            this.dataGridView_sanpham.Size = new System.Drawing.Size(905, 527);
            this.dataGridView_sanpham.TabIndex = 6;
            this.dataGridView_sanpham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_sanpham_CellClick);
            this.dataGridView_sanpham.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_sanpham_CellContentClick);
            // 
            // pictureBox_AnhSP
            // 
            this.pictureBox_AnhSP.Location = new System.Drawing.Point(743, 87);
            this.pictureBox_AnhSP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox_AnhSP.Name = "pictureBox_AnhSP";
            this.pictureBox_AnhSP.Size = new System.Drawing.Size(258, 205);
            this.pictureBox_AnhSP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_AnhSP.TabIndex = 5;
            this.pictureBox_AnhSP.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // errorProvider3
            // 
            this.errorProvider3.ContainerControl = this;
            // 
            // Frm_SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 837);
            this.Controls.Add(this.dataGridView_sanpham);
            this.Controls.Add(this.pictureBox_AnhSP);
            this.Controls.Add(this.numericUpDown_Soluong);
            this.Controls.Add(this.textBox_gia);
            this.Controls.Add(this.textBox_TênSP);
            this.Controls.Add(this.comboBox_chonkhuyenmai);
            this.Controls.Add(this.button_sua);
            this.Controls.Add(this.button_xoa);
            this.Controls.Add(this.button_Them);
            this.Controls.Add(this.button_themmoi);
            this.Controls.Add(this.button_chonanh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_SanPham";
            this.Text = "Frm_SanPham";
            this.Load += new System.EventHandler(this.Frm_SanPham_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Soluong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sanpham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AnhSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_chonanh;
        private System.Windows.Forms.ComboBox comboBox_chonkhuyenmai;
        private System.Windows.Forms.TextBox textBox_TênSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_Soluong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_gia;
        private System.Windows.Forms.PictureBox pictureBox_AnhSP;
        private System.Windows.Forms.Button button_themmoi;
        private System.Windows.Forms.Button button_Them;
        private System.Windows.Forms.Button button_xoa;
        private System.Windows.Forms.Button button_sua;
        private System.Windows.Forms.DataGridView dataGridView_sanpham;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.ErrorProvider errorProvider3;
    }
}