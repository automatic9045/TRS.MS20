using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Vanara.PInvoke;

namespace TRS.MS20.Launching
{
    internal class DisplaySettingManager
    {
        private readonly Dictionary<Size, DEVMODE> SupportedModes;
        public IEnumerable<Size> SupportedSizes => SupportedModes.Keys;

        private DisplaySettingManager(IEnumerable<DEVMODE> supportedModes)
        {
            SupportedModes = supportedModes
                .GroupBy(mode => new Size(mode.dmPelsWidth, mode.dmPelsHeight))
                .AsParallel()
                .ToDictionary(g => g.Key, g =>
                {
                    foreach (DEVMODE mode in g)
                    {
                        if (mode.dmDisplayFixedOutput == DMDFO.DMDFO_DEFAULT) return mode;
                    }

                    return g.First();
                });
        }

        public static DisplaySettingManager Create()
        {
            List<DEVMODE> deviceModes = new List<DEVMODE>();

            for (uint i = 0; true; i++)
            {
                DEVMODE deviceMode = DEVMODE.Default;
                if (User32.EnumDisplaySettings(null, i, ref deviceMode))
                {
                    deviceModes.Add(deviceMode);
                }
                else
                {
                    break;
                }
            }

            return new DisplaySettingManager(deviceModes);
        }

        public void ChangeSetting(Size changeTo)
        {
            int returnCode = User32.ChangeDisplaySettings(SupportedModes[changeTo], User32.ChangeDisplaySettingsFlags.CDS_FULLSCREEN);
        }
    }
}
