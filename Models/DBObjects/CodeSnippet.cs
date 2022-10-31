using System;
using System.Collections.Generic;

namespace clubmembership.Models.DBObjects
{
    public partial class CodeSnippet
    {
        public CodeSnippet()
        {
            InverseIdsnippetPreviousVersionNavigation = new HashSet<CodeSnippet>();
        }

        public Guid IdcodeSnippet { get; set; }
        public string Title { get; set; } = null!;
        public string ContentCode { get; set; } = null!;
        public Guid Idmember { get; set; }
        public int Revision { get; set; }
        public Guid? IdsnippetPreviousVersion { get; set; }
        public DateTime DateTimeAdded { get; set; }
        public bool IsPublished { get; set; }

        public virtual Member IdmemberNavigation { get; set; } = null!;
        public virtual CodeSnippet? IdsnippetPreviousVersionNavigation { get; set; }
        public virtual ICollection<CodeSnippet> InverseIdsnippetPreviousVersionNavigation { get; set; }
    }
}
