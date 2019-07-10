namespace Datester.Services.AutoMapper
{
    using Data.Models;
    using DatesterAPI.InputModels;
    using global::AutoMapper;

    public class ApplicationMappingsProfile : Profile
    {
        public ApplicationMappingsProfile()
        {
            CreateMap<UserRegistrationInputModel, ApplicationUser>().ReverseMap();
        }
    }
}