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
    public class SXTongQuanEnViewModel : BaseViewModel
    {
        //-------------------------Khai báo list hiển thị sản xuất--------------------------------------------------
        private ObservableCollection<SXTongQuanEnSXModel> _SanXuatList;
        public ObservableCollection<SXTongQuanEnSXModel> SanXuatList { get => _SanXuatList; set { _SanXuatList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị nguyên liệu--------------------------------------------------
        private ObservableCollection<SXTongQuanEnNLModel> _NguyenLieuList;
        public ObservableCollection<SXTongQuanEnNLModel> NguyenLieuList { get => _NguyenLieuList; set { _NguyenLieuList = value; OnPropertyChanged(); } }

        public ICommand updatecommand { get; set; }

        public SXTongQuanEnViewModel() 
        {
            {
                SanXuatList = new ObservableCollection<SXTongQuanEnSXModel>();
                NguyenLieuList = new ObservableCollection<SXTongQuanEnNLModel>();

                var phatlieulist = DataProvider.Ins.DB.EPNguyenLieu;
                var sxlist = DataProvider.Ins.DB.KhoLinhKienInputInfo;
                var phatbx = DataProvider.Ins.DB.KhoLinhKienOutputInfo;

                var mahanglist = DataProvider.Ins.DB.BomLk.Where(x => x.EpNhua == true);


                int i = 0;
                foreach (var item in mahanglist)
                {
                    var tonglam = sxlist.Where(x => x.SoHoa == item.SoHoa).Sum(y => y.SoLuongNhap);
                    var phattam = phatbx.Where(x => x.SoHoa == item.SoHoa);
                    int? tongphat = 0;
                    if (phattam.Count() > 0) tongphat = phattam.Sum(y => y.SoLuongNhap);

                    SXTongQuanEnSXModel sXTongQuanEnSXModel = new SXTongQuanEnSXModel();
                    sXTongQuanEnSXModel.STT = i + 1;
                    sXTongQuanEnSXModel.SoHoa = item.SoHoa;
                    sXTongQuanEnSXModel.DisplayName = item.DisplayName;
                    sXTongQuanEnSXModel.QuyCach = item.QuyCach;
                    sXTongQuanEnSXModel.TonKho = tonglam - tongphat;
                    sXTongQuanEnSXModel.IdU = item.IdU;
                    SanXuatList.Add(sXTongQuanEnSXModel);
                    i++;
                }

                var malieulist = DataProvider.Ins.DB.BomNl.Where(x => x.EpNhua == true);

                int j = 0;
                foreach (var item in malieulist)
                {
                    var tongphatlieu = phatlieulist.Where(x => x.MaMuaHang == item.MaMuaHang).Sum(y => y.SoLuong);
                    SXTongQuanEnNLModel sXTongQuanEnNLModel = new SXTongQuanEnNLModel();

                    sXTongQuanEnNLModel.STT = j + 1;
                    sXTongQuanEnNLModel.MaMuaHang = item.MaMuaHang;
                    sXTongQuanEnNLModel.DisplayName = item.DisplayName;
                    sXTongQuanEnNLModel.ChatLieu = item.ChatLieu;
                    sXTongQuanEnNLModel.QuyCach = item.QuyCach;
                    sXTongQuanEnNLModel.NguyenLieuTon = tongphatlieu;
                    sXTongQuanEnNLModel.IdU = item.IdU;
                    NguyenLieuList.Add(sXTongQuanEnNLModel);
                    j++;
                }
            }

            updatecommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SanXuatList = new ObservableCollection<SXTongQuanEnSXModel>();
                NguyenLieuList = new ObservableCollection<SXTongQuanEnNLModel>();

                var phatlieulist = DataProvider.Ins.DB.EPNguyenLieu;
                var sxlist = DataProvider.Ins.DB.KhoLinhKienInputInfo;
                var phatbx = DataProvider.Ins.DB.KhoLinhKienOutputInfo;

                var mahanglist = DataProvider.Ins.DB.BomLk.Where(x => x.EpNhua == true);
                
                
                int i = 0;
                foreach (var item in mahanglist)
                {
                    var tonglam = sxlist.Where(x => x.SoHoa == item.SoHoa).Sum(y => y.SoLuongNhap);
                    var phattam = phatbx.Where(x => x.SoHoa == item.SoHoa);
                    int? tongphat = 0;
                    if (phattam.Count() > 0) tongphat = phattam.Sum(y => y.SoLuongNhap);

                    SXTongQuanEnSXModel sXTongQuanEnSXModel = new SXTongQuanEnSXModel();
                    sXTongQuanEnSXModel.STT = i + 1;
                    sXTongQuanEnSXModel.SoHoa = item.SoHoa;
                    sXTongQuanEnSXModel.DisplayName = item.DisplayName;
                    sXTongQuanEnSXModel.QuyCach = item.QuyCach;
                    sXTongQuanEnSXModel.TonKho = tonglam - tongphat;
                    sXTongQuanEnSXModel.IdU = item.IdU;
                    SanXuatList.Add(sXTongQuanEnSXModel);
                    i++;
                }

                var malieulist = DataProvider.Ins.DB.BomNl.Where(x => x.EpNhua == true);
                
                int j = 0;
                foreach (var item in malieulist)
                {
                    var tongphatlieu = phatlieulist.Where(x => x.MaMuaHang == item.MaMuaHang).Sum(y => y.SoLuong);
                    SXTongQuanEnNLModel sXTongQuanEnNLModel = new SXTongQuanEnNLModel();

                    sXTongQuanEnNLModel.STT = j + 1;
                    sXTongQuanEnNLModel.MaMuaHang = item.MaMuaHang;
                    sXTongQuanEnNLModel.DisplayName = item.DisplayName;
                    sXTongQuanEnNLModel.ChatLieu = item.ChatLieu;
                    sXTongQuanEnNLModel.QuyCach = item.QuyCach;
                    sXTongQuanEnNLModel.NguyenLieuTon = tongphatlieu;
                    sXTongQuanEnNLModel.IdU = item.IdU;
                    NguyenLieuList.Add(sXTongQuanEnNLModel);
                    j++;
                }
            });
                
        }
    }
}
