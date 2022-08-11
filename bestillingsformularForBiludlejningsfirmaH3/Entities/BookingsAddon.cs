using System;
using System.Collections.Generic;

namespace bestillingsformularForBiludlejningsfirmaH3.Entities
{
    public partial class BookingsAddon
    {
        public BookingsAddon()
        {
            BookingsAddonsRelations = new HashSet<BookingsAddonsRelation>();
        }

        public int BookingAddonId { get; set; }
        public string BookingAddon { get; set; } = null!;
        public double BookingAddonPrice { get; set; }

        public virtual ICollection<BookingsAddonsRelation> BookingsAddonsRelations { get; set; }
    }
}
