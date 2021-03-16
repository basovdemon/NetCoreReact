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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? AllDay { get; set; }
        public string Place { get; set; }

        public List<UserEventModel> Users { get; set; }
}
}
