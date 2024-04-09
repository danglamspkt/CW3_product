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
    public class DapKhuonChiTietViewModel : BaseViewModel
    {
        //Khai báo list hiển thị Sản Lượng
        private ObservableCollection<DKSanXuat> _SanLuongList;
        public ObservableCollection<DKSanXuat> SanLuongList { get => _SanLuongList; set { _SanLuongList = value; OnPropertyChanged(); } }

        private DKSanXuat _SanLuongList2;
        public DKSanXuat SanLuongList2 { get => _SanLuongList2; set { _SanLuongList2 = value; OnPropertyChanged(); } }

        private Model.DKSanXuat _SelectedItemSl;
        public Model.DKSanXuat SelectedItemSl
        {
            get => _SelectedItemSl; set
            {
                _SelectedItemSl = value; OnPropertyChanged(); if (_SelectedItemSl != null)
                {
                    try
                    {
                        SanLuongList2 = DataProvider.Ins.DB.DKSanXuat.Where(x => x.IdSxDk == SelectedItemSl.IdSxDk).First();
                        DataProvider.Ins.DB.DKSanXuat.AddOrUpdate(x => x.IdSxDk, SanLuongList2);
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
        private ObservableCollection<DkThoiGian> _TimeList;
        public ObservableCollection<DkThoiGian> TimeList { get => _TimeList; set { _TimeList = value; OnPropertyChanged(); } }

        private DkThoiGian _TimeList2;
        public DkThoiGian TimeList2 { get => _TimeList2; set { _TimeList2 = value; OnPropertyChanged(); } }

        private Model.DkThoiGian _SelectedItemTime;
        public Model.DkThoiGian SelectedItemTime
        {
            get => _SelectedItemTime; set
            {
                _SelectedItemTime = value; OnPropertyChanged(); if (_SelectedItemTime != null)
                {
                    try
                    {
                        TimeList2 = DataProvider.Ins.DB.DkThoiGian.Where(x => x.IdDkTime == SelectedItemTime.IdDkTime).First();
                        DataProvider.Ins.DB.DkThoiGian.AddOrUpdate(x => x.IdDkTime, TimeList2);
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
        private ObservableCollection<DKKiemTra> _CheckList;
        public ObservableCollection<DKKiemTra> CheckList { get => _CheckList; set { _CheckList = value; OnPropertyChanged(); } }

        private DKKiemTra _CheckList2;
        public DKKiemTra CheckList2 { get => _CheckList2; set { _CheckList2 = value; OnPropertyChanged(); } }

        private Model.DKKiemTra _SelectedItemCheck;
        public Model.DKKiemTra SelectedItemCheck
        {
            get => _SelectedItemCheck; set
            {
                _SelectedItemCheck = value; OnPropertyChanged(); if (_SelectedItemCheck != null)
                {
                    try
                    {
                        CheckList2 = DataProvider.Ins.DB.DKKiemTra.Where(x => x.IdSxCheck == SelectedItemCheck.IdSxCheck).First();
                        DataProvider.Ins.DB.DKKiemTra.AddOrUpdate(x => x.IdSxCheck, CheckList2);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Dữ liệu nhập bị lỗi!", "Dữ liệu nhập!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        public DapKhuonChiTietViewModel() 
        {
            SanLuongList = new ObservableCollection<DKSanXuat>(DataProvider.Ins.DB.DKSanXuat);
            TimeList = new ObservableCollection<DkThoiGian>(DataProvider.Ins.DB.DkThoiGian);
            CheckList = new ObservableCollection<DKKiemTra>(DataProvider.Ins.DB.DKKiemTra);
        }
    }
}
