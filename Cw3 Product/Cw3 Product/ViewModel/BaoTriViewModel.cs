using Cw3_Product.Model;
using Cw3_Product.UserControlBaoTri;
using Cw3_Product.UserControlNhanSu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Cw3_Product.ViewModel
{
    public class BaoTriViewModel : BaseViewModel
    {
        public ICommand bdcbbMaMay { get; set; }

        //khai báo hiển thị địa chỉ
        private string _txbTitle1;
        public string txbTitle1 { get => _txbTitle1; set { _txbTitle1 = value; OnPropertyChanged(); } }

        private string _txbTitle2;
        public string txbTitle2 { get => _txbTitle2; set { _txbTitle2 = value; OnPropertyChanged(); } }

        private string _txbTitle3;
        public string txbTitle3 { get => _txbTitle3; set { _txbTitle3 = value; OnPropertyChanged(); } }

        //Khai báo Usercontrol
        public UserControl uc { get; set; }

        //Khai báo list hiển thị Nhóm máy
        private ObservableCollection<NhomMay> _NhomMayList;
        public ObservableCollection<NhomMay> NhomMayList { get => _NhomMayList; set { _NhomMayList = value; OnPropertyChanged(); } }

        //Khai báo list hiển thị tài sản cố định
        private ObservableCollection<TaiSanCoDinh> _TaiSanCoDinhList;
        public ObservableCollection<TaiSanCoDinh> TaiSanCoDinhList { get => _TaiSanCoDinhList; set { _TaiSanCoDinhList = value; OnPropertyChanged(); } }

        //Khai báo list hiển thị Lịch bảo dưỡng
        private ObservableCollection<KHBaoDuong> _KHBaoDuongList;
        public ObservableCollection<KHBaoDuong> KHBaoDuongList { get => _KHBaoDuongList; set { _KHBaoDuongList = value; OnPropertyChanged(); } }

        //Khai báo list hiển thị Bảo dưỡng
        private ObservableCollection<BaoDuong> _BaoDuongList;
        public ObservableCollection<BaoDuong> BaoDuongList { get => _BaoDuongList; set { _BaoDuongList = value; OnPropertyChanged(); } }

        //Khai báo list hiển thị Bảo trì
        private ObservableCollection<BaoTri> _BaoTriList;
        public ObservableCollection<BaoTri> BaoTriList { get => _BaoTriList; set { _BaoTriList = value; OnPropertyChanged(); } }

        //Khai báo list hiển thị Bộ phân
        private ObservableCollection<BoPhan> _BoPhanList;
        public ObservableCollection<BoPhan> BoPhanList { get => _BoPhanList; set { _BoPhanList = value; OnPropertyChanged(); } }

        //Khai báo hiển thị UC con
        public ICommand Homedata { get; set; }
        public ICommand NhomMaydata { get; set; }
        public ICommand TaiSanCoDinhdata { get; set; }
        public ICommand KHBaoDuongdata { get; set; }
        public ICommand TraCuuBaoDuongdata { get; set; }
        public ICommand BaoDuongdata { get; set; }
        public ICommand BaoTridata { get; set; }
        public ICommand LichSuSuaChuadata { get; set; }



        //Khai báo biến nhóm máy
        private string _nmIDNhomMay;
        public string nmIDNhomMay { get => _nmIDNhomMay; set { _nmIDNhomMay = value; OnPropertyChanged(); } }

        private string _nmDisplayName;
        public string nmDisplayName { get => _nmDisplayName; set { _nmDisplayName = value; OnPropertyChanged(); } }

        private string _nmMaBp;
        public string nmMaBp { get => _nmMaBp; set { _nmMaBp = value; OnPropertyChanged(); } }

        private Model.NhomMay _SelectedItemnm;
        public Model.NhomMay SelectedItemnm
        {
            get => _SelectedItemnm; set
            {
                _SelectedItemnm = value; OnPropertyChanged(); if (_SelectedItemnm != null)
                {
                    nmIDNhomMay = SelectedItemnm.IdNhomMay;
                    nmDisplayName = SelectedItemnm.DisplayName;
                    nmMaBp = SelectedItemnm.MaBp;
                }
            }
        }

        //Khai báo command thêm sửa xóa Nhóm máy
        public ICommand addcommandnm { get; set; }
        public ICommand editcommandnm { get; set; }
        public ICommand deletecommandnm { get; set; }
        public ICommand Clearnm { get; set; }



        //Khai báo biến Tài sản cố định
        private string _tscdMaMay;
        public string tscdMaMay { get => _tscdMaMay; set { _tscdMaMay = value; OnPropertyChanged(); } }

        private string _tscdDisplayName;
        public string tscdDisplayName { get => _tscdDisplayName; set { _tscdDisplayName = value; OnPropertyChanged(); } }

        private string _tscdMaBp;
        public string tscdMaBp { get => _tscdMaBp; set { _tscdMaBp = value; OnPropertyChanged(); } }

        private string _tscdViTri;
        public string tscdViTri { get => _tscdViTri; set { _tscdViTri = value; OnPropertyChanged(); } }

        private string _tscdIDNhomMay;
        public string tscdIDNhomMay { get => _tscdIDNhomMay; set { _tscdIDNhomMay = value; OnPropertyChanged(); } }

        private string _tscdTinhTrang;
        public string tscdTinhTrang { get => _tscdTinhTrang; set { _tscdTinhTrang = value; OnPropertyChanged(); } }

        private Model.TaiSanCoDinh _SelectedItemtscd;
        public Model.TaiSanCoDinh SelectedItemtscd
        {
            get => _SelectedItemtscd; set
            {
                _SelectedItemtscd = value; OnPropertyChanged(); if (_SelectedItemtscd != null)
                {
                    tscdMaMay = SelectedItemtscd.MaMay;
                    tscdDisplayName = SelectedItemtscd.DisplayName;
                    tscdMaBp = SelectedItemtscd.MaBp;
                    tscdViTri = SelectedItemtscd.ViTri;
                    tscdIDNhomMay = SelectedItemtscd.IdNhomMay;
                    tscdTinhTrang = SelectedItemtscd.TinhTrang;
                }
            }
        }

        //Khai báo command thêm sửa xóa Tài sản cố định
        public ICommand addcommandtscd { get; set; }
        public ICommand editcommandtscd { get; set; }
        public ICommand deletecommandtscd { get; set; }
        public ICommand Cleartscd { get; set; }


        //Khai báo biến kế hoạch bảo dưỡng
        private int? _khbdIdKeHoach;
        public int? khbdIdKeHoach { get => _khbdIdKeHoach; set { _khbdIdKeHoach = value; OnPropertyChanged(); } }

        private DateTime? _khbdNgayDuKien;
        public DateTime? khbdNgayDuKien { get => _khbdNgayDuKien; set { _khbdNgayDuKien = value; OnPropertyChanged(); } }

        private string _khbdIdNhomMay;
        public string khbdIdNhomMay { get => _khbdIdNhomMay; set { _khbdIdNhomMay = value; OnPropertyChanged(); } }

        private Model.KHBaoDuong _SelectedItemkhbd;
        public Model.KHBaoDuong SelectedItemkhbd
        {
            get => _SelectedItemkhbd; set
            {
                _SelectedItemkhbd = value; OnPropertyChanged(); if (_SelectedItemkhbd != null)
                {
                    khbdIdKeHoach = SelectedItemkhbd.IdKHBaoduong;
                    khbdNgayDuKien = SelectedItemkhbd.NgayDuKien;
                    khbdIdNhomMay = SelectedItemkhbd.IdNhomMay;
                }
            }
        }

        //Khai báo command thêm sửa xóa kế hoạch bảo dưỡng
        public ICommand addcommandkhbd { get; set; }
        public ICommand editcommandkhbd { get; set; }
        public ICommand deletecommandkhbd { get; set; }
        public ICommand Clearkhbd { get; set; }


        //Khai báo biến Bảo dưỡng
        private int? _bdIdBaoDuong;
        public int? bdIdBaoDuong { get => _bdIdBaoDuong; set { _bdIdBaoDuong = value; OnPropertyChanged(); } }

        private DateTime? _bdNgay;
        public DateTime? bdNgay { get => _bdNgay; set { _bdNgay = value; OnPropertyChanged(); } }

        private int? _bdIdKhBaoDuong;
        public int? bdIdKhBaoDuong { get => _bdIdKhBaoDuong; set { _bdIdKhBaoDuong = value; OnPropertyChanged(); } }

        private string _bdMaMay;
        public string bdMaMay { get => _bdMaMay; set { _bdMaMay = value; OnPropertyChanged(); } }

        private string _bdTinhTrang;
        public string bdTinhTrang { get => _bdTinhTrang; set { _bdTinhTrang = value; OnPropertyChanged(); } }

        private Model.BaoDuong _SelectedItembd;
        public Model.BaoDuong SelectedItembd
        {
            get => _SelectedItembd; set
            {
                _SelectedItembd = value; OnPropertyChanged(); if (_SelectedItembd != null)
                {
                    bdIdBaoDuong = SelectedItembd.IdBaoduong;
                    bdIdKhBaoDuong = SelectedItembd.IdKHBaoDuong;
                    bdMaMay = SelectedItembd.MaMay;
                    bdNgay = SelectedItembd.Ngay;
                    bdTinhTrang = SelectedItembd.TinhTrang;
                }
            }
        }

        //Khai báo command thêm sửa xóa Bảo dưỡng
        public ICommand addcommandbd { get; set; }
        public ICommand editcommandbd { get; set; }
        public ICommand deletecommandbd { get; set; }
        public ICommand Clearbd { get; set; }


        //Khai báo biến Bảo trì
        private int? _btIdBaoTri;
        public int? btIdBaoTri { get => _btIdBaoTri; set { _btIdBaoTri = value; OnPropertyChanged(); } }

        private DateTime? _btNgay;
        public DateTime? btNgay { get => _btNgay; set { _btNgay = value; OnPropertyChanged(); } }

        private string _btMaMay;
        public string btMaMay { get => _btMaMay; set { _btMaMay = value; OnPropertyChanged(); } }

        private string _btTinhTrang;
        public string btTinhTrang { get => _btTinhTrang; set { _btTinhTrang = value; OnPropertyChanged(); } }

        private string _btXuLy;
        public string btXuLy { get => _btXuLy; set { _btXuLy = value; OnPropertyChanged(); } }

        private Model.BaoTri _SelectedItembt;
        public Model.BaoTri SelectedItembt
        {
            get => _SelectedItembt; set
            {
                _SelectedItembt = value; OnPropertyChanged(); if (_SelectedItembt != null)
                {
                    btIdBaoTri = SelectedItembt.IdBaotri;
                    btMaMay = SelectedItembt.MaMay;
                    btNgay = SelectedItembt.Ngay;
                    btTinhTrang = SelectedItembt.TinhTrang;
                    btXuLy = SelectedItembt.XuLy;
                }
            }
        }

        //Khai báo command thêm sửa xóa Bảo trì
        public ICommand addcommandbt { get; set; }
        public ICommand editcommandbt { get; set; }
        public ICommand deletecommandbt { get; set; }
        public ICommand Clearbt { get; set; }

        public BaoTriViewModel() 
        {
            txbTitle1 = ""; txbTitle2 = ""; txbTitle3 = "";

            MainWindow mainwindow = new MainWindow();
            var mainVM = mainwindow.DataContext as MainViewModel;

            int level = mainVM.Userlevel;
            mainwindow.Close();

            bdcbbMaMay = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                var dem = DataProvider.Ins.DB.KHBaoDuong.Where(x => x.IdKHBaoduong == bdIdKhBaoDuong);
                if (bdIdKhBaoDuong == null)
                {
                    TaiSanCoDinhList = null;
                }                
                else if (dem == null || dem.Count() == 0)
                {
                    TaiSanCoDinhList = null;
                }
                else
                {
                    string bd = DataProvider.Ins.DB.KHBaoDuong.Where(x => x.IdKHBaoduong == bdIdKhBaoDuong).First().IdNhomMay;
                    TaiSanCoDinhList = new ObservableCollection<TaiSanCoDinh>(DataProvider.Ins.DB.TaiSanCoDinh.Where(y => y.IdNhomMay == bd));
                }

            });


            Homedata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new BaotriHomeUC(); p.Children.Add(uc);
                txbTitle1 = ""; txbTitle2 = ""; txbTitle3 = "";
            });

            NhomMaydata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new NhomMayUC(); p.Children.Add(uc);
                txbTitle1 = "Bảo trì / "; txbTitle2 = "Tài sản cố định / "; txbTitle3 = "Nhóm Máy";
                LoadNhomMay();
            });

            TaiSanCoDinhdata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                if (level > 2)
                {
                    MessageBox.Show("Bạn không thể truy cập vào mục này!");
                }
                else
                {
                    p.Children.Clear(); uc = new TaiSanCoDinhUC(); p.Children.Add(uc);
                    txbTitle1 = "Bảo trì / "; txbTitle2 = "Tài sản cố định / "; txbTitle3 = "Danh sách tài sản cố định";
                    LoadTaiSanCoDinh();
                }
            });

            KHBaoDuongdata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                if (level > 2)
                {
                    MessageBox.Show("Bạn không thể truy cập vào mục này!");
                }
                else
                {
                    p.Children.Clear(); uc = new KeHoachBaoDuongUC(); p.Children.Add(uc);
                    txbTitle1 = "Bảo trì / "; txbTitle2 = "Bảo Dưỡng Máy / "; txbTitle3 = "Lập Kế Hoạch Bảo Dưỡng";
                    LoadKeHoachBaoDuong();
                }
            });

            TraCuuBaoDuongdata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                if (level > 2)
                {
                    MessageBox.Show("Bạn không thể truy cập vào mục này!");
                }
                else
                {
                    p.Children.Clear(); uc = new TraCuuBaoDuongUC(); p.Children.Add(uc);
                    txbTitle1 = "Bảo trì / "; txbTitle2 = "Bảo Dưỡng Máy / "; txbTitle3 = "Tra Cứu Kế Hoạch Bảo Dưỡng";

                }
            });

            BaoDuongdata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                if (level > 2)
                {
                    MessageBox.Show("Bạn không thể truy cập vào mục này!");
                }
                else
                {
                    p.Children.Clear(); uc = new ThucHienBaoDuongUC(); p.Children.Add(uc);
                    txbTitle1 = "Bảo trì / "; txbTitle2 = "Bảo Dưỡng Máy / "; txbTitle3 = "Thực hiện Bảo Dưỡng";
                    LoadBaoDuong();
                }
            });

            BaoTridata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                if (level > 2)
                {
                    MessageBox.Show("Bạn không thể truy cập vào mục này!");
                }
                else
                {
                    p.Children.Clear(); uc = new GhiNhanLoiMayUC(); p.Children.Add(uc);
                    txbTitle1 = "Bảo trì / "; txbTitle2 = "Bảo Trì Máy / "; txbTitle3 = "Ghi nhận lỗi máy";
                    LoadBaoTri();
                }
            });

            LichSuSuaChuadata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                if (level > 2)
                {
                    MessageBox.Show("Bạn không thể truy cập vào mục này!");
                }
                else
                {
                    p.Children.Clear(); uc = new LichSuSuaChua(); p.Children.Add(uc);
                    txbTitle1 = "Bảo trì / "; txbTitle2 = "Bảo Trì Máy / "; txbTitle3 = "Thống kê lỗi";

                }
            });

            //Command Nhóm Máy
            addcommandnm = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(nmIDNhomMay) || string.IsNullOrEmpty(nmDisplayName) || string.IsNullOrEmpty(nmMaBp))
                    return false;
                var nmlist = DataProvider.Ins.DB.NhomMay.Where(x => x.IdNhomMay == nmIDNhomMay);
                if (nmlist == null || nmlist.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                var themnm = new NhomMay() { IdNhomMay = nmIDNhomMay, DisplayName = nmDisplayName, MaBp = nmMaBp };

                DataProvider.Ins.DB.NhomMay.Add(themnm);
                DataProvider.Ins.DB.SaveChanges();
                LoadNhomMay();
            });

            editcommandnm = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(nmIDNhomMay) || string.IsNullOrEmpty(nmDisplayName) || string.IsNullOrEmpty(nmMaBp))
                    return false;
                var nmlist = DataProvider.Ins.DB.NhomMay.Where(x => x.IdNhomMay == nmIDNhomMay);
                if (nmlist == null || nmlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var suanm = DataProvider.Ins.DB.NhomMay.Where(x => x.IdNhomMay == nmIDNhomMay).SingleOrDefault();
                suanm.DisplayName = nmDisplayName;
                suanm.MaBp = nmMaBp;
                DataProvider.Ins.DB.SaveChanges();
                LoadNhomMay();

            });

            deletecommandnm = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(nmIDNhomMay) || string.IsNullOrEmpty(nmDisplayName) || string.IsNullOrEmpty(nmMaBp))
                    return false;
                var nmlist = DataProvider.Ins.DB.NhomMay.Where(x => x.IdNhomMay == nmIDNhomMay);
                if (nmlist == null || nmlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var nhommay = DataProvider.Ins.DB.NhomMay;
                foreach (var item in nhommay)
                {
                    if (item.IdNhomMay == nmIDNhomMay)
                    {
                        nhommay.Remove(item);
                    }
                }
                DataProvider.Ins.DB.SaveChanges();
                LoadNhomMay();
            });

            Clearnm = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                clearNhomMay();
            });


            //Command Tài Sản cố định
            addcommandtscd = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(tscdMaMay) || string.IsNullOrEmpty(tscdDisplayName) || string.IsNullOrEmpty(tscdMaBp) || string.IsNullOrEmpty(tscdViTri) || string.IsNullOrEmpty(tscdIDNhomMay))
                    return false;
                var tscdlist = DataProvider.Ins.DB.TaiSanCoDinh.Where(x => x.MaMay == tscdMaMay);
                if (tscdlist == null || tscdlist.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                var themtscd = new TaiSanCoDinh() { MaMay = tscdMaMay, DisplayName = tscdDisplayName, MaBp = tscdMaBp, ViTri = tscdViTri, IdNhomMay = tscdIDNhomMay, TinhTrang = tscdTinhTrang };

                DataProvider.Ins.DB.TaiSanCoDinh.Add(themtscd);
                DataProvider.Ins.DB.SaveChanges();
                LoadTaiSanCoDinh();
            });

            editcommandtscd = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(tscdMaMay) || string.IsNullOrEmpty(tscdDisplayName) || string.IsNullOrEmpty(tscdMaBp) || string.IsNullOrEmpty(tscdViTri) || string.IsNullOrEmpty(tscdIDNhomMay))
                    return false;
                var tscdlist = DataProvider.Ins.DB.TaiSanCoDinh.Where(x => x.MaMay == tscdMaMay);
                if (tscdlist == null || tscdlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var suatscd = DataProvider.Ins.DB.TaiSanCoDinh.Where(x => x.MaMay == tscdMaMay).SingleOrDefault();
                suatscd.DisplayName = tscdDisplayName;
                suatscd.MaBp = tscdMaBp;
                suatscd.ViTri = tscdViTri;
                suatscd.IdNhomMay = tscdIDNhomMay;
                suatscd.TinhTrang = tscdIDNhomMay;
                DataProvider.Ins.DB.SaveChanges();
                LoadTaiSanCoDinh();

            });

            deletecommandtscd = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(tscdMaMay) || string.IsNullOrEmpty(tscdDisplayName) || string.IsNullOrEmpty(tscdMaBp) || string.IsNullOrEmpty(tscdViTri) || string.IsNullOrEmpty(tscdIDNhomMay))
                    return false;
                var tscdlist = DataProvider.Ins.DB.TaiSanCoDinh.Where(x => x.MaMay == tscdMaMay);
                if (tscdlist == null || tscdlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var taisancodinh = DataProvider.Ins.DB.TaiSanCoDinh;
                foreach (var item in taisancodinh)
                {
                    if (item.MaMay == tscdMaMay)
                    {
                        taisancodinh.Remove(item);
                    }
                }
                DataProvider.Ins.DB.SaveChanges();
                LoadTaiSanCoDinh();
            });

            Cleartscd = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                clearTaiSanCoDinh();
            });


            //Command kế hoạch bảo dưỡng
            addcommandkhbd = new RelayCommand<object>((p) =>
            {
                if (khbdNgayDuKien == null || string.IsNullOrEmpty(khbdIdNhomMay))
                    return false;
                var khbdlist = DataProvider.Ins.DB.KHBaoDuong.Where(x => x.IdKHBaoduong == khbdIdKeHoach);
                if (khbdlist == null || khbdlist.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                var themkhbd = new KHBaoDuong() { NgayDuKien = khbdNgayDuKien, IdNhomMay = khbdIdNhomMay };

                DataProvider.Ins.DB.KHBaoDuong.Add(themkhbd);
                DataProvider.Ins.DB.SaveChanges();
                LoadKeHoachBaoDuong();
            });

            editcommandkhbd = new RelayCommand<object>((p) =>
            {
                if (khbdNgayDuKien == null || string.IsNullOrEmpty(khbdIdNhomMay) || khbdIdKeHoach == null)
                    return false;
                var khbdlist = DataProvider.Ins.DB.KHBaoDuong.Where(x => x.IdKHBaoduong == khbdIdKeHoach);
                if (khbdlist == null || khbdlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var suakhbd = DataProvider.Ins.DB.KHBaoDuong.Where(x => x.IdKHBaoduong == khbdIdKeHoach).SingleOrDefault();
                suakhbd.NgayDuKien = khbdNgayDuKien;
                suakhbd.IdNhomMay = khbdIdNhomMay;
                DataProvider.Ins.DB.SaveChanges();
                LoadKeHoachBaoDuong();

            });

            deletecommandkhbd = new RelayCommand<object>((p) =>
            {
                if (khbdNgayDuKien == null || string.IsNullOrEmpty(khbdIdNhomMay) || khbdIdKeHoach == null)
                    return false;
                var khbdlist = DataProvider.Ins.DB.KHBaoDuong.Where(x => x.IdKHBaoduong == khbdIdKeHoach);
                if (khbdlist == null || khbdlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var kehoachbaoduong = DataProvider.Ins.DB.KHBaoDuong;
                foreach (var item in kehoachbaoduong)
                {
                    if (item.IdKHBaoduong == khbdIdKeHoach)
                    {
                        kehoachbaoduong.Remove(item);
                    }
                }
                DataProvider.Ins.DB.SaveChanges();
                LoadKeHoachBaoDuong();
            });

            Clearkhbd = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                clearKeHoachBaoDuong();
            });

            //Command Bảo dưỡng
            addcommandbd = new RelayCommand<object>((p) =>
            {
                if (bdIdKhBaoDuong == null || string.IsNullOrEmpty(bdMaMay) || bdNgay == null || string.IsNullOrEmpty(bdTinhTrang))
                    return false;
                var bdlist = DataProvider.Ins.DB.BaoDuong.Where(x => x.IdBaoduong == bdIdBaoDuong);
                if (bdlist == null || bdlist.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                var thembd = new BaoDuong() {  IdKHBaoDuong = bdIdKhBaoDuong, Ngay = bdNgay, MaMay = bdMaMay, TinhTrang = bdTinhTrang };

                DataProvider.Ins.DB.BaoDuong.Add(thembd);
                DataProvider.Ins.DB.SaveChanges();
                LoadBaoDuong();
            });

            editcommandbd = new RelayCommand<object>((p) =>
            {
                if (bdIdKhBaoDuong == null || string.IsNullOrEmpty(bdMaMay) || bdNgay == null || string.IsNullOrEmpty(bdTinhTrang) || bdIdBaoDuong == null)
                    return false;
                var bdlist = DataProvider.Ins.DB.BaoDuong.Where(x => x.IdBaoduong == bdIdBaoDuong);
                if (bdlist == null || bdlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var suabd = DataProvider.Ins.DB.BaoDuong.Where(x => x.IdBaoduong == bdIdBaoDuong).SingleOrDefault();
                suabd.IdKHBaoDuong = bdIdKhBaoDuong;
                suabd.MaMay = bdMaMay;
                suabd.Ngay = bdNgay;
                suabd.TinhTrang = bdTinhTrang;
                DataProvider.Ins.DB.SaveChanges();
                LoadBaoDuong();

            });

            deletecommandbd = new RelayCommand<object>((p) =>
            {
                if (bdIdKhBaoDuong == null || string.IsNullOrEmpty(bdMaMay) || bdNgay == null || string.IsNullOrEmpty(bdTinhTrang) || bdIdBaoDuong == null)
                    return false;
                var bdlist = DataProvider.Ins.DB.BaoDuong.Where(x => x.IdBaoduong == bdIdBaoDuong);
                if (bdlist == null || bdlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var baoduong = DataProvider.Ins.DB.BaoDuong;
                foreach (var item in baoduong)
                {
                    if (item.IdBaoduong == bdIdBaoDuong)
                    {
                        baoduong.Remove(item);
                    }
                }
                DataProvider.Ins.DB.SaveChanges();
                LoadBaoDuong();
            });

            Clearbd = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                clearBaoDuong();
            });

            //Command Bảo trì
            addcommandbt = new RelayCommand<object>((p) =>
            {
                if (btNgay == null || string.IsNullOrEmpty(btMaMay) || string.IsNullOrEmpty(btTinhTrang) || string.IsNullOrEmpty(btXuLy) )
                    return false;
                var btlist = DataProvider.Ins.DB.BaoTri.Where(x => x.IdBaotri == btIdBaoTri);
                if (btlist == null || btlist.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                var thembt = new BaoTri() { MaMay = btMaMay, Ngay = btNgay, TinhTrang = btTinhTrang, XuLy = btXuLy };

                DataProvider.Ins.DB.BaoTri.Add(thembt);
                DataProvider.Ins.DB.SaveChanges();
                LoadBaoTri();
            });

            editcommandbt = new RelayCommand<object>((p) =>
            {
                if (btNgay == null || string.IsNullOrEmpty(btMaMay) || string.IsNullOrEmpty(btTinhTrang) || string.IsNullOrEmpty(btXuLy) || btIdBaoTri == null)
                    return false;
                var btlist = DataProvider.Ins.DB.BaoTri.Where(x => x.IdBaotri == btIdBaoTri);
                if (btlist == null || btlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var suabt = DataProvider.Ins.DB.BaoTri.Where(x => x.IdBaotri == btIdBaoTri).SingleOrDefault();
                suabt.MaMay = btMaMay;
                suabt.Ngay = btNgay;
                suabt.TinhTrang = btTinhTrang;
                suabt.XuLy = btXuLy;
                DataProvider.Ins.DB.SaveChanges();
                LoadBaoTri();

            });

            deletecommandbt = new RelayCommand<object>((p) =>
            {
                if (btNgay == null || string.IsNullOrEmpty(btMaMay) || string.IsNullOrEmpty(btTinhTrang) || string.IsNullOrEmpty(btXuLy) || btIdBaoTri == null)
                    return false;
                var btlist = DataProvider.Ins.DB.BaoTri.Where(x => x.IdBaotri == btIdBaoTri);
                if (btlist == null || btlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var baotri = DataProvider.Ins.DB.BaoTri;
                foreach (var item in baotri)
                {
                    if (item.IdBaotri == btIdBaoTri)
                    {
                        baotri.Remove(item);
                    }
                }
                DataProvider.Ins.DB.SaveChanges();
                LoadBaoTri();
            });

            Clearbt = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                clearBaoTri();
            });

        }

        void LoadNhomMay()
        {
            NhomMayList = new ObservableCollection<NhomMay>(DataProvider.Ins.DB.NhomMay);
            BoPhanList = new ObservableCollection<BoPhan>(DataProvider.Ins.DB.BoPhan);
        }

        void clearNhomMay()
        {
            nmIDNhomMay = null;
            nmDisplayName = null;
            nmMaBp = null;
        }

        void LoadTaiSanCoDinh()
        { 
            TaiSanCoDinhList = new ObservableCollection<TaiSanCoDinh>(DataProvider.Ins.DB.TaiSanCoDinh);
            BoPhanList = new ObservableCollection<BoPhan>(DataProvider.Ins.DB.BoPhan);
            NhomMayList = new ObservableCollection<NhomMay>(DataProvider.Ins.DB.NhomMay);
        }

        void clearTaiSanCoDinh()
        {
            tscdMaMay = null;
            tscdDisplayName = null;
            tscdMaBp = null;
            tscdViTri = null;
            tscdIDNhomMay = null;
            tscdTinhTrang = null;
        }

        void LoadKeHoachBaoDuong()
        {
            KHBaoDuongList = new ObservableCollection<KHBaoDuong>(DataProvider.Ins.DB.KHBaoDuong);
            NhomMayList = new ObservableCollection<NhomMay>(DataProvider.Ins.DB.NhomMay);
        }

        void clearKeHoachBaoDuong()
        {
            khbdIdKeHoach = null;
            khbdNgayDuKien = null;
            khbdIdNhomMay = null;
        }

        void LoadBaoDuong()
        {
            BaoDuongList = new ObservableCollection<BaoDuong>(DataProvider.Ins.DB.BaoDuong);
            KHBaoDuongList = new ObservableCollection<KHBaoDuong>(DataProvider.Ins.DB.KHBaoDuong);
                           
            
        }

        void clearBaoDuong()
        {
            bdIdBaoDuong = null;
            bdIdKhBaoDuong = null;
            bdMaMay = null;
            bdNgay = null;
            bdTinhTrang = null;
        }

        void LoadBaoTri()
        {
            BaoTriList = new ObservableCollection<BaoTri>(DataProvider.Ins.DB.BaoTri);
            TaiSanCoDinhList = new ObservableCollection<TaiSanCoDinh>(DataProvider.Ins.DB.TaiSanCoDinh);
        }

        void clearBaoTri()
        {
            btIdBaoTri = null;
            btMaMay = null;
            btNgay = null;
            btTinhTrang = null;
            btXuLy = null;
        }
    }
}
