namespace bestillingsformularForBiludlejningsfirmaH3.Models
{
    public class BookingModel
    {
        public int id { get; set; }
        public  booking_vehicle_id { get; set; }
        public DateTime booking_timestamp_start { get; set; }
        public DateTime booking_timestamp_end { get; set; }

    }
}
