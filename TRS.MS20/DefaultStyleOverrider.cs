using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace TRS.MS20
{
    internal static class DefaultStyleOverrider
    {
        public static void Override()
        {
            OverrideStyleOf(typeof(Window), new Setter[]
            {
                //new Setter(Control.FocusableProperty, false),
                new Setter(Control.FontFamilyProperty, new FontFamily("MS Gothic")),
                new Setter(Control.FontSizeProperty, 16d),
            });
        }

        private static void OverrideStyleOf(Type targetType, params Setter[] setters)
        {
            Style style = new Style(targetType);

            foreach (Setter setter in setters)
            {
                style.Setters.Add(setter);
            }

            FrameworkElement.StyleProperty.OverrideMetadata(targetType, new FrameworkPropertyMetadata(style));
        }
    }
}
