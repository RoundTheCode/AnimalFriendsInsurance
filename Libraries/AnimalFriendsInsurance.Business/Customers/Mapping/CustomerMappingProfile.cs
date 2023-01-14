using AnimalFriendsInsurance.Business.Customers.Mapping.Converters;
using AnimalFriendsInsurance.Business.Customers.Models;
using AnimalFriendsInsurance.Data.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFriendsInsurance.Business.Customers.Mapping
{
    /// <summary>
    /// Stores all the mapping profiles for the customer
    /// </summary>
    internal class CustomerMappingProfile : Profile
    {
         /// <summary>
         /// Creates a new instance of <see cref="CustomerMappingProfile"/>
         /// </summary>
        public CustomerMappingProfile()
        {
            CreateMap(typeof(CustomerCreateModel), typeof(CustomerEmailEntity)).ConvertUsing(typeof(CustomerCreateEmailConverter));
            CreateMap(typeof(CustomerCreateModel), typeof(CustomerDateOfBirthEntity)).ConvertUsing(typeof(CustomerCreateDateOfBirthConverter));
            CreateMap(typeof(CustomerEntity), typeof(CustomerSuccessResult)).ConvertUsing(typeof(CustomerSuccessResultConverter));
        }
    }
}
