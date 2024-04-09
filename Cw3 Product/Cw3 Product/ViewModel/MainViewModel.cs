using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using Cw3_Product.Model;
using Cw3_Product.UserControlMenu;

namespace Cw3_Product.ViewModel
{
    public class MainViewModel : BaseViewModel
    {

        public bool Isloaded { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand reloginCommand { get; set; }
        public ICommand Thoat { get; set; }
        public ICommand leftdrawopen { get; set; }
        public ICommand leftdrawclose { get; set; }
        public ICommand Homedata { get; set; }
        public ICommand Kehoachdata { get; set; }
        public ICommand Sanxuatdata { get; set; }
        public ICommand Khotdata { get; set; }
        public ICommand Bomdata { get; set; }
        public ICommand Baotridata { get; set; }
        public ICommand Nhansudata { get; set; }
        public ICommand Qcdata { get; set; }
        public ICommand testdata { get; set; }




        public UserControl uc { get; set; }

        private string _txbTitle;
        public string txbTitle { get => _txbTitle; set { _txbTitle = value; OnPropertyChanged(); } }

        private bool _menuchecked;
        public bool menuchecked { get => _menuchecked; set { _menuchecked = value; OnPropertyChanged(); } }

        private bool _leftstace;
        public bool leftstace { get => _leftstace; set { _leftstace = value; OnPropertyChanged(); } }

        private string _Userlogin;
        public string Userlogin { get => _Userlogin; set { _Userlogin = value; OnPropertyChanged(); } }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        private int _Userlevel;
        public int Userlevel { get => _Userlevel; set { _Userlevel = value; OnPropertyChanged(); } }


        // mọi thứ xử lý sẽ nằm trong này
        public MainViewModel()
        {
            txbTitle = "Phần mềm quản lý sản xuất CW3";


            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                if (p == null)
                    return;

                p.Hide();
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

                if (loginWindow.DataContext == null)
                    return;

                var loginVM = loginWindow.DataContext as LoginViewModel;

                if (loginVM.IsLogin)
                {
                    p.Show();
                    Userlogin = Cw3_Product.Properties.Settings.Default.account;
                    DisplayName = DataProvider.Ins.DB.Users.Where(x => x.UserName == Userlogin).First().DisplayName;
                    Userlevel = DataProvider.Ins.DB.Users.Where(x => x.UserName == Userlogin).First().IdRole;
                }
                else
                {
                    p.Close();
                }
                if (leftstace == false) menuchecked = false;
            });

            reloginCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                //Isloaded = true;
                //if (p == null)
                //    return;
                //p.Hide();


                //LoginWindow loginWindow = new LoginWindow();
                //loginWindow.ShowDialog();

                //if (loginWindow.DataContext == null)
                //    return;

                //var loginVM = loginWindow.DataContext as LoginViewModel;

                //if (loginVM.IsLogin)
                //{
                //    p.Show();
                //    p.UpdateLayout();
                //    Userlogin = Cw3_Product.Properties.Settings.Default.account;
                //    DisplayName = DataProvider.Ins.DB.Users.Where(x => x.UserName == Userlogin).First().DisplayName;
                //    Userlevel = DataProvider.Ins.DB.Users.Where(x => x.UserName == Userlogin).First().IdRole;
                //}
                //else
                //{
                //    p.Close();
                //}
                //if (leftstace == false) menuchecked = false;

                Application.Current.Shutdown();
                System.Windows.Forms.Application.Restart();

            });

            Thoat = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                var check = MessageBox.Show("Bạn chắc chắn muốn thoát?","Quit app",MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (check == MessageBoxResult.Yes) { Application.Current.Shutdown(); } else {}
            });

            leftdrawopen = new RelayCommand<DrawerHost>((p) => { return true; }, (p) =>
            {
                p.IsLeftDrawerOpen = true;
                menuchecked = true;
            });

            leftdrawclose = new RelayCommand<DrawerHost>((p) => { return true; }, (p) =>
            {
                p.IsLeftDrawerOpen = false;
                menuchecked = false;
            });

            Homedata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new HomeUC(); p.Children.Add(uc);
                txbTitle = "Phần mềm quản lý sản xuất CW3";

                leftstace = false;
                if (leftstace == false) menuchecked = false;

            });

            Kehoachdata = new RelayCommand<Grid>((p) => 
            {
                return true;
            }, (p) =>
            {
                p.Children.Clear(); uc = new KeHoachUC(); p.Children.Add(uc);
                txbTitle = "";
                leftstace = false;
                menuchecked = false;
            });

            Sanxuatdata = new RelayCommand<Grid>((p) => 
            { 
                if ((Userlevel > 0 && Userlevel < 60) || (Userlevel >= 70 && Userlevel < 80))
                return true; 

                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new SanXuatUC(); p.Children.Add(uc);
                txbTitle = "";
                leftstace = false;
                menuchecked = false;
            });

            Khotdata = new RelayCommand<Grid>((p) => 
            {
                if ((Userlevel > 0 && Userlevel < 10) || (Userlevel >= 70 && Userlevel < 80))
                    return true;

                else return false;
            }, (p) =>
            {
                try
                {
                    p.Children.Clear(); uc = new KhoUC(); p.Children.Add(uc);
                    txbTitle = "";
                    leftstace = false;
                    menuchecked = false;
                }
                catch (Exception)
                {
                }
            });

            Bomdata = new RelayCommand<Grid>((p) => { return true; }, (p) =>
            {
                p.Children.Clear(); uc = new BOMUC(); p.Children.Add(uc);
                txbTitle = "";
                leftstace = false;
                menuchecked = false;
            });

            Baotridata = new RelayCommand<Grid>((p) => 
            {
                if ((Userlevel > 0 && Userlevel < 10) || (Userlevel >= 60 && Userlevel < 70))
                    return true;

                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new BaoTriUC(); p.Children.Add(uc);
                txbTitle = "";
                leftstace = false;
                menuchecked = false;
            });

            Nhansudata = new RelayCommand<Grid>((p) => 
            {
                if ((Userlevel > 0 && Userlevel < 10))
                    return true;

                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new NhanSuUC(); p.Children.Add(uc);
                txbTitle = "";
                leftstace = false;
                menuchecked = false;
            });

            Qcdata = new RelayCommand<Grid>((p) =>
            {
                if ((Userlevel > 0 && Userlevel < 10) || (Userlevel >= 80 && Userlevel < 90))
                    return true;

                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new QCUC(); p.Children.Add(uc);
                txbTitle = "";
                leftstace = false;
                menuchecked = false;
            });

            testdata = new RelayCommand<Grid>((p) =>
            {
                if (Userlevel == 1 || Userlevel == 2)
                    return true;

                else return false;
            }, (p) =>
            {
                p.Children.Clear(); uc = new testUC(); p.Children.Add(uc);
                txbTitle = "";
                leftstace = false;
                menuchecked = false;
            });
        }
    }
}
