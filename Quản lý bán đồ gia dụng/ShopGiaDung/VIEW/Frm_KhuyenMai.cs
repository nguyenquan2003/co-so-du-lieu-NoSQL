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
using ShopGiaDung.MODEL;
using MongoDB.Bson;
using Newtonsoft.Json;
using System.Runtime.Remoting.Contexts;
namespace ShopGiaDung.VIEW
{
    public partial class Frm_KhuyenMai : Form
    {
        public Frm_KhuyenMai()
        {
            InitializeComponent();
        }

        private void button_them_Click(object sender, EventArgs e)
        {
            try
            {
                Khuyenmai km = new Khuyenmai();
                km.Machuongtrinh1 = textBox_CtrKM.Text;
                km.Maquatang1 = comboBox_quatang.SelectedValue.ToString();
                km.Tenqua = comboBox_quatang.Text.Trim();
                km.Ngaybatdau1 = dateTimePicker_Batdau.Value;
                km.Ngayketthuc1 = dateTimePicker_Ketthuc.Value;
                km.PhantramGiam1 = Int32.Parse(comboBox_Phantramgiam.SelectedItem.ToString().Trim());
                km.Soluongqua1 = Int32.Parse(textBox_soqua.Text.Trim());
                km.Tenkhuyenmai1 = textBox_tenkhuyenmai.Text;
                if (new KhyenMaiCtrl().ThemKM(km))
                { 
                    MessageBox.Show("Thêm thành công!!");
                    loadDataKM();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");

            }
        }

        private void loadDataKM()
        {
            //DataTable data = new ConnectNosql().Load("QLBH_KM", "CTR_KhuyenMai");
            dataGridView_khuyenmai.DataSource = new KhyenMaiCtrl().LoadKM();
        }
        //load comboobox quaf tặng 

        private void LoadDataIntoComboBox()
        {
            // Gọi phương thức lấy dữ liệu vào DataTable
            DataTable dtb = new KhyenMaiCtrl().LoadQuaTang();

            // Kiểm tra xem DataTable có dữ liệu hay không
            if (dtb != null && dtb.Rows.Count > 0)
            {
                // Đặt DataSource cho ComboBox
                comboBox_quatang.DataSource = dtb;

                // Chỉ định cột nào sẽ hiển thị và cột nào sẽ là giá trị
                comboBox_quatang.DisplayMember = "TenQT"; // Cột hiển thị
                comboBox_quatang.ValueMember = "MaQT";   // Cột giá trị
            }
            else
            {
                // Có thể hiển thị một thông báo nếu không có dữ liệu
                MessageBox.Show("Không có quà tặng để hiển thị.");
            }
        }

      

        private void Frm_KhuyenMai_Load(object sender, EventArgs e)
        {
            LoadDataIntoComboBox();
            loadDataKM();
            
        }

        private void dataGridView_khuyenmai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //Tạo hàm sửa thông tin chương trinh KM: 
       
        /*ACTION1: Lấy thông tin tương ứng cần sửa vào Model tương ứng: 
            1: Lấy vào mã CTR khi clickCell trên view: 
            2: Lấy Tên CTR mới(Nếu thay đổi)
            3: Lấy Ngày bắt đầu mới(Nếu thay đổi)
            4: Lấy Ngày kết thúc mới(Nếu thay đổi) 
            5: Lấy Tên Khuyến mãi mới(Nếu thay đổi)
            6: Lấy phần trăm giảm mới(Nếu thay đổi)
            7: Lấy mã quà tặng mới(Nếu thay đổi)
            6: Lấy số lượng quà mới(Nếu thay đổi)
        */
        //ACTION1: 

        public void xoaKM()
        {
            string MACTR = new KhyenMaiCtrl().layMaCTR(dataGridView_khuyenmai, 0);
            if (new KhyenMaiCtrl().XoaKM(MACTR))
            {
                loadDataKM();
                MessageBox.Show("Xóa chương trình khuyến mãi thành công!!!!");
            }
            else
                MessageBox.Show("Chưa xóa được, có lỗi!!!!");
        }

        public void SuaCTRKM()
        {
            string MACTR = new KhyenMaiCtrl().layMaCTR(dataGridView_khuyenmai, 0);
            //Tạo đối tượng khuyenmai
            //MessageBox.Show("MaCTR:" + MACTR);
            Khuyenmai KM = new Khuyenmai();
            KM.Tenkhuyenmai1 = textBox_tenkhuyenmai.Text.Trim();
            KM.Ngaybatdau1 = dateTimePicker_Batdau.Value;
            KM.Ngayketthuc1 = dateTimePicker_Ketthuc.Value;
            KM.Machuongtrinh1 = textBox_CtrKM.Text;
            KM.PhantramGiam1 = int.Parse(comboBox_Phantramgiam.SelectedIndex.ToString());
            KM.Maquatang1 = comboBox_quatang.SelectedValue.ToString();
            KM.Soluongqua1 = int.Parse(textBox_soqua.Text);
            //Sủa Khuyến mãi theo mã MãCTR:
            if (new KhyenMaiCtrl().SuaKhuyenMai(KM, MACTR))
            {
                loadDataKM();
                MessageBox.Show("Sửa chương trình khuyến mãi thành công!!!!");
            }
            else
                MessageBox.Show("Chưa sửa được, có lỗi!!!!");
        }


      


        //Khi nhấp select hàng trên datagridview hiện thông tin lên các hộp chứa thông tin tương ứng
        private void dataGridView_khuyenmai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra chỉ số dòng hợp lệ
            {
                DataGridViewRow selectedRow = dataGridView_khuyenmai.Rows[e.RowIndex];

                try
                {
                    // Lấy tên chương trình khuyến mãi
                    string tenCTR = selectedRow.Cells["TenCTR"].Value.ToString();

                    // Lấy ngày bắt đầu và ngày kết thúc
                    DateTime NgayBD = DateTime.Parse(selectedRow.Cells["NgayBatDau"].Value.ToString());
                    DateTime NgayKT = DateTime.Parse(selectedRow.Cells["NgayKetThuc"].Value.ToString());

                    string TenKM = selectedRow.Cells["TenKM"].Value?.ToString();
                   
                    

                    string TenQT = selectedRow.Cells["TenQT"].Value?.ToString();
                

                    textBox_CtrKM.Text = tenCTR;
                    
                    textBox_tenkhuyenmai.Text = TenKM;
                    dateTimePicker_Batdau.Value = NgayBD;
                    dateTimePicker_Ketthuc.Value = NgayKT;

                    int index_quatang = comboBox_quatang.FindStringExact(TenQT);
                    comboBox_quatang.SelectedIndex = index_quatang >= 0 ? index_quatang : 0;
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ, thiết lập lại các điều khiển
                    comboBox_quatang.SelectedIndex = 0;
                    comboBox_Phantramgiam.SelectedIndex = 0;
                    textBox_CtrKM.Clear();
                    textBox_soqua.Clear();
                    textBox_tenkhuyenmai.Clear();
                    dateTimePicker_Batdau.Value = DateTime.Now;
                    dateTimePicker_Ketthuc.Value = DateTime.Now;

                    // (Có thể ghi log hoặc hiển thị thông báo cho người dùng nếu cần)
                    Console.WriteLine(ex.Message); // Hoặc sử dụng một MessageBox để thông báo lỗi
                }
            }
        }


        private void button_sua_Click(object sender, EventArgs e)
        {
            SuaCTRKM();
        }

        private void button_xoa_Click(object sender, EventArgs e)
        {
            xoaKM();
        }
    }
}
