using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Entities
{
    public class Flight:IEntity<int>
    {
        public int Id { get; set; }
        public string? Airline { get; set; }
        public string? Url {  get; set; }    
        public string? From { get; set; }
        public string? To { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public double Price { get; set; }
        public int SeatsAvailable { get; set; }
    }
}
