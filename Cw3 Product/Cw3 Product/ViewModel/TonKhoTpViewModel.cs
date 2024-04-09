using Cw3_Product.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
using OfficeOpenXml;

namespace Cw3_Product.ViewModel
{
    public class TonKhoTpViewModel : BaseViewModel
    {
        //-------------------------Khai báo list hiển thị sản xuất--------------------------------------------------
        private ObservableCollection<TonKhoTpModel> _TonKholist;
        public ObservableCollection<TonKhoTpModel> TonKholist { get => _TonKholist; set { _TonKholist = value; OnPropertyChanged(); } }
        //-------------------------Khai báo list hiển thị sản xuất--------------------------------------------------
        private ObservableCollection<TonKhoTpModel> _TonKholist2;
        public ObservableCollection<TonKhoTpModel> TonKholist2 { get => _TonKholist2; set { _TonKholist2 = value; OnPropertyChanged(); } }

        private string _SoLo;
        public string SoLo { get => _SoLo; set { _SoLo = value; OnPropertyChanged(); } }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        private string _MaTp;
        public string MaTp { get => _MaTp; set { _MaTp = value; OnPropertyChanged(); } }

        private string _DonVi;
        public string DonVi { get => _DonVi; set { _DonVi = value; OnPropertyChanged(); } }

        public ICommand updatecommand { get; set; }
        public ICommand valuechangecommand { get; set; }
        public ICommand ExportExcel { get; set; }
        public TonKhoTpViewModel() 
        {
            SoLo = "";
            DisplayName = "";
            MaTp = "";
            DonVi = "";


            {
                var tam = new ObservableCollection<TonKhoTpModel>();
                var nhaplieu = DataProvider.Ins.DB.KhoThanhPhamInputInfo;
                var xuatlieu = DataProvider.Ins.DB.KhoThanhPhamOutputInfo;
                var donhangtp = DataProvider.Ins.DB.DonHangTp;
                var bomtp = DataProvider.Ins.DB.BomTp;
                int i = 1;
                foreach (var item in donhangtp)
                {
                    TonKhoTpModel TonKhoTpModel = new TonKhoTpModel();
                    int tongnhap = 0;
                    int tongxuat = 0;
                    int tongnhap1 = 0;
                    int tongxuat1 = 0;
                    int tongnhap2 = 0;
                    int tongxuat2 = 0;
                    
                    var nhaphang1 = nhaplieu.Where(x => x.SoLo1 == item.SoLo);
                    if (nhaphang1.Count() > 0) tongnhap1 = nhaphang1.Sum(x => x.SoLuongNhap1);
                    var xuathang1 = xuatlieu.Where(x => x.SoLo1 == item.SoLo);
                    if (xuathang1.Count() > 0) tongxuat1 = xuathang1.Sum(x => x.SoLuongNhap1);
                    var nhaphang2 = nhaplieu.Where(x => x.SoLo2 == item.SoLo);
                    if (nhaphang2.Count() > 0) tongnhap2 = nhaphang2.Sum(x => x.SoLuongNhap1);
                    var xuathang2 = xuatlieu.Where(x => x.SoLo2 == item.SoLo);
                    if (xuathang2.Count() > 0) tongxuat2 = xuathang2.Sum(x => x.SoLuongNhap1);

                    tongnhap = tongnhap1 + tongnhap2;
                    tongxuat = tongxuat1 + tongxuat2;

                    TonKhoTpModel.STT = i;
                    TonKhoTpModel.SoLo = item.SoLo;
                    TonKhoTpModel.DisplayName = bomtp.Where(x => x.MaTp == item.MaTp).First().DisplayName;
                    TonKhoTpModel.MaTp = item.MaTp;
                    TonKhoTpModel.DonVi = item.IdU;
                    TonKhoTpModel.TonKho = tongnhap - tongxuat;

                    tam.Add(TonKhoTpModel);

                    TonKholist = new ObservableCollection<TonKhoTpModel>(tam.Where(x => x.TonKho > 0));
                    i++;
                }
                TonKholist2 = TonKholist;
            }

            updatecommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                var tam = new ObservableCollection<TonKhoTpModel>();
                var nhaplieu = DataProvider.Ins.DB.KhoThanhPhamInputInfo;
                var xuatlieu = DataProvider.Ins.DB.KhoThanhPhamOutputInfo;
                var donhangtp = DataProvider.Ins.DB.DonHangTp;
                var bomtp = DataProvider.Ins.DB.BomTp;
                int i = 1;
                foreach (var item in donhangtp)
                {
                    TonKhoTpModel TonKhoTpModel = new TonKhoTpModel();
                    int tongnhap = 0;
                    int tongxuat = 0;
                    int tongnhap1 = 0;
                    int tongxuat1 = 0;
                    int tongnhap2 = 0;
                    int tongxuat2 = 0;

                    var nhaphang1 = nhaplieu.Where(x => x.SoLo1 == item.SoLo);
                    if (nhaphang1.Count() > 0) tongnhap1 = nhaphang1.Sum(x => x.SoLuongNhap1);
                    var xuathang1 = xuatlieu.Where(x => x.SoLo1 == item.SoLo);
                    if (xuathang1.Count() > 0) tongxuat1 = xuathang1.Sum(x => x.SoLuongNhap1);
                    var nhaphang2 = nhaplieu.Where(x => x.SoLo2 == item.SoLo);
                    if (nhaphang2.Count() > 0) tongnhap2 = nhaphang2.Sum(x => x.SoLuongNhap1);
                    var xuathang2 = xuatlieu.Where(x => x.SoLo2 == item.SoLo);
                    if (xuathang2.Count() > 0) tongxuat2 = xuathang2.Sum(x => x.SoLuongNhap1);

                    tongnhap = tongnhap1 + tongnhap2;
                    tongxuat = tongxuat1 + tongxuat2;

                    TonKhoTpModel.STT = i;
                    TonKhoTpModel.SoLo = item.SoLo;
                    TonKhoTpModel.DisplayName = bomtp.Where(x => x.MaTp == item.MaTp).First().DisplayName;
                    TonKhoTpModel.MaTp = item.MaTp;
                    TonKhoTpModel.DonVi = item.IdU;
                    TonKhoTpModel.TonKho = tongnhap - tongxuat;

                    tam.Add(TonKhoTpModel);

                    TonKholist = new ObservableCollection<TonKhoTpModel>(tam.Where(x => x.TonKho > 0));
                    i++;
                }
                TonKholist2 = TonKholist;
            });
            valuechangecommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {

                var a = TonKholist2.Where(x => x.SoLo.Contains(SoLo) && x.DisplayName.Contains(DisplayName) && x.MaTp.Contains(MaTp) && x.DonVi.Contains(DonVi));

                TonKholist = new ObservableCollection<TonKhoTpModel>(a);

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
                            ws.Cells[i, 2].Value = item.SoLo;
                            ws.Cells[i, 3].Value = item.MaTp;
                            ws.Cells[i, 4].Value = item.DisplayName;
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
            SoLo = "";
            DisplayName = "";
            MaTp = "";
            DonVi = "";
        }
    }
}
