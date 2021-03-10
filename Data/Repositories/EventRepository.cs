using NetCoreReact.Data.Entities;
using NetCoreReact.Data.Intefaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreReact.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly EventsAppDbContext _eventContext;

        public EventRepository(EventsAppDbContext eventContext)
        {
            _eventContext = eventContext;
        }

        public async Task<Event> AddAsync(Event evnt)
        {
            evnt.Id = evnt.Id == Guid.Empty ? Guid.NewGuid() : evnt.Id;
            _eventContext.Add(evnt);
            await _eventContext.SaveChangesAsync();
            return evnt;
        }

        public async Task<Event> FindAsync(Guid id)
        {
            return await _eventContext.Events.FindAsync(id);
        }

        public IQueryable<Event> Get()
        {
            return _eventContext.Events.AsQueryable();
        }

        public async Task RemoveAsync(Guid id)
        {
            var evnt = await _eventContext.Events.FindAsync(id);
            if (evnt != null)
            {
                _eventContext.Events.Remove(evnt);
                await _eventContext.SaveChangesAsync();
            }
        }

        public async Task<Event> UpdateAsync(Event evnt)
        {
            var local = _eventContext.Events.Local.FirstOrDefault(e => e.Id == evnt.Id);
            if(local != null)
            {
                _eventContext.Entry(evnt).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
            _eventContext.Entry(evnt).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _eventContext.SaveChangesAsync();
            return evnt;
        }
    }
}
