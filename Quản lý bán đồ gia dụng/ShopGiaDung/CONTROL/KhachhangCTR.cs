using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopGiaDung.MODEL;
using MongoDB.Bson;
using MongoDB.Driver;
namespace ShopGiaDung.CONTROL
{
    public class KhachhangCTR
    {
        public string layMaKH(string SDT)
        {

            string maKH = "";
            try
            {
                var collection = new ConnectNosql().Laycollection("QLBH_KM", "DonHang");
                var filter = Builders<BsonDocument>.Filter.Eq("KhachHang.SDT", SDT);
                BsonDocument value = collection.Find(filter).FirstOrDefault();
                if (value != null)
                {
                    BsonDocument kq = value.GetElement("KhachHang").Value.AsBsonDocument;
                    maKH = kq.GetElement("MaKH").Value.ToString().Trim();
                }
                else
                    maKH = "";
                   
            }
            catch (Exception ex) { }
            return maKH;

        }

        public Khachhang taoKH(string SDT)
        {
            Khachhang KH = new Khachhang();
            try
            {
                string macu = layMaKH(SDT);
                string mamoi = "";
                if (macu != "")
                {
                    mamoi = macu;
                }
                else
                    mamoi = "KH" + new TaoMa().CreateCode(3);


                KH.MaKH = mamoi;
                KH.SDT = SDT;

            }
            catch (Exception ex) { }


            return KH;

        }


    }
}
