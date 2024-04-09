using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw3_Product.Model
{
    public class BOMHaoHutTongQuanModel
    {
        public int STT { get; set; }
        public string MaTp { get; set; }
        public string SoHoa { get; set; }
        public string DisplayName { get; set; }
        public string MaMuaHang { get; set; }
        public string ChatLieu { get; set; }
        public string QuyCach { get; set; }
        public int? HeSo { get; set; }
        public int? SoLuongCan { get; set; }
        public int? SoLuongPhat { get; set; }
        public int? SoLuongCon { get; set; }
    }
}
