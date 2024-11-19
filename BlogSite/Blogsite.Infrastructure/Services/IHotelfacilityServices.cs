using Blogsite.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public interface IHotelfacilityServices
    {
        void Addfacility(HotelFacilities hotelfacility);
        public IList<Hotel> GetAlHotesls();
        void EditHotelfacility(HotelFacilities hotel);
        HotelFacilities GetByid(int id);
        void DeletehotelFacility(int id);
        (IList<HotelFacilities> hotels, int total, int totalDisplay) GetHotelfacilityList(int pageindex, int pagesize, string searchText, string orderBy);

    }
}
