using AnimalFriendsInsurance.Business.Customers.Models;
using AnimalFriendsInsurance.Business.Customers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Net;

namespace AnimalFriendsInsurance.WebApi.Controllers
{
    /// <summary>
    /// Endpoints for the customer
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// Instance of <see cref="ICustomerService"/>
        /// </summary>
        private readonly ICustomerService _customerService;

        /// <summary>
        /// Creates a new instance of <see cref="CustomerController"/>
        /// </summary>
        /// <param name="customerService">Instance of <see cref="ICustomerService"/></param>
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Create a customer
        /// </summary>
        /// <param name="model">The model containing customer data</param>
        /// <returns>A type of <see cref="IActionResult"/></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CustomerCreateModel model)
        {
            // Validate against date of birth and email
            if (!model.DateOfBirth.HasValue && string.IsNullOrWhiteSpace(model.Email))
            {
                ModelState.AddModelError("DobOrEmail", "Neither the customer's date of birth, or email has been supplied");
            }
            // Validate against date of birth and email
            if (model.DateOfBirth.HasValue && !string.IsNullOrWhiteSpace(model.Email))
            {
                ModelState.AddModelError("DobOrEmail", "Both the customer's date of birth, or email has been supplied. Only one needs to be supplied");
            }

            // Return a 400 response if the model state is not valid.
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // Creates a new instance of the customer and returns a unique id.
            var customerSuccess = await _customerService.InsertAsync(model);

            return Ok(customerSuccess);
        }
    }
}
