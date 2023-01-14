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
    public class CustomerEitherDobOrEmailValidation : ValidationAttribute
    {
        public const string NO_DOB_EMAIL = "Neither the customer's date of birth or email address has been supplied";
        public const string BOTH_DOB_EMAIL = "Both the customer's date of birth and email address has been supplied";

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance == null)
            {
                // No object instance, so return error
                throw new NullReferenceException("validationContext.ObjectInstance does not have an instance");
            }

            var customerCreateModel = (CustomerCreateModel)validationContext.ObjectInstance;

            if (!customerCreateModel.DateOfBirth.HasValue && string.IsNullOrWhiteSpace(customerCreateModel.Email))
            {
                // Neither the date of birth or email address has been supplied, so throw error.
                return new ValidationResult(NO_DOB_EMAIL);
            }
            if (customerCreateModel.DateOfBirth.HasValue && !string.IsNullOrWhiteSpace(customerCreateModel.Email))
            {
                // Both the date of birth and email address has been supplied, so throw error.
                return new ValidationResult(BOTH_DOB_EMAIL);
            }

            return ValidationResult.Success;            
        }
    }
}
