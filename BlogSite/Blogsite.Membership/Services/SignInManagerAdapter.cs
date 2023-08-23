using AutoMapper;
using Blogsite.Membership.BusinessObj;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationUserEO = Blogsite.Infrastructure.Entities.Membership.ApplicationUser;

namespace Blogsite.Membership.Services
{
    public class SignInManagerAdapter: ISignInManagerAdapter<ApplicationUser>
    {
        private readonly SignInManager _signInManager;
        private IMapper _mapper;
        public SignInManagerAdapter(SignInManager signInManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _mapper = mapper;   
        }
        private ApplicationUserEO GetSingleEntity(ApplicationUser applicationUser)
        {
            var user = _mapper.Map<ApplicationUserEO>(applicationUser);
            return user;
        }
        public async Task<IEnumerable<AuthenticationScheme>> GetExternalSchemeAsync()
        {
            return await _signInManager.GetExternalAuthenticationSchemesAsync();
        }
        public async Task SignInAsync(ApplicationUser user)
        {
            var entity = GetSingleEntity(user); 
            await _signInManager.SignInAsync(entity,isPersistent:false);
        }
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<SignInResult> PasswordSignInAsync(ApplicationUser user)
        {
            return await _signInManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, 
                lockoutOnFailure: false);
        }
    }
}
