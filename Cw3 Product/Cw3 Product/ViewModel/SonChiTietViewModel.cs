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
    public class SonChiTietViewModel : BaseViewModel
    {
        //Khai báo list hiển thị Sản Lượng
        private ObservableCollection<SonSanXuat> _SanLuongList;
        public ObservableCollection<SonSanXuat> SanLuongList { get => _SanLuongList; set { _SanLuongList = value; OnPropertyChanged(); } }

        private SonSanXuat _SanLuongList2;
        public SonSanXuat SanLuongList2 { get => _SanLuongList2; set { _SanLuongList2 = value; OnPropertyChanged(); } }

        private Model.SonSanXuat _SelectedItemSl;
        public Model.SonSanXuat SelectedItemSl
        {
            get => _SelectedItemSl; set
            {
                _SelectedItemSl = value; OnPropertyChanged(); if (_SelectedItemSl != null)
                {
                    try
                    {
                        SanLuongList2 = DataProvider.Ins.DB.SonSanXuat.Where(x => x.IdSxSon == SelectedItemSl.IdSxSon).First();
                        DataProvider.Ins.DB.SonSanXuat.AddOrUpdate(x => x.IdSxSon, SanLuongList2);
                        DataProvider.Ins.DB.SaveChanges();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Dữ liệu nhập bị lỗi!", "Dữ liệu nhập!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        public SonChiTietViewModel() 
        {
            SanLuongList = new ObservableCollection<SonSanXuat>(DataProvider.Ins.DB.SonSanXuat);
        }
    }
}
