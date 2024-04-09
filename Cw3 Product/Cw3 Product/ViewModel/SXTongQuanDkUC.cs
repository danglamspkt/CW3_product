using Cw3_Product.Model;
using Cw3_Product.UserControlKho;
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
    public class SXTongQuanDkUC : BaseViewModel
    {
        //-------------------------Khai báo list hiển thị Số lô--------------------------------------------------
        private ObservableCollection<DonHangTp> _Sololist;
        public ObservableCollection<DonHangTp> Sololist { get => _Sololist; set { _Sololist = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị sản xuất--------------------------------------------------
        private ObservableCollection<SXTongQuanDkSXModel> _SanXuatList;
        public ObservableCollection<SXTongQuanDkSXModel> SanXuatList { get => _SanXuatList; set { _SanXuatList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị nguyên liệu--------------------------------------------------
        private ObservableCollection<SXTongQuanDKNlModel> _NguyenLieuList;
        public ObservableCollection<SXTongQuanDKNlModel> NguyenLieuList { get => _NguyenLieuList; set { _NguyenLieuList = value; OnPropertyChanged(); } }

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

        public SXTongQuanDkUC() 
        {
            Sololist = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp.Where(x => x.TinhTrang == "Sản xuất"));

            solochanged = new RelayCommand<ComboBox>((p) => { return true; }, (p) =>
            {
                string text = ((DonHangTp)p.SelectedItem).SoLo;
                string textmatp = DataProvider.Ins.DB.DonHangTp.Where(x => x.SoLo == text).First().MaTp;

                SanXuatList = new ObservableCollection<SXTongQuanDkSXModel>();
                NguyenLieuList = new ObservableCollection<SXTongQuanDKNlModel>();

                var mahanglist = DataProvider.Ins.DB.BomLkTp.Where(x => x.MaTp == textmatp && x.DapKhuon == true);
                var phatlieulist = DataProvider.Ins.DB.DKNguyenLieu.Where(x => x.SoLo == text);
                var phatlieulklist = DataProvider.Ins.DB.DKNguyenLieuLK.Where(x => x.SoLo == text);
                var sxlist = DataProvider.Ins.DB.DKSanXuat.Where(x => x.SoLo == text);

                
                int i = 0;
                foreach (var item in mahanglist)
                {
                    SXTongQuanDKNlModel sXTongQuanDKNlModel = new SXTongQuanDKNlModel();
                    SXTongQuanDkSXModel sXTongQuanDkSXModel = new SXTongQuanDkSXModel();
                    var bomlk = DataProvider.Ins.DB.BomLk.Where(x => x.SoHoa == item.SoHoa).First();
                    var bomnl = DataProvider.Ins.DB.BomNl.Where(x => x.MaMuaHang == item.MaMuaHang).First();
                    var bomtp = mahanglist.Where(x => x.SoHoa == item.SoHoa).First();
                    var donhang = Sololist.Where(x => x.SoLo == text).First();

                    var tongphatnl = phatlieulist.Where(x => x.MaMuaHang == item.MaMuaHang);
                    var tongphatlk = phatlieulklist.Where(x => x.SoHoa == item.SoHoa).Sum(y => y.SoLuong);
                    var hesotong = mahanglist.Where(x => x.MaMuaHang == item.MaMuaHang).Sum(y => y.HeSo);

                    var tongsx = sxlist.Where(x => x.SoHoa == item.SoHoa).Sum(y => y.SoLuong);
                    if (tongsx == null) tongsx = 0;

                    sXTongQuanDKNlModel.STT = i + 1;
                    sXTongQuanDKNlModel.SoHoa = item.SoHoa;
                    sXTongQuanDKNlModel.DisplayName = bomlk.DisplayName;
                    sXTongQuanDKNlModel.ChatLieu = bomnl.ChatLieu;
                    sXTongQuanDKNlModel.QuyCach = bomlk.QuyCach;
                    sXTongQuanDKNlModel.HeSo = bomtp.HeSo;
                    sXTongQuanDKNlModel.SoLuongCan = donhang.SoLuong * sXTongQuanDKNlModel.HeSo;
                    sXTongQuanDKNlModel.NguyenLieu = tongphatnl.Sum(x => x.SoLuong) * hesotong / item.HeSo + tongphatlk;
                    if( sXTongQuanDKNlModel.NguyenLieu == null ) sXTongQuanDKNlModel.NguyenLieu= 0;
                    sXTongQuanDKNlModel.ConLai = sXTongQuanDKNlModel.SoLuongCan - sXTongQuanDKNlModel.NguyenLieu;
                    NguyenLieuList.Add(sXTongQuanDKNlModel);

                    sXTongQuanDkSXModel.STT = i + 1;
                    sXTongQuanDkSXModel.SoHoa = item.SoHoa;
                    sXTongQuanDkSXModel.DisplayName = bomlk.DisplayName;
                    sXTongQuanDkSXModel.ChatLieu = bomnl.ChatLieu;
                    sXTongQuanDkSXModel.QuyCach = bomlk.QuyCach;
                    sXTongQuanDkSXModel.HeSo = bomtp.HeSo;
                    sXTongQuanDkSXModel.SoLuongCan = donhang.SoLuong * sXTongQuanDkSXModel.HeSo;
                    sXTongQuanDkSXModel.NguyenLieu = sXTongQuanDKNlModel.NguyenLieu;
                    sXTongQuanDkSXModel.SoLuongLam = tongsx;
                    sXTongQuanDkSXModel.LamThem = sXTongQuanDkSXModel.SoLuongCan - sXTongQuanDkSXModel.SoLuongLam;
                    SanXuatList.Add(sXTongQuanDkSXModel);
                    i++;
                }

            });
        }
    }
}
