using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw3_Product.Model
{
    public class DataProvider
    {

        private static DataProvider _ins;
        public static DataProvider Ins
        {
            get
            {
                if (_ins == null)
                    _ins = new DataProvider();
                return _ins;
            }
            set
            {
                _ins = value;
            }
        }


        public gla43158_QLSXCW3Entities DB { get; set; }

        private DataProvider()
        {
            DB = new gla43158_QLSXCW3Entities();
        }

    }
}
