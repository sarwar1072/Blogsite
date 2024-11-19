using Autofac;
using AutoMapper;
using Blogsite.Membership.Services;
using BlogSite.Web.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Areas.Admin.Models
{
    public abstract class AdminBaseModel
    {
        protected IHttpContextAccessor? _contextAccessor;
        protected IMapper? _mapper;
        protected ILifetimeScope? _lifetimeScope;
        public MenuModel MenuModel { get; set; }

        public ResponseModel? Response
        {
            get
            {
                if (_contextAccessor == null || _contextAccessor.HttpContext == null || !_contextAccessor.HttpContext.Session.IsAvailable)
                {
                    return null;  // Return null or handle the absence of HttpContext
                }

                if (_contextAccessor.HttpContext.Session.Keys.Contains(nameof(Response)))
                {
                    var response = _contextAccessor.HttpContext.Session.Get<ResponseModel>(nameof(Response));
                    _contextAccessor.HttpContext.Session.Remove(nameof(Response));
                    return response;
                }

                return null;
            }
            set
            {
                if (_contextAccessor != null && _contextAccessor.HttpContext != null)
                {
                    _contextAccessor.HttpContext.Session.Set(nameof(Response), value);
                }
            }
        }

        public AdminBaseModel(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
            SetupMenu();
        }
        public virtual void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _contextAccessor = _lifetimeScope.Resolve<IHttpContextAccessor>();
        }
        public AdminBaseModel()
        {
            SetupMenu();
        }

        private void SetupMenu()
        {
            MenuModel = new MenuModel
            {
                MenuItems = new List<MenuItem>()
                {
                    {


                        new MenuItem
                        {
                            Title = "Tour",
                            Childs = new List<MenuChildItem>
                            {
                                new MenuChildItem{ Title = "View Tour", Url = "/Admin/Tour" },
                                new MenuChildItem{Title="Add Tour",Url="/Admin/Tour/Add"}
                            }
                        }
                    },

                    {
                        new MenuItem
                        {
                           Title="TourDetails type",
                           Childs=new List<MenuChildItem>
                           {
                               new MenuChildItem{Title="View Details",Url="/Admin/TourDetails"},
                               new MenuChildItem{Title="Add details",Url="/Admin/TourDetails/AddTourDetails"}
                           }
                        }
                    },

                    {
                        new MenuItem
                        {
                            Title = "Hotel",
                            Childs = new List<MenuChildItem>
                            {
                                new MenuChildItem{ Title = " View hotel", Url = "/Admin/Hotel" },
                                new MenuChildItem{ Title = "Add Hotel", Url ="/Admin/Hotel/AddHotel"}

                            }
                        }
                    },

                    {
                        new MenuItem
                        {
                            Title="Room",
                           Childs=new List<MenuChildItem>
                           {
                               new MenuChildItem{Title="View  Room",Url="/Admin/Room"},
                               new MenuChildItem{Title="Add ",Url="/Admin/Room/AddRoom"}
                           }
                        }
                    },
                    {
                        new MenuItem
                        {
                           Title="Hotel Facilitiy",
                           Childs=new List<MenuChildItem>
                           {
                               new MenuChildItem{Title="Hotel Facility",Url="/Admin/HotelFacility"},
                               new MenuChildItem{Title="Add AddFacility",Url="/Admin/HotelFacility/AddFacility"}
                           }
                        }
                    }
                    ,

                     {
                        new MenuItem
                        {
                           Title="Company",
                           Childs=new List<MenuChildItem>
                           {
                               new MenuChildItem{Title="View Company",Url="/Admin/Company"},
                               new MenuChildItem{Title="Add Company",Url="/Admin/Company/AddCompany"}
                           }
                        }
                    }
                }
            };
        }

    }
}
