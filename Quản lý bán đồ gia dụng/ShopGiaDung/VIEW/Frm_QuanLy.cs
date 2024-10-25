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
    public partial class Frm_QuanLy : Form
    {
        public Frm_QuanLy()
        {
            InitializeComponent();
            // Ẩn nút thu nhỏ (Minimize)
            this.MaximizeBox = false;
            // Đặt form ở chế độ toàn màn hình
            this.WindowState = FormWindowState.Maximized;

           

        }
        private Form CurrentFormChild;

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
            panel_body.Controls.Add(currentChild);
            panel_body.Tag = currentChild;
            currentChild.BringToFront();
            currentChild.Show();
        }
        private void quảnLýKhuyếnMãiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_body.Controls.Clear();
            var Frm_km = new Frm_KhuyenMai();
            craeteFormChild(Frm_km);
        }

        private void quảnLýHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            panel_body.Controls.Clear();
            var Frm_sp = new Frm_SanPham();
            craeteFormChild(Frm_sp);
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_body.Controls.Clear();
            var Frm_nv = new Frm_NhanVien();
            craeteFormChild(Frm_nv);

        }

        private void panel_body_Paint(object sender, PaintEventArgs e)
        {





        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panel_body.Controls.Clear();
            var Frm_BanHang = new Frm_Hoadon();
            craeteFormChild(Frm_BanHang);
        }
    }
}
