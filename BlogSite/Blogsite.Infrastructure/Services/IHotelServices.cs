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
        void EditHotel(Hotel hotel);
        (IList<Hotel> hotels, int total, int totalDisplay) GetHotelList(int pageindex, int pagesize, string searchText, string orderBy);
    }
}
