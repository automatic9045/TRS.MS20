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

namespace TRS.MS20.Presentation.Components
{
    /// <summary>
    /// ProgressBox.xaml の相互作用ロジック
    /// </summary>
    public partial class ProgressLamp : UserControl
    {
        public static readonly DependencyProperty StateProperty =
             DependencyProperty.Register(nameof(State), typeof(ProgressLampState), typeof(ProgressLamp), new PropertyMetadata(ProgressLampState.Default));

        public ProgressLampState State
        {
            get => (ProgressLampState)GetValue(StateProperty);
            set => SetValue(StateProperty, value);
        }

        public ProgressLamp()
        {
            InitializeComponent();
        }
    }
}
