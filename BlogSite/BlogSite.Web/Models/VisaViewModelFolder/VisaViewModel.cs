using Blogsite.Infrastructure.Entities;
using Blogsite.Infrastructure.Services;

namespace BlogSite.Web.Models.VisaViewModelFolder
{
    public class VisaViewModel
    {
        private IVisaServices _visaServices;
        
        public int Id { get; set; }
        public string? Destination { get; set; }
        public string? CoverUrl { get; set; }
        public string? CardUrl { get; set; }
        public string? VisaType { get; set; }
        public string? VisaMode { get; set; }
        public string? EntryType { get; set; }
        public int? VisaValidity { get; set; }
        public int? ProcessingTime { get; set; }
        public int? MaxiMumStay { get; set; }
        public double Price { get; set; }
        public string? Requirements { get; set; }
        public string? Policy { get; set; }
        public int Count { get; set; }
        public IList<Visa> VisaList { get; set; }
        public VisaViewModel(IVisaServices visaServices)
        {
            _visaServices = visaServices;
        }

        public IList<Visa> ListofVisa(string destination)
        {
            var entity = _visaServices.ListOfVisa(destination);
            Count = entity.Count;
            VisaList = new List<Visa>();
            if (entity.Any())
            {
                CoverUrl = entity.First().CoverUrl;
                Destination = entity.First().Destination;
                Policy = entity.First().Policy;
                Requirements = entity.First().Requirements; 
            }

            foreach (var item in entity)
            {
                VisaList.Add(new Visa
                {
                    Id = item.Id,
                    Destination = item.Destination,
                    CardUrl = item.CardUrl,
                    VisaType = item.VisaType,
                    VisaMode = item.VisaMode,
                    EntryType = item.EntryType,
                    VisaValidity = item.VisaValidity,
                    ProcessingTime = item.ProcessingTime,
                    MaxiMumStay = item.MaxiMumStay,
                    Price = item.Price,
                    Policy=item.Policy,
                    Requirements=item.Requirements,
                });

            }
            return VisaList;
        }
    }
}
