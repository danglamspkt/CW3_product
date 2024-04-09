using Cw3_Product.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cw3_Product.ViewModel
{
    public class KhoOutputViewModel :BaseViewModel
    {
        //-------------------------Khai báo list hiển thị Đơn hàng thành phẩm--------------------------------------------------
        private ObservableCollection<DonHangTp> _SoLoList;
        public ObservableCollection<DonHangTp> SoLoList { get => _SoLoList; set { _SoLoList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị BOM TP--------------------------------------------------
        private ObservableCollection<BomTp> _MaTpList;
        public ObservableCollection<BomTp> MaTpList { get => _MaTpList; set { _MaTpList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Đơn vị--------------------------------------------------
        private ObservableCollection<Unit> _donvilist;
        public ObservableCollection<Unit> donvilist { get => _donvilist; set { _donvilist = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Kho output thành phẩm--------------------------------------------------
        private ObservableCollection<XuatTp> _KhoOutputTpList;
        public ObservableCollection<XuatTp> KhoOutputTpList { get => _KhoOutputTpList; set { _KhoOutputTpList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo biến Kho output thành phẩm--------------------------------------------------
        private int? _KhoOutputTpId;
        public int? KhoOutputTpId { get => _KhoOutputTpId; set { _KhoOutputTpId = value; OnPropertyChanged(); } }

        private DateTime? _KhoOutputTpNgay;
        public DateTime? KhoOutputTpNgay { get => _KhoOutputTpNgay; set { _KhoOutputTpNgay = value; OnPropertyChanged(); } }

        private string _KhoOutputTpSoLo;
        public string KhoOutputTpSoLo { get => _KhoOutputTpSoLo; set { _KhoOutputTpSoLo = value; OnPropertyChanged(); } }

        private string _KhoOutputTpMaTp;
        public string KhoOutputTpMaTp { get => _KhoOutputTpMaTp; set { _KhoOutputTpMaTp = value; OnPropertyChanged(); } }

        private int? _KhoOutputTpSoLuong;
        public int? KhoOutputTpSoLuong { get => _KhoOutputTpSoLuong; set { _KhoOutputTpSoLuong = value; OnPropertyChanged(); } }

        private string _KhoOutputTpDonVi;
        public string KhoOutputTpDonVi { get => _KhoOutputTpDonVi; set { _KhoOutputTpDonVi = value; OnPropertyChanged(); } }

        private DateTime? _KhoOutputTpNgayStart;
        public DateTime? KhoOutputTpNgayStart { get => _KhoOutputTpNgayStart; set { _KhoOutputTpNgayStart = value; OnPropertyChanged(); } }

        private DateTime? _KhoOutputTpNgayEnd;
        public DateTime? KhoOutputTpNgayEnd { get => _KhoOutputTpNgayEnd; set { _KhoOutputTpNgayEnd = value; OnPropertyChanged(); } }

        private Model.XuatTp _SelectedItemKhoOutputTp;
        public Model.XuatTp SelectedItemKhoOutputTp
        {
            get => _SelectedItemKhoOutputTp; set
            {
                _SelectedItemKhoOutputTp = value; OnPropertyChanged(); if (_SelectedItemKhoOutputTp != null)
                {
                    KhoOutputTpId = SelectedItemKhoOutputTp.IdOutput;
                    KhoOutputTpNgay = SelectedItemKhoOutputTp.DateXuat;
                    KhoOutputTpSoLo = SelectedItemKhoOutputTp.SoLo;
                    KhoOutputTpMaTp = SelectedItemKhoOutputTp.MaTp;
                    KhoOutputTpSoLuong = SelectedItemKhoOutputTp.SoluongXuat;
                    KhoOutputTpDonVi = SelectedItemKhoOutputTp.IdU;
                }
            }
        }

        //===========================Khai báo command thêm sửa xóa Kho output thành phẩm===========================
        public ICommand filtercommandOuputTp { get; set; }
        public ICommand addcommandOuputTp { get; set; }
        public ICommand editcommandOuputTp { get; set; }
        public ICommand deletecommandOuputTp { get; set; }
        public ICommand ClearOuputTp { get; set; }

        string accname;
        public KhoOutputViewModel() 
        {
            accname = Cw3_Product.Properties.Settings.Default.account;
            if (UserControlKho.OutputKhoTpUC.ContextMenuOpeningEvent != null) loadKhoOutputTp();
            //===========================Command Lắp rap sản xuất===========================
            filtercommandOuputTp = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                loadKhoOutputTp();
            });

            addcommandOuputTp = new RelayCommand<object>((p) =>
            {
                if (KhoOutputTpNgay == null ||  string.IsNullOrEmpty(KhoOutputTpSoLo) || string.IsNullOrEmpty(KhoOutputTpMaTp) || KhoOutputTpSoLuong == null || string.IsNullOrEmpty(KhoOutputTpDonVi))
                    return false;
                return true;
            }, (p) =>
            {
                var themOuputTp = new XuatTp() { DateXuat = KhoOutputTpNgay,  SoLo = KhoOutputTpSoLo, MaTp = KhoOutputTpMaTp, SoluongXuat = KhoOutputTpSoLuong, IdU = KhoOutputTpDonVi,UserName =accname };

                DataProvider.Ins.DB.XuatTp.Add(themOuputTp);
                DataProvider.Ins.DB.SaveChanges();
                loadKhoOutputTp();

            });

            editcommandOuputTp = new RelayCommand<object>((p) =>
            {
                if (KhoOutputTpNgay == null ||  string.IsNullOrEmpty(KhoOutputTpSoLo) || string.IsNullOrEmpty(KhoOutputTpMaTp) || KhoOutputTpSoLuong == null || string.IsNullOrEmpty(KhoOutputTpDonVi))
                    return false;
                var OuputTplist = DataProvider.Ins.DB.XuatTp.Where(x => x.IdOutput == KhoOutputTpId);
                if (OuputTplist == null || OuputTplist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var suaOuputTp = DataProvider.Ins.DB.XuatTp.Where(x => x.IdOutput == KhoOutputTpId).SingleOrDefault();
                suaOuputTp.DateXuat = KhoOutputTpNgay;
                suaOuputTp.SoLo = KhoOutputTpSoLo;
                suaOuputTp.MaTp = KhoOutputTpMaTp;
                suaOuputTp.SoluongXuat = KhoOutputTpSoLuong;
                suaOuputTp.IdU = KhoOutputTpDonVi;
                suaOuputTp.UserName = accname;
                DataProvider.Ins.DB.SaveChanges();
                loadKhoOutputTp();

            });

            deletecommandOuputTp = new RelayCommand<object>((p) =>
            {
                if (KhoOutputTpNgay == null || string.IsNullOrEmpty(KhoOutputTpSoLo) || string.IsNullOrEmpty(KhoOutputTpMaTp) || KhoOutputTpSoLuong == null || string.IsNullOrEmpty(KhoOutputTpDonVi))
                    return false;
                var OuputTplist = DataProvider.Ins.DB.XuatTp.Where(x => x.IdOutput == KhoOutputTpId);
                if (OuputTplist == null || OuputTplist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var OuputTp = DataProvider.Ins.DB.XuatTp.Where(x => x.IdOutput == KhoOutputTpId).SingleOrDefault();
                DataProvider.Ins.DB.XuatTp.Remove(OuputTp);
                DataProvider.Ins.DB.SaveChanges();
                loadKhoOutputTp();
            });

            ClearOuputTp = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                ClearKhoOutputTp();
            });




        }

        void loadKhoOutputTp()
        {
            DateTime? OuputTpStart = KhoOutputTpNgayStart;
            DateTime? OuputTpEnd = KhoOutputTpNgayEnd;
            if (OuputTpStart == null) OuputTpStart = DateTime.MinValue;
            if (OuputTpEnd == null) OuputTpEnd = DateTime.Now;
            KhoOutputTpList = new ObservableCollection<XuatTp>(DataProvider.Ins.DB.XuatTp.Where(x => x.DateXuat >= OuputTpStart && x.DateXuat <= OuputTpEnd));
            SoLoList = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp);
            MaTpList = new ObservableCollection<BomTp>(DataProvider.Ins.DB.BomTp);
            donvilist = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
        }
        void ClearKhoOutputTp()
        {
            KhoOutputTpId = null;
            KhoOutputTpNgay = null;
            KhoOutputTpSoLo = null;
            KhoOutputTpMaTp = null;
            KhoOutputTpSoLuong = null;
            KhoOutputTpDonVi = null;
        }
    }
}
