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
    public class BOMLinhKienViewModel : BaseViewModel
    {
        private ObservableCollection<BOMHaoHutLinhKienModel> _SanLuongList;
        public ObservableCollection<BOMHaoHutLinhKienModel> SanLuongList { get => _SanLuongList; set { _SanLuongList = value; OnPropertyChanged(); } }

        private ObservableCollection<DonHangTp> _sololist;
        public ObservableCollection<DonHangTp> sololist { get => _sololist; set { _sololist = value; OnPropertyChanged(); } }

        public ICommand viewdata { get; set; }

        private bool _flag;
        public bool flag { get => _flag; set { _flag = value; OnPropertyChanged(); } }

        private string _solo;
        public string solo { get => _solo; set { _solo = value; OnPropertyChanged(); } }

        private string _Matp;
        public string Matp { get => _Matp; set { _Matp = value; OnPropertyChanged(); } }

        private Model.DonHangTp _SelectedItemnl;
        public Model.DonHangTp SelectedItemnl
        {
            get => _SelectedItemnl; set
            {
                _SelectedItemnl = value; OnPropertyChanged(); if (_SelectedItemnl != null)
                {
                    flag = true;
                    Matp = SelectedItemnl.MaTp;
                }
            }
        }

        public BOMLinhKienViewModel()
        {
            flag = false;
            sololist = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp.Where(x => x.TinhTrang == "Sản xuất"));
            viewdata = new RelayCommand<object>((p) => { return true; }, (p) => { loadBom(); });
        }

        void loadBom()
        {
            SanLuongList = new ObservableCollection<BOMHaoHutLinhKienModel>();

            var output = DataProvider.Ins.DB.KhoLinhKienOutputInfo.Where(x => x.SoLo == solo);

            int i = 1;

            foreach (var item in output)
            {
                BOMHaoHutLinhKienModel nl = new BOMHaoHutLinhKienModel();

                nl.STT = i;
                nl.MaPhieu = item.MaPhieu;
                nl.Ngay = DataProvider.Ins.DB.KhoLinhKienOutput.Where(x => x.MaPhieu == item.MaPhieu).First().DateCT;
                nl.IdCus = DataProvider.Ins.DB.KhoLinhKienOutput.Where(x => x.MaPhieu == item.MaPhieu).First().DisplayName;
                string ghichu = DataProvider.Ins.DB.KhoLinhKienOutput.Where(x => x.MaPhieu == item.MaPhieu).First().GhiChu + "-" + item.GhiChu;
                nl.GhiChu = ghichu;
                nl.SoLo = item.SoLo;
                nl.SoHoa = item.SoHoa;
                nl.QuyCach = item.QuyCach;
                nl.DisplayName = item.DisplayName;
                nl.IdU = item.IdU;
                nl.ViTri = item.ViTri;
                nl.QrCode = item.QRcode;
                nl.SoLuong = item.SoLuongNhap;
                nl.KhoiLuong = item.KhoiLuongKien;
                i++;

                SanLuongList.Add(nl);
            }

        }
    }
}
