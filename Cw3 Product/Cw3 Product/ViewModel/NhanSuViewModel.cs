using Cw3_Product.Model;
using Cw3_Product.UserControlBOM;
using Cw3_Product.UserControlNhanSu;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Cw3_Product.ViewModel
{
    public class NhanSuViewModel : BaseViewModel
    {

        //Khai báo list hiển thị Bộ phân
        private ObservableCollection<BoPhan> _BoPhanList;
        public ObservableCollection<BoPhan> BoPhanList { get => _BoPhanList; set { _BoPhanList = value; OnPropertyChanged(); } }

        //Khai báo list hiển thị Nhân sự
        private ObservableCollection<NhanSu> _NhanSuList;
        public ObservableCollection<NhanSu> NhanSuList { get => _NhanSuList; set { _NhanSuList = value; OnPropertyChanged(); } }


        //Khai báo Usercontrol
        public UserControl uc { get; set; }


        //khai báo hiển thị địa chỉ
        private string _txbTitle1;
        public string txbTitle1 { get => _txbTitle1; set { _txbTitle1 = value; OnPropertyChanged(); } }

        private string _txbTitle2;
        public string txbTitle2 { get => _txbTitle2; set { _txbTitle2 = value; OnPropertyChanged(); } }

        private string _txbTitle3;
        public string txbTitle3 { get => _txbTitle3; set { _txbTitle3 = value; OnPropertyChanged(); } }


        //Khai báo hiển thị UC con
        public ICommand Homedata { get; set; }
        public ICommand BoPhandata { get; set; }
        public ICommand NhanSudata { get; set; }
        public ICommand BieuDoNhanSudata { get; set; }


        //Khai báo command thêm sửa xóa Bộ phận
        public ICommand addcommandbp { get; set; }
        public ICommand editcommandbp { get; set; }
        public ICommand deletecommandbp { get; set; }
        public ICommand Clearbp { get; set; }

        //Khai báo command thêm sửa xóa Nhân sự
        public ICommand addcommandns { get; set; }
        public ICommand editcommandns { get; set; }
        public ICommand deletecommandns { get; set; }
        public ICommand Clearns { get; set; }
        public ICommand ChiTietns { get; set; }


        //Khai báo biến Bộ phận
        private string _bpMaBp;
        public string bpMaBp { get => _bpMaBp; set { _bpMaBp = value; OnPropertyChanged(); } }

        private string _bpTenBp;
        public string bpTenBp { get => _bpTenBp; set { _bpTenBp = value; OnPropertyChanged(); } }

        private Model.BoPhan _SelectedItembp;
        public Model.BoPhan SelectedItembp
        {
            get => _SelectedItembp; set
            {
                _SelectedItembp = value; OnPropertyChanged(); if (_SelectedItembp != null)
                {
                    bpMaBp = SelectedItembp.MaBp;
                    bpTenBp = SelectedItembp.TenBp;
                }
            }
        }


        //Khai báo biến Nhân sự

        private string _nsMSNV;
        public string nsMSNV { get => _nsMSNV; set { _nsMSNV = value; OnPropertyChanged(); } }

        private string _nsTenNv;
        public string nsTenNv { get => _nsTenNv; set { _nsTenNv = value; OnPropertyChanged(); } }

        private DateTime? _nsNgaySinh;
        public DateTime? nsNgaySinh { get => _nsNgaySinh; set { _nsNgaySinh = value; OnPropertyChanged(); } }

        private string _nsQueQuan;
        public string nsQueQuan { get => _nsQueQuan; set { _nsQueQuan = value; OnPropertyChanged(); } }

        private string _nsPhone;
        public string nsPhone { get => _nsPhone; set { _nsPhone = value; OnPropertyChanged(); } }

        private string _nsMaBp;
        public string nsMaBp { get => _nsMaBp; set { _nsMaBp = value; OnPropertyChanged(); } }

        private string _nsChucVu;
        public string nsChucVu { get => _nsChucVu; set { _nsChucVu = value; OnPropertyChanged(); } }

        private string _nsTinhTrang;
        public string nsTinhTrang { get => _nsTinhTrang; set { _nsTinhTrang = value; OnPropertyChanged(); } }

        private string _nsBoPhan;
        public string nsBoPhan { get => _nsBoPhan; set { _nsBoPhan = value; OnPropertyChanged(); } }

        private string _nsThamNien;
        public string nsThamNien { get => _nsThamNien; set { _nsThamNien = value; OnPropertyChanged(); } }

        private BitmapImage _bitmap;
        public BitmapImage bitmap { get => _bitmap; set { _bitmap = value; OnPropertyChanged(); } }

        private Model.NhanSu _SelectedItemns;
        public Model.NhanSu SelectedItemns
        {
            get => _SelectedItemns; set
            {
                _SelectedItemns = value; OnPropertyChanged(); if (_SelectedItemns != null)
                {
                    nsMSNV = SelectedItemns.MSNV;
                    nsTenNv = SelectedItemns.NhanVien;
                    nsNgaySinh = SelectedItemns.NgaySinh;
                    nsQueQuan = SelectedItemns.QueQuan;
                    nsPhone = SelectedItemns.Phone;
                    nsMaBp = SelectedItemns.MaBp;
                    nsBoPhan = DataProvider.Ins.DB.BoPhan.Where(x => x.MaBp == SelectedItemns.MaBp).First().TenBp;
                    nsChucVu = SelectedItemns.ChucVu;
                    nsTinhTrang = SelectedItemns.TinhTrang;

                    string year = "20" + SelectedItemns.MSNV.Substring(0, 2);
                    string month = SelectedItemns.MSNV.Substring(2, 2);
                    string day = SelectedItemns.MSNV.Substring(4, 2);
                    int nam = 0;
                    DateTime d1 = DateTime.Today;
                    if ((d1.Month < Int32.Parse(month)) || ((d1.Month == Int32.Parse(month)) && (d1.Day < Int32.Parse(day))))
                    {
                        nam = d1.Year - (Int32.Parse(year) + 1);
                        year = (Int32.Parse(year) + nam).ToString();
                    }
                    else
                    {
                        nam = d1.Year - Int32.Parse(year);
                        year = (Int32.Parse(year) + nam).ToString();
                    }

                    DateTime d2 = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));
                    

                    TimeSpan t = d1 - d2;
                    double NrOfDays = t.TotalDays;  
                    //Int32.Parse

                    nsThamNien = nam + " năm " + NrOfDays + " ngày làm việc";
                }
            }
        }


        public NhanSuViewModel() 
        {
            txbTitle1 = ""; txbTitle2 = ""; txbTitle3 = "";

            MainWindow mainwindow = new MainWindow();
            var mainVM = mainwindow.DataContext as MainViewModel;

            int level = mainVM.Userlevel;
            mainwindow.Close();


            Homedata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new NhanSuHomeUC(); p.Children.Add(uc);
                txbTitle1 = ""; txbTitle2 = ""; txbTitle3 = "";
            });

            BoPhandata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new BoPhanUC(); p.Children.Add(uc);
                txbTitle1 = "Nhân sự / "; txbTitle2 = "Tổng quan / "; txbTitle3 = "Bộ Phận";
                LoadBoPhan();
            });

            NhanSudata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                if (level > 2)
                {
                    MessageBox.Show("Bạn không thể truy cập vào mục này!");
                }
                else
                {
                    p.Children.Clear(); uc = new DSNhanSuUC(); p.Children.Add(uc);
                    txbTitle1 = "Nhân sự / "; txbTitle2 = "Tổng quan / "; txbTitle3 = "Nhân Sự";
                    LoadNhanSu();
                }

            });

            BieuDoNhanSudata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                if (level > 2)
                {
                    MessageBox.Show("Bạn không thể truy cập vào mục này!");
                }
                else
                {
                    p.Children.Clear(); uc = new BieuDoNhanSu(); p.Children.Add(uc);
                    txbTitle1 = "Nhân sự / "; txbTitle2 = "Tổng quan / "; txbTitle3 = "Biểu đồ nhân sự";
                    
                }

            });




            //command Bộ Phận
            addcommandbp = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(bpMaBp) || string.IsNullOrEmpty(bpTenBp))
                    return false;
                var bplist = DataProvider.Ins.DB.BoPhan.Where(x => x.MaBp == bpMaBp);
                if (bplist == null || bplist.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                var thembp = new BoPhan() { MaBp = bpMaBp, TenBp = bpTenBp};

                DataProvider.Ins.DB.BoPhan.Add(thembp);
                DataProvider.Ins.DB.SaveChanges();
                LoadBoPhan();
            });

            editcommandbp = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(bpMaBp) || string.IsNullOrEmpty(bpTenBp))
                    return false;
                var MaBplist = DataProvider.Ins.DB.BoPhan.Where(x => x.MaBp == bpMaBp);
                if (MaBplist == null || MaBplist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var suabp = DataProvider.Ins.DB.BoPhan.Where(x => x.MaBp == bpMaBp).SingleOrDefault();
                suabp.TenBp = bpTenBp;
                DataProvider.Ins.DB.SaveChanges();
                LoadBoPhan();

            });

            deletecommandbp = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(bpMaBp) || string.IsNullOrEmpty(bpTenBp))
                    return false;
                var MaBplist = DataProvider.Ins.DB.BoPhan.Where(x => x.MaBp == bpMaBp);
                if (MaBplist == null || MaBplist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var bophan = DataProvider.Ins.DB.BoPhan;
                foreach (var item in bophan)
                {
                    if (item.MaBp == bpMaBp)
                    {
                        bophan.Remove(item);
                    }
                }
                DataProvider.Ins.DB.SaveChanges();
                LoadBoPhan();
            });

            Clearbp = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                clearBoPhan();
            });


            //Command Nhân sự
            addcommandns = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(nsMSNV) || string.IsNullOrEmpty(nsTenNv) || string.IsNullOrEmpty(nsMaBp))
                    return false;
                var nslist = DataProvider.Ins.DB.NhanSu.Where(x => x.MSNV == nsMSNV);
                if (nslist == null || nslist.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                var themns = new NhanSu() { MSNV = nsMSNV, NhanVien = nsTenNv, NgaySinh = nsNgaySinh, QueQuan = nsQueQuan, Phone = nsPhone, MaBp = nsMaBp };

                DataProvider.Ins.DB.NhanSu.Add(themns);
                DataProvider.Ins.DB.SaveChanges();
                LoadNhanSu();
            });

            editcommandns = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(nsMSNV) || string.IsNullOrEmpty(nsTenNv) || string.IsNullOrEmpty(nsMaBp))
                    return false;
                var nslist = DataProvider.Ins.DB.NhanSu.Where(x => x.MSNV == nsMSNV);
                if (nslist == null || nslist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var suans = DataProvider.Ins.DB.NhanSu.Where(x => x.MSNV == nsMSNV).SingleOrDefault();
                suans.NhanVien = nsTenNv;
                suans.NgaySinh = nsNgaySinh;
                suans.QueQuan = nsQueQuan;
                suans.Phone = nsPhone;
                suans.MaBp = nsMaBp;
                DataProvider.Ins.DB.SaveChanges();
                LoadNhanSu();

            });

            deletecommandns = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(nsMSNV) || string.IsNullOrEmpty(nsTenNv) || string.IsNullOrEmpty(nsMaBp))
                    return false;
                var nslist = DataProvider.Ins.DB.NhanSu.Where(x => x.MSNV == nsMSNV);
                if (nslist == null || nslist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var nhansu = DataProvider.Ins.DB.NhanSu;
                foreach (var item in nhansu)
                {
                    if (item.MSNV == nsMSNV)
                    {
                        nhansu.Remove(item);
                    }
                }
                DataProvider.Ins.DB.SaveChanges();
                LoadNhanSu();
            });

            Clearns = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                clearNhanSu();
            });

            ChiTietns = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(nsMSNV) || string.IsNullOrEmpty(nsTenNv) || string.IsNullOrEmpty(nsMaBp))
                    return false;
                var nslist = DataProvider.Ins.DB.NhanSu.Where(x => x.MSNV == nsMSNV);
                if (nslist == null || nslist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                bitmap = LoadImage(DataProvider.Ins.DB.NhanSu.Where(x => x.MSNV == nsMSNV).FirstOrDefault().HinhAnh);
                NhanSuChiTietWD nhanSuChiTietWD = new NhanSuChiTietWD();
                nhanSuChiTietWD.ShowDialog();
                //Image image = new Image { Width = 200, Height = 200, Stretch = Stretch.Uniform };                
                //image.Source = bitmap;
            });

        }


        void LoadBoPhan()
        {
            BoPhanList = new ObservableCollection<BoPhan>(DataProvider.Ins.DB.BoPhan);
        }

        void LoadNhanSu()
        {
            NhanSuList = new ObservableCollection<NhanSu>(DataProvider.Ins.DB.NhanSu);
            BoPhanList = new ObservableCollection<BoPhan>(DataProvider.Ins.DB.BoPhan);
        }

        void clearBoPhan()
        {
            bpMaBp = null;
            bpTenBp = null;
        }

        void clearNhanSu()
        {
            nsMSNV = null;
            nsTenNv = null;
            nsNgaySinh = null;
            nsQueQuan = null;
            nsPhone = null;
            nsMaBp = null;
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

    }
}
