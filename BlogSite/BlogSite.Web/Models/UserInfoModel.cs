namespace BlogSite.Web.Models
{
    public class UserInfoModel
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        
        public string? Email { get; set; }
        public int? Phone { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
