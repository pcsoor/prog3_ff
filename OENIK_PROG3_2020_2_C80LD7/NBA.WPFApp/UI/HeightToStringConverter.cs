using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NBA.WPFApp.UI
{
    class HeightToStringConverter : IValueConverter
    {
        // VM => UI
        // (int) 205 => 2m 5cm (string)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int h = (int)value;
            return string.Format("{0}m {1}cm", h / 100, h % 100);
        }

        // UI => VM
        // (string) 1m 85cm => 185 (int)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string[] input = value.ToString().Split(' ');
            int m = int.Parse(input[0].Substring(0, input[0].Length - 1));
            int cm = int.Parse(input[1].Substring(0, input[1].Length - 2));
            return m * 100 + cm;
        }
    }
}
