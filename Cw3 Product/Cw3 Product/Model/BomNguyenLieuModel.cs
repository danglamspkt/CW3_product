using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw3_Product.Model
{
    public class BomNguyenLieuModel
    {
        public BomNl BomNl { get; set; }
        public int STT { get; set; }
        public string MaMuaHang { get; set; }
        public string TenNL { get; set; }
        public string ChatLieu { get; set; }
        public string QuyCach { get; set; }
        public string DonVi { get; set; }
        public string PhanLoaiBOM { get; set; }
        public bool? DapKhuon { get; set; }
        public bool? EpNhua { get; set; }
        public bool? Han { get; set; }
        public bool? Son { get; set; }
        public bool? LapRap { get; set; }
    }
}
