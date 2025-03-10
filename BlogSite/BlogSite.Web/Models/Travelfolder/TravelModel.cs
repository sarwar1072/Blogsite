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
        public int Count { get; set; }
        public IList<Traveller> TravellerList { get; set; } 
        public Traveller SingleTraveller { get; set; }
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
        public void NoOfTraveller(Guid UserId)
        {
           Count= _travelServices.TravellerCount(UserId);
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
        public void EditTraveller()
        {
            var data = new Traveller
            {
                Id=Id,
                Name = Name,
                Phone = Phone,
                Email = Email,
                DateOfBirth = DateOfBirth,
                ExpireDate = ExpireDate,
                PassportNo = PassportNo,

            };
            _travelServices.EditTraveller(data);
        }
        public void RemoveTraveller(int id)
        {
            _travelServices.DeleteTraveller(id);
        }
        public Traveller GetById(int id)
        {
            var data=_travelServices.GetByid(id);
            SingleTraveller = new Traveller();
            SingleTraveller.Id = data.Id;
            SingleTraveller.Name = data.Name;   
            SingleTraveller.Phone = data.Phone; 
            SingleTraveller.Email = data.Email;
            SingleTraveller.ExpireDate = data.ExpireDate;
            SingleTraveller.DateOfBirth = data.DateOfBirth; 
            SingleTraveller.PassportNo = data.PassportNo;   
            return SingleTraveller;
        }    
        public IList<Traveller> ListOfTravellerByUserId(Guid UserId)
        {
            var data=_travelServices.GetByUserId(UserId);
            TravellerList = new List<Traveller>();    
            foreach (var item in data)
            {
                TravellerList.Add(item);
            }
            return TravellerList;
        }

    }
}
