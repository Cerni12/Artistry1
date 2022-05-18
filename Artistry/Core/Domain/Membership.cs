using System;
using System.Collections.Generic;

namespace Artistry.Models
{
    public partial class Membership
    {
        public Membership()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? Type { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
