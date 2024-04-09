using ControlzEx.Standard;
using Cw3_Product.Model;
using OfficeOpenXml;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Image = System.Windows.Controls.Image;
using Cw3_Product.UserControlBOM;
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
using Microsoft.Win32;
using System.Windows;
using System.IO;

namespace Cw3_Product.ViewModel
{
    public class TonKhoLkViewModel : BaseViewModel
    {
        //-------------------------Khai báo list hiển thị sản xuất--------------------------------------------------
        private ObservableCollection<TonKhoLkModel> _TonKholist;
        public ObservableCollection<TonKhoLkModel> TonKholist { get => _TonKholist; set { _TonKholist = value; OnPropertyChanged(); } }
        //-------------------------Khai báo list hiển thị sản xuất--------------------------------------------------
        private ObservableCollection<TonKhoLkModel> _TonKholist2;
        public ObservableCollection<TonKhoLkModel> TonKholist2 { get => _TonKholist2; set { _TonKholist2 = value; OnPropertyChanged(); } }

        private string _SoHoa;
        public string SoHoa { get => _SoHoa; set { _SoHoa = value; OnPropertyChanged(); } }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        private string _QuyCach;
        public string QuyCach { get => _QuyCach; set { _QuyCach = value; OnPropertyChanged(); } }

        private string _DonVi;
        public string DonVi { get => _DonVi; set { _DonVi = value; OnPropertyChanged(); } }

        public ICommand updatecommand { get; set; }
        public ICommand valuechangecommand { get; set; }
        public ICommand ExportExcel { get; set; }
        public TonKhoLkViewModel() 
        {
            SoHoa = "";
            DisplayName = "";
            QuyCach = "";
            DonVi = "";


            {
                TonKholist = new ObservableCollection<TonKhoLkModel>();
                var nhaplieu = DataProvider.Ins.DB.KhoLinhKienInputInfo;
                var xuatlieu = DataProvider.Ins.DB.KhoLinhKienOutputInfo;
                var bomlk = DataProvider.Ins.DB.BomLk;
                int i = 1;
                foreach (var item in bomlk)
                {
                    int tongnhap = 0;
                    int tongxuat = 0;
                    TonKhoLkModel tonKhoLkModel = new TonKhoLkModel();
                    var nhaphang = nhaplieu.Where(x => x.SoHoa == item.SoHoa);
                    if (nhaphang.Count() > 0) tongnhap = nhaphang.Sum(x => x.SoLuongNhap);
                    var xuathang = xuatlieu.Where(x => x.SoHoa == item.SoHoa);
                    if (xuathang.Count() > 0) tongxuat = xuathang.Sum(x => x.SoLuongNhap);

                    tonKhoLkModel.STT = i;
                    tonKhoLkModel.SoHoa = item.SoHoa;
                    tonKhoLkModel.DisplayName = item.DisplayName;
                    tonKhoLkModel.QuyCach = item.QuyCach;
                    tonKhoLkModel.DonVi = item.IdU;
                    tonKhoLkModel.TonKho = tongnhap - tongxuat;

                    TonKholist.Add(tonKhoLkModel);
                    i++;
                }
                TonKholist2 = TonKholist;
            }

            updatecommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                clear();
                TonKholist = new ObservableCollection<TonKhoLkModel>();
                var nhaplieu = DataProvider.Ins.DB.KhoLinhKienInputInfo;
                var xuatlieu = DataProvider.Ins.DB.KhoLinhKienOutputInfo;
                var bomlk = DataProvider.Ins.DB.BomLk;
                int i = 1;
                foreach (var item in bomlk)
                {
                    int tongnhap = 0;
                    int tongxuat = 0;
                    TonKhoLkModel tonKhoLkModel = new TonKhoLkModel();
                    var nhaphang = nhaplieu.Where(x => x.SoHoa == item.SoHoa);
                    if (nhaphang.Count() > 0) tongnhap = nhaphang.Sum(x => x.SoLuongNhap);
                    var xuathang = xuatlieu.Where(x => x.SoHoa == item.SoHoa);
                    if (xuathang.Count() > 0) tongxuat = xuathang.Sum(x => x.SoLuongNhap);

                    tonKhoLkModel.STT = i;
                    tonKhoLkModel.SoHoa = item.SoHoa;
                    tonKhoLkModel.DisplayName = item.DisplayName;
                    tonKhoLkModel.QuyCach = item.QuyCach;
                    tonKhoLkModel.DonVi = item.IdU;
                    tonKhoLkModel.TonKho = tongnhap - tongxuat;

                    TonKholist.Add(tonKhoLkModel);
                    i++;
                }

                TonKholist2 = TonKholist;
            });
            valuechangecommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

                var a = TonKholist2.Where(x => x.SoHoa.Contains(SoHoa) && x.DisplayName.Contains(DisplayName) && x.QuyCach.Contains(QuyCach) && x.DonVi.Contains(DonVi));
                TonKholist = new ObservableCollection<TonKhoLkModel>(a);
            });

            ExportExcel = new RelayCommand<object>((p) => { return true; }, (p) =>
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

                        int i = 1;

                        foreach (var item in TonKholist2)
                        {
                            
                            ws.Cells[i, 1].Value = item.STT;
                            ws.Cells[i, 2].Value = item.SoHoa;
                            ws.Cells[i, 3].Value = item.DisplayName;
                            ws.Cells[i, 4].Value = item.QuyCach;
                            ws.Cells[i, 5].Value = item.TonKho;
                            ws.Cells[i, 6].Value = item.DonVi;
                            i++;

                        }
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
        }
        void clear()
        {
            SoHoa = "";
            DisplayName = "";
            QuyCach = "";
            DonVi = "";
        }
    }
}
