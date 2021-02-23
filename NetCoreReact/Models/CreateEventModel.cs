using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCoreReact.Core.Models;

namespace NetCoreReact.Models
{
    public class CreateEventModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
    }


}
