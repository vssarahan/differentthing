using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Abc.Core.Hubs
{
    [Authorize]
    public class AuthChatHub: Hub
    {
        public async override Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Info",
                Context.User.FindFirst(ClaimTypes.NameIdentifier)
                .Value, "enter");
            await base.OnConnectedAsync();
        }

        public async override Task OnDisconnectedAsync(Exception ex)
        {
            await Clients.All.SendAsync("Info",
                Context.User.FindFirst(ClaimTypes.NameIdentifier)
                .Value, "exit");
            await base.OnDisconnectedAsync(ex);
        }
    }
}
