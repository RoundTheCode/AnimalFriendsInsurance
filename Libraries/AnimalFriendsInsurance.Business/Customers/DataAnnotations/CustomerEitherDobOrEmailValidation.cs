using AnimalFriendsInsurance.Business.Customers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AnimalFriendsInsurance.Business.Customers.DataAnnotations
{
    /// <summary>
    /// Ensures that either the date of birth or email address is supplied
    /// </summary>
    internal class CustomerEitherDobOrEmailValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance == null)
            {
                // No object instance, so return error
                return new ValidationResult("Object instance cannot be found");
            }

            var customerCreateModel = (CustomerCreateModel)validationContext.ObjectInstance;

            if (!customerCreateModel.DateOfBirth.HasValue && string.IsNullOrWhiteSpace(customerCreateModel.Email))
            {
                // Neither the date of birth or email address has been supplied, so throw error.
                return new ValidationResult("Neither the customer's date of birth or email address has been supplied");
            }
            if (customerCreateModel.DateOfBirth.HasValue && !string.IsNullOrWhiteSpace(customerCreateModel.Email))
            {
                // Both the date of birth and email address has been supplied, so throw error.
                return new ValidationResult("Both the customer's date of birth and email address has been supplied");
            }

            return ValidationResult.Success;            
        }
    }
}
