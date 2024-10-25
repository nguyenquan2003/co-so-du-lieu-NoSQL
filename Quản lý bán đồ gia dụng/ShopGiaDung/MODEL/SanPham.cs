using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGiaDung.MODEL
{
    public class SanPham
    {
        string MaSP, TenSP, TenAnh, MaKM;
        int soluong;
        int gia;
        double thanhtien;

        public string Tensp { get => TenSP; set => TenSP = value; }
        public string Tenanh { get => TenAnh; set => TenAnh = value; }
        public string Makm { get => MaKM; set => MaKM = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public int Gia { get => gia; set => gia = value; }
        public string Masp { get => MaSP; set => MaSP = value; }
        public double Thanhtien { get => thanhtien; set => thanhtien = value; }

        public SanPham()
        { }

        public SanPham(string tensp, string tenAnh , string maKM, int sl, int gia)
        {
            TenSP = tensp;
            TenAnh = tenAnh;
            MaKM = maKM;
            soluong = sl;
            this.gia = gia;
            
        }
    }
}
