using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Entities
{
    public class Tour:IEntity<int>
    {
        public int Id { get; set; }
        public string? TourName { get; set; }
        public string? Url {  get; set; }    
        public string? Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Price { get; set; }
        public int SpotsAvailable { get; set; }
        public ICollection<Images>? Images { get; set; }
    }
}
