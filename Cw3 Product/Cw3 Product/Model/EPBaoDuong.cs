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
    
    public partial class EPBaoDuong
    {
        public int IdEnVeSinh { get; set; }
        public Nullable<System.DateTime> Ngay { get; set; }
        public string CaLv { get; set; }
        public string MaMay { get; set; }
        public string NhanVien { get; set; }
        public string MaPhieu { get; set; }
        public Nullable<bool> AnToanThietBi { get; set; }
        public Nullable<bool> CongTacHanhTrinh { get; set; }
        public Nullable<bool> DauDotNhiet { get; set; }
        public Nullable<bool> KhiNen { get; set; }
        public Nullable<bool> OngNuoc { get; set; }
        public Nullable<bool> BoiTron { get; set; }
        public Nullable<bool> DauThuyLuc { get; set; }
        public Nullable<bool> Robot { get; set; }
        public Nullable<bool> MaySay { get; set; }
        public Nullable<bool> MayHut { get; set; }
        public Nullable<bool> BulongConTan { get; set; }
        public Nullable<bool> QuatLamMat { get; set; }
        public Nullable<bool> NuocLamMatDau { get; set; }
        public Nullable<bool> MayBinhThuong { get; set; }
        public Nullable<bool> SapXepDungCu { get; set; }
        public Nullable<bool> VeSinhMay { get; set; }
        public string UserName { get; set; }
    
        public virtual TaiSanCoDinh TaiSanCoDinh { get; set; }
        public virtual Users Users { get; set; }
    }
}