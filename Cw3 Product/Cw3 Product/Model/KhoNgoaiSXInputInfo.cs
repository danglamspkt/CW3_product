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
    
    public partial class KhoNgoaiSXInputInfo
    {
        public int STT { get; set; }
        public string MaPhieu { get; set; }
        public string TenVatTu { get; set; }
        public string QuyCach { get; set; }
        public int SoLuongNhap { get; set; }
        public string IdU { get; set; }
        public string MaKho { get; set; }
        public string GhiChu { get; set; }
        public string ViTri { get; set; }
        public string UserName { get; set; }
        public string QRcode { get; set; }
        public byte[] QRimg { get; set; }
    
        public virtual Kho Kho { get; set; }
        public virtual KhoNgoaiSXInput KhoNgoaiSXInput { get; set; }
        public virtual Users Users { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
