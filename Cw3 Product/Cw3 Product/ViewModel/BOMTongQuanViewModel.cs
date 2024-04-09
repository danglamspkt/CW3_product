using Cw3_Product.Model;
using DocumentFormat.OpenXml.Wordprocessing;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cw3_Product.ViewModel
{
    public class BOMTongQuanViewModel : BaseViewModel
    {
        private ObservableCollection<BOMHaoHutTongQuanModel> _SanLuongList;
        public ObservableCollection<BOMHaoHutTongQuanModel> SanLuongList { get => _SanLuongList; set { _SanLuongList = value; OnPropertyChanged(); } }

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

        public BOMTongQuanViewModel()
        {
            flag = false;
            sololist = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp.Where(x => x.TinhTrang == "Sản xuất"));
            viewdata = new RelayCommand<object>((p) => {return true; }, (p) => { loadBom(); });

        }

        void loadBom()
        {
            SanLuongList = new ObservableCollection<BOMHaoHutTongQuanModel>();

            var bom = DataProvider.Ins.DB.BomLkTp.Where(x => x.MaTp == Matp);
            var soluong = DataProvider.Ins.DB.DonHangTp.Where(x => x.SoLo == solo).First().SoLuong;
            var phatlieulk = DataProvider.Ins.DB.KhoLinhKienOutput.Where(x => (x.IdCus == "GcDk      " || x.IdCus == "GcEn      " || x.IdCus == "Han       " || x.IdCus == "Son       " || x.IdCus == "Lr        "));
            var phatlieunl = DataProvider.Ins.DB.KhoNguyenLieuOutput.Where(x => (x.IdCus == "GcDk      " || x.IdCus == "GcEn      " || x.IdCus == "Han       " || x.IdCus == "Son       " || x.IdCus == "Lr        "));
            

            

                int i = 1;
            foreach (var item in bom)
            {
                BOMHaoHutTongQuanModel bomtq = new BOMHaoHutTongQuanModel();
                bomtq.STT = i;
                bomtq.SoHoa = item.SoHoa;
                bomtq.DisplayName = DataProvider.Ins.DB.BomLk.Where(x => x.SoHoa == item.SoHoa).First().DisplayName;
                bomtq.MaMuaHang = item.MaMuaHang;
                bomtq.ChatLieu = DataProvider.Ins.DB.BomNl.Where(x => x.MaMuaHang == item.MaMuaHang).First().ChatLieu;
                bomtq.QuyCach = DataProvider.Ins.DB.BomNl.Where(x => x.MaMuaHang == item.MaMuaHang).First().QuyCach;
                bomtq.HeSo = item.HeSo;
                bomtq.SoLuongCan = soluong * item.HeSo;

                int phatlk = 0;
                int phatnl = 0;
                foreach (var item1 in phatlieulk)
                {
                    var phatlieulki = DataProvider.Ins.DB.KhoLinhKienOutputInfo.Where(x => x.MaPhieu == item1.MaPhieu);
                    foreach (var item11 in phatlieulki)
                    {
                        if (item11.SoHoa == item.SoHoa) phatlk += item11.SoLuongNhap;
                    }
                }

                foreach (var item2 in phatlieunl)
                {
                    var phatlieunli = DataProvider.Ins.DB.KhoNguyenLieuOutputInfo.Where(x => x.MaPhieu == item2.MaPhieu);
                    foreach (var item21 in phatlieunli)
                    {
                        if (item21.MaMuaHang == item.MaMuaHang) phatnl += item21.SoLuongNhap;
                    }
                }

                bomtq.SoLuongPhat = phatlk + phatnl;
                bomtq.SoLuongCon = bomtq.SoLuongCan - bomtq.SoLuongPhat;

                SanLuongList.Add(bomtq);
            }
        }
    }
}
