using System.ComponentModel.DataAnnotations;

namespace BlogSite.Web.Models
{
    public class Post
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Enter Title")]
        public string  Title  { get; set; }
        [Required(ErrorMessage ="Enter Description")]
        public string Description { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
