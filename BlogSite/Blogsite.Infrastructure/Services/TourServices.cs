using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Exceptions;
using Blogsite.Infrastructure.UOWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public class TourServices:ITourServices
    {
        private IProjectUnitOfWork _projectUnitOfWork;
        public TourServices(IProjectUnitOfWork projectUnitOfWork)
        {
                _projectUnitOfWork = projectUnitOfWork;
        }
        public async Task AddTour(Tour tour)
        {
            if (tour is null)
            {
                throw new InvalidOperationException("Tour can not be null");
            }
            var tourCount = await _projectUnitOfWork.TourRepository.GetCountAsync(c => c.TourName == tour.TourName);

            if(tourCount > 0) {
                throw new DuplicateException("Same tour exist");
            }

            await _projectUnitOfWork.TourRepository.AddAsync(tour); 
            await _projectUnitOfWork.SaveAsync();

        }

    }
}
