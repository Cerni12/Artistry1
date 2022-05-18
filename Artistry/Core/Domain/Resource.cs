using System;
using System.Collections.Generic;

namespace Artistry.Models
{
    public partial class Resource
    {
        public Resource()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public int? Capacity { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
