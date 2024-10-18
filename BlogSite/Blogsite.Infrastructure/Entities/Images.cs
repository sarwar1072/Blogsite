using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Entities
{
    public class Images:IEntity<int>
    {
        public int Id { get; set; } 
        public string? ImageUrl { get; set; }
        public string? AlternativeText {  get; set; }   
        public int? HotelId {  get; set; }   
        public Hotel? Hotel { get; set; }
        public int? TourId {  get; set; }    
        public Tour? Tour { get; set; }
    }
}
