using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFriendsInsurance.Data.Entities
{
    /// <summary>
    /// Stores the customer's email
    /// </summary>
    public class CustomerEmailEntity : CustomerEntity
    {
        /// <summary>
        /// The customer email's address
        /// </summary>
        public string? Email { get; init; }

        /// <summary>
        /// Sets what happens when the model is created
        /// </summary>
        /// <param name="entity">A type of <see cref="EntityTypeBuilder<CustomerEmailEntity>"/></param>
        internal static void OnModelCreating(EntityTypeBuilder<CustomerEmailEntity> entity)
        {
            entity.HasKey(s => s.Id);
            entity.ToTable("CustomerEmail", "afi");
        }
    }
}
