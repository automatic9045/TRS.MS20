using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRS.MS20.PluginHost
{
    /// <summary>
    /// 操作種別を指定します。
    /// </summary>
    public enum OperationType
    {
        /// <summary>
        /// 発売操作を行うことを指定します。
        /// </summary>
        Sell,

        /// <summary>
        /// 予約操作を行うことを指定します。
        /// </summary>
        Reserve,

        /// <summary>
        /// 照会操作を行うことを指定します。
        /// </summary>
        Inquire,
    }
}
