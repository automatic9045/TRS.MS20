using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Reactive.Bindings;

using TRS.MS20.DisplayableStates;

namespace TRS.MS20.Presentation.Components
{
    internal class UpperStatusBarModel : IUpperStatusBarModel
    {
        public ReactivePropertySlim<TrainingState> TrainingState { get; } = new ReactivePropertySlim<TrainingState>(DisplayableStates.TrainingState.Empty);
        public ReactivePropertySlim<ModeState> ModeState { get; } = new ReactivePropertySlim<ModeState>(DisplayableStates.ModeState.Empty);
        public ReactivePropertySlim<Alert> Alert { get; } = new ReactivePropertySlim<Alert>(DisplayableStates.Alert.Empty);
        public ReactivePropertySlim<OneTimeState> OneTimeState { get; } = new ReactivePropertySlim<OneTimeState>(DisplayableStates.OneTimeState.Empty);

        public ReactivePropertySlim<bool> AreButtonsEnabled { get; } = new ReactivePropertySlim<bool>(true);
        public ReactivePropertySlim<bool> IsHolding { get; } = new ReactivePropertySlim<bool>(false);

        TrainingState IUpperStatusBarModel.TrainingState
        {
            get => TrainingState.Value;
            set => TrainingState.Value = value;
        }
        ModeState IUpperStatusBarModel.ModeState
        {
            get => ModeState.Value;
            set => ModeState.Value = value;
        }
        Alert IUpperStatusBarModel.Alert
        {
            get => Alert.Value;
            set => Alert.Value = value;
        }
        OneTimeState IUpperStatusBarModel.OneTimeState
        {
            get => OneTimeState.Value;
            set => OneTimeState.Value = value;
        }
        bool IUpperStatusBarModel.AreButtonsEnabled
        {
            get => AreButtonsEnabled.Value;
            set => AreButtonsEnabled.Value = value;
        }
        bool IUpperStatusBarModel.IsHolding => IsHolding.Value;

        public UpperStatusBarModel()
        {
        }

        public void Release()
        {

        }

        public void Send()
        {

        }
    }
}
