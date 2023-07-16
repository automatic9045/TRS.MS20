using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TRS.MS20.PluginHost;
using TRS.MS20.Presentation.Components;

namespace TRS.MS20
{
    internal interface IToolBarModel
    {
        bool IsTestMode { get; }
        bool IsCSMode { get; }
        bool IsSumMode { get; }
        OperationType? OperationType { get; }
        bool IsRelayMode { get; }

        ToolBarLockMode LockMode { get; set; }
    }
}
