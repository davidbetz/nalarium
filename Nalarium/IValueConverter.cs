#region Copyright

//+ Jampad Technology, Inc. 2007-2013 Pro 3.0 - Core Module
//+ Copyright © Jampad Technology, Inc. 2007-2013

#endregion

using System;
using System.Globalization;

namespace Nalarium
{
    public interface IValueConverter
    {
        Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture);
        Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture);
    }
}