// <copyright file="HeightToStringConverter.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WPFApp.UI
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Height to string converter.
    /// </summary>
    public class HeightToStringConverter : IValueConverter
    {
        /// <summary>
        /// Converts standart int to height format like: Xm Ycm.
        /// </summary>
        /// <param name="value">value to convert.</param>
        /// <param name="targetType">target type.</param>
        /// <param name="parameter">parameter.</param>
        /// <param name="culture">culture.</param>
        /// <returns>some obj.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int h = (int)value;
            return $"{h / 100}m {h % 100}cm";
        }

        /// <summary>
        /// converts back the string format back to int.
        /// </summary>
        /// <param name="value">value to convert.</param>
        /// <param name="targetType">targettype.</param>
        /// <param name="parameter">param.</param>
        /// <param name="culture">cultureinfo.</param>
        /// <returns>some obj.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string[] input = value?.ToString().Split(' ');
            int m = int.Parse(input[0].Substring(0, input[0].Length - 1), CultureInfo.CurrentCulture);
            int cm = int.Parse(input[1].Substring(0, input[1].Length - 2), CultureInfo.CurrentCulture);
            return (m * 100) + cm;
        }
    }
}
