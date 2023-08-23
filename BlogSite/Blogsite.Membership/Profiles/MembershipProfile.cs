using AutoMapper;
using ApplicationUserEO= Blogsite.Infrastructure.Entities.Membership.ApplicationUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogsite.Membership.BusinessObj;

namespace Blogsite.Membership.Profiles
{
    public class MembershipProfile:Profile
    {
        public MembershipProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserEO>().ReverseMap();

        }
    }
}
