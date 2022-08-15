using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bestillingsformularForBiludlejningsfirmaH3.Entities
{
    public partial class BookingsContact
    {
        public BookingsContact()
        {
            Bookings = new HashSet<Booking>();
        }

        public int BookingContactId { get; set; }
        [Required]
        [StringLength(255)]
        [DataType(DataType.Text)]
        public string BookingContactFullname { get; set; } = null!;
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(255)]
        public string BookingContactEmail { get; set; } = null!;
        [Required]
        [RegularExpression(@"^\d{8}$")]
        public int BookingContactPhone { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
