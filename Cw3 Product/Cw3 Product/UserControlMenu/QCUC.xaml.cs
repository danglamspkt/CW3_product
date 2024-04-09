using Cw3_Product.UserControlBaoTri;
using Cw3_Product.UserControlQC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cw3_Product.UserControlMenu
{
    /// <summary>
    /// Interaction logic for QCUC.xaml
    /// </summary>
    public partial class QCUC : UserControl
    {
        public QCUC()
        {
            InitializeComponent();
            UCQC.Children.Clear();
            var userControls = new QCHomeUC();
            UCQC.Children.Add(userControls);
        }


        private void TSCD_Click(object sender, RoutedEventArgs e)
        {
            

            txbKehoach1.Text = "QC / ";
            txbKehoach1.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach2.Text = "Tổng quan / ";
            txbKehoach2.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach3.Text = "Tổng quan 1";
            txbKehoach3.Foreground = new SolidColorBrush(Colors.Black);


        }

        private void KHBD_Click(object sender, RoutedEventArgs e)
        {
            txbKehoach1.Text = "QC / ";
            txbKehoach1.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach2.Text = "Tổng quan / ";
            txbKehoach2.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach3.Text = "Tổng quan 2";
            txbKehoach3.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void LSSC_Click(object sender, RoutedEventArgs e)
        {

            txbKehoach1.Text = "QC / ";
            txbKehoach1.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach2.Text = "Tổng quan / ";
            txbKehoach2.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach3.Text = "Tổng quan 3";
            txbKehoach3.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void TSCDNew_Click(object sender, RoutedEventArgs e)
        {
            txbKehoach1.Text = "QC / ";
            txbKehoach1.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach2.Text = "Cố định 1 / ";
            txbKehoach2.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach3.Text = "Tạo mới";
            txbKehoach3.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void TSCDView_Click(object sender, RoutedEventArgs e)
        {
            txbKehoach1.Text = "QC / ";
            txbKehoach1.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach2.Text = "Cố định 1 / ";
            txbKehoach2.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach3.Text = "Tra cứu";
            txbKehoach3.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void TSCDEdit_Click(object sender, RoutedEventArgs e)
        {
            txbKehoach1.Text = "QC / ";
            txbKehoach1.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach2.Text = "Cố định 1 / ";
            txbKehoach2.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach3.Text = "Sửa đổi";
            txbKehoach3.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void BTNew_Click(object sender, RoutedEventArgs e)
        {
            txbKehoach1.Text = "QC / ";
            txbKehoach1.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach2.Text = "Cố định 2 / ";
            txbKehoach2.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach3.Text = "Tạo mới";
            txbKehoach3.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void BTView_Click(object sender, RoutedEventArgs e)
        {

            txbKehoach1.Text = "QC / ";
            txbKehoach1.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach2.Text = "Cố định 2 / ";
            txbKehoach2.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach3.Text = "Tra cứu";
            txbKehoach3.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void BTEdit_Click(object sender, RoutedEventArgs e)
        {

            txbKehoach1.Text = "QC / ";
            txbKehoach1.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach2.Text = "Cố định 2 / ";
            txbKehoach2.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach3.Text = "Sửa đổi";
            txbKehoach3.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void BDNew_Click(object sender, RoutedEventArgs e)
        {

            txbKehoach1.Text = "QC / ";
            txbKehoach1.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach2.Text = "Cố định 3 / ";
            txbKehoach2.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach3.Text = "Tạo mới";
            txbKehoach3.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void BDView_Click(object sender, RoutedEventArgs e)
        {

            txbKehoach1.Text = "QC / ";
            txbKehoach1.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach2.Text = "Cố định 3 / ";
            txbKehoach2.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach3.Text = "Tra cứu";
            txbKehoach3.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void BDEdit_Click(object sender, RoutedEventArgs e)
        {

            txbKehoach1.Text = "QC / ";
            txbKehoach1.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach2.Text = "Cố định 3 / ";
            txbKehoach2.Foreground = new SolidColorBrush(Colors.Gray);

            txbKehoach3.Text = "Sửa đổi";
            txbKehoach3.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void txbTitle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            UCQC.Children.Clear();
            var userControls = new QCHomeUC();
            UCQC.Children.Add(userControls);
        }
    }
}
