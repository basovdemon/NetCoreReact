using System;
using System.Collections.Generic;

namespace NetCoreReact.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public Guid EventsListId { get; set; }

        public List<Event> Events { get; set; } = new List<Event>();
    }
}
