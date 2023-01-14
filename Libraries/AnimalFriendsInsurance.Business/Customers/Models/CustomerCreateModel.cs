﻿using AnimalFriendsInsurance.Business.Customers.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace AnimalFriendsInsurance.Business.Customers.Models
{
    /// <summary>
    /// API request containing customer data
    /// </summary>
    public class CustomerCreateModel
    {
        /// <summary>
        /// Customer first name
        /// </summary>
        [MinLength(3, ErrorMessage = "First name must be at least 3 characters"),
         MaxLength(50, ErrorMessage = "First name must be no more than 50 characters")]
        public string? FirstName { get; init; }

        /// <summary>
        /// Customer surname
        /// </summary>
        [MinLength(3, ErrorMessage = "Surname must be at least 3 characters"),
        MaxLength(50, ErrorMessage = "Surname must be no more than 50 characters")]
        public string? Surname { get; init; }

        /// <summary>
        /// Policy reference number
        /// </summary>
        [RegularExpression(@"^([A-Z]{2})\-([0-9]{6})$")]
        public string? PolicyReferenceNumber { get; init; }

        /// <summary>
        /// Customer's date of birth
        /// </summary>         
        [DataType(DataType.Date), CustomerDateOfBirthValidation, CustomerEitherDobOrEmailValidation]
        public DateTime? DateOfBirth { get; init; }

        /// <summary>
        /// Customer's email address
        /// </summary>
        [EmailAddress, CustomerEitherDobOrEmailValidation]
        public string? Email { get; init; }

    }
}