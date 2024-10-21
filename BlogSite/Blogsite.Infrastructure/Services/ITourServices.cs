using Blogsite.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public interface ITourServices
    {
        void AddTour(Tour tour);
        void DeleteTour(int id);
        void EditTour(Tour tour);
        Tour GetByid(int id);
        public (IList<Tour> tours, int total, int totalDisplay) GetTourList
            (int pageindex, int pagesize, string searchText, string orderBy);

    }
}
