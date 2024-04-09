using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using Cw3_Product.UserControlMenu;
using Cw3_Product.UserControlKeHoach;
using Cw3_Product.Model;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Security.Cryptography;

namespace Cw3_Product.ViewModel
{
    public class KeHoachViewModel : BaseViewModel
    {

        private ObservableCollection<KeHoachTheoDonModel> _KhtdList;
        public ObservableCollection<KeHoachTheoDonModel> KhtdList { get => _KhtdList; set { _KhtdList = value; OnPropertyChanged(); } }

        private ObservableCollection<DonHangTp> _DonSxList;
        public ObservableCollection<DonHangTp> DonSxList { get => _DonSxList; set { _DonSxList = value; OnPropertyChanged(); } }

        private ObservableCollection<DonXuatHangChiTietModel> _DonXHList;
        public ObservableCollection<DonXuatHangChiTietModel> DonXHList { get => _DonXHList; set { _DonXHList = value; OnPropertyChanged(); } }

        public UserControl uc { get; set; }

        private string _txbTitle1;
        public string txbTitle1 { get => _txbTitle1; set { _txbTitle1 = value; OnPropertyChanged(); } }

        private string _txbTitle2;
        public string txbTitle2 { get => _txbTitle2; set { _txbTitle2 = value; OnPropertyChanged(); } }

        private string _txbTitle3;
        public string txbTitle3 { get => _txbTitle3; set { _txbTitle3 = value; OnPropertyChanged(); } }


        private Model.DonHangTp _SelectedItem1;
        public Model.DonHangTp SelectedItem1
        {
            get => _SelectedItem1; set
            {
                _SelectedItem1 = value; OnPropertyChanged(); if (SelectedItem1 != null)
                {
                    txbMatp = SelectedItem1.MaTp;
                    txbDvi = SelectedItem1.IdU;
                    txbSolo = SelectedItem1.SoLo;
                    txbSoLuong = (int)SelectedItem1.SoLuong;
                    pickNgay = (DateTime)SelectedItem1.NgayLenDon;
                    txbTinhTrang = SelectedItem1.TinhTrang;

                }
            }
        }

        private Model.DonXuatHangChiTietModel _SelectedItemxh;
        public Model.DonXuatHangChiTietModel SelectedItemxh
        {
            get => _SelectedItemxh; set
            {
                _SelectedItemxh = value; OnPropertyChanged(); if (SelectedItemxh != null)
                {
                    XhSTT = SelectedItemxh.STT;
                    xhMaTp = SelectedItemxh.MaTp;
                    xhDonVi = SelectedItemxh.Donvi;
                    xhSoLuong = (int)SelectedItemxh.Soluongxuat;
                    xhNgay = (DateTime)SelectedItemxh.Ngaylendon;

                }
            }
        }

        private ObservableCollection<BomTp> _Matpss;
        public ObservableCollection<BomTp> Matpss { get => _Matpss; set { _Matpss = value; OnPropertyChanged(); } }

        private ObservableCollection<Unit> _cbDonVi;
        public ObservableCollection<Unit> cbDonVi { get => _cbDonVi; set { _cbDonVi = value; OnPropertyChanged(); } }

        private string _txbMatp;
        public string txbMatp { get => _txbMatp; set { _txbMatp = value; OnPropertyChanged(); } }

        private string _txbDvi;
        public string txbDvi { get => _txbDvi; set { _txbDvi = value; OnPropertyChanged(); } }

        private string _txbSolo;
        public string txbSolo { get => _txbSolo; set { _txbSolo = value; OnPropertyChanged(); } }

        private int? _txbSoLuong;
        public int? txbSoLuong { get => _txbSoLuong; set { _txbSoLuong = value; OnPropertyChanged(); } }

        private string _txbTinhTrang;
        public string txbTinhTrang { get => _txbTinhTrang; set { _txbTinhTrang = value; OnPropertyChanged(); } }

        private DateTime? _pickNgay;
        public DateTime? pickNgay { get => _pickNgay; set { _pickNgay = value; OnPropertyChanged(); } }

        private string _xhMaTp;
        public string xhMaTp { get => _xhMaTp; set { _xhMaTp = value; OnPropertyChanged(); } }

        private string _xhDonVi;
        public string xhDonVi { get => _xhDonVi; set { _xhDonVi = value; OnPropertyChanged(); } }

        private int? _XhSTT;
        public int? XhSTT { get => _XhSTT; set { _XhSTT = value; OnPropertyChanged(); } }

        private int? _xhSoLuong;
        public int? xhSoLuong { get => _xhSoLuong; set { _xhSoLuong = value; OnPropertyChanged(); } }

        private DateTime? _xhNgay;
        public DateTime? xhNgay { get => _xhNgay; set { _xhNgay = value; OnPropertyChanged(); } }


        public ICommand Homedata { get; set; }
        public ICommand SLTDdata { get; set; }
        public ICommand DonSXChiTietdata { get; set; }
        public ICommand DonXHChiTietdata { get; set; }
        public ICommand addcommandsx { get; set; }
        public ICommand editcommandsx { get; set; }
        public ICommand deletecommandsx { get; set; }
        public ICommand Clearsx { get; set; }
        public ICommand addcommandxh { get; set; }
        public ICommand editcommandxh { get; set; }
        public ICommand deletecommandxh { get; set; }
        public ICommand Clearxh { get; set; }

        string accname;


        public KeHoachViewModel()
        {
            MainWindow mainwindow = new MainWindow();
            var mainVM = mainwindow.DataContext as MainViewModel;

            int level = mainVM.Userlevel;
            mainwindow.Close();
            accname = Cw3_Product.Properties.Settings.Default.account;

            Homedata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new KeHoachHomeUC(); p.Children.Add(uc);
                txbTitle1 = ""; txbTitle2 = ""; txbTitle3 = "";
            });

            SLTDdata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new SltdUC(); p.Children.Add(uc);
                txbTitle1 = "Kế Hoạch / "; txbTitle2 = "Tổng quan / "; txbTitle3 = "Sản lượng theo đơn";
                LoadKhtd();
            });

            DonSXChiTietdata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new DonSxChiTietUC(); p.Children.Add(uc);
                txbTitle1 = "Kế Hoạch / "; txbTitle2 = "Đơn sản xuất / "; txbTitle3 = "Chi tiết";
                LoadKeHoachSx();
                
            });

            DonXHChiTietdata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new DonXhChiTietUC(); p.Children.Add(uc);
                txbTitle1 = "Kế Hoạch / "; txbTitle2 = "Đơn xuất hàng / "; txbTitle3 = "Chi tiết";
                LoadKeHoachxh();
            });

            Clearsx = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                cleardonsx();
            });

            
            addcommandsx = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(txbMatp) || string.IsNullOrEmpty(txbDvi) || string.IsNullOrEmpty(txbSolo) || (txbSoLuong <= 0))
                    return false;
                var sololist = DataProvider.Ins.DB.DonHangTp.Where(x => x.SoLo == txbSolo);
                if (sololist == null || sololist.Count() != 0) return false;

                return true;
            }, (p) =>
            {
                var themdon = new DonHangTp() { SoLo = txbSolo, MaTp = txbMatp, IdU = txbDvi, NgayLenDon = pickNgay, SoLuong = txbSoLuong, TinhTrang = txbTinhTrang, UserName = accname };
                DataProvider.Ins.DB.DonHangTp.Add(themdon);
                DataProvider.Ins.DB.SaveChanges();

                DonSxList.Add(themdon);
                LoadKeHoachSx();

            });

            editcommandsx = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(txbMatp) || string.IsNullOrEmpty(txbDvi) || string.IsNullOrEmpty(txbSolo) || (txbSoLuong <= 0))
                    return false;
                var sololist = DataProvider.Ins.DB.DonHangTp.Where(x => x.SoLo == txbSolo);
                if (sololist == null || sololist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var suadon = DataProvider.Ins.DB.DonHangTp.Where(x => x.SoLo == txbSolo).SingleOrDefault();
                suadon.SoLo = txbSolo;
                suadon.MaTp = txbMatp;
                suadon.IdU = txbDvi;
                suadon.NgayLenDon = pickNgay;
                suadon.SoLuong = txbSoLuong;
                suadon.TinhTrang = txbTinhTrang;
                suadon.UserName = accname;
                DataProvider.Ins.DB.SaveChanges();
                LoadKeHoachSx();

            });

            deletecommandsx = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(txbMatp) || string.IsNullOrEmpty(txbDvi) || string.IsNullOrEmpty(txbSolo) || (txbSoLuong <= 0))
                    return false;
                var sololist = DataProvider.Ins.DB.DonHangTp.Where(x => x.SoLo == txbSolo);
                if (sololist == null || sololist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                try
                {
                    var donhang = DataProvider.Ins.DB.DonHangTp;
                    foreach (var item in donhang)
                    {
                        if (item.SoLo == txbSolo)
                        {
                            donhang.Remove(item);
                        }
                    }
                    DataProvider.Ins.DB.SaveChanges();
                    LoadKeHoachSx();
                }
                catch (Exception)
                {
                    MessageBox.Show("Đơn hàng đang sử dụng, không thể xóa!", "Xóa mã hàng!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            });


            addcommandxh = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(xhMaTp) || string.IsNullOrEmpty(xhDonVi) || (xhNgay) == null || (xhSoLuong <= 0))
                    return false;

                return true;
            }, (p) =>
            {
                var themdonxh = new DonXuatHangTP() { MaTp = xhMaTp, IdU = xhDonVi, NgayDuKien = xhNgay, SoluongXuat = xhSoLuong, UserName = accname };

                DataProvider.Ins.DB.DonXuatHangTP.Add(themdonxh);
                DataProvider.Ins.DB.SaveChanges();
                LoadKeHoachxh();


            });

            editcommandxh = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(xhMaTp) || string.IsNullOrEmpty(xhDonVi) || (xhNgay) == null || (xhSoLuong <= 0)  || (xhSoLuong == null))
                    return false;
                var sttlist = DataProvider.Ins.DB.DonXuatHangTP.Where(x => x.IdDonXuatTp == XhSTT);
                if (sttlist == null || sttlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var suadonxh = DataProvider.Ins.DB.DonXuatHangTP.Where(x => x.IdDonXuatTp == XhSTT).SingleOrDefault();
                suadonxh.MaTp = xhMaTp;
                suadonxh.IdU = xhDonVi;
                suadonxh.NgayDuKien = xhNgay;
                suadonxh.SoluongXuat = xhSoLuong;
                suadonxh.UserName = accname;
                DataProvider.Ins.DB.SaveChanges();
                LoadKeHoachxh();

            });

            deletecommandxh = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(xhMaTp) || string.IsNullOrEmpty(xhDonVi) || (xhNgay) == null || (xhSoLuong <= 0))
                    return false;
                var sttlist = DataProvider.Ins.DB.DonXuatHangTP.Where(x => x.IdDonXuatTp == XhSTT);
                if (sttlist == null || sttlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                try
                {
                    var donxuat = DataProvider.Ins.DB.DonXuatHangTP;
                    foreach (var item in donxuat)
                    {
                        if (item.IdDonXuatTp == XhSTT)
                        {
                            donxuat.Remove(item);
                        }
                    }
                    DataProvider.Ins.DB.SaveChanges();
                    LoadKeHoachxh();
                }
                catch (Exception )
                {
                    MessageBox.Show("Đơn xuất hàng đang sử dụng, không thể xóa!", "Xóa mã hàng!", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            });

            Clearxh = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                cleardonxh();
            });

        }

        void LoadKhtd()
        {
            KhtdList = new ObservableCollection<KeHoachTheoDonModel>();

            var Khtd = DataProvider.Ins.DB.DonHangTp;

            int i = 1;
            foreach (var item in Khtd)
            {
                KeHoachTheoDonModel model = new KeHoachTheoDonModel();
                 
                model.STT = i;

                var LapRap1 = DataProvider.Ins.DB.KhoThanhPhamInputInfo.Where(p => p.SoLo1 == item.SoLo);
                var LapRap2 = DataProvider.Ins.DB.KhoThanhPhamInputInfo.Where(p => p.SoLo2 == item.SoLo);
                var XuatHang1 = DataProvider.Ins.DB.KhoThanhPhamOutputInfo.Where(p => p.SoLo1 == item.SoLo);
                var XuatHang2 = DataProvider.Ins.DB.KhoThanhPhamOutputInfo.Where(p => p.SoLo2 == item.SoLo);

                int sumLR1 = 0;
                int SumXH1 = 0;
                int sumLR2 = 0;
                int SumXH2 = 0;


                if (sumLR1 != null)
                {
                    if (LapRap1.Count() > 0 ) sumLR1 = (int)LapRap1.Sum(p => p.SoLuongNhap1);
                }
                if (SumXH1 != null)
                {
                    if (XuatHang1.Count() > 0) SumXH1 = (int)XuatHang1.Sum(p => p.SoLuongNhap1);
                }

                if (sumLR2 != null)
                {
                    if (LapRap2.Count() > 0) sumLR2 = (int)LapRap2.Sum(p => p.SoLuongNhap2);
                }
                if (SumXH2 != null)
                {
                    if (XuatHang2.Count() > 0) SumXH2 = (int)XuatHang2.Sum(p => p.SoLuongNhap2);
                }


                model.NgayLenDon = (DateTime)item.NgayLenDon;
                model.MaBx = item.MaTp;
                model.SoLo = item.SoLo;
                model.SoLuong = (int)item.SoLuong;
                model.Laprap = sumLR1 + sumLR2;
                model.XuatHang = SumXH1 + SumXH2;
                model.ConLai = (int)item.SoLuong - (sumLR1 + sumLR2);
                model.TonKho = ((sumLR1 + sumLR2) - (SumXH1 + SumXH2));
                model.TinhTrangDon = item.TinhTrang;
                model.IdU = item.IdU;

                if (model.ConLai == 0 && model.TonKho == 0) continue;
                

                KhtdList.Add(model);
                i++;
            }
        }

        void LoadKeHoachSx()
        {
            DonSxList = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp);
            Matpss =new ObservableCollection<BomTp>(DataProvider.Ins.DB.BomTp);
            cbDonVi = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);

            //var dh = DataProvider.Ins.DB.DonHangTp;

            //int i = 1;
            //foreach (var item in dh)
            //{
            //    DonHangTp DonHang = new DonHangTp();


            //    DonHang.NgayLenDon = item.NgayLenDon;
            //    DonHang.MaTp = item.MaTp;
            //    DonHang.SoLo = item.SoLo;
            //    DonHang.SoLuong = item.SoLuong;
            //    DonHang.IdU = item.IdU;


            //    DonSxList.Add(DonHang);
            //    i++;
            //}

        }

        void LoadKeHoachxh()
        {
            DonXHList = new ObservableCollection<DonXuatHangChiTietModel>();
            Matpss = new ObservableCollection<BomTp>(DataProvider.Ins.DB.BomTp);
            cbDonVi = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);

            var xh = DataProvider.Ins.DB.DonXuatHangTP;
            List<string> a = new List<string>();
            List<int> vin = new List<int>();
            List<int> vout = new List<int>();
            int x = 0;

            foreach (var item1 in xh)
            {  
                

                var Xuattp1 = DataProvider.Ins.DB.KhoThanhPhamOutputInfo.Where(p => p.MaTp1 == item1.MaTp);
                var Xuattp2 = DataProvider.Ins.DB.KhoThanhPhamOutputInfo.Where(p => p.MaTp2 == item1.MaTp);

                var Nhaptp1 = DataProvider.Ins.DB.KhoThanhPhamInputInfo.Where(p => p.MaTp1 == item1.MaTp);
                var Nhaptp2 = DataProvider.Ins.DB.KhoThanhPhamInputInfo.Where(p => p.MaTp2 == item1.MaTp);


                if (a == null)
                {
                    a.Add(Xuattp1.First().MaTp1);
                    vout.Add((int)Xuattp1.Sum(p => p.SoLuongNhap1));
                    vin.Add((int)Nhaptp1.Sum(p => p.SoLuongNhap1));
                    x++;
                }
                else
                {
                    bool fl = false;
                    foreach (var item2 in a)
                    {
                        if (item2==item1.MaTp) fl = true;
                    }
                    if (fl==false)
                    {
                        a.Add(item1.MaTp);
                        if ((Xuattp1.Count() > 0) || (Xuattp2.Count() > 0))
                        {
                            if ((Xuattp1.Count() > 0) && (Xuattp2.Count() > 0))
                            {
                                vout.Add((int)Xuattp1.Sum(p => p.SoLuongNhap1) + (int)Xuattp2.Sum(p => p.SoLuongNhap2));
                                vin.Add((int)Nhaptp1.Sum(p => p.SoLuongNhap1) + (int)Nhaptp2.Sum(p => p.SoLuongNhap2));
                            }
                            else
                            {
                                if (Xuattp1.Count() > 0)
                                {
                                    vout.Add((int)Xuattp1.Sum(p => p.SoLuongNhap1));
                                    vin.Add((int)Nhaptp1.Sum(p => p.SoLuongNhap1));
                                }
                                if (Xuattp2.Count() > 0)
                                {
                                    vout.Add((int)Xuattp2.Sum(p => p.SoLuongNhap2));
                                    vin.Add((int)Nhaptp2.Sum(p => p.SoLuongNhap2));
                                }
                            }
                                
                        }                            
                        else
                        {
                            vout.Add(0);
                            vin.Add(0);
                        }
                        x++;
                    }
                }
            }

            int i = 1;
            foreach (var item in xh)
            {
                DonXuatHangChiTietModel XuatHang = new DonXuatHangChiTietModel();
                XuatHang.STT = item.IdDonXuatTp;
                XuatHang.Ngaylendon = (DateTime)item.NgayDuKien;
                XuatHang.MaTp = item.MaTp;
                XuatHang.Soluongxuat = (int)item.SoluongXuat;
                XuatHang.Donvi = item.IdU;
                for (int j = 0; j < x; j++)
                {
                    if (a[j]==item.MaTp)
                    {
                        if (vout[j] >= (int)item.SoluongXuat)
                        {
                            XuatHang.DaXuat = (int)item.SoluongXuat;
                            XuatHang.ConLai = 0;
                            vout[j] = vout[j] - (int)item.SoluongXuat;

                            XuatHang.TonKho = vin[j]-(int)item.SoluongXuat;
                            vin[j] = vin[j] - (int)item.SoluongXuat;
                        }
                        else
                        {
                            XuatHang.DaXuat = vout[j];
                            XuatHang.ConLai= (int)item.SoluongXuat - vout[j];
                            

                            if (vout[j] <= 0) XuatHang.TonKho = 0;
                            else
                            {
                                XuatHang.TonKho = vin[j] - vout[j];
                                vin[j] = vin[j] - (int)item.SoluongXuat;
                            }
                            vout[j] = 0;
                        }
                    }
                }


                DonXHList.Add(XuatHang);
                i++;
            }
        }

        void cleardonsx()
        {
            txbMatp = null;
            txbDvi = null;
            txbSolo = null;
            txbSoLuong = null;
            pickNgay = null;
        }

        void cleardonxh()
        {
            XhSTT = null;
            xhNgay = null;
            xhMaTp = null;
            xhDonVi = null;
            xhSoLuong = null;
        }


    }
}
