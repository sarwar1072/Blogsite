using AutoMapper;
using Blogsite.Membership.BusinessObj;
using Blogsite.Membership.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApplicationUserEO = Blogsite.Infrastructure.Entities.Membership.ApplicationUser;

namespace Blogsite.Membership.Services
{
    public class UserManagerAdapter:IUserManagerAdapter<ApplicationUser>
    {
        private readonly UserManager _userManager;
        private readonly SignInManager _signInManager;
        private  IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public UserManagerAdapter(UserManager userManager,SignInManager signInManager,
            IMapper mapper,IHttpContextAccessor contextAccessor)
        {
            _userManager=userManager;
            _signInManager=signInManager;   
            _mapper=mapper;
            _contextAccessor=contextAccessor;   
        }
        
        private ApplicationUserEO GetSingleEntity(ApplicationUser user)
        {
            var entity = _mapper.Map<ApplicationUserEO>(user);
            return entity;  
        }

        private ApplicationUser GetSingleBusinessObj(ApplicationUserEO userEO)
        {
            var user=_mapper.Map<ApplicationUser>(userEO);
            return user;
        }
        public async Task<IdentityResult> CreateAsync(ApplicationUser user,string password)
        {
            if (user == null)
                throw new InvalidOperationException("User must be provided to created member");

            if(string.IsNullOrWhiteSpace(password))
                throw new ArgumentNullException("password"); 
            
             var entity=GetSingleEntity(user);
            var result = await _userManager.CreateAsync(entity, password);

            if (!result.Succeeded)
            {
                return result;
            }
            var roleResult = await _userManager.AddToRoleAsync(entity,"User");

            await SignInAsync(entity);

            if (!roleResult.Succeeded)
            {
                return roleResult;
            }
            return result; 
        }

        private async Task SignInAsync(ApplicationUserEO user)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }
        public async Task CreateAccountAsync(ApplicationUser user,string password)
        {
            var entity=GetSingleEntity(user);
           var result= await _userManager.CreateAsync(entity, password);

            if (!result.Succeeded)
                throw new InvalidOperationException("Failed to create user account try again");
        }
        public bool ConfirmedAccount()
        {
            return _userManager.Options.SignIn.RequireConfirmedAccount;
        }

        public async Task<string> GetUserIdAsync(ApplicationUser user)
        {
            var entity = GetSingleEntity(user);
            return await _userManager.GetUserIdAsync(entity);
        }

        public async Task<ApplicationUser> FindByUsernameAsync(string email)
        {
            var user= await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return null;
            }
            else
            {
                return GetSingleBusinessObj(user);
            }
        }

        public async Task<IList<string>> GetUserRolesAsync(string email)
        {
            if (email is null)
                throw new InvalidOperationException("Id must be provide to get roles");

            var userEntity = await _userManager.FindByEmailAsync(email);
            if (userEntity is null)
                throw new InvalidOperationException("User not found");

            var roles = await _userManager.GetRolesAsync(userEntity);
            return roles;
        }

        public async Task<bool> UpdateAccountAsync(ApplicationUser user)
        {
            if (user == null)
                throw new InvalidOperationException("Application user must be provided to update dependent data ");

            var userEntity = await _userManager.FindByIdAsync(user.Id.ToString());

            userEntity = _mapper.Map(user, userEntity);
            userEntity.NormalizedEmail = user.Email!.ToUpper();

            var result = await _userManager.UpdateAsync(userEntity);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }
        public async Task SignInAsync(Guid id)
        {
            var userEntity = await _userManager.FindByIdAsync(id.ToString());
            if (userEntity is  null)
                throw new InvalidOperationException("Application user not found");
           
            await _signInManager.SignInAsync(userEntity, true);
        }
        public string? GetUserId()
        {
            return _contextAccessor?.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private async Task<ApplicationUserEO> FindUserIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return user;
        }
        public async Task<IdentityResult> ChangePassword(string userId, string newPassword,
                                                         string confirmPassword)
        {
            var user = await FindUserIdAsync(userId);
            var result = await _userManager.ChangePasswordAsync(user, newPassword,
                                                                 confirmPassword);
            return result;
        }

        public async Task RolesAsync(string userid, RoleType[] types)
        {
            if (string.IsNullOrEmpty(userid))
                throw new InvalidOperationException("User id must be provide.");

            if (types.Length == 0)
                throw new InvalidOperationException("Role must be provide to assign into user.");

            var user = await FindUserIdAsync(userid);
            var roles = types.Select(a => a.ToString()).ToArray();
            await _userManager.AddToRolesAsync(user, roles);
        }

    }
}
