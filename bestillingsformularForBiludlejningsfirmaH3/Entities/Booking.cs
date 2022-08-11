using System;
using System.Collections.Generic;

namespace bestillingsformularForBiludlejningsfirmaH3.Entities
{
    public partial class Booking
    {
        public Booking()
        {
            BookingsAddonsRelations = new HashSet<BookingsAddonsRelation>();
        }

        public int BookingId { get; set; }
        public int BookingVehicleId { get; set; }
        public int BookingContactId { get; set; }
        public DateTime BookingTimestampEnd { get; set; }
        public DateTime BookingTimestampStart { get; set; }

        public virtual BookingsContact BookingContact { get; set; } = null!;
        public virtual BookingsVehicle BookingVehicle { get; set; } = null!;
        public virtual ICollection<BookingsAddonsRelation> BookingsAddonsRelations { get; set; }
    }
}
