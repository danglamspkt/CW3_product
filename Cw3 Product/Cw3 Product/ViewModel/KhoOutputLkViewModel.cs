using Cw3_Product.Model;
using Cw3_Product.UserControlKho;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Linq;

namespace Cw3_Product.ViewModel
{
    public class KhoOutputLkViewModel : BaseViewModel
    {
        //-------------------------Khai báo list hiển thị QR thô--------------------------------------------------
        private ObservableCollection<QRModel> _QRlist;
        public ObservableCollection<QRModel> QRlist { get => _QRlist; set { _QRlist = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển phiếu xuất--------------------------------------------------
        private ObservableCollection<KhoLinhKienOutput> _PhieuXuatList;
        public ObservableCollection<KhoLinhKienOutput> PhieuXuatList { get => _PhieuXuatList; set { _PhieuXuatList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị phiếu xuất info--------------------------------------------------
        private ObservableCollection<KhoLinhKienOutputInfo> _PhieuXuatInfoList;
        public ObservableCollection<KhoLinhKienOutputInfo> PhieuXuatInfoList { get => _PhieuXuatInfoList; set { _PhieuXuatInfoList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Đơn vị--------------------------------------------------
        private ObservableCollection<Unit> _donvilist;
        public ObservableCollection<Unit> donvilist { get => _donvilist; set { _donvilist = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Mã Mua Hàng--------------------------------------------------
        private ObservableCollection<BomLk> _SoHoaList;
        public ObservableCollection<BomLk> SoHoaList { get => _SoHoaList; set { _SoHoaList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị khách hàng--------------------------------------------------
        private ObservableCollection<Customer> _Khachhanglist;
        public ObservableCollection<Customer> Khachhanglist { get => _Khachhanglist; set { _Khachhanglist = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Đơn hàng thành phẩm--------------------------------------------------
        private ObservableCollection<DonHangTp> _SoLoList;
        public ObservableCollection<DonHangTp> SoLoList { get => _SoLoList; set { _SoLoList = value; OnPropertyChanged(); } }

        private DateTime? _NgayCT;
        public DateTime? NgayCT { get => _NgayCT; set { _NgayCT = value; OnPropertyChanged(); } }

        private DateTime? _NgayXuat;
        public DateTime? NgayXuat { get => _NgayXuat; set { _NgayXuat = value; OnPropertyChanged(); } }

        private string _IdKhachHang;
        public string IdKhachHang { get => _IdKhachHang; set { _IdKhachHang = value; OnPropertyChanged(); } }

        private string _NCCDisplayName;
        public string NCCDisplayName { get => _NCCDisplayName; set { _NCCDisplayName = value; OnPropertyChanged(); } }

        private string _POMuaHang;
        public string POMuaHang { get => _POMuaHang; set { _POMuaHang = value; OnPropertyChanged(); } }

        private string _MaPhieu;
        public string MaPhieu { get => _MaPhieu; set { _MaPhieu = value; OnPropertyChanged(); } }

        private string _GhiChu;
        public string GhiChu { get => _GhiChu; set { _GhiChu = value; OnPropertyChanged(); } }

        private string _SoLo;
        public string SoLo { get => _SoLo; set { _SoLo = value; OnPropertyChanged(); } }

        private string _MaTp;
        public string MaTp { get => _MaTp; set { _MaTp = value; OnPropertyChanged(); } }

        private DateTime? _KhoOutputTpNgayStart;
        public DateTime? KhoOutputTpNgayStart { get => _KhoOutputTpNgayStart; set { _KhoOutputTpNgayStart = value; OnPropertyChanged(); } }

        private DateTime? _KhoOutputTpNgayEnd;
        public DateTime? KhoOutputTpNgayEnd { get => _KhoOutputTpNgayEnd; set { _KhoOutputTpNgayEnd = value; OnPropertyChanged(); } }

        private bool _tab1;
        public bool tab1 { get => _tab1; set { _tab1 = value; OnPropertyChanged(); } }

        private bool _tab2;
        public bool tab2 { get => _tab2; set { _tab2 = value; OnPropertyChanged(); } }

        private Model.KhoLinhKienOutput _SelectedItem;
        public Model.KhoLinhKienOutput SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged(); if (_SelectedItem != null)
                {
                    MaPhieu = SelectedItem.MaPhieu;

                }
            }
        }

        private Model.Customer _SelectedItem1;
        public Model.Customer SelectedItem1
        {
            get => _SelectedItem1; set
            {
                _SelectedItem1 = value; OnPropertyChanged(); if (_SelectedItem1 != null)
                {
                    NCCDisplayName = SelectedItem1.DisplayName;
                }
            }
        }

        private Model.DonHangTp _SelectedItem2;
        public Model.DonHangTp SelectedItem2
        {
            get => _SelectedItem2; set
            {
                _SelectedItem2 = value; OnPropertyChanged(); if (_SelectedItem2 != null)
                {
                    MaTp = SelectedItem2.MaTp;
                }
            }
        }

        private bool _FlagNew;
        public bool FlagNew { get => _FlagNew; set { _FlagNew = value; OnPropertyChanged(); } }

        private bool _unFlagNew;
        public bool unFlagNew { get => _unFlagNew; set { _unFlagNew = value; OnPropertyChanged(); } }
        public bool view;
        public ICommand ChuyenMaHang { get; set; }
        public ICommand ImportExcel { get; set; }
        public ICommand ExportExcel { get; set; }
        public ICommand Infile { get; set; }
        public ICommand TaoDon { get; set; }
        public ICommand XacNhan { get; set; }
        public ICommand HuyDon { get; set; }
        public ICommand KhoNLdatechange { get; set; }
        public ICommand filtercommandInputNL { get; set; }
        public ICommand ViewDon { get; set; }
        public ICommand deletecommandInputNL { get; set; }
        public ICommand cuscommand { get; set; }

        public KhoOutputLkViewModel()
        {
            FlagNew = false;
            unFlagNew = true;
            view = false;
            tab1 = true; tab2 = false;
            if (PhieuXuatKhoLinhKienUC.ContextMenuOpeningEvent != null) loadKhoNLInput();
            DateTime time = DateTime.Now;
            if (NgayCT != null) { time = (DateTime)NgayCT; }
            QRlist = new ObservableCollection<QRModel>();
            PhieuXuatList = new ObservableCollection<KhoLinhKienOutput>(DataProvider.Ins.DB.KhoLinhKienOutput);


            TaoDon = new RelayCommand<object>((p) => { if (FlagNew == true) return false; return true; }, (p) =>
            {
                Clearuper();
                NgayCT = DateTime.Today;
                NgayXuat = DateTime.Today;
                Taoidnhaplieu();
                SoHoaList = new ObservableCollection<BomLk>(DataProvider.Ins.DB.BomLk);
                donvilist = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
                Khachhanglist = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customer);
                SoLoList = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp.Where(u => u.TinhTrang == "Sản xuất"));
                PhieuXuatInfoList = new ObservableCollection<KhoLinhKienOutputInfo>();
                QRlist = new ObservableCollection<QRModel>();
                FlagNew = true;
                unFlagNew = false;
                view = true;
                tab1 = true; tab2 = false;
            });

            XacNhan = new RelayCommand<object>((p) => { if (FlagNew != true) return false; return true; }, (p) =>
            {
                var check = MessageBox.Show("Bạn chắc chắn muốn xác nhận đơn hàng?", "Xác nhận đơn", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (check == MessageBoxResult.OK)
                {
                    try
                    {
                        Taoidnhaplieu();
                        var b = DataProvider.Ins.DB.KhoLinhKienOutputInfo.Where(x => x.MaPhieu == MaPhieu);
                        while (b.Count() > 0)
                        {
                            DataProvider.Ins.DB.KhoLinhKienOutputInfo.Remove(b.First());
                            DataProvider.Ins.DB.SaveChanges();
                            b = DataProvider.Ins.DB.KhoLinhKienOutputInfo.Where(x => x.MaPhieu == MaPhieu);
                        }
                        var a = DataProvider.Ins.DB.KhoLinhKienOutput.Where(x => x.MaPhieu == MaPhieu);
                        while (a.Count() > 0)
                        {
                            DataProvider.Ins.DB.KhoLinhKienOutput.Remove(a.First());
                            DataProvider.Ins.DB.SaveChanges();
                            a = DataProvider.Ins.DB.KhoLinhKienOutput.Where(x => x.MaPhieu == MaPhieu);
                        }

                        KhoLinhKienOutput khoout = new KhoLinhKienOutput { MaPhieu = MaPhieu, DateCT = NgayCT, DateXuat = NgayXuat, IdCus = IdKhachHang, DisplayName = NCCDisplayName, POMuaHang = POMuaHang, GhiChu = GhiChu, UserName = Cw3_Product.Properties.Settings.Default.account };
                        DataProvider.Ins.DB.KhoLinhKienOutput.Add(khoout);
                        DataProvider.Ins.DB.SaveChanges();

                        foreach (var item in PhieuXuatInfoList)
                        {
                            var c = DataProvider.Ins.DB.KhoLinhKienOutputInfo.Where(y => y.QRcode == item.QRcode);
                            if (c == null || c.Count() == 0)
                            {
                                DataProvider.Ins.DB.KhoLinhKienOutputInfo.Add(item);
                                DataProvider.Ins.DB.SaveChanges();                                
                            }
                            else
                            {
                                var d = DataProvider.Ins.DB.KhoLinhKienOutputInfo.Where(x => x.MaPhieu == MaPhieu);
                                while (d.Count() > 0)
                                {
                                    DataProvider.Ins.DB.KhoLinhKienOutputInfo.Remove(d.First());
                                    DataProvider.Ins.DB.SaveChanges();
                                    d = DataProvider.Ins.DB.KhoLinhKienOutputInfo.Where(x => x.MaPhieu == MaPhieu);
                                }
                                var e = DataProvider.Ins.DB.KhoLinhKienOutput.Where(x => x.MaPhieu == MaPhieu);
                                while (e.Count() > 0)
                                {
                                    DataProvider.Ins.DB.KhoLinhKienOutput.Remove(e.First());
                                    DataProvider.Ins.DB.SaveChanges();
                                    e = DataProvider.Ins.DB.KhoLinhKienOutput.Where(x => x.MaPhieu == MaPhieu);
                                }
                                MessageBox.Show("Mã hàng đã xuất rồi!", "Dữ liệu nhập!", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }
                        
                        if (IdKhachHang == "GcDk      ") 
                        { 
                            DKNguyenLieuLK phieunhap = new DKNguyenLieuLK();
                            foreach (var item in PhieuXuatInfoList)
                            {
                                phieunhap.Ngay = NgayCT;
                                phieunhap.SoLo = item.SoLo;
                                phieunhap.SoHoa = item.SoHoa;
                                phieunhap.SoLuong = item.SoLuongNhap;
                                phieunhap.IdU = item.IdU;
                                phieunhap.NhapXuat = "Nhập";
                                phieunhap.UserName = Cw3_Product.Properties.Settings.Default.account;
                                DataProvider.Ins.DB.DKNguyenLieuLK.Add(phieunhap);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                        }

                        if (IdKhachHang == "Lr        ") 
                        { 
                            LrNguyenLieuLk phieunhap = new LrNguyenLieuLk();
                            foreach (var item in PhieuXuatInfoList)
                            {
                                phieunhap.Ngay = NgayCT;
                                phieunhap.SoLo = item.SoLo;
                                phieunhap.SoHoa = item.SoHoa;
                                phieunhap.SoLuong = item.SoLuongNhap;
                                phieunhap.IdU = item.IdU;
                                phieunhap.NhapXuat = "Nhập";
                                phieunhap.UserName = Cw3_Product.Properties.Settings.Default.account;
                                DataProvider.Ins.DB.LrNguyenLieuLk.Add(phieunhap);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                        }
                                                
                        PhieuXuatInfoList = new ObservableCollection<KhoLinhKienOutputInfo>();
                        QRlist = new ObservableCollection<QRModel>();
                        FlagNew = false;
                        unFlagNew = true;
                        view = false;
                        Clearuper();
                        loadKhoNLInput();
                    }
                    catch (Exception ex)
                    {
                        var b = DataProvider.Ins.DB.KhoLinhKienOutputInfo.Where(x => x.MaPhieu == MaPhieu);
                        while (b.Count() > 0)
                        {
                            DataProvider.Ins.DB.KhoLinhKienOutputInfo.Remove(b.First());
                            DataProvider.Ins.DB.SaveChanges();
                            b = DataProvider.Ins.DB.KhoLinhKienOutputInfo.Where(x => x.MaPhieu == MaPhieu);
                        }
                        var a = DataProvider.Ins.DB.KhoLinhKienOutput.Where(x => x.MaPhieu == MaPhieu);
                        while (a.Count() > 0)
                        {
                            DataProvider.Ins.DB.KhoLinhKienOutput.Remove(a.First());
                            DataProvider.Ins.DB.SaveChanges();
                            a = DataProvider.Ins.DB.KhoLinhKienOutput.Where(x => x.MaPhieu == MaPhieu);
                        }
                        MessageBox.Show("Dữ liệu nhập bị lỗi!", "Dữ liệu nhập!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (check == MessageBoxResult.Cancel)
                {

                }
            });

            HuyDon = new RelayCommand<object>((p) => { if (FlagNew != true) return false; return true; }, (p) =>
            {
                PhieuXuatInfoList = new ObservableCollection<KhoLinhKienOutputInfo>();
                QRlist = new ObservableCollection<QRModel>();
                FlagNew = false;
                unFlagNew = true;
                view = false;
                Clearuper();
            });

            cuscommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                CustomerWindows suplierWindows = new CustomerWindows();
                suplierWindows.ShowDialog();
            });

            ImportExcel = new RelayCommand<object>((p) => { if (FlagNew == false) return false; return true; }, (p) =>
            {
                // tạo ra danh sách UserInfo rỗng để hứng dữ liệu.
                QRlist = new ObservableCollection<QRModel>();
                try
                {
                    string filePath = "";
                    // tạo SaveFileDialog để lưu file excel
                    OpenFileDialog dialog = new OpenFileDialog();
                    // mở file excel
                    dialog.Filter = "Excel file ( *.xlsx; *.xls; *.xlsm) | *.*";
                    dialog.FilterIndex = 1;
                    if (dialog.ShowDialog() == true)
                    {
                        filePath = dialog.FileName;
                    }

                    if (string.IsNullOrEmpty(filePath))
                    {
                        MessageBox.Show("Đường dẫn báo cáo không hợp lệ");
                        return;
                    }

                    var package = new ExcelPackage(new FileInfo(filePath));

                    // lấy ra sheet đầu tiên để thao tác
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[1];

                    // duyệt tuần tự từ dòng thứ 2 đến dòng cuối cùng của file. lưu ý file excel bắt đầu từ số 1 không phải số 0
                    for (int i = workSheet.Dimension.Start.Row; i <= workSheet.Dimension.End.Row; i++)
                    {
                        try
                        {
                            // biến j biểu thị cho một column trong file
                            int j = 1;

                            // lấy ra cột họ tên tương ứng giá trị tại vị trí [i, 1]. i lần đầu là 2
                            // tăng j lên 1 đơn vị sau khi thực hiện xong câu lệnh
                            if (string.IsNullOrEmpty(workSheet.Cells[i, 1].Text)) continue;
                            string qrcode = workSheet.Cells[i, j++].Text;

                            // lấy ra cột ngày sinh tương ứng giá trị tại vị trí [i, 2]. i lần đầu là 2
                            // tăng j lên 1 đơn vị sau khi thực hiện xong câu lệnh
                            // lấy ra giá trị ngày tháng và ép kiểu thành DateTime                      
                            var ngayy = workSheet.Cells[i, j++].Value;
                            DateTime ngay = new DateTime();
                            if (ngayy != null)
                            {
                                ngay = (DateTime)ngayy;
                            }

                            /*                         

                            Đừng lười biến mà dùng đoạn code này sẽ gây ra lỗi nếu giá trị value không thỏa kiểu DateTime

                            DateTime birthday = (DateTime)workSheet.Cells[i, j++].Value;

                             */
                            string vitri = workSheet.Cells[i, j++].Text;

                            // tạo UserInfo từ dữ liệu đã lấy được
                            QRModel qrmodel = new QRModel()
                            {
                                QRcode = qrcode,
                                ThoiGian = ngay,
                                ViTri = vitri
                            };

                            // add UserInfo vào danh sách userList
                            QRlist.Add(qrmodel);

                        }
                        catch (Exception exe)
                        {

                        }
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Error!");
                }

            });

            ChuyenMaHang = new RelayCommand<object>((p) => { if (QRlist == null || FlagNew == false) return false; return true; }, (p) =>
            {
                tab2 = true;
                PhieuXuatInfoList = new ObservableCollection<KhoLinhKienOutputInfo>();
                foreach (var qr in QRlist)
                {
                    if (qr.QRcode == null) continue;
                    KhoLinhKienOutputInfo info = new KhoLinhKienOutputInfo();
                    info.QRcode = qr.QRcode;
                    string[] code = qr.QRcode.Split('-');

                    info.MaPhieu = MaPhieu;

                    info.SoHoa = code[3];
                    var mmh = DataProvider.Ins.DB.BomLk.Where(x => x.SoHoa == info.SoHoa);
                    if (mmh == null || mmh.Count() == 0)
                    {
                        MessageBox.Show("Mã hàng không đúng!", "Dữ liệu nhập!", MessageBoxButton.OK, MessageBoxImage.Error);
                        continue;
                    }
                    info.DisplayName = mmh.First().DisplayName;
                    info.QuyCach = code[4];
                    info.SoLuongNhap = Int32.Parse(code[6]);
                    info.IdU = mmh.First().IdU;
                    info.KhoiLuongKien = Int32.Parse(code[5]);
                    info.MaKho = "WAR02";
                    info.GhiChu = null;
                    info.ViTri = qr.ViTri;
                    info.UserName = Cw3_Product.Properties.Settings.Default.account;
                    info.SoLo = SoLo;

                    PhieuXuatInfoList.Add(info);
                }
            });

            KhoNLdatechange = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                Taoidnhaplieu();
            });

            filtercommandInputNL = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                loadKhoNLInput();
            });

            ViewDon = new RelayCommand<object>((p) => { if (FlagNew == true) return false; return true; }, (p) =>
            {
                PhieuXuatInfoList = new ObservableCollection<KhoLinhKienOutputInfo>(DataProvider.Ins.DB.KhoLinhKienOutputInfo.Where(x => x.MaPhieu == MaPhieu));
                tab2 = true;
                tab1 = false;
                view = true;
                FlagNew = false;
                unFlagNew = true;
                string matam = MaPhieu;
                var a = DataProvider.Ins.DB.KhoLinhKienOutput.Where(y => y.MaPhieu == MaPhieu).FirstOrDefault();
                NgayCT = a.DateCT;
                NgayXuat = a.DateXuat;
                IdKhachHang = a.IdCus;
                NCCDisplayName = a.DisplayName;
                POMuaHang = a.POMuaHang;
                GhiChu = a.GhiChu;
                MaPhieu = matam;
            });

            deletecommandInputNL = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                var b = DataProvider.Ins.DB.KhoLinhKienOutputInfo.Where(x => x.MaPhieu == MaPhieu);
                while (b.Count() > 0)
                {
                    DataProvider.Ins.DB.KhoLinhKienOutputInfo.Remove(b.First());
                    DataProvider.Ins.DB.SaveChanges();
                    b = DataProvider.Ins.DB.KhoLinhKienOutputInfo.Where(x => x.MaPhieu == MaPhieu);
                }
                var a = DataProvider.Ins.DB.KhoLinhKienOutput.Where(x => x.MaPhieu == MaPhieu);
                while (a.Count() > 0)
                {
                    DataProvider.Ins.DB.KhoLinhKienOutput.Remove(a.First());
                    DataProvider.Ins.DB.SaveChanges();
                    a = DataProvider.Ins.DB.KhoLinhKienOutput.Where(x => x.MaPhieu == MaPhieu);
                }
                loadKhoNLInput();
            });

            ExportExcel = new RelayCommand<object>((p) => { if (PhieuXuatInfoList == null) return false; return true; }, (p) =>
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
                        excel.Workbook.Properties.Title = "Export Output TP";

                        //Tạo một sheet để làm việc trên đó
                        excel.Workbook.Worksheets.Add("OutputTp");

                        // lấy sheet vừa add ra để thao tác
                        ExcelWorksheet ws = excel.Workbook.Worksheets[1];

                        // đặt tên cho sheet
                        ws.Name = "OutputTp";
                        // fontsize mặc định cho cả sheet
                        ws.Cells.Style.Font.Size = 11;
                        // font family mặc định cho cả sheet
                        ws.Cells.Style.Font.Name = "Times New Roman";

                        ws.Column(1).Width = 5.38;
                        ws.Column(2).Width = 16.38;
                        ws.Column(3).Width = 25.75;
                        ws.Column(4).Width = 7.5;
                        ws.Column(5).Width = 15.5;
                        ws.Column(6).Width = 30.5;

                        ws.Row(1).Height = 14.25;
                        ws.Row(2).Height = 14.25;
                        ws.Row(3).Height = 14.25;
                        ws.Row(4).Height = 14.25;
                        ws.Row(5).Height = 25.5;
                        ws.Row(6).Height = 18.75;
                        ws.Row(7).Height = 14.25;
                        ws.Row(8).Height = 15;
                        ws.Row(9).Height = 15;
                        ws.Row(10).Height = 15;
                        ws.Row(11).Height = 15;
                        ws.Row(12).Height = 14.25;

                        ws.Row(13).Height = 15;
                        ws.Row(14).Height = 25.5;
                        ws.Row(15).Height = 25.5;
                        ws.Row(16).Height = 25.5;
                        ws.Row(17).Height = 25.5;
                        ws.Row(18).Height = 25.5;
                        ws.Row(19).Height = 25.5;
                        ws.Row(20).Height = 25.5;
                        ws.Row(21).Height = 25.5;
                        ws.Row(22).Height = 25.5;
                        ws.Row(23).Height = 25.5;
                        ws.Row(24).Height = 25.5;
                        ws.Row(25).Height = 25.5;
                        ws.Row(26).Height = 15.75;

                        ws.Row(27).Height = 14.25;
                        ws.Row(28).Height = 15;
                        ws.Row(29).Height = 15;
                        ws.Row(30).Height = 14.25;

                        var border = ws.Cells[13, 1, 26, 6].Style.Border;
                        border.Bottom.Style =
                                border.Top.Style =
                                border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;

                        ws.Cells[5, 1, 5, 6].Merge = true;
                        ws.Cells[5, 1, 5, 6].Style.Font.Bold = true;
                        ws.Cells[5, 1, 5, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        ws.Cells[6, 1, 6, 5].Merge = true;
                        ws.Cells[6, 1, 6, 5].Style.Font.Italic = true;
                        ws.Cells[6, 1, 6, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        ws.Cells[26, 1, 26, 5].Merge = true;
                        ws.Cells[26, 1, 26, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                        ws.Cells[13, 1, 13, 6].Style.Font.Bold = true;
                        ws.Cells[13, 1, 25, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        ws.Cells[26, 6].Style.Font.Bold = true;
                        ws.Cells[26, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                        ws.Cells[28, 6].Style.Font.Italic = true;
                        ws.Cells[28, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                        ws.Cells[29, 1, 30, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[1, 1, 30, 6].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                        ws.Cells[30, 1, 30, 6].Style.Font.Italic = true;
                        ws.Cells[30, 1, 30, 6].Style.Font.Size = 10;

                        ws.Cells[1, 1].Value = "CÔNG TY CỔ PHẦN CLEARWATER METAL VN";
                        ws.Cells[1, 1].Style.Font.Size = 9;

                        ws.Cells[2, 1].Value = "XƯỞNG BÁNH XE";
                        ws.Cells[2, 1].Style.Font.Size = 9;

                        ws.Cells[3, 1].Value = "Lô B3 (Khu A3), Đường D9, Khu công nghiệp Rạch Bắp, Xã An Tây, Thị xã Bến Cát, Tỉnh Bình Dương, Việt Nam";
                        ws.Cells[3, 1].Style.Font.Size = 9;


                        ws.Cells[5, 1].Value = "PHIẾU XUẤT BTP THÉP";
                        ws.Cells[5, 1].Style.Font.Size = 20;


                        int ngay = NgayCT.Value.Day;
                        int thang = NgayCT.Value.Month;
                        int nam = NgayCT.Value.Year;

                        ws.Cells[6, 1].Value = "                                                          Ngày " + ngay.ToString() + " Tháng " + thang.ToString() + " Năm " + nam.ToString();
                        ws.Cells[6, 1].Style.Font.Size = 13;

                        ws.Cells[6, 6].Value = "SỐ: " + MaPhieu;
                        ws.Cells[6, 6].Style.Font.Size = 14;
                        ws.Cells[6, 6].Style.Font.Bold = true;
                        ws.Cells[6, 6].Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;

                        ws.Cells[8, 1].Value = "Người nhận hàng:";
                        ws.Cells[9, 1].Value = "Công ty:";
                        ws.Cells[10, 1].Value = "Địa chỉ:";
                        ws.Cells[11, 1].Value = "Nội dung:";

                        ws.Cells[8, 3].Value = DataProvider.Ins.DB.Customer.Where(x => x.IdCus == IdKhachHang).First().MoreInfo;
                        ws.Cells[9, 3].Value = DataProvider.Ins.DB.Customer.Where(x => x.IdCus == IdKhachHang).First().DisplayName;
                        ws.Cells[10, 3].Value = DataProvider.Ins.DB.Customer.Where(x => x.IdCus == IdKhachHang).First().DiaChi;                        
                        ws.Cells[11, 3].Value = "Xuất linh kiện thép";

                        ws.Cells[13, 1].Value = "STT";
                        ws.Cells[13, 2].Value = "Mã BTP Thép";
                        ws.Cells[13, 3].Value = "Tên NL";
                        ws.Cells[13, 4].Value = "ĐVT";
                        ws.Cells[13, 5].Value = "Trọng Lượng";
                        ws.Cells[13, 6].Value = "Ghi Chú";

                        int k = 14;
                        int? sum = 0;
                        foreach (var item in PhieuXuatInfoList)
                        {
                            ws.Cells[k, 1].Value = k-13;
                            ws.Cells[k, 2].Value = item.SoHoa.Replace(" ","");
                            ws.Cells[k, 3].Value = item.DisplayName;
                            ws.Cells[k, 4].Value = "Kg";
                            ws.Cells[k, 5].Value = item.KhoiLuongKien;
                            ws.Cells[k, 6].Value = item.SoLuongNhap + " Pcs";
                            sum += item.KhoiLuongKien;
                            k++;
                        }
                        
                        ws.Cells[26, 1, 26, 5].Value = "TỔNG CỘNG:";
                        ws.Cells[26, 6].Value = sum + " Kg";
                        ws.Cells[28, 6].Value = "Ngày " + ngay.ToString() + " Tháng " + thang.ToString() + " Năm " + nam.ToString();
                        ws.Cells[29, 2].Value = "NGƯỜI GIAO HÀNG";
                        ws.Cells[29, 4].Value = "NGƯỜI NHẬN HÀNG";
                        ws.Cells[29, 6].Value = "CHỦ QUẢN KHO";
                        ws.Cells[30, 2].Value = "Ký, họ tên";
                        ws.Cells[30, 4].Value = "Ký, họ tên";
                        ws.Cells[30, 6].Value = "Ký, họ tên";

                        ws.PrinterSettings.PrintArea = ws.Cells[1, 1, 30, 6];
                        ws.PrinterSettings.PaperSize = ePaperSize.A4;
                        ws.PrinterSettings.Orientation = eOrientation.Portrait;
                        ws.PrinterSettings.HorizontalCentered = true;
                        ws.PrinterSettings.FitToPage = true;
                        ws.PrinterSettings.FitToWidth = 1;
                        ws.PrinterSettings.FitToHeight = 0;
                        ws.PrinterSettings.HeaderMargin = 0.31M;
                        ws.PrinterSettings.FooterMargin = 0.31M;
                        ws.PrinterSettings.TopMargin = 0.75M;
                        ws.PrinterSettings.BottomMargin = 0.75M;
                        ws.PrinterSettings.LeftMargin = 0.31M;
                        ws.PrinterSettings.RightMargin = 0.31M;



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

        void loadKhoNLInput()
        {
            DateTime? OuputTpStart = KhoOutputTpNgayStart;
            DateTime? OuputTpEnd = KhoOutputTpNgayEnd;
            if (OuputTpStart == null) OuputTpStart = DateTime.MinValue;
            if (OuputTpEnd == null) OuputTpEnd = DateTime.Now;
            PhieuXuatList = new ObservableCollection<KhoLinhKienOutput>(DataProvider.Ins.DB.KhoLinhKienOutput.Where(x => x.DateCT >= OuputTpStart && x.DateCT <= OuputTpEnd));
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
                var check = DataProvider.Ins.DB.KhoLinhKienOutput.Where(x => x.MaPhieu == ("KLK-X-" + i.ToString()));
                if (check == null || check.Count() == 0)
                {
                    stt = i;
                    flag = true;
                }
            }
            MaPhieu = "KLK-X-" + stt.ToString();
        }
        void Clearuper()
        {
            NgayCT = null;
            NgayXuat = null;
            MaPhieu = null;
            SoLo = null;
            MaTp = null;
            IdKhachHang = null;
            NCCDisplayName = null;
            POMuaHang = null;
            GhiChu = null;
        }
    }
}
