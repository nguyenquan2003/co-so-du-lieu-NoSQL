using MongoDB.Bson;
using MongoDB.Driver;
using ShopGiaDung.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGiaDung.CONTROL
{
    public class QuaTangCtrl
    {

        public List<QuaTang> LayDanhSachQuaTang(string maKM)
        {
            var collectionCTR = new ConnectNosql().Laycollection("QLBH_KM", "CTR_KhuyenMai");

            // Tìm tất cả các bản ghi với MaKM tương ứng
            var filter = Builders<BsonDocument>.Filter.Eq("KhuyenMai.MaKM", maKM);
            var cursor = collectionCTR.Find(filter).ToCursor();

            List<QuaTang> danhSachQuaTang = new List<QuaTang>();

            foreach (var document in cursor.ToEnumerable())
            {
                // Lấy thông tin quà tặng từ document
                var quaTang = document["QuaTang"].AsBsonDocument;

                // Tạo đối tượng QuaTang
                QuaTang qt = new QuaTang
                {
                    MaQT = quaTang["MaQT"].AsString,
                    TenQT = quaTang["TenQT"].AsString,
                    MoTaQT = quaTang["MoTaQT"].AsString,
                    SoLuongQT = quaTang["SoLuongQT"].AsInt32
                };

                danhSachQuaTang.Add(qt);
            }

            return danhSachQuaTang;
        }

    }
}
