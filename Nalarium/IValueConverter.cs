#region Copyright

//+ Copyright © David Betz 2007-2017

#endregion

using System;
using System.Globalization;

namespace Nalarium
{
    public interface IValueConverter
    {
        object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}