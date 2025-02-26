using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Services
{
    public interface IDashboardServices
    {
         int NumberOfTourDestination();
         int NumberOfHotel();
         int NumberOfVisaType();
       
    }
}
