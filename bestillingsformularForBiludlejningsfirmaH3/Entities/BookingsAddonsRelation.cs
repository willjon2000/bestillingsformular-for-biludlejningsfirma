using System;
using System.Collections.Generic;

namespace bestillingsformularForBiludlejningsfirmaH3.Entities
{
    public partial class BookingsAddonsRelation
    {
        public int BookingAddonRelationId { get; set; }
        public int BookingId { get; set; }
        public int BookingAddonId { get; set; }

        public virtual Booking Booking { get; set; } = null!;
        public virtual BookingsAddon BookingAddon { get; set; } = null!;
    }
}
