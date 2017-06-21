using System;
using System.Collections.Generic;
using System.Text;
using App.common.core.Messaging;

namespace Vacation.common.Events
{
    public class DemoRabbit : IMessage
    {
        public string message { get; set; }
    }
}
