using System.ComponentModel.DataAnnotations;

namespace clubmembership.Models
{
    public class MemberModel
    {
        public Guid IdMember { get; set; }

        [StringLength(250, ErrorMessage = "Maxim 250 characters allowed")]
        public string Name { get; set; } = null!;

        [StringLength(100, ErrorMessage = "Maxim 100 characters allowed")]
        public string Title { get; set; } = null!;

        [StringLength(250, ErrorMessage = "Maxim 250 characters allowed")]
        public string Position { get; set; } = null!;

        [StringLength(1000, ErrorMessage = "Maxim 1000 characters allowed")]
        public string? Description { get; set; }
        public string? Resume { get; set; }
    }
}
