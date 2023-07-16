using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Reactive.Bindings;

using TRS.MS20.PluginHost;

namespace TRS.MS20.Presentation.Components
{
    internal class ToolBarModel : IToolBarModel
    {
        public ReactivePropertySlim<bool> IsTestMode { get; } = new ReactivePropertySlim<bool>();
        public ReactivePropertySlim<bool> IsCSMode { get; } = new ReactivePropertySlim<bool>();
        public ReactivePropertySlim<bool> IsSumMode { get; } = new ReactivePropertySlim<bool>();
        public ReactivePropertySlim<OperationType?> OperationType { get; } = new ReactivePropertySlim<OperationType?>(null);
        public ReactivePropertySlim<bool> IsRelayMode { get; } = new ReactivePropertySlim<bool>();

        public ReactivePropertySlim<ToolBarLockMode> LockMode { get; } = new ReactivePropertySlim<ToolBarLockMode>(ToolBarLockMode.Default);

        bool IToolBarModel.IsTestMode => IsTestMode.Value;
        bool IToolBarModel.IsCSMode => IsCSMode.Value;
        bool IToolBarModel.IsSumMode => IsSumMode.Value;
        OperationType? IToolBarModel.OperationType => OperationType.Value;
        bool IToolBarModel.IsRelayMode => IsRelayMode.Value;
        ToolBarLockMode IToolBarModel.LockMode
        {
            get => LockMode.Value;
            set => LockMode.Value = value;
        }

        public ToolBarModel()
        {
        }

        public void GoToMenu()
        {

        }

        public void Recover()
        {
            OperationType.Value = null;
            ServiceContext.Instance.LowerStatusBarModel.Progress++;
        }

        public void SwapState()
        {
            switch (LockMode.Value)
            {
                case ToolBarLockMode.Default:
                    LockMode.Value = ToolBarLockMode.Menu;
                    break;
                case ToolBarLockMode.Menu:
                    LockMode.Value = ToolBarLockMode.All;
                    break;
                case ToolBarLockMode.All:
                    LockMode.Value = ToolBarLockMode.Default;
                    break;
            }
        }

        public void SaveState()
        {

        }

        public void BeginNormalOneTime()
        {

        }

        public void FinishNormalOneTime()
        {

        }

        public void BreakOneTimeOperation()
        {

        }

        public void ResumeOneTimeOperation1()
        {

        }

        public void ResumeOneTimeOperation2()
        {

        }

        public void BeginPackageOneTime()
        {

        }

        public void FinishPackageOneTime()
        {

        }

        public void Respond()
        {

        }

        public void ClearRest()
        {
            MessageBox.Show("消去されました。");
        }
    }
}
