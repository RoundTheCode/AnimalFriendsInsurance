using System.ComponentModel.DataAnnotations;

namespace AnimalFriendsInsurance.Business.Models.DataAnnotations
{
    /// <summary>
    /// Validates 
    /// </summary>
    internal class CustomerDateOfBirthValidation : ValidationAttribute
    {
        /// <summary>
        /// Minimum age of the policy.
        /// </summary>
        private int minAge = 18;

        /// <summary>
        /// Whether the date of birth is valid.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object? value)
        {
            var valueString = (value != null ? value.ToString() : null);

            if (string.IsNullOrWhiteSpace(valueString))
            {
                // No value, so return true.
                return true;
            }

            // Convert to date time.
            if (!DateTime.TryParse(valueString, out DateTime dob))
            {
                // Not a valid date, so return false.
                return false;
            }

            // Minimum date of birth
            var minDateOfBirth = DateTime.Now.Date.AddYears(minAge * -1);

            if (dob > minDateOfBirth)
            {
                // Under minimum date of birth, so return false.
                return false;
            }

            // Return true
            return true;
        }
    }
}
