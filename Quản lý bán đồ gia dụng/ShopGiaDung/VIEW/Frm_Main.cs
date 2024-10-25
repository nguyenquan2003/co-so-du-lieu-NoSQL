using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopGiaDung.VIEW
{
    public partial class Frm_Main : Form
    {


        public static bool StatusAccount = false; 
        public Frm_Main()
        {
            InitializeComponent();
        }
        private Form CurrentFormChild;
        private void Dn_DuLieuSanSang(string obj)
        {
            label_hienthiiten.Text = obj;
        }

        
        
        private void craeteFormChild(Form currentChild)
        {
            if (CurrentFormChild != null)
            {
                CurrentFormChild.Close();
            }
            CurrentFormChild = currentChild;
            currentChild.TopLevel = false;
            currentChild.FormBorderStyle = FormBorderStyle.None;
            currentChild.Dock = DockStyle.Fill;
            panel_Body.Controls.Add(currentChild);
            panel_Body.Tag = currentChild;
            currentChild.BringToFront();
            currentChild.Show();
        }

        private void panel_Body_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button_DN_Click(object sender, EventArgs e)
        {
            if (button_DN.Text == "Đăng nhập")
            {
                var Frm = new Frm_DangNhap();
                //Frm.LoginSuccess += Frm_Main_LoginSuccess;
                //Frm.DuLieuSanSang += Frm_DuLieuSanSang; 
                craeteFormChild(Frm);             
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // Kiểm tra kết quả người dùng đã chọn
                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    Frm_Main frm = new Frm_Main();
                    frm.Show();
                }
            }
        }

        private void Frm_DuLieuSanSang(object sender, string e)
        {
            label_hienthiiten.Text = e;
            label_hienthiiten.Font = new Font(label_hienthiiten.Font.Name, 20);
        }

        private void ThucHienTruyenText()
        {
            Frm_DangNhap frm = new Frm_DangNhap();
            // Đăng ký một handler cho event TextThayDoi của form con
            
        }

        private void Frm_Main_LoginSuccess(object sender, EventArgs e)
        {
            //đăng nhập thành công thì cho nút đăng nhập thành đăng xuất
            button_DN.Text = "Đăng xuất";
            StatusAccount = true; // đã đăng nhập
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
        }

        private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn lưu dữ liệu trước khi đóng chương trình?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void button_Quanly_Click(object sender, EventArgs e)
        {
            if (StatusAccount == true)
            {
                panel_Body.Controls.Clear();
                var Frm_QL = new Frm_QuanLy();
                craeteFormChild(Frm_QL);
            }
        }

        private void button_Muahang_Click(object sender, EventArgs e)
        {
            if (StatusAccount == true)
            {
                panel_Body.Controls.Clear();
                var Frm_BH = new Frm_Hoadon();
                craeteFormChild(Frm_BH);
            }
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
