using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Entities.Membership;
using Blogsite.Infrastructure.Services;

namespace BlogSite.Web.Models.BookingModelFolder
{
    public class VisaBookingViewModel
    {
        private IuserFormServices _services;
       
        public List<UserForm> UserForm { get; set; } = new List<UserForm>();    
        public VisaBookingViewModel(IuserFormServices services)
        {
            _services = services;   
        }
        public List<UserForm> GetBookingById(Guid userId)
        {
            var data=_services.ListOfVBookedVisa(userId);
            UserForm  = new List<UserForm>();
            if (data != null)
            {
                foreach(var item in data)
                {
                    UserForm.Add(new UserForm
                    {
                        Phone = item.Phone,
                        Email = item.Email,
                        DepartureDate = item.DepartureDate,
                        ProcessStatus = item.ProcessStatus,
                        Visa=new Visa
                        {
                            Destination=item.Visa.Destination,
                            VisaType=item.Visa.VisaType,    
                            VisaMode=item.Visa.VisaMode,
                            EntryType=item.Visa.EntryType,
                            CardUrl=item.Visa.CardUrl,  
                        },
                    }) ; 
                    
                }
            }
            return UserForm;
        }
        



    }
}
