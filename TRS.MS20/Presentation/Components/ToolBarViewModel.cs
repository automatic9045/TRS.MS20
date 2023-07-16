using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Reactive.Bindings;
using Reactive.Bindings.Disposables;
using Reactive.Bindings.Extensions;

using TRS.MS20.PluginHost;

namespace TRS.MS20.Presentation.Components
{
    internal class ToolBarViewModel : INotifyPropertyChanged, IDisposable
    {
        private readonly CompositeDisposable Disposables = new CompositeDisposable();

        public ToolBarModel Model => (ToolBarModel)ServiceContext.Instance.ToolBarModel;

        public ReactiveProperty<bool> IsTestButtonChecked { get; }
        public ReactiveProperty<bool> IsCSButtonChecked { get; }
        public ReactiveProperty<bool> IsSumButtonChecked { get; }
        public ReactiveProperty<OperationType?> OperationType { get; }
        public ReactiveProperty<bool> IsRelayButtonChecked { get; }

        public ReactiveProperty<ToolBarLockMode> LockMode { get; }

        public ReactiveProperty<Key> MenuKey { get; }
        public ReactiveProperty<Key> TestKey { get; }
        public ReactiveProperty<Key> RecoverKey { get; }
        public ReactiveProperty<Key> SwapKey { get; }
        public ReactiveProperty<Key> SaveKey { get; }
        public ReactiveProperty<Key> BeginOneTimeKey { get; }
        public ReactiveProperty<Key> FinishOneTimeKey { get; }
        public ReactiveProperty<Key> BreakKey { get; }
        public ReactiveProperty<Key> Resume1Key { get; }
        public ReactiveProperty<Key> Resume2Key { get; }
        public ReactiveProperty<Key> BeginPackageOneTimeKey { get; }
        public ReactiveProperty<Key> FinishPackageOneTimeKey { get; }
        public ReactiveProperty<Key> RespondKey { get; }
        public ReactiveProperty<Key> ClearRestKey { get; }
        public ReactiveProperty<Key> CSKey { get; }
        public ReactiveProperty<Key> SumKey { get; }
        public ReactiveProperty<Key> SellKey { get; }
        public ReactiveProperty<Key> ReserveKey { get; }
        public ReactiveProperty<Key> InquireKey { get; }
        public ReactiveProperty<Key> RelayKey { get; }

        public ReactiveCommand MenuButtonCommand { get; }
        public ReactiveCommand TestKeyCommand { get; }
        public ReactiveCommand RecoverButtonCommand { get; }
        public ReactiveCommand SwapButtonCommand { get; }
        public ReactiveCommand SaveButtonCommand { get; }
        public ReactiveCommand BeginOneTimeButtonCommand { get; }
        public ReactiveCommand FinishOneTimeButtonCommand { get; }
        public ReactiveCommand BreakButtonCommand { get; }
        public ReactiveCommand Resume1ButtonCommand { get; }
        public ReactiveCommand Resume2ButtonCommand { get; }
        public ReactiveCommand BeginPackageOneTimeButtonCommand { get; }
        public ReactiveCommand FinishPackageOneTimeButtonCommand { get; }
        public ReactiveCommand RespondButtonCommand { get; }
        public ReactiveCommand ClearRestButtonCommand { get; }
        public ReactiveCommand CSKeyCommand { get; }
        public ReactiveCommand SumKeyCommand { get; }
        public ReactiveCommand SellKeyCommand { get; }
        public ReactiveCommand ReserveKeyCommand { get; }
        public ReactiveCommand InquireKeyCommand { get; }
        public ReactiveCommand RelayKeyCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ToolBarViewModel()
        {
            IsTestButtonChecked = Model.IsTestMode.ToReactivePropertyAsSynchronized(x => x.Value).AddTo(Disposables);
            IsCSButtonChecked = Model.IsCSMode.ToReactivePropertyAsSynchronized(x => x.Value).AddTo(Disposables);
            IsSumButtonChecked = Model.IsSumMode.ToReactivePropertyAsSynchronized(x => x.Value).AddTo(Disposables);
            OperationType = Model.OperationType.ToReactivePropertyAsSynchronized(x => x.Value).AddTo(Disposables);
            IsRelayButtonChecked = Model.IsRelayMode.ToReactivePropertyAsSynchronized(x => x.Value).AddTo(Disposables);

            LockMode = Model.LockMode.ToReactivePropertyAsSynchronized(x => x.Value).AddTo(Disposables);
            LockMode.Subscribe(x =>
            {
                if (x != ToolBarLockMode.Default)
                {
                    IsTestButtonChecked.Value = false;
                    IsCSButtonChecked.Value = false;
                    IsSumButtonChecked.Value = false;
                    OperationType.Value = null;
                    IsRelayButtonChecked.Value = false;
                }
            });

            MenuKey = new ReactiveProperty<Key>(Key.Escape).AddTo(Disposables);
            TestKey = new ReactiveProperty<Key>(Key.F1).AddTo(Disposables);
            RecoverKey = new ReactiveProperty<Key>(Key.F2).AddTo(Disposables);
            SwapKey = new ReactiveProperty<Key>(Key.F3).AddTo(Disposables);
            SaveKey = new ReactiveProperty<Key>(Key.F4).AddTo(Disposables);
            BeginOneTimeKey = new ReactiveProperty<Key>(Key.F5).AddTo(Disposables);
            FinishOneTimeKey = new ReactiveProperty<Key>(Key.F6).AddTo(Disposables);
            BreakKey = new ReactiveProperty<Key>(Key.F7).AddTo(Disposables);
            Resume1Key = new ReactiveProperty<Key>(Key.F8).AddTo(Disposables);
            Resume2Key = new ReactiveProperty<Key>(Key.F9).AddTo(Disposables);
            BeginPackageOneTimeKey = new ReactiveProperty<Key>(Key.F10).AddTo(Disposables);
            FinishPackageOneTimeKey = new ReactiveProperty<Key>(Key.F11).AddTo(Disposables);
            RespondKey = new ReactiveProperty<Key>(Key.F12).AddTo(Disposables);
            ClearRestKey = new ReactiveProperty<Key>(Key.F13).AddTo(Disposables);
            CSKey = new ReactiveProperty<Key>(Key.F14).AddTo(Disposables);
            SumKey = new ReactiveProperty<Key>(Key.F15).AddTo(Disposables);
            SellKey = new ReactiveProperty<Key>(Key.Tab).AddTo(Disposables);
            ReserveKey = new ReactiveProperty<Key>(Key.Divide).AddTo(Disposables);
            InquireKey = new ReactiveProperty<Key>(Key.Multiply).AddTo(Disposables);
            RelayKey = new ReactiveProperty<Key>(Key.F16).AddTo(Disposables);

            MenuButtonCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => Model.GoToMenu());
            TestKeyCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => IsTestButtonChecked.Value = !IsTestButtonChecked.Value);
            RecoverButtonCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => Model.Recover());
            SwapButtonCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => Model.SwapState());
            SaveButtonCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => Model.SaveState());
            BeginOneTimeButtonCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => Model.BeginNormalOneTime());
            FinishOneTimeButtonCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => Model.FinishNormalOneTime());
            BreakButtonCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => Model.BreakOneTimeOperation());
            Resume1ButtonCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => Model.ResumeOneTimeOperation1());
            Resume2ButtonCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => Model.ResumeOneTimeOperation2());
            BeginPackageOneTimeButtonCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => Model.BeginPackageOneTime());
            FinishPackageOneTimeButtonCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => Model.FinishPackageOneTime());
            RespondButtonCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => Model.Respond());
            ClearRestButtonCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => Model.ClearRest());
            CSKeyCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => IsCSButtonChecked.Value = !IsCSButtonChecked.Value);
            SumKeyCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => IsSumButtonChecked.Value = !IsSumButtonChecked.Value);
            SellKeyCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => OperationType.Value = PluginHost.OperationType.Sell);
            ReserveKeyCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => OperationType.Value = PluginHost.OperationType.Reserve);
            InquireKeyCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => OperationType.Value = PluginHost.OperationType.Inquire);
            RelayKeyCommand = new ReactiveCommand().AddTo(Disposables).WithSubscribe(() => IsRelayButtonChecked.Value = !IsRelayButtonChecked.Value);
        }

        public void Dispose()
        {
            Disposables.Dispose();
        }
    }
}
