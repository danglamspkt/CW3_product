using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw3_Product.Model
{
    public class PhieuSanLuongLapRapModel
    {
        public LrSanXuat LrSanXuat { get; set; }
        public int? STT { get; set; }
        public DateTime? Ngay { get; set; }
        public string Ca { get; set; }
        public string ChuyenLr { get; set; }
        public string LrSlId { get; set; }
        public TimeSpan? TimeStart { get; set; }
        public TimeSpan? TimeEnd { get; set; }
        public string Solo { get; set; }
        public string MaTp { get; set; }
        public string DonVi { get; set; }
        public int? SoLuong { get; set; }
        public int? Phe { get; set; }
    }
}
