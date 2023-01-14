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
    /// Converts a customer create model to entity (for email).
    /// </summary>
    internal class CustomerCreateEmailConverter : ITypeConverter<CustomerCreateModel, CustomerEmailEntity?>
    {
        /// <summary>
        /// Converts <see cref="CustomerCreateModel"/> to <see cref="CustomerEmailEntity"/>
        /// </summary>
        /// <param name="source">>An instance of <see cref="CustomerCreateModel"/></param>
        /// <param name="destination">>An instance of <see cref="CustomerEmailEntity"/></param>
        /// <param name="context"></param>
        /// <returns>An instance of <see cref="CustomerEmailEntity"/></returns>
        public CustomerEmailEntity? Convert(CustomerCreateModel source, CustomerEmailEntity? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            // Create new entity
            destination = destination ?? new CustomerEmailEntity {
                FirstName = source.FirstName,
                Surname = source.Surname,                
                PolicyReferenceNumber = source.PolicyReferenceNumber,
                Email = source.Email
            };

            return destination;
        }
    }
}
