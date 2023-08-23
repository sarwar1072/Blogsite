using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Membership.Services
{
    public interface ISignInManagerAdapter<T> where T:class
    {
        Task<IEnumerable<AuthenticationScheme>> GetExternalSchemeAsync();
        Task SignInAsync(T applicationUser);
        Task SignOutAsync();
        Task<SignInResult> PasswordSignInAsync(T user);
    }
}
