﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw3_Product.Model
{
    public class BOMTongHopModel
    {
        public BomLkTp BomLkTp { get; set; }
        public int STT { get; set; }
        public string MaTp { get; set; }
        public string TenBX { get; set; }
        public string SoHoa { get; set; }
        public string TenLK { get; set; }
        public string DonVi { get; set; }
        public string ChatLieu { get; set; }
        public string QuyCach { get; set; }
        public int HeSo { get; set; }
        public string PhanLoaiBOM { get; set; }

    }
}