using System;
using System.Collections.Generic;

namespace clubmembership.Models.DBObjects
{
    public partial class MembershipType
    {
        public MembershipType()
        {
            Memberships = new HashSet<Membership>();
        }

        public Guid IdMembershipType { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int SubscriptionLengthInMonths { get; set; }

        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
