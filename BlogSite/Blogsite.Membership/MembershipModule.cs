using Autofac;
using DevSkill.Http.Utilities;
using DevSkill.Http.Emails.Services;
using Blogsite.Membership.Services;
using Blogsite.Membership.BusinessObj;

namespace Blogsite.Membership
{
    public class MembershipModule : Module
    {
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<UrlService>().As<IUrlService>()
				.InstancePerLifetimeScope();

			//builder.RegisterType<HtmlEmailService>().As<IQueuedEmailService>()
			//	.InstancePerLifetimeScope();

			builder.RegisterType<SignInManagerAdapter>().As<ISignInManagerAdapter<ApplicationUser>>()
				.InstancePerLifetimeScope();

			builder.RegisterType<UserManagerAdapter>().As<IUserManagerAdapter<ApplicationUser>>()
				.InstancePerLifetimeScope();

			//builder.RegisterType<MembershipMailSenderService>().As<IMembershipMailSenderService>()
			//	.InstancePerLifetimeScope();
			base.Load(builder);
		}
	}
}
