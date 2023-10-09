﻿using FETA.Model;
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
            if (((string)parameter == "D" && (EDAction)value == EDAction.Decrypt) 
                || ((string)parameter == "E" && (EDAction)value == EDAction.Encrypt) 
                || ((string)parameter == "SH" && (EDAction)value == EDAction.ShaFile) 
                || ((string)parameter == "MD" && (EDAction)value == EDAction.MDFile))
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
                return EDAction.Encrypt;
            
            else if((string)parameter=="D")           
                return EDAction.Decrypt;
           
            else if ((string)parameter=="SH")
                return EDAction.ShaFile;
            else
                return EDAction.MDFile;
        }
    }
}
