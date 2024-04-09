using Cw3_Product.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cw3_Product.ViewModel
{
    public class GcEnSxChiTietViewModel : BaseViewModel
    {
        //Khai báo list hiển thị Nhiệt độ
        private ObservableCollection<EPNhietDo> _NhietDoList;
        public ObservableCollection<EPNhietDo> NhietDoList { get => _NhietDoList; set { _NhietDoList = value; OnPropertyChanged(); } }

        private EPNhietDo _NhietDoList2;
        public EPNhietDo NhietDoList2 { get => _NhietDoList2; set { _NhietDoList2 = value; OnPropertyChanged(); } }

        private Model.EPNhietDo _SelectedItem;
        public Model.EPNhietDo SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged(); if (_SelectedItem != null)
                {
                    try
                    {
                        NhietDoList2 = DataProvider.Ins.DB.EPNhietDo.Where(x => x.IdEnNhietDo == SelectedItem.IdEnNhietDo).First();
                        DataProvider.Ins.DB.EPNhietDo.AddOrUpdate(x => x.IdEnNhietDo, NhietDoList2);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Dữ liệu nhập bị lỗi!", "Dữ liệu nhập!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        //Khai báo list hiển thị Sản Lượng
        private ObservableCollection<EPSanXuat> _SanLuongList;
        public ObservableCollection<EPSanXuat> SanLuongList { get => _SanLuongList; set { _SanLuongList = value; OnPropertyChanged(); } }

        private EPSanXuat _SanLuongList2;
        public EPSanXuat SanLuongList2 { get => _SanLuongList2; set { _SanLuongList2 = value; OnPropertyChanged(); } }

        private Model.EPSanXuat _SelectedItemSl;
        public Model.EPSanXuat SelectedItemSl
        {
            get => _SelectedItemSl; set
            {
                _SelectedItemSl = value; OnPropertyChanged(); if (_SelectedItemSl != null)
                {
                    try
                    {
                        SanLuongList2 = DataProvider.Ins.DB.EPSanXuat.Where(x => x.IdSxEn == SelectedItemSl.IdSxEn).First();
                        DataProvider.Ins.DB.EPSanXuat.AddOrUpdate(x => x.IdSxEn, SanLuongList2);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Dữ liệu nhập bị lỗi!", "Dữ liệu nhập!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        //Khai báo list hiển thị Thời gian dừng máy
        private ObservableCollection<EPThoiGian> _TimeList;
        public ObservableCollection<EPThoiGian> TimeList { get => _TimeList; set { _TimeList = value; OnPropertyChanged(); } }

        private EPThoiGian _TimeList2;
        public EPThoiGian TimeList2 { get => _TimeList2; set { _TimeList2 = value; OnPropertyChanged(); } }

        private Model.EPThoiGian _SelectedItemTime;
        public Model.EPThoiGian SelectedItemTime
        {
            get => _SelectedItemTime; set
            {
                _SelectedItemTime = value; OnPropertyChanged(); if (_SelectedItemTime != null)
                {
                    try
                    {
                        TimeList2 = DataProvider.Ins.DB.EPThoiGian.Where(x => x.IdEnTime == SelectedItemTime.IdEnTime).First();
                        DataProvider.Ins.DB.EPThoiGian.AddOrUpdate(x => x.IdEnTime, TimeList2);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Dữ liệu nhập bị lỗi!", "Dữ liệu nhập!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        //Khai báo list hiển thị Kiểm tra
        private ObservableCollection<EPKiemTra> _CheckList;
        public ObservableCollection<EPKiemTra> CheckList { get => _CheckList; set { _CheckList = value; OnPropertyChanged(); } }

        private EPKiemTra _CheckList2;
        public EPKiemTra CheckList2 { get => _CheckList2; set { _CheckList2 = value; OnPropertyChanged(); } }

        private Model.EPKiemTra _SelectedItemCheck;
        public Model.EPKiemTra SelectedItemCheck
        {
            get => _SelectedItemCheck; set
            {
                _SelectedItemCheck = value; OnPropertyChanged(); if (_SelectedItemCheck != null)
                {
                    try
                    {
                        CheckList2 = DataProvider.Ins.DB.EPKiemTra.Where(x => x.IdEnKiemTra == SelectedItemCheck.IdEnKiemTra).First();
                        DataProvider.Ins.DB.EPKiemTra.AddOrUpdate(x => x.IdEnKiemTra, CheckList2);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Dữ liệu nhập bị lỗi!", "Dữ liệu nhập!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        //Khai báo list hiển thị Thêm nguyên liệu
        private ObservableCollection<EPThemNL> _ThemNlList;
        public ObservableCollection<EPThemNL> ThemNlList { get => _ThemNlList; set { _ThemNlList = value; OnPropertyChanged(); } }

        private EPThemNL _ThemNlList2;
        public EPThemNL ThemNlList2 { get => _ThemNlList2; set { _ThemNlList2 = value; OnPropertyChanged(); } }

        private Model.EPThemNL _SelectedItemThemNl;
        public Model.EPThemNL SelectedItemThemNl
        {
            get => _SelectedItemThemNl; set
            {
                _SelectedItemThemNl = value; OnPropertyChanged(); if (_SelectedItemThemNl != null)
                {
                    try
                    {
                        ThemNlList2 = DataProvider.Ins.DB.EPThemNL.Where(x => x.IdEnThemNL == SelectedItemThemNl.IdEnThemNL).First();
                        DataProvider.Ins.DB.EPThemNL.AddOrUpdate(x => x.IdEnThemNL, ThemNlList2);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Dữ liệu nhập bị lỗi!", "Dữ liệu nhập!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        //Khai báo list hiển thị kiểm tra máy
        private ObservableCollection<EPBaoDuong> _BaoDuongList;
        public ObservableCollection<EPBaoDuong> BaoDuongList { get => _BaoDuongList; set { _BaoDuongList = value; OnPropertyChanged(); } }

        private EPBaoDuong _BaoDuongList2;
        public EPBaoDuong BaoDuongList2 { get => _BaoDuongList2; set { _BaoDuongList2 = value; OnPropertyChanged(); } }

        private Model.EPBaoDuong _SelectedItemBaoDuong;
        public Model.EPBaoDuong SelectedItemBaoDuong
        {
            get => _SelectedItemBaoDuong; set
            {
                _SelectedItemBaoDuong = value; OnPropertyChanged(); if (_SelectedItemBaoDuong != null)
                {
                    try
                    {
                        BaoDuongList2 = DataProvider.Ins.DB.EPBaoDuong.Where(x => x.IdEnVeSinh == SelectedItemBaoDuong.IdEnVeSinh).First();
                        DataProvider.Ins.DB.EPBaoDuong.AddOrUpdate(x => x.IdEnVeSinh, BaoDuongList2);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Dữ liệu nhập bị lỗi!", "Dữ liệu nhập!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        public GcEnSxChiTietViewModel() 
        {
            NhietDoList = new ObservableCollection<EPNhietDo>(DataProvider.Ins.DB.EPNhietDo);
            SanLuongList = new ObservableCollection<EPSanXuat>(DataProvider.Ins.DB.EPSanXuat);
            TimeList = new ObservableCollection<EPThoiGian>(DataProvider.Ins.DB.EPThoiGian);
            CheckList = new ObservableCollection<EPKiemTra>(DataProvider.Ins.DB.EPKiemTra);
            ThemNlList = new ObservableCollection<EPThemNL>(DataProvider.Ins.DB.EPThemNL);
            BaoDuongList = new ObservableCollection<EPBaoDuong>(DataProvider.Ins.DB.EPBaoDuong);
        }
    }
}
