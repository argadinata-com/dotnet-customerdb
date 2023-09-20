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
            CreateMap<ContactRequest, Contact>();

            CreateMap<Contact, ContactResponse>()
                .ForMember(dest => dest.company_name, options => options.MapFrom(src => src.company == null ? null : src.company.name))
                .ForMember(dest => dest.company_website, options => options.MapFrom(src => src.company == null ? null : src.company.website))
                .ForMember(dest => dest.company_email, options => options.MapFrom(src => src.company == null ? null : src.company.email))
                .ForMember(dest => dest.company_phone_no, options => options.MapFrom(src => src.company == null ? null : src.company.phone_no))
                .ForMember(dest => dest.company_address, options => options.MapFrom(src => src.company == null ? null : src.company.address));
        }
    }
}
