using Autofac;
using Blogsite.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Areas.Admin.Models
{
    public class DashboardModel:AdminBaseModel
    {

        public int TotalTours { get; set; }
        public int TotalHotel { get; set; }
        public int TotalVisaDestination { get; set; }

        private IDashboardServices _Services;
        public DashboardModel(IDashboardServices Services)
        {
            _Services = Services;   
        }
        public DashboardModel()
        {
           
        }
        //public override void ResolveDependency(ILifetimeScope lifetimeScope)
        //{
        //    _lifetimeScope = lifetimeScope;
        //    _contextAccessor = _lifetimeScope.Resolve<IDashboardServices>();
        //}

        public void GetAllProperty()
        {
            TotalTours = _Services.NumberOfTourDestination();
            TotalHotel= _Services.NumberOfHotel();
            TotalVisaDestination = _Services.NumberOfVisaType();
        }

    }
}
