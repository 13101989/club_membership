 using System.ComponentModel.DataAnnotations;

namespace clubmembership.Models
{
    public class AnnouncementModel
    {
        public Guid Idannouncemment { get; set; }

        [DisplayFormat(DataFormatString= "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime ValidFrom { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)] 
        public DateTime ValidTo { get; set; }

        [StringLength(250,ErrorMessage = "Maxim 250 characters allowed")]
        public string Title { get; set; } = null!;

        [StringLength(1000, ErrorMessage = "Maxim 1000 characters allowed")]
        public string Text { get; set; } = null!;

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public DateTime? EventDateTime { get; set; }

        [StringLength(1000, ErrorMessage = "Maxim 1000 characters allowed")]
        public string? Tags { get; set; }
    }
}
