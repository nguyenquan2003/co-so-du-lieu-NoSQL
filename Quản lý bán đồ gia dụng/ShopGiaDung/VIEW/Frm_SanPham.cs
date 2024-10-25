using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopGiaDung.CONTROL;
using ShopGiaDung.MODEL;
namespace ShopGiaDung.VIEW
{
    public partial class Frm_SanPham : Form
    {
        public Frm_SanPham()
        {
            InitializeComponent();
        }
        private string selectedImagePath;
        private string selectedImageName;
        private bool checkNull()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(textBox_TênSP.Text))
            {
                isValid = false;
            }

            if (numericUpDown_Soluong.Value == 0)
            {
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(textBox_gia.Text))
            {
                isValid = false;
            }
            return isValid;
        }
        private bool SaveImageToFolder()
        {
            if (!string.IsNullOrEmpty(selectedImagePath) && checkNull() == true)
            {
                string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string imagesDirectory = Path.Combine(projectDirectory, "Image");

                if (!Directory.Exists(imagesDirectory))
                {
                    Directory.CreateDirectory(imagesDirectory);
                }

                string fileName = Path.GetFileName(selectedImagePath);
                string destinationPath = Path.Combine(imagesDirectory, fileName);

                File.Copy(selectedImagePath, destinationPath, true);

                MessageBox.Show("Thành công");
                return true;
            }
            else if (!string.IsNullOrEmpty(selectedImagePath) && checkNull() == false)
            {
                MessageBox.Show("Chưa nhập đủ thông tin!!!!");
                return false;
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn ảnh");
                return false;
            }
        }

        //các hàm check
        private void checkTenSP()
        {
            if (string.IsNullOrWhiteSpace(textBox_TênSP.Text))
            {
                errorProvider1.SetError(textBox_TênSP, "Tên sản phẩm không được bỏ trống");
            }
            else
            {
                errorProvider1.SetError(textBox_TênSP, "");
            }
        }

        private void CheckSoLuong()
        {
            if (numericUpDown_Soluong.Value == 0)
            {
                errorProvider2.SetError(numericUpDown_Soluong, "Số lượng không được chứa số 0");
            }
            else
            {
                errorProvider2.SetError(numericUpDown_Soluong, ""); // Xóa thông báo lỗi
            }
        }

        private void CheckPrice()
        {
            if (string.IsNullOrWhiteSpace(textBox_gia.Text))
            {
                errorProvider3.SetError(textBox_gia, "Giá không được bỏ trống");
            }
            else if (Convert.ToDecimal(textBox_gia.Text) <= 0)
            {
                errorProvider3.SetError(textBox_gia, "Giá không được âm");
            }
            else if (!decimal.TryParse(textBox_gia.Text, out decimal price))
            {
                errorProvider3.SetError(textBox_gia, "Giá phải là số");
            }
            else
            {
                errorProvider3.SetError(textBox_gia, "");
            }
        }
        public void SuaSP()
        {

            string MaSP = "";
            string hinhanh = "";
            if (dataGridView_sanpham.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_sanpham.SelectedRows[0];
                object firstCellValue = selectedRow.Cells[1].Value;
                object hinhanhValue = selectedRow.Cells[5].Value;

                if (firstCellValue != null)
                {
                    MaSP = firstCellValue.ToString();
                    hinhanh = hinhanhValue.ToString();
                }

            }

            try
            {
                if (selectedImageName != null)
                    hinhanh = selectedImageName;
                SanPham KM = new SanPham();
                KM.Tensp = textBox_TênSP.Text.Trim();
                KM.Makm = comboBox_chonkhuyenmai.SelectedValue.ToString();
                KM.Gia = int.Parse(textBox_gia.Text.Trim());
                KM.Soluong = int.Parse(numericUpDown_Soluong.Value.ToString());
                KM.Tenanh = hinhanh;
               
                //Sủa Khuyến mãi theo mã MãCTR:
                if (new SanPhanCtrl().SuaSanPham(KM))
                {
                    MessageBox.Show("Sửa thành công!!!");
                    loaddatagridviewSP();
                }
                else
                    MessageBox.Show("Không sửa đươc!!!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!");
            }


        }

        public void xoaSP()
        {
            string MaSP = "";
            if (dataGridView_sanpham.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView_sanpham.SelectedRows[0];
                object firstCellValue = selectedRow.Cells[0].Value;

                if (firstCellValue != null)
                {
                    MaSP = firstCellValue.ToString();

                }

            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phảm này?", "Xác nhận xóa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                if (new SanPhanCtrl().XoaSanPham(MaSP.Trim()))
                {

                    MessageBox.Show("Xóa sản phẩm thành công!!!!");
                    loaddatagridviewSP();
                }
                else
                    MessageBox.Show("Chưa xóa được, có lỗi!!!!");
            }
        }

        private void Frm_SanPham_Load(object sender, EventArgs e)
        {
            LoadComBo();
            loaddatagridviewSP();
        }

        private void button_themmoi_Click(object sender, EventArgs e)
        {

        }

        private void button_chonanh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImageName = openFileDialog.SafeFileName;
                selectedImagePath = openFileDialog.FileName;
                pictureBox_AnhSP.Image = Image.FromFile(selectedImagePath);
            }
        }
        private void loaddatagridviewSP()
        {
            dataGridView_sanpham.DataSource = new SanPhanCtrl().LoadDLSP();
        }

        //private bool ktraThem()
        private void button_Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (errorProvider1.GetError(textBox_TênSP) == "" &&
           errorProvider2.GetError(numericUpDown_Soluong) == "" &&
           errorProvider3.GetError(textBox_gia) == "" || checkNull() == true)
                    if (SaveImageToFolder())
                    {
                        SanPham sp = new SanPham(textBox_TênSP.Text.Trim(), selectedImageName.Trim(), comboBox_chonkhuyenmai.SelectedValue.ToString(), Int32.Parse(numericUpDown_Soluong.Value.ToString()), Int32.Parse(textBox_gia.Text.Trim()));
                        if (new SanPhanCtrl().ThemSP(sp))
                        {
                            loaddatagridviewSP();
                            MessageBox.Show("Thêm thành công!!");
                        }

                        else
                            MessageBox.Show("Thêm thất bại!!");
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!");
            }
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            xoaSP();
        }

        private void LoadComBo()
        {
            comboBox_chonkhuyenmai.DataSource = new KhyenMaiCtrl().LayMaGiam();
            comboBox_chonkhuyenmai.DisplayMember = "TenKM";
            comboBox_chonkhuyenmai.ValueMember = "MaKM";
        }
        //kiểm tra trống


        private void comboBox_chonkhuyenmai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_TênSP_TextChanged(object sender, EventArgs e)
        {
            checkTenSP();
        }

        private void numericUpDown_Soluong_ValueChanged(object sender, EventArgs e)
        {
            CheckSoLuong();
        }

        private void textBox_gia_TextChanged(object sender, EventArgs e)
        {
            CheckPrice();
        }

        private void textBox_TênSP_MouseLeave(object sender, EventArgs e)
        {

        }

        private void dataGridView_sanpham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView_sanpham.CellClick += DataGridView_sanpham_CellClick;
        }

        private void DataGridView_sanpham_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Kiểm tra xem người dùng đã chọn một hàng hợp lệ hay không
            // Kiểm tra xem người dùng đã chọn một hàng hợp lệ hay không
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView_sanpham.Rows.Count)
            {

                DataGridViewRow selectedRow = dataGridView_sanpham.Rows[e.RowIndex];

                // Lấy giá trị của cột "URL" từ hàng được chọn
                string imageUrl = selectedRow.Cells["HinhAnh"].Value.ToString();

                // Hiển thị hình ảnh từ URL trong PictureBox
                string folderPath = @"D:\SinhVienHUIT\HocKi7\CoSoDuLieu_NoSQL\ShopGiaDung\Image";// Thay thế bằng đường dẫn thực sự tới thư mục "Image" trong project của bạn

                // Tên của tệp tin hình ảnh muốn hiển thị

                // Tạo đường dẫn đầy đủ tới tệp tin hình ảnh
                string imagePath = Path.Combine(folderPath, imageUrl);

                // Kiểm tra xem tệp tin có tồn tại hay không
                if (File.Exists(imagePath))
                {
                    // Hiển thị hình ảnh từ đường dẫn trong PictureBox
                    pictureBox_AnhSP.ImageLocation = imagePath;
                }
                string tenSP = selectedRow.Cells["TenSP"].Value.ToString();
                int soluong = int.Parse(selectedRow.Cells["Soluong"].Value.ToString());
                int gia = int.Parse(selectedRow.Cells["Gia"].Value.ToString());
                string maKM = selectedRow.Cells["MaKM"].Value.ToString();

                textBox_TênSP.Text = tenSP;
                numericUpDown_Soluong.Value = soluong;
                textBox_gia.Text = gia.ToString();
                int index = -1;

                DataTable dtb = new KhyenMaiCtrl().LayMaGiam();
                foreach (DataRow row in dtb.Rows)
                {
                    if (row["MaKM"].ToString() == maKM) // Thay "Tên cột" bằng tên cột trong DataTable của bạn
                    {
                        index = dtb.Rows.IndexOf(row);
                        break;
                    }
                }

                if (index != -1)
                {
                    comboBox_chonkhuyenmai.SelectedIndex = index;
                }
            }

        }

        private void button_sua_Click(object sender, EventArgs e)
        {
            SuaSP();
        }
    }
}
