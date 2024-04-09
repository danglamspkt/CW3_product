using Cw3_Product.Model;
using Cw3_Product.UserControlBOM;
using Cw3_Product.ViewModel;
using Cw3_Product.UserControlKeHoach;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using Cw3_Product.UserControlMenu;
using System.Runtime.CompilerServices;

namespace Cw3_Product.ViewModel
{
    public class BomViewModel : BaseViewModel
    {
        //Khai báo list hiển thị BOM tổng hợp
        private ObservableCollection<BOMTongHopModel> _BomTHList;
        public ObservableCollection<BOMTongHopModel> BomTHList { get => _BomTHList; set { _BomTHList = value; OnPropertyChanged(); } }

        //Khai báo list hiển thị BOM tổng hợp
        private ObservableCollection<BOMTongHopModel> _BomTHList2;
        public ObservableCollection<BOMTongHopModel> BomTHList2 { get => _BomTHList2; set { _BomTHList2 = value; OnPropertyChanged(); } }

        //Khai báo list hiển thị BOM nguyên liệu
        private ObservableCollection<BomNguyenLieuModel> _BomNLList;
        public ObservableCollection<BomNguyenLieuModel> BomNLList { get => _BomNLList; set { _BomNLList = value; OnPropertyChanged(); } }

        //Khai báo list hiển thị BOM linh kiện
        private ObservableCollection<BomLinhKienModel> _BomLKList;
        public ObservableCollection<BomLinhKienModel> BomLKList { get => _BomLKList; set { _BomLKList = value; OnPropertyChanged(); } }

        //Khai báo list hiển thị BOM Thành phẩm
        private ObservableCollection<BomThanhPhamModel> _BomTPList;
        public ObservableCollection<BomThanhPhamModel> BomTPList { get => _BomTPList; set { _BomTPList = value; OnPropertyChanged(); } }

        //Khai báo list hiển thị đơn vị
        private ObservableCollection<UnitModel> _UnitList;
        public ObservableCollection<UnitModel> UnitList { get => _UnitList; set { _UnitList = value; OnPropertyChanged(); } }

        //Khai báo list hiển thị BOM linh kiện thành phẩm
        private ObservableCollection<BomLkTp> _BomLKTPList;
        public ObservableCollection<BomLkTp> BomLKTPList { get => _BomLKTPList; set { _BomLKTPList = value; OnPropertyChanged(); } }

        //Khai báo Usercontrol
        public UserControl uc { get; set; }


        //khai báo hiển thị địa chỉ
        private string _txbTitle1;
        public string txbTitle1 { get => _txbTitle1; set { _txbTitle1 = value; OnPropertyChanged(); } }

        private string _txbTitle2;
        public string txbTitle2 { get => _txbTitle2; set { _txbTitle2 = value; OnPropertyChanged(); } }

        private string _txbTitle3;
        public string txbTitle3 { get => _txbTitle3; set { _txbTitle3 = value; OnPropertyChanged(); } }


        //Khai báo hiển thị UC con
        public ICommand Homedata { get; set; }
        public ICommand BomTHdata { get; set; }
        public ICommand BomLkdata { get; set; }
        public ICommand BomTpdata { get; set; }
        public ICommand BomNldata { get; set; }
        public ICommand Unitdata { get; set; }
        public ICommand BomLkTpdata { get; set; }

        //Khai báo command thêm sửa xóa BOM linh kiện thành phẩm
        public ICommand addcommandlktp { get; set; }
        public ICommand editcommandlktp { get; set; }
        public ICommand deletecommandlktp { get; set; }
        public ICommand Clearlktp { get; set; }

        //Khai báo command thêm sửa xóa BOM linh kiện
        public ICommand addcommandlk { get; set; }
        public ICommand editcommandlk { get; set; }
        public ICommand deletecommandlk { get; set; }
        public ICommand Clearlk { get; set; }

        //Khai báo command thêm sửa xóa BOM nguyên liệu
        public ICommand addcommandnl { get; set; }
        public ICommand editcommandnl { get; set; }
        public ICommand deletecommandnl { get; set; }
        public ICommand Clearnl { get; set; }

        //Khai báo command thêm sửa xóa BOM thành phẩm
        public ICommand addcommandtp { get; set; }
        public ICommand editcommandtp { get; set; }
        public ICommand deletecommandtp { get; set; }
        public ICommand Cleartp { get; set; }

        //Khai báo command thêm sửa xóa đơn vị
        public ICommand addcommandUnit { get; set; }
        public ICommand editcommandUnit { get; set; }
        public ICommand deletecommandUnit { get; set; }
        public ICommand ClearUnit { get; set; }


        //Khai danh sách combobox
        private ObservableCollection<BomTp> _cbMatp;
        public ObservableCollection<BomTp> cbMatp { get => _cbMatp; set { _cbMatp = value; OnPropertyChanged(); } }

        private ObservableCollection<BomLk> _cbSoHoa;
        public ObservableCollection<BomLk> cbSoHoa { get => _cbSoHoa; set { _cbSoHoa = value; OnPropertyChanged(); } }

        private ObservableCollection<BomNl> _cbMaMuaHang;
        public ObservableCollection<BomNl> cbMaMuaHang { get => _cbMaMuaHang; set { _cbMaMuaHang = value; OnPropertyChanged(); } }

        private ObservableCollection<Unit> _cbUnit;
        public ObservableCollection<Unit> cbUnit { get => _cbUnit; set { _cbUnit = value; OnPropertyChanged(); } }


        //Khai báo biến BOM linh kiện thành phẩm
        private int? _lktpSTT;
        public int? lktpSTT { get => _lktpSTT; set { _lktpSTT = value; OnPropertyChanged(); } }

        private string _lktpMaTp;
        public string lktpMaTp { get => _lktpMaTp; set { _lktpMaTp = value; OnPropertyChanged(); } }

        private string _lktpSoHoa;
        public string lktpSoHoa { get => _lktpSoHoa; set { _lktpSoHoa = value; OnPropertyChanged(); } }

        private string _lktpMaMuaHang;
        public string lktpMaMuaHang { get => _lktpMaMuaHang; set { _lktpMaMuaHang = value; OnPropertyChanged(); } }

        private int? _lktpHeSo;
        public int? lktpHeSo { get => _lktpHeSo; set { _lktpHeSo = value; OnPropertyChanged(); } }

        private bool? _lktpDk;
        public bool? lktpDk { get => _lktpDk; set { _lktpDk = value; OnPropertyChanged(); } }

        private bool? _lktpEn;
        public bool? lktpEn { get => _lktpEn; set { _lktpEn = value; OnPropertyChanged(); } }

        private bool? _lktpHan;
        public bool? lktpHan { get => _lktpHan; set { _lktpHan = value; OnPropertyChanged(); } }

        private bool? _lktpSon;
        public bool? lktpSon { get => _lktpSon; set { _lktpSon = value; OnPropertyChanged(); } }

        private bool? _lktpLr;
        public bool? lktpLr { get => _lktpLr; set { _lktpLr = value; OnPropertyChanged(); } }

        private Model.BomLkTp _SelectedItemlktp;
        public Model.BomLkTp SelectedItemlktp
        {
            get => _SelectedItemlktp; set
            {
                _SelectedItemlktp = value; OnPropertyChanged(); if (_SelectedItemlktp != null)
                {
                    lktpSTT = SelectedItemlktp.IdLkTp;
                    lktpMaTp = SelectedItemlktp.MaTp;
                    lktpSoHoa = SelectedItemlktp.SoHoa;
                    lktpMaMuaHang = SelectedItemlktp.MaMuaHang;
                    lktpHeSo = SelectedItemlktp.HeSo;
                    lktpDk = SelectedItemlktp.DapKhuon;
                    lktpEn = SelectedItemlktp.EpNhua;
                    lktpHan = SelectedItemlktp.Han;
                    lktpSon = SelectedItemlktp.Son;
                    lktpLr = SelectedItemlktp.LapRap;

                }
            }
        }

        //Khai báo biến BOM linh kiện
        private int? _lkSTT;
        public int? lkSTT { get => _lkSTT; set { _lkSTT = value; OnPropertyChanged(); } }

        private string _lkSoHoa;
        public string lkSoHoa { get => _lkSoHoa; set { _lkSoHoa = value; OnPropertyChanged(); } }

        private string _lkDisplayName;
        public string lkDisplayName { get => _lkDisplayName; set { _lkDisplayName = value; OnPropertyChanged(); } }

        private string _lkQuyCach;
        public string lkQuyCach { get => _lkQuyCach; set { _lkQuyCach = value; OnPropertyChanged(); } }

        private string _lkDonVi;
        public string lkDonVi { get => _lkDonVi; set { _lkDonVi = value; OnPropertyChanged(); } }

        private bool? _lkDk;
        public bool? lkDk { get => _lkDk; set { _lkDk = value; OnPropertyChanged(); } }

        private bool? _lkEn;
        public bool? lkEn { get => _lkEn; set { _lkEn = value; OnPropertyChanged(); } }

        private bool? _lkHan;
        public bool? lkHan { get => _lkHan; set { _lkHan = value; OnPropertyChanged(); } }

        private bool? _lkSon;
        public bool? lkSon { get => _lkSon; set { _lkSon = value; OnPropertyChanged(); } }

        private bool? _lkLr;
        public bool? lkLr { get => _lkLr; set { _lkLr = value; OnPropertyChanged(); } }

        private Model.BomLinhKienModel _SelectedItemlk;
        public Model.BomLinhKienModel SelectedItemlk
        {
            get => _SelectedItemlk; set
            {
                _SelectedItemlk = value; OnPropertyChanged(); if (_SelectedItemlk != null)
                {
                    lkSTT = SelectedItemlk.STT;
                    lkSoHoa = SelectedItemlk.SoHoa;
                    lkDisplayName = SelectedItemlk.TenLK;
                    lkQuyCach = SelectedItemlk.QuyCach;
                    lkDonVi = SelectedItemlk.DonVi;
                    lkDk = SelectedItemlk.DapKhuon;
                    lkEn = SelectedItemlk.EpNhua;
                    lkHan = SelectedItemlk.Han;
                    lkSon = SelectedItemlk.Son;
                    lkLr = SelectedItemlk.LapRap;

                }
            }
        }


        //Khai báo biến BOM nguyên liệu
        private int? _nlSTT;
        public int? nlSTT { get => _nlSTT; set { _nlSTT = value; OnPropertyChanged(); } }

        private string _nlMaMuaHang;
        public string nlMaMuaHang { get => _nlMaMuaHang; set { _nlMaMuaHang = value; OnPropertyChanged(); } }

        private string _nlDisplayName;
        public string nlDisplayName { get => _nlDisplayName; set { _nlDisplayName = value; OnPropertyChanged(); } }

        private string _nlDonVi;
        public string nlDonVi { get => _nlDonVi; set { _nlDonVi = value; OnPropertyChanged(); } }

        private string _nlChatLieu;
        public string nlChatLieu { get => _nlChatLieu; set { _nlChatLieu = value; OnPropertyChanged(); } }

        private string _nlQuyCach;
        public string nlQuyCach { get => _nlQuyCach; set { _nlQuyCach = value; OnPropertyChanged(); } }

        private string _nlPhanLoai;
        public string nlPhanLoai { get => _nlPhanLoai; set { _nlPhanLoai = value; OnPropertyChanged(); } }

        private bool? _nlDk;
        public bool? nlDk { get => _nlDk; set { _nlDk = value; OnPropertyChanged(); } }

        private bool? _nlEn;
        public bool? nlEn { get => _nlEn; set { _nlEn = value; OnPropertyChanged(); } }

        private bool? _nlHan;
        public bool? nlHan { get => _nlHan; set { _nlHan = value; OnPropertyChanged(); } }

        private bool? _nlSon;
        public bool? nlSon { get => _nlSon; set { _nlSon = value; OnPropertyChanged(); } }

        private bool? _nlLr;
        public bool? nlLr { get => _nlLr; set { _nlLr = value; OnPropertyChanged(); } }

        private Model.BomNguyenLieuModel _SelectedItemnl;
        public Model.BomNguyenLieuModel SelectedItemnl
        {
            get => _SelectedItemnl; set
            {
                _SelectedItemnl = value; OnPropertyChanged(); if (_SelectedItemnl != null)
                {
                    nlSTT = SelectedItemnl.STT;
                    nlMaMuaHang = SelectedItemnl.MaMuaHang;
                    nlDisplayName = SelectedItemnl.TenNL;
                    nlDonVi = SelectedItemnl.DonVi;
                    nlChatLieu = SelectedItemnl.ChatLieu;
                    nlQuyCach = SelectedItemnl.QuyCach;
                    nlPhanLoai = SelectedItemnl.PhanLoaiBOM;
                    nlDk = SelectedItemnl.DapKhuon;
                    nlEn = SelectedItemnl.EpNhua;
                    nlHan = SelectedItemnl.Han;
                    nlSon = SelectedItemnl.Son;
                    nlLr = SelectedItemnl.LapRap;
                }
            }
        }

        //Khai báo biến BOM thành phẩm
        private int? _tpSTT;
        public int? tpSTT { get => _tpSTT; set { _tpSTT = value; OnPropertyChanged(); } }

        private string _tpMaTp;
        public string tpMaTp { get => _tpMaTp; set { _tpMaTp = value; OnPropertyChanged(); } }

        private string _tpDisplayName;
        public string tpDisplayName { get => _tpDisplayName; set { _tpDisplayName = value; OnPropertyChanged(); } }

        private string _tpDonVi;
        public string tpDonVi { get => _tpDonVi; set { _tpDonVi = value; OnPropertyChanged(); } }

        private Model.BomThanhPhamModel _SelectedItemtp;
        public Model.BomThanhPhamModel SelectedItemtp
        {
            get => _SelectedItemtp; set
            {
                _SelectedItemtp = value; OnPropertyChanged(); if (_SelectedItemtp != null)
                {
                    tpSTT = SelectedItemtp.STT;
                    tpMaTp = SelectedItemtp.MaTp;
                    tpDisplayName = SelectedItemtp.TenBX;
                    tpDonVi = SelectedItemtp.DonVi;
                }
            }
        }

        //Khai báo biến BOM thành phẩm
        private int? _UnitTT;
        public int? UnitTT { get => _UnitTT; set { _UnitTT = value; OnPropertyChanged(); } }

        private string _UnitId;
        public string UnitId { get => _UnitId; set { _UnitId = value; OnPropertyChanged(); } }

        private string _UnitDisplayName;
        public string UnitDisplayName { get => _UnitDisplayName; set { _UnitDisplayName = value; OnPropertyChanged(); } }

        private Model.UnitModel _SelectedItemUnit;
        public Model.UnitModel SelectedItemUnit
        {
            get => _SelectedItemUnit; set
            {
                _SelectedItemUnit = value; OnPropertyChanged(); if (_SelectedItemUnit != null)
                {
                    UnitTT = SelectedItemUnit.STT;
                    UnitId = SelectedItemUnit.IdU;
                    UnitDisplayName = SelectedItemUnit.DisplayName;
                }
            }
        }

        private string _ThMaTp;
        public string ThMaTp { get => _ThMaTp; set { _ThMaTp = value; OnPropertyChanged(); } }

        private string _ThDisplayName1;
        public string ThDisplayName1 { get => _ThDisplayName1; set { _ThDisplayName1 = value; OnPropertyChanged(); } }

        private string _ThSoHoa;
        public string ThSoHoa { get => _ThSoHoa; set { _ThSoHoa = value; OnPropertyChanged(); } }

        private string _ThDisplayName2;
        public string ThDisplayName2 { get => _ThDisplayName2; set { _ThDisplayName2 = value; OnPropertyChanged(); } }

        private string _ThDonVi;
        public string ThDonVi { get => _ThDonVi; set { _ThDonVi = value; OnPropertyChanged(); } }

        private string _ThChatLieu;
        public string ThChatLieu { get => _ThChatLieu; set { _ThChatLieu = value; OnPropertyChanged(); } }

        private string _ThQuyCach;
        public string ThQuyCach { get => _ThQuyCach; set { _ThQuyCach = value; OnPropertyChanged(); } }

        private string _ThPhanLoai;
        public string ThPhanLoai { get => _ThPhanLoai; set { _ThPhanLoai = value; OnPropertyChanged(); } }

        public ICommand valuechangecommand { get; set; }

        public BomViewModel() 
        {
            LoadUnit();
            txbTitle1 = ""; txbTitle2 = ""; txbTitle3 = "";

            MainWindow mainwindow = new MainWindow();
            var mainVM = mainwindow.DataContext as MainViewModel;

            int level = mainVM.Userlevel;
            mainwindow.Close();  


            Homedata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new BOMHomeUC(); p.Children.Add(uc);
                txbTitle1 = ""; txbTitle2 = ""; txbTitle3 = "";
            });

            BomTHdata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new BomTHUC(); p.Children.Add(uc);
                txbTitle1 = "Kế Hoạch / "; txbTitle2 = "Tổng quan / "; txbTitle3 = "B.O.M Tổng hợp";
                loadBomTH();
            });

            BomLkdata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                    p.Children.Clear(); uc = new BomLkUC(); p.Children.Add(uc);
                    txbTitle1 = "Kế Hoạch / "; txbTitle2 = "B.O.M Linh Kiện / "; txbTitle3 = "B.O.M Linh Kiện";
                    loadBomlk();
               
            });

            BomTpdata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new BomTPUC(); p.Children.Add(uc);
                txbTitle1 = "Kế Hoạch / "; txbTitle2 = "B.O.M Thành phẩm / "; txbTitle3 = "B.O.M Thành phẩm";
                loadBomTP();
            });

            BomNldata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new BomNLUC(); p.Children.Add(uc);
                txbTitle1 = "Kế Hoạch / "; txbTitle2 = "B.O.M Nguyên liệu / "; txbTitle3 = "B.O.M Nguyên liệu";
                loadBomNL();
            });

            Unitdata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new UnitUC(); p.Children.Add(uc);
                txbTitle1 = "Kế Hoạch / "; txbTitle2 = "Đơn vị / "; txbTitle3 = "Đơn vị";
                LoadUnit();
            });

            BomLkTpdata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                    p.Children.Clear(); uc = new BomLkTpUC(); p.Children.Add(uc);
                    txbTitle1 = "Kế Hoạch / "; txbTitle2 = "Tổng quan / "; txbTitle3 = "B.O.M Linh Kiện - Thành Phẩm";
                    loadBomLkTp();
            });


            //command BOM linh kiện thành phẩm
            addcommandlktp = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(lktpMaTp) || string.IsNullOrEmpty(lktpSoHoa) || string.IsNullOrEmpty(lktpMaMuaHang) || lktpHeSo == null || lktpHeSo <= 0)
                    return false;
                var lktplist = DataProvider.Ins.DB.BomLkTp.Where(x => x.MaTp == lktpMaTp && x.SoHoa == lktpSoHoa && x.MaMuaHang == lktpMaMuaHang && x.HeSo == lktpHeSo);
                if (lktplist == null || lktplist.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                var themdonlktp = new BomLkTp() { MaTp = lktpMaTp, SoHoa = lktpSoHoa, MaMuaHang = lktpMaMuaHang, HeSo = lktpHeSo, DapKhuon = lktpDk, EpNhua = lktpEn, Han = lktpHan, Son = lktpSon, LapRap = lktpLr, UserName = Cw3_Product.Properties.Settings.Default.account };

                DataProvider.Ins.DB.BomLkTp.Add(themdonlktp);
                DataProvider.Ins.DB.SaveChanges();
                loadBomLkTp();
            });

            editcommandlktp = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(lktpMaTp) || string.IsNullOrEmpty(lktpSoHoa) || string.IsNullOrEmpty(lktpMaMuaHang) || lktpHeSo == null || lktpHeSo <= 0)
                    return false;
                var sttlist = DataProvider.Ins.DB.BomLkTp.Where(x => x.IdLkTp == lktpSTT);
                if (sttlist == null || sttlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var suadonlktp = DataProvider.Ins.DB.BomLkTp.Where(x => x.IdLkTp == lktpSTT).SingleOrDefault();
                suadonlktp.MaTp = lktpMaTp;
                suadonlktp.SoHoa = lktpSoHoa;
                suadonlktp.MaMuaHang = lktpMaMuaHang;
                suadonlktp.HeSo = lktpHeSo;
                suadonlktp.DapKhuon = lktpDk;
                suadonlktp.EpNhua = lktpEn;
                suadonlktp.Han = lktpHan;
                suadonlktp.Son = lktpSon;
                suadonlktp.LapRap = lktpLr;
                suadonlktp.UserName = Cw3_Product.Properties.Settings.Default.account;
                DataProvider.Ins.DB.SaveChanges();
                loadBomLkTp();

            });

            deletecommandlktp = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(lktpMaTp) || string.IsNullOrEmpty(lktpSoHoa) || string.IsNullOrEmpty(lktpMaMuaHang) || lktpHeSo == null || lktpHeSo <= 0)
                    return false;
                var sttlist = DataProvider.Ins.DB.BomLkTp.Where(x => x.IdLkTp == lktpSTT);
                if (sttlist == null || sttlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                try
                {
                    var bomlktp = DataProvider.Ins.DB.BomLkTp.Where(x => x.IdLkTp == lktpSTT).SingleOrDefault();
                    DataProvider.Ins.DB.BomLkTp.Remove(bomlktp);
                    DataProvider.Ins.DB.SaveChanges();
                    loadBomLkTp();
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã hàng đang sử dụng, không thể xóa!", "Xóa mã hàng!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            Clearlktp = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                clearbomlktp();
            });


            //Command BOM linh kiện
            addcommandlk = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(lkSoHoa) || string.IsNullOrEmpty(lkDonVi) || string.IsNullOrEmpty(lkQuyCach) || string.IsNullOrEmpty(lkDisplayName))
                    return false;
                var lklist = DataProvider.Ins.DB.BomLk.Where(x => x.SoHoa == lkSoHoa);
                if (lklist == null || lklist.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                var themdonlk = new BomLk() { SoHoa = lkSoHoa, DisplayName = lkDisplayName, QuyCach = lkQuyCach, IdU = lkDonVi, DapKhuon = lkDk, EpNhua = lkEn, Han = lkHan, Son = lkSon, LapRap = lkLr, UserName = Cw3_Product.Properties.Settings.Default.account };

                DataProvider.Ins.DB.BomLk.Add(themdonlk);
                DataProvider.Ins.DB.SaveChanges();
                loadBomlk();
            });

            editcommandlk = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(lkSoHoa) || string.IsNullOrEmpty(lkDonVi) || string.IsNullOrEmpty(lkQuyCach) || string.IsNullOrEmpty(lkDisplayName))
                    return false;
                var lklist = DataProvider.Ins.DB.BomLk.Where(x => x.SoHoa == lkSoHoa);
                if (lklist == null || lklist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var suadonlk = DataProvider.Ins.DB.BomLk.Where(x => x.SoHoa == lkSoHoa).SingleOrDefault();
                suadonlk.DisplayName = lkDisplayName;
                suadonlk.QuyCach = lkQuyCach;
                suadonlk.IdU = lkDonVi;
                suadonlk.DapKhuon = lkDk;
                suadonlk.EpNhua = lkEn;
                suadonlk.Han = lkHan;
                suadonlk.Son = lkSon;
                suadonlk.LapRap = lkLr;
                suadonlk.UserName = Cw3_Product.Properties.Settings.Default.account;
                DataProvider.Ins.DB.SaveChanges();
                loadBomlk();

            });

            deletecommandlk = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(lkSoHoa) || string.IsNullOrEmpty(lkDonVi) || string.IsNullOrEmpty(lkQuyCach) || string.IsNullOrEmpty(lkDisplayName))
                    return false;
                var lklist = DataProvider.Ins.DB.BomLk.Where(x => x.SoHoa == lkSoHoa);
                if (lklist == null || lklist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                try
                {
                    var bomlk = DataProvider.Ins.DB.BomLk.Where(x => x.SoHoa == lkSoHoa).SingleOrDefault();
                    DataProvider.Ins.DB.BomLk.Remove(bomlk);
                    DataProvider.Ins.DB.SaveChanges();
                    loadBomlk();
                }
                catch (Exception )
                {
                    MessageBox.Show("Mã hàng đang sử dụng, không thể xóa!", "Xóa mã hàng!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            });

            Clearlk = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                clearbomlk();
            });


            //Command BOM nguyên liệu
            addcommandnl = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(nlMaMuaHang) || string.IsNullOrEmpty(nlDisplayName) || string.IsNullOrEmpty(nlDonVi) || string.IsNullOrEmpty(nlChatLieu) || string.IsNullOrEmpty(nlQuyCach) || string.IsNullOrEmpty(nlPhanLoai))
                    return false;
                var nllist = DataProvider.Ins.DB.BomNl.Where(x => x.MaMuaHang == nlMaMuaHang);
                if (nllist == null || nllist.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                var themdonnl = new BomNl() { MaMuaHang = nlMaMuaHang , DisplayName = nlDisplayName , IdU = nlDonVi , ChatLieu = nlChatLieu , QuyCach = nlQuyCach , PhanLoaiBom = nlPhanLoai, DapKhuon = nlDk, EpNhua = nlEn, Han = nlHan, Son = nlSon, LapRap = nlLr, UserName = Cw3_Product.Properties.Settings.Default.account };

                DataProvider.Ins.DB.BomNl.Add(themdonnl);
                DataProvider.Ins.DB.SaveChanges();
                loadBomNL();
            });

            editcommandnl = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(nlMaMuaHang) || string.IsNullOrEmpty(nlDisplayName) || string.IsNullOrEmpty(nlDonVi) || string.IsNullOrEmpty(nlChatLieu) || string.IsNullOrEmpty(nlQuyCach) || string.IsNullOrEmpty(nlPhanLoai))
                    return false;
                var nllist = DataProvider.Ins.DB.BomNl.Where(x => x.MaMuaHang == nlMaMuaHang);
                if (nllist == null || nllist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var suadonnl = DataProvider.Ins.DB.BomNl.Where(x => x.MaMuaHang == nlMaMuaHang).SingleOrDefault();
                suadonnl.DisplayName = nlDisplayName;
                suadonnl.IdU = nlDonVi;
                suadonnl.ChatLieu = nlChatLieu;
                suadonnl.QuyCach = nlQuyCach;
                suadonnl.PhanLoaiBom = nlPhanLoai;
                suadonnl.DapKhuon = nlDk;
                suadonnl.EpNhua = nlEn;
                suadonnl.Han = nlHan;
                suadonnl.Son = nlSon;
                suadonnl.LapRap = nlLr;
                suadonnl.UserName = Cw3_Product.Properties.Settings.Default.account;
                DataProvider.Ins.DB.SaveChanges();
                loadBomNL();

            });

            deletecommandnl = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(nlMaMuaHang) || string.IsNullOrEmpty(nlDisplayName) || string.IsNullOrEmpty(nlDonVi) || string.IsNullOrEmpty(nlChatLieu) || string.IsNullOrEmpty(nlQuyCach) || string.IsNullOrEmpty(nlPhanLoai))
                    return false;
                var nllist = DataProvider.Ins.DB.BomNl.Where(x => x.MaMuaHang == nlMaMuaHang);
                if (nllist == null || nllist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                try
                {
                    var bomnl = DataProvider.Ins.DB.BomNl.Where(x => x.MaMuaHang == nlMaMuaHang).SingleOrDefault();
                    DataProvider.Ins.DB.BomNl.Remove(bomnl);
                    DataProvider.Ins.DB.SaveChanges();
                    loadBomNL();
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã hàng đang sử dụng, không thể xóa!", "Xóa mã hàng!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            Clearnl = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                clearbomnl();
            });

            //Command BOM thành phẩm
            addcommandtp = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(tpMaTp) || string.IsNullOrEmpty(tpDisplayName) || string.IsNullOrEmpty(tpDonVi))
                    return false;
                var tplist = DataProvider.Ins.DB.BomTp.Where(x => x.MaTp == tpMaTp);
                if (tplist == null || tplist.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                var themdontp = new BomTp() { MaTp = tpMaTp, DisplayName = tpDisplayName, IdU = tpDonVi , UserName = Cw3_Product.Properties.Settings.Default.account };

                DataProvider.Ins.DB.BomTp.Add(themdontp);
                DataProvider.Ins.DB.SaveChanges();
                loadBomTP();
            });

            editcommandtp = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(tpMaTp) || string.IsNullOrEmpty(tpDisplayName) || string.IsNullOrEmpty(tpDonVi))
                    return false;
                var tplist = DataProvider.Ins.DB.BomTp.Where(x => x.MaTp == tpMaTp);
                if (tplist == null || tplist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var suadontp = DataProvider.Ins.DB.BomTp.Where(x => x.MaTp == tpMaTp).SingleOrDefault();
                suadontp.DisplayName = tpDisplayName;
                suadontp.IdU = tpDonVi;
                suadontp.UserName = Cw3_Product.Properties.Settings.Default.account;
                DataProvider.Ins.DB.SaveChanges();
                loadBomTP();

            });

            deletecommandtp = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(tpMaTp) || string.IsNullOrEmpty(tpDisplayName) || string.IsNullOrEmpty(tpDonVi))
                    return false;
                var tplist = DataProvider.Ins.DB.BomTp.Where(x => x.MaTp == tpMaTp);
                if (tplist == null || tplist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                try
                {
                    var bomtp = DataProvider.Ins.DB.BomTp.Where(x => x.MaTp == tpMaTp).SingleOrDefault();
                    DataProvider.Ins.DB.BomTp.Remove(bomtp);
                    DataProvider.Ins.DB.SaveChanges();
                    loadBomTP();
                }
                catch (Exception )
                {
                    MessageBox.Show("Mã hàng đang sử dụng, không thể xóa!", "Xóa mã hàng!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            });

            Cleartp = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                clearbomtp();
            });

            //Command Đơn vị
            addcommandUnit = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(UnitId) || string.IsNullOrEmpty(UnitDisplayName))
                    return false;
                var Unitlist = DataProvider.Ins.DB.Unit.Where(x => x.IdU == UnitId);
                if (Unitlist == null || Unitlist.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                var themdonUnit = new Unit() { IdU = UnitId, DisplayName = UnitDisplayName , UserName = Cw3_Product.Properties.Settings.Default.account };

                DataProvider.Ins.DB.Unit.Add(themdonUnit);
                DataProvider.Ins.DB.SaveChanges();
                LoadUnit();
            });

            editcommandUnit = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(UnitId) || string.IsNullOrEmpty(UnitDisplayName))
                    return false;
                var Unitlist = DataProvider.Ins.DB.Unit.Where(x => x.IdU == UnitId);
                if (Unitlist == null || Unitlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var suadonUnit = DataProvider.Ins.DB.Unit.Where(x => x.IdU == UnitId).SingleOrDefault();
                suadonUnit.DisplayName = UnitDisplayName;
                suadonUnit.UserName = Cw3_Product.Properties.Settings.Default.account;
                DataProvider.Ins.DB.SaveChanges();
                LoadUnit();

            });

            deletecommandUnit = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(UnitId) || string.IsNullOrEmpty(UnitDisplayName))
                    return false;
                var Unitlist = DataProvider.Ins.DB.Unit.Where(x => x.IdU == UnitId);
                if (Unitlist == null || Unitlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                try
                {
                    var unit = DataProvider.Ins.DB.Unit.Where(x => x.IdU == UnitId).SingleOrDefault();
                    DataProvider.Ins.DB.Unit.Remove(unit);
                    DataProvider.Ins.DB.SaveChanges();
                    LoadUnit();
                }
                catch (Exception) 
                {
                    MessageBox.Show("Mã hàng đang sử dụng, không thể xóa!","Xóa mã hàng!",MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
            });

            ClearUnit = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                clearUnit();
            });

            valuechangecommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

                var a = BomTHList2.Where(x => x.MaTp.Contains(ThMaTp) && x.TenBX.Contains(ThDisplayName1) && x.SoHoa.Contains(ThSoHoa) && x.TenLK.Contains(ThDisplayName2) && x.ChatLieu.Contains(ThChatLieu) && x.QuyCach.Contains(ThQuyCach) && x.DonVi.Contains(ThDonVi) && x.PhanLoaiBOM.Contains(ThPhanLoai));

                BomTHList = new ObservableCollection<BOMTongHopModel>(a);
            });

        }

        void loadBomTH ()
        {
            ThMaTp = "";
            ThDisplayName1 = "";
            ThSoHoa = "";
            ThDisplayName2 = "";
            ThChatLieu = "";
            ThQuyCach = "";
            ThDonVi = "";
            ThPhanLoai = "";

            BomTHList = new ObservableCollection<BOMTongHopModel> ();

            var lktp = DataProvider.Ins.DB.BomLkTp;

            lktp.OrderBy(x => x.MaTp);
            int i = 1;            
            foreach (var item in lktp) 
            {
                BOMTongHopModel model = new BOMTongHopModel();

                model.STT = i;

                var bomtp = DataProvider.Ins.DB.BomTp.Where(p => p.MaTp == item.MaTp);
                var bomlk = DataProvider.Ins.DB.BomLk.Where(p => p.SoHoa == item.SoHoa);
                var bomnl = DataProvider.Ins.DB.BomNl.Where(p => p.MaMuaHang == item.MaMuaHang);

                model.MaTp = item.MaTp;
                model.TenBX =bomtp.First().DisplayName;
                model.SoHoa = item.SoHoa;
                model.TenLK = bomlk.First().DisplayName;
                model.DonVi = bomnl.First().IdU;
                model.ChatLieu = bomnl.First().ChatLieu;
                model.QuyCach = bomnl.First().QuyCach;
                model.HeSo = (int)item.HeSo;
                model.PhanLoaiBOM = bomnl.First().PhanLoaiBom;

                BomTHList.Add(model);
                i++;
            }
            
            BomTHList2 = BomTHList;
        }

        void loadBomlk()
        {
            BomLKList = new ObservableCollection<BomLinhKienModel>();
            cbSoHoa = new ObservableCollection<BomLk>(DataProvider.Ins.DB.BomLk);
            cbUnit = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);

            var lk = DataProvider.Ins.DB.BomLk;

            int i = 1;
            foreach (var item in lk)
            {
                BomLinhKienModel lkmd = new BomLinhKienModel();

                lkmd.STT = i;

                lkmd.SoHoa = item.SoHoa;
                lkmd.TenLK = item.DisplayName;
                lkmd.DonVi = item.IdU;
                lkmd.QuyCach = item.QuyCach;
                lkmd.DapKhuon = item.DapKhuon;
                lkmd.EpNhua = item.EpNhua;
                lkmd.Han = item.Han;
                lkmd.Son = item.Son;
                lkmd.LapRap = item.LapRap;

                BomLKList.Add(lkmd);
                i++;
            }
        }

        void loadBomNL()
        {
            BomNLList = new ObservableCollection<BomNguyenLieuModel>();
            cbMaMuaHang = new ObservableCollection<BomNl>(DataProvider.Ins.DB.BomNl);
            cbUnit = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);

            var nl = DataProvider.Ins.DB.BomNl;

            int i = 1;
            foreach (var item in nl)
            {
                BomNguyenLieuModel nlmd = new BomNguyenLieuModel();

                nlmd.STT = i;

                nlmd.MaMuaHang = item.MaMuaHang;
                nlmd.TenNL = item.DisplayName;
                nlmd.DonVi = item.IdU;
                nlmd.ChatLieu = item.ChatLieu;
                nlmd.QuyCach = item.QuyCach;
                nlmd.PhanLoaiBOM = item.PhanLoaiBom;
                nlmd.DapKhuon = item.DapKhuon;
                nlmd.EpNhua = item.EpNhua;
                nlmd.Han = item.Han;
                nlmd.Son = item.Son;
                nlmd.LapRap = item.LapRap;

                BomNLList.Add(nlmd);
                i++;
            }
        }

        void loadBomTP()
        {
            BomTPList = new ObservableCollection<BomThanhPhamModel>();
            cbMatp = new ObservableCollection<BomTp>(DataProvider.Ins.DB.BomTp);
            cbUnit = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);

            var tp = DataProvider.Ins.DB.BomTp;

            int i = 1;
            foreach (var item in tp)
            {
                BomThanhPhamModel tpmd = new BomThanhPhamModel();

                tpmd.STT = i;

                tpmd.MaTp = item.MaTp;
                tpmd.TenBX = item.DisplayName;
                tpmd.DonVi = item.IdU;
                

                BomTPList.Add(tpmd);
                i++;
            }
        }

        void loadBomLkTp()
        {
            BomLKTPList = new ObservableCollection<BomLkTp>(DataProvider.Ins.DB.BomLkTp);
            cbMatp = new ObservableCollection<BomTp>(DataProvider.Ins.DB.BomTp);
            cbSoHoa = new ObservableCollection<BomLk>(DataProvider.Ins.DB.BomLk);
            cbMaMuaHang = new ObservableCollection<BomNl>(DataProvider.Ins.DB.BomNl);
        }

        void LoadUnit()
        {
            UnitList = new ObservableCollection<UnitModel>();
            cbUnit = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);

            var Un = DataProvider.Ins.DB.Unit;

            int i = 1;
            foreach (var item in Un)
            {
                UnitModel unmd = new UnitModel();

                unmd.STT = i;

                unmd.IdU = item.IdU;
                unmd.DisplayName = item.DisplayName;


                UnitList.Add(unmd);
                i++;
            }
        }

        void clearbomlktp()
        {
            lktpSTT = null;
            lktpMaTp = null;
            lktpSoHoa = null;
            lktpMaMuaHang = null;
            lktpHeSo = null;
        }
        
        void clearbomlk()
        {
            lkSTT = null;
            lkSoHoa = null;
            lkDisplayName = null;
            lkQuyCach = null;
            lkDonVi = null;
        }

        void clearbomnl()
        {
            nlSTT = null;
            nlMaMuaHang = null;
            nlDisplayName = null;
            nlDonVi = null;
            nlChatLieu = null;
            nlQuyCach = null;
            nlPhanLoai = null;
        }

        void clearbomtp()
        {
            tpSTT = null;
            tpMaTp = null;
            tpDisplayName = null;
            tpDonVi = null;
        }

        void clearUnit()
        {
            UnitTT = null;
            UnitId = null;
            UnitDisplayName = null;
        }
    }
}
