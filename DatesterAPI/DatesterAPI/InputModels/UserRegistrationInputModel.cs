namespace DatesterAPI.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Datester.Data.Models;
    using Datester.Services.Validation_Attributes;

    public class UserRegistrationInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Description { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MinLength(6)]
        public string Password { get; set; }

        [PasswordMatch]
        public string ConfirmPassword { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public string[] Hobbies { get; set; }
    }
}
