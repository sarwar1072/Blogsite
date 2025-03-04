
using Blogsite.Infrastructure.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSite.Web.Models
{
    public interface IUserAccessor
    {
        ApplicationUser GetUser();
    }
}
