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
    internal class CustomerSuccessResultConverter : ITypeConverter<CustomerEntity, CustomerSuccessResult?>
    {
        /// <summary>
        /// Converts <see cref="CustomerEntity"/> to <see cref="CustomerSuccessResult"/>
        /// </summary>
        /// <param name="source">An instance of <see cref="CustomerEntity"/></param>
        /// <param name="destination">An instance of <see cref="CustomerSuccessResult"/></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public CustomerSuccessResult? Convert(CustomerEntity source, CustomerSuccessResult? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            // Creates the new customer success result.
            destination = destination ?? new CustomerSuccessResult(source.Id);

            return destination;
        }
    }
}
