using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.Remoting.Contexts;


namespace ShopGiaDung.CONTROL
{

    public class DangNhap
    {
        public DataTable LoadDTB(string db, string collect)
        {
            return new ConnectNosql().Load(db, collect);
        }

        //public DataTable loadDangNhap()
        //{
        //    ConnectNosql connect = new ConnectNosql();


        //    DataTable dataTable = connect.Load("QLBH_KM", "NhanVien");

        //    // Trả về DataTable để gán vào DataGridView
        //    return dataTable;
        //}
        public DataTable LoadDangNhap()
        {
            // Khởi tạo đối tượng ConnectNosql
            ConnectNosql connect = new ConnectNosql();

            // Danh sách các cột mong muốn hiển thị
            List<string> columns = new List<string> {"ChucVu", "TaiKhoan", "MatKhau" };

            // Gọi phương thức Load với các cột mong muốn
            DataTable dataTable = connect.Load("QLBH_KM", "NhanVien", columns);

            // Trả về DataTable để gán vào DataGridView
            return dataTable;
        }
    }
}
