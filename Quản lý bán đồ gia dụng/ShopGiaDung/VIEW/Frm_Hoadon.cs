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
using MongoDB.Driver;
namespace ShopGiaDung.VIEW
{
    public partial class Frm_Hoadon : Form
    {
        DataTable dataTable = new createdtataTable().createDTB();

        public Frm_Hoadon()
        {
            InitializeComponent();
           
            // Ẩn nút thu nhỏ (Minimize)
            this.MaximizeBox = false;
            // Đặt form ở chế độ toàn màn hình
            this.WindowState = FormWindowState.Maximized;
        }

        private void Frm_Hoadon_Load(object sender, EventArgs e)
        {
            LoadProductData();
        }

        private void InHD()
        {
            printPreviewDialog_hoadon.Document = printDocument_Hoadon;
            printPreviewDialog_hoadon.ShowDialog();
        }


        private void LoadProductData()
        {
            var bson = new HoadonCtrl().LayHanghoa();
            foreach (var doccument in bson)
            {
                // Duyệt qua từng dòng dữ liệu
                //foreach (DataRow row in productDataTable.Rows)
                //{
                // Tạo card chứa thông tin sản phẩm
                Panel cardPanel = new Panel();
                cardPanel.BorderStyle = BorderStyle.FixedSingle;
                cardPanel.Size = new Size(200, 180);
                cardPanel.BackColor = Color.LightGray;
                cardPanel.Margin = new Padding(10);

                // Tạo hình ảnh sản phẩm
                PictureBox productPictureBox = new PictureBox();
                try
                {

                    Image imageFromFile = Image.FromFile(@"D:\SinhVienHUIT\HocKi7\CoSoDuLieu_NoSQL\ShopGiaDung\Image\" + doccument.GetValue("HinhAnh").ToString());
                    productPictureBox.Image = imageFromFile;
                }
                catch (Exception ex) { }


                productPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                productPictureBox.Size = new Size(100, 80);
                productPictureBox.Location = new Point(10, 50);
                cardPanel.Controls.Add(productPictureBox);

                // Tạo tên sản phẩm
                Label nameLabel = new Label();
                BsonValue value = doccument.GetValue("TenSP");
                nameLabel.Text = value.ToString();
                nameLabel.Size = new Size(200, 20);
                nameLabel.Location = new Point(0, 10);
                cardPanel.Controls.Add(nameLabel);

                Button addButton = new Button();
                addButton.Text = "Thêm";
                addButton.Size = new Size(60, 20);
                addButton.Location = new Point(120, 70);
                addButton.Click += AddButton_Click;
                BsonValue Masp = doccument.GetValue("MaSP");
                addButton.Tag = Masp.ToString();
                cardPanel.Controls.Add(addButton);

                // Tạo giá sản phẩm
                Label priceLabel = new Label();
                BsonValue Gia = doccument.GetValue("Gia");
                priceLabel.Text = Gia.ToString();
                priceLabel.Size = new Size(200, 20);
                priceLabel.Location = new Point(120, 45);
                cardPanel.Controls.Add(priceLabel);


                flowLayoutPanel_DSHangHoa.Controls.Add(cardPanel);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string maSP = (string)((Button)sender).Tag;
            LoadProductData(maSP, dataTable);
        }
        private void LoadProductData(string productID, DataTable dtb)
        {
            // Kiểm tra và thêm cột "GiamGia" nếu chưa tồn tại
            if (!dtb.Columns.Contains("GiamGia"))
            {
                dtb.Columns.Add("GiamGia", typeof(double));  // Thêm cột giảm giá với kiểu dữ liệu là double
            }


            // Code để load thông tin sản phẩm có ID tương ứng vào DataTable
            // Ví dụ: Lấy thông tin từ CSDL 

            int kq = 0;
            int sl = new SanPhanCtrl().laySoluong(productID);
            int phanTramGiam = new KhyenMaiCtrl().PhanTramGiam(new KhyenMaiCtrl().layMaGiam(productID));

            if (dtb != null)
                foreach (DataRow row in dtb.Rows)
                {
                    // Lấy giá trị trong cột "ID" của mỗi dòng
                    string rowProductID = row["ID"].ToString();


                    // Kiểm tra xem ID của dòng hiện tại có trùng với productID không
                    if (rowProductID == productID)
                    {
                        int currentQuantity = Convert.ToInt32(row["SoLuong"]);

                        if (currentQuantity > sl)
                        {
                            kq = -1;
                        }
                        else
                        {
                            kq = 1;
                            row["SoLuong"] = currentQuantity + 1;
                            double giam = Int32.Parse(row["Gia"].ToString()) * (phanTramGiam * 0.01);

                            // Tính giảm giá
                           
                            row["GiamGia"] = giam;  // Lưu số tiền giảm giá vào cột "GiamGia"


                            int tongtien = (Int32.Parse(row["Gia"].ToString()) - (int)giam) * Int32.Parse(row["SoLuong"].ToString());
                            row["ThanhTien"] = tongtien;
                        }
                        // Nếu trùng, thực hiện tăng giá trị trong cột "Số lượng" lên một
                        break;
                    }
                }

            if (kq == 0)
            {
                DataRow newRow = dtb.NewRow();
                var bson = new HoadonCtrl().LayHanghoaTheoId(productID);
                newRow["ID"] = productID;
                newRow["TenSP"] = bson.GetValue("TenSP").ToString();
                newRow["Gia"] = bson.GetValue("Gia").ToString();
                newRow["SoLuong"] = 1;

                // Tính giảm giá cho sản phẩm mới
                double giam = Int32.Parse(bson.GetValue("Gia").ToString()) * (phanTramGiam * 0.01);
                newRow["GiamGia"] = giam;  // Lưu số tiền giảm giá vào cột "GiamGia"
                newRow["ThanhTien"] = (Int32.Parse(bson.GetValue("Gia").ToString()) - (int)giam) * Int32.Parse(newRow["SoLuong"].ToString());
                dtb.Rows.Add(newRow);
            }
            else if (kq == -1)
            {
                MessageBox.Show("Đã hết hàng!!!");
            }

            // Đặt DataTable làm nguồn dữ liệu cho DataGridView
            dataGridView_danhsachmuahang.DataSource = dtb;
        }

        private void button_bohang_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView_danhsachmuahang.SelectedRows.Count > 0)
                {
                    // Lặp qua tất cả các hàng đã chọn
                    foreach (DataGridViewRow row in dataGridView_danhsachmuahang.SelectedRows)
                    {
                        // Xóa hàng đã chọn
                        dataGridView_danhsachmuahang.Rows.Remove(row);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có hàng nào được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi!!!!");
            }

        }

        public bool loadCOmboKM()
        {
            var data = new KhyenMaiCtrl().LayComboboxKhuyenmai(GetSP(), tinhTongtien());

            if (data == null || data.Rows.Count == 0)
                return false;
            else
            {
                comboBox_Khuyenmai.DataSource = data;
                comboBox_Khuyenmai.DisplayMember = "TenCTR";
                comboBox_Khuyenmai.ValueMember = "MaCT";
                return true;
            }
        }

        private string[] GetSP()
        {
            // Xác định cột đầu tiên trong DataGridView
            DataGridViewColumn firstColumn = dataGridView_danhsachmuahang.Columns[0];

            // Tạo một List<string> để lưu giá trị của cột đầu
            List<string> values = new List<string>();

            // Duyệt qua từng dòng trong DataGridView
            foreach (DataGridViewRow row in dataGridView_danhsachmuahang.Rows)
            {
                // Kiểm tra nếu có giá trị trong cột đầu của dòng hiện tại
                if (row.Cells[firstColumn.Index].Value != null)
                {
                    // Lấy giá trị từ cột đầu của dòng hiện tại và thêm vào List<string>
                    string value = row.Cells[firstColumn.Index].Value.ToString().Trim();
                    values.Add(value);
                }
            }

            // Chuyển đổi List<string> thành một mảng chuỗi và trả về
            return values.ToArray();
        }



        private void flowLayoutPanel_DSHangHoa_Paint(object sender, PaintEventArgs e)
        {

        }

        private int tinhTongtien()
        {
            // Xác định cột số lượng và giá sản phẩm 
            DataGridViewColumn firstColumn = dataGridView_danhsachmuahang.Columns[4];
            int tongGia = 0;
            // Tạo một List<string> để lưu giá trị của cột đầu
            List<string> values = new List<string>();

            // Duyệt qua từng dòng trong DataGridView
            foreach (DataGridViewRow row in dataGridView_danhsachmuahang.Rows)
            {
                // Kiểm tra nếu có giá trị trong cột đầu của dòng hiện tại
                if (row.Cells[firstColumn.Index].Value != null)
                {
                    // Lấy giá trị từ cột đầu của dòng hiện tại và thêm vào List<string>
                    int Gia = Int32.Parse(row.Cells[firstColumn.Index].Value.ToString().Trim());
                    tongGia += Gia;
                }
            }

            // Chuyển đổi List<string> thành một mảng chuỗi và trả về

            return tongGia;
        }

        private void button_timkhuyenmai_Click(object sender, EventArgs e)
        {
            try
            {
                if (loadCOmboKM() == false)
                    MessageBox.Show("Không tìm thấy!!!");
            }
            catch (Exception ex) { }
        }
        private List<SanPham> layDSSP()
        {
            List<SanPham> dsSSP = new List<SanPham>();
            foreach (DataGridViewRow row in dataGridView_danhsachmuahang.Rows)
            {
                SanPham SP = new SanPham();
                // Kiểm tra nếu hàng không phải là hàng Header hoặc hàng mới thêm (NewRow)
                if (!row.IsNewRow && row.Index != -1)
                {

                    // Lấy dữ liệu từ cột 1 (column index = 0)
                    string MaSP = row.Cells[0].Value.ToString();

                    // Lấy dữ liệu từ cột 2 (column index = 1)
                    string TenSP = row.Cells[1].Value.ToString();

                    // Lấy dữ liệu từ cột 3 (column index = 2)
                    int Gia = int.Parse(row.Cells[2].Value.ToString());

                    int Soluong = int.Parse(row.Cells[3].Value.ToString());
                    double thanhtien = double.Parse(row.Cells[4].Value.ToString());

                    // ... và tiếp tục lấy dữ liệu từ các cột khác nếu cần

                    // Xử lý dữ liệu đã lấy được từ mỗi hàng và từng cột tương ứng ở đây
                    SP.Masp = MaSP;
                    SP.Tensp = TenSP;
                    SP.Gia = Gia;
                    SP.Soluong = Soluong;
                    SP.Makm = new KhyenMaiCtrl().layMaGiam(MaSP);
                    SP.Thanhtien = thanhtien;
                    dsSSP.Add(SP);
                }
            }
            return dsSSP;
        }

        string maHD = "HD" + new TaoMa().CreateCode(3);
        private void button_Thanhtoan_Click(object sender, EventArgs e)
        {
            bool checkSDT = new HoadonCtrl().IsPhoneNumberValid(textBox_SDT.Text.Trim());

            if (checkSDT)
            {
                HoaDon HD = new HoaDon();
                HD.NgayMuaHang = DateTime.Now;
                HD.Madh = maHD;
                HD.KhachHang = new KhachhangCTR().taoKH(textBox_SDT.Text.Trim());
                HD.Tongtien = tinhTongtien();
                HD.SanPham = layDSSP();
                new HoadonCtrl().ThemHD(HD);
                textBox_tongtien.Text = tinhTongtien().ToString();
                InHD();
            }
            else
            {
                MessageBox.Show("Hoàn thành nhập chính xác SDT để thêm hóa Đơn!!!!");
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string TenHD = "HÓA ĐƠN TÍNH TIỀN ECOSHOP";
            DateTime Ngaytinh = DateTime.Now;
            List<SanPham> dssp = layDSSP();
            double tongtien = tinhTongtien();
            var width = printDocument_Hoadon.DefaultPageSettings.PaperSize.Width;

            e.Graphics.DrawString(TenHD.ToUpper(), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(50, 20));
            e.Graphics.DrawString(String.Format("{0}", maHD), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(width / 2 + 200, 20));
            e.Graphics.DrawString(String.Format("Ngày lập: {0}", Ngaytinh.ToString("dd/MM/yyyy")), new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(width / 2 + 200, 50));
            Pen blackpen = new Pen(Color.Black, 1);
            int heigh = 100;
            Point P1 = new Point(10, heigh);
            Point P2 = new Point(width - 10, heigh);
            e.Graphics.DrawLine(blackpen, P1, P2);
            heigh += 40;
            e.Graphics.DrawString("Tên SP", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(10, heigh));
            e.Graphics.DrawString("Số lượng", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(300, heigh));
            e.Graphics.DrawString("Giá", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(width / 2, heigh));
            e.Graphics.DrawString("Giảm giá", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(width / 2 + 100, heigh)); // Thêm cột giảm giá
            e.Graphics.DrawString("Thành tiền", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(width / 2 + 200, heigh));

            // Sử dụng Dictionary để gom các sản phẩm có cùng mã sản phẩm
            Dictionary<string, SanPham> sanPhamDict = new Dictionary<string, SanPham>();

            foreach (var sp in dssp)
            {
                if (sanPhamDict.ContainsKey(sp.Masp))
                {
                    // Cộng dồn số lượng và thành tiền nếu sản phẩm đã tồn tại
                    sanPhamDict[sp.Masp].Soluong += sp.Soluong;
                    sanPhamDict[sp.Masp].Thanhtien += sp.Thanhtien;
                }
                else
                {
                    // Thêm sản phẩm mới vào Dictionary
                    sanPhamDict[sp.Masp] = sp;
                }
            }

            // Duyệt qua các sản phẩm đã gom
            foreach (var sp in sanPhamDict.Values)
            {
                heigh += 40;
                string maKM = new KhyenMaiCtrl().layMaGiam(sp.Masp); // Lấy mã khuyến mãi của sản phẩm
                int giamgia = new KhyenMaiCtrl().PhanTramGiam(maKM); // Lấy phần trăm giảm giá
                double tienGiamGia = (sp.Gia * sp.Soluong * giamgia) / 100; // Tính số tiền giảm giá
                double thanhTienSauGiam = sp.Thanhtien; // Tính thành tiền sau khi giảm giá

                // In thông tin sản phẩm
                e.Graphics.DrawString(sp.Tensp, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(10, heigh));
                e.Graphics.DrawString(sp.Soluong.ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(300, heigh));
                e.Graphics.DrawString(sp.Gia.ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(width / 2, heigh));
                e.Graphics.DrawString(tienGiamGia.ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(width / 2 + 100, heigh)); // In tiền giảm giá
                e.Graphics.DrawString(thanhTienSauGiam.ToString(), new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new Point(width / 2 + 200, heigh)); // In thành tiền sau giảm giá

                // Nếu có quà tặng, in danh sách quà tặng
                List<QuaTang> danhSachQuaTang = new QuaTangCtrl().LayDanhSachQuaTang(maKM);
                if (danhSachQuaTang.Count > 0)
                {
                    heigh += 20; // Tạo khoảng cách cho quà tặng
                    e.Graphics.DrawString("Quà tặng:", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(50, heigh));

                    foreach (var qt in danhSachQuaTang)
                    {
                        heigh += 20;
                        e.Graphics.DrawString($"- {qt.TenQT} (Số lượng: {qt.SoLuongQT})", new Font("Arial", 10, FontStyle.Italic), Brushes.Black, new Point(70, heigh));
                    }
                }
            }

            heigh += 40;
            e.Graphics.DrawLine(blackpen, new Point(10, heigh), new Point(width - 10, heigh));
            heigh += 40;
            e.Graphics.DrawString("Tổng tiền: " + tongtien + " VND", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(width - 300, heigh));

            e.Graphics.DrawString("Khách hàng: " + textBox_SDT.Text, new Font("Arial", 15, FontStyle.Bold), Brushes.Black, new Point(10, heigh));

            heigh += 50;

            e.Graphics.DrawString("Cảm ơn quý khách đã mua hàng tại EcoSHOP!!", new Font("Verdana", 20, FontStyle.Italic), Brushes.Black, new Point(10, heigh));
        }

        private void comboBox_Khuyenmai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Khuyenmai.SelectedIndex != -1)
            {
                string selectedData = comboBox_Khuyenmai.Text.Trim().ToString();
                //textBox_QuaTang.Text = selectedData;
            }
        }

        private void dataGridView_danhsachmuahang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin từ dòng được chọn
                DataGridViewRow selectedRow = dataGridView_danhsachmuahang.Rows[e.RowIndex];

                // Lấy mã sản phẩm từ ô tương ứng (giả sử cột chứa mã sản phẩm là cột "ID")
                string productID = selectedRow.Cells["ID"].Value.ToString();  // Chỉnh sửa tên cột cho phù hợp

                string maKM = new KhyenMaiCtrl().layMaGiam(productID);

                // Sử dụng MaKM để lấy TenCT của chương trình khuyến mãi
                var (tenCT, mucGiam, tenQT, soLuongQT) = new KhyenMaiCtrl().LayThongTinKhuyenMai(maKM);

                // Hiển thị thông tin lên các textbox
                txtTenKM.Text = tenCT ?? "Không có thông tin"; // Kiểm tra null
                txtMucGiam.Text = mucGiam > 0 ? mucGiam.ToString() + "%" : "Không có giảm giá"; // Kiểm tra mức giảm giá
                txtTenQuaTang.Text = tenQT ?? "Không có thông tin";
                txtSoLuongQT.Text = soLuongQT.ToString(); // Kiểm tra mức giảm giá
            }
        }

    }
}
