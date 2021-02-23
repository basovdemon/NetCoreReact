using System;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreReact.Data.Intefaces
{
    public interface IEventRepository
    {
        Task<Entities.Event> FindAsync(Guid id);
        Task<Entities.Event> UpdateAsync(Entities.Event evnt);
        Task<Entities.Event> AddAsync(Entities.Event evnt);
        Task RemoveAsync(Guid id);
        IQueryable<Entities.Event> Get();
    }
}
