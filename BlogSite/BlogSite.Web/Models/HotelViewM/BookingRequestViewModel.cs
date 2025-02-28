using Blogsite.Infrastructure.Services;

namespace BlogSite.Web.Models.HotelViewM
{
    public class BookingRequestViewModel
    {
        public int Id { get; set; }
        public int NumberOfGuests { get; set; } // Number of Guests
        public DateTime CheckInDate { get; set; } // Check-In Date
        public DateTime CheckOutDate { get; set; } // Check-Out Date
        public bool AirportTransfer { get; set; }
        public bool ExtraBed { get; set; }
        public bool RoomOnHigherFloor { get; set; }
        public bool DecorationsInRoom { get; set; }
        public string? BedType { get; set; } // Radio button value
        public string? RoomPreference { get; set; } // Radio button value
        public string? NoteToProperty { get; set; } // Textarea
        private IHotelBookingServices _services;
        public BookingRequestViewModel(IHotelBookingServices hotelBooking)
        {
            _services = hotelBooking;
        }


    }
}
