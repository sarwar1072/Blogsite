using Blogsite.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public interface IHotelServices
    {
        void AddHotel(Hotel hotel);
        void Deletehotel(int id);
        Hotel GetByid(int id);
        IList<Hotel> GetAlHotesls();
        Room GetRoomDetailsById(int id);

        IList<Hotel> SearchedHotelList(string Location, DateTime CheckInDate, DateTime CheckOutDate, int NumberOfGuests);
        IList<string> GetAllHoteslsWithoutLimit();
        Hotel SearchedRoomListWithHotel(int id, string Location, DateTime CheckInDate, DateTime CheckOutDate, int NumberOfGuests);

        void EditHotel(Hotel hotel);
        (IList<Hotel> hotels, int total, int totalDisplay) GetHotelList(int pageindex, int pagesize, string searchText, string orderBy);
    }
}
