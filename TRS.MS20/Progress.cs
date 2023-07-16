using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRS.MS20
{
    internal enum Progress
    {
        Default,
        ReadyToSend,
        Sent,
        AnswerRecieved,
        Issuing2ndTicket,
        Completed,
        AnswerRecieveTimeout,
        DeviceError,
    }
}
