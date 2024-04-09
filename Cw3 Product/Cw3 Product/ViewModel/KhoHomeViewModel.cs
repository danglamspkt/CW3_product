using Cw3_Product.Model;
using Cw3_Product.UserControlKho;
using Cw3_Product.ViewModel;
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
using Cw3_Product.UserControlSanXuat;

namespace Cw3_Product.ViewModel
{
    public class KhoHomeViewModel : BaseViewModel
    {
        //------------------------khai báo hiển thị địa chỉ--------------------------
        private string _txbTitle1;
        public string txbTitle1 { get => _txbTitle1; set { _txbTitle1 = value; OnPropertyChanged(); } }

        private string _txbTitle2;
        public string txbTitle2 { get => _txbTitle2; set { _txbTitle2 = value; OnPropertyChanged(); } }

        private string _txbTitle3;
        public string txbTitle3 { get => _txbTitle3; set { _txbTitle3 = value; OnPropertyChanged(); } }

        //-----------------Khai báo Usercontrol-------------------------------
        public UserControl uc { get; set; }

        //--------------Khai báo hiển thị UC con-------------------------
        public ICommand Homedata { get; set; }
        public ICommand OutputTP2Data { get; set; }
        public ICommand InputNLData { get; set; }
        public ICommand SuplierData { get; set; }
        public ICommand CustomerData { get; set; }
        public ICommand OutputNLData { get; set; }
        public ICommand InputLkData { get; set; }
        public ICommand OutputLkData { get; set; }
        public ICommand InputTpData { get; set; }
        public ICommand OutputTpData { get; set; }
        public ICommand TonKhoNlData { get; set; }
        public ICommand TonKhoLkData { get; set; }
        public ICommand TonKhoTpData { get; set; }
        public ICommand SoDoNlData { get; set; }
        public ICommand SoDoLkData { get; set; }
        public ICommand SoDoTpData { get; set; }
        public ICommand BOMHHTongQuanData { get; set; }
        public ICommand BOMHHNguyenLieuData { get; set; }
        public ICommand BOMHHLinhKienData { get; set; }


        //============================================================================================================
        //==========================================Chương trình chính================================================
        //============================================================================================================
        public KhoHomeViewModel() 
        {
            string accname = Cw3_Product.Properties.Settings.Default.account;
            int level = Cw3_Product.Properties.Settings.Default.UserLevel;

            Homedata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new KhoHomeUC(); p.Children.Add(uc);
                txbTitle1 = ""; txbTitle2 = ""; txbTitle3 = "";
            });

            OutputTP2Data = new RelayCommand<Grid>((p) => 
            {
                if ((level > 0 && level < 10) || (level >= 70 && level < 80))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new OutputKhoTpUC(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "Xuất kho / "; txbTitle3 = "Xuất kho thành phẩm";
            });

            InputNLData = new RelayCommand<Grid>((p) =>
            {
                if ((level > 0 && level < 10) || (level >= 70 && level < 80))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new PhieuNhapKhoNguyenLieu(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "Nhập kho / "; txbTitle3 = "Nhập kho nguyên liệu";
            });

            SuplierData = new RelayCommand<Grid>((p) =>
            {
                if ((level > 0 && level < 10) || (level >= 70 && level < 80))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new SuplierUC(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "Nhà cung cấp / "; txbTitle3 = "Nhà cung cấp";
            });

            CustomerData = new RelayCommand<Grid>((p) =>
            {
                if ((level > 0 && level < 10) || (level >= 70 && level < 80))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new CustomerUC(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "Khách hàng / "; txbTitle3 = "Khách hàng";
            });

            OutputNLData = new RelayCommand<Grid>((p) =>
            {
                if ((level > 0 && level < 10) || (level >= 70 && level < 80))
                    return true;
                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new PhieuXuatKhoNguyenLieuUC(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "Xuất kho / "; txbTitle3 = "Xuất kho nguyên liệu";
            });

            InputLkData = new RelayCommand<Grid>((p) => { if ((level > 0 && level < 10) || (level >= 70 && level < 80)) return true; else return false; }, (p) =>
            {
                p.Children.Clear(); uc = new PhieuNhapKhoLinhKienUC(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "Nhập kho / "; txbTitle3 = "Nhập kho linh kiện";
            });

            OutputLkData = new RelayCommand<Grid>((p) => { if ((level > 0 && level < 10) || (level >= 70 && level < 80)) return true; else return false; }, (p) =>
            {
                p.Children.Clear(); uc = new PhieuXuatKhoLinhKienUC(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "Xuất kho / "; txbTitle3 = "Xuất kho linh kiện";
            });

            InputTpData = new RelayCommand<Grid>((p) => { if ((level > 0 && level < 10) || (level >= 70 && level < 80)) return true; else return false; }, (p) =>
            {
                p.Children.Clear(); uc = new PhieuNhapKhoThanhPhamUC(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "Nhập kho / "; txbTitle3 = "Nhập kho thành phẩm";
            });

            OutputTpData = new RelayCommand<Grid>((p) => { if ((level > 0 && level < 10) || (level >= 70 && level < 80)) return true; else return false; }, (p) =>
            {
                p.Children.Clear(); uc = new PhieuXuatKhoThanhPhamUC(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "Xuất kho / "; txbTitle3 = "Xuất kho thành phẩm";
            });
            TonKhoNlData = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new TonKhoNguyenLieuUC(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "Tồn kho / "; txbTitle3 = "Tồn kho nguyên liệu";
            });
            TonKhoLkData = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new TonKhoLinhKienUC(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "Tồn kho / "; txbTitle3 = "Tồn kho linh kiện";
            });
            TonKhoTpData = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new TonKhoThanhPhamUC(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "Tồn kho / "; txbTitle3 = "Tồn kho thành phẩm";
            });
            SoDoNlData = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new SoDoKhoNguyenLieuUC(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "Sơ đồ kho / "; txbTitle3 = "Sơ đồ kho nguyên liệu";
            });
            SoDoLkData = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new SoDoKhoLinhKienUC(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "Sơ đồ kho / "; txbTitle3 = "Sơ đồ kho linh kiện";
            });
            SoDoTpData = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new SoDoKhoThanhPhamUC(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "Sơ đồ kho / "; txbTitle3 = "Sơ đồ kho thành phẩm";
            });
            BOMHHTongQuanData = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new BOMHaoHutTongQuan(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "BOM hao hụt / "; txbTitle3 = "BOM hao hụt tổng quan";
            });
            BOMHHNguyenLieuData = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new BOMHaoHutNguyenLieuUC(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "BOM hao hụt / "; txbTitle3 = "BOM hao hụt nguyên liệu";
            });
            BOMHHLinhKienData = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new BOMHaoHutLinhKienUC(); p.Children.Add(uc);
                txbTitle1 = "Kho / "; txbTitle2 = "BOM hao hụt / "; txbTitle3 = "BOM hao hụt linh kiện";
            });

        }
    }
}
