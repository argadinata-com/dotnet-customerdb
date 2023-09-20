using AutoMapper;

namespace CustomerDb.Models
{
    public class DataMapperProfile : Profile
    {
        public DataMapperProfile()
        {
            // Company Map
            CreateMap<CompanyRequest, Company>();
            CreateMap<Company, CompanyResponse>();

            // Contact Map
            CreateMap<ContactRequest, Company>();
            CreateMap<Company, ContactResponse>();
        }
    }
}
