using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NetCoreReact.Data
{
    public class EventContextFactory : IDesignTimeDbContextFactory<EventsAppDbContext>
    {
        public EventsAppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EventsAppDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=TrialDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");  // insert connection string

            return new EventsAppDbContext(optionsBuilder.Options);
        }
    }
}
