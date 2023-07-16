using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Reactive.Bindings;

namespace TRS.MS20.Presentation.Components
{
    internal class LowerStatusBarModel : ILowerStatusBarModel
    {
        public ReactivePropertySlim<Progress> Progress { get; } = new ReactivePropertySlim<Progress>(MS20.Progress.Default);

        Progress ILowerStatusBarModel.Progress
        {
            get => Progress.Value;
            set => Progress.Value = value;
        }

        public LowerStatusBarModel()
        {
        }
    }
}
