using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw3_Product.Model
{
    public class DonXuatHangChiTietModel
    {
        public DonXuatHangTP DonXuatHangTP { get; set; }
        public int STT { get; set; }
        public DateTime Ngaylendon { get; set; }
        public int Soluongxuat { get; set; }
        public string MaTp { get; set; }
        public int TonKho { get; set; }
        public int DaXuat { get; set; }
        public int ConLai { get; set; }
        public string Donvi { get; set; }
    }
}
