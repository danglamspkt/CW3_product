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
    public class SoDoKhoLkViewModel : BaseViewModel
    {
        //-------------------------Khai báo list hiển thị sản xuất--------------------------------------------------
        private ObservableCollection<SoDoKhoLkModel> _TonKholist;
        public ObservableCollection<SoDoKhoLkModel> TonKholist { get => _TonKholist; set { _TonKholist = value; OnPropertyChanged(); } }
        //-------------------------Khai báo list hiển thị sản xuất--------------------------------------------------
        private ObservableCollection<SoDoKhoLkModel> _TonKholist2;
        public ObservableCollection<SoDoKhoLkModel> TonKholist2 { get => _TonKholist2; set { _TonKholist2 = value; OnPropertyChanged(); } }

        private string _SoHoa;
        public string SoHoa { get => _SoHoa; set { _SoHoa = value; OnPropertyChanged(); } }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        private string _QuyCach;
        public string QuyCach { get => _QuyCach; set { _QuyCach = value; OnPropertyChanged(); } }

        private string _ViTri;
        public string ViTri { get => _ViTri; set { _ViTri = value; OnPropertyChanged(); } }

        public ICommand updatecommand { get; set; }
        public ICommand valuechangecommand { get; set; }
        public SoDoKhoLkViewModel() 
        {
            
            {
                clear();
                TonKholist = new ObservableCollection<SoDoKhoLkModel>();
                var nhaplieu = DataProvider.Ins.DB.KhoLinhKienInputInfo;
                var xuatlieu = DataProvider.Ins.DB.KhoLinhKienOutputInfo;
                var bomlk = DataProvider.Ins.DB.BomLk;
                int i = 1;
                nhaplieu.OrderBy(x => x.ViTri);
                foreach (var item in nhaplieu)
                {
                    if (xuatlieu.Where(x => x.QRcode == item.QRcode).Count() > 0) continue;
                    
                    SoDoKhoLkModel soDoKhoLkModel = new SoDoKhoLkModel();
                    
                    soDoKhoLkModel.STT = i;
                    soDoKhoLkModel.SoHoa = item.SoHoa;
                    soDoKhoLkModel.DisplayName = bomlk.Where(x => x.SoHoa == item.SoHoa).First().DisplayName;
                    soDoKhoLkModel.QuyCach = bomlk.Where(x => x.SoHoa == item.SoHoa).First().QuyCach;
                    soDoKhoLkModel.ViTri = item.ViTri;
                    soDoKhoLkModel.SoLuong = item.SoLuongNhap;

                    TonKholist.Add(soDoKhoLkModel);
                    i++;
                }
                TonKholist.OrderBy(x => x.ViTri);
                TonKholist2 = TonKholist;                
            }

            updatecommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                clear();
                TonKholist = new ObservableCollection<SoDoKhoLkModel>();
                var nhaplieu = DataProvider.Ins.DB.KhoLinhKienInputInfo;
                var xuatlieu = DataProvider.Ins.DB.KhoLinhKienOutputInfo;
                var bomlk = DataProvider.Ins.DB.BomLk;
                int i = 1;
                nhaplieu.OrderBy(x => x.ViTri);
                foreach (var item in nhaplieu)
                {
                    if (xuatlieu.Where(x => x.QRcode == item.QRcode).Count() > 0) continue;

                    SoDoKhoLkModel soDoKhoLkModel = new SoDoKhoLkModel();

                    soDoKhoLkModel.STT = i;
                    soDoKhoLkModel.SoHoa = item.SoHoa;
                    soDoKhoLkModel.DisplayName = bomlk.Where(x => x.SoHoa == item.SoHoa).First().DisplayName;
                    soDoKhoLkModel.QuyCach = bomlk.Where(x => x.SoHoa == item.SoHoa).First().QuyCach;
                    soDoKhoLkModel.ViTri = item.ViTri;
                    soDoKhoLkModel.SoLuong = item.SoLuongNhap;

                    TonKholist.Add(soDoKhoLkModel);
                    i++;
                }
                TonKholist.OrderBy(x => x.ViTri);
                TonKholist2 = TonKholist;
            });
            valuechangecommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                
                var a = TonKholist2.Where(x => x.SoHoa.Contains(SoHoa) && x.DisplayName.Contains(DisplayName) && x.QuyCach.Contains(QuyCach) && x.ViTri.Contains(ViTri));

                TonKholist = new ObservableCollection<SoDoKhoLkModel>(a);
            });
        }
        void clear()
        {
            SoHoa = "";
            DisplayName = "";
            QuyCach = "";
            ViTri = "";
        }
    }
}
