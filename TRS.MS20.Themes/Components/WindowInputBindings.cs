using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TRS.MS20.Themes.Components
{
    public class WindowInputBindings : FrameworkElement
    {
        private static readonly DependencyPropertyKey ItemsPropertyKey
            = DependencyProperty.RegisterReadOnly(nameof(Items), typeof(FreezableCollection<InputBinding>), typeof(WindowInputBindings), new PropertyMetadata());
        public static readonly DependencyProperty ItemsProperty = ItemsPropertyKey.DependencyProperty;

        static WindowInputBindings()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowInputBindings), new FrameworkPropertyMetadata(typeof(WindowInputBindings)));
        }

        private readonly List<InputBinding> RegisteredItems = new List<InputBinding>();

        public Window TargetWindow { get; } = Application.Current.MainWindow;

        public FreezableCollection<InputBinding> Items => (FreezableCollection<InputBinding>)GetValue(ItemsProperty);

        public WindowInputBindings()
        {
            SetValue(ItemsPropertyKey, new FreezableCollection<InputBinding>());
            Items.Changed += (sender, e) =>
            {
                foreach (InputBinding x in RegisteredItems)
                {
                    if (!Items.Contains(x))
                    {
                        TargetWindow?.InputBindings.Remove(x);
                        RegisteredItems.Remove(x);
                    }
                }

                InputBinding[] newItems = Items.Where(x => !RegisteredItems.Contains(x)).ToArray();
                TargetWindow?.InputBindings.AddRange(newItems);
                RegisteredItems.AddRange(newItems);
            };
        }
    }
}
