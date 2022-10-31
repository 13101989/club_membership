using System.ComponentModel.DataAnnotations;

namespace clubmembership.Models
{
    public class MembershipModel
    {
        public Guid Idmembership { get; set; }
        public Guid Idmember { get; set; }
        public Guid IdmembershipType { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public int Level { get; set; }
    }
}
