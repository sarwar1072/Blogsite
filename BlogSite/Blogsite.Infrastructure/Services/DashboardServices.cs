using Blogsite.Infrastructure.UOWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public class DashboardServices: IDashboardServices
    {
        private IProjectUnitOfWork _projectUnitOfWork;
       
        public DashboardServices(IProjectUnitOfWork projectUnitOf)
        {
                _projectUnitOfWork = projectUnitOf;
        }

        public int NumberOfTourDestination()
        {
            return _projectUnitOfWork.TourRepository.GetCount();    
        }
        public int NumberOfHotel()
        {
            return _projectUnitOfWork.HotelRepository.GetCount();   
        }

        public int NumberOfVisaType() 
        { 
            return _projectUnitOfWork.VisaRepository.GetCount();
        }
    }
}
