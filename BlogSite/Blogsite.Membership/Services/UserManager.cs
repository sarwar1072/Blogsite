using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Blogsite.Infrastructure.Entities.Membership;

namespace Blogsite.Membership.Services
{
    public class UserManager : UserManager<ApplicationUser>
    {
		public UserManager(IUserStore<ApplicationUser> store,
		   IOptions<IdentityOptions> optionsAccessor,
		   IPasswordHasher<ApplicationUser> passwordHasher,
		   IEnumerable<IUserValidator<ApplicationUser>> userValidators,
		   IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
		   ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors,
		   IServiceProvider services, ILogger<UserManager<ApplicationUser>> logger)
		   : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
		{
		}
	}
}
