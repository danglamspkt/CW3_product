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
using System.Printing;
using System.Xml.Linq;
using System.Drawing.Printing;
using System.Windows.Documents;
using Microsoft;


namespace Cw3_Product.ViewModel
{    
    public class KhoInputLkViewModel : BaseViewModel
    {
        //-------------------------Khai báo list hiển thị Mã Mua Hàng--------------------------------------------------
        private ObservableCollection<BomLk> _SoHoaList;
        public ObservableCollection<BomLk> SoHoaList { get => _SoHoaList; set { _SoHoaList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Đơn vị--------------------------------------------------
        private ObservableCollection<Unit> _donvilist;
        public ObservableCollection<Unit> donvilist { get => _donvilist; set { _donvilist = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Kho NL Input--------------------------------------------------
        private ObservableCollection<KhoLinhKienInput> _NhapKhoLkList;
        public ObservableCollection<KhoLinhKienInput> NhapKhoLkList { get => _NhapKhoLkList; set { _NhapKhoLkList = value; OnPropertyChanged(); } }

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

        private string _POMuaHang;
        public string POMuaHang { get => _POMuaHang; set { _POMuaHang = value; OnPropertyChanged(); } }

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

        private Model.KhoLinhKienInput _SelectedItem;
        public Model.KhoLinhKienInput SelectedItem
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
        public ICommand ExportPhieuNhap { get; set; }
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
        List<ComboBox> MaHang = new List<ComboBox>();
        List<TextBox> DisplayName = new List<TextBox>();
        List<TextBox> QuyCach = new List<TextBox>();
        List<TextBox> SoLuongNhap = new List<TextBox>();
        List<ComboBox> DonVi = new List<ComboBox>();
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

        
        public KhoInputLkViewModel()
        {
            FlagNew = false;
            unFlagNew = true;
            if (PhieuNhapKhoLinhKienUC.ContextMenuOpeningEvent != null) loadKhoNLInput();
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
                    
                        printDialog.PrintVisual(stackPanel, "MyPrinterName");
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
                        //string[] arrColumnHeader = { "STT", "Ngày", "Mã phiếu", "Mã hàng", "Display Name", "Quy cách", "Số lượng", "Đơn vị", "Khối lượng", "vị trí", "Ghi chú", "Tem QR", "QR", "QR code" };

                        //// lấy ra số lượng cột cần dùng dựa vào số lượng header
                        //var countColHeader = arrColumnHeader.Count();

                        //// merge các column lại từ column 1 đến số column header
                        //// gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                        //ws.Cells[1, 1].Value = "Phiếu nhập nguyên liệu";
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
                        //ws.Column(2).Width = 12;
                        //ws.Column(3).Width = 22;
                        //ws.Column(4).Width = 22;
                        //ws.Column(5).Width = 22;
                        //ws.Column(6).Width = 22;
                        //ws.Column(7).Width = 12;
                        //ws.Column(8).Width = 12;
                        //ws.Column(9).Width = 12;
                        //ws.Column(10).Width = 12;
                        //ws.Column(11).Width = 12;
                        //ws.Column(12).Width = 38;
                        //ws.Column(13).Width = 23.29;
                        //ws.Column(14).Width = 90;
                        
                        for (int i = 1; i <= inputt; i++)
                        {
                            //ws.Row(i + 2).Height = 126;
                            //ws.Cells[i + 2, 13].Style.WrapText = true;
                            //ws.Cells[i + 2, 2].Style.Numberformat.Format = "dd/mm/yyyy";
                            //for (int j = 1; j <= countColHeader;)
                            //{
                            //    ws.Cells[i + 2, j++].Value = STT[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = NgayCT;
                            //    ws.Cells[i + 2, j++].Value = MaPhieu;
                            //    ws.Cells[i + 2, j++].Value = MaHang[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = DisplayName[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = QuyCach[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = SoLuongNhap[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = DonVi[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = KhoiLuong[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = Vitri[i - 1].Text;
                            //    ws.Cells[i + 2, j++].Value = PhieuGhiChu[i - 1].Text;
                            //    //căn chỉnh các border
                            //    var border = ws.Cells[i + 2, j].Style.Border;
                            //    border.Bottom.Style =
                            //        border.Top.Style =
                            //        border.Left.Style =
                            //        border.Right.Style = ExcelBorderStyle.Thin;
                            ws.Column(i*2-1).Width = GetTrueColumnWidth(40.00);
                            ws.Column(i*2).Width = GetTrueColumnWidth(27.00);
                            ws.Cells[1, i * 2 - 1].Value = MaQR[i - 1].Text;
                                //var border2 = ws.Cells[i + 2, j].Style.Border;
                                //border2.Bottom.Style =
                                //    border2.Top.Style =
                                //    border2.Left.Style =
                                //    border2.Right.Style = ExcelBorderStyle.Thin;
                                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                                QRCodeData qrCodeData = qrGenerator.CreateQrCode(QRcode[i - 1], QRCodeGenerator.ECCLevel.Q);
                                QRCode qrCode = new QRCode(qrCodeData);
                                Bitmap qrCodeImage = qrCode.GetGraphic(20, "black", "white", false);
                                var img = ws.Drawings.AddPicture(i.ToString(), qrCodeImage);
                                img.SetSize(145, 145);
                                img.SetPosition(0, 9, i*2-1, 12);

                            //ws.Cells[1, i * 2 - 1].Style.WrapText = true;

                            //ws.Cells[i + 2, j++].Value = QRcode[i - 1];
                            //}

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

            ExportPhieuNhap = new RelayCommand<object>((p) => { if (inputt == 0) return false; return true; }, (p) =>
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
                        int sld = 0;
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
                        ws.Cells.Style.Font.Name = "Times New Roman";

                        ws.Column(1).Width = GetTrueColumnWidth(5.29);
                        ws.Column(2).Width = GetTrueColumnWidth(8.43);
                        ws.Column(3).Width = GetTrueColumnWidth(19.29);
                        ws.Column(4).Width = GetTrueColumnWidth(32.71);
                        ws.Column(5).Width = GetTrueColumnWidth(24.29);
                        ws.Column(6).Width = GetTrueColumnWidth(7.29);
                        ws.Column(7).Width = GetTrueColumnWidth(10);
                        ws.Column(8).Width = GetTrueColumnWidth(10);
                        ws.Column(9).Width = GetTrueColumnWidth(7.71);
                        ws.Column(10).Width = GetTrueColumnWidth(7);
                        ws.Column(11).Width = GetTrueColumnWidth(17);


                        ws.Row(1).Height = 27;
                        ws.Row(2).Height = 27;
                        ws.Row(3).Height = 27;
                        ws.Row(4).Height = 26.25;
                        ws.Row(5).Height = 27;
                        ws.Row(6).Height = 47.25;
                        ws.Row(7).Height = 21.75;
                        ws.Row(8).Height = 21.75;
                        ws.Row(9).Height = 21.75;
                        ws.Row(10).Height = 21.75;
                        ws.Row(11).Height = 21.75;
                        ws.Row(12).Height = 21.75;
                        ws.Row(13).Height = 21.75;
                        ws.Row(14).Height = 21.75;
                        ws.Row(15).Height = 21.75;
                        ws.Row(16).Height = 21.75;
                        if (inputt > 10) sld = inputt; else sld = 10;
                        for (int i = 11; i<=sld; i++)
                        {
                            ws.Row(i+6).Height = 21.75;
                        }                        

                        ws.Row(sld + 7).Height = 18.75;
                        ws.Row(sld + 8).Height = 15.75;
                        ws.Row(sld + 9).Height = 15.75;
                        ws.Row(sld + 10).Height = 15.75;
                        ws.Row(sld + 11).Height = 15.75;

                        ws.Cells[1, 1, sld + 10, 11].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        var border = ws.Cells[4, 1, sld + 8, 11].Style.Border;
                        border.Bottom.Style =
                                border.Top.Style =
                                border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;

                        ws.Cells[1, 1, 1, 3].Merge = true;
                        ws.Cells[1, 1, 1, 3].Style.Font.Bold = true;
                        ws.Cells[1, 1, 1, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
                        

                        ws.Cells[1, 4, 1, 8].Merge = true;
                        ws.Cells[1, 4, 1, 8].Style.Font.Bold = true;
                        ws.Cells[1, 4, 1, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        ws.Cells[2, 1, 2, 3].Merge = true;
                        ws.Cells[2, 1, 2, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                        ws.Cells[2, 4, 2, 8].Merge = true;
                        ws.Cells[2, 4, 2, 8].Style.Font.Bold = true;
                        ws.Cells[2, 4, 2, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        ws.Cells[2, 9].Style.Font.Bold = true;

                        ws.Cells[3, 11].Style.Font.Bold = true;
                        ws.Cells[3, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                        ws.Cells[4, 1, 4, 3].Merge = true;
                        ws.Cells[4, 1, 4, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                        ws.Cells[4, 4, 4, 6].Merge = true;
                        ws.Cells[4, 4, 4, 6].Style.Font.Bold = true;
                        ws.Cells[4, 4, 4, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                        ws.Cells[4, 7, 4, 11].Merge = true;
                        ws.Cells[4, 7, 4, 11].Style.Font.Bold = true;
                        ws.Cells[4, 7, 4, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                        ws.Cells[5, 1, 5, 3].Merge = true;
                        ws.Cells[5, 1, 5, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                        ws.Cells[5, 4, 5, 6].Merge = true;
                        ws.Cells[5, 4, 5, 6].Style.Font.Bold = true;
                        ws.Cells[5, 4, 5, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                        ws.Cells[5, 7, 5, 11].Merge = true;
                        ws.Cells[5, 7, 5, 11].Style.Font.Bold = true;
                        ws.Cells[5, 7, 5, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;

                        ws.Cells[6, 1, 6, 11].Style.Font.Bold = true;
                        ws.Cells[6, 1, 6, 11].Style.WrapText = true;
                        ws.Cells[6, 1, 6, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        ws.Cells[7, 1, sld + 8, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[7, 5, sld + 8, 10].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        ws.Cells[sld + 7, 1, sld + 7, 3].Merge = true;
                        ws.Cells[sld + 7, 1, sld + 7, 3].Style.Font.Bold = true;

                        ws.Cells[sld + 7, 7].Style.Font.Bold = true;
                        ws.Cells[sld + 7, 9].Style.Font.Bold = true;

                        ws.Cells[sld + 8, 1, sld + 8, 3].Merge = true;
                        ws.Cells[sld + 8, 1, sld + 8, 3].Style.Font.Bold = true;

                        ws.Cells[sld + 9, 1].Style.Font.Bold = true;

                        ws.Cells[sld + 10, 2].Style.Font.Bold = true;
                        ws.Cells[sld + 10, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        ws.Cells[sld + 10, 8].Style.Font.Bold = true;
                        ws.Cells[sld + 10, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        ws.Cells[sld + 10, 11].Style.Font.Bold = true;
                        ws.Cells[sld + 10, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        ws.Cells[sld + 11, 8].Style.Font.Bold = true;
                        ws.Cells[sld + 11, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                        ws.Cells[1, 1, 1, 3].Value = "江玥金屬股份有現公司";
                        ws.Cells[1, 1, 1, 3].Style.Font.Size = 10;

                        ws.Cells[2, 1, 2, 3].Value = "CTY CLEAR WATER METAL(VN)";
                        ws.Cells[2, 1, 2, 3].Style.Font.Size = 10;

                        ws.Cells[1, 4, 1, 8].Value = "採購進貨單";
                        ws.Cells[1, 4, 1, 8].Style.Font.Size = 16;

                        ws.Cells[2, 4, 2, 8].Value = "ĐƠN NHẬP HÀNG";
                        ws.Cells[2, 4, 2, 8].Style.Font.Size = 20;

                        ws.Cells[2, 9].Value = "編號PNK No: " + MaPhieu;

                        int ngay = NgayCT.Value.Day;
                        int thang = NgayCT.Value.Month;
                        int nam = NgayCT.Value.Year;

                        ws.Cells[3, 11].Value = "年Năm " + nam.ToString() + " 月Tháng " + thang.ToString() + " 日Ngày " + ngay.ToString();

                        ws.Cells[4, 1, 4, 3].Value = "供應廠商 Tên Cty giao hàng:";

                        ws.Cells[4, 4, 4, 6].Value = NCCDisplayName;

                        ws.Cells[4, 7, 4, 11].Value = "SỐ HÓA ĐƠN: " + POMuaHang;

                        ws.Cells[5, 1, 5, 3].Value = "地址 Địa chỉ:";
                        

                        ws.Cells[6, 1].Value = "STT\r\n編號";
                        ws.Cells[6, 2].Value = "Số kiện\r\n站板號碼";
                        ws.Cells[6, 3].Value = "Mã vật tư\r\n原物料號碼";
                        ws.Cells[6, 4].Value = "Tên vật tư\r\n原物料名稱";
                        ws.Cells[6, 5].Value = "Quy cách\r\n規格";
                        ws.Cells[6, 6].Value = "Đơn vị\r\n單位";
                        ws.Cells[6, 7].Value = "SL c.từ\r\n單據數量";
                        ws.Cells[6, 8].Value = "SL thực nhập\r\n實際數量";
                        ws.Cells[6, 9].Value = "Khối lượng\r\n(Kg)";
                        ws.Cells[6, 10].Value = "Thành tiền\r\n金額";
                        ws.Cells[6, 11].Value = "Ghi chú\r\n備註";

                        int sumsl = 0;
                        int sumkl = 0;

                        for (int i = 0; i < inputt; i++)
                        {
                            ws.Cells[i + 7, 1].Value = i + 1;
                            ws.Cells[i + 7, 3].Value = MaHang[i].Text;
                            ws.Cells[i + 7, 4].Value = DisplayName[i].Text;
                            ws.Cells[i + 7, 5].Value = QuyCach[i].Text;
                            ws.Cells[i + 7, 6].Value = DonVi[i].Text;
                            ws.Cells[i + 7, 7].Value = SoLuongNhap[i].Text;
                            ws.Cells[i + 7, 8].Value = SoLuongNhap[i].Text;
                            ws.Cells[i + 7, 9].Value = KhoiLuong[i].Text;
                            sumsl += Int32.Parse(SoLuongNhap[i].Text);
                            sumkl += Int32.Parse(KhoiLuong[i].Text);
                        }

                        ws.Cells[sld + 7, 1, sld + 7, 3].Value = "總共 CỘNG:";
                        ws.Cells[sld + 7, 7].Value = sumsl;
                        ws.Cells[sld + 7, 9].Value = sumkl;

                        ws.Cells[sld + 8, 1, sld + 8, 3].Value = "採用目的 Mục đích sử dụng:";
                        ws.Cells[sld + 9, 1].Value = "Liên thứ 1 (trắng): Quản kho -liên thứ 2 (hồng): NC.ứng -Liên 3 (vàng): Tài vụ";
                        ws.Cells[sld + 10, 2].Value = "主管 Chủ quản";
                        ws.Cells[sld + 10, 8].Value = "倉管Thủ kho";
                        ws.Cells[sld + 10, 11].Value = "N0.QP1601 Rev.0";
                        ws.Cells[sld + 11, 8].Value = "(Kiểm tra số lượng,ký nhận hàng)";



                        ws.PrinterSettings.PrintArea = ws.Cells[1, 1, sld + 11, 11];
                        ws.PrinterSettings.PaperSize = ePaperSize.A4;
                        ws.PrinterSettings.Orientation = eOrientation.Landscape;
                        ws.PrinterSettings.HorizontalCentered = true;
                        ws.PrinterSettings.FitToPage = true;
                        ws.PrinterSettings.FitToWidth = 1;
                        ws.PrinterSettings.FitToHeight = 0;
                        ws.PrinterSettings.HeaderMargin = 0.31M;
                        ws.PrinterSettings.FooterMargin = 0.31M;
                        ws.PrinterSettings.TopMargin = 0.39M;
                        ws.PrinterSettings.BottomMargin = 0.275M;
                        ws.PrinterSettings.LeftMargin = 0.157M;
                        ws.PrinterSettings.RightMargin = 0.157M;

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
                SoHoaList = new ObservableCollection<BomLk>(DataProvider.Ins.DB.BomLk);
                donvilist = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
                NCCList = new ObservableCollection<Supplier>(DataProvider.Ins.DB.Supplier);
                FlagNew = true;
                unFlagNew = false;
                fis = true;
                inputt = 0;
                p.Children.Clear();
                STT.Clear();
                MaHang.Clear();
                DisplayName.Clear();
                QuyCach.Clear();
                SoLuongNhap.Clear();
                DonVi.Clear();
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
                        var b = DataProvider.Ins.DB.KhoLinhKienInputInfo.Where(x => x.MaPhieu == MaPhieu);
                        while (b.Count() > 0)
                        {
                            DataProvider.Ins.DB.KhoLinhKienInputInfo.Remove(b.First());
                            DataProvider.Ins.DB.SaveChanges();
                            b = DataProvider.Ins.DB.KhoLinhKienInputInfo.Where(x => x.MaPhieu == MaPhieu);
                        }
                        var a = DataProvider.Ins.DB.KhoLinhKienInput.Where(x => x.MaPhieu == MaPhieu);
                        while (a.Count() > 0)
                        {
                            DataProvider.Ins.DB.KhoLinhKienInput.Remove(a.First());
                            DataProvider.Ins.DB.SaveChanges();
                            a = DataProvider.Ins.DB.KhoLinhKienInput.Where(x => x.MaPhieu == MaPhieu);
                        }

                        KhoLinhKienInput KhoLinhKienInput = new KhoLinhKienInput { MaPhieu = MaPhieu, DateCT = NgayCT, DateNhap = NgayNhap, IdSup = IdNCC, TenNCC = NCCDisplayName, POMuaHang = POMuaHang, GhiChu = GhiChu, UserName = Cw3_Product.Properties.Settings.Default.account };
                        DataProvider.Ins.DB.KhoLinhKienInput.Add(KhoLinhKienInput);
                        DataProvider.Ins.DB.SaveChanges();

                        KhoLinhKienInputInfo khoLinhKienInputInfo = new KhoLinhKienInputInfo();

                        if (inputt > 0) for (int j = 0; j < inputt; j++)
                            {
                                khoLinhKienInputInfo.MaPhieu = MaPhieu;
                                khoLinhKienInputInfo.SoHoa = MaHang[j].Text;
                                khoLinhKienInputInfo.SoLuongNhap = Int32.Parse(SoLuongNhap[j].Text);
                                khoLinhKienInputInfo.IdU = DonVi[j].Text;
                                khoLinhKienInputInfo.KhoiLuongKien = Int32.Parse(KhoiLuong[j].Text);
                                khoLinhKienInputInfo.MaKho = "WAR02     ";
                                khoLinhKienInputInfo.GhiChu = PhieuGhiChu[j].Text;
                                khoLinhKienInputInfo.ViTri = Vitri[j].Text;
                                khoLinhKienInputInfo.UserName = Cw3_Product.Properties.Settings.Default.account;
                                khoLinhKienInputInfo.QRcode = QRcode[j];

                                BitmapImage bitmapSource = (BitmapImage)QR[j].Source;

                                var imageBuffer = BitmapSourceToByteArray(bitmapSource);
                                khoLinhKienInputInfo.QRimg = imageBuffer;
                                var c = DataProvider.Ins.DB.KhoLinhKienOutputInfo.Where(x => x.QRcode == khoLinhKienInputInfo.QRcode);
                                if (c == null || c.Count() == 0) khoLinhKienInputInfo.TinhTrang = "Tồn";
                                else khoLinhKienInputInfo.TinhTrang = null;

                                DataProvider.Ins.DB.KhoLinhKienInputInfo.Add(khoLinhKienInputInfo);
                                DataProvider.Ins.DB.SaveChanges();
                            }


                        p.Children.Clear();
                        STT.Clear();
                        MaHang.Clear();
                        DisplayName.Clear();
                        QuyCach.Clear();
                        SoLuongNhap.Clear();
                        DonVi.Clear();
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
                        var b = DataProvider.Ins.DB.KhoLinhKienInputInfo.Where(x => x.MaPhieu == MaPhieu);
                        while (b.Count() > 0)
                        {
                            DataProvider.Ins.DB.KhoLinhKienInputInfo.Remove(b.First());
                            DataProvider.Ins.DB.SaveChanges();
                            b = DataProvider.Ins.DB.KhoLinhKienInputInfo.Where(x => x.MaPhieu == MaPhieu);
                        }
                        var a = DataProvider.Ins.DB.KhoLinhKienInput.Where(x => x.MaPhieu == MaPhieu);
                        while (a.Count() > 0)
                        {
                            DataProvider.Ins.DB.KhoLinhKienInput.Remove(a.First());
                            DataProvider.Ins.DB.SaveChanges();
                            a = DataProvider.Ins.DB.KhoLinhKienInput.Where(x => x.MaPhieu == MaPhieu);
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
                    MaHang.Clear();
                    DisplayName.Clear();
                    QuyCach.Clear();
                    SoLuongNhap.Clear();
                    DonVi.Clear();
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
                cbMMH.ItemsSource = SoHoaList;
                cbMMH.DisplayMemberPath = "SoHoa";
                cbMMH.Text = null;
                cbMMH.IsEnabled = true;
                cbMMH.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(cbMMH, "Mã hàng");
                cbMMH.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged);
                cbMMH.Width = 140;
                MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbMMH, 50);
                MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbMMH, 0.26);
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                cbMMH.Margin = new Thickness(15, 0, 15, 0);
                MaHang.Insert(inputt - 1, cbMMH);
                stackPanel.Children.Add(MaHang[inputt - 1]);

                TextBox tbdisplayname = new TextBox();
                tbdisplayname.IsReadOnly = true;
                tbdisplayname.TextAlignment = TextAlignment.Left;
                tbdisplayname.Text = null;
                tbdisplayname.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbdisplayname, "Display Name");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbdisplayname.Width = 190;
                tbdisplayname.Margin = new Thickness(15, 0, 15, 0);
                DisplayName.Insert(inputt - 1, tbdisplayname);
                stackPanel.Children.Add(DisplayName[inputt - 1]);

                TextBox tbquycach = new TextBox();
                tbquycach.IsReadOnly = true;
                tbquycach.TextAlignment = TextAlignment.Left;
                tbquycach.Text = "pcs       ";
                tbquycach.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tbquycach, "Chất liệu");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tbquycach.Width = 140;
                tbquycach.Margin = new Thickness(15, 0, 15, 0);
                QuyCach.Insert(inputt - 1, tbquycach);
                stackPanel.Children.Add(QuyCach[inputt - 1]);

                TextBox tcsoluong = new TextBox();
                tcsoluong.IsReadOnly = false;
                tcsoluong.TextAlignment = TextAlignment.Right;
                tcsoluong.Text = 0.ToString();
                tcsoluong.VerticalAlignment = VerticalAlignment.Center;
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tcsoluong, "Số lượng");
                MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                tcsoluong.Width = 80;
                tcsoluong.Margin = new Thickness(15, 0, 15, 0);
                SoLuongNhap.Insert(inputt - 1, tcsoluong);
                stackPanel.Children.Add(SoLuongNhap[inputt - 1]);

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
                DonVi.Insert(inputt - 1, cbdonvi);
                stackPanel.Children.Add(DonVi[inputt - 1]);

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
                stackPanel.Children.Add(unit);

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
                tbmaqr.Text = "PO mua hàng: " + POMuaHang + "\nNgày: " + time.ToString("dd/MM/yyyy") + "\nTên: " + DisplayName[inputt - 1].Text + "\nMã hàng: " + MaHang[inputt - 1].Text + "\nQuy cách: " + QuyCach[inputt - 1].Text + "\nKhối lượng: " + KhoiLuong[inputt - 1].Text + "\nSố lượng: " + SoLuongNhap[inputt - 1].Text + "\nID: " + MaPhieu;
                tbmaqr.VerticalAlignment = VerticalAlignment.Center;
                tbmaqr.Margin = new Thickness(15, 0, 15, 0);
                tbmaqr.Width = 250;
                MaQR.Insert(inputt - 1, tbmaqr);
                stackPanel.Children.Add(MaQR[inputt - 1]);

                QRcode.Insert(inputt - 1, MaPhieu + "-" + MaHang[inputt - 1].Text + "-" + QuyCach[inputt - 1].Text + "-" + KhoiLuong[inputt - 1].Text + "-" + SoLuongNhap[inputt - 1].Text + "-" + IdNCC + "-" + POMuaHang + "-" + STT[inputt - 1].Text);

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
                    QRcode.Insert(ins, MaPhieu + "-" + MaHang[ins].Text + "-" + QuyCach[ins].Text + "-" + KhoiLuong[ins].Text + "-" + SoLuongNhap[ins].Text + "-" + IdNCC + "-" + POMuaHang + "-" + STT[ins].Text);
                    //QRcode[ins] = MaPhieu + "-" + MaHang[ins].Text + "-" + QuyCach[ins].Text + "-" + KhoiLuong[ins].Text + "-" + SoLuongNhap[ins].Text + "-" + IdNCC + "-" + POMuaHang + "-" + inputt;
                    MaQR[ins].Text = "PO mua hàng: " + POMuaHang + "\nNgày: " + time.ToString("dd/MM/yyyy") + "\nTên: " + DisplayName[ins].Text + "\nMã hàng: " + MaHang[ins].Text + "\nQuy cách: " + QuyCach[ins].Text + "\nKhối lượng: " + KhoiLuong[ins].Text + "\nSố lượng: " + SoLuongNhap[ins].Text + "\nID: " + MaPhieu;

                    
                    QRCodeGenerator qrGenerators = new QRCodeGenerator();
                    QRCodeData qrCodeDatas = qrGenerators.CreateQrCode(QRcode[ins], QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCodes = new QRCode(qrCodeDatas);
                    Bitmap qrCodeImages = qrCodes.GetGraphic(20, "black", "white", false);

                    image.Source = BitmapToImageSource(qrCodeImages);
                    QR.RemoveAt(ins);
                    QR.Insert(ins, image);
                    //QR[ins].Source = images.Source;
                    //QR[ins] = image;
                    bitmap.RemoveAt(ins);
                    bitmap.Insert(ins, BitmapSourceToByteArray((BitmapSource)QR[ins].Source));
                    //bitmap[ins] = BitmapSourceToByteArray((BitmapSource)QR[ins].Source);

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
                MaHang.RemoveAt(a);
                DisplayName.RemoveAt(a);
                QuyCach.RemoveAt(a);
                SoLuongNhap.RemoveAt(a);
                DonVi.RemoveAt(a);
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

                SoHoaList = new ObservableCollection<BomLk>(DataProvider.Ins.DB.BomLk);
                donvilist = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
                NCCList = new ObservableCollection<Supplier>(DataProvider.Ins.DB.Supplier);

                p.Children.Clear();
                STT.Clear();
                MaHang.Clear();
                DisplayName.Clear();
                QuyCach.Clear();
                SoLuongNhap.Clear();
                DonVi.Clear();
                KhoiLuong.Clear();
                PhieuGhiChu.Clear();
                QR.Clear();
                QRcode.Clear();
                MaQR.Clear();
                updateQR.Clear();
                Vitri.Clear();
                bitmap.Clear();
                inputt = 0;


                var doninput = DataProvider.Ins.DB.KhoLinhKienInput.Where(x => x.MaPhieu == MaPhieu).First();
                var doninputinfo = DataProvider.Ins.DB.KhoLinhKienInputInfo.Where(x => x.MaPhieu == doninput.MaPhieu);

                NgayCT = doninput.DateCT;
                NgayNhap = doninput.DateNhap;
                IdNCC = doninput.IdSup;
                NCCDisplayName = doninput.TenNCC;
                POMuaHang = doninput.POMuaHang;
                GhiChu = doninput.GhiChu;
                MaPhieu = doninput.MaPhieu;

                foreach (var item in doninputinfo)
                {
                    inputt++;
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Orientation = Orientation.Horizontal;
                    stackPanel.Margin = new Thickness(10, 5, 0, 5);

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
                    cbMMH.ItemsSource = SoHoaList;
                    cbMMH.DisplayMemberPath = "SoHoa";
                    cbMMH.IsReadOnly = true;
                    cbMMH.Text = item.SoHoa;
                    cbMMH.IsEnabled = false;
                    cbMMH.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(cbMMH, "Mã hàng");
                    cbMMH.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged);
                    cbMMH.Width = 140;
                    MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbMMH, 50);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbMMH, 0.26);
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    cbMMH.Margin = new Thickness(15, 0, 15, 0);
                    MaHang.Insert(inputt - 1, cbMMH);
                    stackPanel.Children.Add(MaHang[inputt - 1]);

                    TextBox tbdisplayname = new TextBox();
                    tbdisplayname.IsReadOnly = true;
                    tbdisplayname.TextAlignment = TextAlignment.Left;
                    tbdisplayname.Text = DataProvider.Ins.DB.BomLk.Where(y => y.SoHoa == item.SoHoa).First().DisplayName;
                    tbdisplayname.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(tbdisplayname, "Display Name");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    tbdisplayname.Width = 190;
                    tbdisplayname.Margin = new Thickness(15, 0, 15, 0);
                    DisplayName.Insert(inputt - 1, tbdisplayname);
                    stackPanel.Children.Add(DisplayName[inputt - 1]);

                    TextBox tbquycach = new TextBox();
                    tbquycach.IsReadOnly = true;
                    tbquycach.TextAlignment = TextAlignment.Left;
                    tbquycach.Text = DataProvider.Ins.DB.BomLk.Where(y => y.SoHoa == item.SoHoa).First().QuyCach;
                    tbquycach.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(tbquycach, "Chất liệu");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    tbquycach.Width = 140;
                    tbquycach.Margin = new Thickness(15, 0, 15, 0);
                    QuyCach.Insert(inputt - 1, tbquycach);
                    stackPanel.Children.Add(QuyCach[inputt - 1]);

                    TextBox tcsoluong = new TextBox();
                    tcsoluong.IsReadOnly = true;
                    tcsoluong.TextAlignment = TextAlignment.Right;
                    tcsoluong.Text = item.SoLuongNhap.ToString();
                    tcsoluong.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(tcsoluong, "Số lượng");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    tcsoluong.Width = 80;
                    tcsoluong.Margin = new Thickness(15, 0, 15, 0);
                    SoLuongNhap.Insert(inputt - 1, tcsoluong);
                    stackPanel.Children.Add(SoLuongNhap[inputt - 1]);

                    ComboBox cbdonvi = new ComboBox();
                    cbdonvi.ItemsSource = donvilist;
                    cbdonvi.IsReadOnly = true;
                    cbdonvi.DisplayMemberPath = "IdU";
                    cbdonvi.Text = item.IdU;
                    cbdonvi.IsEnabled = false;
                    cbdonvi.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(cbdonvi, "Đơn vị");
                    cbdonvi.Width = 60;
                    MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbdonvi, 50);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbdonvi, 0.26);
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    cbdonvi.Margin = new Thickness(15, 0, 0, 0);
                    DonVi.Insert(inputt - 1, cbdonvi);
                    stackPanel.Children.Add(DonVi[inputt - 1]);

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
                    tbmaqr.Text = "PO mua hàng: " + POMuaHang + "\nNgày: " + time.ToString("dd/MM/yyyy") + "\nTên: " + DisplayName[inputt - 1].Text + "\nMã hàng: " + MaHang[inputt - 1].Text + "\nQuy cách: " + QuyCach[inputt - 1].Text + "\nKhối lượng: " + KhoiLuong[inputt - 1].Text + "\nSố lượng: " + SoLuongNhap[inputt - 1].Text + "\nID: " + MaPhieu;
                    tbmaqr.VerticalAlignment = VerticalAlignment.Center;
                    tbmaqr.Margin = new Thickness(15, 0, 15, 0);
                    tbmaqr.Width = 250;
                    MaQR.Insert(inputt - 1, tbmaqr);
                    stackPanel.Children.Add(MaQR[inputt - 1]);

                    QRcode.Insert(inputt - 1, item.QRcode);

                    Image image = new Image { Width = 130, Height = 130, Stretch = Stretch.Uniform };
                    image.Margin = new Thickness(15, 0, 15, 0);
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(item.QRcode, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(20, "black", "white", false);
                    image.Source = BitmapToImageSource(qrCodeImage);

                    //Image image = new Image { Width = 130, Height = 130, Stretch = Stretch.Uniform };
                    //var bitmaps = LoadImage(DataProvider.Ins.DB.KhoLinhKienInputInfo.First().QRimg);
                    //image.Source = bitmaps;

                    QR.Insert(inputt - 1, image);
                    QR[inputt - 1].Source = image.Source;
                    bitmap.Insert(inputt - 1, BitmapSourceToByteArray((BitmapSource)QR[inputt - 1].Source));

                    stackPanel.Children.Add(QR[inputt - 1]);
                    p.Children.Add(stackPanel);
                }

            });

            deletecommandInputNL = new RelayCommand<StackPanel>((p) => { if (FlagNew == true || string.IsNullOrEmpty(MaPhieu)) return false; return true; }, (p) =>
            {
                var b = DataProvider.Ins.DB.KhoLinhKienInputInfo.Where(x => x.MaPhieu == MaPhieu);
                while (b.Count() > 0)
                {
                    DataProvider.Ins.DB.KhoLinhKienInputInfo.Remove(b.First());
                    DataProvider.Ins.DB.SaveChanges();
                    b = DataProvider.Ins.DB.KhoLinhKienInputInfo.Where(x => x.MaPhieu == MaPhieu);
                }
                var a = DataProvider.Ins.DB.KhoLinhKienInput.Where(x => x.MaPhieu == MaPhieu);
                while (a.Count() > 0)
                {
                    DataProvider.Ins.DB.KhoLinhKienInput.Remove(a.First());
                    DataProvider.Ins.DB.SaveChanges();
                    a = DataProvider.Ins.DB.KhoLinhKienInput.Where(x => x.MaPhieu == MaPhieu);
                }
                loadKhoNLInput();
            });

            editcommandInputNL = new RelayCommand<StackPanel>((p) => { if (FlagNew == true || string.IsNullOrEmpty(MaPhieu)) return false; return true; }, (p) =>
            {
                fis = true;
                FlagNew = true;
                unFlagNew = false;

                SoHoaList = new ObservableCollection<BomLk>(DataProvider.Ins.DB.BomLk);
                donvilist = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
                NCCList = new ObservableCollection<Supplier>(DataProvider.Ins.DB.Supplier);

                p.Children.Clear();
                STT.Clear();
                MaHang.Clear();
                DisplayName.Clear();
                QuyCach.Clear();
                SoLuongNhap.Clear();
                DonVi.Clear();
                KhoiLuong.Clear();
                PhieuGhiChu.Clear();
                QR.Clear();
                QRcode.Clear();
                MaQR.Clear();
                updateQR.Clear();
                Vitri.Clear();
                bitmap.Clear();
                inputt = 0;


                var doninput = DataProvider.Ins.DB.KhoLinhKienInput.Where(x => x.MaPhieu == MaPhieu).First();
                var doninputinfo = DataProvider.Ins.DB.KhoLinhKienInputInfo.Where(x => x.MaPhieu == doninput.MaPhieu);

                NgayCT = doninput.DateCT;
                NgayNhap = doninput.DateNhap;
                IdNCC = doninput.IdSup;
                NCCDisplayName = doninput.TenNCC;
                POMuaHang = doninput.POMuaHang;
                GhiChu = doninput.GhiChu;
                MaPhieu = doninput.MaPhieu;

                foreach (var item in doninputinfo)
                {
                    inputt++;
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Orientation = Orientation.Horizontal;
                    stackPanel.Margin = new Thickness(10, 5, 0, 5);

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
                    cbMMH.ItemsSource = SoHoaList;
                    cbMMH.DisplayMemberPath = "SoHoa";
                    cbMMH.Text = item.SoHoa;
                    cbMMH.IsEnabled = true;
                    cbMMH.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(cbMMH, "Mã hàng");
                    cbMMH.SelectionChanged += new SelectionChangedEventHandler(OnMyComboBoxChanged);
                    cbMMH.Width = 140;
                    MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbMMH, 50);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbMMH, 0.26);
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    cbMMH.Margin = new Thickness(15, 0, 15, 0);
                    MaHang.Insert(inputt - 1, cbMMH);
                    stackPanel.Children.Add(MaHang[inputt - 1]);

                    TextBox tbdisplayname = new TextBox();
                    tbdisplayname.IsReadOnly = true;
                    tbdisplayname.TextAlignment = TextAlignment.Left;
                    tbdisplayname.Text = DataProvider.Ins.DB.BomLk.Where(y => y.SoHoa == item.SoHoa).First().DisplayName;
                    tbdisplayname.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(tbdisplayname, "Display Name");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    tbdisplayname.Width = 190;
                    tbdisplayname.Margin = new Thickness(15, 0, 15, 0);
                    DisplayName.Insert(inputt - 1, tbdisplayname);
                    stackPanel.Children.Add(DisplayName[inputt - 1]);

                    TextBox tbquycach = new TextBox();
                    tbquycach.IsReadOnly = true;
                    tbquycach.TextAlignment = TextAlignment.Left;
                    tbquycach.Text = DataProvider.Ins.DB.BomLk.Where(y => y.SoHoa == item.SoHoa).First().QuyCach; ;
                    tbquycach.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(tbquycach, "Chất liệu");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    tbquycach.Width = 140;
                    tbquycach.Margin = new Thickness(15, 0, 15, 0);
                    QuyCach.Insert(inputt - 1, tbquycach);
                    stackPanel.Children.Add(QuyCach[inputt - 1]);

                    TextBox tcsoluong = new TextBox();
                    tcsoluong.IsReadOnly = false;
                    tcsoluong.TextAlignment = TextAlignment.Right;
                    tcsoluong.Text = item.SoLuongNhap.ToString();
                    tcsoluong.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(tcsoluong, "Số lượng");
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    tcsoluong.Width = 80;
                    tcsoluong.Margin = new Thickness(15, 0, 15, 0);
                    SoLuongNhap.Insert(inputt - 1, tcsoluong);
                    stackPanel.Children.Add(SoLuongNhap[inputt - 1]);

                    ComboBox cbdonvi = new ComboBox();
                    cbdonvi.ItemsSource = donvilist;
                    cbdonvi.IsReadOnly = false;
                    cbdonvi.DisplayMemberPath = "IdU";
                    cbdonvi.Text = item.IdU;
                    cbdonvi.IsEnabled = true;
                    cbdonvi.VerticalAlignment = VerticalAlignment.Center;
                    MaterialDesignThemes.Wpf.HintAssist.SetHint(cbdonvi, "Đơn vị");
                    cbdonvi.Width = 60;
                    MaterialDesignThemes.Wpf.ComboBoxAssist.SetMaxLength(cbdonvi, 50);
                    MaterialDesignThemes.Wpf.HintAssist.SetHintOpacity(cbdonvi, 0.26);
                    MaterialDesignThemes.Wpf.HintAssist.IsFloatingProperty.Equals(true);
                    cbdonvi.Margin = new Thickness(15, 0, 0, 0);
                    DonVi.Insert(inputt - 1, cbdonvi);
                    stackPanel.Children.Add(DonVi[inputt - 1]);

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
                    stackPanel.Children.Add(unit);

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
                    tbmaqr.Text = "PO mua hàng: " + POMuaHang + "\nNgày: " + time.ToString("dd/MM/yyyy") + "\nTên: " + DisplayName[inputt - 1].Text + "\nMã hàng: " + MaHang[inputt - 1].Text + "\nQuy cách: " + QuyCach[inputt - 1].Text + "\nKhối lượng: " + KhoiLuong[inputt - 1].Text + "\nSố lượng: " + SoLuongNhap[inputt - 1].Text + "\nID: " + MaPhieu;
                    tbmaqr.VerticalAlignment = VerticalAlignment.Center;
                    tbmaqr.Margin = new Thickness(15, 0, 15, 0);
                    tbmaqr.Width = 250;
                    MaQR.Insert(inputt - 1, tbmaqr);
                    stackPanel.Children.Add(MaQR[inputt - 1]);


                    QRcode.Insert(inputt - 1, item.QRcode);

                    Image image = new Image { Width = 130, Height = 130, Stretch = Stretch.Uniform };
                    image.Margin = new Thickness(15, 0, 15, 0);
                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(item.QRcode, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    Bitmap qrCodeImage = qrCode.GetGraphic(20, "black", "white", false);
                    image.Source = BitmapToImageSource(qrCodeImage);
                    
                    //Image image = new Image { Width = 130, Height = 130, Stretch = Stretch.Uniform };
                    //var bitmaps = LoadImage(DataProvider.Ins.DB.KhoLinhKienInputInfo.First().QRimg);
                    //image.Source = bitmaps;

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
                        QRcode.Insert(ins, MaPhieu + "-" + MaHang[ins].Text + "-" + QuyCach[ins].Text + "-" + KhoiLuong[ins].Text + "-" + SoLuongNhap[ins].Text + "-" + IdNCC + "-" + POMuaHang + "-" + STT[ins].Text);
                        //QRcode[ins] = MaPhieu + "-" + MaHang[ins].Text + "-" + QuyCach[ins].Text + "-" + KhoiLuong[ins].Text + "-" + SoLuongNhap[ins].Text + "-" + IdNCC + "-" + POMuaHang + "-" + inputt;
                        MaQR[ins].Text = "PO mua hàng: " + POMuaHang + "\nNgày: " + time.ToString("dd/MM/yyyy") + "\nTên: " + DisplayName[ins].Text + "\nMã hàng: " + MaHang[ins].Text + "\nQuy cách: " + QuyCach[ins].Text + "\nKhối lượng: " + KhoiLuong[ins].Text + "\nSố lượng: " + SoLuongNhap[ins].Text + "\nID: " + MaPhieu;

                        
                        QRCodeGenerator qrGenerators = new QRCodeGenerator();
                        QRCodeData qrCodeDatas = qrGenerators.CreateQrCode(QRcode[ins], QRCodeGenerator.ECCLevel.Q);
                        QRCode qrCodes = new QRCode(qrCodeDatas);
                        Bitmap qrCodeImages = qrCodes.GetGraphic(20, "black", "white", false);

                        image.Source = BitmapToImageSource(qrCodeImages);
                        QR.RemoveAt(ins);
                        QR.Insert(ins, image);
                        //QR[ins].Source = images.Source;
                        //QR[ins] = images;
                        bitmap.RemoveAt(ins);
                        bitmap.Insert(ins, BitmapSourceToByteArray((BitmapSource)QR[ins].Source));
                        //bitmap[ins] = BitmapSourceToByteArray((BitmapSource)QR[ins].Source);

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
            int ins = MaHang.IndexOf(combobox);
            string text = "";

            text = ((BomLk)combobox.SelectedItem).SoHoa;

            var a = DataProvider.Ins.DB.BomLk.Where(x => x.SoHoa == text);
            if (a == null || a.Count() == 0)
            {

            }
            else
            {

                DisplayName[ins].Text = a.First().DisplayName;
                QuyCach[ins].Text = a.First().QuyCach;
            }
        }
        void loadKhoNLInput()
        {
            DateTime? OuputTpStart = KhoOutputTpNgayStart;
            DateTime? OuputTpEnd = KhoOutputTpNgayEnd;
            if (OuputTpStart == null) OuputTpStart = DateTime.MinValue;
            if (OuputTpEnd == null) OuputTpEnd = DateTime.Now;
            NhapKhoLkList = new ObservableCollection<KhoLinhKienInput>(DataProvider.Ins.DB.KhoLinhKienInput.Where(x => x.DateCT >= OuputTpStart && x.DateCT <= OuputTpEnd));
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
                var check = DataProvider.Ins.DB.KhoLinhKienInput.Where(x => x.MaPhieu == ("KLK-N-" + i.ToString()) + "     ");
                if (check == null || check.Count() == 0)
                {
                    stt = i;
                    flag = true;
                }
            }
            MaPhieu = "KLK-N-" + stt.ToString() + "     ";
        }
        void Clearphieunhap()
        {
            NgayCT = null;
            NgayNhap = null;
            MaPhieu = null;
            IdNCC = null;
            NCCDisplayName = null;
            POMuaHang = null;
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
