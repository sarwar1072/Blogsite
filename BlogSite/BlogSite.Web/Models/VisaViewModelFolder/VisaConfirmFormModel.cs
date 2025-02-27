using Autofac;
using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Entities.Membership;
using Blogsite.Infrastructure.Services;

namespace BlogSite.Web.Models.VisaViewModelFolder
{
    public class VisaConfirmFormModel:BaseModel
    {
        private IVisaServices _visaServices;
        private IuserFormServices _userFormsServices;   
        public int Id { get; set; }
        public string? Destination { get; set; }      
        public string? VisaType { get; set; }
        public string? VisaMode { get; set; }
        public string? EntryType { get; set; }
        public int? VisaValidity { get; set; }
       public int? MaxiMumStay { get; set; } 
        public double Price { get; set; }
        public string?  Name { get; set; }
        public string?  Email{ get; set; }
        public string? Phone { get; set; }
        public DateTime? DepartureDate { get; set; }
        public int? NumberOfTravellers { get; set; }
        public int VisaId { get; set; }
        public Guid UserId { get; set; }
        public string? Remark {  get; set; }
        public VisaConfirmFormModel(IVisaServices visaServices, IuserFormServices userFormsServices)
        {
            _visaServices = visaServices;
            _userFormsServices = userFormsServices; 
        }
        public VisaConfirmFormModel() { }
        public override void ResolveDependency(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
            _userFormsServices = _lifetimeScope.Resolve<IuserFormServices>();         
            base.ResolveDependency(lifetimeScope);
        }
        public void AddUserForm()
        {
            var data = new UserForm
            {
                applicationUserid =UserId,
                VisaId=VisaId,
                Phone=Phone,    
                Email=Email,    
                NumberOfTravellers=NumberOfTravellers,  
                DepartureDate= DepartureDate,
                Remark= Remark,
                ProcessStatus="Requested",    
                
            };
            _userFormsServices.AddUserForm(data);   
            
        }
        public void VisaById(int id)
        {
            var data = _visaServices.GetByid(id);
            VisaId= data.Id;    
            Destination = data.Destination;
            VisaType = data.VisaType;
            VisaMode = data.VisaMode;
            EntryType = data.EntryType;
            VisaValidity = data.VisaValidity;
            Price = data.Price;
            MaxiMumStay = data.MaxiMumStay;
        }
    }
}
