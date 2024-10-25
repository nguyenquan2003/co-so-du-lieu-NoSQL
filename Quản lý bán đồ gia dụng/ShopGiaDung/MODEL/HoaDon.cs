using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGiaDung.MODEL
{
    class HoaDon
    {
        string MaDH;
        DateTime NgayMua;
        int tongtien;
        List<SanPham> DSSP;
        Khachhang Khachhang;

        public string Madh { get => MaDH; set => MaDH = value; }
        public DateTime NgayMuaHang { get => NgayMua; set => NgayMua = value; }
        public int Tongtien { get => tongtien; set => tongtien = value; }
        public List<SanPham> SanPham { get => DSSP; set => DSSP = value; }
        public Khachhang KhachHang { get => Khachhang; set => Khachhang = value; }

        public HoaDon()
        { 
        
        }
    }
}
