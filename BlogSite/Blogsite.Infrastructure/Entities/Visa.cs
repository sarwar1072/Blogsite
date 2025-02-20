using DevSkill.Data;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogsite.Infrastructure.Entities
{
    public class Visa:IEntity<int>
    {
        public int Id { get; set; }
        public string? Destination { get; set; }
         public string? CoverUrl {  get; set; } 
        public string? CardUrl { get; set; } 
        public string? VisaType { get; set; }
        public string? VisaMode {  get; set; }    
        public string? EntryType { get; set; }
        public int? VisaValidity { get; set; }
        public int? ProcessingTime { get; set; }
        public int?  MaxiMumStay { get; set; }
        public double Price { get; set; }
        public string? Requirements {  get; set; } 
        public string? Policy { get; set; }
    }
}
