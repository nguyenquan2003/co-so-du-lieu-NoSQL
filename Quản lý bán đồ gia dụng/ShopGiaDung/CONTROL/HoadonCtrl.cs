using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Data;
using MongoDB.Bson;
using ShopGiaDung.MODEL;
using System.Text.RegularExpressions;

namespace ShopGiaDung.CONTROL
{
    class HoadonCtrl
    {
        public List<BsonDocument> LayHanghoa()
        {
            MongoClient client = new ConnectNosql().connection();
            var database = client.GetDatabase("QLBH_KM"); 
            var collection = database.GetCollection<BsonDocument>("SanPham");
            var filter = Builders<BsonDocument>.Filter.Empty; 
            var result = collection.Find(filter).ToList();
            return result;
        }

        public BsonDocument LayHanghoaTheoId(string Id)
        {
            MongoClient client = new ConnectNosql().connection();
            var database = client.GetDatabase("QLBH_KM");
            var collection = database.GetCollection<BsonDocument>("SanPham");
            var filter = Builders<BsonDocument>.Filter.Eq("MaSP", Id);
            var result = collection.Find(filter).FirstOrDefault();
            return result;
        }

        public bool IsPhoneNumberValid(string phoneNumber)
        {
            // Kiểm tra số điện thoại có đúng 10 chữ số và bắt đầu bằng số 0 hay không
            var regex = new Regex(@"^0\d{9}$");
            return regex.IsMatch(phoneNumber);
        }

        

        public void ThemHD(HoaDon HD )
        {
            MongoClient client = new ConnectNosql().connection();
            var database = client.GetDatabase("QLBH_KM");
            var collection = database.GetCollection<HoaDon>("DonHang");
            collection.InsertOne(HD);
        }


    }
}
