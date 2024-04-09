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
    
    public partial class BomTp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BomTp()
        {
            this.BomLkTp = new HashSet<BomLkTp>();
            this.DonHangTp = new HashSet<DonHangTp>();
            this.DonXuatHangTP = new HashSet<DonXuatHangTP>();
            this.LrSanXuat = new HashSet<LrSanXuat>();
            this.XuatTp = new HashSet<XuatTp>();
            this.KhoThanhPhamInputInfo = new HashSet<KhoThanhPhamInputInfo>();
            this.KhoThanhPhamInputInfo1 = new HashSet<KhoThanhPhamInputInfo>();
            this.KhoThanhPhamOutputInfo = new HashSet<KhoThanhPhamOutputInfo>();
            this.KhoThanhPhamOutputInfo1 = new HashSet<KhoThanhPhamOutputInfo>();
        }
    
        public string MaTp { get; set; }
        public string DisplayName { get; set; }
        public string IdU { get; set; }
        public string UserName { get; set; }
        public Nullable<int> SoLuongBanh { get; set; }
        public string QuyCach { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BomLkTp> BomLkTp { get; set; }
        public virtual Unit Unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHangTp> DonHangTp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonXuatHangTP> DonXuatHangTP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LrSanXuat> LrSanXuat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XuatTp> XuatTp { get; set; }
        public virtual Users Users { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoThanhPhamInputInfo> KhoThanhPhamInputInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoThanhPhamInputInfo> KhoThanhPhamInputInfo1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoThanhPhamOutputInfo> KhoThanhPhamOutputInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoThanhPhamOutputInfo> KhoThanhPhamOutputInfo1 { get; set; }
    }
}
