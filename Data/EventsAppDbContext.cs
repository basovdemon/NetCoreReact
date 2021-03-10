using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using NetCoreReact.Data.Entities;

namespace NetCoreReact.Data
{
    public class EventsAppDbContext: DbContext
    {
        public EventsAppDbContext(DbContextOptions<EventsAppDbContext> options) : base (options)
        { 
        
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
