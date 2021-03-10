using System;
using System.Collections.Generic;

namespace NetCoreReact.Data.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? AllDay { get; set; }
        public string Place { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}
