using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGiaDung.MODEL
{
    public class Khuyenmai
    {
        string Machuongtrinh, Tenkhuyenmai, Maquatang, tenqua;
        DateTime Ngaybatdau, Ngayketthuc;
        int PhantramGiam, Soluongqua;

        public string Machuongtrinh1 { get => Machuongtrinh; set => Machuongtrinh = value; }
        public string Tenkhuyenmai1 { get => Tenkhuyenmai; set => Tenkhuyenmai = value; }
        public string Maquatang1 { get => Maquatang; set => Maquatang = value; }
        public DateTime Ngaybatdau1 { get => Ngaybatdau; set => Ngaybatdau = value; }
        public DateTime Ngayketthuc1 { get => Ngayketthuc; set => Ngayketthuc = value; }
        public int PhantramGiam1 { get => PhantramGiam; set => PhantramGiam = value; }
        public int Soluongqua1 { get => Soluongqua; set => Soluongqua = value; }
        public string Tenqua { get => tenqua; set => tenqua = value; }

        public Khuyenmai()
        { }
    }
}
