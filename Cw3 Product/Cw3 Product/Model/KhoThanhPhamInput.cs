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
    
    public partial class KhoThanhPhamInput
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhoThanhPhamInput()
        {
            this.KhoThanhPhamInputInfo = new HashSet<KhoThanhPhamInputInfo>();
        }
    
        public string MaPhieu { get; set; }
        public Nullable<System.DateTime> DateCT { get; set; }
        public Nullable<System.DateTime> DateNhap { get; set; }
        public string IdSup { get; set; }
        public string TenNCC { get; set; }
        public string POMuaHang { get; set; }
        public string GhiChu { get; set; }
        public string UserName { get; set; }
    
        public virtual Supplier Supplier { get; set; }
        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoThanhPhamInputInfo> KhoThanhPhamInputInfo { get; set; }
    }
}