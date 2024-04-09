using Cw3_Product.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw3_Product.Model
{
    public class UnitModel : BaseViewModel
    {
        public Unit Unit { get; set; }
        public int STT { get; set; }
        public string IdU { get; set; }
        public string DisplayName { get; set; }
    }
}
