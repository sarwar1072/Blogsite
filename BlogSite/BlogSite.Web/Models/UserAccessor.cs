using Blogsite.Infrastructure.Entities.Membership;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Models
{
    public class UserAccessor: IUserAccessor
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IHttpContextAccessor _httpContextAccessor;
        public UserAccessor(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public ApplicationUser GetUser()
        {
            if (_httpContextAccessor.HttpContext.User != null)
                return _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User).Result;
            else
                return null;
        }
    }
}
