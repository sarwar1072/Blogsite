using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Entities
{
    public class TourDetails:IEntity<int>
    {
        public int Id { get; set; }
        public string? Overview { get; set; }
        public string? Location { get; set; }
        public string? Timing { get; set; }
        public string? InclusionExclusion { get; set; }
        public string? Description { get; set; }
        public string? AdditionalInformation { get; set; }
        public string? TravelTips { get; set; }
        public string? Options { get; set; }
        public string? Policy { get; set; }

        // Navigation property to multiple Tours
        public  ICollection<Tour> Tours { get; set; } = new List<Tour>();
    }
}
