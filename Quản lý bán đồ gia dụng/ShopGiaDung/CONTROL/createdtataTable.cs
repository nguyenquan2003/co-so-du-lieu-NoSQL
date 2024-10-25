using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace ShopGiaDung.CONTROL
{
    class createdtataTable
    {
        public DataTable createDTB()
        {
            DataTable dtb = new DataTable();
            dtb.Columns.Add("ID", typeof(string));
            dtb.Columns.Add("TenSP", typeof(string));
            dtb.Columns.Add("Gia", typeof(decimal));
            dtb.Columns.Add("SoLuong", typeof(int));
            dtb.Columns.Add("ThanhTien", typeof(int));

            return dtb;
        }
            
    }
}
