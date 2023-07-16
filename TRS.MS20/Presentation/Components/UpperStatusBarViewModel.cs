using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Reactive.Bindings;
using Reactive.Bindings.Disposables;
using Reactive.Bindings.Extensions;

using TRS.MS20.DisplayableStates;

namespace TRS.MS20.Presentation.Components
{
    internal class UpperStatusBarViewModel : INotifyPropertyChanged, IDisposable
    {
        private readonly CompositeDisposable Disposables = new CompositeDisposable();

        public UpperStatusBarModel Model => (UpperStatusBarModel)ServiceContext.Instance.UpperStatusBarModel;

        public ReadOnlyReactiveProperty<TrainingState> TrainingState { get; }
        public ReadOnlyReactiveProperty<ModeState> ModeState { get; }
        public ReadOnlyReactiveProperty<Alert> Alert { get; }
        public ReadOnlyReactiveProperty<OneTimeState> OneTimeState { get; }

        public ReadOnlyReactiveProperty<bool> AreButtonsEnabled { get; }
        public ReactiveProperty<bool> IsHoldButtonChecked { get; }

        public ReactiveProperty<Key> HoldKey { get; }
        public ReactiveProperty<Key> ReleaseKey { get; }
        public ReactiveProperty<Key> SendKey { get; }

        public ReactiveCommand HoldButtonCommand { get; }
        public ReactiveCommand HoldKeyCommand { get; }
        public ReactiveCommand ReleaseButtonCommand { get; }
        public ReactiveCommand SendButtonCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public UpperStatusBarViewModel()
        {
            TrainingState = Model.TrainingState.ToReadOnlyReactiveProperty().AddTo(Disposables);
            ModeState = Model.ModeState.ToReadOnlyReactiveProperty().AddTo(Disposables);
            Alert = Model.Alert.ToReadOnlyReactiveProperty().AddTo(Disposables);
            OneTimeState = Model.OneTimeState.ToReadOnlyReactiveProperty().AddTo(Disposables);

            AreButtonsEnabled = Model.AreButtonsEnabled.ToReadOnlyReactiveProperty().AddTo(Disposables);
            IsHoldButtonChecked = Model.IsHolding.ToReactivePropertyAsSynchronized(x => x.Value).AddTo(Disposables);

            HoldKey = new ReactiveProperty<Key>(Key.Delete).AddTo(Disposables);
            ReleaseKey = new ReactiveProperty<Key>(Key.Back).AddTo(Disposables);
            SendKey = new ReactiveProperty<Key>(Key.Enter).AddTo(Disposables);

            HoldButtonCommand = AreButtonsEnabled.ToReactiveCommand().AddTo(Disposables);
            HoldKeyCommand = AreButtonsEnabled.ToReactiveCommand().AddTo(Disposables).WithSubscribe(() =>
            {
                IsHoldButtonChecked.Value = !IsHoldButtonChecked.Value;
                HoldButtonCommand.Execute();
            });
            ReleaseButtonCommand = AreButtonsEnabled.ToReactiveCommand().AddTo(Disposables).WithSubscribe(() => Model.Release());
            SendButtonCommand = new[] { AreButtonsEnabled, }.CombineLatestValuesAreAllTrue().ToReactiveCommand().AddTo(Disposables).WithSubscribe(() => Model.Send());

            AreButtonsEnabled.Subscribe(x =>
            {
                if (!x) IsHoldButtonChecked.Value = false;
            });
        }

        public void Dispose()
        {
            Disposables.Dispose();
        }
    }
}
