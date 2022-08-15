using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bestillingsformularForBiludlejningsfirmaH3.Entities
{
    public partial class BookingsAddon
    {
        public BookingsAddon()
        {
            BookingsAddonsRelations = new HashSet<BookingsAddonsRelation>();
        }


        public int BookingAddonId { get; set; }
        [Required]
        [StringLength(32)]
        [DataType(DataType.Text)]
        public string BookingAddon { get; set; } = null!;
        [Required]
        [DataType(DataType.Currency)]
        public double BookingAddonPrice { get; set; }

        public virtual ICollection<BookingsAddonsRelation> BookingsAddonsRelations { get; set; }
    }
}
