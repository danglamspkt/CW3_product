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
using ControlzEx.Standard;

namespace Cw3_Product.ViewModel
{
    public class KhoOutputNlViewModel : BaseViewModel
    {
        //-------------------------Khai báo list hiển thị QR thô--------------------------------------------------
        private ObservableCollection<QRModel> _QRlist;
        public ObservableCollection<QRModel> QRlist { get => _QRlist; set { _QRlist = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển phiếu xuất--------------------------------------------------
        private ObservableCollection<KhoNguyenLieuOutput> _PhieuXuatList;
        public ObservableCollection<KhoNguyenLieuOutput> PhieuXuatList { get => _PhieuXuatList; set { _PhieuXuatList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị phiếu xuất info--------------------------------------------------
        private ObservableCollection<KhoNguyenLieuOutputInfo> _PhieuXuatInfoList;
        public ObservableCollection<KhoNguyenLieuOutputInfo> PhieuXuatInfoList { get => _PhieuXuatInfoList; set { _PhieuXuatInfoList = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Đơn vị--------------------------------------------------
        private ObservableCollection<Unit> _donvilist;
        public ObservableCollection<Unit> donvilist { get => _donvilist; set { _donvilist = value; OnPropertyChanged(); } }

        //-------------------------Khai báo list hiển thị Mã Mua Hàng--------------------------------------------------
        private ObservableCollection<BomNl> _MaMuaHangList;
        public ObservableCollection<BomNl> MaMuaHangList { get => _MaMuaHangList; set { _MaMuaHangList = value; OnPropertyChanged(); } }

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

        private Model.KhoNguyenLieuOutput _SelectedItem;
        public Model.KhoNguyenLieuOutput SelectedItem
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

        public KhoOutputNlViewModel() 
        {
            FlagNew = false;
            unFlagNew = true;
            view = false;
            tab1 = true; tab2= false;
            if (PhieuNhapKhoNguyenLieu.ContextMenuOpeningEvent != null) loadKhoNLInput();
            DateTime time = DateTime.Now;
            if (NgayCT != null) { time = (DateTime)NgayCT; }
            QRlist = new ObservableCollection<QRModel>();
            PhieuXuatList = new ObservableCollection<KhoNguyenLieuOutput>(DataProvider.Ins.DB.KhoNguyenLieuOutput);
            

            TaoDon = new RelayCommand<object>((p) => { if (FlagNew == true) return false; return true; }, (p) =>
            {
                Clearuper();
                NgayCT = DateTime.Today;
                NgayXuat = DateTime.Today;
                Taoidnhaplieu();
                MaMuaHangList = new ObservableCollection<BomNl>(DataProvider.Ins.DB.BomNl);
                donvilist = new ObservableCollection<Unit>(DataProvider.Ins.DB.Unit);
                Khachhanglist = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customer);
                SoLoList = new ObservableCollection<DonHangTp>(DataProvider.Ins.DB.DonHangTp.Where(u => u.TinhTrang == "Sản xuất"));
                PhieuXuatInfoList = new ObservableCollection<KhoNguyenLieuOutputInfo>();
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
                        var b = DataProvider.Ins.DB.KhoNguyenLieuOutputInfo.Where(x => x.MaPhieu == MaPhieu);
                        while (b.Count() > 0)
                        {
                            DataProvider.Ins.DB.KhoNguyenLieuOutputInfo.Remove(b.First());
                            DataProvider.Ins.DB.SaveChanges();
                            b = DataProvider.Ins.DB.KhoNguyenLieuOutputInfo.Where(x => x.MaPhieu == MaPhieu);
                        }
                        var a = DataProvider.Ins.DB.KhoNguyenLieuOutput.Where(x => x.MaPhieu == MaPhieu);
                        while (a.Count() > 0)
                        {
                            DataProvider.Ins.DB.KhoNguyenLieuOutput.Remove(a.First());
                            DataProvider.Ins.DB.SaveChanges();
                            a = DataProvider.Ins.DB.KhoNguyenLieuOutput.Where(x => x.MaPhieu == MaPhieu);
                        }

                        KhoNguyenLieuOutput khoout = new KhoNguyenLieuOutput { MaPhieu = MaPhieu, DateCT = NgayCT, DateXuat = NgayXuat, IdCus = IdKhachHang, DisplayName = NCCDisplayName, POMuaHang = POMuaHang, GhiChu = GhiChu, UserName = Cw3_Product.Properties.Settings.Default.account };
                        DataProvider.Ins.DB.KhoNguyenLieuOutput.Add(khoout);
                        DataProvider.Ins.DB.SaveChanges();

                        foreach (var item in PhieuXuatInfoList)
                        {
                            var c = DataProvider.Ins.DB.KhoNguyenLieuOutputInfo.Where(y => y.QRcode == item.QRcode);
                            if (c == null || c.Count() == 0)
                            {                                
                                DataProvider.Ins.DB.KhoNguyenLieuOutputInfo.Add(item);
                                DataProvider.Ins.DB.SaveChanges();                                
                            }
                            else
                            {
                                var d = DataProvider.Ins.DB.KhoNguyenLieuOutputInfo.Where(x => x.MaPhieu == MaPhieu);
                                while (d.Count() > 0)
                                {
                                    DataProvider.Ins.DB.KhoNguyenLieuOutputInfo.Remove(d.First());
                                    DataProvider.Ins.DB.SaveChanges();
                                    d = DataProvider.Ins.DB.KhoNguyenLieuOutputInfo.Where(x => x.MaPhieu == MaPhieu);
                                }
                                var e = DataProvider.Ins.DB.KhoNguyenLieuOutput.Where(x => x.MaPhieu == MaPhieu);
                                while (e.Count() > 0)
                                {
                                    DataProvider.Ins.DB.KhoNguyenLieuOutput.Remove(e.First());
                                    DataProvider.Ins.DB.SaveChanges();
                                    e = DataProvider.Ins.DB.KhoNguyenLieuOutput.Where(x => x.MaPhieu == MaPhieu);
                                }
                                MessageBox.Show("Mã hàng đã xuất rồi!", "Dữ liệu nhập!", MessageBoxButton.OK, MessageBoxImage.Error);
                                return;
                            }
                        }

                        if (IdKhachHang == "GcDk      ")
                        {
                            DKNguyenLieu phieunhap = new DKNguyenLieu();
                            foreach (var item in PhieuXuatInfoList)
                            {
                                phieunhap.Ngay = NgayCT;
                                phieunhap.SoLo = item.SoLo;
                                phieunhap.MaMuaHang = item.MaMuaHang;
                                phieunhap.SoLuong = item.SoLuongNhap;
                                phieunhap.IdU = item.IdU;
                                phieunhap.NhapXuat = "Nhập";
                                phieunhap.UserName = Cw3_Product.Properties.Settings.Default.account;
                                DataProvider.Ins.DB.DKNguyenLieu.Add(phieunhap);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                        }

                        if (IdKhachHang == "Lr        ")
                        {
                            LrNguyenLieu phieunhap = new LrNguyenLieu();
                            foreach (var item in PhieuXuatInfoList)
                            {
                                phieunhap.Ngay = NgayCT;
                                phieunhap.SoLo = item.SoLo;
                                phieunhap.MaMuaHang = item.MaMuaHang;
                                phieunhap.SoLuong = item.SoLuongNhap;
                                phieunhap.IdU = item.IdU;
                                phieunhap.NhapXuat = "Nhập";
                                phieunhap.UserName = Cw3_Product.Properties.Settings.Default.account;
                                DataProvider.Ins.DB.LrNguyenLieu.Add(phieunhap);
                                DataProvider.Ins.DB.SaveChanges();
                            }
                        }

                        PhieuXuatInfoList = new ObservableCollection<KhoNguyenLieuOutputInfo>();
                        QRlist = new ObservableCollection<QRModel>();
                        FlagNew = false;
                        unFlagNew = true;
                        view = false;
                        Clearuper();
                        loadKhoNLInput();
                    }
                    catch (Exception ex)
                    {
                        var b = DataProvider.Ins.DB.KhoNguyenLieuOutputInfo.Where(x => x.MaPhieu == MaPhieu);
                        while (b.Count() > 0)
                        {
                            DataProvider.Ins.DB.KhoNguyenLieuOutputInfo.Remove(b.First());
                            DataProvider.Ins.DB.SaveChanges();
                            b = DataProvider.Ins.DB.KhoNguyenLieuOutputInfo.Where(x => x.MaPhieu == MaPhieu);
                        }
                        var a = DataProvider.Ins.DB.KhoNguyenLieuOutput.Where(x => x.MaPhieu == MaPhieu);
                        while (a.Count() > 0)
                        {
                            DataProvider.Ins.DB.KhoNguyenLieuOutput.Remove(a.First());
                            DataProvider.Ins.DB.SaveChanges();
                            a = DataProvider.Ins.DB.KhoNguyenLieuOutput.Where(x => x.MaPhieu == MaPhieu);
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
                PhieuXuatInfoList = new ObservableCollection<KhoNguyenLieuOutputInfo>();
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
                    for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                    {
                        try
                        {
                            // biến j biểu thị cho một column trong file
                            int j = 1;

                            // lấy ra cột họ tên tương ứng giá trị tại vị trí [i, 1]. i lần đầu là 2
                            // tăng j lên 1 đơn vị sau khi thực hiện xong câu lệnh
                            string qrcode = workSheet.Cells[i, j++].Value.ToString();

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
                            string vitri = workSheet.Cells[i, j++].Value.ToString();

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
                PhieuXuatInfoList = new ObservableCollection<KhoNguyenLieuOutputInfo>();
                foreach (var qr in QRlist)
                {                  
                    if (qr.QRcode == null) continue;
                    KhoNguyenLieuOutputInfo info = new KhoNguyenLieuOutputInfo();
                    info.QRcode = qr.QRcode;
                    string[] code = qr.QRcode.Split('-');

                    info.MaPhieu = MaPhieu;

                    info.MaMuaHang = code[3];
                    //while (info.MaMuaHang.IndexOf(" ") != -1)
                    //{
                    //    info.MaMuaHang = info.MaMuaHang.Replace(" ", "");
                    //}

                    var mmh = DataProvider.Ins.DB.BomNl.Where(x => x.MaMuaHang == info.MaMuaHang);
                    if (mmh == null || mmh.Count() == 0)
                    {
                        MessageBox.Show("Mã hàng không đúng!", "Dữ liệu nhập!", MessageBoxButton.OK, MessageBoxImage.Error);
                        continue;
                    }
                    info.DisplayName = mmh.First().DisplayName;
                    info.ChatLieu = code[4];
                    info.QuyCach = code[5];
                    info.SoLuongNhap = Int32.Parse(code[7]);
                    info.IdU = mmh.First().IdU;
                    info.KhoiLuongKien = Int32.Parse(code[6]);
                    info.MaKho = "WAR01";
                    info.GhiChu =null;
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
                PhieuXuatInfoList = new ObservableCollection<KhoNguyenLieuOutputInfo>(DataProvider.Ins.DB.KhoNguyenLieuOutputInfo.Where(x => x.MaPhieu == MaPhieu));
                tab2 = true;
                tab1 = false;
                view = true;
                FlagNew = false;
                unFlagNew = true;
                string matam = MaPhieu;
                var a = DataProvider.Ins.DB.KhoNguyenLieuOutput.Where(y => y.MaPhieu == MaPhieu).FirstOrDefault();
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
                var b = DataProvider.Ins.DB.KhoNguyenLieuOutputInfo.Where(x => x.MaPhieu == MaPhieu);
                while (b.Count() > 0)
                {
                    DataProvider.Ins.DB.KhoNguyenLieuOutputInfo.Remove(b.First());
                    DataProvider.Ins.DB.SaveChanges();
                    b = DataProvider.Ins.DB.KhoNguyenLieuOutputInfo.Where(x => x.MaPhieu == MaPhieu);
                }
                var a = DataProvider.Ins.DB.KhoNguyenLieuOutput.Where(x => x.MaPhieu == MaPhieu);
                while (a.Count() > 0)
                {
                    DataProvider.Ins.DB.KhoNguyenLieuOutput.Remove(a.First());
                    DataProvider.Ins.DB.SaveChanges();
                    a = DataProvider.Ins.DB.KhoNguyenLieuOutput.Where(x => x.MaPhieu == MaPhieu);
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
                        excel.Workbook.Properties.Title = "Export Output NL";

                        //Tạo một sheet để làm việc trên đó
                        excel.Workbook.Worksheets.Add("OutputNl");

                        // lấy sheet vừa add ra để thao tác
                        ExcelWorksheet ws = excel.Workbook.Worksheets[1];

                        // đặt tên cho sheet
                        ws.Name = "OutputNl";
                        // fontsize mặc định cho cả sheet
                        ws.Cells.Style.Font.Size = 12;
                        // font family mặc định cho cả sheet
                        ws.Cells.Style.Font.Name = "Calibri";

                        // Tạo danh sách các column header
                        string[] arrColumnHeader = { "STT", "Ngày", "Mã phiếu", "Mã hàng", "Display Name", "Chất Liệu", "Quy cách", "Số lượng", "Đơn vị", "Khối lượng", "vị trí", "Ghi chú"};

                        // lấy ra số lượng cột cần dùng dựa vào số lượng header
                        var countColHeader = arrColumnHeader.Count();

                        // merge các column lại từ column 1 đến số column header
                        // gán giá trị cho cell vừa merge là Thống kê thông tni User Kteam
                        ws.Cells[1, 1].Value = "Phiếu xuất nguyên liệu";
                        ws.Cells[1, 1].Style.Font.Size = 24;
                        ws.Row(1).Height = 31.5;
                        ws.Cells[1, 1, 1, countColHeader].Merge = true;
                        // in đậm
                        ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                        // căn giữa
                        ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        int colIndex = 1;
                        int rowIndex = 2;

                        //tạo các header từ column header đã tạo từ bên trên
                        foreach (var item in arrColumnHeader)
                        {
                            var cell = ws.Cells[rowIndex, colIndex];

                            //set màu thành gray
                            var fill = cell.Style.Fill;
                            fill.PatternType = ExcelFillStyle.Solid;
                            fill.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);

                            //căn chỉnh các border
                            var border = cell.Style.Border;
                            border.Bottom.Style =
                                border.Top.Style =
                                border.Left.Style =
                                border.Right.Style = ExcelBorderStyle.Thin;

                            //gán giá trị
                            cell.Value = item;
                            cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                            colIndex++;
                        }

                        ws.Column(1).Width = 5;
                        ws.Column(2).Width = 12;
                        ws.Column(3).Width = 22;
                        ws.Column(4).Width = 22;
                        ws.Column(5).Width = 22;
                        ws.Column(6).Width = 12;
                        ws.Column(7).Width = 22;
                        ws.Column(8).Width = 12;
                        ws.Column(9).Width = 12;
                        ws.Column(10).Width = 12;
                        ws.Column(11).Width = 12;
                        ws.Column(12).Width = 12;
                        //// lấy ra danh sách UserInfo từ ItemSource của DataGrid
                        //List<UserInfo> userList = dtgExcel.ItemsSource.Cast<UserInfo>().ToList();

                        //// với mỗi item trong danh sách sẽ ghi trên 1 dòng
                        //foreach (var item in userList)
                        //{
                        //    // bắt đầu ghi từ cột 1. Excel bắt đầu từ 1 không phải từ 0
                        //    colIndex = 1;

                        //    // rowIndex tương ứng từng dòng dữ liệu
                        //    rowIndex++;

                        //    //gán giá trị cho từng cell                      
                        //    ws.Cells[rowIndex, colIndex++].Value = item.;

                        //    // lưu ý phải .ToShortDateString để dữ liệu khi in ra Excel là ngày như ta vẫn thấy.Nếu không sẽ ra tổng số :v
                        //    ws.Cells[rowIndex, colIndex++].Value = item.Birthday.ToShortDateString();

                        //}
                        int i = 0;
                        foreach (var item in PhieuXuatInfoList)
                        {
                            i++;
                            ws.Cells[i + 2, 2].Style.Numberformat.Format = "dd/mm/yyyy";
                            for (int j = 1; j <= countColHeader;)
                            {
                                ws.Cells[i + 2, j++].Value = item.STT;
                                ws.Cells[i + 2, j++].Value = NgayCT;
                                ws.Cells[i + 2, j++].Value = MaPhieu;
                                ws.Cells[i + 2, j++].Value = item.MaMuaHang;
                                ws.Cells[i + 2, j++].Value = item.DisplayName;
                                ws.Cells[i + 2, j++].Value = item.ChatLieu;
                                ws.Cells[i + 2, j++].Value = item.QuyCach;
                                ws.Cells[i + 2, j++].Value = item.SoLuongNhap;
                                ws.Cells[i + 2, j++].Value = item.IdU;
                                ws.Cells[i + 2, j++].Value = item.KhoiLuongKien;
                                ws.Cells[i + 2, j++].Value = item.ViTri;
                                ws.Cells[i + 2, j++].Value = item.GhiChu;                                
                            }
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

        }

        void loadKhoNLInput()
        {
            DateTime? OuputTpStart = KhoOutputTpNgayStart;
            DateTime? OuputTpEnd = KhoOutputTpNgayEnd;
            if (OuputTpStart == null) OuputTpStart = DateTime.MinValue;
            if (OuputTpEnd == null) OuputTpEnd = DateTime.Now;
            PhieuXuatList = new ObservableCollection<KhoNguyenLieuOutput>(DataProvider.Ins.DB.KhoNguyenLieuOutput.Where(x => x.DateCT >= OuputTpStart && x.DateCT <= OuputTpEnd));
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
                var check = DataProvider.Ins.DB.KhoNguyenLieuOutput.Where(x => x.MaPhieu == ("KNL-X-" + i.ToString()));
                if (check == null || check.Count() == 0)
                {
                    stt = i;
                    flag = true;
                }
            }
            MaPhieu = "KNL-X-" + stt.ToString();
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
