namespace BlogSite.Web.Models.HotelViewM
{
    public class HotelSearchFilter
    {
        public string Location { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
    }
}
