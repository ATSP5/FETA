using FETA.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace FETA.Converters
{
    public class HCActionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (((string)parameter == "C" && (HashCompareAction)value == HashCompareAction.Compare) || ((string)parameter == "H" && (HashCompareAction)value == HashCompareAction.Hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)parameter == "H")
            {
                return HashCompareAction.Hash;
            }
            else
            {
                return HashCompareAction.Compare;
            }
        }
    }
}
