using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRS.MS20.DisplayableStates
{
    internal class OneTimeState : IDisplayableState
    {
        public static readonly OneTimeState Empty = new OneTimeState("");
        public static readonly OneTimeState WaitingResumeOneTime = new OneTimeState("一件再開待");
        public static readonly OneTimeState BreakingOneTime = new OneTimeState("一件中断中");
        public static readonly OneTimeState WaitingBreakOneTime = new OneTimeState("一件中断待");
        public static readonly OneTimeState OneTime = new OneTimeState("一件操作中");
        public static readonly OneTimeState ReissuingSeatOnlyTicket = new OneTimeState("発行替・指のみ中");
        public static readonly OneTimeState BreakingOneTimeAndReissuingSeatOnlyTicket = new OneTimeState("断・発替指ﾉﾐ中");
        public static readonly OneTimeState WaitingResumeOneTimeAndReissuingSeatOnlyTicket = new OneTimeState("開・発替指ﾉﾐ中");
        public static readonly OneTimeState ReissuingSeatOnlyTestTicket = new OneTimeState("営試発替指ﾉﾐ中");
        public static readonly OneTimeState BreakingOneTimeAndReissuingSeatOnlyTestTicket = new OneTimeState("断試発替指ﾉﾐ中");
        public static readonly OneTimeState WaitingResumeOneTimeAndReissuingSeatOnlyTestTicket = new OneTimeState("開試発替指ﾉﾐ中");
        public static readonly OneTimeState ChangingTicket = new OneTimeState("挿入乗変中");

        public string DisplayText { get; }

        private OneTimeState(string displayText)
        {
            DisplayText = displayText;
        }
    }
}
