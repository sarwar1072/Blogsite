using Blogsite.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public interface ITourDetailsServices
    {
        void AddTourDetails(TourDetails tourDetails);
        void EditDetails(TourDetails details);
        TourDetails GetByid(int id);
        void DeleteTourDetails(int id);
       
        (IList<TourDetails> tours, int total, int totalDisplay) GetTourdetailsList(int pageindex, int pagesize, string searchText, string orderBy);

    }
}
