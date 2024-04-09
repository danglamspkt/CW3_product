using Cw3_Product.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cw3_Product.ViewModel
{
    public class SXTongQuanLrViewModel : BaseViewModel
    {
        //-------------------------Khai báo list hiển thị Số lô--------------------------------------------------
        private ObservableCollection<DonHangTp> _Sololist;
        public ObservableCollection<DonHangTp> Sololist { get => _Sololist; set { _Sololist = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị sản xuất--------------------------------------------------
        private ObservableCollection<SXTongQuanLrSXModel> _SanXuatList;
        public ObservableCollection<SXTongQuanLrSXModel> SanXuatList { get => _SanXuatList; set { _SanXuatList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị nguyên liệu--------------------------------------------------
        private ObservableCollection<SXTongQuanLrNLModel> _NguyenLieuList;
        public ObservableCollection<SXTongQuanLrNLModel> NguyenLieuList { get => _NguyenLieuList; set { _NguyenLieuList = value; OnPropertyChanged(); } }

        private string _SoLo;
        public string SoLo { get => _SoLo; set { _SoLo = value; OnPropertyChanged(); } }

        private string _MaTp;
        public string MaTp { get => _MaTp; set { _MaTp = value; OnPropertyChanged(); } }

        private Model.DonHangTp _SelectedItem;
        public Model.DonHangTp SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged(); if (_SelectedItem != null)
                {
                    MaTp = SelectedItem.MaTp;
                }
            }
        }
        public ICommand solochanged { get; set; }
        public ICommand updatecommand { get; set; }

        public SXTongQuanLrViewModel()
        {
            

            solochanged = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                string text = ((DonHangTp)p.SelectedItem).SoLo;
                string textmatp = DataProvider.Ins.DB.DonHangTp.Where(x => x.SoLo == text).First().MaTp;

                NguyenLieuList = new ObservableCollection<SXTongQuanLrNLModel>();

                var mahanglist = DataProvider.Ins.DB.BomLkTp.Where(x => x.MaTp == textmatp && x.LapRap == true);
                var phatlieulist = DataProvider.Ins.DB.LrNguyenLieu.Where(x => x.SoLo == text);
                var phatlieulklist = DataProvider.Ins.DB.LrNguyenLieuLk.Where(x => x.SoLo == text);
                var sxlist = DataProvider.Ins.DB.LrSanXuat.Where(x => x.SoLo == text);

                int i = 0;
                foreach (var item in mahanglist)
                {
                    SXTongQuanLrNLModel sXTongQuanLrNLModel = new SXTongQuanLrNLModel();
                    var bomlk = DataProvider.Ins.DB.BomLk.Where(x => x.SoHoa == item.SoHoa).First();
                    var bomtp = mahanglist.Where(x => x.SoHoa == item.SoHoa).First();
                    var donhang = Sololist.Where(x => x.SoLo == text).First();

                    var tongphatnl = phatlieulist.Where(x => x.MaMuaHang == item.MaMuaHang);
                    var tongphatlk = phatlieulklist.Where(x => x.SoHoa == item.SoHoa).Sum(y => y.SoLuong);
                    var hesotong = mahanglist.Where(x => x.MaMuaHang == item.MaMuaHang).Sum(y => y.HeSo);

                    sXTongQuanLrNLModel.STT = i + 1;
                    sXTongQuanLrNLModel.SoHoa = item.SoHoa;
                    sXTongQuanLrNLModel.DisplayName = bomlk.DisplayName;
                    sXTongQuanLrNLModel.IdU = bomlk.IdU;
                    sXTongQuanLrNLModel.HeSo = bomtp.HeSo;
                    sXTongQuanLrNLModel.SoLuongCan = donhang.SoLuong * sXTongQuanLrNLModel.HeSo;
                    sXTongQuanLrNLModel.SoLuongLanh = tongphatnl.Sum(x => x.SoLuong) * hesotong / item.HeSo + tongphatlk;
                    if (sXTongQuanLrNLModel.SoLuongLanh == null) sXTongQuanLrNLModel.SoLuongLanh = 0;
                    sXTongQuanLrNLModel.LanhThem = sXTongQuanLrNLModel.SoLuongCan - sXTongQuanLrNLModel.SoLuongLanh;
                    NguyenLieuList.Add(sXTongQuanLrNLModel);
                    i++;
                }
            });

            updatecommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Sololist = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp.Where(x => x.TinhTrang == "Sản xuất"));
                SanXuatList = new ObservableCollection<SXTongQuanLrSXModel>();

                var sxlist = DataProvider.Ins.DB.LrSanXuat;

                int i = 0;
                foreach (var item in Sololist)
                {
                    var bomtp = DataProvider.Ins.DB.BomTp.Where(x => x.MaTp == item.MaTp).First();

                    var tonglam = sxlist.Where(x => x.SoLo == item.SoLo).Sum(y => y.SoLuong);
                    if (tonglam == null) tonglam = 0;

                    SXTongQuanLrSXModel sXTongQuanLrSXModel = new SXTongQuanLrSXModel();

                    sXTongQuanLrSXModel.STT = i + 1;
                    sXTongQuanLrSXModel.SoLo = item.SoLo;
                    sXTongQuanLrSXModel.MaTp = item.MaTp;
                    sXTongQuanLrSXModel.DisplayName = bomtp.DisplayName;
                    sXTongQuanLrSXModel.IdU = item.IdU;
                    sXTongQuanLrSXModel.SoLuongCan = item.SoLuong;
                    sXTongQuanLrSXModel.SoLuongLam = tonglam;
                    sXTongQuanLrSXModel.LamThem = sXTongQuanLrSXModel.SoLuongCan - sXTongQuanLrSXModel.SoLuongLam;
                    SanXuatList.Add(sXTongQuanLrSXModel);
                    i++;
                }                
            });

            {
                Sololist = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp.Where(x => x.TinhTrang == "Sản xuất"));
                SanXuatList = new ObservableCollection<SXTongQuanLrSXModel>();

                var sxlist = DataProvider.Ins.DB.LrSanXuat;

                int i = 0;
                foreach (var item in Sololist)
                {
                    var bomtp = DataProvider.Ins.DB.BomTp.Where(x => x.MaTp == item.MaTp).First();

                    var tonglam = sxlist.Where(x => x.SoLo == item.SoLo).Sum(y => y.SoLuong);
                    if (tonglam == null) tonglam = 0;

                    SXTongQuanLrSXModel sXTongQuanLrSXModel = new SXTongQuanLrSXModel();

                    sXTongQuanLrSXModel.STT = i + 1;
                    sXTongQuanLrSXModel.SoLo = item.SoLo;
                    sXTongQuanLrSXModel.MaTp = item.MaTp;
                    sXTongQuanLrSXModel.DisplayName = bomtp.DisplayName;
                    sXTongQuanLrSXModel.IdU = item.IdU;
                    sXTongQuanLrSXModel.SoLuongCan = item.SoLuong;
                    sXTongQuanLrSXModel.SoLuongLam = tonglam;
                    sXTongQuanLrSXModel.LamThem = sXTongQuanLrSXModel.SoLuongCan - sXTongQuanLrSXModel.SoLuongLam;
                    SanXuatList.Add(sXTongQuanLrSXModel);
                    i++;
                }
            }

        }
    }
}
