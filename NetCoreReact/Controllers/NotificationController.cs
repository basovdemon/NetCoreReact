using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using NetCoreReact.Hubs;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreReact.Controllers
{
    [Route("notification")]
    [ApiController]
    public class NotificationController : Controller
    {
        protected readonly IHubContext<NotificationHub> _notificationHub;
        public NotificationController([NotNull] IHubContext<NotificationHub> notificationHub)
        {
            _notificationHub = notificationHub;
        }

        [HttpPost]
        public async Task<IActionResult> Create(NotificationPost notificationPost)
        {
            await _notificationHub.Clients.All.SendAsync("sendToReact", "You was invited to event: " + notificationPost.Title, 
                " start: " + notificationPost.StartDate, " end: " + notificationPost.EndDate);

            return Ok();
        }
    }

    public class NotificationPost
    {
        //public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? AllDay { get; set; }
        public string Place { get; set; }
        public List<string> Users { get; set; }
    }
}
