using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw3_Product.Model
{
    public class KeHoachTheoDonModel
    {
        public DonHangTp DonHangTp { get; set; }
        public int STT { get; set; }
        public DateTime NgayLenDon { get; set; }
        public string MaBx { get; set; }
        public string SoLo { get; set; }
        public string IdU { get; set; }
        public int SoLuong { get; set; }
        public int Laprap { get; set; }
        public int ConLai { get; set; }
        public int XuatHang { get; set; }
        public int TonKho { get; set; }
        public string TinhTrangDon { get; set; }
    }
}
