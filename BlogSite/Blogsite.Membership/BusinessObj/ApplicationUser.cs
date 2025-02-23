using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Membership.BusinessObj
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthOfDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }
        public int? NumberOfTravellers { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
