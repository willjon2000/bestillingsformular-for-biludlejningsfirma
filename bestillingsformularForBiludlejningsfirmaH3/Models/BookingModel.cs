namespace bestillingsformularForBiludlejningsfirmaH3.Models
{
    public class BookingModel
    {
        public int id { get; set; }
        public List<BookingVehicles> booking_vehicle { get; set; }
        public DateTime booking_timestamp_start { get; set; }
        public DateTime booking_timestamp_end { get; set; }

    }
}
