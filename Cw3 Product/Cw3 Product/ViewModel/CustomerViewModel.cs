using Cw3_Product.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cw3_Product.ViewModel
{
    public class CustomerViewModel : BaseViewModel
    {

        //Khai báo list hiển thị Cuslier
        private ObservableCollection<Customer> _CusList;
        public ObservableCollection<Customer> CusList { get => _CusList; set { _CusList = value; OnPropertyChanged(); } }

        //Khai báo command thêm sửa xóa Cuslier
        public ICommand addcommandCus { get; set; }
        public ICommand editcommandCus { get; set; }
        public ICommand deletecommandCus { get; set; }
        public ICommand ClearCus { get; set; }

        //Khai báo biến Cuslier
        private string _IdCus;
        public string IdCus { get => _IdCus; set { _IdCus = value; OnPropertyChanged(); } }

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

        private Model.Customer _SelectedItem;
        public Model.Customer SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value; OnPropertyChanged(); if (_SelectedItem != null)
                {
                    IdCus = SelectedItem.IdCus;
                    DisplayName = SelectedItem.DisplayName;
                    DiaChi = SelectedItem.DiaChi;
                    Phone = SelectedItem.Phone;
                    Email = SelectedItem.Email;
                    MoreInfo = SelectedItem.MoreInfo;
                    NgayHT = SelectedItem.DateContract;
                }
            }
        }


        public CustomerViewModel() 
        {
            CusList = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customer);
            addcommandCus = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(IdCus) || string.IsNullOrEmpty(DisplayName))
                    return false;
                var lktplist = DataProvider.Ins.DB.Customer.Where(x => x.IdCus == IdCus);
                if (lktplist == null || lktplist.Count() != 0) return false;
                return true;
            }, (p) =>
            {
                var themdonlktp = new Customer() { IdCus = IdCus, DisplayName = DisplayName, DiaChi = DiaChi, Phone = Phone, UserName = Cw3_Product.Properties.Settings.Default.account, Email = Email, DateContract = NgayHT, MoreInfo = MoreInfo };

                DataProvider.Ins.DB.Customer.Add(themdonlktp);
                DataProvider.Ins.DB.SaveChanges();
                loadCus();
            });

            editcommandCus = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(IdCus) || string.IsNullOrEmpty(DisplayName))
                    return false;
                var sttlist = DataProvider.Ins.DB.Customer.Where(x => x.IdCus == IdCus);
                if (sttlist == null || sttlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                var suadonlktp = DataProvider.Ins.DB.Customer.Where(x => x.IdCus == IdCus).SingleOrDefault();
                suadonlktp.DisplayName = DisplayName;
                suadonlktp.DiaChi = DiaChi;
                suadonlktp.Phone = Phone;
                suadonlktp.Email = Email;
                suadonlktp.DateContract = NgayHT;
                suadonlktp.MoreInfo = MoreInfo;
                suadonlktp.UserName = Cw3_Product.Properties.Settings.Default.account;
                DataProvider.Ins.DB.SaveChanges();
                loadCus();

            });

            deletecommandCus = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(IdCus) || string.IsNullOrEmpty(DisplayName))
                    return false;
                var sttlist = DataProvider.Ins.DB.Customer.Where(x => x.IdCus == IdCus);
                if (sttlist == null || sttlist.Count() == 0) return false;

                return true;
            }, (p) =>
            {
                try
                {
                    var bomlktp = DataProvider.Ins.DB.Customer.Where(x => x.IdCus == IdCus).SingleOrDefault();
                    DataProvider.Ins.DB.Customer.Remove(bomlktp);
                    DataProvider.Ins.DB.SaveChanges();
                    loadCus();
                }
                catch (Exception)
                {
                    MessageBox.Show("Nhà cũng cấp đang sử dụng, không thể xóa!", "Xóa nhà cung cấp!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });

            ClearCus = new RelayCommand<object>((p) =>
            {
                return true;
            }, (p) =>
            {
                clearCus();
            });
        }
        void clearCus()
        {
            IdCus = null;
            DisplayName = null;
            DiaChi = null;
            Phone = null;
            Email = null;
            NgayHT = null;
            MoreInfo = null;
        }
        void loadCus()
        {
            CusList = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customer);
        }
    }
}
