using System;
using System.Collections.Generic;

namespace clubmembership.Models.DBObjects
{
    public partial class Announcement
    {
        public Guid Idannouncemment { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public DateTime? EventDateTime { get; set; }
        public string? Tags { get; set; }
    }
}
