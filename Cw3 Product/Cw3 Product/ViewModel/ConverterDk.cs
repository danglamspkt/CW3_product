using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Cw3_Product.ViewModel
{
    public class ConverterDk : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] != null && values[1] != null && values[2] != null && values.Length == 3)
            {
                StackPanel name = values[0] as StackPanel;
                StackPanel age = values[1] as StackPanel;
                StackPanel stack3 = values[2] as StackPanel;

                return new StackPanelDk { Stack1 = name, Stack2 = age, Stack3 = stack3 };
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
