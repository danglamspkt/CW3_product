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
using System.Data.SqlTypes;

namespace Cw3_Product.ViewModel
{
    public class DapKhuonPhieuSlViewModel : BaseViewModel
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

        //-------------------------Khai báo list hiển thị Đơn hàng thành phẩm--------------------------------------------------
        private ObservableCollection<DonHangTp> _SoLoList;
        public ObservableCollection<DonHangTp> SoLoList { get => _SoLoList; set { _SoLoList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị tên nhân viên--------------------------------------------------
        private ObservableCollection<NhanSu> _NhanVienlist;
        public ObservableCollection<NhanSu> NhanVienlist { get => _NhanVienlist; set { _NhanVienlist = value; OnPropertyChanged(); } }

        private DateTime? _DkNgay;
        public DateTime? DkNgay { get => _DkNgay; set { _DkNgay = value; OnPropertyChanged(); } }

        private string _DkCa;
        public string DkCa { get => _DkCa; set { _DkCa = value; OnPropertyChanged(); } }

        private string _DkMaMay;
        public string DkMaMay { get => _DkMaMay; set { _DkMaMay = value; OnPropertyChanged(); } }

        private string _DkNhanVien;
        public string DkNhanVien { get => _DkNhanVien; set { _DkNhanVien = value; OnPropertyChanged(); } }

        private string _DkId;
        public string DkId { get => _DkId; set { _DkId = value; OnPropertyChanged(); } }

        public ICommand ThemMaSanLuong { get; set; }
        public ICommand XoaMaSanLuong { get; set; }
        public ICommand ThemMaKiemTra { get; set; }
        public ICommand XoaMaKiemTra { get; set; }
        public ICommand ThemMaTime { get; set; }
        public ICommand XoaMaTime { get; set; }
        public ICommand TaoDon { get; set; }
        public ICommand XacNhan { get; set; }
        public ICommand HuyDon { get; set; }
        public ICommand Dkdatechange { get; set; }

        List<TextBox> STT = new List<TextBox>();
        List<ComboBox> SoLo = new List<ComboBox>();
        List<ComboBox> SoHoa = new List<ComboBox>();
        List<TextBox> DisplayName = new List<TextBox>();
        List<TextBox> QuyCach = new List<TextBox>();
        List<TimePicker> BatDau = new List<TimePicker>();
        List<TimePicker> KetThuc = new List<TimePicker>();
        List<TextBox> MaNguyenLieu = new List<TextBox>();
        List<TextBox> SoLuong = new List<TextBox>();
        List<TextBox> Phe = new List<TextBox>();
        List<TextBox> NguyenNhan = new List<TextBox>();
        List<CheckBox> TpBtp = new List<CheckBox>();
        int Dktt = 0;


        List<TextBox> pheSTT = new List<TextBox>();
        List<TimePicker> pheThoiGian = new List<TimePicker>();
        List<ComboBox> pheSoHoa = new List<ComboBox>();
        List<TextBox> pheDisplayName = new List<TextBox>();
        List<TextBox> pheQuyCach = new List<TextBox>();
        List<TextBox> pheKichThuoc1 = new List<TextBox>();
        List<TextBox> pheKichThuoc2 = new List<TextBox>();
        List<TextBox> pheKichThuoc3 = new List<TextBox>();
        List<TextBox> pheKichThuoc4 = new List<TextBox>();
        List<TextBox> pheKichThuoc5 = new List<TextBox>();
        List<TextBox> pheKichThuoc6 = new List<TextBox>();
        int phett = 0;

        List<TextBox> timeSTT = new List<TextBox>();
        List<TimePicker> timeBatDau = new List<TimePicker>();
        List<TimePicker> timeKetThuc = new List<TimePicker>();
        List<ComboBox> timeLyDo = new List<ComboBox>();
        int timett = 0;

        private bool _FlagNew;
        public bool FlagNew { get => _FlagNew; set { _FlagNew = value; OnPropertyChanged(); } }
        public DapKhuonPhieuSlViewModel() 
        {
            FlagNew = false;

            TaoDon = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                DkNgay = DateTime.Today;
                DkCa = "Ngày";
                DkMaMay = "";
                Taoidnhaplieu();
                Dktt = 0; phett = 0; timett = 0;
                SoLoList = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp.Where(u => u.TinhTrang == "Sản xuất"));
                donvilist = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
                SoHoaList = new ObservableCollection<BomLk>(DataProvider.Ins.DB.BomLk.Where(y => y.DapKhuon == true));
                Mamaylist = new ObservableCollection<TaiSanCoDinh>(DataProvider.Ins.DB.TaiSanCoDinh.Where(x => x.MaBp == "GcDk      "));
                NhanVienlist = new ObservableCollection<NhanSu>(DataProvider.Ins.DB.NhanSu);
                FlagNew = true;

            });

            XacNhan = new RelayCommand<StackPanelDk>((p) =>
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

                        DKSanXuat Dksl = new DKSanXuat();

                        if (Dktt > 0) for (int j = 0; j < Dktt; j++)
                            {
                                Dksl.Ngay = DkNgay;
                                Dksl.CaLv = DkCa;
                                Dksl.MaMay = DkMaMay;
                                Dksl.NhanVien = DkNhanVien;
                                Dksl.SoHoa = SoHoa[j].Text;
                                Dksl.SoLo = SoLo[j].Text;
                                if (SoLuong[j].Text != null) Dksl.SoLuong = Int32.Parse(SoLuong[j].Text);
                                if (Phe[j].Text != null) Dksl.Phe = Int32.Parse(Phe[j].Text);
                                Dksl.NguyenNhan = NguyenNhan[j].Text;
                                Dksl.IdU = "pcs";
                                Dksl.hourstart = BatDau[j].SelectedTime.Value.TimeOfDay;
                                Dksl.hourend = KetThuc[j].SelectedTime.Value.TimeOfDay;
                                Dksl.MaPhieu = DkId;
                                Dksl.UserName = Cw3_Product.Properties.Settings.Default.account;
                                if (TpBtp[j].IsChecked == false) Dksl.TpBtp = "TP"; else Dksl.TpBtp = "BTP";

                                DataProvider.Ins.DB.DKSanXuat.Add(Dksl);
                                DataProvider.Ins.DB.SaveChanges();
                            }

                        DKKiemTra Dkkt = new DKKiemTra();

                        if (phett > 0) for (int k = 0; k < phett; k++)
                            {
                                Dkkt.Ngay = DkNgay;
                                Dkkt.CaLv = DkCa;
                                Dkkt.MaMay = DkMaMay;
                                Dkkt.NhanVien = DkNhanVien;
                                Dkkt.MaPhieu = DkId;
                                Dkkt.ThoiGian = pheThoiGian[k].SelectedTime.Value.TimeOfDay;
                                Dkkt.SoHoa = pheSoHoa[k].Text;
                                if (pheKichThuoc1[k].Text != null) Dkkt.Kichthuoc1 = Int32.Parse(pheKichThuoc1[k].Text);
                                if (pheKichThuoc2[k].Text != null) Dkkt.Kichthuoc2 = Int32.Parse(pheKichThuoc2[k].Text);
                                if (pheKichThuoc3[k].Text != null) Dkkt.Kichthuoc3 = Int32.Parse(pheKichThuoc3[k].Text);
                                if (pheKichThuoc4[k].Text != null) Dkkt.Kichthuoc4 = Int32.Parse(pheKichThuoc4[k].Text);
                                if (pheKichThuoc5[k].Text != null) Dkkt.Kichthuoc5 = Int32.Parse(pheKichThuoc5[k].Text);
                                if (pheKichThuoc6[k].Text != null) Dkkt.Kichthuoc6 = Int32.Parse(pheKichThuoc6[k].Text);
                                Dkkt.UserName = Cw3_Product.Properties.Settings.Default.account;


                                DataProvider.Ins.DB.DKKiemTra.Add(Dkkt);
                                DataProvider.Ins.DB.SaveChanges();
                            }

                        DkThoiGian Dktime = new DkThoiGian();

                        if (phett > 0) for (int l = 0; l < phett; l++)
                            {
                                Dktime.Ngay = DkNgay;
                                Dktime.CaLv = DkCa;
                                Dktime.MaMay = DkMaMay;
                                Dktime.NhanVien = DkNhanVien;
                                Dktime.MaPhieu = DkId;
                                Dktime.BatDau = timeBatDau[l].SelectedTime.Value.TimeOfDay;
                                Dktime.KetThuc = timeKetThuc[l].SelectedTime.Value.TimeOfDay;
                                Dktime.LyDo = timeLyDo[l].Text;
                                Dktime.UserName = Cw3_Product.Properties.Settings.Default.account;

                                DataProvider.Ins.DB.DkThoiGian.Add(Dktime);
                                DataProvider.Ins.DB.SaveChanges();
                            }

                        p.Stack1.Children.Clear();
                        p.Stack2.Children.Clear();
                        p.Stack3.Children.Clear();

                        STT.Clear();
                        SoHoa.Clear();
                        DisplayName.Clear();
                        QuyCach.Clear();
                        BatDau.Clear();
                        KetThuc.Clear();
                        MaNguyenLieu.Clear();
                        SoLuong.Clear();
                        Phe.Clear();
                        NguyenNhan.Clear();
                        TpBtp.Clear();

                        pheSTT.Clear();
                        pheSoHoa.Clear();
                        pheDisplayName.Clear();
                        pheQuyCach.Clear();
                        pheThoiGian.Clear();
                        pheKichThuoc1.Clear();
                        pheKichThuoc2.Clear();
                        pheKichThuoc3.Clear();
                        pheKichThuoc4.Clear();
                        pheKichThuoc5.Clear();
                        pheKichThuoc6.Clear();

                        timeSTT.Clear();
                        timeBatDau.Clear();
                        timeKetThuc.Clear();
                        timeLyDo.Clear();

                        Dktt = 0;
                        phett = 0;
                        timett = 0;

                        Clearphieunhap();
                        FlagNew = false;
                    }
                    catch (Exception)
                    {
                        var a = DataProvider.Ins.DB.DKSanXuat.Where(x => x.MaPhieu == DkId);
                        while (a.Count() > 0)
                        {
                            DataProvider.Ins.DB.DKSanXuat.Remove(a.First());
                            DataProvider.Ins.DB.SaveChanges();
                            a = DataProvider.Ins.DB.DKSanXuat.Where(x => x.MaPhieu == DkId);
                        }
                        var b = DataProvider.Ins.DB.DkThoiGian.Where(x => x.MaPhieu == DkId);
                        while (b.Count() > 0)
                        {
                            DataProvider.Ins.DB.DkThoiGian.Remove(b.First());
                            DataProvider.Ins.DB.SaveChanges();
                            b = DataProvider.Ins.DB.DkThoiGian.Where(x => x.MaPhieu == DkId);
                        }
                        var c = DataProvider.Ins.DB.DKKiemTra.Where(x => x.MaPhieu == DkId);
                        while (c.Count() > 0)
                        {
                            DataProvider.Ins.DB.DKKiemTra.Remove(c.First());
                            DataProvider.Ins.DB.SaveChanges();
                            c = DataProvider.Ins.DB.DKKiemTra.Where(x => x.MaPhieu == DkId);
                        }
                        MessageBox.Show("Dữ liệu nhập bị lỗi!", "Dữ liệu nhập!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }



                }
                else if (check == MessageBoxResult.Cancel)
                {

                }

            });

            HuyDon = new RelayCommand<StackPanelDk>((p) =>
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
                    p.Stack3.Children.Clear();

                    STT.Clear();
                    SoHoa.Clear();
                    DisplayName.Clear();
                    QuyCach.Clear();
                    BatDau.Clear();
                    KetThuc.Clear();
                    MaNguyenLieu.Clear();
                    SoLuong.Clear();
                    Phe.Clear();
                    NguyenNhan.Clear();
                    TpBtp.Clear();

                    pheSTT.Clear();
                    pheSoHoa.Clear();
                    pheDisplayName.Clear();
                    pheQuyCach.Clear();
                    pheThoiGian.Clear();
                    pheKichThuoc1.Clear();
                    pheKichThuoc2.Clear();
                    pheKichThuoc3.Clear();
                    pheKichThuoc4.Clear();
                    pheKichThuoc5.Clear();
                    pheKichThuoc6.Clear();

                    timeSTT.Clear();
                    timeBatDau.Clear();
                    timeKetThuc.Clear();
                    timeLyDo.Clear();

                    Dktt = 0;
                    phett = 0;
                    timett = 0;

                    Clearphieunhap();
                    FlagNew = false;
                }
                else if (check == MessageBoxResult.Cancel)
                {

                }

            });

            ThemMaSanLuong = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                Dktt++;
                StackPanel wrapPanel = new StackPanel();
                wrapPanel.Orientation = Orientation.Horizontal;
                wrapPanel.Margin = new Thickness(10, 5, 0, 5);

                TextBox tbstt = new TextBox();
                tbstt.IsReadOnly = true;
                tbstt.TextAlignment = TextAlignment.Center;
                tbstt.Text = Dktt.ToString();
                tbstt.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbstt, "STT");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbstt.Width = 20;
                tbstt.Margin = new Thickness(5, 0, 15, 0);
                STT.Insert(Dktt - 1, tbstt);
                wrapPanel.Children.Add(STT[Dktt - 1]);

                ComboBox cbSoLo = new ComboBox();
                cbSoLo.ItemsSource = SoLoList;
                cbSoLo.DisplayMemberPath = "SoLo";
                cbSoLo.Text = null;
                cbSoLo.IsEnabled = true;
                cbSoLo.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged1);
                cbSoLo.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cbSoLo, "Số lô");
                cbSoLo.Width = 170;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbSoLo, 50);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbSoLo, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                cbSoLo.Margin = new Thickness(15, 0, 15, 0);
                SoLo.Insert(Dktt - 1, cbSoLo);
                wrapPanel.Children.Add(SoLo[Dktt - 1]);

                ComboBox cbSoHoa = new ComboBox();
                cbSoHoa.ItemsSource = SoHoaList;
                cbSoHoa.DisplayMemberPath = "SoHoa";
                cbSoHoa.Text = null;
                cbSoHoa.IsEnabled = true;
                cbSoHoa.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged);
                cbSoHoa.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cbSoHoa, "Số họa");
                cbSoHoa.Width = 110;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbSoHoa, 50);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbSoHoa, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                cbSoHoa.Margin = new Thickness(15, 0, 15, 0);
                SoHoa.Insert(Dktt - 1, cbSoHoa);
                wrapPanel.Children.Add(SoHoa[Dktt - 1]);

                TextBox tbDisplayName = new TextBox();
                tbDisplayName.IsReadOnly = true;
                tbDisplayName.Text = null;
                tbDisplayName.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbDisplayName, "Display Name");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbDisplayName.Width = 130;
                tbDisplayName.Margin = new Thickness(15, 0, 15, 0);
                DisplayName.Insert(Dktt - 1, tbDisplayName);
                wrapPanel.Children.Add(DisplayName[Dktt - 1]);

                TextBox tbQuyCach = new TextBox();
                tbQuyCach.IsReadOnly = true;
                tbQuyCach.Text = null;
                tbQuyCach.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbQuyCach, "Quy cách");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbQuyCach.Width = 170;
                tbQuyCach.Margin = new Thickness(15, 0, 15, 0);
                QuyCach.Insert(Dktt - 1, tbQuyCach);
                wrapPanel.Children.Add(QuyCach[Dktt - 1]);

                TimePicker tpBatDau = new TimePicker();
                tpBatDau.Width = 80;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tpBatDau, "Bắt đầu");
                tpBatDau.Is24Hours = true;
                tpBatDau.WithSeconds = true;
                tpBatDau.Margin = new Thickness(15, 0, 15, 0);
                BatDau.Insert(Dktt - 1, tpBatDau);
                wrapPanel.Children.Add(BatDau[Dktt - 1]);

                TimePicker tpKetThuc = new TimePicker();
                tpKetThuc.Width = 80;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tpKetThuc, "Kết thúc");
                tpKetThuc.Is24Hours = true;
                tpKetThuc.WithSeconds = true;
                tpKetThuc.Margin = new Thickness(15, 0, 15, 0);
                KetThuc.Insert(Dktt - 1, tpKetThuc);
                wrapPanel.Children.Add(KetThuc[Dktt - 1]);

                TextBox tbMaNguyenLieu = new TextBox();
                tbMaNguyenLieu.Text = null;
                tbMaNguyenLieu.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbMaNguyenLieu, "Mã nguyên liệu");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbMaNguyenLieu.Width = 110;
                tbMaNguyenLieu.Margin = new Thickness(15, 0, 15, 0);
                MaNguyenLieu.Insert(Dktt - 1, tbMaNguyenLieu);
                wrapPanel.Children.Add(MaNguyenLieu[Dktt - 1]);

                TextBox tbSoLuong = new TextBox();
                tbSoLuong.Text = 0.ToString();
                tbSoLuong.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbSoLuong, "Số lượng");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbSoLuong.Width = 70;
                tbSoLuong.Margin = new Thickness(15, 0, 15, 0);
                SoLuong.Insert(Dktt - 1, tbSoLuong);
                wrapPanel.Children.Add(SoLuong[Dktt - 1]);

                TextBox tbPhe = new TextBox();
                tbPhe.Text = 0.ToString();
                tbPhe.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbPhe, "Phế");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbPhe.Width = 70;
                tbPhe.Margin = new Thickness(15, 0, 15, 0);
                Phe.Insert(Dktt - 1, tbPhe);
                wrapPanel.Children.Add(Phe[Dktt - 1]);

                TextBox tbNguyenNhan = new TextBox();
                tbNguyenNhan.Text = null;
                tbNguyenNhan.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbNguyenNhan, "Nguyên nhân");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbNguyenNhan.Width = 140;
                tbNguyenNhan.Margin = new Thickness(15, 0, 15, 0);
                NguyenNhan.Insert(Dktt - 1, tbNguyenNhan);
                wrapPanel.Children.Add(NguyenNhan[Dktt - 1]);

                CheckBox cbTpBtp = new CheckBox();
                cbTpBtp.IsChecked = false;
                cbTpBtp.Margin = new Thickness(20, 10, 15, 0);
                TpBtp.Insert(Dktt - 1, cbTpBtp);
                wrapPanel.Children.Add(TpBtp[Dktt - 1]);
                
                //MaterialDesignThemes.Wpf.PackIcon icon = new MaterialDesignThemes.Wpf.PackIcon();
                //icon.Height = 24;
                //icon.Width = 24;
                //icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.DeleteOutline;
                //icon.Foreground = Brushes.Black;


                p.Children.Add(wrapPanel);

            });

            XoaMaSanLuong = new RelayCommand<StackPanel>((p) => { if (Dktt == 0) return false; else return true; }, (p) =>
            {
                var a = Dktt - 1;
                p.Children.RemoveAt(a);
                STT.RemoveAt(a);
                SoLo.RemoveAt(a);
                SoHoa.RemoveAt(a);
                DisplayName.RemoveAt(a);
                QuyCach.RemoveAt(a);
                BatDau.RemoveAt(a);
                KetThuc.RemoveAt(a);
                MaNguyenLieu.RemoveAt(a);
                SoLuong.RemoveAt(a);
                Phe.RemoveAt(a);
                NguyenNhan.RemoveAt(a);
                TpBtp.RemoveAt(a);
                Dktt -= 1;

            });

            ThemMaKiemTra = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                phett++;
                StackPanel wrapPanel = new StackPanel();
                wrapPanel.Orientation = Orientation.Horizontal;
                wrapPanel.Margin = new Thickness(10, 5, 0, 5);

                TextBox phestt = new TextBox();
                phestt.IsReadOnly = true;
                phestt.TextAlignment = TextAlignment.Center;
                phestt.Text = Dktt.ToString();
                phestt.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(phestt, "STT");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                phestt.Width = 20;
                phestt.Margin = new Thickness(5, 0, 15, 0);
                pheSTT.Insert(phett - 1, phestt);
                wrapPanel.Children.Add(pheSTT[phett - 1]);

                TimePicker phetptime = new TimePicker();
                phetptime.Width = 80;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(phetptime, "Thời gian");
                phetptime.Is24Hours = true;
                phetptime.WithSeconds = true;
                phetptime.Margin = new Thickness(15, 0, 15, 0);
                pheThoiGian.Insert(phett - 1, phetptime);
                wrapPanel.Children.Add(pheThoiGian[phett - 1]);

                ComboBox phecbSoHoa = new ComboBox();
                phecbSoHoa.ItemsSource = SoHoaList;
                phecbSoHoa.DisplayMemberPath = "SoHoa";
                phecbSoHoa.Text = null;
                phecbSoHoa.IsEnabled = true;
                phecbSoHoa.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged2);
                phecbSoHoa.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(phecbSoHoa, "Số họa");
                phecbSoHoa.Width = 140;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(phecbSoHoa, 50);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(phecbSoHoa, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                phecbSoHoa.Margin = new Thickness(15, 0, 15, 0);
                pheSoHoa.Insert(phett - 1, phecbSoHoa);
                wrapPanel.Children.Add(pheSoHoa[phett - 1]);

                TextBox phetbDisplayName = new TextBox();
                phetbDisplayName.IsReadOnly = true;
                phetbDisplayName.Text = null;
                phetbDisplayName.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(phetbDisplayName, "Display Name");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                phetbDisplayName.Width = 130;
                phetbDisplayName.Margin = new Thickness(15, 0, 15, 0);
                pheDisplayName.Insert(phett - 1, phetbDisplayName);
                wrapPanel.Children.Add(pheDisplayName[phett - 1]);

                TextBox phetbQuyCach = new TextBox();
                phetbQuyCach.IsReadOnly = true;
                phetbQuyCach.Text = null;
                phetbQuyCach.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(phetbQuyCach, "Quy cách");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                phetbQuyCach.Width = 170;
                phetbQuyCach.Margin = new Thickness(15, 0, 15, 0);
                pheQuyCach.Insert(phett - 1, phetbQuyCach);
                wrapPanel.Children.Add(pheQuyCach[phett - 1]);

                TextBox phetbKichThuoc1 = new TextBox();
                phetbKichThuoc1.Text = 0.ToString();
                phetbKichThuoc1.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(phetbKichThuoc1, "Số lượng");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                phetbKichThuoc1.Width = 70;
                phetbKichThuoc1.Margin = new Thickness(15, 0, 15, 0);
                pheKichThuoc1.Insert(phett - 1, phetbKichThuoc1);
                wrapPanel.Children.Add(pheKichThuoc1[phett - 1]);

                TextBox phetbKichThuoc2 = new TextBox();
                phetbKichThuoc2.Text = 0.ToString();
                phetbKichThuoc2.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(phetbKichThuoc2, "Số lượng");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                phetbKichThuoc2.Width = 70;
                phetbKichThuoc2.Margin = new Thickness(15, 0, 15, 0);
                pheKichThuoc2.Insert(phett - 1, phetbKichThuoc2);
                wrapPanel.Children.Add(pheKichThuoc2[phett - 1]);

                TextBox phetbKichThuoc3 = new TextBox();
                phetbKichThuoc3.Text = 0.ToString();
                phetbKichThuoc3.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(phetbKichThuoc3, "Số lượng");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                phetbKichThuoc3.Width = 70;
                phetbKichThuoc3.Margin = new Thickness(15, 0, 15, 0);
                pheKichThuoc3.Insert(phett - 1, phetbKichThuoc3);
                wrapPanel.Children.Add(pheKichThuoc3[phett - 1]);

                TextBox phetbKichThuoc4 = new TextBox();
                phetbKichThuoc4.Text = 0.ToString();
                phetbKichThuoc4.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(phetbKichThuoc4, "Số lượng");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                phetbKichThuoc4.Width = 70;
                phetbKichThuoc4.Margin = new Thickness(15, 0, 15, 0);
                pheKichThuoc4.Insert(phett - 1, phetbKichThuoc4);
                wrapPanel.Children.Add(pheKichThuoc4[phett - 1]);

                TextBox phetbKichThuoc5 = new TextBox();
                phetbKichThuoc5.Text = 0.ToString();
                phetbKichThuoc5.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(phetbKichThuoc5, "Số lượng");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                phetbKichThuoc5.Width = 70;
                phetbKichThuoc5.Margin = new Thickness(15, 0, 15, 0);
                pheKichThuoc5.Insert(phett - 1, phetbKichThuoc5);
                wrapPanel.Children.Add(pheKichThuoc5[phett - 1]);

                TextBox phetbKichThuoc6 = new TextBox();
                phetbKichThuoc6.Text = 0.ToString();
                phetbKichThuoc6.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(phetbKichThuoc6, "Số lượng");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                phetbKichThuoc6.Width = 70;
                phetbKichThuoc6.Margin = new Thickness(15, 0, 15, 0);
                pheKichThuoc6.Insert(phett - 1, phetbKichThuoc6);
                wrapPanel.Children.Add(pheKichThuoc6[phett - 1]);

                p.Children.Add(wrapPanel);

            });

            XoaMaKiemTra = new RelayCommand<StackPanel>((p) => { if (phett == 0) return false; else return true; }, (p) =>
            {
                var a = phett - 1;
                p.Children.RemoveAt(a);
                pheSTT.RemoveAt(a);
                pheSoHoa.RemoveAt(a);
                pheDisplayName.RemoveAt(a);
                pheQuyCach.RemoveAt(a);
                pheThoiGian.RemoveAt(a);
                pheKichThuoc1.RemoveAt(a);
                pheKichThuoc2.RemoveAt(a);
                pheKichThuoc3.RemoveAt(a);
                pheKichThuoc4.RemoveAt(a);
                pheKichThuoc5.RemoveAt(a);
                pheKichThuoc6.RemoveAt(a);
                phett -= 1;

            });

            ThemMaTime = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                timett++;
                StackPanel wrapPanel = new StackPanel();
                wrapPanel.Orientation = Orientation.Horizontal;
                wrapPanel.Margin = new Thickness(10, 5, 0, 5);

                TextBox timestt = new TextBox();
                timestt.IsReadOnly = true;
                timestt.TextAlignment = TextAlignment.Center;
                timestt.Text = timett.ToString();
                timestt.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(timestt, "STT");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                timestt.Width = 20;
                timestt.Margin = new Thickness(5, 0, 15, 0);
                timeSTT.Insert(timett - 1, timestt);
                wrapPanel.Children.Add(timeSTT[timett - 1]);

                ComboBox timelydo = new ComboBox();
                var listItem = new List<string>() { "Chỉnh máy", "Thay dao, khuôn", "Chở hàng", "Vệ sinh cá nhân", "Vệ sinh máy, vệ sinh nơi làm việc", "Họp", "Máy hư", "Kiếm xe nâng, palet", "Nghỉ ngơi" };
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
                timeLyDo.Insert(timett - 1, timelydo);
                wrapPanel.Children.Add(timeLyDo[timett - 1]);

                TimePicker timebatdau = new TimePicker();
                timebatdau.Width = 80;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(timebatdau, "Bắt đầu");
                timebatdau.Is24Hours = true;
                timebatdau.WithSeconds = true;
                timebatdau.Margin = new Thickness(15, 0, 15, 0);
                timeBatDau.Insert(timett - 1, timebatdau);
                wrapPanel.Children.Add(timeBatDau[timett - 1]);

                TimePicker timeketthuc = new TimePicker();
                timeketthuc.Width = 80;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(timeketthuc, "Bắt đầu");
                timeketthuc.Is24Hours = true;
                timeketthuc.WithSeconds = true;
                timeketthuc.Margin = new Thickness(15, 0, 15, 0);
                timeKetThuc.Insert(timett - 1, timeketthuc);
                wrapPanel.Children.Add(timeKetThuc[timett - 1]);

                p.Children.Add(wrapPanel);

            });

            XoaMaTime = new RelayCommand<StackPanel>((p) => { if (timett == 0) return false; else return true; }, (p) =>
            {
                var a = timett - 1;
                p.Children.RemoveAt(a);
                timeSTT.RemoveAt(a);
                timeBatDau.RemoveAt(a);
                timeKetThuc.RemoveAt(a);
                timeLyDo.RemoveAt(a);

                timett -= 1;

            });

            Dkdatechange = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Taoidnhaplieu();
            });

        }

        private void OnMyComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            int ins = SoHoa.IndexOf(combobox);
            string text = "";
            
            if (combobox.SelectedItem != null)
            {
                if ((DonHangTp)SoLo[ins].SelectedItem == null) text = ((BomLk)combobox.SelectedItem).SoHoa;
                else text = ((BomLkTp)combobox.SelectedItem).SoHoa;
            }
            
            var a = DataProvider.Ins.DB.BomLk.Where(x => x.SoHoa == text);
            if (a == null || a.Count() == 0)
            {

            }
            else
            {
                QuyCach[ins].Text = a.First().QuyCach;
                DisplayName[ins].Text = a.First().DisplayName;
            }            
        }

        private void OnMyComboBoxChanged1(object sender, SelectionChangedEventArgs e)
        {
            var combobox2 = sender as ComboBox;
            int ins = SoLo.IndexOf(combobox2);
            SoHoa[ins].Text = null;
            var text = ((DonHangTp)combobox2.SelectedItem).SoLo;
            var a = DataProvider.Ins.DB.DonHangTp.Where(x => x.SoLo == text);
            
            if (a == null || a.Count() == 0)
            {

            }
            else
            {
                string c = a.First().MaTp;
                var b = DataProvider.Ins.DB.BomLkTp.Where(x => x.MaTp == c && x.DapKhuon == true);
                SoHoa[ins].ItemsSource = new ObservableCollection<BomLkTp>(b);
                SoHoa[ins].DisplayMemberPath = "SoHoa";
            }

        }

        private void OnMyComboBoxChanged2(object sender, SelectionChangedEventArgs e)
        {
            
            var combobox = sender as ComboBox;
            int ins = pheSoHoa.IndexOf(combobox);
            string text = "";
            if (combobox.SelectedItem != null)  text = ((BomLk)combobox.SelectedItem).SoHoa;
            var a = DataProvider.Ins.DB.BomLk.Where(x => x.SoHoa == text);
            if (a == null || a.Count() == 0)
            {

            }
            else
            {
                pheQuyCach[ins].Text = a.First().QuyCach;
                pheDisplayName[ins].Text = a.First().DisplayName;
            }

        }

        void Taoidnhaplieu()
        {
            DateTime timetam = DateTime.Today;
            string timeint = "";
            int stt = 0;
            int maid = 0;
            bool flag = false;
            if (DkNgay != null) { timetam = (DateTime)DkNgay; }
            timeint = timetam.ToString("yyMMdd");
            maid = Int32.Parse(timeint, 0);
            stt = maid * 1000 + 1;
            for (int i = stt; flag == false; i++)
            {
                var check = DataProvider.Ins.DB.DKSanXuat.Where(x => x.MaPhieu == ("Dk-" + i.ToString()));
                if (check == null || check.Count() == 0)
                {
                    stt = i;
                    flag = true;
                }
            }
            DkId = "Dk-" + stt.ToString();
        }
        void Clearphieunhap()
        {
            DkNgay = null;
            DkCa = null;
            DkMaMay = null;
            DkNhanVien = null;
            DkId = null;
        }
    }
}
