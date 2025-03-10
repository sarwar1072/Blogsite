using Blogsite.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public interface ITravelServices
    {
        void AddTraveller(Traveller traveller);
        Traveller GetByid(int id);
        IList<Traveller> GetByUserId(Guid id);
        int TravellerCount(Guid id);
        void DeleteTraveller(int id);
        void EditTraveller(Traveller traveller);

    }
}
