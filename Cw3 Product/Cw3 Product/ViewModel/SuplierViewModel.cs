using Cw3_Product.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace Cw3_Product.ViewModel
{
    public class SuplierViewModel : BaseViewModel
    {

        //Khai báo list hiển thị suplier
        private ObservableCollection<Supplier> _SupList;
        public ObservableCollection<Supplier> SupList { get => _SupList; set { _SupList = value; OnPropertyChanged(); } }

        //Khai báo command thêm sửa xóa suplier
        public ICommand addcommandsup { get; set; }
        public ICommand editcommandsup { get; set; }
        public ICommand deletecommandsup { get; set; }
        public ICommand Clearsup { get; set; }

        //Khai báo biến suplier
        private string _IdSup;
        public string IdSup { get => _IdSup; set { _IdSup = value; OnPropertyChanged(); } }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        private string _DiaChi;
        public string DiaChi { get => _DiaChi; set { _DiaChi = value; OnPropertyChanged(); } }

        private string _Phone;
        public string Phone { get => _Phone; set { _Phone = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private string _MoreInfo;
        public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }

        private DateTime? _NgayHT;
        public DateTime? NgayHT { get => _NgayHT; set { _NgayHT = value; OnPropertyChanged(); } }

        private Model.Supplier _SelectedItem;
        public Model.Supplier SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged(); if (_SelectedItem != null)
                {
                    IdSup = SelectedItem.IdSup;
                    DisplayName = SelectedItem.DisplayName;
                    DiaChi = SelectedItem.DiaChi;
                    Phone = SelectedItem.Phone;
                    Email = SelectedItem.Email;
                    MoreInfo = SelectedItem.MoreInfo;
                    NgayHT = SelectedItem.DateContract;
                }
            }
        }

        public SuplierViewModel() 
        {
            SupList = new ObservableCollection<Supplier>(DataProvider.Ins.DB.Supplier);
            addcommandsup = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(IdSup) || string.IsNullOrEmpty(DisplayName))
                    return false;
                var lktplist = DataProvider.Ins.DB.Supplier.Where(x => x.IdSup == IdSup);
                if (lktplist == null || lktplist.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                var themdonlktp = new Supplier() { IdSup = IdSup, DisplayName = DisplayName, DiaChi = DiaChi, Phone = Phone, UserName = Cw3_Product.Properties.Settings.Default.account, Email = Email, DateContract = NgayHT, MoreInfo = MoreInfo };

                DataProvider.Ins.DB.Supplier.Add(themdonlktp);
                DataProvider.Ins.DB.SaveChanges();
                loadSup();
            });

            editcommandsup = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(IdSup) || string.IsNullOrEmpty(DisplayName))
                    return false;
                var sttlist = DataProvider.Ins.DB.Supplier.Where(x => x.IdSup == IdSup);
                if (sttlist == null || sttlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var suadonlktp = DataProvider.Ins.DB.Supplier.Where(x => x.IdSup == IdSup).SingleOrDefault();
                suadonlktp.DisplayName = DisplayName;
                suadonlktp.DiaChi = DiaChi;
                suadonlktp.Phone = Phone;
                suadonlktp.Email = Email;
                suadonlktp.DateContract = NgayHT;
                suadonlktp.MoreInfo = MoreInfo;
                suadonlktp.UserName = Cw3_Product.Properties.Settings.Default.account;
                DataProvider.Ins.DB.SaveChanges();
                loadSup();

            });

            deletecommandsup = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(IdSup) || string.IsNullOrEmpty(DisplayName))
                    return false;
                var sttlist = DataProvider.Ins.DB.Supplier.Where(x => x.IdSup == IdSup);
                if (sttlist == null || sttlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                try
                {
                    var bomlktp = DataProvider.Ins.DB.Supplier.Where(x => x.IdSup == IdSup).SingleOrDefault();
                    DataProvider.Ins.DB.Supplier.Remove(bomlktp);
                    DataProvider.Ins.DB.SaveChanges();
                    loadSup();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nhà cũng cấp đang sử dụng, không thể xóa!", "Xóa nhà cung cấp!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            Clearsup = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                clearSup();
            });
        }

        void clearSup()
        {
            IdSup = null;
            DisplayName = null;
            DiaChi = null;
            Phone = null;
            Email = null;
            NgayHT = null;
            MoreInfo = null;
        }
        void loadSup()
        {
            SupList = new ObservableCollection<Supplier>(DataProvider.Ins.DB.Supplier);
        }
    }
}
