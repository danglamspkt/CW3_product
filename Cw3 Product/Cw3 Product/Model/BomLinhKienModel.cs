using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw3_Product.Model
{
    public class BomLinhKienModel
    {
        public BomLkTp BomLkTp { get; set; }
        public int STT { get; set; }
        public string SoHoa { get; set; }
        public string TenLK { get; set; }
        public string DonVi { get; set; }
        public string QuyCach { get; set; }
        public bool? DapKhuon { get; set; }
        public bool? EpNhua { get; set; }
        public bool? Han { get; set; }
        public bool? Son { get; set; }
        public bool? LapRap { get; set; }
    }
}
