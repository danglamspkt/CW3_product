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
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.BaoDuong = new HashSet<BaoDuong>();
            this.BaoTri = new HashSet<BaoTri>();
            this.BomLk = new HashSet<BomLk>();
            this.BomLkTp = new HashSet<BomLkTp>();
            this.BomNl = new HashSet<BomNl>();
            this.BomTp = new HashSet<BomTp>();
            this.BoPhan = new HashSet<BoPhan>();
            this.Customer = new HashSet<Customer>();
            this.DKKiemTra = new HashSet<DKKiemTra>();
            this.DKNguyenLieu = new HashSet<DKNguyenLieu>();
            this.DKSanXuat = new HashSet<DKSanXuat>();
            this.DkThoiGian = new HashSet<DkThoiGian>();
            this.DonHangTp = new HashSet<DonHangTp>();
            this.DonXuatHangTP = new HashSet<DonXuatHangTP>();
            this.EPBaoDuong = new HashSet<EPBaoDuong>();
            this.EPKiemTra = new HashSet<EPKiemTra>();
            this.EPNguyenLieu = new HashSet<EPNguyenLieu>();
            this.EPNhietDo = new HashSet<EPNhietDo>();
            this.EPSanXuat = new HashSet<EPSanXuat>();
            this.EPThemNL = new HashSet<EPThemNL>();
            this.EPThoiGian = new HashSet<EPThoiGian>();
            this.HanNguyenLieu = new HashSet<HanNguyenLieu>();
            this.HanSanXuat = new HashSet<HanSanXuat>();
            this.KHBaoDuong = new HashSet<KHBaoDuong>();
            this.Kho = new HashSet<Kho>();
            this.LrNguyenLieu = new HashSet<LrNguyenLieu>();
            this.LrSanXuat = new HashSet<LrSanXuat>();
            this.NhanSu = new HashSet<NhanSu>();
            this.NhomMay = new HashSet<NhomMay>();
            this.OutputInfo = new HashSet<OutputInfo>();
            this.Outputt = new HashSet<Outputt>();
            this.SonNguyenLieu = new HashSet<SonNguyenLieu>();
            this.Supplier = new HashSet<Supplier>();
            this.TaiSanCoDinh = new HashSet<TaiSanCoDinh>();
            this.Unit = new HashSet<Unit>();
            this.XuatTp = new HashSet<XuatTp>();
            this.KhoLinhKienInputInfo = new HashSet<KhoLinhKienInputInfo>();
            this.KhoLinhKienOutput = new HashSet<KhoLinhKienOutput>();
            this.KhoLinhKienOutputInfo = new HashSet<KhoLinhKienOutputInfo>();
            this.KhoNgoaiSXInput = new HashSet<KhoNgoaiSXInput>();
            this.KhoNgoaiSXInputInfo = new HashSet<KhoNgoaiSXInputInfo>();
            this.KhoNgoaiSXOutput = new HashSet<KhoNgoaiSXOutput>();
            this.KhoNgoaiSXOutputInfo = new HashSet<KhoNgoaiSXOutputInfo>();
            this.KhoNguyenLieuInput = new HashSet<KhoNguyenLieuInput>();
            this.KhoNguyenLieuInputInfo = new HashSet<KhoNguyenLieuInputInfo>();
            this.KhoNguyenLieuOutput = new HashSet<KhoNguyenLieuOutput>();
            this.KhoNguyenLieuOutputInfo = new HashSet<KhoNguyenLieuOutputInfo>();
            this.KhoThanhPhamInput = new HashSet<KhoThanhPhamInput>();
            this.KhoThanhPhamOutput = new HashSet<KhoThanhPhamOutput>();
            this.MaHangSame = new HashSet<MaHangSame>();
            this.KhoLinhKienInput = new HashSet<KhoLinhKienInput>();
            this.DKNguyenLieuLK = new HashSet<DKNguyenLieuLK>();
            this.KhoThanhPhamInputInfo = new HashSet<KhoThanhPhamInputInfo>();
            this.LrNguyenLieuLk = new HashSet<LrNguyenLieuLk>();
            this.EPPhatLieu = new HashSet<EPPhatLieu>();
            this.KhoThanhPhamOutputInfo = new HashSet<KhoThanhPhamOutputInfo>();
            this.SonSanXuat = new HashSet<SonSanXuat>();
        }
    
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int IdRole { get; set; }
    
        public virtual UserRole UserRole { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoDuong> BaoDuong { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaoTri> BaoTri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BomLk> BomLk { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BomLkTp> BomLkTp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BomNl> BomNl { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BomTp> BomTp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BoPhan> BoPhan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DKKiemTra> DKKiemTra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DKNguyenLieu> DKNguyenLieu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DKSanXuat> DKSanXuat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DkThoiGian> DkThoiGian { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHangTp> DonHangTp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonXuatHangTP> DonXuatHangTP { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EPBaoDuong> EPBaoDuong { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EPKiemTra> EPKiemTra { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EPNguyenLieu> EPNguyenLieu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EPNhietDo> EPNhietDo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EPSanXuat> EPSanXuat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EPThemNL> EPThemNL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EPThoiGian> EPThoiGian { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HanNguyenLieu> HanNguyenLieu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HanSanXuat> HanSanXuat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KHBaoDuong> KHBaoDuong { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kho> Kho { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LrNguyenLieu> LrNguyenLieu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LrSanXuat> LrSanXuat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanSu> NhanSu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhomMay> NhomMay { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OutputInfo> OutputInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Outputt> Outputt { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SonNguyenLieu> SonNguyenLieu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier> Supplier { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiSanCoDinh> TaiSanCoDinh { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Unit> Unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<XuatTp> XuatTp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoLinhKienInputInfo> KhoLinhKienInputInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoLinhKienOutput> KhoLinhKienOutput { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoLinhKienOutputInfo> KhoLinhKienOutputInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoNgoaiSXInput> KhoNgoaiSXInput { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoNgoaiSXInputInfo> KhoNgoaiSXInputInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoNgoaiSXOutput> KhoNgoaiSXOutput { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoNgoaiSXOutputInfo> KhoNgoaiSXOutputInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoNguyenLieuInput> KhoNguyenLieuInput { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoNguyenLieuInputInfo> KhoNguyenLieuInputInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoNguyenLieuOutput> KhoNguyenLieuOutput { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoNguyenLieuOutputInfo> KhoNguyenLieuOutputInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoThanhPhamInput> KhoThanhPhamInput { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoThanhPhamOutput> KhoThanhPhamOutput { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaHangSame> MaHangSame { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoLinhKienInput> KhoLinhKienInput { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DKNguyenLieuLK> DKNguyenLieuLK { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoThanhPhamInputInfo> KhoThanhPhamInputInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LrNguyenLieuLk> LrNguyenLieuLk { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EPPhatLieu> EPPhatLieu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhoThanhPhamOutputInfo> KhoThanhPhamOutputInfo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SonSanXuat> SonSanXuat { get; set; }
    }
}