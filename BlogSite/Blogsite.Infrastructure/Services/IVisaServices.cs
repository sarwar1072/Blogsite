using Blogsite.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public interface IVisaServices
    {
        void AddVisa(Visa visa);
        (IList<Visa> visa, int total, int totalDisplay) GetVisaList(int pageindex, int pagesize, string searchText, string orderBy);
        void EditVisa(Visa visa);
        Visa GetByid(int id);
        void DeleteVisa(int id);
        IList<Visa> ListOfVisa(string destination);
        int CountDestination(string destination);
        Visa GetSingleVisa(int id);
        IList<Visa> GetAllVisaForDropDown();

        IList<string> GetOnlyVisaDestinationName();


    }
}
