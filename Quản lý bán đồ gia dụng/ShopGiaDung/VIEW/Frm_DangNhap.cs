using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopGiaDung.CONTROL;
namespace ShopGiaDung.VIEW
{
    public partial class Frm_DangNhap : Form
    {
        //public event EventHandler LoginSuccess;
        //public event EventHandler<string> DuLieuSanSang;
        private DangNhap dangNhap = new DangNhap();
        //private void TruyenDuLieu()
        //{
        //    // Gọi event DuLieuSanSang khi dữ liệu đã sẵn sàng
        //    DuLieuSanSang?.Invoke(this, textBox_Name.Text);
        //}

        public Frm_DangNhap()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            // Đặt form ở chế độ toàn màn hình
            this.WindowState = FormWindowState.Maximized;
            textBox_Name.Clear();
            textBox_MK.Clear();

        }
        private Decimal ValidateTextBoxes()
        {
            errorProvider1.Clear(); // Xóa tất cả lỗi trước đó
            Decimal value = 0;
            if (string.IsNullOrEmpty(textBox_Name.Text))
            {
                errorProvider1.SetError(textBox_Name, "Vui lòng nhập tên đăng nhập");
                value = 1;
            }

            if (string.IsNullOrEmpty(textBox_MK.Text))
            {
                errorProvider1.SetError(textBox_MK, "Vui lòng nhập mật khẩu");
                value = 2;
            }
            return value;
        }


        private void button_DangNhap_Click(object sender, EventArgs e)
        {
            decimal checkerro = ValidateTextBoxes();

            // Nếu không có lỗi, thực hiện đăng nhập
            if (checkerro == 0)
            {
                try
                {
                    string role = checkTonTaiTK(); // Kiểm tra thông tin đăng nhập
                    if (role == "Admin")
                    {
                        var Frm_nv = new Frm_QuanLy();
                        Frm_nv.Show();
                        this.Hide();
                    }
                    else if (role == "Seller")
                    {
                        var Frm_seller = new Frm_Hoadon();
                        Frm_seller.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Sai thông tin đăng nhập!!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                }
            }
            else
            {
                // Xử lý các trường hợp lỗi
                if (checkerro == 1)
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập."); // Thông báo rõ ràng
                    textBox_Name.Clear();
                    textBox_Name.Focus();
                }
                else if (checkerro == 2)
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu."); // Thông báo rõ ràng
                    textBox_MK.Clear();
                    textBox_MK.Focus();
                }
                else if (checkerro == 1 && checkerro == 2)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin."); // Thông báo rõ ràng
                    textBox_MK.Clear();
                    textBox_Name.Clear();
                    textBox_MK.Focus();
                }
            }
        }



        private string checkTonTaiTK()
        {
            DataTable dataTable = dangNhap.LoadDangNhap();
            if (dataTable == null || dataTable.Columns.Count == 0)
            {
                throw new Exception("DataTable is null or has no columns.");
            }

            string result = "Not Found";
            foreach (DataRow row in dataTable.Rows)
            { 
                if (row["TaiKhoan"].ToString() == textBox_Name.Text && row["MatKhau"].ToString() == textBox_MK.Text.Trim())
                {
                    string chucVu = row["ChucVu"].ToString();
                    if (chucVu == "Admin" || chucVu == "Seller")
                    {
                        result = chucVu;
                    }
                    break;
                }
            }
            return result;
        }


        private void Frm_DangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
