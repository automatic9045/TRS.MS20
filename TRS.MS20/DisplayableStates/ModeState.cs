using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TRS.MS20.PluginHost;

namespace TRS.MS20.DisplayableStates
{
    internal class ModeState : IDisplayableState
    {
        public static readonly ModeState Empty = new ModeState("");
        public static readonly ModeState ReadBaseTicket = new ModeState("読取完了");
        public static readonly ModeState HddDown = new ModeState("ＨＤ片系運転");
        public static readonly ModeState CSReady = new ModeState("ＣＳ読取待");
        public static ModeState CSPinTyping(int digitCount) => 0 <= digitCount && digitCount <= 4
            ? new ModeState($"暗証 {digitCount.ToString().ToWide()}")
            : throw new ArgumentOutOfRangeException(nameof(digitCount));

        public string DisplayText { get; }

        private ModeState(string displayText)
        {
            DisplayText = displayText;
        }
    }
}
