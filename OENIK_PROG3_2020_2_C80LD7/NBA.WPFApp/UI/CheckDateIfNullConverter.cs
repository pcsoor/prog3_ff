using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NBA.WPFApp.UI
{
    class CheckDateIfNullConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var nullable = (Nullable<DateTime>)value;

            if (nullable.HasValue && nullable.Value > DateTime.MinValue)
            {
                return nullable.Value.ToShortDateString();
            }

            return "asd";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
