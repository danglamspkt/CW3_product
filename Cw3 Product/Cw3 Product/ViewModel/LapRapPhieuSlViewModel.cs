using Cw3_Product.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using MaterialDesignColors.Recommended;
using MaterialDesignColors.ColorManipulation;
using MahApps.Metro;
using MaterialDesignThemes.MahApps;
using MahApps.Metro.Markup;
using ControlzEx.Standard;
using System.Net;

namespace Cw3_Product.ViewModel
{

    public class LapRapPhieuSlViewModel : BaseViewModel
    {
        //-------------------------Khai báo list hiển thị BOM TP--------------------------------------------------
        private ObservableCollection<BomTp> _MaTpList;
        public ObservableCollection<BomTp> MaTpList { get => _MaTpList; set { _MaTpList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị BOM TP--------------------------------------------------
        private ObservableCollection<BomLk> _SoHoaList;
        public ObservableCollection<BomLk> SoHoaList { get => _SoHoaList; set { _SoHoaList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Đơn vị--------------------------------------------------
        private ObservableCollection<Unit> _donvilist;
        public ObservableCollection<Unit> donvilist { get => _donvilist; set { _donvilist = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Đơn hàng thành phẩm--------------------------------------------------
        private ObservableCollection<DonHangTp> _SoLoList;
        public ObservableCollection<DonHangTp> SoLoList { get => _SoLoList; set { _SoLoList = value; OnPropertyChanged(); } }

        private DateTime? _LrSlNgay;
        public DateTime? LrSlNgay { get => _LrSlNgay; set { _LrSlNgay = value; OnPropertyChanged(); } }

        private string _LrSlCa;
        public string LrSlCa { get => _LrSlCa; set { _LrSlCa = value; OnPropertyChanged(); } }

        private string _LrSlChuyenLr;
        public string LrSlChuyenLr { get => _LrSlChuyenLr; set { _LrSlChuyenLr = value; OnPropertyChanged(); } }

        private string _LrSlId;
        public string LrSlId { get => _LrSlId; set { _LrSlId = value; OnPropertyChanged(); } }

        public ICommand ThemMaSanLuong { get; set; }
        public ICommand XoaMaSanLuong { get; set; }
        public ICommand ThemMaPhe { get; set; }
        public ICommand XoaMaPhe { get; set; }
        public ICommand TaoDon { get; set; }
        public ICommand XacNhan { get; set; }
        public ICommand HuyDon { get; set; }
        public ICommand LrSldatechange { get; set; }

        List<TextBox> LrSlSTT = new List<TextBox>();
        List<ComboBox> LrSlSoLo = new List<ComboBox>();
        List<ComboBox> LrSlMaTp = new List<ComboBox>();
        List<ComboBox> LrSlDonVi = new List<ComboBox>();
        List<TextBox> LrSlSoluong = new List<TextBox>();
        List<TextBox> LrSlPhe = new List<TextBox>();
        int LrSlStt = 0;

        List<TextBox> LrPheSTT = new List<TextBox>();
        List<ComboBox> LrPheSoLo = new List<ComboBox>();
        List<ComboBox> LrPheSoHoa = new List<ComboBox>();
        List<TextBox> LrPhePhe = new List<TextBox>();
        List<TextBox> LrPheNguyenNhan = new List<TextBox>();
        int LrPheStt = 0;

        private bool _FlagNew;
        public bool FlagNew { get => _FlagNew; set { _FlagNew = value; OnPropertyChanged(); } }
        

        public LapRapPhieuSlViewModel()
        {
            
            FlagNew = false;

            TaoDon = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                LrSlNgay = DateTime.Today;
                LrSlCa = "Ngày";
                LrSlChuyenLr = "Lr1";
                LaprapTaoidnhaplieu();
                SoLoList = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp.Where(u => u.TinhTrang == "Sản xuất"));
                donvilist = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
                SoHoaList = new ObservableCollection<BomLk>(DataProvider.Ins.DB.BomLk);
                MaTpList = new ObservableCollection<BomTp>(DataProvider.Ins.DB.BomTp);
                
                FlagNew = true;

            });

            XacNhan = new RelayCommand<stackpanels>((p) =>
            {
                if (FlagNew != true)
                    return false;

                return true;
            }, (p) =>
            {

                var check = MessageBox.Show("Bạn chắc chắn muốn xác nhận đơn hàng?", "Xác nhận đơn", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (check == MessageBoxResult.OK)
                {
                    
                    try
                    {
                        LaprapTaoidnhaplieu();
                        LrSanXuat lrsl = new LrSanXuat();
                        if (LrSlStt > 0) for (int i = 0; i < LrSlStt; i++)
                            {
                                lrsl.Ngay = LrSlNgay;
                                lrsl.ChuyenLr = LrSlChuyenLr;
                                lrsl.CaLv = LrSlCa;
                                lrsl.MaPhieu = LrSlId;
                                lrsl.SoLo = LrSlSoLo[i].Text;
                                lrsl.MaTp = LrSlMaTp[i].Text;
                                lrsl.SoLuong = Int32.Parse(LrSlSoluong[i].Text);
                                lrsl.Phe = Int32.Parse(LrSlPhe[i].Text);
                                lrsl.IdU = LrSlDonVi[i].Text;
                                lrsl.UserName = Cw3_Product.Properties.Settings.Default.account;

                                DataProvider.Ins.DB.LrSanXuat.Add(lrsl);
                                DataProvider.Ins.DB.SaveChanges();
                            }

                        DKSanXuat dksl = new DKSanXuat();

                        if (LrPheStt > 0) for (int j = 0; j < LrPheStt; j++)
                            {
                                dksl.Ngay = LrSlNgay;
                                dksl.NhanVien = LrSlChuyenLr;
                                dksl.CaLv = LrSlCa;
                                dksl.MaPhieu = LrSlId;
                                dksl.SoLo = LrPheSoLo[j].Text;
                                dksl.SoHoa = LrPheSoHoa[j].Text;
                                dksl.Phe = Int32.Parse(LrPhePhe[j].Text);
                                dksl.NguyenNhan = LrPheNguyenNhan[j].Text;
                                dksl.IdU = "pcs";
                                dksl.UserName = Cw3_Product.Properties.Settings.Default.account;

                                DataProvider.Ins.DB.DKSanXuat.Add(dksl);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                        p.Stack1.Children.Clear();
                        p.Stack2.Children.Clear();
                        LrSlSTT.Clear();
                        LrSlSoLo.Clear();
                        LrSlMaTp.Clear();
                        LrSlDonVi.Clear();
                        LrSlSoluong.Clear();
                        LrSlPhe.Clear();
                        LrSlStt = 0;
                        LrPheSTT.Clear();
                        LrPheSoLo.Clear();
                        LrPheSoHoa.Clear();
                        LrPhePhe.Clear();
                        LrPheNguyenNhan.Clear();
                        LrPheStt = 0;
                        ClearLapRapphieunhap();
                        FlagNew = false;
                    }
                    catch (Exception)
                    {
                        var a = DataProvider.Ins.DB.LrSanXuat.Where(x => x.MaPhieu == LrSlId);
                        while (a.Count() > 0)
                        {
                            DataProvider.Ins.DB.LrSanXuat.Remove(a.First());
                            DataProvider.Ins.DB.SaveChanges();
                            a = DataProvider.Ins.DB.LrSanXuat.Where(x => x.MaPhieu == LrSlId);
                        }
                        var b = DataProvider.Ins.DB.DKSanXuat.Where(x => x.MaPhieu == LrSlId);
                        while (b.Count() > 0)
                        {
                            DataProvider.Ins.DB.DKSanXuat.Remove(b.First());
                            DataProvider.Ins.DB.SaveChanges();
                            b = DataProvider.Ins.DB.DKSanXuat.Where(x => x.MaPhieu == LrSlId);
                        }
                        MessageBox.Show("Dữ liệu nhập bị lỗi!", "Dữ liệu nhập!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }


                    
                }
                else if (check == MessageBoxResult.Cancel)
                {

                }

            });

            HuyDon = new RelayCommand<stackpanels>((p) =>
            {
                if (FlagNew != true)
                    return false;

                return true;
            }, (p) =>
            {

                var check = MessageBox.Show("Bạn chắc chắn muốn hủy đơn hàng?", "Hủy đơn", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (check == MessageBoxResult.OK)
                {
                    p.Stack1.Children.Clear();
                    p.Stack2.Children.Clear();
                    LrSlSTT.Clear();
                    LrSlSoLo.Clear();
                    LrSlMaTp.Clear();
                    LrSlDonVi.Clear();
                    LrSlSoluong.Clear();
                    LrSlPhe.Clear();
                    LrSlStt = 0;
                    LrPheSTT.Clear();
                    LrPheSoLo.Clear();
                    LrPheSoHoa.Clear();
                    LrPhePhe.Clear();
                    LrPheNguyenNhan.Clear();
                    LrPheStt = 0;
                    ClearLapRapphieunhap();
                    FlagNew = false;
                }
                else if (check == MessageBoxResult.Cancel)
                {

                }

            });

            ThemMaSanLuong = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                LrSlStt++;
                StackPanel wrapPanel = new StackPanel();
                wrapPanel.Orientation = Orientation.Horizontal;
                wrapPanel.Margin = new Thickness(10, 5, 0, 5);

                TextBox textBox = new TextBox();
                textBox.IsReadOnly = true;
                textBox.Text = LrSlStt.ToString();
                textBox.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(textBox, "STT");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                textBox.Width = 70;
                textBox.Margin = new Thickness(5, 0, 15, 0);
                LrSlSTT.Insert(LrSlStt - 1, textBox);
                wrapPanel.Children.Add(LrSlSTT[LrSlStt - 1]);

                ComboBox comboBox = new ComboBox();
                comboBox.ItemsSource = SoLoList;
                comboBox.DisplayMemberPath = "SoLo";
                comboBox.Text = "";
                comboBox.IsEnabled = true;
                comboBox.VerticalAlignment = VerticalAlignment.Center;                
                MaterialDesignThemes.Wpf.HintAssist.SetHint(comboBox, "Số lô");
                comboBox.Width = 190;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(comboBox, 50);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(comboBox, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                comboBox.Margin = new Thickness(15, 0, 15, 0);
                comboBox.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged);
                LrSlSoLo.Insert(LrSlStt - 1, comboBox);
                wrapPanel.Children.Add(LrSlSoLo[LrSlStt - 1]);

                ComboBox comboBox2 = new ComboBox();
                comboBox2.ItemsSource = MaTpList;
                comboBox2.DisplayMemberPath = "MaTp";
                comboBox2.Text = "";
                comboBox2.IsEnabled = true;
                comboBox2.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(comboBox2, "Mã bánh xe");
                comboBox2.Width = 140;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(comboBox2, 20);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(comboBox2, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                comboBox2.Margin = new Thickness(15, 0, 15, 0);
                LrSlMaTp.Insert(LrSlStt - 1, comboBox2);
                wrapPanel.Children.Add(LrSlMaTp[LrSlStt - 1]);

                ComboBox comboBox3 = new ComboBox();
                comboBox3.ItemsSource = donvilist;
                comboBox3.DisplayMemberPath = "IdU";
                comboBox3.Text = "";
                comboBox3.IsEnabled = true;
                comboBox3.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(comboBox3, "Đơn vị");
                comboBox3.Width = 140;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(comboBox3, 10);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(comboBox3, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                comboBox3.Margin = new Thickness(15, 0, 15, 0);
                LrSlDonVi.Insert(LrSlStt - 1, comboBox3);
                wrapPanel.Children.Add(LrSlDonVi[LrSlStt - 1]);

                TextBox textBox2 = new TextBox();
                textBox2.Text = 0.ToString();
                textBox2.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(textBox2, "Số lượng");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                textBox2.Width = 120;
                textBox2.Margin = new Thickness(15, 0, 15, 0);
                LrSlSoluong.Insert(LrSlStt - 1, textBox2);
                wrapPanel.Children.Add(LrSlSoluong[LrSlStt - 1]);

                TextBox textBox3 = new TextBox();
                textBox3.Text = 0.ToString();
                textBox3.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(textBox3, "Phế");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                textBox3.Width = 120;
                textBox3.Margin = new Thickness(11, 0, 11, 0);
                LrSlPhe.Insert(LrSlStt - 1, textBox3);
                wrapPanel.Children.Add(LrSlPhe[LrSlStt - 1]);

                //MaterialDesignThemes.Wpf.PackIcon icon = new MaterialDesignThemes.Wpf.PackIcon();
                //icon.Height = 24;
                //icon.Width = 24;
                //icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.DeleteOutline;
                //icon.Foreground = Brushes.Black;

                
                p.Children.Add(wrapPanel);

            });

            XoaMaSanLuong = new RelayCommand<StackPanel>((p) => { if (LrSlStt == 0) return false; else return true; }, (p) =>
            {
                var a = LrSlStt - 1;
                p.Children.RemoveAt(a);
                LrSlSTT.RemoveAt(a);
                LrSlSoLo.RemoveAt(a);
                LrSlMaTp.RemoveAt(a);
                LrSlDonVi.RemoveAt(a);
                LrSlSoluong.RemoveAt(a);
                LrSlPhe.RemoveAt(a);
                LrSlStt -= 1;

            });

            ThemMaPhe = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                LrPheStt++;
                StackPanel wrapPanels = new StackPanel();
                wrapPanels.Orientation = Orientation.Horizontal;
                wrapPanels.Margin = new Thickness(10, 5, 0, 5);

                TextBox textBox4 = new TextBox();
                textBox4.IsReadOnly = true;
                textBox4.Text = LrPheStt.ToString();
                textBox4.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(textBox4, "STT");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                textBox4.Width = 70;
                textBox4.Margin = new Thickness(5, 0, 15, 0);
                LrPheSTT.Insert(LrPheStt - 1, textBox4);
                wrapPanels.Children.Add(LrPheSTT[LrPheStt - 1]);

                ComboBox comboBox4 = new ComboBox();
                comboBox4.ItemsSource = SoLoList;
                comboBox4.DisplayMemberPath = "SoLo";
                comboBox4.Text = "";
                comboBox4.IsEnabled = true;
                comboBox4.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(comboBox4, "Số lô");
                comboBox4.Width = 190;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(comboBox4, 50);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(comboBox4, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                comboBox4.Margin = new Thickness(15, 0, 15, 0);
                LrPheSoLo.Insert(LrPheStt - 1, comboBox4);
                wrapPanels.Children.Add(LrPheSoLo[LrPheStt - 1]);

                ComboBox comboBox5 = new ComboBox();
                comboBox5.ItemsSource = SoHoaList;
                comboBox5.DisplayMemberPath = "SoHoa";
                comboBox5.Text = "";
                comboBox5.IsEnabled = true;
                comboBox5.IsEditable = true;
                comboBox5.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(comboBox5, "Số Họa");
                comboBox5.Width = 140;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(comboBox5, 20);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(comboBox5, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                comboBox5.Margin = new Thickness(15, 0, 15, 0);
                LrPheSoHoa.Insert(LrPheStt - 1, comboBox5);
                wrapPanels.Children.Add(LrPheSoHoa[LrPheStt - 1]);

                TextBox textBox5 = new TextBox();
                textBox5.Text = 0.ToString();
                textBox5.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(textBox5, "Phế");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                textBox5.Width = 120;
                textBox5.Margin = new Thickness(15, 0, 15, 0);
                LrPhePhe.Insert(LrPheStt - 1, textBox5);
                wrapPanels.Children.Add(LrPhePhe[LrPheStt - 1]);

                TextBox textBox6 = new TextBox();
                textBox6.Text = "";
                textBox6.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(textBox6, "Nguyên nhân");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                textBox6.Width = 240;
                textBox6.Margin = new Thickness(11, 0, 11, 0);
                LrPheNguyenNhan.Insert(LrPheStt - 1, textBox6);
                wrapPanels.Children.Add(LrPheNguyenNhan[LrPheStt - 1]);


                p.Children.Add(wrapPanels);

            });

            XoaMaPhe = new RelayCommand<StackPanel>((p) => { if (LrPheStt == 0) return false; else return true; }, (p) =>
            {
                var a = LrPheStt - 1;
                p.Children.RemoveAt(a);
                LrPheSTT.RemoveAt(a);
                LrPheSoLo.RemoveAt(a);
                LrPheSoHoa.RemoveAt(a);
                LrPhePhe.RemoveAt(a);
                LrPheNguyenNhan.RemoveAt(a);
                LrPheStt -= 1;

            });

            LrSldatechange = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                LaprapTaoidnhaplieu();
            });
        }

        private void OnMyComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            var bb = sender as ComboBox;
            int ins = LrSlSoLo.IndexOf(bb);
            var text = ((Cw3_Product.Model.DonHangTp)bb.SelectedItem).SoLo;
            var a = DataProvider.Ins.DB.DonHangTp.Where(x => x.SoLo == text);
            if (a == null || a.Count() == 0)
            {

            }
            else
            {
                
                LrSlMaTp[ins].ItemsSource = new ObservableCollection < DonHangTp > (a);
                LrSlMaTp[ins].DisplayMemberPath = "MaTp";
                LrSlMaTp[ins].Text = a.First().MaTp;
            }

        }
        void LaprapTaoidnhaplieu()
        {
            DateTime timetam = DateTime.Today;
            string timeint = "";
            int stt = 0;
            int maid = 0;
            bool flag = false;
            if (LrSlNgay != null) { timetam = (DateTime)LrSlNgay; }
            timeint = timetam.ToString("yyMMdd");
            maid = Int32.Parse(timeint, 0);
            stt = maid * 1000 + 1;
            for (int i = stt; flag == false; i++)
            {
                var check = DataProvider.Ins.DB.LrSanXuat.Where(x => x.MaPhieu == ("Lr-"+i.ToString()));
                if (check == null || check.Count() == 0)
                {
                    stt = i;
                    flag = true;
                }
            }
            LrSlId = "Lr-" + stt.ToString();
        }
        void ClearLapRapphieunhap()
        {
            LrSlNgay = null;
            LrSlCa = null;
            LrSlChuyenLr = null;
            LrSlId =null;
        }

    }
}
