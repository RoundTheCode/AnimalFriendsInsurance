using AnimalFriendsInsurance.Business.Customers.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AnimalFriendsInsurance.UnitTest
{
    public class CustomerCreateValidation
    {
        /// <summary>
        /// Customer first name empty
        /// </summary>
        [Fact]
        public void FirstName_Empty_ReturnsError()
        {
            var customerCreateModel = new CustomerCreateModel();

            var validationResult = ValidateModel(customerCreateModel);

            Assert.Contains(validationResult, s => s.ErrorMessage == CustomerCreateModel.CUSTOMER_FIRST_NAME_REQUIRED);
        }

        /// <summary>
        /// Customer less than min length
        /// </summary>
        [Fact]
        public void FirstName_LessThanMinLength_ReturnsError()
        {
            var customerCreateModel = new CustomerCreateModel
            {
                FirstName = "aa"
            };

            var validationResult = ValidateModel(customerCreateModel);

            Assert.Contains(validationResult, s => s.ErrorMessage == CustomerCreateModel.CUSTOMER_FIRST_NAME_MIN_LENGTH);
        }

        /// <summary>
        /// Customer first name, max length
        /// </summary>
        [Fact]
        public void FirstName_MoreThanMaxLength_ReturnsError()
        {
            var customerCreateModel = new CustomerCreateModel
            {
                FirstName = "Lorem ipsum dolor sit amet, consectetur turpis duis."
            };

            var validationResult = ValidateModel(customerCreateModel);

            Assert.Contains(validationResult, s => s.ErrorMessage == CustomerCreateModel.CUSTOMER_FIRST_NAME_MAX_LENGTH);
        }

        /// <summary>
        /// Customer first name empty
        /// </summary>
        [Fact]
        public void Surname_Empty_ReturnsError()
        {
            var customerCreateModel = new CustomerCreateModel();

            var validationResult = ValidateModel(customerCreateModel);

            Assert.Contains(validationResult, s => s.ErrorMessage == CustomerCreateModel.CUSTOMER_SURNAME_REQUIRED);
        }

        /// <summary>
        /// Customer less than min length
        /// </summary>
        [Fact]
        public void Surname_LessThanMinLength_ReturnsError()
        {
            var customerCreateModel = new CustomerCreateModel
            {
                Surname = "aa"
            };

            var validationResult = ValidateModel(customerCreateModel);

            Assert.Contains(validationResult, s => s.ErrorMessage == CustomerCreateModel.CUSTOMER_SURNAME_MIN_LENGTH);
        }

        /// <summary>
        /// Customer surname, max length
        /// </summary>
        [Fact]
        public void Surname_MoreThanMaxLength_ReturnsError()
        {
            var customerCreateModel = new CustomerCreateModel
            {
                Surname = "Lorem ipsum dolor sit amet, consectetur turpis duis."
            };

            var validationResult = ValidateModel(customerCreateModel);

            Assert.Contains(validationResult, s => s.ErrorMessage == CustomerCreateModel.CUSTOMER_SURNAME_MAX_LENGTH);
        }

        /// <summary>
        /// Test error message when policy reference number is empty.
        /// </summary>
        [Fact]
        public void PolicyReferenceNumber_Empty_ReturnsError()
        {
            var customerCreateModel = new CustomerCreateModel();
            var validationResult = ValidateModel(customerCreateModel);

            Assert.Contains(validationResult, s => s.ErrorMessage == CustomerCreateModel.CUSTOMER_POLICY_REFERENCE_REQUIRED);
        }

        /// <summary>
        /// Test error message when policy reference number is in the wrong format
        /// </summary>
        /// <param name="policyReferenceNumber">Policy reference number</param>
        [Theory]
        [InlineData("a-129121")]
        [InlineData("as-129121")]
        [InlineData("a2-343343")]
        [InlineData("aC-34334C")]
        public void PolicyReferenceNumber_WrongFormat_ReturnsError(string policyReferenceNumber)
        {
            var customerCreateModel = new CustomerCreateModel
            {
                PolicyReferenceNumber = policyReferenceNumber
            };
            var validationResult = ValidateModel(customerCreateModel);

            Assert.Contains(validationResult, s => s.ErrorMessage == CustomerCreateModel.CUSTOMER_POLICY_REFERENCE_FORMAT);
        }
       
        /// <summary>
        /// Tests to ensure that error message for policy reference number is in the correct format
        /// </summary>
        [Fact]
        public void PolicyReferenceNumber_RightFormat_ReturnsNoError()
        {
            var customerCreateModel = new CustomerCreateModel
            {
                PolicyReferenceNumber = "AS-328242"
            };
            var validationResult = ValidateModel(customerCreateModel);

            Assert.DoesNotContain(validationResult, s => s.ErrorMessage == CustomerCreateModel.CUSTOMER_POLICY_REFERENCE_FORMAT);
        }

        private IList<ValidationResult> ValidateModel<TModel>(TModel model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}