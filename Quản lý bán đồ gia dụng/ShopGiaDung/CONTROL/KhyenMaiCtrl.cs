using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Data;
using MongoDB.Bson;
using ShopGiaDung.MODEL;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Runtime.Remoting.Contexts;
using System.Collections.ObjectModel;

namespace ShopGiaDung.CONTROL
{
    public class KhyenMaiCtrl
    {
        public DataTable LoadKM()
        {
            // Khởi tạo đối tượng ConnectNosql
            ConnectNosql connect = new ConnectNosql();

            // Danh sách các cột mong muốn hiển thị
            List<string> columns = new List<string> { "MaCT", "TenCTR", "TrangThai", "NgayBatDau", "NgayKetThuc", "KhuyenMai", "QuaTang" };

            // Gọi phương thức Load với các cột mong muốn
            DataTable dataTable = connect.Load("QLBH_KM", "CTR_KhuyenMai", columns);

            // Tạo một DataTable mới với các cột cần thiết
            DataTable filteredTable = new DataTable();
            filteredTable.Columns.Add("MaCT");
            filteredTable.Columns.Add("TenCTR");
            filteredTable.Columns.Add("TrangThai");
            filteredTable.Columns.Add("NgayBatDau");
            filteredTable.Columns.Add("NgayKetThuc");
            filteredTable.Columns.Add("TenKM"); // Thay thế KhuyenMai bằng TenKM
           
            filteredTable.Columns.Add("TenQT");

            // Lọc dữ liệu và thêm vào DataTable mới
            foreach (DataRow row in dataTable.Rows)
            {
                DataRow newRow = filteredTable.NewRow();
                newRow["MaCT"] = row["MaCT"];
                newRow["TenCTR"] = row["TenCTR"];
                newRow["TrangThai"] = row["TrangThai"];
                newRow["NgayBatDau"] = row["NgayBatDau"];
                newRow["NgayKetThuc"] = row["NgayKetThuc"];

                // Lấy giá trị TenKM trực tiếp từ JSON
                newRow["TenKM"] = JsonConvert.DeserializeObject<dynamic>(row["KhuyenMai"].ToString())?.TenKM;
               
                // Lấy giá trị TenQT từ QuaTang
                newRow["TenQT"] = JsonConvert.DeserializeObject<dynamic>(row["QuaTang"].ToString())?.TenQT;
                filteredTable.Rows.Add(newRow);
            }

            // Trả về DataTable đã lọc để gán vào DataGridView
            return filteredTable;
        }
        public bool ThemKM(Khuyenmai Km)
        {
            bool kq = false;
            MongoClient client = new ConnectNosql().connection();
            var database = client.GetDatabase("QLBH_KM");
            var collection = database.GetCollection<BsonDocument>("CTR_KhuyenMai");

            var document = new BsonDocument{
                { "MaCT", new TaoMa().CreateCode(4)},
                { "TenCTR", Km.Machuongtrinh1},
                { "TrangThai", true},
                { "NgayBatDau", Km.Ngaybatdau1},
                { "NgayKetThuc", Km.Ngayketthuc1},
                { "KhuyenMai", new BsonDocument{ { "MaKM", new TaoMa().CreateCode(5)},{ "TenKM", Km.Tenkhuyenmai1},{ "MoTaKM", "" }, { "Mucgiam", Km.PhantramGiam1} } },
                { "QuaTang", new BsonDocument{ { "MaQT", Km.Maquatang1}, { "TenQT", Km.Tenqua },{ "MoTaQT", "" }, { "HinhAnhQT", ""}, { "SoLuongQT", Km.Soluongqua1} } }

            };
            collection.InsertOne(document);
            return true;
        }
        //trả về phần trăm giảm
        public int PhanTramGiam(string MGiamGia)
        {
            int tmp = 0;
            try
            {
                var collection = new ConnectNosql().Laycollection("QLBH_KM", "CTR_KhuyenMai");
                var filter = Builders<BsonDocument>.Filter.Eq("KhuyenMai.MaKM", MGiamGia);
                BsonDocument value = collection.Find(filter).FirstOrDefault();
                var kq = value.GetElement("KhuyenMai").Value.AsBsonDocument;
                tmp = kq.GetElement("MucGiam").Value.AsInt32;
            }
            catch (Exception ex) { }
            return tmp;
        }

        //lấy mãCTR từ gridvikew
        public string layMaCTR(DataGridView dataGridView, int cot)
        {
            string duLieu = string.Empty;
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow dong = dataGridView.SelectedRows[0];

                // Kiểm tra dòng cuối cùng không rỗng
                if (dong.Index != dataGridView.Rows.Count - 1)
                {
                    if (dong.Cells[cot].Value != null)
                    {
                        duLieu = dong.Cells[cot].Value.ToString();
                    }
                }
            }
            return duLieu;
        }
        //lấy mã giảm theo sản phẩm
        public string layMaGiam(string MASP)
        {
            string tmp = "";
            try
            {
                var collection = new ConnectNosql().Laycollection("QLBH_KM", "SanPham");
                var filter = Builders<BsonDocument>.Filter.Eq("MaSP", MASP);
                BsonDocument value = collection.Find(filter).FirstOrDefault();
                tmp = value.GetValue("MaKM").ToString();
            }
            catch (Exception ex) { }
            return tmp;
        }

        //Lấy tất cả mã giảm trong các Ctr khuyến mãi
        public DataTable LayMaGiam()
        {
            var collection = new ConnectNosql().Laycollection("QLBH_KM", "CTR_KhuyenMai");
            DataTable dtb = new DataTable();
            dtb.Columns.Add("MaKM");
            dtb.Columns.Add("TenKM");

            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(filter).ToList();

            foreach (var document in result)
            {
                var value = document.GetElement("KhuyenMai").Value.AsBsonDocument;
                string Ten = value.GetValue("TenKM").AsString;
                string Ma = value.GetValue("MaKM").AsString;
                dtb.Rows.Add(Ma, Ten);
            }
            return dtb;
        }
        //trả về số lượng CTrKM hiện có
        public int soluongCtrKM()
        {
            var collection = new ConnectNosql().Laycollection("QLBH_KM", "CTR_KhuyenMai");
            var count = collection.CountDocuments(FilterDefinition<BsonDocument>.Empty);
            return (int)count;
        }

        //lấy danh sách quà tặng load vào combobox
        public DataTable LoadQuaTang()
        {
            ConnectNosql connect = new ConnectNosql();

            // Danh sách các cột mong muốn hiển thị
            List<string> columns = new List<string> { "MaQT", "TenQT"};

            // Gọi phương thức Load với các cột mong muốn
            DataTable dataTable = connect.Load("QLBH_KM", "QuaTang", columns);
            return dataTable;
        }

        public DataTable LoadKhuyenMai()
        {
            ConnectNosql connect = new ConnectNosql();

            // Danh sách các cột mong muốn hiển thị
            List<string> columns = new List<string> { "KhuyenMai" };

            // Gọi phương thức Load với các cột mong muốn
            DataTable dataTable = connect.Load("QLBH_KM", "CTR_KhuyenMai", columns);

            // Tạo DataTable mới để chứa dữ liệu đã được lọc
            DataTable khuyenMaiTable = new DataTable();
            khuyenMaiTable.Columns.Add("MaKM");
            khuyenMaiTable.Columns.Add("TenKM");

            // Lọc dữ liệu và thêm vào DataTable mới
            foreach (DataRow row in dataTable.Rows)
            {
                // Giả sử cột KhuyenMai chứa dữ liệu JSON
                string khuyenMaiJson = row["KhuyenMai"].ToString();

                // Giải mã JSON thành Dictionary
                var khuyenMaiData = JsonConvert.DeserializeObject<Dictionary<string, object>>(khuyenMaiJson);

                // Tạo một hàng mới trong DataTable
                DataRow newRow = khuyenMaiTable.NewRow();

                // Lấy giá trị từ khuyến mãi
                newRow["MaKM"] = khuyenMaiData.ContainsKey("MaKM") ? khuyenMaiData["MaKM"] : string.Empty;
                newRow["TenKM"] = khuyenMaiData.ContainsKey("TenKM") ? khuyenMaiData["TenKM"] : string.Empty;

                // Thêm hàng mới vào DataTable
                khuyenMaiTable.Rows.Add(newRow);
            }

            // Trả về DataTable chứa dữ liệu khuyến mãi
            return khuyenMaiTable;
        }


        //lấy data cho combobox Khuyến mãi
        public DataTable LayComboboxKhuyenmai(string[] masp, int tongtien)
        {

            var chuongTrinhKhuyenMaiCollection = new ConnectNosql().Laycollection("QLBH_KM", "CTR_KhuyenMai");


            DataTable dtb = new DataTable();
            dtb.Columns.Add("MaCT");
            dtb.Columns.Add("TenCTR");
            // Duyệt qua kết quả truy vấn

            var currentDate = DateTime.Now;
            var filter = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Lte("NgayBatDau", currentDate),
                Builders<BsonDocument>.Filter.Gte("NgayKetThuc", currentDate)
            );
            var promotions = chuongTrinhKhuyenMaiCollection.Find(filter).ToList();


            foreach (var document in promotions)
            {
                var documentvalue = document.GetElement("QuaTang").Value.AsBsonDocument;
                string code = documentvalue.GetValue("MaQT").AsString;
                string Name = documentvalue.GetValue("TenQT").AsString;
                int MucNhan = documentvalue.GetValue("MucNhan").ToInt32();
                if (tongtien >= MucNhan)
                    dtb.Rows.Add(code, Name);
            }
            return dtb;
        }


        //Hàm Sửa thông tin khuyến mãi: 
        public bool SuaKhuyenMai(Khuyenmai KM, string maCTR)
        {
            bool kq = false;
            var collection = new ConnectNosql().Laycollection("QLBH_KM", "CTR_KhuyenMai");

            var filter = Builders<BsonDocument>.Filter.Eq("MaCT", maCTR);
            //Lấy document KhuyenMai:
            var valueTMP = collection.Find(filter).FirstOrDefault();
            var KhuyenMai = valueTMP.GetValue("KhuyenMai").ToBsonDocument();
            var Quatang = valueTMP.GetValue("QuaTang").ToBsonDocument();
            //        "MaQT": "QT002",
            //"TenQT": "Nồi áp xuất 2 tầng BKS",
            //"MoTaQT": "Nối áp xuất giá 150.000 Đ",
            //"HinhAnhQT": null,
            //"MucNhan": 650000,
            //"SoLuongQT": 1
            // Tạo một đối tượng mới đại diện cho thông tin đã được sửa
            var update = Builders<BsonDocument>.Update
            .Set("TenCTR", KM.Machuongtrinh1)
            .Set("NgayBatDau", KM.Ngaybatdau1)
            .Set("NgayKetThuc", KM.Ngayketthuc1)
            .Set("KhuyenMai", new BsonDocument { 
                { "MaKM", KhuyenMai.GetValue("MaKM").ToString() },
                { "TenKM", KM.Tenkhuyenmai1 }, 
                { "MoTaKM", KhuyenMai.GetValue("MoTaKM").ToString() }, 
                { "MucGiam", KM.PhantramGiam1 } })
            .Set("QuaTang", new BsonDocument {
                { "MaQT", KM.Maquatang1 },
                { "TenQT", Quatang.GetValue("TenQT").ToString()},
                { "MoTaQT", Quatang.GetValue("MoTaQT").ToString()},
                { "HinhAnhQT", Quatang.GetValue("HinhAnhQT").ToString()},               
                { "SoLuongQT", KM.Soluongqua1 }
            });
            // Cập nhật một đối tượng
            var result = collection.UpdateOne(filter, update);
            if (result.ModifiedCount > 0)
                kq = true;
            return kq;
        }

        //Hàm xóa khuyến mãi: 
        public bool XoaKM(string  maCTR)
        {
            bool kq = false;
            var collection = new ConnectNosql().Laycollection("QLBH_KM", "CTR_KhuyenMai");
            var filter = Builders<BsonDocument>.Filter.Eq("MaCT", maCTR);
            var result = collection.DeleteOne(filter);

            // Kiểm tra kết quả xóa
            if (result.DeletedCount > 0)
            {
                // Đã xóa thành công
                kq = true;
            }
            return kq;
        }

        public (string TenKM, double MucGiam, string TenQT, int SoLuongQT) LayThongTinKhuyenMai(string maKM)
        {
            // Tạo bộ lọc để tìm kiếm document có MaKM
            var collection = new ConnectNosql().Laycollection("QLBH_KM", "CTR_KhuyenMai");
            var filter = Builders<BsonDocument>.Filter.Eq("KhuyenMai.MaKM", maKM);

            // Tìm document đầu tiên khớp với MaKM
            var result = collection.Find(filter).FirstOrDefault();

            if (result != null)
            {
                // Lấy trường TenKM và MucGiam từ KhuyenMai
                var tenKM = result["KhuyenMai"]["TenKM"].AsString;
                int mucGiam = result["KhuyenMai"]["MucGiam"].AsInt32; // Nếu MucGiam có kiểu double

                // Lấy TenQT và SoLuongQT từ QuaTang
                var quaTang = result["QuaTang"];
                string tenQT = quaTang["TenQT"].AsString; // Lấy TenQT
                int soLuongQT = quaTang["SoLuongQT"].AsInt32; // Lấy SoLuongQT

                return (tenKM, mucGiam, tenQT, soLuongQT); // Trả về tuple chứa các trường
            }
            else
            {
                return (null, 0, null, 0); // Trả về tuple với các trường null hoặc 0 nếu không tìm thấy
            }
        }


    }
}
