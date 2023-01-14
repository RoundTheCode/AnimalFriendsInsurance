using AnimalFriendsInsurance.Business.Customers.Models;
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
        private readonly IActionContextAccessor _actionContextAccessor;

        public CustomerController(IActionContextAccessor actionContextAccessor)
        {
            _actionContextAccessor = actionContextAccessor;
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

            return Ok();
        }
    }
}
