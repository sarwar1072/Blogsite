using DevSkill.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Entities
{
    public class HotelFacilities:IEntity<int>
    {
        public int Id { get; set; } 
        public string? BusinessFacilities {  get; set; }
        public string? FitnessFacilities {  get; set; } 
        public string? FoodFacilities {  get; set; }    
        public string? General {  get; set; }   
        public string? IndoorFacitilies {  get; set; }   
        public string? Parking {  get; set; }   
        public string? Policies {  get; set; }  
        public int? HotelId {  get; set; }   
        public Hotel? Hotel { get; set; }   
    }
}
