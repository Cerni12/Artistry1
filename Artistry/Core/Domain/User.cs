using System;
using System.Collections.Generic;

namespace Artistry.Models
{
    public partial class User
    {
        public User()
        {
            Events = new HashSet<Event>();
            UserEvents = new HashSet<UserEvent>();
        }

        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Mail { get; set; }
        public string? Password { get; set; }
        public int? MembershipId { get; set; }

        public virtual Membership? Membership { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<UserEvent> UserEvents { get; set; }
    }
}
