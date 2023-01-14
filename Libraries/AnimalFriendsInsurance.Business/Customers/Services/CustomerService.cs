using AnimalFriendsInsurance.Business.Customers.Models;

namespace AnimalFriendsInsurance.Business.Customers.Services
{
    /// <summary>
    /// Stores business logic for the customer
    /// </summary>
    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// Creates a new customer record
        /// </summary>
        /// <param name="model">Information supplied by the customer</param>
        /// <returns>Stores information when a customer is successfully registered</returns>
        public async Task<CustomerSuccessResult> InsertAsync(CustomerWithCreateModel model)
        {
            throw new NotImplementedException();
        }
    }
}
