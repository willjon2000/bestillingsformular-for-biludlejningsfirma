using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bestillingsformularForBiludlejningsfirmaH3.Entities
{
    public partial class BookingsVehicle
    {
        public BookingsVehicle()
        {
            Bookings = new HashSet<Booking>();
        }

        public int BookingVehicleId { get; set; }
        [Required]
        [StringLength(32)]
        [DataType(DataType.Text)]
        public string BookingVehicle { get; set; } = null!;
        [Required]
        [DataType(DataType.Currency)]
        public double BookingVehiclePrice { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
