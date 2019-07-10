using System;
using System.Collections.Generic;
using System.Text;

namespace Datester.Services.Validation_Attributes
{
    using System.ComponentModel.DataAnnotations;
    using DatesterAPI.InputModels;

    public class PasswordMatchAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var instance = (UserRegistrationInputModel)validationContext.ObjectInstance;

            if (instance.Password != instance.ConfirmPassword)
            {
                return new ValidationResult("Passwords should match");
            }

            return ValidationResult.Success;
        }
    }
}