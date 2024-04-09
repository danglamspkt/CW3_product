using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
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
    /// Interaction logic for HomeUC.xaml
    /// </summary>
    public partial class HomeUC : UserControl
    {
        public HomeUC()
        {
            InitializeComponent();
        }

        private void btnWeb_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://www.csps.vn/";
            Process.Start("explorer", url);
        }

        private void btnFb_Click(object sender, RoutedEventArgs e)
        {
            string url = "https://www.facebook.com/www.csps.vn/";
            Process.Start("explorer", url);
        }

        private void btnMail_Click(object sender, RoutedEventArgs e)
        {
            
            string url = "mailto://so_v1@csps.vn";
            if ( RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }

        }
    }
}
