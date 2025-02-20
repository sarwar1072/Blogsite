using Autofac;
using Blogsite.Infrastructure.DbContexts;
using Blogsite.Infrastructure.Repositories;
using Blogsite.Infrastructure.Services;
using Blogsite.Infrastructure.UOWork;
using Microsoft.Extensions.Hosting;

namespace Blogsite.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly string _webHostEnvironment;

        public InfrastructureModule(string connectionString, string migrationAssemblyName,
            string webHostEnvironment)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
            _webHostEnvironment = webHostEnvironment;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<TourRepository>().As<ITourRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProjectUnitOfWork>().As<IProjectUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TourServices>().As<ITourServices>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TourDetailsRepository>().As<ITourDetailsRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TourDetailsServices>().As<ITourDetailsServices>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ConsultationFormRepository>().As<IConsultationFormRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<HotelRepository>().As<IHotelRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RoomRepository>().As<IRoomRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<RoomServices>().As<IRoomServices>().InstancePerLifetimeScope();
            builder.RegisterType<HotelServices>().As<IHotelServices>().InstancePerLifetimeScope();
            builder.RegisterType< HotelFacilitiesRepositories >().As< IHotelFacilitiesRepositories >().InstancePerLifetimeScope ();
            builder.RegisterType<HotelfacilityServices>().As<IHotelfacilityServices>().InstancePerLifetimeScope();
            builder.RegisterType<HotelBookingRepository>().As<IHotelBookingRepository>().InstancePerLifetimeScope();
            builder.RegisterType<VisaRepository>().As<IVisaRepository>().InstancePerLifetimeScope();
            builder.RegisterType<VisaServices>().As<IVisaServices>().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
