using AnimalFriendsInsurance.Business.Customers.Models;
using AnimalFriendsInsurance.Data;
using AnimalFriendsInsurance.Data.Entities;
using AutoMapper;

namespace AnimalFriendsInsurance.Business.Customers.Services
{
    /// <summary>
    /// Stores business logic for the customer
    /// </summary>
    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// An instance of <see cref="AnimalFriendsInsuranceDataContext"/>
        /// </summary>
        private readonly AnimalFriendsInsuranceDataContext _dbContext;

        /// <summary>
        /// An instance of <see cref="IMapper"/>
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a new instance of <see cref="CustomerService"/>
        /// </summary>
        /// <param name="dbContext">An instance of <see cref="AnimalFriendsInsuranceDataContext"/></param>
        /// <param name="mapper">An instance of <see cref="IMapper"/></param>
        public CustomerService(AnimalFriendsInsuranceDataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new customer record
        /// </summary>
        /// <param name="model">Information supplied by the customer</param>
        /// <returns>Stores information when a customer is successfully registered</returns>
        public async Task<CustomerSuccessResult> InsertAsync(CustomerCreateModel model)
        {
            if (model.CustomerTypeEntity == null)
            {
                // Throw exception if we cannot find the customer type entity
                throw new NullReferenceException("Unable to find what customer entity to convert to");
            }

            var customer = _mapper.Map(model, typeof(CustomerCreateModel), model.CustomerTypeEntity);
            await _dbContext.AddAsync(customer);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<CustomerSuccessResult>(customer);
        }
    }
}
