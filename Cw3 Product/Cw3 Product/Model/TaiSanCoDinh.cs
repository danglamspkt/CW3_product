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
    
    public partial class TaiSanCoDinh
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiSanCoDinh()
        {
            this.BaoDuong = new HashSet<BaoDuong>();
            this.BaoTri = new HashSet<BaoTri>();
            this.DKSanXuat = new HashSet<DKSanXuat>();
            this.EPSanXuat = new HashSet<EPSanXuat>();
            this.HanSanXuat = new HashSet<HanSanXuat>();
            this.DKKiemTra = new HashSet<DKKiemTra>();
            this.DkThoiGian = new HashSet<DkThoiGian>();
            this.EPNhietDo = new HashSet<EPNhietDo>();
            this.EPThemNL = new HashSet<EPThemNL>();
            this.EPThoiGian = new HashSet<EPThoiGian>();
            this.EPKiemTra = new HashSet<EPKiemTra>();
            this.EPBaoDuong = new HashSet<EPBaoDuong>();
        }
    
        public string MaMay { get; set; }
        public string DisplayName { get; set; }
        public string MaBp { get; set; }
        public string ViTri { get; set; }
        public string IdNhomMay { get; set; }
        public string TinhTrang { get; set; }
        public string UserName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoDuong> BaoDuong { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoTri> BaoTri { get; set; }
        public virtual BoPhan BoPhan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DKSanXuat> DKSanXuat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EPSanXuat> EPSanXuat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HanSanXuat> HanSanXuat { get; set; }
        public virtual NhomMay NhomMay { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DKKiemTra> DKKiemTra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DkThoiGian> DkThoiGian { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EPNhietDo> EPNhietDo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EPThemNL> EPThemNL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EPThoiGian> EPThoiGian { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EPKiemTra> EPKiemTra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EPBaoDuong> EPBaoDuong { get; set; }
        public virtual Users Users { get; set; }
    }
}