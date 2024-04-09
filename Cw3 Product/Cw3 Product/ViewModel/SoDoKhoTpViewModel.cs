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
    public class SoDoKhoTpViewModel : BaseViewModel
    {
        //-------------------------Khai báo list hiển thị sản xuất--------------------------------------------------
        private ObservableCollection<SoDoKhoTpModel> _TonKholist;
        public ObservableCollection<SoDoKhoTpModel> TonKholist { get => _TonKholist; set { _TonKholist = value; OnPropertyChanged(); } }
        //-------------------------Khai báo list hiển thị sản xuất--------------------------------------------------
        private ObservableCollection<SoDoKhoTpModel> _TonKholist2;
        public ObservableCollection<SoDoKhoTpModel> TonKholist2 { get => _TonKholist2; set { _TonKholist2 = value; OnPropertyChanged(); } }

        private string _SoLo1;
        public string SoLo1 { get => _SoLo1; set { _SoLo1 = value; OnPropertyChanged(); } }

        private string _MaTp1;
        public string MaTp1 { get => _MaTp1; set { _MaTp1 = value; OnPropertyChanged(); } }

        private string _DisplayName1;
        public string DisplayName1 { get => _DisplayName1; set { _DisplayName1 = value; OnPropertyChanged(); } }

        private string _SoLo2;
        public string SoLo2 { get => _SoLo2; set { _SoLo2 = value; OnPropertyChanged(); } }

        private string _MaTp2;
        public string MaTp2 { get => _MaTp2; set { _MaTp2 = value; OnPropertyChanged(); } }

        private string _DisplayName2;
        public string DisplayName2 { get => _DisplayName2; set { _DisplayName2 = value; OnPropertyChanged(); } }

        private string _ViTri;
        public string ViTri { get => _ViTri; set { _ViTri = value; OnPropertyChanged(); } }

        public ICommand updatecommand { get; set; }
        public ICommand valuechangecommand { get; set; }
        public SoDoKhoTpViewModel() 
        {
            {
                clear();
                TonKholist = new ObservableCollection<SoDoKhoTpModel>();
                var nhaplieu = DataProvider.Ins.DB.KhoThanhPhamInputInfo;
                var xuatlieu = DataProvider.Ins.DB.KhoThanhPhamOutputInfo;
                var bomtp = DataProvider.Ins.DB.BomTp;
                nhaplieu.OrderBy(x => x.ViTri);
                int i = 1;
                foreach (var item in nhaplieu)
                {
                    if (xuatlieu.Where(x => x.QRcode == item.QRcode).Count() > 0) continue;
                    SoDoKhoTpModel model = new SoDoKhoTpModel();

                    model.STT = i;
                    model.SoLo1 = item.SoLo1;
                    model.MaTp1 = item.MaTp1;
                    model.DisplayName1 = bomtp.Where(x => x.MaTp == item.MaTp1).First().DisplayName;
                    model.SoLuong1 = item.SoLuongNhap1;
                    if (string.IsNullOrEmpty(item.SoLo2))
                    {
                        model.SoLo2 = "";
                        model.MaTp2 = "";
                        model.DisplayName2 = "";
                        model.SoLuong2 = 0;
                    }
                    else
                    {
                        model.SoLo2 = item.SoLo2;
                        model.MaTp2 = item.MaTp2;
                        model.DisplayName2 = bomtp.Where(x => x.MaTp == item.MaTp2).First().DisplayName;
                        model.SoLuong2 = item.SoLuongNhap2;
                    }
                    model.ViTri = item.ViTri;                    

                    TonKholist.Add(model);
                    i++;
                }
                TonKholist2 = TonKholist;
            }

            updatecommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                clear();
                TonKholist = new ObservableCollection<SoDoKhoTpModel>();
                var nhaplieu = DataProvider.Ins.DB.KhoThanhPhamInputInfo;
                var xuatlieu = DataProvider.Ins.DB.KhoThanhPhamOutputInfo;
                var bomtp = DataProvider.Ins.DB.BomTp;
                nhaplieu.OrderBy(x => x.ViTri);
                int i = 1;
                foreach (var item in nhaplieu)
                {
                    if (xuatlieu.Where(x => x.QRcode == item.QRcode).Count() > 0) continue;
                    SoDoKhoTpModel model = new SoDoKhoTpModel();

                    model.STT = i;
                    model.SoLo1 = item.SoLo1;
                    model.MaTp1 = item.MaTp1;
                    model.DisplayName1 = bomtp.Where(x => x.MaTp == item.MaTp1).First().DisplayName;
                    model.SoLuong1 = item.SoLuongNhap1;
                    if (string.IsNullOrEmpty(item.SoLo2))
                    {
                        model.SoLo2 = "";
                        model.MaTp2 = "";
                        model.DisplayName2 = "";
                        model.SoLuong2 = 0;
                    }
                    else
                    {
                        model.SoLo2 = item.SoLo2;
                        model.MaTp2 = item.MaTp2;
                        model.DisplayName2 = bomtp.Where(x => x.MaTp == item.MaTp2).First().DisplayName;
                        model.SoLuong2 = item.SoLuongNhap2;
                    }                    
                    model.ViTri = item.ViTri;
                    
                    

                    TonKholist.Add(model);
                    i++;
                }
                TonKholist2 = TonKholist;
            });
            valuechangecommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

                var a = TonKholist2.Where(x => (x.SoLo1.Contains(SoLo1) || x.SoLo2.Contains(SoLo1)) && (x.MaTp1.Contains(MaTp1) || x.MaTp2.Contains(MaTp1)) && (x.DisplayName1.Contains(DisplayName1) || x.DisplayName2.Contains(DisplayName1)) && x.ViTri.Contains(ViTri));

                TonKholist = new ObservableCollection<SoDoKhoTpModel>(a);

            });
        }

        void clear()
        {
            SoLo1 = "";
            MaTp1 = "";
            DisplayName1 = "";
            SoLo2 = "";
            MaTp2 = "";
            DisplayName2 = "";
            ViTri = "";
        }
    }
}
