
using Autofac;

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

            //builder.RegisterType<PostLayoutModel>()
            //    .AsSelf()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<QuestionCreateModel>()
            //    .AsSelf()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<QuestionEditModel>()
            //    .AsSelf()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<AnswerCreateModel>()
            //    .AsSelf()
            //    .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
