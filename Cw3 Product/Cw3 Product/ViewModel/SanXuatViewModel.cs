using Cw3_Product.Model;
using Cw3_Product.UserControlBaoTri;
using Cw3_Product.UserControlSanXuat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using MaterialDesignColors.Recommended;
using MaterialDesignColors.ColorManipulation;
using MahApps.Metro;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.MahApps;
using MahApps.Metro.Markup;
using ControlzEx.Standard;
using System.Net;
using System.Windows.Data;

namespace Cw3_Product.ViewModel
{
    public class SanXuatViewModel : BaseViewModel
    {
        //------------------------khai báo hiển thị địa chỉ--------------------------
        private string _txbTitle1;
        public string txbTitle1 { get => _txbTitle1; set { _txbTitle1 = value; OnPropertyChanged(); } }

        private string _txbTitle2;
        public string txbTitle2 { get => _txbTitle2; set { _txbTitle2 = value; OnPropertyChanged(); } }

        private string _txbTitle3;
        public string txbTitle3 { get => _txbTitle3; set { _txbTitle3 = value; OnPropertyChanged(); } }

        //-----------------Khai báo Usercontrol-------------------------------
        public UserControl uc { get; set; }

     
        //--------------Khai báo hiển thị UC con-------------------------
        public ICommand Homedata { get; set; }
        public ICommand GcEnInfoData { get; set; }
        public ICommand GcDkInfoData { get; set; }
        public ICommand HanInfoData { get; set; }
        public ICommand SonInfoData { get; set; }
        public ICommand LapRapInfoData { get; set; }

        public ICommand GcEnProductData { get; set; }
        public ICommand GcEnNhietDoData { get; set; }
        public ICommand GcEnThoiGianData { get; set; }
        public ICommand GcEnCheckData { get; set; }
        public ICommand GcEnThemNlData { get; set; }
        public ICommand GcEnBaoDuongData { get; set; }
        public ICommand GcEnSanLuongData { get; set; }

        public ICommand GcDkCheckData { get; set; }
        public ICommand GcDkProductData { get; set; }
        public ICommand GcDkTimeData { get; set; }
        public ICommand GcDkSanLuongData { get; set; }


        public ICommand HanInPutData { get; set; }
        public ICommand HanOutPutData { get; set; }
        public ICommand HanProductData { get; set; }
        public ICommand HanSanLuongData { get; set; }

        public ICommand SonInPutData { get; set; }
        public ICommand SonOutPutData { get; set; }
        public ICommand SonProductData { get; set; }
        public ICommand SonSanLuongData { get; set; }


        public ICommand LapRapNguyenLieuData { get; set; }
        public ICommand LapRapProductData { get; set; }
        public ICommand LapRapSanLuongData { get; set; }
        public ICommand LapRapSanLuong2Data { get; set; }

        public ICommand BOMhaohuttongquan { get; set; }
        public ICommand BOMhaohutnguyenlieu { get; set; }
        public ICommand BOMhaohutlinhkien { get; set; }


        //-------------------------Khai báo list hiển thị BOM NL--------------------------------------------------
        private ObservableCollection<BomNl> _mamuahanglist;
        public ObservableCollection<BomNl> mamuahanglist { get => _mamuahanglist; set { _mamuahanglist = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị BOM TP--------------------------------------------------
        private ObservableCollection<DonHangTp> _MaTpList;
        public ObservableCollection<DonHangTp> MaTpList { get => _MaTpList; set { _MaTpList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị BOM TP--------------------------------------------------
        private ObservableCollection<BomLkTp> _SoHoaList;
        public ObservableCollection<BomLkTp> SoHoaList { get => _SoHoaList; set { _SoHoaList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Đơn vị--------------------------------------------------
        private ObservableCollection<Unit> _donvilist;
        public ObservableCollection<Unit> donvilist { get => _donvilist; set { _donvilist = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Đơn hàng thành phẩm--------------------------------------------------
        private ObservableCollection<DonHangTp> _SoLoList;
        public ObservableCollection<DonHangTp> SoLoList { get => _SoLoList; set { _SoLoList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Nguyên liệu lắp ráp--------------------------------------------------
        private ObservableCollection<LrNguyenLieu> _LapRapNguyenLieuList;
        public ObservableCollection<LrNguyenLieu> LapRapNguyenLieuList { get => _LapRapNguyenLieuList; set { _LapRapNguyenLieuList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị sản xuất lắp ráp--------------------------------------------------
        private ObservableCollection<LrSanXuat> _LapRapSanXuatList;
        public ObservableCollection<LrSanXuat> LapRapSanXuatList { get => _LapRapSanXuatList; set { _LapRapSanXuatList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị sản xuất lắp ráp--------------------------------------------------
        private ObservableCollection<LrSanXuat> _LapRapSanLuongList;
        public ObservableCollection<LrSanXuat> LapRapSanLuongList { get => _LapRapSanLuongList; set { _LapRapSanLuongList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị phiếu sản lượng lắp ráp--------------------------------------------------
        private ObservableCollection<PhieuSanLuongLapRapModel> _PhieuSanLuongLapRapList;
        public ObservableCollection<PhieuSanLuongLapRapModel> PhieuSanLuongLapRapList { get => _PhieuSanLuongLapRapList; set { _PhieuSanLuongLapRapList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị phiếu phế lắp ráp--------------------------------------------------
        private ObservableCollection<LaprapPheGiacong> _LapRapPheGCList;
        public ObservableCollection<LaprapPheGiacong> LapRapPheGCList { get => _LapRapPheGCList; set { _LapRapPheGCList = value; OnPropertyChanged(); } }


        //-------------------------Khai báo biến Nguyên liệu Lắp ráp--------------------------------------------------
        private int? _LapRapNlId;
        public int? LapRapNlId { get => _LapRapNlId; set { _LapRapNlId = value; OnPropertyChanged(); } }

        private DateTime? _LapRapNlNgay;
        public DateTime? LapRapNlNgay { get => _LapRapNlNgay; set { _LapRapNlNgay = value; OnPropertyChanged(); } }

        private string _LapRapNlMaMuaHang;
        public string LapRapNlMaMuaHang { get => _LapRapNlMaMuaHang; set { _LapRapNlMaMuaHang = value; OnPropertyChanged(); } }

        private int? _LapRapNlSoLuong;
        public int? LapRapNlSoLuong { get => _LapRapNlSoLuong; set { _LapRapNlSoLuong = value; OnPropertyChanged(); } }

        private string _LapRapNlNhapXuat;
        public string LapRapNlNhapXuat { get => _LapRapNlNhapXuat; set { _LapRapNlNhapXuat = value; OnPropertyChanged(); } }

        private string _LapRapNlDonVi;
        public string LapRapNlDonVi { get => _LapRapNlDonVi; set { _LapRapNlDonVi = value; OnPropertyChanged(); } }

        private DateTime? _LapRapNlNgayStart;
        public DateTime? LapRapNlNgayStart { get => _LapRapNlNgayStart; set { _LapRapNlNgayStart = value; OnPropertyChanged(); } }

        private DateTime? _LapRapNlNgayEnd;
        public DateTime? LapRapNlNgayEnd { get => _LapRapNlNgayEnd; set { _LapRapNlNgayEnd = value; OnPropertyChanged(); } }

        private Model.LrNguyenLieu _SelectedItemLapRapNl;
        public Model.LrNguyenLieu SelectedItemLapRapNl
        {
            get => _SelectedItemLapRapNl; set
            {
                _SelectedItemLapRapNl = value; OnPropertyChanged(); if (_SelectedItemLapRapNl != null)
                {
                    LapRapNlId = SelectedItemLapRapNl.IdNlLr;
                    LapRapNlNgay = SelectedItemLapRapNl.Ngay;
                    LapRapNlMaMuaHang = SelectedItemLapRapNl.MaMuaHang;
                    LapRapNlSoLuong = SelectedItemLapRapNl.SoLuong;
                    LapRapNlNhapXuat = SelectedItemLapRapNl.NhapXuat;
                    LapRapNlDonVi = SelectedItemLapRapNl.IdU;
                }
            }
        }

        //===========================Khai báo command thêm sửa xóa Nguyên liệu lắp ráp===========================
        public ICommand filtercommandLrNl { get; set; }
        public ICommand addcommandLrNl { get; set; }
        public ICommand editcommandLrNl { get; set; }
        public ICommand deletecommandLrNl { get; set; }
        public ICommand ClearLrNl { get; set; }


        //-------------------------Khai báo biến sản xuất Lắp ráp--------------------------------------------------
        private int? _LapRapSxId;
        public int? LapRapSxId { get => _LapRapSxId; set { _LapRapSxId = value; OnPropertyChanged(); } }

        private DateTime? _LapRapSxNgay;
        public DateTime? LapRapSxNgay { get => _LapRapSxNgay; set { _LapRapSxNgay = value; OnPropertyChanged(); } }

        private string _LapRapSxChuyenLr;
        public string LapRapSxChuyenLr { get => _LapRapSxChuyenLr; set { _LapRapSxChuyenLr = value; OnPropertyChanged(); } }

        private string _LapRapSxSoLo;
        public string LapRapSxSoLo { get => _LapRapSxSoLo; set { _LapRapSxSoLo = value; OnPropertyChanged(); } }

        private string _LapRapSxMaTp;
        public string LapRapSxMaTp { get => _LapRapSxMaTp; set { _LapRapSxMaTp = value; OnPropertyChanged(); } }

        private int? _LapRapSxSoLuong;
        public int? LapRapSxSoLuong { get => _LapRapSxSoLuong; set { _LapRapSxSoLuong = value; OnPropertyChanged(); } }

        private string _LapRapSxDonVi;
        public string LapRapSxDonVi { get => _LapRapSxDonVi; set { _LapRapSxDonVi = value; OnPropertyChanged(); } }

        private int? _LapRapSxPhe;
        public int? LapRapSxPhe { get => _LapRapSxPhe; set { _LapRapSxPhe = value; OnPropertyChanged(); } }

        private DateTime? _LapRapSxNgayStart;
        public DateTime? LapRapSxNgayStart { get => _LapRapSxNgayStart; set { _LapRapSxNgayStart = value; OnPropertyChanged(); } }

        private DateTime? _LapRapSxNgayEnd;
        public DateTime? LapRapSxNgayEnd { get => _LapRapSxNgayEnd; set { _LapRapSxNgayEnd = value; OnPropertyChanged(); } }

        private Model.LrSanXuat _SelectedItemLapRapSx;
        public Model.LrSanXuat SelectedItemLapRapSx
        {
            get => _SelectedItemLapRapSx; set
            {
                _SelectedItemLapRapSx = value; OnPropertyChanged(); if (_SelectedItemLapRapSx != null)
                {
                    LapRapSxId = SelectedItemLapRapSx.IdSxLr;
                    LapRapSxNgay = SelectedItemLapRapSx.Ngay;
                    LapRapSxChuyenLr = SelectedItemLapRapSx.ChuyenLr;
                    LapRapSxSoLo = SelectedItemLapRapSx.SoLo;
                    LapRapSxMaTp = SelectedItemLapRapSx.MaTp;
                    LapRapSxSoLuong = SelectedItemLapRapSx.SoLuong;
                    LapRapSxDonVi = SelectedItemLapRapSx.IdU;
                    LapRapSxPhe = SelectedItemLapRapSx.Phe;
                }
            }
        }

        //===========================Khai báo command thêm sửa xóa lắp ráp sản xuất===========================
        public ICommand filtercommandLrSx { get; set; }
        public ICommand addcommandLrSx { get; set; }
        public ICommand editcommandLrSx { get; set; }
        public ICommand deletecommandLrSx { get; set; }
        public ICommand ClearLrSx { get; set; }
        public ICommand Filterngay { get; set; }


        //-------------------------Khai báo biến phiêu nhập Lắp ráp--------------------------------------------------
        private DateTime? _LrSlNgay;
        public DateTime? LrSlNgay { get => _LrSlNgay; set { _LrSlNgay = value; OnPropertyChanged(); } }

        private string _LrSlCa;
        public string LrSlCa { get => _LrSlCa; set { _LrSlCa = value; OnPropertyChanged(); } }

        private string _LrSlChuyenLr;
        public string LrSlChuyenLr { get => _LrSlChuyenLr; set { _LrSlChuyenLr = value; OnPropertyChanged(); } }

        private string _LrSlId;
        public string LrSlId { get => _LrSlId; set { _LrSlId = value; OnPropertyChanged(); } }

        private int? _LrSlStt;
        public int? LrSlStt { get => _LrSlStt; set { _LrSlStt = value; OnPropertyChanged(); } }

        private int? _LrSlStt1;
        public int? LrSlStt1 { get => _LrSlStt1; set { _LrSlStt1 = value; OnPropertyChanged(); } }

        private TimeSpan? _LrSlTimeStart;
        public TimeSpan? LrSlTimeStart { get => _LrSlTimeStart; set { _LrSlTimeStart = value; OnPropertyChanged(); } }

        private TimeSpan? _LrSlTimeEnd;
        public TimeSpan? LrSlTimeEnd { get => _LrSlTimeEnd; set { _LrSlTimeEnd = value; OnPropertyChanged(); } }        

        private string _LrSlSoLo;
        public string LrSlSoLo { get => _LrSlSoLo; set { _LrSlSoLo = value; OnPropertyChanged(); } }

        private string _LrSlMaTp;
        public string LrSlMaTp { get => _LrSlMaTp; set { _LrSlMaTp = value; OnPropertyChanged(); } }

        private string _LrSlDonVi;
        public string LrSlDonVi { get => _LrSlDonVi; set { _LrSlDonVi = value; OnPropertyChanged(); } }

        private int? _LrSlSoLuong;
        public int? LrSlSoLuong { get => _LrSlSoLuong; set { _LrSlSoLuong = value; OnPropertyChanged(); } }

        private int? _LrSlPhe;
        public int? LrSlPhe { get => _LrSlPhe; set { _LrSlPhe = value; OnPropertyChanged(); } }

        private int? _LrPheSTT;
        public int? LrPheSTT { get => _LrPheSTT; set { _LrPheSTT = value; OnPropertyChanged(); } }

        private int? _LrPheSTT1;
        public int? LrPheSTT1 { get => _LrPheSTT1; set { _LrPheSTT1 = value; OnPropertyChanged(); } }

        private string _LrSlPheSoLo;
        public string LrSlPheSoLo { get => _LrSlPheSoLo; set { _LrSlPheSoLo = value; OnPropertyChanged(); } }

        private string _LrSlPheSoHoa;
        public string LrSlPheSoHoa { get => _LrSlPheSoHoa; set { _LrSlPheSoHoa = value; OnPropertyChanged(); } }

        private int? _LrSlPhePhe;
        public int? LrSlPhePhe { get => _LrSlPhePhe; set { _LrSlPhePhe = value; OnPropertyChanged(); } }

        private string _LrSlPheNguyenNhan;
        public string LrSlPheNguyenNhan { get => _LrSlPheNguyenNhan; set { _LrSlPheNguyenNhan = value; OnPropertyChanged(); } }

        private bool _LrSlnew;
        public bool LrSlnew { get => _LrSlnew; set { _LrSlnew = value; OnPropertyChanged(); } }

        private Model.PhieuSanLuongLapRapModel _SelectedItemPhieuSl;
        public Model.PhieuSanLuongLapRapModel SelectedItemPhieuSl
        {
            get => _SelectedItemPhieuSl; set
            {
                _SelectedItemPhieuSl = value; OnPropertyChanged(); if (_SelectedItemPhieuSl != null)
                {
                    LrSlStt = SelectedItemPhieuSl.STT;
                    LrSlTimeStart = SelectedItemPhieuSl.TimeStart;
                    LrSlTimeEnd = SelectedItemPhieuSl.TimeEnd;
                    LrSlSoLo = SelectedItemPhieuSl.Solo;
                    LrSlMaTp = SelectedItemPhieuSl.MaTp;
                    LrSlDonVi = SelectedItemPhieuSl.DonVi;
                    LrSlSoLuong = SelectedItemPhieuSl.SoLuong;
                    LrSlPhe = SelectedItemPhieuSl.Phe;
                }
            }
        }

        private Model.LaprapPheGiacong _SelectedItemLrPheGC;
        public Model.LaprapPheGiacong SelectedItemLrPheGC
        {
            get => _SelectedItemLrPheGC; set
            {
                _SelectedItemLrPheGC = value; OnPropertyChanged(); if (_SelectedItemLrPheGC != null)
                {
                    LrPheSTT = SelectedItemLrPheGC.STT;
                    LrSlPheSoLo = SelectedItemLrPheGC.Solo;
                    LrSlPheSoHoa = SelectedItemLrPheGC.SoHoa;
                    LrSlPhePhe = SelectedItemLrPheGC.Phe;
                    LrSlPheNguyenNhan = SelectedItemLrPheGC.NguyenNhan;
                }
            }
        }


        //===========================Khai báo command phiếu nhập lắp ráp===========================
        public ICommand LrSlTaoDon { get; set; }
        public ICommand LrSlXacNhan { get; set; }
        public ICommand LrSlHuyDon { get; set; }
        public ICommand LrSldatechange { get; set; }
        public ICommand LrSlNew { get; set; }
        public ICommand LrSlDelete { get; set; }
        public ICommand LrSlClear { get; set; }
        public ICommand LrSlPheNew { get; set; }
        public ICommand LrSlPheDelete { get; set; }
        public ICommand LrSlPheClear { get; set; }
        public ICommand SoloMaTp { get; set; }
        public ICommand SoloSoHoa { get; set; }

        bool issort = false;
        private string _Userlogin;
        public string Userlogin { get => _Userlogin; set { _Userlogin = value; OnPropertyChanged(); } }

        private int _Userlevel;
        public int Userlevel { get => _Userlevel; set { _Userlevel = value; OnPropertyChanged(); } }
        //============================================================================================================
        //==========================================Chương trình chính================================================
        //============================================================================================================
        public SanXuatViewModel() 
        {
            Homedata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new SanxuatHomeUC(); p.Children.Add(uc);
                txbTitle1 = ""; txbTitle2 = ""; txbTitle3 = "";
            });

            GcEnInfoData = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new GcEnTongQuanUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Tổng quan / "; txbTitle3 = "Ép nhựa";
            });

            GcDkInfoData = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new GcDkTongQuanUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Tổng quan / "; txbTitle3 = "Dập khuôn";
            });

            HanInfoData = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new HanTongQuanUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Tổng quan / "; txbTitle3 = "Hàn";
            });

            SonInfoData = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new SonTongQuanUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Tổng quan / "; txbTitle3 = "Sơn";
            });

            LapRapInfoData = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new LapRapTongQuanUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Tổng quan / "; txbTitle3 = "Lắp ráp";
            });

            GcEnNhietDoData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new GcEnNhietDoUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Ép nhựa / "; txbTitle3 = "Biểu nhiệt độ";
            });

            GcEnProductData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new GcEnProductUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Ép nhựa / "; txbTitle3 = "Biểu sản lượng";
            });

            GcEnThoiGianData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new GcEnThoiGianUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Ép nhựa / "; txbTitle3 = "Biểu dừng máy";
            });

            GcEnCheckData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new GcEnCheckUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Ép nhựa / "; txbTitle3 = "Biểu kiểm tra";
            });

            GcEnThemNlData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new GcEnThemNlUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Ép nhựa / "; txbTitle3 = "Biểu thêm nguyên liệu";
            });

            GcEnBaoDuongData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new GcEnBaoDuongUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Ép nhựa / "; txbTitle3 = "Biểu bảo dưỡng";
            });

            GcEnSanLuongData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10) || (Cw3_Product.Properties.Settings.Default.UserLevel >= 20 && Cw3_Product.Properties.Settings.Default.UserLevel < 30))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new GcEnSanLuongUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Ép nhựa / "; txbTitle3 = "Nhập sản lượng hằng ngày";
            });

            GcDkCheckData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10) || (Cw3_Product.Properties.Settings.Default.UserLevel >= 10 && Cw3_Product.Properties.Settings.Default.UserLevel < 20))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new GcDkCheckUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Dập khuôn / "; txbTitle3 = "Biểu kiểm tra";
            });

            GcDkTimeData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10) || (Cw3_Product.Properties.Settings.Default.UserLevel >= 10 && Cw3_Product.Properties.Settings.Default.UserLevel < 20))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new GcDkTimeUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Dập khuôn / "; txbTitle3 = "Biểu thời gian";
            });

            GcDkProductData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10) || (Cw3_Product.Properties.Settings.Default.UserLevel >= 10 && Cw3_Product.Properties.Settings.Default.UserLevel < 20))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new GcDkProductUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Dập khuôn / "; txbTitle3 = "Biểu sản lượng";
            });

            GcDkSanLuongData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10) || (Cw3_Product.Properties.Settings.Default.UserLevel >= 10 && Cw3_Product.Properties.Settings.Default.UserLevel < 20))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new GcDkSanLuongUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Dập khuôn / "; txbTitle3 = "Nhập sản lượng hằng ngày";
            });

            HanInPutData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10) || (Cw3_Product.Properties.Settings.Default.UserLevel >= 30 && Cw3_Product.Properties.Settings.Default.UserLevel < 40))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new HanInputUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Hàn / "; txbTitle3 = "Nhập liệu";
            });

            HanOutPutData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10) || (Cw3_Product.Properties.Settings.Default.UserLevel >= 30 && Cw3_Product.Properties.Settings.Default.UserLevel < 40))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new HanOutputUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Hàn / "; txbTitle3 = "Trả liệu";
            });

            HanProductData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10) || (Cw3_Product.Properties.Settings.Default.UserLevel >= 30 && Cw3_Product.Properties.Settings.Default.UserLevel < 40))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new HanProductUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Hàn / "; txbTitle3 = "Sản lượng";
            });

            HanSanLuongData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10) || (Cw3_Product.Properties.Settings.Default.UserLevel >= 30 && Cw3_Product.Properties.Settings.Default.UserLevel < 40))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new HanSanLuongUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Hàn / "; txbTitle3 = "Nhập sản lượng hằng ngày";
                LrSlnew = false;
            });

            SonInPutData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10) || (Cw3_Product.Properties.Settings.Default.UserLevel >= 40 && Cw3_Product.Properties.Settings.Default.UserLevel < 50))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new SonInputUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Sơn / "; txbTitle3 = "Nhập liệu";
            });

            SonOutPutData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10) || (Cw3_Product.Properties.Settings.Default.UserLevel >= 40 && Cw3_Product.Properties.Settings.Default.UserLevel < 50))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new SonOutputUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Sơn / "; txbTitle3 = "Trả liệu";
            });

            SonProductData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10) || (Cw3_Product.Properties.Settings.Default.UserLevel >= 40 && Cw3_Product.Properties.Settings.Default.UserLevel < 50))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new SonProductUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Sơn / "; txbTitle3 = "Sản lượng";
            });

            SonSanLuongData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10) || (Cw3_Product.Properties.Settings.Default.UserLevel >= 40 && Cw3_Product.Properties.Settings.Default.UserLevel < 50))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new SonSanLuongUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Sơn / "; txbTitle3 = "Nhập sản lượng hằng ngày";
            });

            LapRapNguyenLieuData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10) || (Cw3_Product.Properties.Settings.Default.UserLevel >= 50 && Cw3_Product.Properties.Settings.Default.UserLevel < 60))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new LapRapNguyenLieuUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Lắp ráp / "; txbTitle3 = "Nguyên liệu";
                ClearLapRapNguyenLieu();
                loadLapRapNguyenLieu();
            });

            LapRapProductData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10) || (Cw3_Product.Properties.Settings.Default.UserLevel >= 50 && Cw3_Product.Properties.Settings.Default.UserLevel < 60))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new LapRapProductUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Lắp ráp / "; txbTitle3 = "Sản xuất";
                ClearLapRapSanxuat();
                loadLapRapSanXuat();
            });

            LapRapSanLuongData = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10) || (Cw3_Product.Properties.Settings.Default.UserLevel >= 50 && Cw3_Product.Properties.Settings.Default.UserLevel < 60))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new LapRapSanLuongUC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Lắp ráp / "; txbTitle3 = "Nhập sản lượng hằng ngày";
            });

            LapRapSanLuong2Data = new RelayCommand<Grid>((p) =>
            {
                if ((Cw3_Product.Properties.Settings.Default.UserLevel > 0 && Cw3_Product.Properties.Settings.Default.UserLevel < 10) || (Cw3_Product.Properties.Settings.Default.UserLevel >= 50 && Cw3_Product.Properties.Settings.Default.UserLevel < 60))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new LapRapSanLuong2UC(); p.Children.Add(uc);
                txbTitle1 = "Sản xuất / "; txbTitle2 = "Lắp ráp / "; txbTitle3 = "Nhập sản lượng hằng ngày";
            });

            //---------lum la---------
            {
                //===========================Command Lắp rap nguyên liệu===========================
                filtercommandLrNl = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    loadLapRapNguyenLieu();
                });

                addcommandLrNl = new RelayCommand<object>((p) =>
                {
                    if (LapRapNlNgay == null || string.IsNullOrEmpty(LapRapNlMaMuaHang) || string.IsNullOrEmpty(LapRapNlNhapXuat) || string.IsNullOrEmpty(LapRapNlDonVi) || LapRapNlSoLuong == null)
                        return false;
                    //var LrNllist = DataProvider.Ins.DB.LrNguyenLieu.Where(x => x.IdNlLr == LapRapNlId);
                    //if (LrNllist == null || LrNllist.Count() != 0) return false;
                    return true;
                }, (p) =>
                {
                    var themLrNl = new LrNguyenLieu() { Ngay = LapRapNlNgay, SoLuong = LapRapNlSoLuong, NhapXuat = LapRapNlNhapXuat, IdU = LapRapNlDonVi, MaMuaHang = LapRapNlMaMuaHang };

                    DataProvider.Ins.DB.LrNguyenLieu.Add(themLrNl);
                    DataProvider.Ins.DB.SaveChanges();
                    loadLapRapNguyenLieu();

                });

                editcommandLrNl = new RelayCommand<object>((p) =>
                {
                    if (LapRapNlNgay == null || string.IsNullOrEmpty(LapRapNlMaMuaHang) || string.IsNullOrEmpty(LapRapNlNhapXuat) || string.IsNullOrEmpty(LapRapNlDonVi) || LapRapNlSoLuong == null)
                        return false;
                    var LrNllist = DataProvider.Ins.DB.LrNguyenLieu.Where(x => x.IdNlLr == LapRapNlId);
                    if (LrNllist == null || LrNllist.Count() == 0) return false;

                    return true;
                }, (p) =>
                {
                    var suaLrNl = DataProvider.Ins.DB.LrNguyenLieu.Where(x => x.IdNlLr == LapRapNlId).SingleOrDefault();
                    suaLrNl.NhapXuat = LapRapNlNhapXuat;
                    suaLrNl.Ngay = LapRapNlNgay;
                    suaLrNl.MaMuaHang = LapRapNlMaMuaHang;
                    suaLrNl.SoLuong = LapRapNlSoLuong;
                    suaLrNl.IdU = LapRapNlDonVi;
                    DataProvider.Ins.DB.SaveChanges();
                    loadLapRapNguyenLieu();

                });

                deletecommandLrNl = new RelayCommand<object>((p) =>
                {
                    if (LapRapNlNgay == null || string.IsNullOrEmpty(LapRapNlMaMuaHang) || string.IsNullOrEmpty(LapRapNlNhapXuat) || string.IsNullOrEmpty(LapRapNlDonVi) || LapRapNlSoLuong == null)
                        return false;
                    var LrNllist = DataProvider.Ins.DB.LrNguyenLieu.Where(x => x.IdNlLr == LapRapNlId);
                    if (LrNllist == null || LrNllist.Count() == 0) return false;

                    return true;
                }, (p) =>
                {
                    var lrnl = DataProvider.Ins.DB.LrNguyenLieu;
                    foreach (var item in lrnl)
                    {
                        if (item.IdNlLr == LapRapNlId)
                        {
                            lrnl.Remove(item);
                        }
                    }
                    DataProvider.Ins.DB.SaveChanges();
                    loadLapRapNguyenLieu();
                });

                ClearLrNl = new RelayCommand<object>((p) =>
                {
                    return true;
                }, (p) =>
                {
                    ClearLapRapNguyenLieu();
                });

                //===========================Command Lắp rap sản xuất===========================
                filtercommandLrSx = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    loadLapRapSanXuat();
                });

                Filterngay = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    GridViewColumnHeader header = p as GridViewColumnHeader;
                    CollectionView View = (CollectionView)CollectionViewSource.GetDefaultView(LapRapSanXuatList);
                    if (issort)
                    {
                        View.SortDescriptions.Clear();
                        View.SortDescriptions.Add(new SortDescription(header.Name, ListSortDirection.Ascending));
                    }
                    else
                    {
                        View.SortDescriptions.Clear();
                        View.SortDescriptions.Add(new SortDescription(header.Name, ListSortDirection.Descending));
                    }
                    issort = !issort;
                });

                addcommandLrSx = new RelayCommand<object>((p) =>
                {
                    if (LapRapSxNgay == null || string.IsNullOrEmpty(LapRapSxChuyenLr) || string.IsNullOrEmpty(LapRapSxSoLo) || string.IsNullOrEmpty(LapRapSxMaTp) || LapRapSxSoLuong == null || string.IsNullOrEmpty(LapRapSxDonVi))
                        return false;
                    //var LrNllist = DataProvider.Ins.DB.LrNguyenLieu.Where(x => x.IdNlLr == LapRapNlId);
                    //if (LrNllist == null || LrNllist.Count() != 0) return false;
                    return true;
                }, (p) =>
                {
                    var themLrSx = new LrSanXuat() { Ngay = LapRapSxNgay, ChuyenLr = LapRapSxChuyenLr, SoLo = LapRapSxSoLo, MaTp = LapRapSxMaTp, SoLuong = LapRapSxSoLuong, IdU = LapRapSxDonVi, Phe = LapRapSxPhe };

                    DataProvider.Ins.DB.LrSanXuat.Add(themLrSx);
                    DataProvider.Ins.DB.SaveChanges();
                    loadLapRapSanXuat();

                });

                editcommandLrSx = new RelayCommand<object>((p) =>
                {
                    if (LapRapSxNgay == null || string.IsNullOrEmpty(LapRapSxChuyenLr) || string.IsNullOrEmpty(LapRapSxSoLo) || string.IsNullOrEmpty(LapRapSxMaTp) || LapRapSxSoLuong == null || string.IsNullOrEmpty(LapRapSxDonVi))
                        return false;
                    var LrSxlist = DataProvider.Ins.DB.LrSanXuat.Where(x => x.IdSxLr == LapRapSxId);
                    if (LrSxlist == null || LrSxlist.Count() == 0) return false;

                    return true;
                }, (p) =>
                {
                    var suaLrSx = DataProvider.Ins.DB.LrSanXuat.Where(x => x.IdSxLr == LapRapSxId).SingleOrDefault();
                    suaLrSx.Ngay = LapRapSxNgay;
                    suaLrSx.ChuyenLr = LapRapSxChuyenLr;
                    suaLrSx.SoLo = LapRapSxSoLo;
                    suaLrSx.MaTp = LapRapSxMaTp;
                    suaLrSx.SoLuong = LapRapSxSoLuong;
                    suaLrSx.IdU = LapRapSxDonVi;
                    suaLrSx.Phe = LapRapSxPhe;
                    DataProvider.Ins.DB.SaveChanges();
                    loadLapRapSanXuat();

                });

                deletecommandLrSx = new RelayCommand<object>((p) =>
                {
                    if (LapRapSxNgay == null || string.IsNullOrEmpty(LapRapSxChuyenLr) || string.IsNullOrEmpty(LapRapSxSoLo) || string.IsNullOrEmpty(LapRapSxMaTp) || LapRapSxSoLuong == null || string.IsNullOrEmpty(LapRapSxDonVi))
                        return false;
                    var LrSxlist = DataProvider.Ins.DB.LrSanXuat.Where(x => x.IdSxLr == LapRapSxId);
                    if (LrSxlist == null || LrSxlist.Count() == 0) return false;

                    return true;
                }, (p) =>
                {
                    var lrsx = DataProvider.Ins.DB.LrSanXuat;
                    foreach (var item in lrsx)
                    {
                        if (item.IdSxLr == LapRapSxId)
                        {
                            lrsx.Remove(item);
                        }
                    }
                    DataProvider.Ins.DB.SaveChanges();
                    loadLapRapSanXuat();
                });

                ClearLrSx = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    ClearLapRapSanxuat();
                });

                //===========================Command Lắp rap phiếu nhập sản lượng===========================
                LrSlTaoDon = new RelayCommand<object>((p) =>
                {
                    if (LrSlnew == true)
                        return false;

                    return true;
                }, (p) =>
                {
                    LrSlnew = true;
                    LrSlNgay = DateTime.Today;
                    LrSlCa = "Ngày";
                    LrSlChuyenLr = "Lr1";
                    LaprapTaoidnhaplieu();
                    PhieuSanLuongLapRapList = new ObservableCollection<PhieuSanLuongLapRapModel>();
                    LrSlStt1 = 0;
                    LapRapPheGCList = new ObservableCollection<LaprapPheGiacong>();
                    LrPheSTT1 = 0;
                    SoLoList = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp.Where(u => u.TinhTrang == "Sản xuất"));
                    donvilist = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
                    SoHoaList = new ObservableCollection<BomLkTp>(DataProvider.Ins.DB.BomLkTp);
                });

                SoloMaTp = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    if (string.IsNullOrEmpty(LrSlSoLo))
                    {

                    }
                    else
                    {
                        MaTpList = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp.Where(v => v.SoLo == LrSlSoLo));
                    }

                });

                SoloSoHoa = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    if (string.IsNullOrEmpty(LrSlPheSoLo))
                    {

                    }
                    else
                    {
                        SoHoaList = new ObservableCollection<BomLkTp>(DataProvider.Ins.DB.BomLkTp.Where(w => w.MaTp == DataProvider.Ins.DB.DonHangTp.Where(v => v.SoLo == LrSlPheSoLo).FirstOrDefault().MaTp));
                    }

                });

                LrSlXacNhan = new RelayCommand<object>((p) =>
                {
                    if (LrSlnew != true)
                        return false;

                    return true;
                }, (p) =>
                {

                    var check = MessageBox.Show("Bạn chắc chắn muốn xác nhận đơn hàng?", "Xác nhận đơn", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (check == MessageBoxResult.OK)
                    {
                        LrSanXuat lrsl = new LrSanXuat();
                        foreach (var item1 in PhieuSanLuongLapRapList)
                        {
                            lrsl.Ngay = LrSlNgay;
                            lrsl.ChuyenLr = LrSlChuyenLr;
                            lrsl.MaPhieu = LrSlId;
                            //lrsl.hourstart = item1.TimeStart;
                            //lrsl.hourend = item1.TimeEnd;
                            lrsl.SoLo = item1.Solo;
                            lrsl.MaTp = item1.MaTp;
                            lrsl.SoLuong = item1.SoLuong;
                            lrsl.Phe = item1.Phe;
                            lrsl.IdU = item1.DonVi;

                            DataProvider.Ins.DB.LrSanXuat.Add(lrsl);
                            DataProvider.Ins.DB.SaveChanges();
                        }

                        DKSanXuat dksl = new DKSanXuat();
                        foreach (var item2 in LapRapPheGCList)
                        {
                            dksl.Ngay = LrSlNgay;
                            dksl.NhanVien = LrSlChuyenLr;
                            dksl.MaPhieu = LrSlId; ;
                            dksl.SoLo = item2.Solo;
                            dksl.SoHoa = item2.SoHoa;
                            dksl.Phe = item2.Phe;
                            dksl.NguyenNhan = item2.NguyenNhan;
                            dksl.IdU = "pcs";

                            DataProvider.Ins.DB.DKSanXuat.Add(dksl);
                            DataProvider.Ins.DB.SaveChanges();
                        }

                        PhieuSanLuongLapRapList.Clear();
                        LapRapPheGCList.Clear();
                        ClearLapRapphieunhap();
                        ClearLapRapphieuSl();
                        ClearLapRapphieuPhe();
                        LrSlnew = false;
                    }
                    else if (check == MessageBoxResult.Cancel)
                    {

                    }

                });

                LrSlHuyDon = new RelayCommand<object>((p) =>
                {
                    if (LrSlnew != true)
                        return false;

                    return true;
                }, (p) =>
                {

                    var check = MessageBox.Show("Bạn chắc chắn muốn hủy đơn hàng?", "Hủy đơn", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (check == MessageBoxResult.OK)
                    {
                        PhieuSanLuongLapRapList.Clear();
                        LapRapPheGCList.Clear();
                        ClearLapRapphieunhap();
                        ClearLapRapphieuSl();
                        ClearLapRapphieuPhe();
                        LrSlnew = false;
                    }
                    else if (check == MessageBoxResult.Cancel)
                    {

                    }

                });

                LrSlNew = new RelayCommand<object>((p) =>
                {
                    if (LrSlnew != true)
                        return false;
                    if (string.IsNullOrEmpty(LrSlSoLo) || string.IsNullOrEmpty(LrSlMaTp) || string.IsNullOrEmpty(LrSlDonVi) || LrSlSoLuong == null)
                        return false;

                    return true;
                }, (p) =>
                {
                    PhieuSanLuongLapRapModel phieusl = new PhieuSanLuongLapRapModel();
                    LrSlStt1++;
                    phieusl.STT = LrSlStt1;
                    phieusl.TimeStart = LrSlTimeStart;
                    phieusl.TimeEnd = LrSlTimeEnd;
                    phieusl.Solo = LrSlSoLo;
                    phieusl.MaTp = LrSlMaTp;
                    phieusl.DonVi = LrSlDonVi;
                    phieusl.SoLuong = LrSlSoLuong;
                    phieusl.Phe = LrSlPhe;

                    PhieuSanLuongLapRapList.Add(phieusl);

                });

                LrSlDelete = new RelayCommand<object>((p) =>
                {
                    if (LrSlnew != true)
                        return false;
                    if (string.IsNullOrEmpty(LrSlSoLo) || string.IsNullOrEmpty(LrSlMaTp) || string.IsNullOrEmpty(LrSlDonVi) || LrSlSoLuong == null)
                        return false;
                    var index1 = PhieuSanLuongLapRapList.Where(x => x.STT == LrSlStt);
                    if (index1 == null || index1.Count() == 0) return false;

                    return true;
                }, (p) =>
                {
                    var phieusl1 = PhieuSanLuongLapRapList.Single(x => x.STT == LrSlStt);

                    PhieuSanLuongLapRapList.Remove(phieusl1);
                });

                LrSlClear = new RelayCommand<object>((p) =>
                {
                    if (LrSlnew != true)
                        return false;

                    return true;
                }, (p) =>
                {
                    ClearLapRapphieuSl();

                });

                LrSlPheNew = new RelayCommand<object>((p) =>
                {
                    if (LrSlnew != true)
                        return false;
                    if (string.IsNullOrEmpty(LrSlPheSoLo) || string.IsNullOrEmpty(LrSlPheSoHoa) || LrSlPhePhe == null)
                        return false;

                    return true;
                }, (p) =>
                {
                    LaprapPheGiacong phieuphe = new LaprapPheGiacong();

                    LrPheSTT1++;
                    phieuphe.STT = LrPheSTT1;
                    phieuphe.Solo = LrSlPheSoLo;
                    phieuphe.SoHoa = LrSlPheSoHoa;
                    phieuphe.Phe = LrSlPhePhe;
                    phieuphe.NguyenNhan = LrSlPheNguyenNhan;

                    LapRapPheGCList.Add(phieuphe);

                });

                LrSlPheDelete = new RelayCommand<object>((p) =>
                {
                    if (LrSlnew != true)
                        return false;
                    if (string.IsNullOrEmpty(LrSlPheSoLo) || string.IsNullOrEmpty(LrSlPheSoHoa) || LrSlPhePhe == null)
                        return false;
                    var index2 = LapRapPheGCList.Where(x => x.STT == LrPheSTT);
                    if (index2 == null || index2.Count() == 0) return false;

                    return true;
                }, (p) =>
                {
                    var phieuphe1 = LapRapPheGCList.Single(x => x.STT == LrPheSTT);

                    LapRapPheGCList.Remove(phieuphe1);

                });

                LrSlPheClear = new RelayCommand<object>((p) =>
                {
                    if (LrSlnew != true)
                        return false;

                    return true;
                }, (p) =>
                {
                    ClearLapRapphieuPhe();

                });

                LrSldatechange = new RelayCommand<object>((p) => { return true; }, (p) =>
                {
                    LaprapTaoidnhaplieu();
                });
            }

            

        }

        void loadLapRapNguyenLieu()
        {
            DateTime? LrNlStart = LapRapNlNgayStart;
            DateTime? LrNlEnd = LapRapNlNgayEnd;
            if (LrNlStart == null) LrNlStart =DateTime.MinValue;
            if (LrNlEnd == null) LrNlEnd = DateTime.Now;
            LapRapNguyenLieuList = new ObservableCollection<LrNguyenLieu>(DataProvider.Ins.DB.LrNguyenLieu.Where(x => x.Ngay >= LrNlStart && x.Ngay <= LrNlEnd));
            mamuahanglist = new ObservableCollection<BomNl>(DataProvider.Ins.DB.BomNl);
            donvilist = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
        }        
        void ClearLapRapNguyenLieu()
        {
            LapRapNlId = null;
            LapRapNlNgay = null;
            LapRapNlMaMuaHang = null;
            LapRapNlSoLuong = null;
            LapRapNlNhapXuat = null;
            LapRapNlDonVi = null;
            LapRapNlNgayStart = null;
            LapRapNlNgayEnd = null;
        }

        void loadLapRapSanXuat()
        {
            DateTime? LrSxStart = LapRapSxNgayStart;
            DateTime? LrSxEnd = LapRapSxNgayEnd;
            if (LrSxStart == null) LrSxStart = DateTime.MinValue;
            if (LrSxEnd == null) LrSxEnd = DateTime.Now;
            LapRapSanXuatList = new ObservableCollection<LrSanXuat>(DataProvider.Ins.DB.LrSanXuat.Where(x => x.Ngay >= LrSxStart && x.Ngay <= LrSxEnd));
            SoLoList = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp.Where(u => u.TinhTrang == "Sản xuất"));
            MaTpList = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp.Where(v => v.TinhTrang == "Sản xuất"));
            donvilist = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
        }
        void ClearLapRapSanxuat()
        {
            LapRapSxId = null;
            LapRapSxNgay = null;
            LapRapSxChuyenLr = null;
            LapRapSxSoLo = null;
            LapRapSxMaTp = null;
            LapRapSxSoLuong = null;
            LapRapSxDonVi = null;
            LapRapSxPhe = null;
        }

        void ClearLapRapphieunhap()
        {
            LrSlNgay = null;
            LrSlCa = null;
            LrSlChuyenLr = null;
            LrSlId = null;
        }
        void LaprapTaoidnhaplieu()
        {
            DateTime timetam = DateTime.Today;
            string timeint = "";
            int stt = 0;
            int maid = 0;
            bool flag=false;
            if (LrSlNgay != null) { timetam = (DateTime)LrSlNgay; }
            timeint = timetam.ToString("yyMMdd");
            maid = Int32.Parse(timeint, 0);
            stt = maid * 1000 + 1;
            for (int i = stt; flag == false; i++) 
            {
                var check = DataProvider.Ins.DB.LrSanXuat.Where(x => x.MaPhieu == i.ToString());
                if (check == null || check.Count() == 0)
                {
                    stt = i;
                    flag = true;
                }
            }
            LrSlId = "Lr-" + stt.ToString();
        }
        void ClearLapRapphieuSl()
        {
            LrSlStt = null;
            LrSlTimeStart = null;
            LrSlTimeEnd = null;
            LrSlSoLo = null;
            LrSlMaTp = null;
            LrSlDonVi = null;
            LrSlSoLuong = null;
            LrSlPhe = null;
        }
        void ClearLapRapphieuPhe()
        {
            LrPheSTT = null;
            LrSlPheSoLo = null;
            LrSlPheSoHoa = null;
            LrSlPhePhe = null;
            LrSlPheNguyenNhan = null;
        }
    }
}
