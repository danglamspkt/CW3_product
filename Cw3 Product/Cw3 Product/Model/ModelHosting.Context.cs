﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class gla43158_QLSXCW3Entities : DbContext
    {
        public gla43158_QLSXCW3Entities()
            : base("name=gla43158_QLSXCW3Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BaoDuong> BaoDuong { get; set; }
        public virtual DbSet<BaoTri> BaoTri { get; set; }
        public virtual DbSet<BomLk> BomLk { get; set; }
        public virtual DbSet<BomLkTp> BomLkTp { get; set; }
        public virtual DbSet<BomNl> BomNl { get; set; }
        public virtual DbSet<BomTp> BomTp { get; set; }
        public virtual DbSet<BoPhan> BoPhan { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<DKNguyenLieu> DKNguyenLieu { get; set; }
        public virtual DbSet<DKSanXuat> DKSanXuat { get; set; }
        public virtual DbSet<DonHangTp> DonHangTp { get; set; }
        public virtual DbSet<DonXuatHangTP> DonXuatHangTP { get; set; }
        public virtual DbSet<EPNguyenLieu> EPNguyenLieu { get; set; }
        public virtual DbSet<EPSanXuat> EPSanXuat { get; set; }
        public virtual DbSet<HanNguyenLieu> HanNguyenLieu { get; set; }
        public virtual DbSet<HanSanXuat> HanSanXuat { get; set; }
        public virtual DbSet<KHBaoDuong> KHBaoDuong { get; set; }
        public virtual DbSet<Kho> Kho { get; set; }
        public virtual DbSet<LrNguyenLieu> LrNguyenLieu { get; set; }
        public virtual DbSet<LrSanXuat> LrSanXuat { get; set; }
        public virtual DbSet<NhanSu> NhanSu { get; set; }
        public virtual DbSet<NhomMay> NhomMay { get; set; }
        public virtual DbSet<OutputInfo> OutputInfo { get; set; }
        public virtual DbSet<Outputt> Outputt { get; set; }
        public virtual DbSet<SonNguyenLieu> SonNguyenLieu { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<TaiSanCoDinh> TaiSanCoDinh { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<XuatTp> XuatTp { get; set; }
        public virtual DbSet<DKKiemTra> DKKiemTra { get; set; }
        public virtual DbSet<DkThoiGian> DkThoiGian { get; set; }
        public virtual DbSet<EPNhietDo> EPNhietDo { get; set; }
        public virtual DbSet<EPThemNL> EPThemNL { get; set; }
        public virtual DbSet<EPThoiGian> EPThoiGian { get; set; }
        public virtual DbSet<EPKiemTra> EPKiemTra { get; set; }
        public virtual DbSet<EPBaoDuong> EPBaoDuong { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<KhoLinhKienInputInfo> KhoLinhKienInputInfo { get; set; }
        public virtual DbSet<KhoLinhKienOutput> KhoLinhKienOutput { get; set; }
        public virtual DbSet<KhoLinhKienOutputInfo> KhoLinhKienOutputInfo { get; set; }
        public virtual DbSet<KhoNgoaiSXInput> KhoNgoaiSXInput { get; set; }
        public virtual DbSet<KhoNgoaiSXInputInfo> KhoNgoaiSXInputInfo { get; set; }
        public virtual DbSet<KhoNgoaiSXOutput> KhoNgoaiSXOutput { get; set; }
        public virtual DbSet<KhoNgoaiSXOutputInfo> KhoNgoaiSXOutputInfo { get; set; }
        public virtual DbSet<KhoNguyenLieuInput> KhoNguyenLieuInput { get; set; }
        public virtual DbSet<KhoNguyenLieuInputInfo> KhoNguyenLieuInputInfo { get; set; }
        public virtual DbSet<KhoNguyenLieuOutput> KhoNguyenLieuOutput { get; set; }
        public virtual DbSet<KhoNguyenLieuOutputInfo> KhoNguyenLieuOutputInfo { get; set; }
        public virtual DbSet<KhoThanhPhamInput> KhoThanhPhamInput { get; set; }
        public virtual DbSet<KhoThanhPhamOutput> KhoThanhPhamOutput { get; set; }
        public virtual DbSet<MaHangSame> MaHangSame { get; set; }
        public virtual DbSet<KhoLinhKienInput> KhoLinhKienInput { get; set; }
        public virtual DbSet<DKNguyenLieuLK> DKNguyenLieuLK { get; set; }
        public virtual DbSet<KhoThanhPhamInputInfo> KhoThanhPhamInputInfo { get; set; }
        public virtual DbSet<LrNguyenLieuLk> LrNguyenLieuLk { get; set; }
        public virtual DbSet<EPPhatLieu> EPPhatLieu { get; set; }
        public virtual DbSet<KhoThanhPhamOutputInfo> KhoThanhPhamOutputInfo { get; set; }
        public virtual DbSet<SonKiemTra> SonKiemTra { get; set; }
        public virtual DbSet<SonSanXuat> SonSanXuat { get; set; }
        public virtual DbSet<ACGroup> ACGroup { get; set; }
        public virtual DbSet<ACTimeZones> ACTimeZones { get; set; }
        public virtual DbSet<ACUnlockComb> ACUnlockComb { get; set; }
        public virtual DbSet<AlarmLog> AlarmLog { get; set; }
        public virtual DbSet<AttParam> AttParam { get; set; }
        public virtual DbSet<AuditedExc> AuditedExc { get; set; }
        public virtual DbSet<AUTHDEVICE> AUTHDEVICE { get; set; }
        public virtual DbSet<CHECKEXACT> CHECKEXACT { get; set; }
        public virtual DbSet<CHECKINOUT> CHECKINOUT { get; set; }
        public virtual DbSet<DEPARTMENTS> DEPARTMENTS { get; set; }
        public virtual DbSet<DeptUsedSchs> DeptUsedSchs { get; set; }
        public virtual DbSet<FaceTemp> FaceTemp { get; set; }
        public virtual DbSet<HOLIDAYS> HOLIDAYS { get; set; }
        public virtual DbSet<LeaveClass> LeaveClass { get; set; }
        public virtual DbSet<LeaveClass1> LeaveClass1 { get; set; }
        public virtual DbSet<Machines> Machines { get; set; }
        public virtual DbSet<NUM_RUN> NUM_RUN { get; set; }
        public virtual DbSet<NUM_RUN_DEIL> NUM_RUN_DEIL { get; set; }
        public virtual DbSet<ReportItem> ReportItem { get; set; }
        public virtual DbSet<SchClass> SchClass { get; set; }
        public virtual DbSet<SECURITYDETAILS> SECURITYDETAILS { get; set; }
        public virtual DbSet<SHIFT> SHIFT { get; set; }
        public virtual DbSet<SystemLog> SystemLog { get; set; }
        public virtual DbSet<TBSMSALLOT> TBSMSALLOT { get; set; }
        public virtual DbSet<TBSMSINFO> TBSMSINFO { get; set; }
        public virtual DbSet<TEMPLATE> TEMPLATE { get; set; }
        public virtual DbSet<USER_OF_RUN> USER_OF_RUN { get; set; }
        public virtual DbSet<USER_SPEDAY> USER_SPEDAY { get; set; }
        public virtual DbSet<USER_TEMP_SCH> USER_TEMP_SCH { get; set; }
        public virtual DbSet<UserACMachines> UserACMachines { get; set; }
        public virtual DbSet<UserACPrivilege> UserACPrivilege { get; set; }
        public virtual DbSet<USERINFO> USERINFO { get; set; }
        public virtual DbSet<UserUpdates> UserUpdates { get; set; }
        public virtual DbSet<UserUsedSClasses> UserUsedSClasses { get; set; }
        public virtual DbSet<EmOpLog> EmOpLog { get; set; }
        public virtual DbSet<ServerLog> ServerLog { get; set; }
        public virtual DbSet<UsersMachines> UsersMachines { get; set; }
    }
}