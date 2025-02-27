using Blogsite.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public interface IuserFormServices
    {
        void AddUserForm(UserForm userForm);
        List<UserForm> ListOfVBookedVisa(Guid UserId);
         List<HotelBooking> ListOfVBookedHotel(Guid UserId);

    }
}
