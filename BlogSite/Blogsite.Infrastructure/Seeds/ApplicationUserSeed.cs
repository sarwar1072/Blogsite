using Blogsite.Infrastructure.Entities.Membership;
using Microsoft.AspNetCore.Identity;

namespace Blogsite.Infrastructure.Seeds
{
	internal class ApplicationUserSeed
	{
		internal static ApplicationUser[] Users
		{
			get
			{
				var rootUser = new ApplicationUser
				{
					Id = Guid.Parse("e9b3be8c-99c5-42c7-8f2e-1eb39f6d9125"),
					Name="Admin",
					UserName = "admin@gmail.com",
					NormalizedUserName = "admin@gmail.com",
					Email = "admin@gmail.com",
                    NormalizedEmail = "admin@gmail.com",
					LockoutEnabled = true,
					SecurityStamp = Guid.NewGuid().ToString(),
					EmailConfirmed = true
				};
				var normalUser = new ApplicationUser
				{
					Id = Guid.Parse("8f3d96ce-76ec-4992-911a-33ceB81fa29d"),
				    Name = "sarwar",
					UserName = "user@gmail.com.com",
					NormalizedUserName = "user@gmail.com.com",
					Email = "user@gmail.com.com",
					NormalizedEmail = "user@gmail.com.com",
					LockoutEnabled = true,
					SecurityStamp = Guid.NewGuid().ToString(),
					EmailConfirmed = true
				};
				var password = new PasswordHasher<ApplicationUser>();
				var rootHashed = password.HashPassword(rootUser, "Admin123@");
				var normalHashed = password.HashPassword(normalUser, "User123@");
                rootUser.PasswordHash = rootHashed;
				normalUser.PasswordHash = normalHashed;

				return new ApplicationUser[]
				{
                    rootUser,
					normalUser
                };
			}
		}
	}
}
