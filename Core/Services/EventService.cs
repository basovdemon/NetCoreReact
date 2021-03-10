using Microsoft.EntityFrameworkCore;
using NetCoreReact.Core.Intefaces;
using NetCoreReact.Core.Models;
using NetCoreReact.Data.Entities;
using NetCoreReact.Data.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreReact.Core.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public async Task<EventModel> CreateEventAsync(EventModel eventModel)
        {
            if(eventModel is null)
            {
                throw new ArgumentNullException(nameof(eventModel));
            }

            var eventEntity = new Data.Entities.Event
            {
                Title = eventModel.Title,
                Description = eventModel.Description,
                StartDate = eventModel.StartDate,
                EndDate = eventModel.EndDate,
                AllDay = eventModel.AllDay,
                Place = eventModel.Place
            };

            eventEntity = await _eventRepository.AddAsync(eventEntity);

            return new EventModel
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title,
                Description = eventEntity.Description,
                StartDate = eventModel.StartDate,
                EndDate = eventModel.EndDate,
                AllDay = eventModel.AllDay,
                Place = eventModel.Place
            };
        }

        public async Task DeleteEventAsync(Guid eventId)
        {
            await _eventRepository.RemoveAsync(eventId);
        }

        public async Task<EventModel> GetEventAsync(Guid eventId)
        {
            var eventEntity = await _eventRepository.FindAsync(eventId);

            if (eventEntity is null) return null;

            return new EventModel
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title,
                Description = eventEntity.Description,
                StartDate = eventEntity.StartDate,
                EndDate = eventEntity.EndDate,
                AllDay = eventEntity.AllDay,
                Place = eventEntity.Place
            };
        }

        public async Task<List<EventModel>> GetEventsAsync()
        {
            IQueryable<Data.Entities.Event> query = _eventRepository.Get();
            return await query.Select(eventEntity => new EventModel
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title,
                Description = eventEntity.Description,
                StartDate = eventEntity.StartDate,
                EndDate = eventEntity.EndDate,
                AllDay = eventEntity.AllDay,
                Place = eventEntity.Place
            }).ToListAsync();
        }

        public async Task<EventModel> UpdateEventAsync(EventModel eventModel)
        {
            var eventEntity = new Data.Entities.Event
            {
                Id = eventModel.Id,
                Title = eventModel.Title,
                Description = eventModel.Description,
                StartDate = eventModel.StartDate,
                EndDate = eventModel.EndDate,
                AllDay = eventModel.AllDay,
                Place = eventModel.Place
            };

            eventEntity = await _eventRepository.UpdateAsync(eventEntity);

            return new EventModel
            {
                Id = eventEntity.Id,
                Title = eventEntity.Title,
                Description = eventEntity.Description,
                StartDate = eventEntity.StartDate,
                EndDate = eventEntity.EndDate,
                AllDay = eventEntity.AllDay,
                Place = eventEntity.Place
            };
        }
    }
}
