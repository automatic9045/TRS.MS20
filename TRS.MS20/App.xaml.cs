using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using TRS.MS20.Launching;
using TRS.MS20.Presentation;

namespace TRS.MS20
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private static readonly Size RecommendedSize = new Size(1024, 768);

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            DisplaySettingManager displaySettingManager = DisplaySettingManager.Create();
            if (displaySettingManager.SupportedSizes.Contains(RecommendedSize))
            {
                //displaySettingManager.ChangeSetting(RecommendedSize);
            }
            else
            {

            }

            DefaultStyleOverrider.Override();

            MainWindow mainWindow = new MainWindow();
            MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
}
