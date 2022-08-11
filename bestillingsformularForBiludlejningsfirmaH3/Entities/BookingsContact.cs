using System;
using System.Collections.Generic;

namespace bestillingsformularForBiludlejningsfirmaH3.Entities
{
    public partial class BookingsContact
    {
        public BookingsContact()
        {
            Bookings = new HashSet<Booking>();
        }

        public int BookingContactId { get; set; }
        public string BookingContactFullname { get; set; } = null!;
        public string BookingContactEmail { get; set; } = null!;
        public int BookingContactPhone { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
