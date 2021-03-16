using System;
using System.Collections.Generic;

namespace NetCoreReact.Core.Models
{
    public class EventModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? AllDay { get; set; }
        public string Place { get; set; }

        public List<UserModel> Users { get; set; }
    }
}
