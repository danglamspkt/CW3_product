using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw3_Product.Model
{
    public class BOMHaoHutLinhKienModel
    {
        public int STT { get; set; }
        public DateTime? Ngay { get; set; }
        public string MaPhieu { get; set; }
        public string IdCus { get; set; }
        public string GhiChu { get; set; }
        public string SoLo { get; set; }
        public string SoHoa { get; set; }
        public string QuyCach { get; set; }
        public string DisplayName { get; set; }
        public string IdU { get; set; }
        public string ViTri { get; set; }
        public string QrCode { get; set; }
        public int? SoLuong { get; set; }
        public int? KhoiLuong { get; set; }
    }
}
