using Blogsite.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public interface IRoomServices
    {
        void AddRoom(Room room);
        void AddBookingData(HotelBooking hotelBooking);

        void EditRoom(Room room);
        public IList<Hotel> GetAll();
        Room GetById(int id);
        public void DeleteRoom(int id);
        (IList<Room> rooms, int total, int totalDisplay) GetRoomList(int pageindex, int pagesize, string searchText, string orderBy);
    }
}
