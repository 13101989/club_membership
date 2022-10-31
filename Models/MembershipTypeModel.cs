using System.ComponentModel.DataAnnotations;

namespace clubmembership.Models
{
    public class MembershipTypeModel
    {
        public Guid IdMembershipType { get; set; }

        [StringLength(100, ErrorMessage = "Maxim 100 characters allowed")]
        public string Name { get; set; } = null!;

        [StringLength(250, ErrorMessage = "Maxim 250 characters allowed")]
        public string Description { get; set; } = null!;
        public int SubscriptionLengthInMonths { get; set; }
    }
}
