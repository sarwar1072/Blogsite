using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.UOWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public class HotelBookingServices: IHotelBookingServices
    {
        private IProjectUnitOfWork _projectUnitOfWork;
        public HotelBookingServices(IProjectUnitOfWork projectUnitOfWork)
        {
                _projectUnitOfWork = projectUnitOfWork;
        }
        public List<HotelBooking> ListOfVBookedHotel(Guid UserId)
        {
            return _projectUnitOfWork.HotelBookingRepository.GetDynamic(c => c.UserId == UserId, null, x => x.Include(y => y.Room).ThenInclude
            (x => x.Hotel), false).ToList();
        }
    }
}
