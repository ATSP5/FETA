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
    public class EDActionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (((string)parameter == "D" && (EDAction)value == EDAction.Decrypt) || ((string)parameter == "E" && (EDAction)value == EDAction.Encrypt))
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
            if((string)parameter=="E")
            {
                return EDAction.Encrypt;
            }
            else
            {
                return EDAction.Decrypt;
            }
        }
    }
}
