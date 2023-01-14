using AnimalFriendsInsurance.Business.Models.Customer;
using Microsoft.AspNetCore.Mvc;

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
        /// Create a customer
        /// </summary>
        /// <param name="model">The model containing customer data</param>
        /// <returns>A type of <see cref="IActionResult"/></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CustomerWithCreateModel model)
        {
            


            return Ok();
        }
    }
}
