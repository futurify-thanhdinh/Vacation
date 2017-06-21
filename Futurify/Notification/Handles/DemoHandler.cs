using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.common.core.Messaging;
using Microsoft.AspNetCore.Hosting;
using RawRabbit;
using RawRabbit.Context;
using Vacation.common.Events;

namespace Notification.Handles
{
    public class DemoHandler : IMessageHandle<DemoRabbit>
    {
       
        
        public async Task HandleAsync(DemoRabbit e, IMessageContext context)
        {
            string name = e.message;
        }
    }
}
