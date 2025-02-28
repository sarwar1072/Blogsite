using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;

namespace BlogSite.Web.Models.BookingModelFolder
{
    public class HotelBookingModel
    {
        private IHotelBookingServices _services;
        public int Id { get; set; }
       
        public List<HotelBooking>? HotelBooking { get; set; }=new List<HotelBooking>();
        public Guid UserId { get; set; }
        public HotelBookingModel(IHotelBookingServices hotelBooking)
        {
            _services = hotelBooking;    
        }
        public List<HotelBooking> GetHotelBookingList(Guid Userid)
        {
            var data=_services.ListOfVBookedHotel(Userid);
            if(data != null)
            {
                HotelBooking=new List<HotelBooking>();
                foreach (var item in data)
                {
                    HotelBooking.Add(new HotelBooking
                    {
                        NumberOfGuests = item.NumberOfGuests,
                        CheckInDate = item.CheckInDate,
                        CheckOutDate = item.CheckOutDate,
                        Room=new Room
                        {
                            Price=item.Room.Price,
                            RoomType=item.Room.RoomType,    
                            Hotel=new Hotel
                            {
                                Name=item.Room.Hotel.Name,
                                HotelUrl=item.Room.Hotel.HotelUrl,
                                Location=item.Room.Hotel.Location,
                            }
                        }
                    });
                }
            }
            return HotelBooking;
        }
        
    }
}
