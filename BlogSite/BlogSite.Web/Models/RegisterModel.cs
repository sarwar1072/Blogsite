using Autofac;
using AutoMapper;
using Blogsite.Membership.BusinessObj;
using Blogsite.Membership.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BlogSite.Web.Models
{   
    public class RegisterModel:BaseModel
    {
        private IUserManagerAdapter<ApplicationUser>? _userManagerAdapter;
        private ISignInManagerAdapter<ApplicationUser>? _signInManagerAdapter;
        private ILifetimeScope? _scope;
        private IMapper? _mapper;
        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        public string? UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
        public string? ReturnUrl { get; set; }


        public IList<AuthenticationScheme>? ExternalLogins { get; set; }
        public RegisterModel()
        {

        }
        public RegisterModel(IUserManagerAdapter<ApplicationUser> userManagerAdapter,
            ISignInManagerAdapter<ApplicationUser> signInManagerAdapter,
            IMapper mapper)    
        {
            _userManagerAdapter = userManagerAdapter;
            _signInManagerAdapter = signInManagerAdapter;
            _mapper = mapper;
        }

        internal void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _userManagerAdapter = _scope.Resolve<IUserManagerAdapter<ApplicationUser>>();
            _signInManagerAdapter = _scope.Resolve<ISignInManagerAdapter<ApplicationUser>>();
            _mapper = _scope.Resolve<IMapper>();
        }
        

        internal async Task<IdentityResult> CreateAsync()
        {
            var user = GetMember();
            return await _userManagerAdapter!.CreateAsync(user, Password!);

        }
        internal bool RequireConfirmedAccount()
        {
            return _userManagerAdapter!.ConfirmedAccount();
        }
        internal async Task<RegisterModel> FindByEmailAsync(string email)
        {
            var user = _userManagerAdapter.FindByUsernameAsync(email);
            if (user == null)
                return null;
            else
                return _mapper.Map(user, this);
        }

        internal async Task SignInAsync()
        {
            var user = GetMember();
            await _signInManagerAdapter!.SignInAsync(user);
        }
        internal async Task<string> GetUserIdAsync()
        {
            var user = GetMember();
            return await _userManagerAdapter!.GetUserIdAsync(user);
        }
        internal async Task GetExternalAuthenticationSchemesAsync()
        {
            ExternalLogins = (await _signInManagerAdapter!.GetExternalSchemeAsync()).ToList();
        }
        private ApplicationUser GetMember()
        {
            var user = new ApplicationUser
            {
                UserName = Email,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
            };
            return user;
        }

    }
}
