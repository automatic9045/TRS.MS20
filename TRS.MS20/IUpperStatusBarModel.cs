using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TRS.MS20.DisplayableStates;

namespace TRS.MS20
{
    internal interface IUpperStatusBarModel
    {
        TrainingState TrainingState { get; set; }
        ModeState ModeState { get; set; }
        Alert Alert { get; set; }
        OneTimeState OneTimeState { get; set; }

        bool AreButtonsEnabled { get; set; }
        bool IsHolding { get; }
    }
}
