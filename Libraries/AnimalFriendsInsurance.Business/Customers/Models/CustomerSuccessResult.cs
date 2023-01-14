using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFriendsInsurance.Business.Customers.Models
{
    /// <summary>
    /// Stores information when a customer is successfully registered
    /// </summary>
    public class CustomerSuccessResult
    {
        /// <summary>
        /// The unique customer id once a registration has been successfully validated.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Creates a new instance of <see cref="CustomerSuccessResult"/>
        /// </summary>
        /// <param name="id">The unique customer id once a registration has been successfully validated.</param>
        public CustomerSuccessResult(int id)
        {
            Id = id;
        }
    }
}
