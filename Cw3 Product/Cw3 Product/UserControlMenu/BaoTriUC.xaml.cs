using Cw3_Product.UserControlBaoTri;
using Cw3_Product.UserControlKeHoach;
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
    /// Interaction logic for BaoTriUC.xaml
    /// </summary>
    public partial class BaoTriUC : UserControl
    {
        public BaoTriUC()
        {
            InitializeComponent();
            UCBaotri.Children.Clear();
            var userControls = new BaotriHomeUC();
            UCBaotri.Children.Add(userControls);
        }
    }
}
