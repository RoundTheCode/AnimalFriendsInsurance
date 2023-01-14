using AnimalFriendsInsurance.Business.Customers.DataAnnotations;
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

        /// <summary>
        /// Tests to ensure if an error message is supplied if neither the DOB or email is supplied
        /// </summary>
        [Fact]
        public void DobEmail_NeitherSupplied_ReturnsError()
        {
            var customerCreateModel = new CustomerCreateModel();
            var validationResult = ValidateModel(customerCreateModel);

            Assert.Contains(validationResult, s => s.ErrorMessage == CustomerEitherDobOrEmailValidation.NO_DOB_EMAIL);
        }

        /// <summary>
        /// Tests to ensure if an error message is supplied if neither the DOB or email is supplied
        /// </summary>
        [Fact]
        public void DobEmail_BothSupplied_ReturnsError()
        {
            var customerCreateModel = new CustomerCreateModel
            {
                DateOfBirth = new DateTime(1980, 1, 1),
                Email = "asasas@asas.com"
            };
            var validationResult = ValidateModel(customerCreateModel);

            Assert.Contains(validationResult, s => s.ErrorMessage == CustomerEitherDobOrEmailValidation.BOTH_DOB_EMAIL);
        }

        /// <summary>
        /// Tests to ensure that someone who is exactly 3 years old cannot register a policy
        /// </summary>
        [Theory]
        [InlineData(-3)]
        [InlineData(-10)]
        [InlineData(-17)]
        public void Dob_Under18Years_ReturnsError(int yearsOld)
        {
            var customerCreateModel = new CustomerCreateModel
            {
                DateOfBirth = DateTime.Now.Date.AddYears(yearsOld)
            };
            var validationResult = ValidateModel(customerCreateModel);

            Assert.Contains(validationResult, s => s.ErrorMessage == CustomerDateOfBirthValidation.MINIMUM_DATE_OF_BIRTH);
        }

        /// <summary>
        /// Tests to ensure that someone who is one day away from 18th birthday
        /// </summary>
        [Fact]
        public void Dob_1DayAwayFrom18_ReturnsError()
        {
            var customerCreateModel = new CustomerCreateModel
            {
                DateOfBirth = DateTime.Now.Date.AddYears(-18).AddDays(1)
            };
            var validationResult = ValidateModel(customerCreateModel);

            Assert.Contains(validationResult, s => s.ErrorMessage == CustomerDateOfBirthValidation.MINIMUM_DATE_OF_BIRTH);
        }

        /// <summary>
        /// Tests to ensure that someone who is over 18 will not see an error message
        /// </summary>
        [Theory]
        [InlineData(-18)]
        [InlineData(-23)]
        [InlineData(-30)]
        [InlineData(-50)]
        [InlineData(-70)]
        public void Dob_Over18_ReturnsNoError(int yearsOld)
        {
            var customerCreateModel = new CustomerCreateModel
            {
                DateOfBirth = DateTime.Now.Date.AddYears(yearsOld)
            };
            var validationResult = ValidateModel(customerCreateModel);

            Assert.DoesNotContain(validationResult, s => s.ErrorMessage == CustomerDateOfBirthValidation.MINIMUM_DATE_OF_BIRTH);
        }

        /// <summary>
        /// Tests that email address in the wrong format throws error
        /// </summary>
        /// <param name="email">The email address</param>
        [Theory]
        [InlineData("asas")]
        [InlineData("asas@")]
        [InlineData("cd33!!@")]
        public void Email_WrongFormat_ReturnsError(string email)
        {
            var customerCreateModel = new CustomerCreateModel
            {
                Email = email
            };
            
            var validationResult = ValidateModel(customerCreateModel);

            Assert.Contains(validationResult, s => s.ErrorMessage == CustomerCreateModel.EMAIL_ADDRESS_FORMAT);
        }

        /// <summary>
        /// Tests that email address in the right format does not throw an error
        /// </summary>
        /// <param name="email">The email address</param>
        [Theory]
        [InlineData("asas@asas.com")]
        [InlineData("asas@abc.com")]
        [InlineData("cd33@sdsd.com")]
        public void Email_CorrectFormat_ReturnsNoError(string email)
        {
            var customerCreateModel = new CustomerCreateModel
            {
                Email = email
            };

            var validationResult = ValidateModel(customerCreateModel);

            Assert.DoesNotContain(validationResult, s => s.ErrorMessage == CustomerCreateModel.EMAIL_ADDRESS_FORMAT);
        }

        /// <summary>
        /// Email does not end in .co.uk, or .com throws an error
        /// </summary>
        /// <param name="email">The email address</param>
        [Theory]
        [InlineData("asas@asas.abc")]
        [InlineData("asas@abc.def")]
        [InlineData("cd33@sdsd.fgf")]
        [InlineData("cd33@sdsd.com ")]
        public void Email_DoesNotEndInComCoUk_ReturnsError(string email)
        {
            var customerCreateModel = new CustomerCreateModel
            {
                Email = email
            };

            var validationResult = ValidateModel(customerCreateModel);

            Assert.Contains(validationResult, s => s.ErrorMessage == CustomerCreateModel.EMAIL_ADDRESS_END);
        }

        /// <summary>
        /// Email ends in .co.uk, or .com does not throw an error
        /// </summary>
        /// <param name="email">The email address</param>
        [Theory]
        [InlineData("asas@asas.co.uk")]
        [InlineData("asas@abc.com")]
        [InlineData("cd33@sdsd.com")]
        public void Email_EndsInComCoUk_ReturnsNoError(string email)
        {
            var customerCreateModel = new CustomerCreateModel
            {
                Email = email
            };

            var validationResult = ValidateModel(customerCreateModel);

            Assert.DoesNotContain(validationResult, s => s.ErrorMessage == CustomerCreateModel.EMAIL_ADDRESS_END);
        }

        /// <summary>
        /// Valid data (with email) throws no errors
        /// </summary>
        [Fact]
        public void Customer_ValidDataWithEmail_ReturnsNoErrors()
        {
            var customerCreateModel = new CustomerCreateModel
            {
                FirstName = "Dan",
                Surname = "Man",
                PolicyReferenceNumber = "AB-123111",
                Email = "abc@def.com"
            };

            var validationResult = ValidateModel(customerCreateModel);

            Assert.False(validationResult.Any());
        }

        /// <summary>
        /// Valid data (with email) throws no errors
        /// </summary>
        [Fact]
        public void Customer_ValidDataWithDob_ReturnsNoErrors()
        {
            var customerCreateModel = new CustomerCreateModel
            {
                FirstName = "Dan",
                Surname = "Man",
                PolicyReferenceNumber = "AB-123111",
                DateOfBirth = new DateTime(1985, 1, 1)
            };

            var validationResult = ValidateModel(customerCreateModel);

            Assert.False(validationResult.Any());
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