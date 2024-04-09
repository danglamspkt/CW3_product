using Cw3_Product.Model;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace Cw3_Product.ViewModel
{
    public class EpNhuaPhieuSLViewModel : BaseViewModel
    {
        //-------------------------Khai báo list hiển thị BOM TP--------------------------------------------------
        private ObservableCollection<BomLk> _SoHoaList;
        public ObservableCollection<BomLk> SoHoaList { get => _SoHoaList; set { _SoHoaList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Đơn vị--------------------------------------------------
        private ObservableCollection<Unit> _donvilist;
        public ObservableCollection<Unit> donvilist { get => _donvilist; set { _donvilist = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Đơn vị--------------------------------------------------
        private ObservableCollection<TaiSanCoDinh> _Mamaylist;
        public ObservableCollection<TaiSanCoDinh> Mamaylist { get => _Mamaylist; set { _Mamaylist = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị mã mua hàng--------------------------------------------------
        private ObservableCollection<BomNl> _Mamuahanglist;
        public ObservableCollection<BomNl> Mamuahanglist { get => _Mamuahanglist; set { _Mamuahanglist = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị tên nhân viên--------------------------------------------------
        private ObservableCollection<NhanSu> _NhanVienlist;
        public ObservableCollection<NhanSu> NhanVienlist { get => _NhanVienlist; set { _NhanVienlist = value; OnPropertyChanged(); } }

        private DateTime? _EnNgay;
        public DateTime? EnNgay { get => _EnNgay; set { _EnNgay = value; OnPropertyChanged(); } }

        private string _EnCa;
        public string EnCa { get => _EnCa; set { _EnCa = value; OnPropertyChanged(); } }

        private string _EnMaMay;
        public string EnMaMay { get => _EnMaMay; set { _EnMaMay = value; OnPropertyChanged(); } }

        private string _EnNhanVien;
        public string EnNhanVien { get => _EnNhanVien; set { _EnNhanVien = value; OnPropertyChanged(); } }

        private string _EnId;
        public string EnId { get => _EnId; set { _EnId = value; OnPropertyChanged(); } }

        public ICommand ThemMaNhietDo { get; set; }
        public ICommand XoaMaNhietDo { get; set; }
        public ICommand ThemMaSanLuong { get; set; }
        public ICommand XoaMaSanLuong { get; set; }
        public ICommand ThemMaKiemTra { get; set; }
        public ICommand XoaMaKiemTra { get; set; }
        public ICommand ThemMaTime { get; set; }
        public ICommand XoaMaTime { get; set; }
        public ICommand ThemMaNguyenLieu { get; set; }
        public ICommand XoaMaNguyenLieu { get; set; }
        public ICommand TaoDon { get; set; }
        public ICommand XacNhan { get; set; }
        public ICommand HuyDon { get; set; }
        public ICommand Endatechange { get; set; }

        List<TextBox> NhietDoSTT = new List<TextBox>();
        List<TimePicker> NhietDoBatDau = new List<TimePicker>();
        List<ComboBox> NhietDoSoHoa = new List<ComboBox>();
        List<TimePicker> NhietDoGhiNhan = new List<TimePicker>();
        List<TextBox> NhietDoDauPhun = new List<TextBox>();
        List<TextBox> NhietDoT1 = new List<TextBox>();
        List<TextBox> NhietDoT2 = new List<TextBox>();
        List<TextBox> NhietDoT3 = new List<TextBox>();
        List<TextBox> NhietDoT4 = new List<TextBox>();
        List<TextBox> NhietDoSay = new List<TextBox>();
        List<TextBox> NhietDoVMax = new List<TextBox>();
        List<TextBox> NhietDoVMin = new List<TextBox>();
        List<TextBox> NhietDoPMax = new List<TextBox>();
        List<TextBox> NhietDoPMin = new List<TextBox>();
        List<TextBox> NhietDoTime = new List<TextBox>();
        int NhietDott = 0;

        List<TextBox> SlSTT = new List<TextBox>();
        List<TimePicker> SLBatDau = new List<TimePicker>();
        List<TimePicker> SlKetThuc = new List<TimePicker>();
        List<ComboBox> SlSoHoa = new List<ComboBox>();
        List<TextBox> SlDisplayName = new List<TextBox>();
        List<TextBox> SlMay = new List<TextBox>();
        List<TextBox> SlChuKy = new List<TextBox>();
        List<TextBox> SlDat = new List<TextBox>();
        List<TextBox> SlPhe = new List<TextBox>();
        List<TextBox> SlNguyenNhan = new List<TextBox>();
        List<TextBox> SlTime = new List<TextBox>();
        int Sltt = 0;

        List<TextBox> DungMaySTT = new List<TextBox>();
        List<TimePicker> DungMayBatDau = new List<TimePicker>();
        List<TimePicker> DungMayKetThuc = new List<TimePicker>();
        List<ComboBox> DungMayLyDo = new List<ComboBox>();
        int DungMaytt = 0;

        List<TextBox> CheckSTT = new List<TextBox>();
        List<TimePicker> CheckTime = new List<TimePicker>();
        List<ComboBox> CheckSoHoa = new List<ComboBox>();
        List<TextBox> CheckDisplayName = new List<TextBox>();
        List<CheckBox> CheckHutNhua = new List<CheckBox>();
        List<CheckBox> CheckMauSac = new List<CheckBox>();
        List<CheckBox> CheckBavia = new List<CheckBox>();
        List<CheckBox> CheckGonSong = new List<CheckBox>();
        List<TextBox> CheckDuongKinh = new List<TextBox>();
        List<TextBox> CheckTrucGiua = new List<TextBox>();
        List<CheckBox> CheckThaoLap = new List<CheckBox>();
        List<TextBox> CheckCanNang = new List<TextBox>();
        int Checktt = 0;

        List<TextBox> NlSTT = new List<TextBox>();
        List<TimePicker> NlTime = new List<TimePicker>();
        List<ComboBox> NlMamuahang = new List<ComboBox>();
        List<TextBox> NlDisplayName = new List<TextBox>();
        List<TextBox> NlNhuaMoi = new List<TextBox>();
        List<TextBox> NlNhuaCu = new List<TextBox>();
        int Nltt = 0;

        private bool _ThongSo1;
        public bool ThongSo1 { get => _ThongSo1; set { _ThongSo1 = value; OnPropertyChanged(); } }

        private bool _ThongSo2;
        public bool ThongSo2 { get => _ThongSo2; set { _ThongSo2 = value; OnPropertyChanged(); } }

        private bool _ThongSo3;
        public bool ThongSo3 { get => _ThongSo3; set { _ThongSo3 = value; OnPropertyChanged(); } }

        private bool _ThongSo4;
        public bool ThongSo4 { get => _ThongSo4; set { _ThongSo4 = value; OnPropertyChanged(); } }

        private bool _ThongSo5;
        public bool ThongSo5 { get => _ThongSo5; set { _ThongSo5 = value; OnPropertyChanged(); } }

        private bool _ThongSo6;
        public bool ThongSo6 { get => _ThongSo6; set { _ThongSo6 = value; OnPropertyChanged(); } }

        private bool _ThongSo7;
        public bool ThongSo7 { get => _ThongSo7; set { _ThongSo7 = value; OnPropertyChanged(); } }

        private bool _ThongSo8;
        public bool ThongSo8 { get => _ThongSo8; set { _ThongSo8 = value; OnPropertyChanged(); } }

        private bool _ThongSo9;
        public bool ThongSo9 { get => _ThongSo9; set { _ThongSo9 = value; OnPropertyChanged(); } }

        private bool _ThongSo10;
        public bool ThongSo10 { get => _ThongSo10; set { _ThongSo10 = value; OnPropertyChanged(); } }

        private bool _ThongSo11;
        public bool ThongSo11 { get => _ThongSo11; set { _ThongSo11 = value; OnPropertyChanged(); } }

        private bool _ThongSo12;
        public bool ThongSo12 { get => _ThongSo12; set { _ThongSo12 = value; OnPropertyChanged(); } }

        private bool _ThongSo13;
        public bool ThongSo13 { get => _ThongSo13; set { _ThongSo13 = value; OnPropertyChanged(); } }

        private bool _ThongSo14;
        public bool ThongSo14 { get => _ThongSo14; set { _ThongSo14 = value; OnPropertyChanged(); } }

        private bool _ThongSo15;
        public bool ThongSo15 { get => _ThongSo15; set { _ThongSo15 = value; OnPropertyChanged(); } }

        private bool _ThongSo16;
        public bool ThongSo16 { get => _ThongSo16; set { _ThongSo16 = value; OnPropertyChanged(); } }


        private bool _FlagNew;
        public bool FlagNew { get => _FlagNew; set { _FlagNew = value; OnPropertyChanged(); } }

        public EpNhuaPhieuSLViewModel() 
        {
            FlagNew = false;

            ThemMaNhietDo = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                NhietDott++;
                StackPanel wrapPanel = new StackPanel();
                wrapPanel.Orientation = Orientation.Horizontal;
                wrapPanel.Margin = new Thickness(10, 5, 0, 5);

                TextBox Nhietdostt = new TextBox();
                Nhietdostt.IsReadOnly = false;
                Nhietdostt.TextAlignment = TextAlignment.Center;
                Nhietdostt.Text = NhietDott.ToString();
                Nhietdostt.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(Nhietdostt, "STT");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                Nhietdostt.Width = 40;
                Nhietdostt.Margin = new Thickness(5, 0, 15, 0);
                NhietDoSTT.Insert(NhietDott - 1, Nhietdostt);
                wrapPanel.Children.Add(NhietDoSTT[NhietDott - 1]);

                TimePicker tpBatDau = new TimePicker();
                tpBatDau.Width = 90;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tpBatDau, "Bắt đầu");
                tpBatDau.Is24Hours = true;
                tpBatDau.WithSeconds = true;
                tpBatDau.Margin = new Thickness(15, 0, 15, 0);
                NhietDoBatDau.Insert(NhietDott - 1, tpBatDau);
                wrapPanel.Children.Add(NhietDoBatDau[NhietDott - 1]);

                ComboBox cbSoHoa = new ComboBox();
                cbSoHoa.ItemsSource = SoHoaList;
                cbSoHoa.DisplayMemberPath = "SoHoa";
                cbSoHoa.Text = null;
                cbSoHoa.IsEnabled = true;
                cbSoHoa.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cbSoHoa, "Số họa");
                cbSoHoa.Width = 110;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbSoHoa, 50);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbSoHoa, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                cbSoHoa.Margin = new Thickness(15, 0, 15, 0);
                NhietDoSoHoa.Insert(NhietDott - 1, cbSoHoa);
                wrapPanel.Children.Add(NhietDoSoHoa[NhietDott - 1]);


                TimePicker tpGhiNhan = new TimePicker();
                tpGhiNhan.Width = 90;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tpGhiNhan, "Bắt đầu");
                tpGhiNhan.Is24Hours = true;
                tpGhiNhan.WithSeconds = true;
                tpGhiNhan.Margin = new Thickness(15, 0, 15, 0);
                NhietDoGhiNhan.Insert(NhietDott - 1, tpGhiNhan);
                wrapPanel.Children.Add(NhietDoGhiNhan[NhietDott - 1]);

                TextBox tbDauPhun = new TextBox();
                tbDauPhun.IsReadOnly = false;
                tbDauPhun.Text = 0.ToString();
                tbDauPhun.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbDauPhun, "Nhiệt độ đầu phun");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbDauPhun.Width = 80;
                tbDauPhun.Margin = new Thickness(15, 0, 15, 0);
                NhietDoDauPhun.Insert(NhietDott - 1, tbDauPhun);
                wrapPanel.Children.Add(NhietDoDauPhun[NhietDott - 1]);

                TextBox tbT1 = new TextBox();
                tbT1.IsReadOnly = false;
                tbT1.Text = 0.ToString();
                tbT1.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbT1, "Nhiệt độ T1");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbT1.Width = 70;
                tbT1.Margin = new Thickness(15, 0, 15, 0);
                NhietDoT1.Insert(NhietDott - 1, tbT1);
                wrapPanel.Children.Add(NhietDoT1[NhietDott - 1]);

                TextBox tbT2 = new TextBox();
                tbT2.IsReadOnly = false;
                tbT2.Text = 0.ToString();
                tbT2.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbT2, "Nhiệt độ T2");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbT2.Width = 70;
                tbT2.Margin = new Thickness(15, 0, 15, 0);
                NhietDoT2.Insert(NhietDott - 1, tbT2);
                wrapPanel.Children.Add(NhietDoT2[NhietDott - 1]);

                TextBox tbT3 = new TextBox();
                tbT3.IsReadOnly = false;
                tbT3.Text = 0.ToString();
                tbT3.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbT3, "Nhiệt độ T3");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbT3.Width = 70;
                tbT3.Margin = new Thickness(15, 0, 15, 0);
                NhietDoT3.Insert(NhietDott - 1, tbT3);
                wrapPanel.Children.Add(NhietDoT3[NhietDott - 1]);

                TextBox tbT4 = new TextBox();
                tbT4.IsReadOnly = false;
                tbT4.Text = 0.ToString();
                tbT4.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbT4, "Nhiệt độ T4");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbT4.Width = 70;
                tbT4.Margin = new Thickness(15, 0, 15, 0);
                NhietDoT4.Insert(NhietDott - 1, tbT4);
                wrapPanel.Children.Add(NhietDoT4[NhietDott - 1]);

                TextBox tbSay = new TextBox();
                tbSay.IsReadOnly = false;
                tbSay.Text = 0.ToString();
                tbSay.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbSay, "Nhiệt độ Sấy");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbSay.Width = 70;
                tbSay.Margin = new Thickness(15, 0, 15, 0);
                NhietDoSay.Insert(NhietDott - 1, tbSay);
                wrapPanel.Children.Add(NhietDoSay[NhietDott - 1]);

                TextBox tbVMax = new TextBox();
                tbVMax.IsReadOnly = false;
                tbVMax.Text = 0.ToString();
                tbVMax.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbVMax, "V tối đa");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbVMax.Width = 70;
                tbVMax.Margin = new Thickness(15, 0, 15, 0);
                NhietDoVMax.Insert(NhietDott - 1, tbVMax);
                wrapPanel.Children.Add(NhietDoVMax[NhietDott - 1]);

                TextBox tbVMin = new TextBox();
                tbVMin.IsReadOnly = false;
                tbVMin.Text = 0.ToString();
                tbVMin.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbVMin, "V tối thiểu");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbVMin.Width = 70;
                tbVMin.Margin = new Thickness(15, 0, 15, 0);
                NhietDoVMin.Insert(NhietDott - 1, tbVMin);
                wrapPanel.Children.Add(NhietDoVMin[NhietDott - 1]);

                TextBox tbPMax = new TextBox();
                tbPMax.IsReadOnly = false;
                tbPMax.Text = 0.ToString();
                tbPMax.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbPMax, "P tối đa");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbPMax.Width = 70;
                tbPMax.Margin = new Thickness(15, 0, 15, 0);
                NhietDoPMax.Insert(NhietDott - 1, tbPMax);
                wrapPanel.Children.Add(NhietDoPMax[NhietDott - 1]);

                TextBox tbPMin = new TextBox();
                tbPMin.IsReadOnly = false;
                tbPMin.Text = 0.ToString();
                tbPMin.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbPMin, "P tối thiểu");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbPMin.Width = 70;
                tbPMin.Margin = new Thickness(15, 0, 15, 0);
                NhietDoPMin.Insert(NhietDott - 1, tbPMin);
                wrapPanel.Children.Add(NhietDoPMin[NhietDott - 1]);

                TextBox tbTime = new TextBox();
                tbTime.IsReadOnly = false;
                tbTime.Text = 0.ToString();
                tbTime.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbTime, "Thời gian bơm");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbTime.Width = 70;
                tbTime.Margin = new Thickness(15, 0, 15, 0);
                NhietDoTime.Insert(NhietDott - 1, tbTime);
                wrapPanel.Children.Add(NhietDoTime[NhietDott - 1]);

                p.Children.Add(wrapPanel);

            });

            XoaMaNhietDo = new RelayCommand<StackPanel>((p) => { if (NhietDott == 0) return false; else return true; }, (p) =>
            {
                var a = NhietDott - 1;
                p.Children.RemoveAt(a);
                NhietDoSTT.RemoveAt(a);
                NhietDoBatDau.RemoveAt(a);
                NhietDoSoHoa.RemoveAt(a);
                NhietDoGhiNhan.RemoveAt(a);
                NhietDoDauPhun.RemoveAt(a);
                NhietDoT1.RemoveAt(a);
                NhietDoT2.RemoveAt(a);
                NhietDoT3.RemoveAt(a);
                NhietDoT4.RemoveAt(a);
                NhietDoSay.RemoveAt(a);
                NhietDoVMax.RemoveAt(a);
                NhietDoVMin.RemoveAt(a);
                NhietDoPMax.RemoveAt(a);
                NhietDoPMin.RemoveAt(a);
                NhietDoTime.RemoveAt(a);
                NhietDott -= 1;

            });

            ThemMaSanLuong = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                Sltt++;
                StackPanel wrapPanel = new StackPanel();
                wrapPanel.Orientation = Orientation.Horizontal;
                wrapPanel.Margin = new Thickness(10, 5, 0, 5);

                TextBox Sanluongstt = new TextBox();
                Sanluongstt.IsReadOnly = false;
                Sanluongstt.TextAlignment = TextAlignment.Center;
                Sanluongstt.Text = Sltt.ToString();
                Sanluongstt.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(Sanluongstt, "STT");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                Sanluongstt.Width = 40;
                Sanluongstt.Margin = new Thickness(5, 0, 15, 0);
                SlSTT.Insert(Sltt - 1, Sanluongstt);
                wrapPanel.Children.Add(SlSTT[Sltt - 1]);

                TimePicker tpBatDau = new TimePicker();
                tpBatDau.Width = 90;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tpBatDau, "Bắt đầu");
                tpBatDau.Is24Hours = true;
                tpBatDau.WithSeconds = true;
                tpBatDau.Margin = new Thickness(15, 0, 15, 0);
                SLBatDau.Insert(Sltt - 1, tpBatDau);
                wrapPanel.Children.Add(SLBatDau[Sltt - 1]);

                TimePicker tpKetthuc = new TimePicker();
                tpKetthuc.Width = 90;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tpKetthuc, "Kết thúc");
                tpKetthuc.Is24Hours = true;
                tpKetthuc.WithSeconds = true;
                tpKetthuc.Margin = new Thickness(15, 0, 15, 0);
                SlKetThuc.Insert(Sltt - 1, tpKetthuc);
                wrapPanel.Children.Add(SlKetThuc[Sltt - 1]);

                ComboBox cbSoHoa = new ComboBox();
                cbSoHoa.ItemsSource = SoHoaList;
                cbSoHoa.DisplayMemberPath = "SoHoa";
                cbSoHoa.Text = null;
                cbSoHoa.IsEnabled = true;
                cbSoHoa.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cbSoHoa, "Số họa");
                cbSoHoa.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged);
                cbSoHoa.Width = 140;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbSoHoa, 50);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbSoHoa, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                cbSoHoa.Margin = new Thickness(15, 0, 15, 0);
                SlSoHoa.Insert(Sltt - 1, cbSoHoa);
                wrapPanel.Children.Add(SlSoHoa[Sltt - 1]);

                TextBox tbDisplayName = new TextBox();
                tbDisplayName.IsReadOnly = true;
                tbDisplayName.Text = null;
                tbDisplayName.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbDisplayName, "Display Name");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbDisplayName.Width = 170;
                tbDisplayName.Margin = new Thickness(15, 0, 15, 0);
                SlDisplayName.Insert(Sltt - 1, tbDisplayName);
                wrapPanel.Children.Add(SlDisplayName[Sltt - 1]);

                TextBox tbmay = new TextBox();
                tbmay.IsReadOnly = false;
                tbmay.Text = 0.ToString();
                tbmay.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbmay, "Số lượng trên máy");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbmay.Width = 90;
                tbmay.Margin = new Thickness(15, 0, 15, 0);
                SlMay.Insert(Sltt - 1, tbmay);
                wrapPanel.Children.Add(SlMay[Sltt - 1]);

                TextBox tbchuky = new TextBox();
                tbchuky.IsReadOnly = false;
                tbchuky.Text = 0.ToString();
                tbchuky.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbchuky, "Số lượng 1 chu kỳ");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbchuky.Width = 90;
                tbchuky.Margin = new Thickness(15, 0, 15, 0);
                SlChuKy.Insert(Sltt - 1, tbchuky);
                wrapPanel.Children.Add(SlChuKy[Sltt - 1]);

                TextBox tbDat = new TextBox();
                tbDat.IsReadOnly = false;
                tbDat.Text = 0.ToString();
                tbDat.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbDat, "Số lượng đạt");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbDat.Width = 90;
                tbDat.Margin = new Thickness(15, 0, 15, 0);
                SlDat.Insert(Sltt - 1, tbDat);
                wrapPanel.Children.Add(SlDat[Sltt - 1]);

                TextBox tbphe = new TextBox();
                tbphe.IsReadOnly = false;
                tbphe.Text = 0.ToString();
                tbphe.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbphe, "Số lượng phế");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbphe.Width = 90;
                tbphe.Margin = new Thickness(15, 0, 15, 0);
                SlPhe.Insert(Sltt - 1, tbphe);
                wrapPanel.Children.Add(SlPhe[Sltt - 1]);

                TextBox tbnguyennhan = new TextBox();
                tbnguyennhan.IsReadOnly = false;
                tbnguyennhan.Text = null;
                tbnguyennhan.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbnguyennhan, "Nguyên nhân");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbnguyennhan.Width = 170;
                tbnguyennhan.Margin = new Thickness(15, 0, 15, 0);
                SlNguyenNhan.Insert(Sltt - 1, tbnguyennhan);
                wrapPanel.Children.Add(SlNguyenNhan[Sltt - 1]);

                TextBox tbtime = new TextBox();
                tbtime.IsReadOnly = false;
                tbtime.Text = 0.ToString();
                tbtime.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbtime, "Thời gian 1 chu kỳ");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbtime.Width = 90;
                tbtime.Margin = new Thickness(15, 0, 15, 0);
                SlTime.Insert(Sltt - 1, tbtime);
                wrapPanel.Children.Add(SlTime[Sltt - 1]);

                p.Children.Add(wrapPanel);

            });

            XoaMaSanLuong = new RelayCommand<StackPanel>((p) => { if (Sltt == 0) return false; else return true; }, (p) =>
            {
                var a = Sltt - 1;
                p.Children.RemoveAt(a);
                SlSTT.RemoveAt(a);
                SLBatDau.RemoveAt(a);
                SlKetThuc.RemoveAt(a);
                SlSoHoa.RemoveAt(a);
                SlDisplayName.RemoveAt(a);
                SlMay.RemoveAt(a);
                SlChuKy.RemoveAt(a);
                SlDat.RemoveAt(a);
                SlPhe.RemoveAt(a);
                SlNguyenNhan.RemoveAt(a);
                SlTime.RemoveAt(a);
                Sltt -= 1;

            });

            ThemMaTime = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                DungMaytt++;
                StackPanel wrapPanel = new StackPanel();
                wrapPanel.Orientation = Orientation.Horizontal;
                wrapPanel.Margin = new Thickness(10, 5, 0, 5);

                TextBox Sanluongstt = new TextBox();
                Sanluongstt.IsReadOnly = false;
                Sanluongstt.TextAlignment = TextAlignment.Center;
                Sanluongstt.Text = DungMaytt.ToString();
                Sanluongstt.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(Sanluongstt, "STT");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                Sanluongstt.Width = 40;
                Sanluongstt.Margin = new Thickness(5, 0, 15, 0);
                DungMaySTT.Insert(DungMaytt - 1, Sanluongstt);
                wrapPanel.Children.Add(DungMaySTT[DungMaytt - 1]);

                ComboBox timelydo = new ComboBox();
                var listItem = new List<string>() { "Khởi động máy", "Sự cố chất lượng", "Thay khuôn/sửa khuôn", "Sự cố máy lỗi/bảo dưỡng máy", "Khác (Họp SX, 5S, không sản xuất, cúp điện...)" };
                timelydo.ItemsSource = listItem;
                timelydo.Text = null;
                timelydo.IsEnabled = true;
                timelydo.IsEditable = true;
                timelydo.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(timelydo, "Lý do");
                timelydo.Width = 290;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(timelydo, 50);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(timelydo, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                timelydo.Margin = new Thickness(15, 0, 15, 0);
                DungMayLyDo.Insert(DungMaytt - 1, timelydo);
                wrapPanel.Children.Add(DungMayLyDo[DungMaytt - 1]);

                TimePicker tpBatDau = new TimePicker();
                tpBatDau.Width = 90;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tpBatDau, "Bắt đầu");
                tpBatDau.Is24Hours = true;
                tpBatDau.WithSeconds = true;
                tpBatDau.Margin = new Thickness(15, 0, 15, 0);
                DungMayBatDau.Insert(DungMaytt - 1, tpBatDau);
                wrapPanel.Children.Add(DungMayBatDau[DungMaytt - 1]);

                TimePicker tpKetthuc = new TimePicker();
                tpKetthuc.Width = 90;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tpKetthuc, "Kết thúc");
                tpKetthuc.Is24Hours = true;
                tpKetthuc.WithSeconds = true;
                tpKetthuc.Margin = new Thickness(15, 0, 15, 0);
                DungMayKetThuc.Insert(DungMaytt - 1, tpKetthuc);
                wrapPanel.Children.Add(DungMayKetThuc[DungMaytt - 1]);


                p.Children.Add(wrapPanel);

            });

            XoaMaTime = new RelayCommand<StackPanel>((p) => { if (DungMaytt == 0) return false; else return true; }, (p) =>
            {
                var a = DungMaytt - 1;
                p.Children.RemoveAt(a);
                DungMaySTT.RemoveAt(a);
                DungMayBatDau.RemoveAt(a);
                DungMayKetThuc.RemoveAt(a);
                DungMayLyDo.RemoveAt(a);
                DungMaytt -= 1;

            });

            ThemMaKiemTra = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                Checktt++;
                StackPanel wrapPanel = new StackPanel();
                wrapPanel.Orientation = Orientation.Horizontal;
                wrapPanel.Margin = new Thickness(10, 5, 0, 5);

                TextBox Sanluongstt = new TextBox();
                Sanluongstt.IsReadOnly = false;
                Sanluongstt.TextAlignment = TextAlignment.Center;
                Sanluongstt.Text = Checktt.ToString();
                Sanluongstt.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(Sanluongstt, "STT");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                Sanluongstt.Width = 40;
                Sanluongstt.Margin = new Thickness(5, 0, 15, 0);
                SlSTT.Insert(Checktt - 1, Sanluongstt);
                wrapPanel.Children.Add(SlSTT[Checktt - 1]);

                TimePicker tpBatDau = new TimePicker();
                tpBatDau.Width = 90;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tpBatDau, "Thời gian");
                tpBatDau.Is24Hours = true;
                tpBatDau.WithSeconds = true;
                tpBatDau.Margin = new Thickness(15, 0, 15, 0);
                CheckTime.Insert(Checktt - 1, tpBatDau);
                wrapPanel.Children.Add(CheckTime[Checktt - 1]);

                ComboBox cbSoHoa = new ComboBox();
                cbSoHoa.ItemsSource = SoHoaList;
                cbSoHoa.DisplayMemberPath = "SoHoa";
                cbSoHoa.Text = null;
                cbSoHoa.IsEnabled = true;
                cbSoHoa.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cbSoHoa, "Số họa");
                cbSoHoa.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged2);
                cbSoHoa.Width = 140;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbSoHoa, 50);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbSoHoa, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                cbSoHoa.Margin = new Thickness(15, 0, 15, 0);
                CheckSoHoa.Insert(Checktt - 1, cbSoHoa);
                wrapPanel.Children.Add(CheckSoHoa[Checktt - 1]);

                TextBox tbDisplayName = new TextBox();
                tbDisplayName.IsReadOnly = true;
                tbDisplayName.Text = null;
                tbDisplayName.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbDisplayName, "Display Name");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbDisplayName.Width = 140;
                tbDisplayName.Margin = new Thickness(15, 0, 15, 0);
                CheckDisplayName.Insert(Checktt - 1, tbDisplayName);
                wrapPanel.Children.Add(CheckDisplayName[Checktt - 1]);

                CheckBox cbHutNhua = new CheckBox();
                cbHutNhua.IsChecked = false;
                cbHutNhua.Width = 50;
                cbHutNhua.HorizontalAlignment = HorizontalAlignment.Center;
                cbHutNhua.Margin = new Thickness(55, 0, 15, 0);
                CheckHutNhua.Insert(Checktt - 1, cbHutNhua);
                wrapPanel.Children.Add(CheckHutNhua[Checktt - 1]);

                CheckBox cbMauSac = new CheckBox();
                cbMauSac.IsChecked = false;
                cbMauSac.Width = 50;
                cbMauSac.HorizontalAlignment = HorizontalAlignment.Center;
                cbMauSac.Margin = new Thickness(55, 0, 15, 0);
                CheckMauSac.Insert(Checktt - 1, cbMauSac);
                wrapPanel.Children.Add(CheckMauSac[Checktt - 1]);

                CheckBox cbBavia = new CheckBox();
                cbBavia.IsChecked = false;
                cbBavia.Width = 50;
                cbBavia.HorizontalAlignment = HorizontalAlignment.Center;
                cbBavia.Margin = new Thickness(55, 0, 15, 0);
                CheckBavia.Insert(Checktt - 1, cbBavia);
                wrapPanel.Children.Add(CheckBavia[Checktt - 1]);

                CheckBox cbGonSong = new CheckBox();
                cbGonSong.IsChecked = false;
                cbGonSong.Width = 50;
                cbGonSong.HorizontalAlignment = HorizontalAlignment.Center;
                cbGonSong.Margin = new Thickness(55, 0, 15, 0);
                CheckGonSong.Insert(Checktt - 1, cbGonSong);
                wrapPanel.Children.Add(CheckGonSong[Checktt - 1]);

                TextBox tbDuongKinh = new TextBox();
                tbDuongKinh.IsReadOnly = false;
                tbDuongKinh.Text = 0.ToString();
                tbDuongKinh.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbDuongKinh, "Đường kính");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbDuongKinh.Width = 90;
                tbDuongKinh.Margin = new Thickness(15, 0, 15, 0);
                CheckDuongKinh.Insert(Checktt - 1, tbDuongKinh);
                wrapPanel.Children.Add(CheckDuongKinh[Checktt - 1]);

                TextBox tbTrucGiua = new TextBox();
                tbTrucGiua.IsReadOnly = false;
                tbTrucGiua.Text = 0.ToString();
                tbTrucGiua.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbTrucGiua, "Trục giữa");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbTrucGiua.Width = 90;
                tbTrucGiua.Margin = new Thickness(15, 0, 15, 0);
                CheckTrucGiua.Insert(Checktt - 1, tbTrucGiua);
                wrapPanel.Children.Add(CheckTrucGiua[Checktt - 1]);

                CheckBox cbThaoLap = new CheckBox();
                cbThaoLap.IsChecked = false;
                cbThaoLap.Width = 50;
                cbThaoLap.HorizontalAlignment = HorizontalAlignment.Center;
                cbThaoLap.Margin = new Thickness(55, 0, 15, 0);
                CheckThaoLap.Insert(Checktt - 1, cbThaoLap);
                wrapPanel.Children.Add(CheckThaoLap[Checktt - 1]);

                TextBox tbCanNang = new TextBox();
                tbCanNang.IsReadOnly = false;
                tbCanNang.Text = 0.ToString();
                tbCanNang.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbCanNang, "Cân nặng");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbCanNang.Width = 90;
                tbCanNang.Margin = new Thickness(15, 0, 15, 0);
                CheckCanNang.Insert(Checktt - 1, tbCanNang);
                wrapPanel.Children.Add(CheckCanNang[Checktt - 1]);

                p.Children.Add(wrapPanel);

            });

            XoaMaKiemTra = new RelayCommand<StackPanel>((p) => { if (Checktt == 0) return false; else return true; }, (p) =>
            {
                var a = Checktt - 1;
                p.Children.RemoveAt(a);
                CheckSTT.RemoveAt(a);
                CheckTime.RemoveAt(a);
                CheckSoHoa.RemoveAt(a);
                CheckDisplayName.RemoveAt(a);
                CheckHutNhua.RemoveAt(a);
                CheckMauSac.RemoveAt(a);
                CheckBavia.RemoveAt(a);
                CheckGonSong.RemoveAt(a);
                CheckDuongKinh.RemoveAt(a);
                CheckTrucGiua.RemoveAt(a);
                CheckThaoLap.RemoveAt(a);
                CheckCanNang.RemoveAt(a);
                Checktt -= 1;

            });

            ThemMaNguyenLieu = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                Nltt++;
                StackPanel wrapPanel = new StackPanel();
                wrapPanel.Orientation = Orientation.Horizontal;
                wrapPanel.Margin = new Thickness(10, 5, 0, 5);

                TextBox Sanluongstt = new TextBox();
                Sanluongstt.IsReadOnly = false;
                Sanluongstt.TextAlignment = TextAlignment.Center;
                Sanluongstt.Text = Nltt.ToString();
                Sanluongstt.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(Sanluongstt, "STT");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                Sanluongstt.Width = 40;
                Sanluongstt.Margin = new Thickness(5, 0, 15, 0);
                NlSTT.Insert(Nltt - 1, Sanluongstt);
                wrapPanel.Children.Add(NlSTT[Nltt - 1]);

                TimePicker tpBatDau = new TimePicker();
                tpBatDau.Width = 90;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tpBatDau, "Thời gian");
                tpBatDau.Is24Hours = true;
                tpBatDau.WithSeconds = true;
                tpBatDau.Margin = new Thickness(15, 0, 15, 0);
                NlTime.Insert(Nltt - 1, tpBatDau);
                wrapPanel.Children.Add(NlTime[Nltt - 1]);

                ComboBox cbSoHoa = new ComboBox();
                cbSoHoa.ItemsSource = Mamuahanglist;
                cbSoHoa.DisplayMemberPath = "MaMuaHang";
                cbSoHoa.Text = null;
                cbSoHoa.IsEnabled = true;
                cbSoHoa.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cbSoHoa, "Mã mua hàng");
                cbSoHoa.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged3);
                cbSoHoa.Width = 140;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbSoHoa, 50);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbSoHoa, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                cbSoHoa.Margin = new Thickness(15, 0, 15, 0);
                NlMamuahang.Insert(Nltt - 1, cbSoHoa);
                wrapPanel.Children.Add(NlMamuahang[Nltt - 1]);

                TextBox tbDisplayName = new TextBox();
                tbDisplayName.IsReadOnly = true;
                tbDisplayName.Text = null;
                tbDisplayName.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbDisplayName, "Display Name");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbDisplayName.Width = 140;
                tbDisplayName.Margin = new Thickness(15, 0, 15, 0);
                NlDisplayName.Insert(Nltt - 1, tbDisplayName);
                wrapPanel.Children.Add(NlDisplayName[Nltt - 1]);

                TextBox tbDuongKinh = new TextBox();
                tbDuongKinh.IsReadOnly = false;
                tbDuongKinh.Text = 0.ToString();
                tbDuongKinh.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbDuongKinh, "Khối lượng nhựa mới");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbDuongKinh.Width = 90;
                tbDuongKinh.Margin = new Thickness(15, 0, 15, 0);
                NlNhuaMoi.Insert(Nltt - 1, tbDuongKinh);
                wrapPanel.Children.Add(NlNhuaMoi[Nltt - 1]);

                TextBox tbTrucGiua = new TextBox();
                tbTrucGiua.IsReadOnly = false;
                tbTrucGiua.Text = 0.ToString();
                tbTrucGiua.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbTrucGiua, "Khối lượng nhựa cũ");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbTrucGiua.Width = 90;
                tbTrucGiua.Margin = new Thickness(15, 0, 15, 0);
                NlNhuaCu.Insert(Nltt - 1, tbTrucGiua);
                wrapPanel.Children.Add(NlNhuaCu[Nltt - 1]);

                p.Children.Add(wrapPanel);

            });

            XoaMaNguyenLieu = new RelayCommand<StackPanel>((p) => { if (Nltt == 0) return false; else return true; }, (p) =>
            {
                var a = Nltt - 1;
                p.Children.RemoveAt(a);
                NlSTT.RemoveAt(a);
                NlTime.RemoveAt(a);
                NlMamuahang.RemoveAt(a);
                NlDisplayName.RemoveAt(a);
                NlNhuaCu.RemoveAt(a);
                NlNhuaMoi.RemoveAt(a);
                Nltt -= 1;

            });

            Endatechange = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Taoidnhaplieu();
            });

            TaoDon = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                EnNgay = DateTime.Today;
                EnCa = "Ngày";
                EnMaMay = "";
                Taoidnhaplieu();
                NhietDott = 0; Sltt = 0; DungMaytt = 0; Checktt = 0; Nltt = 0;
                Mamuahanglist = new ObservableCollection<BomNl>(DataProvider.Ins.DB.BomNl.Where(u => u.EpNhua == true));
                donvilist = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
                SoHoaList = new ObservableCollection<BomLk>(DataProvider.Ins.DB.BomLk.Where(y => y.EpNhua == true));
                NhanVienlist = new ObservableCollection<NhanSu>(DataProvider.Ins.DB.NhanSu);
                Mamaylist = new ObservableCollection<TaiSanCoDinh>(DataProvider.Ins.DB.TaiSanCoDinh.Where(x => x.MaBp == "GcEn      "));
                FlagNew = true;

            });

            XacNhan = new RelayCommand<StackpanelEn>((p) =>
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
                        Taoidnhaplieu();

                        EPNhietDo EnNhietDo = new EPNhietDo();

                        if (NhietDott > 0) for (int j = 0; j < NhietDott; j++)
                            {
                                EnNhietDo.Ngay = EnNgay;
                                EnNhietDo.CaLv = EnCa;
                                EnNhietDo.MaMay = EnMaMay;
                                EnNhietDo.NhanVien = EnNhanVien;
                                EnNhietDo.MaPhieu = EnId;
                                EnNhietDo.TimeStart = NhietDoBatDau[j].SelectedTime.Value.TimeOfDay;
                                EnNhietDo.SoHoa = NhietDoSoHoa[j].Text;
                                EnNhietDo.TimeWrite = NhietDoGhiNhan[j].SelectedTime.Value.TimeOfDay;
                                EnNhietDo.NhietDo1 = Int32.Parse(NhietDoDauPhun[j].Text);
                                EnNhietDo.NhietDo2 = Int32.Parse(NhietDoT1[j].Text);
                                EnNhietDo.NhietDo3 = Int32.Parse(NhietDoT2[j].Text);
                                EnNhietDo.NhietDo4 = Int32.Parse(NhietDoT3[j].Text);
                                EnNhietDo.NhietDo5 = Int32.Parse(NhietDoT4[j].Text);
                                EnNhietDo.NhietDoSay = Int32.Parse(NhietDoSay[j].Text);
                                EnNhietDo.VPhunKeoMax = Int32.Parse(NhietDoVMax[j].Text);
                                EnNhietDo.VPhunKeoMin = Int32.Parse(NhietDoVMin[j].Text);
                                EnNhietDo.PPhunKeoMax = Int32.Parse(NhietDoPMax[j].Text);
                                EnNhietDo.PPhunKeoMin = Int32.Parse(NhietDoPMin[j].Text);
                                EnNhietDo.TimeBom = Int32.Parse(NhietDoTime[j].Text);
                                EnNhietDo.UserName = Cw3_Product.Properties.Settings.Default.account;

                                DataProvider.Ins.DB.EPNhietDo.Add(EnNhietDo);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                        EPSanXuat EnSl = new EPSanXuat();

                        if (Sltt > 0) for (int j = 0; j < Sltt; j++)
                            {
                                EnSl.Ngay = EnNgay;
                                EnSl.CaLv = EnCa;
                                EnSl.MaMay = EnMaMay;
                                EnSl.NhanVien = EnNhanVien;
                                EnSl.MaPhieu = EnId;
                                EnSl.hourstart = SLBatDau[j].SelectedTime.Value.TimeOfDay;
                                EnSl.hourend = SlKetThuc[j].SelectedTime.Value.TimeOfDay;
                                EnSl.SoHoa = SlSoHoa[j].Text;
                                EnSl.SoLuongMay = Int32.Parse(SlMay[j].Text);
                                EnSl.SoLuongChuKy = Int32.Parse(SlChuKy[j].Text);
                                EnSl.SoLuong = Int32.Parse(SlDat[j].Text);
                                EnSl.Phe = Int32.Parse(SlPhe[j].Text);
                                EnSl.NguyenNhan = (SlNguyenNhan[j].Text);
                                EnSl.TimeChuKy = Int32.Parse(SlTime[j].Text);
                                EnSl.UserName = Cw3_Product.Properties.Settings.Default.account;

                                DataProvider.Ins.DB.EPSanXuat.Add(EnSl);
                                DataProvider.Ins.DB.SaveChanges();
                            }

                        EPThoiGian EnDungMay = new EPThoiGian();

                        if (DungMaytt > 0) for (int j = 0; j < DungMaytt; j++)
                            {
                                EnDungMay.Ngay = EnNgay;
                                EnDungMay.CaLv = EnCa;
                                EnDungMay.MaMay = EnMaMay;
                                EnDungMay.NhanVien = EnNhanVien;
                                EnDungMay.MaPhieu = EnId;
                                EnDungMay.BatDau = DungMayBatDau[j].SelectedTime.Value.TimeOfDay;
                                EnDungMay.KetThuc = DungMayKetThuc[j].SelectedTime.Value.TimeOfDay;
                                EnDungMay.LyDo = DungMayLyDo[j].Text;
                                EnDungMay.UserName = Cw3_Product.Properties.Settings.Default.account;

                                DataProvider.Ins.DB.EPThoiGian.Add(EnDungMay);
                                DataProvider.Ins.DB.SaveChanges();
                            }

                        EPKiemTra EnKiemTra = new EPKiemTra();

                        if (Checktt > 0) for (int j = 0; j < Checktt; j++)
                            {
                                EnKiemTra.Ngay = EnNgay;
                                EnKiemTra.CaLv = EnCa;
                                EnKiemTra.MaMay = EnMaMay;
                                EnKiemTra.NhanVien = EnNhanVien;
                                EnKiemTra.MaPhieu = EnId;
                                EnKiemTra.ThoiGian = CheckTime[j].SelectedTime.Value.TimeOfDay;
                                EnKiemTra.SoHoa = CheckSoHoa[j].Text;
                                EnKiemTra.KhongHutNhua = CheckHutNhua[j].IsChecked;
                                EnKiemTra.DongMau = CheckMauSac[j].IsChecked;
                                EnKiemTra.Bavia = CheckBavia[j].IsChecked;
                                EnKiemTra.GonSong = CheckGonSong[j].IsChecked;
                                EnKiemTra.DuongKinh = Int32.Parse(CheckDuongKinh[j].Text);
                                EnKiemTra.TrucGiua = Int32.Parse(CheckTrucGiua[j].Text);
                                EnKiemTra.ThaoLap = CheckThaoLap[j].IsChecked;
                                EnKiemTra.CanNang = Int32.Parse(CheckCanNang[j].Text);
                                EnKiemTra.UserName = Cw3_Product.Properties.Settings.Default.account;


                                DataProvider.Ins.DB.EPKiemTra.Add(EnKiemTra);
                                DataProvider.Ins.DB.SaveChanges();
                            }

                        EPThemNL EnNl = new EPThemNL();

                        if (Nltt > 0) for (int j = 0; j < Nltt; j++)
                            {
                                EnNl.Ngay = EnNgay;
                                EnNl.CaLv = EnCa;
                                EnNl.MaMay = EnMaMay;
                                EnNl.NhanVien = EnNhanVien;
                                EnNl.MaPhieu = EnId;
                                EnNl.ThoiGian = CheckTime[j].SelectedTime.Value.TimeOfDay;
                                EnNl.MaNVL = NlMamuahang[j].Text;
                                EnNl.KhoiLuongMoi = Int32.Parse(NlNhuaMoi[j].Text);
                                EnNl.KhoiLuongCu = Int32.Parse(NlNhuaCu[j].Text);
                                EnNl.UserName = Cw3_Product.Properties.Settings.Default.account;


                                DataProvider.Ins.DB.EPThemNL.Add(EnNl);
                                DataProvider.Ins.DB.SaveChanges();
                            }

                        EPBaoDuong EnBaoduong = new EPBaoDuong();

                            {
                                EnBaoduong.Ngay = EnNgay;
                                EnBaoduong.CaLv = EnCa;
                                EnBaoduong.MaMay = EnMaMay;
                                EnBaoduong.NhanVien = EnNhanVien;
                                EnBaoduong.MaPhieu = EnId;
                                EnBaoduong.AnToanThietBi = ThongSo1;
                                EnBaoduong.CongTacHanhTrinh = ThongSo2;
                                EnBaoduong.DauDotNhiet = ThongSo3;
                                EnBaoduong.KhiNen = ThongSo4;
                                EnBaoduong.OngNuoc = ThongSo5;
                                EnBaoduong.BoiTron = ThongSo6;
                                EnBaoduong.DauThuyLuc = ThongSo7;
                                EnBaoduong.Robot = ThongSo8;
                                EnBaoduong.MaySay = ThongSo9;
                                EnBaoduong.MayHut = ThongSo10;
                                EnBaoduong.BulongConTan = ThongSo11;
                                EnBaoduong.QuatLamMat = ThongSo12;
                                EnBaoduong.NuocLamMatDau = ThongSo13;
                                EnBaoduong.MayBinhThuong = ThongSo14;
                                EnBaoduong.SapXepDungCu = ThongSo15;
                                EnBaoduong.VeSinhMay = ThongSo16;
                                EnBaoduong.UserName = Cw3_Product.Properties.Settings.Default.account;


                                DataProvider.Ins.DB.EPBaoDuong.Add(EnBaoduong);
                                DataProvider.Ins.DB.SaveChanges();
                            }

                        p.Stack1.Children.Clear(); p.Stack2.Children.Clear(); p.Stack3.Children.Clear(); p.Stack4.Children.Clear(); p.Stack5.Children.Clear();

                        NhietDoSTT.Clear(); NhietDoBatDau.Clear(); NhietDoSoHoa.Clear(); NhietDoGhiNhan.Clear(); NhietDoDauPhun.Clear(); NhietDoT1.Clear(); NhietDoT2.Clear(); NhietDoT3.Clear(); NhietDoT4.Clear(); NhietDoSay.Clear(); NhietDoVMax.Clear(); NhietDoVMin.Clear(); NhietDoPMax.Clear(); NhietDoPMin.Clear(); NhietDoTime.Clear();

                        SlSTT.Clear(); SLBatDau.Clear(); SlKetThuc.Clear(); SlSoHoa.Clear(); SlDisplayName.Clear(); SlMay.Clear(); SlChuKy.Clear(); SlDat.Clear(); SlPhe.Clear(); SlNguyenNhan.Clear(); SlTime.Clear();

                        DungMaySTT.Clear(); DungMayBatDau.Clear(); DungMayKetThuc.Clear(); DungMayLyDo.Clear();

                        CheckSTT.Clear(); CheckTime.Clear(); CheckSoHoa.Clear(); CheckDisplayName.Clear(); CheckHutNhua.Clear(); CheckMauSac.Clear(); CheckBavia.Clear(); CheckGonSong.Clear(); CheckDuongKinh.Clear(); CheckTrucGiua.Clear(); CheckThaoLap.Clear(); CheckCanNang.Clear();

                        NlSTT.Clear(); NlTime.Clear(); NlMamuahang.Clear(); NlDisplayName.Clear(); NlNhuaCu.Clear(); NlNhuaMoi.Clear();

                        ThongSo1 = false; ThongSo2 = false; ThongSo3 = false; ThongSo4 = false; ThongSo5 = false; ThongSo6 = false; ThongSo7 = false; ThongSo8 = false; ThongSo9 = false; ThongSo10 = false; ThongSo11 = false; ThongSo12 = false; ThongSo13 = false; ThongSo14 = false; ThongSo15 = false; ThongSo16 = false;

                        NhietDott = 0; Sltt = 0; DungMaytt = 0; Checktt = 0; Nltt = 0;

                        Clearphieunhap();
                        FlagNew = false;
                    }
                    catch (Exception)
                    {
                        var a = DataProvider.Ins.DB.EPNhietDo.Where(x => x.MaPhieu == EnId);
                        while (a.Count() > 0)
                        {
                            DataProvider.Ins.DB.EPNhietDo.Remove(a.First());
                            DataProvider.Ins.DB.SaveChanges();
                            a = DataProvider.Ins.DB.EPNhietDo.Where(x => x.MaPhieu == EnId);
                        }

                        var b = DataProvider.Ins.DB.EPSanXuat.Where(x => x.MaPhieu == EnId);
                        while (b.Count() > 0)
                        {
                            DataProvider.Ins.DB.EPSanXuat.Remove(b.First());
                            DataProvider.Ins.DB.SaveChanges();
                            b = DataProvider.Ins.DB.EPSanXuat.Where(x => x.MaPhieu == EnId);
                        }

                        var c = DataProvider.Ins.DB.EPThoiGian.Where(x => x.MaPhieu == EnId);
                        while (c.Count() > 0)
                        {
                            DataProvider.Ins.DB.EPThoiGian.Remove(c.First());
                            DataProvider.Ins.DB.SaveChanges();
                            c = DataProvider.Ins.DB.EPThoiGian.Where(x => x.MaPhieu == EnId);
                        }

                        var d = DataProvider.Ins.DB.EPKiemTra.Where(x => x.MaPhieu == EnId);
                        while (d.Count() > 0)
                        {
                            DataProvider.Ins.DB.EPKiemTra.Remove(d.First());
                            DataProvider.Ins.DB.SaveChanges();
                            d = DataProvider.Ins.DB.EPKiemTra.Where(x => x.MaPhieu == EnId);
                        }

                        var e = DataProvider.Ins.DB.EPThemNL.Where(x => x.MaPhieu == EnId);
                        while (e.Count() > 0)
                        {
                            DataProvider.Ins.DB.EPThemNL.Remove(e.First());
                            DataProvider.Ins.DB.SaveChanges();
                            e = DataProvider.Ins.DB.EPThemNL.Where(x => x.MaPhieu == EnId);
                        }

                        var f = DataProvider.Ins.DB.EPBaoDuong.Where(x => x.MaPhieu == EnId);
                        while (f.Count() > 0)
                        {
                            DataProvider.Ins.DB.EPBaoDuong.Remove(f.First());
                            DataProvider.Ins.DB.SaveChanges();
                            f = DataProvider.Ins.DB.EPBaoDuong.Where(x => x.MaPhieu == EnId);
                        }

                        MessageBox.Show("Dữ liệu nhập bị lỗi!", "Dữ liệu nhập!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }



                }
                else if (check == MessageBoxResult.Cancel)
                {

                }

            });

            HuyDon = new RelayCommand<StackpanelEn>((p) =>
            {
                if (FlagNew != true)
                    return false;

                return true;
            }, (p) =>
            {

                var check = MessageBox.Show("Bạn chắc chắn muốn hủy đơn hàng?", "Hủy đơn", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (check == MessageBoxResult.OK)
                {
                    p.Stack1.Children.Clear(); p.Stack2.Children.Clear(); p.Stack3.Children.Clear(); p.Stack4.Children.Clear(); p.Stack5.Children.Clear();

                    NhietDoSTT.Clear(); NhietDoBatDau.Clear(); NhietDoSoHoa.Clear(); NhietDoGhiNhan.Clear(); NhietDoDauPhun.Clear(); NhietDoT1.Clear(); NhietDoT2.Clear(); NhietDoT3.Clear(); NhietDoT4.Clear(); NhietDoSay.Clear(); NhietDoVMax.Clear(); NhietDoVMin.Clear(); NhietDoPMax.Clear(); NhietDoPMin.Clear(); NhietDoTime.Clear();

                    SlSTT.Clear(); SLBatDau.Clear(); SlKetThuc.Clear(); SlSoHoa.Clear(); SlDisplayName.Clear(); SlMay.Clear(); SlChuKy.Clear(); SlDat.Clear(); SlPhe.Clear(); SlNguyenNhan.Clear(); SlTime.Clear();

                    DungMaySTT.Clear(); DungMayBatDau.Clear(); DungMayKetThuc.Clear(); DungMayLyDo.Clear();

                    CheckSTT.Clear(); CheckTime.Clear(); CheckSoHoa.Clear(); CheckDisplayName.Clear(); CheckHutNhua.Clear(); CheckMauSac.Clear(); CheckBavia.Clear(); CheckGonSong.Clear(); CheckDuongKinh.Clear(); CheckTrucGiua.Clear(); CheckThaoLap.Clear(); CheckCanNang.Clear();

                    NlSTT.Clear(); NlTime.Clear(); NlMamuahang.Clear(); NlDisplayName.Clear(); NlNhuaCu.Clear();NlNhuaMoi.Clear();

                    ThongSo1=false; ThongSo2 = false; ThongSo3 = false; ThongSo4 = false; ThongSo5 = false; ThongSo6 = false; ThongSo7 = false; ThongSo8 = false; ThongSo9 = false; ThongSo10 = false; ThongSo11 = false; ThongSo12 = false; ThongSo13 = false; ThongSo14 = false; ThongSo15 = false; ThongSo16 = false;

                    NhietDott = 0; Sltt = 0; DungMaytt = 0; Checktt = 0; Nltt = 0;

                    Clearphieunhap();
                    FlagNew = false;
                }
                else if (check == MessageBoxResult.Cancel)
                {

                }

            });
        }

        private void OnMyComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            int ins = SlSoHoa.IndexOf(combobox);
            string text = "";

            text = ((BomLk)combobox.SelectedItem).SoHoa;

            var a = DataProvider.Ins.DB.BomLk.Where(x => x.SoHoa == text);
            if (a == null || a.Count() == 0)
            {

            }
            else
            {
                
                SlDisplayName[ins].Text = a.First().DisplayName;
            }
        }

        private void OnMyComboBoxChanged2(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            int ins = CheckSoHoa.IndexOf(combobox);
            string text = "";

            text = ((BomLk)combobox.SelectedItem).SoHoa;

            var b = DataProvider.Ins.DB.BomLk.Where(x => x.SoHoa == text);
            if (b == null || b.Count() == 0)
            {

            }
            else
            {

                CheckDisplayName[ins].Text = b.First().DisplayName;
            }
        }

        private void OnMyComboBoxChanged3(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            int ins = NlMamuahang.IndexOf(combobox);
            string text = "";

            text = ((BomNl)combobox.SelectedItem).MaMuaHang;

            var c = DataProvider.Ins.DB.BomNl.Where(x => x.MaMuaHang == text);
            if (c == null || c.Count() == 0)
            {

            }
            else
            {

                NlDisplayName[ins].Text = c.First().DisplayName;
            }
        }

        void Taoidnhaplieu()
        {
            DateTime timetam = DateTime.Today;
            string timeint = "";
            int stt = 0;
            int maid = 0;
            bool flag = false;
            if (EnNgay != null) { timetam = (DateTime)EnNgay; }
            timeint = timetam.ToString("yyMMdd");
            maid = Int32.Parse(timeint, 0);
            stt = maid * 1000 + 1;
            for (int i = stt; flag == false; i++)
            {
                var check = DataProvider.Ins.DB.EPSanXuat.Where(x => x.MaPhieu == ("En-" + i.ToString()));
                if (check == null || check.Count() == 0)
                {
                    stt = i;
                    flag = true;
                }
            }
            EnId = "En-" + stt.ToString();
        }
        void Clearphieunhap()
        {
            EnNgay = null;
            EnCa = null;
            EnMaMay = null;
            EnNhanVien = null;
            EnId = null;
        }
    }
}
