using Autofac;
using BlogSite.Web.Areas.Admin.Models;
using BlogSite.Web.Areas.Admin.Models.HotelFacFolder;
using BlogSite.Web.Areas.Admin.Models.HotelmodelFolder;
using BlogSite.Web.Areas.Admin.Models.RoomFolder;
using BlogSite.Web.Areas.Admin.Models.TourDetailsFolder;
using BlogSite.Web.Areas.Admin.Models.TourModelFolder;
using BlogSite.Web.Models;
using BlogSite.Web.Models.HotelViewM;
using BlogSite.Web.Models.tourViewModel;

namespace BlogSite.Web
{
    public class WebModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EditTourDetails>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<CreateTourDetails>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<TourDetailsVModel>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<TourDetailsModel>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<TourViewModel>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<EditTourModel>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<ResponseModel>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();
            builder.RegisterType<TourModel>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<CreateTour>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<FileHelper>().As<IFileHelper>().InstancePerLifetimeScope();
            builder.RegisterType<RoomModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<EditRoomModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<CreateRoomModel>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<CreateHotelModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<HotelModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<EditHotelModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<HotelSearchFilter>().AsSelf().InstancePerLifetimeScope();  
            builder.RegisterType< HotelModelView >().AsSelf().InstancePerLifetimeScope(); 
            builder.RegisterType< CreateHotelfacility >().AsSelf().InstancePerLifetimeScope ();
            builder.RegisterType<EditHotelfacility>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<HotelfacilityModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType< RoomDetailsModel >().AsSelf() .InstancePerLifetimeScope(); 
            builder.RegisterType< BookingRequestViewModel >().AsSelf().InstancePerLifetimeScope(); 
            base.Load(builder);
        }
    }
}
