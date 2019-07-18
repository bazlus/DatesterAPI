﻿namespace Datester.Services.AutoMapper
{
    using Data.Models;
    using DatesterAPI.InputModels;
    using global::AutoMapper;

    public class ApplicationMappingsProfile : Profile
    {
        public ApplicationMappingsProfile()
        {
            CreateMap<UserRegistrationInputModel, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(source => GetUsername(source.Email)))
                .ForMember(dest => dest.Hobbies, opt => opt.MapFrom(source => string.Join(", ", source.Hobbies)));
        }

        private string GetUsername(string email)
        {
            return email.Replace("@", ".").Replace(".", "-");
        }
    }
}