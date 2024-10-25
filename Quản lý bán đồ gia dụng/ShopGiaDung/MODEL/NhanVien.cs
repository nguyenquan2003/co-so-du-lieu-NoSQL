using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopGiaDung.MODEL
{
    public class NhanVien
    {
        string maNV, tenNV, gioiTinh, queQuan, sDT;
        DateTime ngaySinh;

        public string manv { get => maNV; set => maNV = value; }
        public string tennv { get => tenNV; set => tenNV = value; }
        public string gender { get => gioiTinh; set => gioiTinh = value; }
        public string que { get => queQuan; set => queQuan = value; }
        public string sdt { get => sDT; set => sDT = value; }
        public DateTime ngaysinh { get => ngaySinh; set => ngaySinh = value; }
        public string chucvu { get; set; }

        public string taiKhoan { get; set; }
        public string matKhau { get; set; }
        public NhanVien() { }   
    }
}
