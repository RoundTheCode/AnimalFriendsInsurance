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

        private IList<ValidationResult> ValidateModel<TModel>(TModel model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
    }
}