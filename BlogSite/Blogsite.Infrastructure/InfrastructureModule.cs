using Autofac;
using Blogsite.Infrastructure.DbContexts;
using Blogsite.Infrastructure.Repositories;
using Blogsite.Infrastructure.Services;
using Blogsite.Infrastructure.UOWork;

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

            //builder.RegisterType<AnswerRepository>().As<IAnswerRepository>()
            //    .InstancePerLifetimeScope();
            //builder.RegisterType<AnswerServices>().As<IAnswerServices>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<VoteRepository>().As<IVoteRepository>()
            //    .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
