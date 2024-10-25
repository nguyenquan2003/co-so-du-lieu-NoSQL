using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MongoDB.Bson;
using ShopGiaDung.MODEL;
using MongoDB.Driver;

namespace ShopGiaDung.CONTROL
{
    public class SanPhanCtrl
    {
        //public DataTable LoadDLSP()
        //{
        //    return new ConnectNosql().Load("QLBH_KM", "SanPham");
        //}

        public DataTable LoadDLSP()
        {
            // Khởi tạo đối tượng ConnectNosql
            ConnectNosql connect = new ConnectNosql();

            // Danh sách các cột mong muốn hiển thị
            List<string> columns = new List<string> { "MaSP", "TenSP", "Gia", "Soluong", "Giamgia", "MaKM", "HinhAnh"};

            // Gọi phương thức Load với các cột mong muốn
            DataTable dataTable = connect.Load("QLBH_KM", "SanPham", columns);

            // Trả về DataTable để gán vào DataGridView
            return dataTable;
        }

        public int laySoluong(string MASP)
        {
            int tmp = 0;
            try
            {
                var collection = new ConnectNosql().Laycollection("QLBH_KM", "SanPham");
                var filter = Builders<BsonDocument>.Filter.Eq("MaSP", MASP);
                BsonDocument value = collection.Find(filter).FirstOrDefault();
                var kq = value.GetElement("Soluong").Value.ToInt32();
                tmp = kq;
            }
            catch (Exception ex) { }
            return tmp;
        }
        public bool XoaSanPham(string maSP)
        {
            bool kq = false;
            var collection = new ConnectNosql().Laycollection("QLBH_KM", "SanPham");
            var filter = Builders<BsonDocument>.Filter.Eq("MaSP", maSP);
            var result = collection.DeleteOne(filter);

            // Kiểm tra kết quả xóa
            if (result.DeletedCount > 0)
            {

                // Đã xóa thành công
                kq = true;
            }
            return kq;
        }
        public bool SuaSanPham(SanPham SP)
        {
            bool kq = false;
            var collection = new ConnectNosql().Laycollection("QLBH_KM", "SanPham");

            var filter = Builders<BsonDocument>.Filter.Eq("MaSSP", SP.Masp);

            var result = collection.Find(filter).FirstOrDefault();


            int giamgia = new KhyenMaiCtrl().PhanTramGiam(SP.Makm);
            string tenanh = "";
            if (SP.Tenanh == "")
                tenanh = result.GetValue("TenAnh").ToString();
            else
                tenanh = SP.Tenanh;
            var update = Builders<BsonDocument>.Update
            .Set("TenSP", SP.Tensp)
            .Set("Gia", SP.Gia)
            .Set("Soluong", SP.Soluong)
            .Set("HinhAnh", tenanh)
            .Set("Giamgia", giamgia)
            .Set("MaKM", SP.Makm);
            // Cập nhật một đối tượng

            var RS = collection.UpdateOne(filter, update);
            if (RS.ModifiedCount > 0)
                kq = true;
            return kq;
        }
        public void tinhThanhTien(string maSP)
        { 
            
        }
        public bool ThemSP(SanPham SP)
        {
            try
            {
                MongoClient client = new ConnectNosql().connection();
                var database = client.GetDatabase("QLBH_KM");
                var collection = database.GetCollection<BsonDocument>("SanPham");
                int giamgia = new KhyenMaiCtrl().PhanTramGiam(SP.Makm.Trim());
                var document = new BsonDocument{
                { "MaSP", "SP"+new TaoMa().CreateCode(3)},
                { "TenSP", SP.Tensp},
                { "Gia", SP.Gia},
                { "Soluong", SP.Soluong},
                { "HinhAnh", SP.Tenanh},
                { "Giamgia", giamgia},
                { "MaKM", SP.Makm.Trim()}

            };
                collection.InsertOne(document);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }
    }
}
