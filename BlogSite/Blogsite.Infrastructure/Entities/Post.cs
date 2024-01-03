using DevSkill.Data;
using System.ComponentModel.DataAnnotations;

namespace Blogsite.Infrastructure.Entities
{
    public class Post:IEntity<int>
    {
        public int Id { get; set; }
        public string  Title  { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
