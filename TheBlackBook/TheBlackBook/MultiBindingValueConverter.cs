﻿using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace TheBlackBook
{
    public class MultiBindingValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.ToArray();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}