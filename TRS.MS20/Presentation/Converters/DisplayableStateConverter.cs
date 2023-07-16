using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

using TRS.MS20.DisplayableStates;

namespace TRS.MS20.Presentation.Converters
{
    internal class DisplayableStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => !(value is IDisplayableState state) ? DependencyProperty.UnsetValue : state.DisplayText;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
