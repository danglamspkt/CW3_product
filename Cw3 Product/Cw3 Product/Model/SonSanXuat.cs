//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cw3_Product.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class SonSanXuat
    {
        public int IdSxSon { get; set; }
        public Nullable<System.DateTime> Ngay { get; set; }
        public string ChuyenSon { get; set; }
        public string CaLv { get; set; }
        public string SoLo { get; set; }
        public string SoHoa { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public string IdU { get; set; }
        public Nullable<int> Phe { get; set; }
        public Nullable<System.TimeSpan> hourstart { get; set; }
        public Nullable<System.TimeSpan> hourend { get; set; }
        public string MaPhieu { get; set; }
        public string UserName { get; set; }
    
        public virtual BomLk BomLk { get; set; }
        public virtual DonHangTp DonHangTp { get; set; }
        public virtual Users Users { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
