using AnimalFriendsInsurance.Business.Customers.Mapping;
using AnimalFriendsInsurance.Business.Customers.Models;
using AnimalFriendsInsurance.Business.Customers.Services;
using AnimalFriendsInsurance.Data;
using AnimalFriendsInsurance.Data.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFriendsInsurance.UnitTest
{
    public class CustomerServiceTests
    {
        private readonly ICustomerService _customerService;

        public CustomerServiceTests()
        {
            // Use inmemory DbContext
            var optionsBuilder = new DbContextOptionsBuilder<AnimalFriendsInsuranceDataContext>();
            optionsBuilder.UseInMemoryDatabase("AnimalFriendsInsuranceDataContext-" + Guid.NewGuid());

            var animalFriendsInsuranceDataContext = new AnimalFriendsInsuranceDataContext(optionsBuilder.Options);

            var mapper = new Mapper(new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(new CustomerMappingProfile());
                }
             ));

            _customerService = new CustomerService(animalFriendsInsuranceDataContext, mapper);
        }

        /// <summary>
        /// Create a customer with email returns success
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Customer_WithEmail_ReturnsCustomerSuccess()
        {
            var customerWithEmail = await _customerService.InsertAsync(new Business.Customers.Models.CustomerCreateModel
            {
                FirstName = "Dan",
                Surname = "Man",
                PolicyReferenceNumber = "ABC-121211",                
                Email = "AASAS@AS.COM"  
            });

            Assert.IsType<CustomerSuccessResult>(customerWithEmail);
            Assert.Equal(1, customerWithEmail.Id);
        }

        /// <summary>
        /// Create a customer with date of birth returns success
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Customer_WithDateOfBirth_ReturnsCustomerSuccess()
        {
            var customerWithEmail = await _customerService.InsertAsync(new Business.Customers.Models.CustomerCreateModel
            {
                FirstName = "Dan",
                Surname = "Man",
                PolicyReferenceNumber = "ABC-121211",
                DateOfBirth = new DateTime(1980, 1, 1)
            });

            Assert.IsType<CustomerSuccessResult>(customerWithEmail);
            Assert.Equal(1, customerWithEmail.Id);
        }

        /// <summary>
        /// Create a customer with date of birth returns success
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Customer_TwoSubmitsWithDateOfBirth_ReturnsUniqueCustomerIds()
        {
            var customerWithEmail = await _customerService.InsertAsync(new Business.Customers.Models.CustomerCreateModel
            {
                FirstName = "Dan",
                Surname = "Man",
                PolicyReferenceNumber = "ABC-121211",
                DateOfBirth = new DateTime(1980, 1, 1)
            });
            customerWithEmail = await _customerService.InsertAsync(new Business.Customers.Models.CustomerCreateModel
            {
                FirstName = "Dan",
                Surname = "Man",
                PolicyReferenceNumber = "ABC-121211",
                DateOfBirth = new DateTime(1980, 1, 1)
            });

            Assert.IsType<CustomerSuccessResult>(customerWithEmail);
            Assert.Equal(2, customerWithEmail.Id);
        }

        /// <summary>
        /// Creates a customer without a date of birth or email.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Customer_NoDobOrEmail_ThrowsNotImplementedException()
        {
            Assert.ThrowsAsync<NotImplementedException>(async() => await _customerService.InsertAsync(new CustomerCreateModel
            {
                FirstName = "Dan",
                Surname = "Man",
                PolicyReferenceNumber = "ABC-121211"
            }));
        }
    }
}
