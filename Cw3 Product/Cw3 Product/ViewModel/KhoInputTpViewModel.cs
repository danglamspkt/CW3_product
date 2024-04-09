using Cw3_Product.Model;
using Cw3_Product.UserControlKho;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using QRCoder.Xaml;
using QRCoder;
using System.Windows.Media;
using System.Security.Cryptography;
using SkiaSharp;
using System.IO;
using System.Windows.Media.Imaging;
using System.Data.SqlTypes;
using System.CodeDom;
using System.Reflection.Emit;
using System.Windows.Interop;
using System.Drawing;
using Image = System.Windows.Controls.Image;
using Cw3_Product.UserControlBOM;
using Microsoft.Win32;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using DocumentFormat.OpenXml.EMMA;
using OfficeOpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using Excel = Microsoft.Office.Interop.Excel;

namespace Cw3_Product.ViewModel
{
    public class KhoInputTpViewModel : BaseViewModel
    {
        //-------------------------Khai báo list hiển thị Số lô--------------------------------------------------
        private ObservableCollection<DonHangTp> _SoLoList;
        public ObservableCollection<DonHangTp> SoLoList { get => _SoLoList; set { _SoLoList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Đơn vị--------------------------------------------------
        private ObservableCollection<Unit> _donvilist;
        public ObservableCollection<Unit> donvilist { get => _donvilist; set { _donvilist = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Kho NL Input--------------------------------------------------
        private ObservableCollection<KhoThanhPhamInput> _NhapKhoTpList;
        public ObservableCollection<KhoThanhPhamInput> NhapKhoTpList { get => _NhapKhoTpList; set { _NhapKhoTpList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị NCC--------------------------------------------------
        private ObservableCollection<Supplier> _NCCList;
        public ObservableCollection<Supplier> NCCList { get => _NCCList; set { _NCCList = value; OnPropertyChanged(); } }

        private DateTime? _NgayCT;
        public DateTime? NgayCT { get => _NgayCT; set { _NgayCT = value; OnPropertyChanged(); } }

        private DateTime? _NgayNhap;
        public DateTime? NgayNhap { get => _NgayNhap; set { _NgayNhap = value; OnPropertyChanged(); } }

        private string _IdNCC;
        public string IdNCC { get => _IdNCC; set { _IdNCC = value; OnPropertyChanged(); } }

        private string _NCCDisplayName;
        public string NCCDisplayName { get => _NCCDisplayName; set { _NCCDisplayName = value; OnPropertyChanged(); } }

        private string _GhiChu;
        public string GhiChu { get => _GhiChu; set { _GhiChu = value; OnPropertyChanged(); } }

        private string _MaPhieu;
        public string MaPhieu { get => _MaPhieu; set { _MaPhieu = value; OnPropertyChanged(); } }

        private DateTime? _KhoOutputTpNgayStart;
        public DateTime? KhoOutputTpNgayStart { get => _KhoOutputTpNgayStart; set { _KhoOutputTpNgayStart = value; OnPropertyChanged(); } }

        private DateTime? _KhoOutputTpNgayEnd;
        public DateTime? KhoOutputTpNgayEnd { get => _KhoOutputTpNgayEnd; set { _KhoOutputTpNgayEnd = value; OnPropertyChanged(); } }

        private bool _fis;
        public bool fis { get => _fis; set { _fis = value; OnPropertyChanged(); } }

        private Model.KhoThanhPhamInput _SelectedItem;
        public Model.KhoThanhPhamInput SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged(); if (_SelectedItem != null)
                {
                    MaPhieu = SelectedItem.MaPhieu;

                }
            }
        }

        public ICommand ThemMaHang { get; set; }
        public ICommand XoaMaHang { get; set; }
        public ICommand ViewDon { get; set; }
        public ICommand ExportExcel { get; set; }
        public ICommand Infile { get; set; }
        public ICommand TaoDon { get; set; }
        public ICommand XacNhan { get; set; }
        public ICommand HuyDon { get; set; }
        public ICommand KhoNLdatechange { get; set; }
        public ICommand filtercommandInputNL { get; set; }
        public ICommand editcommandInputNL { get; set; }
        public ICommand supcommand { get; set; }
        public ICommand deletecommandInputNL { get; set; }



        List<TextBox> STT = new List<TextBox>();
        List<ComboBox> SoLo1 = new List<ComboBox>();
        List<ComboBox> MaTp1 = new List<ComboBox>();
        List<TextBox> SoLuongNhap1 = new List<TextBox>();
        List<ComboBox> DonVi1 = new List<ComboBox>();
        List<ComboBox> SoLo2 = new List<ComboBox>();
        List<ComboBox> MaTp2 = new List<ComboBox>();
        List<TextBox> SoLuongNhap2 = new List<TextBox>();
        List<ComboBox> DonVi2 = new List<ComboBox>();
        List<TextBox> KhoiLuong = new List<TextBox>();
        List<TextBox> PhieuGhiChu = new List<TextBox>();
        List<TextBox> Vitri = new List<TextBox>();
        List<TextBlock> MaQR = new List<TextBlock>();
        List<Image> QR = new List<Image>();
        List<byte[]> bitmap = new List<byte[]>();
        List<string> QRcode = new List<string>();
        List<Button> updateQR = new List<Button>();
        int inputt = 0;

        private Model.Supplier _SelectedItem1;
        public Model.Supplier SelectedItem1
        {
            get => _SelectedItem1; set
            {
                _SelectedItem1 = value; OnPropertyChanged(); if (_SelectedItem1 != null)
                {
                    NCCDisplayName = SelectedItem1.DisplayName;
                }
            }
        }

        private bool _FlagNew;
        public bool FlagNew { get => _FlagNew; set { _FlagNew = value; OnPropertyChanged(); } }

        private bool _unFlagNew;
        public bool unFlagNew { get => _unFlagNew; set { _unFlagNew = value; OnPropertyChanged(); } }


        public KhoInputTpViewModel() 
        {

            FlagNew = false;
            unFlagNew = true;
            if (PhieuNhapKhoThanhPhamUC.ContextMenuOpeningEvent != null) loadKhoNLInput();
            DateTime time = DateTime.Now;
            if (NgayCT != null) { time = (DateTime)NgayCT; }

            supcommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                SuplierWindows suplierWindows = new SuplierWindows();
                suplierWindows.ShowDialog();
            });

            Infile = new RelayCommand<object>((p) => { if (inputt == 0) return false; return true; }, (p) =>
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Vertical;
                stackPanel.Margin = new Thickness(10, 5, 0, 5);

                for (int i = 0; i < inputt; i++)
                {
                    StackPanel stackPanel2 = new StackPanel();
                    stackPanel2.Orientation = Orientation.Horizontal;
                    stackPanel2.Margin = new Thickness(50, 20, 0, 20);

                    TextBlock tbmaqr = new TextBlock();
                    tbmaqr.Text = MaQR[i].Text;
                    tbmaqr.VerticalAlignment = VerticalAlignment.Center;
                    tbmaqr.Margin = new Thickness(15, 0, 15, 0);
                    tbmaqr.Width = 250;

                    Image image = new Image { Width = 130, Height = 130, Stretch = Stretch.Uniform };
                    image.Margin = new Thickness(15, 0, 15, 0);

                    image.Source = QR[i].Source;
                    stackPanel2.Children.Add(tbmaqr);

                    stackPanel2.Children.Add(image);
                    stackPanel.Children.Add(stackPanel2);
                }

                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(stackPanel, "My First Print Job");
                }

            });

            ExportExcel = new RelayCommand<object>((p) => { if (inputt == 0) return false; return true; }, (p) =>
            {
                string filePath = "";
                // tạo SaveFileDialog để lưu file excel
                SaveFileDialog dialog = new SaveFileDialog();

                // chỉ lọc ra các file có định dạng Excel
                dialog.Filter = "Excel Workbook |*.xlsx";

                // Nếu mở file và chọn nơi lưu file thành công sẽ lưu đường dẫn lại dùng
                if (dialog.ShowDialog() == true)
                {
                    filePath = dialog.FileName;
                }

                // nếu đường dẫn null hoặc rỗng thì báo không hợp lệ và return hàm
                if (string.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                    return;
                }

                try
                {
                    using (ExcelPackage excel = new ExcelPackage())
                    {
                        // đặt tên người tạo file
                        excel.Workbook.Properties.Author = "Dang Lam";

                        // đặt tiêu đề cho file
                        excel.Workbook.Properties.Title = "Export Input LK";

                        //Tạo một sheet để làm việc trên đó
                        excel.Workbook.Worksheets.Add("InputLk");

                        // lấy sheet vừa add ra để thao tác
                        ExcelWorksheet ws = excel.Workbook.Worksheets[1];

                        // đặt tên cho sheet
                        ws.Name = "InputNl";
                        // fontsize mặc định cho cả sheet
                        ws.Cells.Style.Font.Size = 12;
                        // font family mặc định cho cả sheet
                        ws.Cells.Style.Font.Name = "Calibri";

                        //// Tạo danh sách các column header
                        //string[] arrColumnHeader = { "STT", "Ngày", "Mã phiếu", "Số lô 1", "Mã tp1", "Đơn vị 1", "Số lượng 1", "Số lô 2", "Mã tp2", "Đơn vị 2", "Số lượng 2", "Khối lượng", "vị trí", "Ghi chú", "Tem QR", "QR", "QR code" };

                        //// lấy ra số lượng cột cần dùng dựa vào số lượng header
                        //var countColHeader = arrColumnHeader.Count();

                        //// merge các column lại từ column 1 đến số column header
                        //// gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                        //ws.Cells[1, 1].Value = "PHIẾU NHẬP THÀNH PHẨM";
                        //ws.Cells[1, 1].Style.Font.Size = 24;
                        //ws.Row(1).Height = 31.5;
                        //ws.Cells[1, 1, 1, countColHeader].Merge = true;
                        //// in đậm
                        //ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                        //// căn giữa
                        //ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        //int colIndex = 1;
                        //int rowIndex = 2;

                        ////tạo các header từ column header đã tạo từ bên trên
                        //foreach (var item in arrColumnHeader)
                        //{
                        //    var cell = ws.Cells[rowIndex, colIndex];

                        //    //set màu thành gray
                        //    var fill = cell.Style.Fill;
                        //    fill.PatternType = ExcelFillStyle.Solid;
                        //    fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                        //    //căn chỉnh các border
                        //    var border = cell.Style.Border;
                        //    border.Bottom.Style =
                        //        border.Top.Style =
                        //        border.Left.Style =
                        //        border.Right.Style = ExcelBorderStyle.Thin;

                        //    //gán giá trị
                        //    cell.Value = item;
                        //    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        //    cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        //    colIndex++;
                        //}

                        //ws.Column(1).Width = 5;
                        //ws.Column(2).Width = 9.25;
                        //ws.Column(3).Width = 9.25;
                        //ws.Column(4).Width = 21.5;
                        //ws.Column(5).Width = 9.25;
                        //ws.Column(6).Width = 9.25;
                        //ws.Column(7).Width = 9.25;
                        //ws.Column(8).Width = 21.5;
                        //ws.Column(9).Width = 9.25;
                        //ws.Column(10).Width = 9.25;
                        //ws.Column(11).Width = 9.25;
                        //ws.Column(12).Width = 9.25;
                        //ws.Column(13).Width = 9.25;
                        //ws.Column(14).Width = 9.25;
                        //ws.Column(15).Width = 38;
                        //ws.Column(16).Width = 23.29;
                        //ws.Column(17).Width = 90;

                        ws.Row(1).Height = 198;
                        for (int i = 1; i <= inputt; i++)
                        {

                            //ws.Cells[i + 2, 15].Style.WrapText = true;
                            //ws.Cells[i + 2, 2].Style.Numberformat.Format = "dd/mm/yyyy";
                            //for (int j = 1; j <= countColHeader;)
                            //{
                            //    ws.Cells[i + 2, j++].Value = STT[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = NgayCT;
                            //    ws.Cells[i + 2, j++].Value = MaPhieu;
                            //    ws.Cells[i + 2, j++].Value = SoLo1[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = MaTp1[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = SoLuongNhap1[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = DonVi1[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = SoLo2[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = MaTp2[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = SoLuongNhap2[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = DonVi2[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = KhoiLuong[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = Vitri[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = PhieuGhiChu[i - 1].Text;
                            //    //căn chỉnh các border
                            //    var border = ws.Cells[i + 2, j].Style.Border;
                            //    border.Bottom.Style =
                            //        border.Top.Style =
                            //        border.Left.Style =
                            //        border.Right.Style = ExcelBorderStyle.Thin;
                            //    ws.Cells[i + 2, j++].Value = MaQR[i - 1].Text;
                            //    var border2 = ws.Cells[i + 2, j].Style.Border;
                            //    border2.Bottom.Style =
                            //        border2.Top.Style =
                            //        border2.Left.Style =
                            //        border2.Right.Style = ExcelBorderStyle.Thin;
                            //    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                            //    QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRcode[i - 1], QRCodeGenerator.ECCLevel.Q);
                            //    QRCode qrCode = new QRCode(qrCodeData);
                            //    Bitmap qrCodeImage = qrCode.GetGraphic(20, "black", "white", false);
                            //    var img = ws.Drawings.AddPicture(i.ToString(), qrCodeImage);
                            //    img.SetSize(145, 145);
                            //    img.SetPosition(i + 1, 9, j++ - 1, 12);
                            //    ws.Cells[i + 2, j++].Value = QRcode[i - 1];
                            //}
                            ws.Column(i * 2 - 1).Width = GetTrueColumnWidth(53.00);
                            ws.Column(i * 2).Width = GetTrueColumnWidth(24.00);
                            ws.Cells[1, i * 2 - 1].Value = MaQR[i - 1].Text;
                            ws.Cells[1, i * 2 - 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                            QRCodeGenerator qrGenerator = new QRCodeGenerator();
                            QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRcode[i - 1], QRCodeGenerator.ECCLevel.Q);
                            QRCode qrCode = new QRCode(qrCodeData);
                            Bitmap qrCodeImage = qrCode.GetGraphic(20, "black", "white", false);
                            var img = ws.Drawings.AddPicture(i.ToString(), qrCodeImage);
                            img.SetSize(145, 145);
                            img.SetPosition(0, 50, i * 2 - 1, 2);

                            
                            ws.Cells[1, i * 2 - 1].Style.WrapText = true;

                            ws.PrinterSettings.Orientation = eOrientation.Landscape;
                            ws.PrinterSettings.FitToPage = true;
                            ws.PrinterSettings.FitToWidth = 0;
                            ws.PrinterSettings.FitToHeight = 1;
                            ws.PrinterSettings.HeaderMargin = 0.0M;
                            ws.PrinterSettings.FooterMargin = 0.0M;
                            ws.PrinterSettings.TopMargin = 0.05M;
                            ws.PrinterSettings.BottomMargin = 0.05M;
                            ws.PrinterSettings.LeftMargin = 0.05M;
                            ws.PrinterSettings.RightMargin = 0.05M;

                        }

                        //Lưu file lại
                        Byte[] bin = excel.GetAsByteArray();
                        File.WriteAllBytes(filePath, bin);
                    }
                    MessageBox.Show("Xuất excel thành công!");
                    var excelApp = new Excel.Application();
                    excelApp.Visible = true;
                    excelApp.Workbooks.Open(filePath);
                }
                catch (Exception EE)
                {
                    MessageBox.Show("Có lỗi khi lưu file!");
                }

            });

            TaoDon = new RelayCommand<StackPanel>((p) => { if (FlagNew == true) return false; return true; }, (p) =>
            {
                NgayCT = DateTime.Today;
                NgayNhap = DateTime.Today;
                Taoidnhaplieu();
                SoLoList = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp.Where(x => x.TinhTrang == "Sản xuất"));
                donvilist = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
                NCCList = new ObservableCollection<Supplier>(DataProvider.Ins.DB.Supplier);
                FlagNew = true;
                unFlagNew = false;
                fis = true;
                inputt = 0;
                p.Children.Clear();
                STT.Clear();
                SoLo1.Clear();
                MaTp1.Clear();
                SoLuongNhap1.Clear();
                DonVi1.Clear();
                SoLo2.Clear();
                MaTp2.Clear();
                SoLuongNhap2.Clear();
                DonVi2.Clear();
                KhoiLuong.Clear();
                PhieuGhiChu.Clear();
                QR.Clear();
                QRcode.Clear();
                MaQR.Clear();
                updateQR.Clear();
                Vitri.Clear();
                bitmap.Clear();

            });

            XacNhan = new RelayCommand<StackPanel>((p) => { if (FlagNew != true) return false; return true; }, (p) =>
            {
                var check = MessageBox.Show("Bạn chắc chắn muốn xác nhận đơn hàng?", "Xác nhận đơn", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (check == MessageBoxResult.OK)
                {
                    try
                    {
                        //Taoidnhaplieu();
                        var b = DataProvider.Ins.DB.KhoThanhPhamInputInfo.Where(x => x.MaPhieu == MaPhieu);
                        while (b.Count() > 0)
                        {
                            DataProvider.Ins.DB.KhoThanhPhamInputInfo.Remove(b.First());
                            DataProvider.Ins.DB.SaveChanges();
                            b = DataProvider.Ins.DB.KhoThanhPhamInputInfo.Where(x => x.MaPhieu == MaPhieu);
                        }
                        var a = DataProvider.Ins.DB.KhoThanhPhamInput.Where(x => x.MaPhieu == MaPhieu);
                        while (a.Count() > 0)
                        {
                            DataProvider.Ins.DB.KhoThanhPhamInput.Remove(a.First());
                            DataProvider.Ins.DB.SaveChanges();
                            a = DataProvider.Ins.DB.KhoThanhPhamInput.Where(x => x.MaPhieu == MaPhieu);
                        }

                        KhoThanhPhamInput KhoThanhPhamInput = new KhoThanhPhamInput { MaPhieu = MaPhieu, DateCT = NgayCT, DateNhap = NgayNhap, IdSup = IdNCC, TenNCC = NCCDisplayName, GhiChu = GhiChu, UserName = Cw3_Product.Properties.Settings.Default.account };
                        DataProvider.Ins.DB.KhoThanhPhamInput.Add(KhoThanhPhamInput);
                        DataProvider.Ins.DB.SaveChanges();

                        KhoThanhPhamInputInfo KhoThanhPhamInputInfo = new KhoThanhPhamInputInfo();

                        if (inputt > 0) for (int j = 0; j < inputt; j++)
                            {
                                KhoThanhPhamInputInfo.MaPhieu = MaPhieu;
                                KhoThanhPhamInputInfo.SoLo1 = SoLo1[j].Text;
                                KhoThanhPhamInputInfo.MaTp1 = MaTp1[j].Text;
                                KhoThanhPhamInputInfo.SoLuongNhap1 = Int32.Parse(SoLuongNhap1[j].Text);
                                KhoThanhPhamInputInfo.IdU1 = DonVi1[j].Text;
                                KhoThanhPhamInputInfo.SoLo2 = SoLo2[j].Text;
                                KhoThanhPhamInputInfo.MaTp2 = MaTp2[j].Text;
                                KhoThanhPhamInputInfo.SoLuongNhap2 = Int32.Parse(SoLuongNhap2[j].Text);
                                KhoThanhPhamInputInfo.IdU2 = DonVi2[j].Text;
                                KhoThanhPhamInputInfo.KhoiLuongKien = Int32.Parse(KhoiLuong[j].Text);
                                KhoThanhPhamInputInfo.MaKho = "WAR03     ";
                                KhoThanhPhamInputInfo.GhiChu = PhieuGhiChu[j].Text;
                                KhoThanhPhamInputInfo.ViTri = Vitri[j].Text;
                                KhoThanhPhamInputInfo.UserName = Cw3_Product.Properties.Settings.Default.account;
                                KhoThanhPhamInputInfo.QRcode = QRcode[j];

                                BitmapImage bitmapSource = (BitmapImage)QR[j].Source;

                                var imageBuffer = BitmapSourceToByteArray(bitmapSource);
                                KhoThanhPhamInputInfo.QRimg = imageBuffer;
                                var c = DataProvider.Ins.DB.KhoThanhPhamOutputInfo.Where(x => x.QRcode == KhoThanhPhamInputInfo.QRcode);
                                if (c == null || c.Count() == 0) KhoThanhPhamInputInfo.TinhTrang = "Tồn";
                                else KhoThanhPhamInputInfo.TinhTrang = null;

                                DataProvider.Ins.DB.KhoThanhPhamInputInfo.Add(KhoThanhPhamInputInfo);
                                DataProvider.Ins.DB.SaveChanges();
                            }


                        p.Children.Clear();
                        STT.Clear();
                        SoLo1.Clear();
                        MaTp1.Clear();
                        SoLuongNhap1.Clear();
                        DonVi1.Clear();
                        SoLo2.Clear();
                        MaTp2.Clear();
                        SoLuongNhap2.Clear();
                        DonVi2.Clear();
                        KhoiLuong.Clear();
                        PhieuGhiChu.Clear();
                        QR.Clear();
                        QRcode.Clear();
                        MaQR.Clear();
                        updateQR.Clear();
                        Vitri.Clear();
                        bitmap.Clear();
                        inputt = 0;

                        Clearphieunhap();
                        FlagNew = false;
                        unFlagNew = true;
                        loadKhoNLInput();
                    }
                    catch (Exception E)
                    {
                        var b = DataProvider.Ins.DB.KhoThanhPhamInputInfo.Where(x => x.MaPhieu == MaPhieu);
                        while (b.Count() > 0)
                        {
                            DataProvider.Ins.DB.KhoThanhPhamInputInfo.Remove(b.First());
                            DataProvider.Ins.DB.SaveChanges();
                            b = DataProvider.Ins.DB.KhoThanhPhamInputInfo.Where(x => x.MaPhieu == MaPhieu);
                        }
                        var a = DataProvider.Ins.DB.KhoThanhPhamInput.Where(x => x.MaPhieu == MaPhieu);
                        while (a.Count() > 0)
                        {
                            DataProvider.Ins.DB.KhoThanhPhamInput.Remove(a.First());
                            DataProvider.Ins.DB.SaveChanges();
                            a = DataProvider.Ins.DB.KhoThanhPhamInput.Where(x => x.MaPhieu == MaPhieu);
                        }
                        MessageBox.Show("Dữ liệu nhập bị lỗi! \n" + E, "Dữ liệu nhập!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (check == MessageBoxResult.Cancel)
                {

                }

            });

            HuyDon = new RelayCommand<StackPanel>((p) => { if (FlagNew != true) return false; return true; }, (p) =>
            {

                var check = MessageBox.Show("Bạn chắc chắn muốn hủy đơn hàng?", "Hủy đơn", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (check == MessageBoxResult.OK)
                {
                    p.Children.Clear();
                    STT.Clear();
                    SoLo1.Clear();
                    MaTp1.Clear();
                    SoLuongNhap1.Clear();
                    DonVi1.Clear();
                    SoLo2.Clear();
                    MaTp2.Clear();
                    SoLuongNhap2.Clear();
                    DonVi2.Clear();
                    KhoiLuong.Clear();
                    PhieuGhiChu.Clear();
                    QR.Clear();
                    QRcode.Clear();
                    MaQR.Clear();
                    updateQR.Clear();
                    Vitri.Clear();
                    bitmap.Clear();
                    inputt = 0;

                    Clearphieunhap();

                    FlagNew = false;
                    unFlagNew = true;
                }
                else if (check == MessageBoxResult.Cancel)
                {

                }

            });

            KhoNLdatechange = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Taoidnhaplieu();
            });

            ThemMaHang = new RelayCommand<StackPanel>((p) => { return true; }, (p) =>
            {
                inputt++;
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;
                stackPanel.Margin = new Thickness(10, 5, 0, 5);

                StackPanel stackPanelgroup = new StackPanel();
                stackPanelgroup.Orientation = Orientation.Vertical;
                stackPanelgroup.VerticalAlignment = VerticalAlignment.Center;
                stackPanelgroup.Margin = new Thickness(0, 0, 0, 0);

                StackPanel stackPanelup = new StackPanel();
                stackPanelup.Orientation = Orientation.Horizontal;
                stackPanelup.VerticalAlignment = VerticalAlignment.Center;
                stackPanelup.Margin = new Thickness(0, 5, 0, 5);

                StackPanel stackPaneldown = new StackPanel();
                stackPaneldown.Orientation = Orientation.Horizontal;
                stackPaneldown.VerticalAlignment = VerticalAlignment.Center;
                stackPaneldown.Margin = new Thickness(0, 5, 0, 5);

                TextBox Stt = new TextBox();
                Stt.IsReadOnly = true;
                Stt.TextAlignment = TextAlignment.Center;
                Stt.Text = inputt.ToString();
                Stt.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(Stt, "STT");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                Stt.Width = 70;
                Stt.Margin = new Thickness(5, 0, 15, 0);
                STT.Insert(inputt - 1, Stt);
                stackPanel.Children.Add(STT[inputt - 1]);

                ComboBox cbMMH = new ComboBox();
                cbMMH.ItemsSource = SoLoList;
                cbMMH.DisplayMemberPath = "SoLo";
                cbMMH.Text = null;
                cbMMH.IsEnabled = true;
                cbMMH.IsEditable = false;
                cbMMH.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cbMMH, "Mã hàng");
                cbMMH.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged);
                cbMMH.Width = 190;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbMMH, 50);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbMMH, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                cbMMH.Margin = new Thickness(15, 0, 15, 0);
                SoLo1.Insert(inputt - 1, cbMMH);
                stackPanelup.Children.Add(SoLo1[inputt - 1]);

                ComboBox cbMMH2 = new ComboBox();
                cbMMH2.ItemsSource = SoLoList;
                cbMMH2.DisplayMemberPath = "SoLo";
                cbMMH2.Text = null;
                cbMMH2.IsEnabled = true;
                cbMMH2.IsEditable = false;
                cbMMH2.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cbMMH2, "Mã hàng");
                cbMMH2.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged2);
                cbMMH2.Width = 190;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbMMH2, 50);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbMMH2, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                cbMMH2.Margin = new Thickness(15, 0, 15, 0);
                SoLo2.Insert(inputt - 1, cbMMH2);
                stackPaneldown.Children.Add(SoLo2[inputt - 1]);

                ComboBox combobox3 = new ComboBox();
                combobox3.ItemsSource = SoLoList;
                combobox3.DisplayMemberPath = "MaTp";
                combobox3.Text = null;
                combobox3.IsEnabled = true;
                combobox3.IsEditable = false;
                combobox3.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(combobox3, "Mã Bánh xe");
                combobox3.Width = 140;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(combobox3, 50);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(combobox3, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                combobox3.Margin = new Thickness(15, 0, 15, 0);
                MaTp1.Insert(inputt - 1, combobox3);
                stackPanelup.Children.Add(MaTp1[inputt - 1]);

                ComboBox combobox4 = new ComboBox();
                combobox4.ItemsSource = SoLoList;
                combobox4.DisplayMemberPath = "MaTp";
                combobox4.Text = null;
                combobox4.IsEnabled = true;
                combobox4.IsEditable = false;
                combobox4.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(combobox4, "Mã Bánh xe");
                combobox4.Width = 140;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(combobox4, 50);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(combobox4, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                combobox4.Margin = new Thickness(15, 0, 15, 0);
                MaTp2.Insert(inputt - 1, combobox4);
                stackPaneldown.Children.Add(MaTp2[inputt - 1]);

                TextBox tcsoluong = new TextBox();
                tcsoluong.IsReadOnly = false;
                tcsoluong.TextAlignment = TextAlignment.Right;
                tcsoluong.Text = 0.ToString();
                tcsoluong.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tcsoluong, "Số lượng");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tcsoluong.Width = 80;
                tcsoluong.Margin = new Thickness(15, 0, 15, 0);
                SoLuongNhap1.Insert(inputt - 1, tcsoluong);
                stackPanelup.Children.Add(SoLuongNhap1[inputt - 1]);

                TextBox tcsoluong2 = new TextBox();
                tcsoluong2.IsReadOnly = false;
                tcsoluong2.TextAlignment = TextAlignment.Right;
                tcsoluong2.Text = 0.ToString();
                tcsoluong2.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tcsoluong2, "Số lượng");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tcsoluong2.Width = 80;
                tcsoluong2.Margin = new Thickness(15, 0, 15, 0);
                SoLuongNhap2.Insert(inputt - 1, tcsoluong2);
                stackPaneldown.Children.Add(SoLuongNhap2[inputt - 1]);

                ComboBox cbdonvi = new ComboBox();
                cbdonvi.ItemsSource = donvilist;
                cbdonvi.DisplayMemberPath = "IdU";
                cbdonvi.Text = null;
                cbdonvi.IsEnabled = true;
                cbdonvi.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cbdonvi, "Đơn vị");
                cbdonvi.Width = 60;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbdonvi, 50);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbdonvi, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                cbdonvi.Margin = new Thickness(15, 0, 0, 0);
                DonVi1.Insert(inputt - 1, cbdonvi);
                stackPanelup.Children.Add(DonVi1[inputt - 1]);

                ComboBox cbdonvi2 = new ComboBox();
                cbdonvi2.ItemsSource = donvilist;
                cbdonvi2.DisplayMemberPath = "IdU";
                cbdonvi2.Text = null;
                cbdonvi2.IsEnabled = true;
                cbdonvi2.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cbdonvi2, "Đơn vị");
                cbdonvi2.Width = 60;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbdonvi2, 50);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbdonvi2, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                cbdonvi2.Margin = new Thickness(15, 0, 0, 0);
                DonVi2.Insert(inputt - 1, cbdonvi2);
                stackPaneldown.Children.Add(DonVi2[inputt - 1]);

                Button unit = new Button();
                unit.Content = "...";
                unit.Padding = new Thickness(2, 0, 2, 0);
                unit.Background = System.Windows.Media.Brushes.LightGray;
                unit.Margin = new Thickness(5, 0, 15, 0);
                unit.Click += (s, e) =>
                {
                    UnitWindows unitWindows = new UnitWindows();
                    unitWindows.Height = 700;
                    unitWindows.Width = 700;
                    unitWindows.ShowDialog();
                };
                stackPanelup.Children.Add(unit);

                Button unit2 = new Button();
                unit2.Content = "...";
                unit2.Padding = new Thickness(2, 0, 2, 0);
                unit2.Background = System.Windows.Media.Brushes.LightGray;
                unit2.Margin = new Thickness(5, 0, 15, 0);
                unit2.Click += (s, e) =>
                {
                    UnitWindows unitWindows = new UnitWindows();
                    unitWindows.Height = 700;
                    unitWindows.Width = 700;
                    unitWindows.ShowDialog();
                };
                stackPaneldown.Children.Add(unit2);

                stackPanelgroup.Children.Add(stackPanelup);
                stackPanelgroup.Children.Add(stackPaneldown);
                stackPanel.Children.Add(stackPanelgroup);

                TextBox tbkhoiluong = new TextBox();
                tbkhoiluong.IsReadOnly = false;
                tbkhoiluong.TextAlignment = TextAlignment.Right;
                tbkhoiluong.Text = 0.ToString();
                tbkhoiluong.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbkhoiluong, "Khối lượng");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbkhoiluong.Width = 80;
                tbkhoiluong.Margin = new Thickness(15, 0, 15, 0);
                KhoiLuong.Insert(inputt - 1, tbkhoiluong);
                stackPanel.Children.Add(KhoiLuong[inputt - 1]);

                TextBox tbvitri = new TextBox();
                tbvitri.IsReadOnly = false;
                tbvitri.TextAlignment = TextAlignment.Right;
                tbvitri.Text = null;
                tbvitri.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbvitri, "Vị trí");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbvitri.Width = 80;
                tbvitri.Margin = new Thickness(15, 0, 15, 0);
                Vitri.Insert(inputt - 1, tbvitri);
                stackPanel.Children.Add(Vitri[inputt - 1]);

                TextBox tbghichu = new TextBox();
                tbghichu.IsReadOnly = false;
                tbghichu.TextAlignment = TextAlignment.Center;
                tbghichu.Text = null;
                tbghichu.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbghichu, "Ghi chú");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbghichu.Width = 120;
                tbghichu.Margin = new Thickness(15, 0, 15, 0);
                PhieuGhiChu.Insert(inputt - 1, tbghichu);
                stackPanel.Children.Add(PhieuGhiChu[inputt - 1]);

                TextBlock tbmaqr = new TextBlock();
                string quycach1 = null;
                string mtp1 = null;
                mtp1 = MaTp1[inputt - 1].Text;
                if ( mtp1 != null) quycach1 = DataProvider.Ins.DB.BomTp.Where(x => x.MaTp == mtp1).First().DisplayName;
                string bxe1 = null;
                bxe1 = "\n------------\n Số lô: " + SoLo1[inputt - 1].Text + "\n Mã bánh xe: " + MaTp1[inputt - 1].Text + "\n Display Name: " + quycach1 + "\n Số lượng: " + SoLuongNhap1[inputt - 1].Text + " " + DonVi1[inputt - 1].Text;
                string bxe2 = null;
                string mtp2 = null;
                mtp2 = MaTp2[inputt - 1].Text;
                string quycach2 = null;
                if (mtp2 != null) quycach2 = DataProvider.Ins.DB.BomTp.Where(x => x.MaTp == mtp2).First().DisplayName;
                if (string.IsNullOrEmpty(SoLo2[inputt - 1].Text) || string.IsNullOrEmpty(MaTp2[inputt - 1].Text) || string.IsNullOrEmpty(SoLuongNhap2[inputt - 1].Text)) bxe2= null;
                else bxe2= "\n------------\n Số lô: " + SoLo2[inputt - 1].Text + "\n Mã bánh xe: " + MaTp2[inputt - 1].Text + "\n Display Name: " + quycach2 + "\n Số lượng: " + SoLuongNhap2[inputt - 1].Text + " " + DonVi2[inputt - 1].Text;
                tbmaqr.Text = "ID: " + MaPhieu + "-" + inputt + "\nNgày: " + time.ToString("dd/MM/yyyy") + bxe1 + bxe2;
                tbmaqr.VerticalAlignment = VerticalAlignment.Center;
                tbmaqr.Margin = new Thickness(15, 0, 15, 0);
                tbmaqr.Width = 250;
                MaQR.Insert(inputt - 1, tbmaqr);
                stackPanel.Children.Add(MaQR[inputt - 1]);

                QRcode.Insert(inputt - 1, MaPhieu + "-" + SoLo1[inputt - 1].Text + "-" + MaTp1[inputt - 1].Text + "-" + SoLuongNhap1[inputt - 1].Text + "-" + SoLo2[inputt - 1].Text + "-" + MaTp2[inputt - 1].Text + "-" + SoLuongNhap2[inputt - 1].Text + "-" + KhoiLuong[inputt - 1].Text + "-" + STT[inputt - 1].Text);

                Image image = new Image { Width = 130, Height = 130, Stretch = Stretch.Uniform };
                image.Margin = new Thickness(15, 0, 15, 0);
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRcode[inputt - 1], QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);
                Bitmap qrCodeImage = qrCode.GetGraphic(20, "black", "white", false);
                image.Source = BitmapToImageSource(qrCodeImage);
                QR.Insert(inputt - 1, image);
                QR[inputt - 1].Source = image.Source;
                bitmap.Insert(inputt - 1, BitmapSourceToByteArray((BitmapSource)QR[inputt - 1].Source));
                stackPanel.Children.Add(QR[inputt - 1]);

                MaterialDesignThemes.Wpf.PackIcon icon = new MaterialDesignThemes.Wpf.PackIcon();
                icon.Height = 24;
                icon.Width = 24;
                icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Update;
                icon.Foreground = System.Windows.Media.Brushes.Black;

                Button upd = new Button();
                upd.Content = icon;
                upd.Margin = new Thickness(15, 0, 15, 0);
                upd.Click += (s, e) =>
                {
                    var button = s as Button;
                    int ins = updateQR.IndexOf(button);
                    QRcode.RemoveAt(ins);
                    QRcode.Insert(ins, MaPhieu + "-" + SoLo1[ins].Text + "-" + MaTp1[ins].Text + "-" + SoLuongNhap1[ins].Text + "-" + SoLo2[ins].Text + "-" + MaTp2[ins].Text + "-" + SoLuongNhap2[ins].Text + "-" + KhoiLuong[ins].Text + "-" + STT[ins].Text);

                    string quycach11 = null;
                    string mtp11 = null;
                    mtp11 = MaTp1[ins].Text;
                    if (mtp11 != null) quycach11 = DataProvider.Ins.DB.BomTp.Where(x => x.MaTp == mtp11).First().DisplayName;
                    string bxe11 = null;
                    bxe11 = "\n------------\n Số lô: " + SoLo1[ins].Text + "\n Mã bánh xe: " + MaTp1[ins].Text + "\n Display Name: " + quycach11 + "\n Số lượng: " + SoLuongNhap1[ins].Text + " " + DonVi1[ins].Text;
                    string bxe22 = null;
                    string mtp22 = null;
                    mtp22 = MaTp2[ins].Text;
                    string quycach22 = null;
                    if (mtp22 != null) quycach22 = DataProvider.Ins.DB.BomTp.Where(x => x.MaTp == mtp22).First().DisplayName;
                    if (string.IsNullOrEmpty(SoLo2[ins].Text) || string.IsNullOrEmpty(MaTp2[ins].Text) || string.IsNullOrEmpty(SoLuongNhap2[ins].Text)) bxe2 = null;
                    else bxe22 = "\n------------\n Số lô: " + SoLo2[ins].Text + "\n Mã bánh xe: " + MaTp2[ins].Text + "\n Display Name: " + quycach22 + "\n Số lượng: " + SoLuongNhap2[ins].Text + " " + DonVi2[ins].Text;

                    MaQR[ins].Text = "ID: " + MaPhieu + "-" + (ins + 1) + "\nNgày: " + time.ToString("dd/MM/yyyy") + bxe11 + bxe22;

                    QRCodeGenerator qrGenerators = new QRCodeGenerator();
                    QRCodeData qrCodeDatas = qrGenerators.CreateQrCode(QRcode[ins], QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCodes = new QRCode(qrCodeDatas);
                    Bitmap qrCodeImages = qrCodes.GetGraphic(20, "black", "white", false);

                    image.Source = BitmapToImageSource(qrCodeImages);
                    QR.RemoveAt(ins);
                    QR.Insert(ins, image);
                    bitmap.RemoveAt(ins);
                    bitmap.Insert(ins, BitmapSourceToByteArray((BitmapSource)QR[ins].Source));

                };
                updateQR.Insert(inputt - 1, upd);
                stackPanel.Children.Add(updateQR[inputt - 1]);

                p.Children.Add(stackPanel);
            });

            XoaMaHang = new RelayCommand<StackPanel>((p) => { if (inputt == 0) return false; else return true; }, (p) =>
            {
                var a = inputt - 1;
                p.Children.RemoveAt(a);
                STT.RemoveAt(a);
                SoLo1.RemoveAt(a);
                MaTp1.RemoveAt(a);
                SoLuongNhap1.RemoveAt(a);
                DonVi1.RemoveAt(a);
                SoLo2.RemoveAt(a);
                MaTp2.RemoveAt(a);
                SoLuongNhap2.RemoveAt(a);
                DonVi2.RemoveAt(a);
                KhoiLuong.RemoveAt(a);
                PhieuGhiChu.RemoveAt(a);
                QR.RemoveAt(a);
                QRcode.RemoveAt(a);
                MaQR.RemoveAt(a);
                updateQR.RemoveAt(a);
                Vitri.RemoveAt(a);
                bitmap.RemoveAt(a);
                inputt -= 1;

            });

            filtercommandInputNL = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                loadKhoNLInput();
            });

            ViewDon = new RelayCommand<StackPanel>((p) => { if (FlagNew == true || string.IsNullOrEmpty(MaPhieu)) return false; return true; }, (p) =>
            {
                fis = true;

                SoLoList = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp);
                donvilist = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
                NCCList = new ObservableCollection<Supplier>(DataProvider.Ins.DB.Supplier);

                p.Children.Clear();
                STT.Clear();
                SoLo1.Clear();
                MaTp1.Clear();
                SoLuongNhap1.Clear();
                DonVi1.Clear();
                SoLo2.Clear();
                MaTp2.Clear();
                SoLuongNhap2.Clear();
                DonVi2.Clear();
                KhoiLuong.Clear();
                PhieuGhiChu.Clear();
                QR.Clear();
                QRcode.Clear();
                MaQR.Clear();
                updateQR.Clear();
                Vitri.Clear();
                bitmap.Clear();
                inputt = 0;


                var doninput = DataProvider.Ins.DB.KhoThanhPhamInput.Where(x => x.MaPhieu == MaPhieu).First();
                var doninputinfo = DataProvider.Ins.DB.KhoThanhPhamInputInfo.Where(x => x.MaPhieu == doninput.MaPhieu);

                NgayCT = doninput.DateCT;
                NgayNhap = doninput.DateNhap;
                IdNCC = doninput.IdSup;
                NCCDisplayName = doninput.TenNCC;
                GhiChu = doninput.GhiChu;
                MaPhieu = doninput.MaPhieu;

                foreach (var item in doninputinfo)
                {
                    inputt++;
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Orientation = Orientation.Horizontal;
                    stackPanel.Margin = new Thickness(10, 5, 0, 5);

                    StackPanel stackPanelgroup = new StackPanel();
                    stackPanelgroup.Orientation = Orientation.Vertical;
                    stackPanelgroup.VerticalAlignment = VerticalAlignment.Center;
                    stackPanelgroup.Margin = new Thickness(0, 0, 0, 0);

                    StackPanel stackPanelup = new StackPanel();
                    stackPanelup.Orientation = Orientation.Horizontal;
                    stackPanelup.VerticalAlignment = VerticalAlignment.Center;
                    stackPanelup.Margin = new Thickness(0, 5, 0, 5);

                    StackPanel stackPaneldown = new StackPanel();
                    stackPaneldown.Orientation = Orientation.Horizontal;
                    stackPaneldown.VerticalAlignment = VerticalAlignment.Center;
                    stackPaneldown.Margin = new Thickness(0, 5, 0, 5);

                    TextBox Stt = new TextBox();
                    Stt.IsReadOnly = true;
                    Stt.TextAlignment = TextAlignment.Center;
                    Stt.Text = inputt.ToString();
                    Stt.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(Stt, "STT");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    Stt.Width = 70;
                    Stt.Margin = new Thickness(5, 0, 15, 0);
                    STT.Insert(inputt - 1, Stt);
                    stackPanel.Children.Add(STT[inputt - 1]);

                    ComboBox cbMMH = new ComboBox();
                    cbMMH.ItemsSource = SoLoList;
                    cbMMH.DisplayMemberPath = "SoLo";
                    cbMMH.Text = item.SoLo1;
                    cbMMH.IsEnabled = false;
                    cbMMH.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(cbMMH, "Mã hàng");
                    cbMMH.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged);
                    cbMMH.Width = 190;
                    MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbMMH, 50);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbMMH, 0.26);
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    cbMMH.Margin = new Thickness(15, 0, 15, 0);
                    SoLo1.Insert(inputt - 1, cbMMH);
                    stackPanelup.Children.Add(SoLo1[inputt - 1]);

                    ComboBox cbMMH2 = new ComboBox();
                    cbMMH2.ItemsSource = SoLoList;
                    cbMMH2.DisplayMemberPath = "SoLo";
                    cbMMH2.Text = item.SoLo2;
                    cbMMH2.IsEnabled = false;
                    cbMMH2.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(cbMMH2, "Mã hàng");
                    cbMMH2.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged2);
                    cbMMH2.Width = 190;
                    MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbMMH2, 50);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbMMH2, 0.26);
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    cbMMH2.Margin = new Thickness(15, 0, 15, 0);
                    SoLo2.Insert(inputt - 1, cbMMH2);
                    stackPaneldown.Children.Add(SoLo2[inputt - 1]);

                    ComboBox combobox3 = new ComboBox();
                    combobox3.ItemsSource = SoLoList;
                    combobox3.DisplayMemberPath = "MaTp";
                    combobox3.Text = item.MaTp1;
                    combobox3.IsEnabled = false;
                    combobox3.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(combobox3, "Mã Bánh xe");
                    combobox3.Width = 140;
                    MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(combobox3, 50);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(combobox3, 0.26);
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    combobox3.Margin = new Thickness(15, 0, 15, 0);
                    MaTp1.Insert(inputt - 1, combobox3);
                    stackPanelup.Children.Add(MaTp1[inputt - 1]);

                    ComboBox combobox4 = new ComboBox();
                    combobox4.ItemsSource = SoLoList;
                    combobox4.DisplayMemberPath = "MaTp";
                    combobox4.Text = item.MaTp2;
                    combobox4.IsEnabled = false;
                    combobox4.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(combobox4, "Mã Bánh xe");
                    combobox4.Width = 140;
                    MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(combobox4, 50);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(combobox4, 0.26);
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    combobox4.Margin = new Thickness(15, 0, 15, 0);
                    MaTp2.Insert(inputt - 1, combobox4);
                    stackPaneldown.Children.Add(MaTp2[inputt - 1]);

                    TextBox tcsoluong = new TextBox();
                    tcsoluong.IsReadOnly = true;
                    tcsoluong.TextAlignment = TextAlignment.Right;
                    tcsoluong.Text = item.SoLuongNhap1.ToString();
                    tcsoluong.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(tcsoluong, "Số lượng");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    tcsoluong.Width = 80;
                    tcsoluong.Margin = new Thickness(15, 0, 15, 0);
                    SoLuongNhap1.Insert(inputt - 1, tcsoluong);
                    stackPanelup.Children.Add(SoLuongNhap1[inputt - 1]);

                    TextBox tcsoluong2 = new TextBox();
                    tcsoluong2.IsReadOnly = true;
                    tcsoluong2.TextAlignment = TextAlignment.Right;
                    tcsoluong2.Text = item.SoLuongNhap2.ToString();
                    tcsoluong2.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(tcsoluong2, "Số lượng");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    tcsoluong2.Width = 80;
                    tcsoluong2.Margin = new Thickness(15, 0, 15, 0);
                    SoLuongNhap2.Insert(inputt - 1, tcsoluong2);
                    stackPaneldown.Children.Add(SoLuongNhap2[inputt - 1]);

                    ComboBox cbdonvi = new ComboBox();
                    cbdonvi.ItemsSource = donvilist;
                    cbdonvi.DisplayMemberPath = "IdU";
                    cbdonvi.Text = item.IdU1;
                    cbdonvi.IsEnabled = false;
                    cbdonvi.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(cbdonvi, "Đơn vị");
                    cbdonvi.Width = 60;
                    MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbdonvi, 50);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbdonvi, 0.26);
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    cbdonvi.Margin = new Thickness(15, 0, 0, 0);
                    DonVi1.Insert(inputt - 1, cbdonvi);
                    stackPanelup.Children.Add(DonVi1[inputt - 1]);

                    ComboBox cbdonvi2 = new ComboBox();
                    cbdonvi2.ItemsSource = donvilist;
                    cbdonvi2.DisplayMemberPath = "IdU";
                    cbdonvi2.Text = item.IdU2;
                    cbdonvi2.IsEnabled = false;
                    cbdonvi2.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(cbdonvi2, "Đơn vị");
                    cbdonvi2.Width = 60;
                    MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbdonvi2, 50);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbdonvi2, 0.26);
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    cbdonvi2.Margin = new Thickness(15, 0, 0, 0);
                    DonVi2.Insert(inputt - 1, cbdonvi2);
                    stackPaneldown.Children.Add(DonVi2[inputt - 1]);

                    Button unit = new Button();
                    unit.Content = "...";
                    unit.Padding = new Thickness(2, 0, 2, 0);
                    unit.Background = System.Windows.Media.Brushes.LightGray;
                    unit.Margin = new Thickness(5, 0, 15, 0);
                    unit.Click += (s, e) =>
                    {
                        UnitWindows unitWindows = new UnitWindows();
                        unitWindows.Height = 700;
                        unitWindows.Width = 700;
                        unitWindows.ShowDialog();
                    };
                    stackPanelup.Children.Add(unit);

                    Button unit2 = new Button();
                    unit2.Content = "...";
                    unit2.Padding = new Thickness(2, 0, 2, 0);
                    unit2.Background = System.Windows.Media.Brushes.LightGray;
                    unit2.Margin = new Thickness(5, 0, 15, 0);
                    unit2.Click += (s, e) =>
                    {
                        UnitWindows unitWindows = new UnitWindows();
                        unitWindows.Height = 700;
                        unitWindows.Width = 700;
                        unitWindows.ShowDialog();
                    };
                    stackPaneldown.Children.Add(unit2);

                    stackPanelgroup.Children.Add(stackPanelup);
                    stackPanelgroup.Children.Add(stackPaneldown);
                    stackPanel.Children.Add(stackPanelgroup);

                    TextBox tbkhoiluong = new TextBox();
                    tbkhoiluong.IsReadOnly = true;
                    tbkhoiluong.TextAlignment = TextAlignment.Right;
                    tbkhoiluong.Text = item.KhoiLuongKien.ToString();
                    tbkhoiluong.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(tbkhoiluong, "Khối lượng");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    tbkhoiluong.Width = 80;
                    tbkhoiluong.Margin = new Thickness(15, 0, 15, 0);
                    KhoiLuong.Insert(inputt - 1, tbkhoiluong);
                    stackPanel.Children.Add(KhoiLuong[inputt - 1]);

                    TextBox tbvitri = new TextBox();
                    tbvitri.IsReadOnly = true;
                    tbvitri.TextAlignment = TextAlignment.Right;
                    tbvitri.Text = item.ViTri;
                    tbvitri.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(tbvitri, "Vị trí");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    tbvitri.Width = 80;
                    tbvitri.Margin = new Thickness(15, 0, 15, 0);
                    Vitri.Insert(inputt - 1, tbvitri);
                    stackPanel.Children.Add(Vitri[inputt - 1]);

                    TextBox tbghichu = new TextBox();
                    tbghichu.IsReadOnly = true;
                    tbghichu.TextAlignment = TextAlignment.Center;
                    tbghichu.Text = item.GhiChu;
                    tbghichu.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(tbghichu, "Ghi chú");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    tbghichu.Width = 120;
                    tbghichu.Margin = new Thickness(15, 0, 15, 0);
                    PhieuGhiChu.Insert(inputt - 1, tbghichu);
                    stackPanel.Children.Add(PhieuGhiChu[inputt - 1]);

                    TextBlock tbmaqr = new TextBlock();
                    string quycach1 = null;
                    string mtp1 = null;
                    mtp1 = MaTp1[inputt - 1].Text;
                    if (mtp1 != null) quycach1 = DataProvider.Ins.DB.BomTp.Where(x => x.MaTp == mtp1).First().DisplayName;
                    string bxe1 = null;
                    bxe1 = "\n------------\n Số lô: " + SoLo1[inputt - 1].Text + "\n Mã bánh xe: " + MaTp1[inputt - 1].Text + "\n Display Name: " + quycach1 + "\n Số lượng: " + SoLuongNhap1[inputt - 1].Text + " " + DonVi1[inputt - 1].Text;
                    string bxe2 = null;
                    string mtp2 = null;
                    mtp2 = MaTp2[inputt - 1].Text;
                    string quycach2 = null;
                    if (mtp2 != null) quycach2 = DataProvider.Ins.DB.BomTp.Where(x => x.MaTp == mtp2).First().DisplayName;
                    if (string.IsNullOrEmpty(SoLo2[inputt - 1].Text) || string.IsNullOrEmpty(MaTp2[inputt - 1].Text) || string.IsNullOrEmpty(SoLuongNhap2[inputt - 1].Text)) bxe2 = null;
                    else bxe2 = "\n------------\n Số lô: " + SoLo2[inputt - 1].Text + "\n Mã bánh xe: " + MaTp2[inputt - 1].Text + "\n Display Name: " + quycach2 + "\n Số lượng: " + SoLuongNhap2[inputt - 1].Text + " " + DonVi2[inputt - 1].Text;
                    tbmaqr.Text = "ID: " + MaPhieu + "-" + inputt + "\nNgày: " + time.ToString("dd/MM/yyyy") + bxe1 + bxe2;
                    tbmaqr.VerticalAlignment = VerticalAlignment.Center;
                    tbmaqr.Margin = new Thickness(15, 0, 15, 0);
                    tbmaqr.Width = 250;
                    MaQR.Insert(inputt - 1, tbmaqr);
                    stackPanel.Children.Add(MaQR[inputt - 1]);

                    QRcode.Insert(inputt - 1, MaPhieu + "-" + SoLo1[inputt - 1].Text + "-" + MaTp1[inputt - 1].Text + "-" + SoLuongNhap1[inputt - 1].Text + "-" + SoLo2[inputt - 1].Text + "-" + MaTp2[inputt - 1].Text + "-" + SoLuongNhap2[inputt - 1].Text + "-" + KhoiLuong[inputt - 1].Text + "-" + inputt);

                    Image image = new Image { Width = 130, Height = 130, Stretch = Stretch.Uniform };
                    image.Margin = new Thickness(15, 0, 15, 0);
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRcode[inputt - 1], QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(20, "black", "white", false);
                    image.Source = BitmapToImageSource(qrCodeImage);
                    QR.Insert(inputt - 1, image);
                    QR[inputt - 1].Source = image.Source;
                    bitmap.Insert(inputt - 1, BitmapSourceToByteArray((BitmapSource)QR[inputt - 1].Source));
                    stackPanel.Children.Add(QR[inputt - 1]);

                    p.Children.Add(stackPanel);
                }

            });

            deletecommandInputNL = new RelayCommand<StackPanel>((p) => { if (FlagNew == true || string.IsNullOrEmpty(MaPhieu)) return false; return true; }, (p) =>
            {
                var b = DataProvider.Ins.DB.KhoThanhPhamInputInfo.Where(x => x.MaPhieu == MaPhieu);
                while (b.Count() > 0)
                {
                    DataProvider.Ins.DB.KhoThanhPhamInputInfo.Remove(b.First());
                    DataProvider.Ins.DB.SaveChanges();
                    b = DataProvider.Ins.DB.KhoThanhPhamInputInfo.Where(x => x.MaPhieu == MaPhieu);
                }
                var a = DataProvider.Ins.DB.KhoThanhPhamInput.Where(x => x.MaPhieu == MaPhieu);
                while (a.Count() > 0)
                {
                    DataProvider.Ins.DB.KhoThanhPhamInput.Remove(a.First());
                    DataProvider.Ins.DB.SaveChanges();
                    a = DataProvider.Ins.DB.KhoThanhPhamInput.Where(x => x.MaPhieu == MaPhieu);
                }
                loadKhoNLInput();
            });

            editcommandInputNL = new RelayCommand<StackPanel>((p) => { if (FlagNew == true || string.IsNullOrEmpty(MaPhieu)) return false; return true; }, (p) =>
            {
                fis = true;
                FlagNew = true;
                unFlagNew = false;

                SoLoList = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp);
                donvilist = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
                NCCList = new ObservableCollection<Supplier>(DataProvider.Ins.DB.Supplier);

                p.Children.Clear();
                STT.Clear();
                SoLo1.Clear();
                MaTp1.Clear();
                SoLuongNhap1.Clear();
                DonVi1.Clear();
                SoLo2.Clear();
                MaTp2.Clear();
                SoLuongNhap2.Clear();
                DonVi2.Clear();
                KhoiLuong.Clear();
                PhieuGhiChu.Clear();
                QR.Clear();
                QRcode.Clear();
                MaQR.Clear();
                updateQR.Clear();
                Vitri.Clear();
                bitmap.Clear();
                inputt = 0;


                var doninput = DataProvider.Ins.DB.KhoThanhPhamInput.Where(x => x.MaPhieu == MaPhieu).First();
                var doninputinfo = DataProvider.Ins.DB.KhoThanhPhamInputInfo.Where(x => x.MaPhieu == doninput.MaPhieu);

                NgayCT = doninput.DateCT;
                NgayNhap = doninput.DateNhap;
                IdNCC = doninput.IdSup;
                NCCDisplayName = doninput.TenNCC;
                GhiChu = doninput.GhiChu;
                MaPhieu = doninput.MaPhieu;

                foreach (var item in doninputinfo)
                {
                    inputt++;
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Orientation = Orientation.Horizontal;
                    stackPanel.Margin = new Thickness(10, 5, 0, 5);

                    StackPanel stackPanelgroup = new StackPanel();
                    stackPanelgroup.Orientation = Orientation.Vertical;
                    stackPanelgroup.VerticalAlignment = VerticalAlignment.Center;
                    stackPanelgroup.Margin = new Thickness(0, 0, 0, 0);

                    StackPanel stackPanelup = new StackPanel();
                    stackPanelup.Orientation = Orientation.Horizontal;
                    stackPanelup.VerticalAlignment = VerticalAlignment.Center;
                    stackPanelup.Margin = new Thickness(0, 5, 0, 5);

                    StackPanel stackPaneldown = new StackPanel();
                    stackPaneldown.Orientation = Orientation.Horizontal;
                    stackPaneldown.VerticalAlignment = VerticalAlignment.Center;
                    stackPaneldown.Margin = new Thickness(0, 5, 0, 5);

                    TextBox Stt = new TextBox();
                    Stt.IsReadOnly = true;
                    Stt.TextAlignment = TextAlignment.Center;
                    Stt.Text = inputt.ToString();
                    Stt.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(Stt, "STT");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    Stt.Width = 70;
                    Stt.Margin = new Thickness(5, 0, 15, 0);
                    STT.Insert(inputt - 1, Stt);
                    stackPanel.Children.Add(STT[inputt - 1]);

                    ComboBox cbMMH = new ComboBox();
                    cbMMH.ItemsSource = SoLoList;
                    cbMMH.DisplayMemberPath = "SoLo";
                    cbMMH.Text = item.SoLo1;
                    cbMMH.IsEnabled = true;
                    cbMMH.IsEditable = false;
                    cbMMH.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(cbMMH, "Mã hàng");
                    cbMMH.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged);
                    cbMMH.Width = 190;
                    MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbMMH, 50);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbMMH, 0.26);
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    cbMMH.Margin = new Thickness(15, 0, 15, 0);
                    SoLo1.Insert(inputt - 1, cbMMH);
                    stackPanelup.Children.Add(SoLo1[inputt - 1]);

                    ComboBox cbMMH2 = new ComboBox();
                    cbMMH2.ItemsSource = SoLoList;
                    cbMMH2.DisplayMemberPath = "SoLo";
                    cbMMH2.Text = item.SoLo2;
                    cbMMH2.IsEnabled = true;
                    cbMMH2.IsEditable = false;
                    cbMMH2.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(cbMMH2, "Mã hàng");
                    cbMMH2.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged2);
                    cbMMH2.Width = 190;
                    MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbMMH2, 50);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbMMH2, 0.26);
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    cbMMH2.Margin = new Thickness(15, 0, 15, 0);
                    SoLo2.Insert(inputt - 1, cbMMH2);
                    stackPaneldown.Children.Add(SoLo2[inputt - 1]);

                    ComboBox combobox3 = new ComboBox();
                    combobox3.ItemsSource = SoLoList;
                    combobox3.DisplayMemberPath = "MaTp";
                    combobox3.Text = item.MaTp1;
                    combobox3.IsEnabled = true;
                    combobox3.IsEditable = false;
                    combobox3.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(combobox3, "Mã Bánh xe");
                    combobox3.Width = 140;
                    MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(combobox3, 50);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(combobox3, 0.26);
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    combobox3.Margin = new Thickness(15, 0, 15, 0);
                    MaTp1.Insert(inputt - 1, combobox3);
                    stackPanelup.Children.Add(MaTp1[inputt - 1]);

                    ComboBox combobox4 = new ComboBox();
                    combobox4.ItemsSource = SoLoList;
                    combobox4.DisplayMemberPath = "MaTp";
                    combobox4.Text = item.MaTp2;
                    combobox4.IsEnabled = true;
                    combobox4.IsEditable = false;
                    combobox4.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(combobox4, "Mã Bánh xe");
                    combobox4.Width = 140;
                    MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(combobox4, 50);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(combobox4, 0.26);
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    combobox4.Margin = new Thickness(15, 0, 15, 0);
                    MaTp2.Insert(inputt - 1, combobox4);
                    stackPaneldown.Children.Add(MaTp2[inputt - 1]);

                    TextBox tcsoluong = new TextBox();
                    tcsoluong.IsReadOnly = false;
                    tcsoluong.TextAlignment = TextAlignment.Right;
                    tcsoluong.Text = item.SoLuongNhap1.ToString();
                    tcsoluong.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(tcsoluong, "Số lượng");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    tcsoluong.Width = 80;
                    tcsoluong.Margin = new Thickness(15, 0, 15, 0);
                    SoLuongNhap1.Insert(inputt - 1, tcsoluong);
                    stackPanelup.Children.Add(SoLuongNhap1[inputt - 1]);

                    TextBox tcsoluong2 = new TextBox();
                    tcsoluong2.IsReadOnly = false;
                    tcsoluong2.TextAlignment = TextAlignment.Right;
                    tcsoluong2.Text = item.SoLuongNhap2.ToString();
                    tcsoluong2.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(tcsoluong2, "Số lượng");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    tcsoluong2.Width = 80;
                    tcsoluong2.Margin = new Thickness(15, 0, 15, 0);
                    SoLuongNhap2.Insert(inputt - 1, tcsoluong2);
                    stackPaneldown.Children.Add(SoLuongNhap2[inputt - 1]);

                    ComboBox cbdonvi = new ComboBox();
                    cbdonvi.ItemsSource = donvilist;
                    cbdonvi.DisplayMemberPath = "IdU";
                    cbdonvi.Text = item.IdU1;
                    cbdonvi.IsEnabled = true;
                    cbdonvi.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(cbdonvi, "Đơn vị");
                    cbdonvi.Width = 60;
                    MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbdonvi, 50);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbdonvi, 0.26);
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    cbdonvi.Margin = new Thickness(15, 0, 0, 0);
                    DonVi1.Insert(inputt - 1, cbdonvi);
                    stackPanelup.Children.Add(DonVi1[inputt - 1]);

                    ComboBox cbdonvi2 = new ComboBox();
                    cbdonvi2.ItemsSource = donvilist;
                    cbdonvi2.DisplayMemberPath = "IdU";
                    cbdonvi2.Text = item.IdU2;
                    cbdonvi2.IsEnabled = true;
                    cbdonvi2.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(cbdonvi2, "Đơn vị");
                    cbdonvi2.Width = 60;
                    MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbdonvi2, 50);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbdonvi2, 0.26);
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    cbdonvi2.Margin = new Thickness(15, 0, 0, 0);
                    DonVi2.Insert(inputt - 1, cbdonvi2);
                    stackPaneldown.Children.Add(DonVi2[inputt - 1]);

                    Button unit = new Button();
                    unit.Content = "...";
                    unit.Padding = new Thickness(2, 0, 2, 0);
                    unit.Background = System.Windows.Media.Brushes.LightGray;
                    unit.Margin = new Thickness(5, 0, 15, 0);
                    unit.Click += (s, e) =>
                    {
                        UnitWindows unitWindows = new UnitWindows();
                        unitWindows.Height = 700;
                        unitWindows.Width = 700;
                        unitWindows.ShowDialog();
                    };
                    stackPanelup.Children.Add(unit);

                    Button unit2 = new Button();
                    unit2.Content = "...";
                    unit2.Padding = new Thickness(2, 0, 2, 0);
                    unit2.Background = System.Windows.Media.Brushes.LightGray;
                    unit2.Margin = new Thickness(5, 0, 15, 0);
                    unit2.Click += (s, e) =>
                    {
                        UnitWindows unitWindows = new UnitWindows();
                        unitWindows.Height = 700;
                        unitWindows.Width = 700;
                        unitWindows.ShowDialog();
                    };
                    stackPaneldown.Children.Add(unit2);

                    stackPanelgroup.Children.Add(stackPanelup);
                    stackPanelgroup.Children.Add(stackPaneldown);
                    stackPanel.Children.Add(stackPanelgroup);

                    TextBox tbkhoiluong = new TextBox();
                    tbkhoiluong.IsReadOnly = false;
                    tbkhoiluong.TextAlignment = TextAlignment.Right;
                    tbkhoiluong.Text = item.KhoiLuongKien.ToString();
                    tbkhoiluong.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(tbkhoiluong, "Khối lượng");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    tbkhoiluong.Width = 80;
                    tbkhoiluong.Margin = new Thickness(15, 0, 15, 0);
                    KhoiLuong.Insert(inputt - 1, tbkhoiluong);
                    stackPanel.Children.Add(KhoiLuong[inputt - 1]);

                    TextBox tbvitri = new TextBox();
                    tbvitri.IsReadOnly = false;
                    tbvitri.TextAlignment = TextAlignment.Right;
                    tbvitri.Text = item.ViTri;
                    tbvitri.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(tbvitri, "Vị trí");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    tbvitri.Width = 80;
                    tbvitri.Margin = new Thickness(15, 0, 15, 0);
                    Vitri.Insert(inputt - 1, tbvitri);
                    stackPanel.Children.Add(Vitri[inputt - 1]);

                    TextBox tbghichu = new TextBox();
                    tbghichu.IsReadOnly = false;
                    tbghichu.TextAlignment = TextAlignment.Center;
                    tbghichu.Text = item.GhiChu;
                    tbghichu.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(tbghichu, "Ghi chú");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    tbghichu.Width = 120;
                    tbghichu.Margin = new Thickness(15, 0, 15, 0);
                    PhieuGhiChu.Insert(inputt - 1, tbghichu);
                    stackPanel.Children.Add(PhieuGhiChu[inputt - 1]);

                    TextBlock tbmaqr = new TextBlock();
                    string quycach1 = null;
                    string mtp1 = null;
                    mtp1 = MaTp1[inputt - 1].Text;
                    if (mtp1 != null) quycach1 = DataProvider.Ins.DB.BomTp.Where(x => x.MaTp == mtp1).First().DisplayName;
                    string bxe1 = null;
                    bxe1 = "\n------------\n Số lô: " + SoLo1[inputt - 1].Text + "\n Mã bánh xe: " + MaTp1[inputt - 1].Text + "\n Display Name: " + quycach1 + "\n Số lượng: " + SoLuongNhap1[inputt - 1].Text + " " + DonVi1[inputt - 1].Text;
                    string bxe2 = null;
                    string mtp2 = null;
                    mtp2 = MaTp2[inputt - 1].Text;
                    string quycach2 = null;
                    if (mtp2 != null) quycach2 = DataProvider.Ins.DB.BomTp.Where(x => x.MaTp == mtp2).First().DisplayName;
                    if (string.IsNullOrEmpty(SoLo2[inputt - 1].Text) || string.IsNullOrEmpty(MaTp2[inputt - 1].Text) || string.IsNullOrEmpty(SoLuongNhap2[inputt - 1].Text)) bxe2 = null;
                    else bxe2 = "\n------------\n Số lô: " + SoLo2[inputt - 1].Text + "\n Mã bánh xe: " + MaTp2[inputt - 1].Text + "\n Display Name: " + quycach2 + "\n Số lượng: " + SoLuongNhap2[inputt - 1].Text + " " + DonVi2[inputt - 1].Text;
                    tbmaqr.Text = "ID: " + MaPhieu + "-" + inputt + "\nNgày: " + time.ToString("dd/MM/yyyy") + bxe1 + bxe2;
                    tbmaqr.VerticalAlignment = VerticalAlignment.Center;
                    tbmaqr.Margin = new Thickness(15, 0, 15, 0);
                    tbmaqr.Width = 250;
                    MaQR.Insert(inputt - 1, tbmaqr);
                    stackPanel.Children.Add(MaQR[inputt - 1]);

                    QRcode.Insert(inputt - 1, MaPhieu + "-" + SoLo1[inputt - 1].Text + "-" + MaTp1[inputt - 1].Text + "-" + SoLuongNhap1[inputt - 1].Text + "-" + SoLo2[inputt - 1].Text + "-" + MaTp2[inputt - 1].Text + "-" + SoLuongNhap2[inputt - 1].Text + "-" + KhoiLuong[inputt - 1].Text + "-" + STT[inputt - 1].Text);

                    Image image = new Image { Width = 130, Height = 130, Stretch = Stretch.Uniform };
                    image.Margin = new Thickness(15, 0, 15, 0);
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRcode[inputt - 1], QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(20, "black", "white", false);
                    image.Source = BitmapToImageSource(qrCodeImage);
                    QR.Insert(inputt - 1, image);
                    QR[inputt - 1].Source = image.Source;
                    bitmap.Insert(inputt - 1, BitmapSourceToByteArray((BitmapSource)QR[inputt - 1].Source));
                    stackPanel.Children.Add(QR[inputt - 1]);

                    MaterialDesignThemes.Wpf.PackIcon icon = new MaterialDesignThemes.Wpf.PackIcon();
                    icon.Height = 24;
                    icon.Width = 24;
                    icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Update;
                    icon.Foreground = System.Windows.Media.Brushes.Black;

                    Button upd = new Button();
                    upd.Content = icon;
                    upd.Margin = new Thickness(15, 0, 15, 0);
                    upd.Click += (s, e) =>
                    {
                        var button = s as Button;
                        int ins = updateQR.IndexOf(button);
                        QRcode.RemoveAt(ins);
                        QRcode.Insert(ins, MaPhieu + "-" + SoLo1[ins].Text + "-" + MaTp1[ins].Text + "-" + SoLuongNhap1[ins].Text + "-" + SoLo2[ins].Text + "-" + MaTp2[ins].Text + "-" + SoLuongNhap2[ins].Text + "-" + KhoiLuong[ins].Text + "-" + STT[ins].Text);

                        string quycach11 = null;
                        string mtp11 = null;
                        mtp11 = MaTp1[ins].Text;
                        if (mtp11 != null) quycach11 = DataProvider.Ins.DB.BomTp.Where(x => x.MaTp == mtp11).First().DisplayName;
                        string bxe11 = null;
                        bxe11 = "\n------------\n Số lô: " + SoLo1[ins].Text + "\n Mã bánh xe: " + MaTp1[ins].Text + "\n Display Name: " + quycach11 + "\n Số lượng: " + SoLuongNhap1[ins].Text + " " + DonVi1[ins].Text;
                        string bxe22 = null;
                        string mtp22 = null;
                        mtp22 = MaTp2[ins].Text;
                        string quycach22 = null;
                        if (mtp22 != null) quycach22 = DataProvider.Ins.DB.BomTp.Where(x => x.MaTp == mtp22).First().DisplayName;
                        if (string.IsNullOrEmpty(SoLo2[ins].Text) || string.IsNullOrEmpty(MaTp2[ins].Text) || string.IsNullOrEmpty(SoLuongNhap2[ins].Text)) bxe2 = null;
                        else bxe22 = "\n------------\n Số lô: " + SoLo2[ins].Text + "\n Mã bánh xe: " + MaTp2[ins].Text + "\n Display Name: " + quycach22 + "\n Số lượng: " + SoLuongNhap2[ins].Text + " " + DonVi2[ins].Text;

                        MaQR[ins].Text = "ID: " + MaPhieu + "-" + (ins + 1) + "\nNgày: " + time.ToString("dd/MM/yyyy") + bxe11 + bxe22;

                        QRCodeGenerator qrGenerators = new QRCodeGenerator();
                        QRCodeData qrCodeDatas = qrGenerators.CreateQrCode(QRcode[ins], QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCodes = new QRCode(qrCodeDatas);
                        Bitmap qrCodeImages = qrCodes.GetGraphic(20, "black", "white", false);

                        image.Source = BitmapToImageSource(qrCodeImages);
                        QR.RemoveAt(ins);
                        QR.Insert(ins, image);
                        bitmap.RemoveAt(ins);
                        bitmap.Insert(ins, BitmapSourceToByteArray((BitmapSource)QR[ins].Source));

                    };
                    updateQR.Insert(inputt - 1, upd);
                    stackPanel.Children.Add(updateQR[inputt - 1]);

                    p.Children.Add(stackPanel);
                }

            });
        }



        private void OnMyComboBoxChanged(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            int ins = SoLo1.IndexOf(combobox);
            string text = "";

            text = ((DonHangTp)combobox.SelectedItem).SoLo;

            var a = DataProvider.Ins.DB.DonHangTp.Where(x => x.SoLo == text);
            if (a == null || a.Count() == 0)
            {

            }
            else
            {

                MaTp1[ins].Text = a.First().MaTp;
            }
        }
        private void OnMyComboBoxChanged2(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            int ins = SoLo2.IndexOf(combobox);
            string text = "";

            text = ((DonHangTp)combobox.SelectedItem).SoLo;

            var a = DataProvider.Ins.DB.DonHangTp.Where(x => x.SoLo == text);
            if (a == null || a.Count() == 0)
            {

            }
            else
            {

                MaTp2[ins].Text = a.First().MaTp;
            }
        }
        void loadKhoNLInput()
        {
            DateTime? OuputTpStart = KhoOutputTpNgayStart;
            DateTime? OuputTpEnd = KhoOutputTpNgayEnd;
            if (OuputTpStart == null) OuputTpStart = DateTime.MinValue;
            if (OuputTpEnd == null) OuputTpEnd = DateTime.Now;
            NhapKhoTpList = new ObservableCollection<KhoThanhPhamInput>(DataProvider.Ins.DB.KhoThanhPhamInput.Where(x => x.DateCT >= OuputTpStart && x.DateCT <= OuputTpEnd));
        }
        void Taoidnhaplieu()
        {
            DateTime timetam = DateTime.Today;
            string timeint = "";
            int stt = 0;
            int maid = 0;
            bool flag = false;
            if (NgayCT != null) { timetam = (DateTime)NgayCT; }
            timeint = timetam.ToString("yyMMdd");
            maid = Int32.Parse(timeint, 0);
            stt = maid * 1000 + 1;
            for (int i = stt; flag == false; i++)
            {
                var check = DataProvider.Ins.DB.KhoThanhPhamInput.Where(x => x.MaPhieu == ("KTP-N-" + i.ToString()) + "     ");
                if (check == null || check.Count() == 0)
                {
                    stt = i;
                    flag = true;
                }
            }
            MaPhieu = "KTP-N-" + stt.ToString() + "     ";
        }
        void Clearphieunhap()
        {
            NgayCT = null;
            NgayNhap = null;
            MaPhieu = null;
            IdNCC = null;
            NCCDisplayName = null;
            GhiChu = null;
        }
        private ImageSource BitmapToImageSource(Bitmap bitmap)
        {
            using (var stream = new MemoryStream())
            {
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                stream.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }
        private byte[] BitmapSourceToByteArray(BitmapSource image)
        {
            using (var stream = new MemoryStream())
            {
                var encoder = new PngBitmapEncoder(); // or some other encoder
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
                return stream.ToArray();
            }
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

        public static double GetTrueColumnWidth(double width)
        {
            //DEDUCE WHAT THE COLUMN WIDTH WOULD REALLY GET SET TO
            double z = 1d;
            if (width >= (1 + 2 / 3))
            {
                z = Math.Round((Math.Round(7 * (width - 1 / 256), 0) - 5) / 7, 2);
            }
            else
            {
                z = Math.Round((Math.Round(12 * (width - 1 / 256), 0) - Math.Round(5 * width, 0)) / 12, 2);
            }

            //HOW FAR OFF? (WILL BE LESS THAN 1)
            double errorAmt = width - z;

            //CALCULATE WHAT AMOUNT TO TACK ONTO THE ORIGINAL AMOUNT TO RESULT IN THE CLOSEST POSSIBLE SETTING 
            double adj = 0d;
            if (width >= (1 + 2 / 3))
            {
                adj = (Math.Round(7 * errorAmt - 7 / 256, 0)) / 7;
            }
            else
            {
                adj = ((Math.Round(12 * errorAmt - 12 / 256, 0)) / 12) + (2 / 12);
            }

            //RETURN A SCALED-VALUE THAT SHOULD RESULT IN THE NEAREST POSSIBLE VALUE TO THE TRUE DESIRED SETTING
            if (z > 0)
            {
                return width + adj;
            }

            return 0d;
        }
    }
}
