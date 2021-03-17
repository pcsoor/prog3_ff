// <copyright file="StatusToBrushConverter.cs" company="C80LD7">
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
    using System.Windows.Media;
    using NBA.WPFApp.Data;

    /// <summary>
    /// Status to brush converter.
    /// </summary>
    public class StatusToBrushConverter : IValueConverter
    {
        /// <inheritdoc/>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PositionTypeUI pos = (PositionTypeUI)value;
            switch (pos)
            {
                default:
                case PositionTypeUI.PointGuard: return Brushes.White;
                case PositionTypeUI.ShootingGuard: return Brushes.WhiteSmoke;
                case PositionTypeUI.SmallForward: return Brushes.Gainsboro;
                case PositionTypeUI.PowerForward: return Brushes.Silver;
                case PositionTypeUI.Center: return Brushes.DarkGray;
            }
        }

        /// <inheritdoc/>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
