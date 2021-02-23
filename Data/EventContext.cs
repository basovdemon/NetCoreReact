using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace NetCoreReact.Data
{
    public class EventContext: DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base (options)
        { 
        
        }

        public DbSet<Entities.Event> Events { get; set; }
    }
}
