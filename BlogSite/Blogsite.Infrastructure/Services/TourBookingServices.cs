using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.UOWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public class TourBookingServices: ITourBookingServices
    {
        private IProjectUnitOfWork _projectUnitOfWork;
        public TourBookingServices(IProjectUnitOfWork projectUnitOfWork)
        {
            _projectUnitOfWork = projectUnitOfWork;
        }
        //public List<> ListOfVBookedTour(Guid UserId)
        //{
        //    return _projectUnitOfWork.HotelBookingRepository.GetDynamic(c => c.UserId == UserId, null, x => x.Include(y => y.Room).ThenInclude
        //    (x => x.Hotel), false).ToList();
        //}
    }
}
