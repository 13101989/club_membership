using System;
using System.Collections.Generic;

namespace clubmembership.Models.DBObjects
{
    public partial class Member
    {
        public Member()
        {
            CodeSnippets = new HashSet<CodeSnippet>();
            Memberships = new HashSet<Membership>();
        }

        public Guid IdMember { get; set; }
        public string Name { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string? Description { get; set; }
        public string? Resume { get; set; }

        public virtual ICollection<CodeSnippet> CodeSnippets { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
