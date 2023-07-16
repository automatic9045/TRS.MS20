using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRS.MS20.DisplayableStates
{
    internal class TrainingState : IDisplayableState
    {
        public static readonly TrainingState Empty = new TrainingState("");
        public static readonly TrainingState Training = new TrainingState("営業訓練");

        public string DisplayText { get; }

        private TrainingState(string displayText)
        {
            DisplayText = displayText;
        }
    }
}
