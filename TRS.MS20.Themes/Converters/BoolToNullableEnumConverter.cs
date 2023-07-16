using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace TRS.MS20.Themes.Converters
{
    public class BoolToNullableEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return false;
            if (parameter is null) return false;
            if (!(parameter is string parameterText)) return DependencyProperty.UnsetValue;

            Type valueType = value.GetType();
            if (!Enum.IsDefined(valueType, value)) return DependencyProperty.UnsetValue;

            object parameterValue = Enum.Parse(valueType, parameterText);
            return (int)parameterValue == (int)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => parameter is string parameterText ? Enum.Parse(targetType.GenericTypeArguments[0], parameterText) : DependencyProperty.UnsetValue;
    }
}
