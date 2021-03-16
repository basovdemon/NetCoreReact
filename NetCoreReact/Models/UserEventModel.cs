using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreReact.Models
{
    public class UserEventModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        //public List<CreateEventModel> Events { get; set; }
    }
}
