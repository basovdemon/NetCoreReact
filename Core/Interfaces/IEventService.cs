using NetCoreReact.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCoreReact.Core.Intefaces
{
    public interface IEventService
    {
        Task<EventModel> CreateEventAsync(EventModel eventModel);
        Task<EventModel> UpdateEventAsync(EventModel eventModel);
        Task DeleteEventAsync(Guid eventId);
        Task<EventModel> GetEventAsync(Guid eventId);
        Task<List<EventModel>> GetEventsAsync();
    }
}
