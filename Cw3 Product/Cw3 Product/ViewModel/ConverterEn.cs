using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Cw3_Product.ViewModel
{
    public class ConverterEn : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null && values[3] != null && values[4] != null && values[5] != null && values.Length == 6)
            {
                StackPanel name = values[0] as StackPanel;
                StackPanel age = values[1] as StackPanel;
                StackPanel stack3 = values[2] as StackPanel;
                StackPanel stack4 = values[3] as StackPanel;
                StackPanel stack5 = values[4] as StackPanel;
                StackPanel stack6 = values[5] as StackPanel;

                return new StackpanelEn { Stack1 = name, Stack2 = age, Stack3 = stack3, Stack4 = stack4, Stack5 = stack5, Stack6 = stack6 };
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
