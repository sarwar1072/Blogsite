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
        IList<Tour> ListOfTour(string destination);
        Tour TourDetailsById(int id);
        IList<Tour> ListOfTourName();
        Tour GetTourDetails(int id);
        IList<TourDetails> GetTypeOfTour();
        void AddConsulationForm(ConsultationForm Form);
        (IList<ConsultationForm> forms, int total, int totalDisplay) GetConsultForm(int pageindex, int pagesize, string searchText, string orderBy);

        public (IList<Tour> tours, int total, int totalDisplay) GetTourList
            (int pageindex, int pagesize, string searchText, string orderBy);

    }
}
