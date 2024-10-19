using Autofac;
using AutoMapper;
using Blogsite.Membership.Services;
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
        //public ResponseModel Response
        //{
        //    get
        //    {
        //        if (_httpContextAccessor.HttpContext.Session.IsAvailable
        //            && _httpContextAccessor.HttpContext.Session.Keys.Contains(nameof(Response)))
        //        {
        //            var response = _httpContextAccessor.HttpContext.Session.Get<ResponseModel>(nameof(Response));
        //            _httpContextAccessor.HttpContext.Session.Remove(nameof(Response));
        //            return response;
        //        }
        //        else
        //            return null;
        //    }
        //    set
        //    {
        //        _httpContextAccessor.HttpContext.Session.Set(nameof(Response),
        //            value);
        //    }
        //}
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
                                new MenuChildItem{Title="Add category",Url="/Admin/Tour/Add"}
                            }
                        }
                    },

                    {
                        new MenuItem
                        {
                           Title="Cover type",
                           Childs=new List<MenuChildItem>
                           {
                               new MenuChildItem{Title="View CoverType",Url="/Admin/CoverType"},
                               new MenuChildItem{Title="Add CoverType",Url="/Admin/CoverType/AddCoverType"}
                           }
                        }
                    },

                    {
                        new MenuItem
                        {
                            Title = "Product",
                            Childs = new List<MenuChildItem>
                            {
                                new MenuChildItem{ Title = " View Product", Url = "/Admin/Product" },
                                new MenuChildItem{ Title = "Add Product", Url ="/Admin/Product/AddProduct"}

                            }
                        }
                    },

                    {
                        new MenuItem
                        {
                            Title="List Order",
                           Childs=new List<MenuChildItem>
                           {
                               new MenuChildItem{Title="View  Order",Url="/Admin/Order"},
                               //new MenuChildItem{Title="Add ",Url="/Admin/StudentRegistration/CreateRegistration/"}
                           }
                        }
                    },
                    {
                        new MenuItem
                        {
                           Title="List User",
                           Childs=new List<MenuChildItem>
                           {
                               new MenuChildItem{Title="View  User",Url="/Admin/User"},
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
