using AutoMapper;

namespace CustomerDb.Models
{
    public class DataMapperProfile : Profile
    {
        public DataMapperProfile()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new LowerUnderscoreNamingConvention();

            // Company Map
            CreateMap<CompanyRequest, Company>();
            CreateMap<Company, CompanyResponse>();

            // Contact Map
            CreateMap<ContactRequest, Contact>();
            CreateMap<Contact, ContactResponse>();
        }
    }
}
