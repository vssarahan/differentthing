using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Core.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("Send", message);
        }
    }
}
