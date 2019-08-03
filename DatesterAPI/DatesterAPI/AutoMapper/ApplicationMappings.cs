namespace Datester.Services.AutoMapper
{
    using System;
    using Data.Models;
    using DatesterAPI.InputModels;
    using DatesterAPI.ViewModels;
    using global::AutoMapper;

    public class ApplicationMappingsProfile : Profile
    {

        public ApplicationMappingsProfile()
        {
            CreateMap<UserRegistrationInputModel, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(source => source.Email))
                .ForMember(dest => dest.Hobbies, opt => opt.MapFrom(source => string.Join(", ", source.Hobbies)));

            CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => GetUserAge(src.BirthDate)));
        }

        private int GetUserAge(DateTime birthdate)
        {
            // Save today's date.
            var today = DateTime.Today;
            // Calculate the age.
            var age = today.Year - birthdate.Year;
            // Go back to the year the person was born in case of a leap year
            if (birthdate.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}