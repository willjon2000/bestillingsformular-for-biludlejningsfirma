using System;
using System.Collections.Generic;

namespace bestillingsformularForBiludlejningsfirmaH3.Entities
{
    public partial class BookingsVehicle
    {
        public BookingsVehicle()
        {
            Bookings = new HashSet<Booking>();
        }

        public int BookingVehicleId { get; set; }
        public string BookingVehicle { get; set; } = null!;
        public double BookingVehiclePrice { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
