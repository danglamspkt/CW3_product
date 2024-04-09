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
    public class SoDoKhoNlViewModel : BaseViewModel
    {
        //-------------------------Khai báo list hiển thị sản xuất--------------------------------------------------
        private ObservableCollection<SoDokhoNlModel> _TonKholist;
        public ObservableCollection<SoDokhoNlModel> TonKholist { get => _TonKholist; set { _TonKholist = value; OnPropertyChanged(); } }
        //-------------------------Khai báo list hiển thị sản xuất--------------------------------------------------
        private ObservableCollection<SoDokhoNlModel> _TonKholist2;
        public ObservableCollection<SoDokhoNlModel> TonKholist2 { get => _TonKholist2; set { _TonKholist2 = value; OnPropertyChanged(); } }

        private string _MaMuaHang;
        public string MaMuaHang { get => _MaMuaHang; set { _MaMuaHang = value; OnPropertyChanged(); } }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        private string _ChatLieu;
        public string ChatLieu { get => _ChatLieu; set { _ChatLieu = value; OnPropertyChanged(); } }

        private string _QuyCach;
        public string QuyCach { get => _QuyCach; set { _QuyCach = value; OnPropertyChanged(); } }

        private string _ViTri;
        public string ViTri { get => _ViTri; set { _ViTri = value; OnPropertyChanged(); } }

        public ICommand updatecommand { get; set; }
        public ICommand valuechangecommand { get; set; }
        public SoDoKhoNlViewModel() 
        {
            {
                clear();
                TonKholist = new ObservableCollection<SoDokhoNlModel>();
                var nhaplieu = DataProvider.Ins.DB.KhoNguyenLieuInputInfo;
                var xuatlieu = DataProvider.Ins.DB.KhoNguyenLieuOutputInfo;
                var bomnl = DataProvider.Ins.DB.BomNl;
                nhaplieu.OrderBy(x => x.ViTri);
                int i = 1;
                foreach (var item in nhaplieu)
                {
                    if (xuatlieu.Where(x => x.QRcode == item.QRcode).Count() > 0) continue;
                    SoDokhoNlModel model = new SoDokhoNlModel();

                    model.STT = i;
                    model.MaMuaHang = item.MaMuaHang;
                    model.DisplayName = bomnl.Where(x => x.MaMuaHang == item.MaMuaHang).First().DisplayName;
                    model.ChatLieu = bomnl.Where(x => x.MaMuaHang == item.MaMuaHang).First().ChatLieu;
                    model.QuyCach = bomnl.Where(x => x.MaMuaHang == item.MaMuaHang).First().QuyCach;
                    model.ViTri = item.ViTri;
                    model.SoLuong = item.SoLuongNhap;

                    TonKholist.Add(model);
                    i++;
                }
                TonKholist2 = TonKholist;
            }

            updatecommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                clear();
                TonKholist = new ObservableCollection<SoDokhoNlModel>();
                var nhaplieu = DataProvider.Ins.DB.KhoNguyenLieuInputInfo;
                var xuatlieu = DataProvider.Ins.DB.KhoNguyenLieuOutputInfo;
                var bomnl = DataProvider.Ins.DB.BomNl;
                nhaplieu.OrderBy(x => x.ViTri);
                int i = 1;
                foreach (var item in nhaplieu)
                {
                    if (xuatlieu.Where(x => x.QRcode == item.QRcode).Count() > 0) continue;
                    SoDokhoNlModel model = new SoDokhoNlModel();

                    model.STT = i;
                    model.MaMuaHang = item.MaMuaHang;
                    model.DisplayName = bomnl.Where(x => x.MaMuaHang == item.MaMuaHang).First().DisplayName;
                    model.ChatLieu = bomnl.Where(x => x.MaMuaHang == item.MaMuaHang).First().ChatLieu;
                    model.QuyCach = bomnl.Where(x => x.MaMuaHang == item.MaMuaHang).First().QuyCach;
                    model.ViTri = item.ViTri;
                    model.SoLuong = item.SoLuongNhap;

                    TonKholist.Add(model);
                    i++;
                }
                TonKholist2 = TonKholist;
            });
            valuechangecommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                
                var a = TonKholist2.Where(x => x.MaMuaHang.Contains(MaMuaHang) && x.DisplayName.Contains(DisplayName) && x.ChatLieu.Contains(ChatLieu) && x.QuyCach.Contains(QuyCach) && x.ViTri.Contains(ViTri));

                TonKholist = new ObservableCollection<SoDokhoNlModel>(a);

            });
        }

        void clear()
        {
            MaMuaHang = "";
            DisplayName = "";
            ChatLieu = "";
            QuyCach = "";
            ViTri = "";
        }
    }
}
