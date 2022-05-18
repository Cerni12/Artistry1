using System;
using System.Collections.Generic;

namespace Artistry.Models
{
    public partial class Event
    {
        public Event()
        {
            UserEvents = new HashSet<UserEvent>();
        }

        public int Id { get; set; }
        public int? ResourceId { get; set; }
        public int? UserId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Resource? Resource { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<UserEvent> UserEvents { get; set; }
    }
}
