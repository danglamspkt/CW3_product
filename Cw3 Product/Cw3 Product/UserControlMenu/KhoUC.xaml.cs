using Cw3_Product.UserControlBaoTri;
using Cw3_Product.UserControlKho;
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
    /// Interaction logic for KhoUC.xaml
    /// </summary>
    public partial class KhoUC : UserControl
    {
        public KhoUC()
        {
            InitializeComponent();
            UCKho.Children.Clear();
            var userControls = new KhoHomeUC();
            UCKho.Children.Add(userControls);
        }

       
    }
}
