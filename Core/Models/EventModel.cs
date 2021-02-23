using System;

namespace NetCoreReact.Core.Models
{
    public class EventModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
    }
}
