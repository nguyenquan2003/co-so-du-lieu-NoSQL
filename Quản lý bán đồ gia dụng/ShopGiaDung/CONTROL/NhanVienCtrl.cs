using MongoDB.Bson;
using MongoDB.Driver;
using ShopGiaDung.MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopGiaDung.CONTROL
{
    internal class NhanVienCtrl
    {
        public DataTable LoadDLNV()
        {
            // Khởi tạo đối tượng ConnectNosql
            ConnectNosql connect = new ConnectNosql();

            // Danh sách các cột mong muốn hiển thị
            List<string> columns = new List<string> { "MaNV", "TenNV", "GioiTinh", "NgaySinh", "QueQuan", "SoDienThoai", "ChucVu", "TaiKhoan", "MatKhau"};

            // Gọi phương thức Load với các cột mong muốn
            DataTable dataTable = connect.Load("QLBH_KM", "NhanVien", columns);

            // Trả về DataTable để gán vào DataGridView
            return dataTable;
        }
        public NhanVienCtrl()
        {

        }

        public string layMaNV(DataGridView dataGridView, int cot)
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

        public bool themNV(NhanVien nv)
        {
            try
            {
                //MongoClient client = new ConnectNosql().connection();
                //var database = client.GetDatabase("QLBH_KM");

                //var collection = database.GetCollection<BsonDocument>("NhanVien");

                var collection = new ConnectNosql().Laycollection("QLBH_KM", "NhanVien");

                var document = new BsonDocument{
                { "MaNV", "NV" + new TaoMa().CreateCode(3)},
                { "TenNV", nv.tennv},
                { "GioiTinh", nv.gender},
                { "NgaySinh", nv.ngaysinh},
                { "QueQuan", nv.que},
                { "SoDienThoai", nv.sdt},
                { "ChucVu", nv.chucvu},
                { "TaiKhoan", nv.taiKhoan},
                { "MatKhau", nv.matKhau}
                };
                collection.InsertOne(document);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SuaNhanVien(NhanVien nv, string maNV)
        {
            bool kq = false;
            var collection = new ConnectNosql().Laycollection("QLBH_KM", "NhanVien");

            var filter = Builders<BsonDocument>.Filter.Eq("MaNV", maNV);
            //
            var update = Builders<BsonDocument>.Update
            .Set("TenNV", nv.tennv)
            .Set("GioiTinh", nv.gender)
            .Set("SoDienThoai", nv.sdt)
            .Set("QueQuan", nv.que)
            .Set("NgaySinh", nv.ngaysinh)
            .Set("ChucVu", nv.chucvu)
            .Set("TaiKhoan", nv.taiKhoan)
            .Set("MatKhau", nv.matKhau);

            //
            var result = collection.UpdateOne(filter, update);
            if (result.ModifiedCount > 0)
                kq = true;
            return kq;
        }
        public bool XoaNV(string maNV)
        {
            bool kq = false;
            var collection = new ConnectNosql().Laycollection("QLBH_KM", "NhanVien");

            var filter = Builders<BsonDocument>.Filter.Eq("MaNV", maNV);


            var result = collection.DeleteOne(filter);

            // Kiểm tra kết quả xóa
            if (result.DeletedCount > 0)
            {
                // Đã xóa thành công
                kq = true;
            }
            return kq;
        }
    }
}
