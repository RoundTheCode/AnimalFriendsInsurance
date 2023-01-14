using AnimalFriendsInsurance.Business.Customers.Models;

namespace AnimalFriendsInsurance.Business.Customers.Services
{
    /// <summary>
    /// Stores business logic for the customer
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Creates a new customer record
        /// </summary>
        /// <param name="model">Information supplied by the customer</param>
        /// <returns>Stores information when a customer is successfully registered</returns>
        Task<CustomerSuccessResult> InsertAsync(CustomerCreateModel model);
    }
}
