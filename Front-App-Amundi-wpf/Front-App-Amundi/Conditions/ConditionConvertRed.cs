using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Front_App_Amundi.Conditions
{
    public class ConditionConvertRed : IMultiValueConverter
    {
        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value[0] != null && MainWindow.GetTestConditionEffectue())
            {
                if ((Boolean)value[1] == false)
                    return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
