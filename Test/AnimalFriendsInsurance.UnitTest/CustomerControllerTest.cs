using AnimalFriendsInsurance.Business.Customers.Models;
using AnimalFriendsInsurance.Business.Customers.Services;
using AnimalFriendsInsurance.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFriendsInsurance.UnitTest
{
    public class CustomerControllerTest
    {
        /// <summary>
        /// A mock implemntation of <see cref="ICustomerService"/>
        /// </summary>
        private readonly CustomerController _customerController;

        public CustomerControllerTest()
        {
            // Create mock implementaton of customer service, and return a successful result.
            var customerServiceMockRepo = new Mock<ICustomerService>();
            customerServiceMockRepo
                .Setup(s => s.InsertAsync(It.IsAny<CustomerCreateModel>()))
                .ReturnsAsync(new CustomerSuccessResult(1));

            // New instance of controller
            _customerController = new CustomerController(customerServiceMockRepo.Object);
        }

        /// <summary>
        /// Customer empty data throws bad request
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Customer_EmptyData_ReturnsBadRequest()
        {
            var model = new CustomerCreateModel();
            MockModelState(model);

            var result = await _customerController.CreateAsync(model);

            Assert.True(result is BadRequestResult);
        }

        /// <summary>
        /// Customer incorrect data throws bad request
        /// </summary>
        /// <param name="firstName">First name of the customer</param>
        /// <param name="surname">Surname of the customer</param>
        /// <param name="policyReferenceNumber">Policy reference of a customer</param>
        /// <returns></returns>
        [Theory]
        [InlineData("aa", "", "isdsd0asd")]
        [InlineData("", "sds", "AA-323233")]
        [InlineData("ASS", "sds", "AA-3232")]
        [InlineData("ASS", "sds", "")]
        public async Task Customer_IncorrectData_ReturnsBadRequest(string firstName, string surname, string policyReferenceNumber)
        {
            var model = new CustomerCreateModel
            {
                FirstName = firstName,
                Surname = surname,
                PolicyReferenceNumber = policyReferenceNumber,
                DateOfBirth = new DateTime(1983, 1, 1)
            };
            MockModelState(model);

            var result = await _customerController.CreateAsync(model);

            Assert.True(result is BadRequestResult);
        }

        /// <summary>
        /// Customer correct data with date of birth returns OK
        /// </summary>
        /// <param name="firstName">First name of the customer</param>
        /// <param name="surname">Surname of the customer</param>
        /// <param name="policyReferenceNumber">Policy reference of a customer</param>>
        /// <returns></returns>
        [Theory]
        [InlineData("Dan", "Man", "AC-192121")]
        [InlineData("Dave", "Rave", "CD-492422")]
        [InlineData("Matt", "Smith", "XY-545477")]
        [InlineData("Rob", "Moore", "AA-545477")]
        public async Task Customer_CorrectDataWithDateOfBirth_ReturnsIdOf1(string firstName, string surname, string policyReferenceNumber)
        {
            var model = new CustomerCreateModel
            {
                FirstName = firstName,
                Surname = surname,
                PolicyReferenceNumber = policyReferenceNumber,
                DateOfBirth = new DateTime(1983, 1, 1)
            };
            MockModelState(model);

            var result = await _customerController.CreateAsync(model);
            Assert.True(result is OkObjectResult);

            var resultModel = (CustomerSuccessResult)((OkObjectResult)result).Value;
            Assert.Equal(1, resultModel.Id);
        }

        /// <summary>
        /// Customer correct data with date of birth returns OK
        /// </summary>
        /// <param name="firstName">First name of the customer</param>
        /// <param name="surname">Surname of the customer</param>
        /// <param name="policyReferenceNumber">Policy reference of a customer</param>>
        /// <returns></returns>
        [Theory]
        [InlineData("Dan", "Man", "AC-192121")]
        [InlineData("Dave", "Rave", "CD-492422")]
        [InlineData("Matt", "Smith", "XY-545477")]
        [InlineData("Rob", "Moore", "AA-545477")]
        public async Task Customer_CorrectDataWithEmail_ReturnsOk(string firstName, string surname, string policyReferenceNumber)
        {
            var model = new CustomerCreateModel
            {
                FirstName = firstName,
                Surname = surname,
                PolicyReferenceNumber = policyReferenceNumber,
                Email = "dave.rave@abc.com"
            };
            MockModelState(model);

            var result = await _customerController.CreateAsync(model);
            Assert.True(result is OkObjectResult);

            var resultModel = (CustomerSuccessResult)((OkObjectResult)result).Value;
            Assert.Equal(1, resultModel.Id);
        }

        private void MockModelState<TModel>(TModel model)
        {
            var validationContext = new ValidationContext(model, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                if (validationResult.MemberNames.FirstOrDefault() != null)
                {
                    _customerController.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
                }
            }
        }

    }
}
