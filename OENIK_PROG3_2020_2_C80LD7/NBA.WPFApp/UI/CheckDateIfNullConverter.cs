// <copyright file="CheckDateIfNullConverter.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp.UI
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Data;

    /// <summary>
    /// Checks if date is null.
    /// </summary>
    public class CheckDateIfNullConverter : IValueConverter
    {
        /// <summary>
        /// Convert to.
        /// </summary>
        /// <param name="value">value.</param>
        /// <param name="targetType">target type.</param>
        /// <param name="parameter">parameter.</param>
        /// <param name="culture">culture info.</param>
        /// <returns>DateTime if not null, string if null.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var nullable = (DateTime?)value;

            if (nullable.HasValue && nullable.Value > DateTime.MinValue)
            {
                return nullable.Value.ToShortDateString();
            }

            return "date is null";
        }

        /// <summary>
        /// Converts back.
        /// </summary>
        /// <param name="value">value.</param>
        /// <param name="targetType">target type.</param>
        /// <param name="parameter">parameter.</param>
        /// <param name="culture">culture info.</param>
        /// <returns>Nothing.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
