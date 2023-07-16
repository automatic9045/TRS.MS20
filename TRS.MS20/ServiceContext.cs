using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TRS.MS20.Presentation.Components;

namespace TRS.MS20
{
    internal class ServiceContext
    {
        public static ServiceContext Instance { get; } = new ServiceContext();

        public IToolBarModel ToolBarModel { get; } = new ToolBarModel();
        public IUpperStatusBarModel UpperStatusBarModel { get; } = new UpperStatusBarModel();
        public ILowerStatusBarModel LowerStatusBarModel { get; } = new LowerStatusBarModel();

        public ServiceContext()
        {
        }
    }
}
