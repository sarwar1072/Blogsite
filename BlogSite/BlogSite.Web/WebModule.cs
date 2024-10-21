using Autofac;
using BlogSite.Web.Areas.Admin.Models;
using BlogSite.Web.Areas.Admin.Models.TourModelFolder;
using BlogSite.Web.Models;

namespace BlogSite.Web
{
    public class WebModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<PublicLayoutModel>()
            //    .AsSelf()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<LoginModel>()
            //    .AsSelf()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<RegistrationConfirmationModel>()
            //    .AsSelf()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<RegisterModel>()
            //    .AsSelf()
            //    .InstancePerLifetimeScope();

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
            

            base.Load(builder);
        }
    }
}
