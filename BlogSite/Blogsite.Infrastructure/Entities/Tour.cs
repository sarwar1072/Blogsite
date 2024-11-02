using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Entities
{
    public class Tour:IEntity<int>
    {
        public int Id { get; set; }
        public string? TourName { get; set; }
        public string? TourUrl {  get; set; }    
        public string? Destination { get; set; }     
        public int MaxiMumPeople {  get; set; }
        public int MiniMumPeople { get; set; }
        public string? MapUrl {  get; set; } 
        public string? Requirements {  get; set; }    
        public string? CancellationTerm {  get; set; }   
        public double Price { get; set; }
        public int SpotsAvailable { get; set; }
        public ICollection<Images>? Images { get; set; }
        [ForeignKey("TourDetails")]
       public int? TourDetailsId {  get; set; }    
        public TourDetails? TourDetails { get; set; }    
    }
}
