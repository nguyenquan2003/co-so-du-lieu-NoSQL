
namespace ShopGiaDung.VIEW
{
    partial class Frm_DangNhap
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_DangNhap = new System.Windows.Forms.Button();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.label_tenDN = new System.Windows.Forms.Label();
            this.label_MK = new System.Windows.Forms.Label();
            this.textBox_MK = new System.Windows.Forms.TextBox();
            this.button_Huy = new System.Windows.Forms.Button();
            this.linkLabel_QuenMK = new System.Windows.Forms.LinkLabel();
            this.linkLabel_dangky = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(681, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(780, 163);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng nhập";
            // 
            // button_DangNhap
            // 
            this.button_DangNhap.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button_DangNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DangNhap.ForeColor = System.Drawing.Color.White;
            this.button_DangNhap.Location = new System.Drawing.Point(1213, 799);
            this.button_DangNhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_DangNhap.Name = "button_DangNhap";
            this.button_DangNhap.Size = new System.Drawing.Size(472, 144);
            this.button_DangNhap.TabIndex = 1;
            this.button_DangNhap.Text = "Đăng Nhập";
            this.button_DangNhap.UseVisualStyleBackColor = false;
            this.button_DangNhap.Click += new System.EventHandler(this.button_DangNhap_Click);
            // 
            // textBox_Name
            // 
            this.textBox_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Name.Location = new System.Drawing.Point(1149, 355);
            this.textBox_Name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Name.Multiline = true;
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(573, 58);
            this.textBox_Name.TabIndex = 2;
            this.textBox_Name.Text = "Admin";
            // 
            // label_tenDN
            // 
            this.label_tenDN.AutoSize = true;
            this.label_tenDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tenDN.Location = new System.Drawing.Point(399, 316);
            this.label_tenDN.Name = "label_tenDN";
            this.label_tenDN.Size = new System.Drawing.Size(739, 108);
            this.label_tenDN.TabIndex = 3;
            this.label_tenDN.Text = "Tên đăng nhập: ";
            // 
            // label_MK
            // 
            this.label_MK.AutoSize = true;
            this.label_MK.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MK.Location = new System.Drawing.Point(414, 491);
            this.label_MK.Name = "label_MK";
            this.label_MK.Size = new System.Drawing.Size(465, 108);
            this.label_MK.TabIndex = 3;
            this.label_MK.Text = "Mật khẩu:";
            // 
            // textBox_MK
            // 
            this.textBox_MK.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_MK.Location = new System.Drawing.Point(1149, 524);
            this.textBox_MK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_MK.Multiline = true;
            this.textBox_MK.Name = "textBox_MK";
            this.textBox_MK.PasswordChar = '*';
            this.textBox_MK.Size = new System.Drawing.Size(573, 62);
            this.textBox_MK.TabIndex = 2;
            this.textBox_MK.Text = "123Admin";
            // 
            // button_Huy
            // 
            this.button_Huy.BackColor = System.Drawing.Color.Red;
            this.button_Huy.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Huy.ForeColor = System.Drawing.Color.White;
            this.button_Huy.Location = new System.Drawing.Point(442, 799);
            this.button_Huy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Huy.Name = "button_Huy";
            this.button_Huy.Size = new System.Drawing.Size(435, 144);
            this.button_Huy.TabIndex = 1;
            this.button_Huy.Text = "Hủy";
            this.button_Huy.UseVisualStyleBackColor = false;
            // 
            // linkLabel_QuenMK
            // 
            this.linkLabel_QuenMK.AutoSize = true;
            this.linkLabel_QuenMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_QuenMK.Location = new System.Drawing.Point(429, 689);
            this.linkLabel_QuenMK.Name = "linkLabel_QuenMK";
            this.linkLabel_QuenMK.Size = new System.Drawing.Size(564, 82);
            this.linkLabel_QuenMK.TabIndex = 4;
            this.linkLabel_QuenMK.TabStop = true;
            this.linkLabel_QuenMK.Text = "Quên mật khẩu !";
            // 
            // linkLabel_dangky
            // 
            this.linkLabel_dangky.AutoSize = true;
            this.linkLabel_dangky.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel_dangky.Location = new System.Drawing.Point(1351, 689);
            this.linkLabel_dangky.Name = "linkLabel_dangky";
            this.linkLabel_dangky.Size = new System.Drawing.Size(337, 82);
            this.linkLabel_dangky.TabIndex = 4;
            this.linkLabel_dangky.TabStop = true;
            this.linkLabel_dangky.Text = "Đăng ký !";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Frm_DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.linkLabel_dangky);
            this.Controls.Add(this.linkLabel_QuenMK);
            this.Controls.Add(this.label_MK);
            this.Controls.Add(this.label_tenDN);
            this.Controls.Add(this.textBox_MK);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.button_Huy);
            this.Controls.Add(this.button_DangNhap);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Frm_DangNhap";
            this.Text = "Frm_DangNhap";
            this.Load += new System.EventHandler(this.Frm_DangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_DangNhap;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Label label_tenDN;
        private System.Windows.Forms.Label label_MK;
        private System.Windows.Forms.TextBox textBox_MK;
        private System.Windows.Forms.Button button_Huy;
        private System.Windows.Forms.LinkLabel linkLabel_QuenMK;
        private System.Windows.Forms.LinkLabel linkLabel_dangky;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}