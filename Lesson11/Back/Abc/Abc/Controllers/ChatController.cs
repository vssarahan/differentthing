using Abc.Core.Hubs;
using Abc.Core.Hubs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Abc.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ChatController: Controller
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IHubContext<AuthChatHub> _authHubContext;

        public ChatController(IHubContext<ChatHub> hc,
            IHubContext<AuthChatHub> ahc)
        {
            _hubContext = hc;
            _authHubContext = ahc;
        }

        [Authorize]
        public async Task<ActionResult<bool>> SendAuth(
            [FromBody] Message message)
        {
            try
            {
                var email = HttpContext.User
                    .FindFirst(ClaimTypes.NameIdentifier).Value;
                await _authHubContext.Clients.All.SendAsync(
                    "Send", email, message.Text);
                return true;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        public async Task<ActionResult<bool>> Send(
            [FromBody] Message message)
        {
            try
            {
                await _hubContext.Clients.All.SendAsync(
                    "Send", message.Name, message.Text);
                return true;
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
