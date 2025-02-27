using Blogsite.Infrastructure.Entities.Membership;
using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Entities
{
    public class UserForm:IEntity<int>
    {
        public int Id { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public Guid  applicationUserid { get; set; }
        public int VisaId { get; set; }
        public Visa? Visa { get; set; }
        public string? Phone { get; set; }
        public string? Email {  get; set; }  
        public int? NumberOfTravellers { get; set; }
        public DateTime? DepartureDate { get; set; }
        public string? Remark { get; set; }
        public string? ProcessStatus {  get; set; } 

    }
}
