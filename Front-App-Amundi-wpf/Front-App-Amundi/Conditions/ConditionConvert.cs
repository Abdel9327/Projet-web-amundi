﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Front_App_Amundi.Conditions
{
    public class ConditionConvert : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine(parameter);
            Console.WriteLine(value[0]);
            Console.WriteLine(value[1]);


            if (value[0] != null) return Visibility.Visible;
            return Visibility.Collapsed;
        }

    
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}