using Autofac;
using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;

namespace BlogSite.Web.Models.Travelfolder
{
    public class TravelModel:BaseModel
    {
        private ITravelServices _travelServices;
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string? PassportNo { get; set; }
       public Guid? UserId { get; set; }
        public TravelModel(ITravelServices travelServices)
        {
            _travelServices = travelServices;
        }
        public TravelModel()
        {
                
        }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _travelServices = _lifetimeScope.Resolve<ITravelServices>();
            base.ResolveDependency(lifetimeScope);
        }
        public void AddTraveller(Guid UserId)
        {
            var data = new Traveller
            {
                UserId = UserId,
                Name = Name,
                Phone = Phone,
                Email = Email,
                DateOfBirth = DateOfBirth,
                ExpireDate = ExpireDate,
                PassportNo = PassportNo,

            };
            _travelServices.AddTraveller(data);
        }
    }
}
