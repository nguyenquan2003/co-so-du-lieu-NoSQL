using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using ShopGiaDung.CONTROL;
using ShopGiaDung.MODEL;

namespace ShopGiaDung.VIEW
{
    public partial class Frm_NhanVien : Form
    {
        public Frm_NhanVien()
        {
            InitializeComponent();
            loadCombobox();
            loadComboboxChucVu();
            loadData();
        }

        public void loadData()
        {
            dataGridView_Nhanvien.DataSource = new NhanVienCtrl().LoadDLNV();
        }



        public void loadCombobox()
        {
            cbo_Gioitinh.Items.Add("-Giới tính-");
            cbo_Gioitinh.Items.Add("Nam");
            cbo_Gioitinh.Items.Add("Nữ");
            cbo_Gioitinh.SelectedIndex = 0;
        }
        public void loadComboboxChucVu()
        {
            cboChucVu.Items.Add("-Chức vụ-");
            cboChucVu.Items.Add("Admin");
            cboChucVu.Items.Add("Seller");
            cboChucVu.SelectedIndex = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txt_maNV.Text = string.Empty;
            txt_tenNV.Text = string.Empty;
            txt_quequan.Text = string.Empty;
            txt_sdt.Text = string.Empty;
            cbo_Gioitinh.SelectedIndex = 0;

            dateTimePicker1.Value = DateTime.Now;
        }

        private void btn_addNV_Click(object sender, EventArgs e)
        {
            try
            {
                NhanVien nv = new NhanVien();
                nv.manv = txt_maNV.Text;
                nv.tennv = txt_tenNV.Text;
                nv.sdt = txt_sdt.Text;
                nv.que = txt_quequan.Text;
                nv.ngaysinh = dateTimePicker1.Value;
                nv.gender = cbo_Gioitinh.SelectedItem.ToString();
                nv.chucvu = cboChucVu.SelectedItem.ToString();
                nv.taiKhoan = txtTaiKhoan.Text;
                nv.matKhau = txtMatKhau.Text;


                List<string> errors = validateNhanVien(nv);
                if (errors.Count == 0)
                {
                    // Nếu không có lỗi, tiến hành sửa thông tin nhân viên
                    if (new NhanVienCtrl().themNV(nv))
                    {
                        MessageBox.Show("Thêm nhân viên thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Nếu có lỗi, hiển thị tất cả lỗi
                    string errorMessage = string.Join("\n", errors);
                    MessageBox.Show(errorMessage, "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                loadData();
                button4_Click(sender, e);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thêm thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void xoaNV()
        {
            string MANV = new NhanVienCtrl().layMaNV(dataGridView_Nhanvien, 0);
            if (new NhanVienCtrl().XoaNV(MANV))
            {
                MessageBox.Show("Xóa nhân viên thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Xóa thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            loadData();
        }
        public List<string> validateNhanVien(NhanVien nhanVien)
        {
            List<string> errors = new List<string>();

            // Kiểm tra tên nhân viên
            if (string.IsNullOrEmpty(nhanVien.tennv))
            {
                errors.Add("Tên nhân viên không được để trống.");
            }

            // Kiểm tra quê quán
            if (string.IsNullOrEmpty(nhanVien.que))
            {
                errors.Add("Quê quán không được để trống.");
            }

            // Kiểm tra quê quán
            if (string.IsNullOrEmpty(nhanVien.chucvu))
            {
                errors.Add("Chức vụ không được để trống.");
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrEmpty(nhanVien.sdt) || nhanVien.sdt.Length != 10)
            {
                errors.Add("Số điện thoại không hợp lệ. Số điện thoại phải có 10 chữ số.");
            }

            // Kiểm tra ngày sinh (không được lớn hơn ngày hiện tại)
            if (nhanVien.ngaysinh > DateTime.Now)
            {
                errors.Add("Ngày sinh không hợp lệ. Ngày sinh phải nhỏ hơn hoặc bằng ngày hiện tại.");
            }

            // Trả về danh sách các lỗi
            return errors;
        }
        public void SuaNV()
        {
            string MANV = new NhanVienCtrl().layMaNV(dataGridView_Nhanvien, 0);
            //
            NhanVien nv = new NhanVien();
            //nv.manv = txt_maNV.Text.Trim();
            nv.tennv = txt_tenNV.Text.Trim();
            nv.gender = cbo_Gioitinh.SelectedItem.ToString();
            nv.ngaysinh = dateTimePicker1.Value;
            nv.que = txt_quequan.Text;
            nv.sdt = txt_sdt.Text;
            nv.chucvu = cboChucVu.SelectedItem.ToString();
            nv.taiKhoan = txtTaiKhoan.Text;
            nv.matKhau = txtMatKhau.Text;

            //Sủa Khuyến mãi theo mã MãCTR:
            //new NhanVienCtrl().SuaNhanVien(nv, MANV);
            // Kiểm tra tính hợp lệ của thông tin nhân viên
            List<string> errors = validateNhanVien(nv);
            if (errors.Count == 0)
            {
                // Nếu không có lỗi, tiến hành sửa thông tin nhân viên
                if (new NhanVienCtrl().SuaNhanVien(nv, MANV))
                {
                    MessageBox.Show("Sửa nhân viên thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Nếu có lỗi, hiển thị tất cả lỗi
                string errorMessage = string.Join("\n", errors);
                MessageBox.Show(errorMessage, "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            loadData();

        }

        private void btn_delNV_Click(object sender, EventArgs e)
        {
            xoaNV();
            loadData();
        }

        private void btn_editNV_Click(object sender, EventArgs e)
        {
            SuaNV();
            loadData();
        }

        private void dataGridView_Nhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.RowIndex <= dataGridView_Nhanvien.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView_Nhanvien.Rows[e.RowIndex];
                try
                {
                    string maNV = selectedRow.Cells["MaNV"].Value.ToString();
                    string tenNV = selectedRow.Cells["TenNV"].Value.ToString();
                    string gioiTinh = selectedRow.Cells["GioiTinh"].Value.ToString();
                    DateTime Ngaysinh = DateTime.Parse(selectedRow.Cells["NgaySinh"].Value.ToString());
                    string queQ = selectedRow.Cells["QueQuan"].Value.ToString();
                    string sodt = selectedRow.Cells["SoDienThoai"].Value.ToString();
                    string chucVu = selectedRow.Cells["ChucVu"].Value.ToString();
                    string taiKhoan = selectedRow.Cells["TaiKhoan"].Value.ToString();
                    string matKhau = selectedRow.Cells["MatKhau"].Value.ToString();
                    //lấy tên thông tin để hiển thị trước chỉnh sửa

                    txt_maNV.Text = maNV;
                    txt_tenNV.Text = tenNV;
                    if(gioiTinh == "Nam")
                    {
                        cbo_Gioitinh.SelectedIndex = 1;
                    }
                    else if(gioiTinh == "Nữ")
                    {
                        cbo_Gioitinh.SelectedIndex = 2;
                    }
                    else { cbo_Gioitinh.SelectedIndex=0;}
                    dateTimePicker1.Value = Ngaysinh;
                    txt_quequan.Text = queQ;
                    txt_sdt.Text = sodt;

                    if (chucVu == "Admin")
                    {
                        cboChucVu.SelectedIndex = 1;
                    }
                    else if (gioiTinh == "Seller")
                    {
                        cboChucVu.SelectedIndex = 2;
                    }
                    else { cboChucVu.SelectedIndex = 0; }

                    txtTaiKhoan.Text = taiKhoan;
                    txtMatKhau.Text = matKhau;



                }
                catch(Exception ex)
                {
                    cbo_Gioitinh.SelectedIndex = 0;
                    cboChucVu.SelectedIndex=0;
                    txt_maNV.Clear();
                    txt_tenNV.Clear();
                    txt_quequan.Clear();
                    txt_sdt.Clear();
                    dateTimePicker1.Value = DateTime.Now;

                }
            }
        }

        private void dataGridView_Nhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //----
    }
}
