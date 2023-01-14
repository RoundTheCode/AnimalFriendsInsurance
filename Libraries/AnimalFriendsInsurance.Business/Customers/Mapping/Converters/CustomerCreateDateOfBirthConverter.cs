using AnimalFriendsInsurance.Business.Customers.Models;
using AnimalFriendsInsurance.Data.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFriendsInsurance.Business.Customers.Mapping.Converters
{
    /// <summary>
    /// Converts a customer create model to entity (for date of birth).
    /// </summary>
    internal class CustomerCreateDateOfBirthConverter : ITypeConverter<CustomerCreateModel, CustomerDateOfBirthEntity?>
    {
        /// <summary>
        /// Converts <see cref="CustomerCreateModel"/> to <see cref="CustomerDateOfBirthEntity"/>
        /// </summary>
        /// <param name="source">>An instance of <see cref="CustomerCreateModel"/></param>
        /// <param name="destination">>An instance of <see cref="CustomerDateOfBirthEntity"/></param>
        /// <param name="context"></param>
        /// <returns>An instance of <see cref="CustomerDateOfBirthEntity"/></returns>
        public CustomerDateOfBirthEntity? Convert(CustomerCreateModel source, CustomerDateOfBirthEntity? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            // Create new entity
            destination = destination ?? new CustomerDateOfBirthEntity
            {
                FirstName = source.FirstName,
                Surname = source.Surname,                
                PolicyReferenceNumber = source.PolicyReferenceNumber,
                DateOfBirth = source.DateOfBirth
            };

            return destination;
        }
    }
}
