using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetCoreReact.Data.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public bool? AllDay { get; set; }
        [Required]
        public string Place { get; set; }

        //[Required]
        public List<User> Users { get; set; } = new List<User>();
    }
}
