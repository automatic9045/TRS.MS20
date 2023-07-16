using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using Reactive.Bindings;
using Reactive.Bindings.Disposables;
using Reactive.Bindings.Extensions;
using Reactive.Bindings.Helpers;

namespace TRS.MS20.Presentation.Components
{
    internal class LowerStatusBarViewModel : INotifyPropertyChanged, IDisposable
    {
        private readonly CompositeDisposable Disposables = new CompositeDisposable();

        public LowerStatusBarModel Model => (LowerStatusBarModel)ServiceContext.Instance.LowerStatusBarModel;

        public ReadOnlyReactiveProperty<ProgressLampState> ProgressLamp1State { get; }
        public ReadOnlyReactiveProperty<ProgressLampState> ProgressLamp2State { get; }
        public ReadOnlyReactiveProperty<ProgressLampState> ProgressLamp3State { get; }
        public ReadOnlyReactiveProperty<ProgressLampState> ProgressLamp4State { get; }

        public ReadOnlyReactiveProperty<string> ConnectionState { get; }
        public ReadOnlyReactiveProperty<string> DownloadState { get; }
        public ReadOnlyReactiveProperty<string> TicketPrinterState { get; }
        public ReadOnlyReactiveProperty<string> JournalPrinterState { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public LowerStatusBarViewModel()
        {
            ProgressLamp1State = Model.Progress.Select(x =>
            {
                switch (x)
                {
                    case Progress.Default:
                        return ProgressLampState.Default;

                    case Progress.ReadyToSend:
                    case Progress.Sent:
                    case Progress.AnswerRecieved:
                    case Progress.Issuing2ndTicket:
                    case Progress.Completed:
                    case Progress.AnswerRecieveTimeout:
                    case Progress.DeviceError:
                        return ProgressLampState.Completed;

                    default:
                        throw new NotImplementedException();
                }
            }).ToReadOnlyReactiveProperty().AddTo(Disposables);

            ProgressLamp2State = Model.Progress.Select(x =>
            {
                switch (x)
                {
                    case Progress.Default:
                    case Progress.ReadyToSend:
                        return ProgressLampState.Default;

                    case Progress.Sent:
                        return ProgressLampState.Working;

                    case Progress.AnswerRecieved:
                    case Progress.Issuing2ndTicket:
                    case Progress.Completed:
                    case Progress.DeviceError:
                        return ProgressLampState.Completed;

                    case Progress.AnswerRecieveTimeout:
                        return ProgressLampState.Error;

                    default:
                        throw new NotImplementedException();
                }
            }).ToReadOnlyReactiveProperty().AddTo(Disposables);

            ProgressLamp3State = Model.Progress.Select(x =>
            {
                switch (x)
                {
                    case Progress.Default:
                    case Progress.ReadyToSend:
                    case Progress.Sent:
                    case Progress.AnswerRecieveTimeout:
                        return ProgressLampState.Default;

                    case Progress.AnswerRecieved:
                    case Progress.Issuing2ndTicket:
                        return ProgressLampState.Working;

                    case Progress.Completed:
                        return ProgressLampState.Completed;

                    case Progress.DeviceError:
                        return ProgressLampState.Error;

                    default:
                        throw new NotImplementedException();
                }
            }).ToReadOnlyReactiveProperty().AddTo(Disposables);

            ProgressLamp4State = Model.Progress.Select(x =>
            {
                switch (x)
                {
                    case Progress.Default:
                    case Progress.ReadyToSend:
                    case Progress.Sent:
                    case Progress.AnswerRecieved:
                    case Progress.AnswerRecieveTimeout:
                        return ProgressLampState.Default;

                    case Progress.Issuing2ndTicket:
                        return ProgressLampState.Working;

                    case Progress.Completed:
                        return ProgressLampState.Completed;

                    case Progress.DeviceError:
                        return ProgressLampState.Error;

                    default:
                        throw new NotImplementedException();
                }
            }).ToReadOnlyReactiveProperty().AddTo(Disposables);
        }

        public void Dispose()
        {
            Disposables.Dispose();
        }
    }
}
