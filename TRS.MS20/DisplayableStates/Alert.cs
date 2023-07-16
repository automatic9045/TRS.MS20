using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRS.MS20.DisplayableStates
{
    internal class Alert : IDisplayableState
    {
        public static readonly Alert Empty = new Alert("");
        public static readonly Alert SoonReleaseNewTickets = new Alert("１ヶ月発売間近");
        public static readonly Alert ReleasedNewTickets = new Alert("１ヶ月発売中");

        public string DisplayText { get; }

        private Alert(string displayText)
        {
            DisplayText = displayText;
        }
    }
}
