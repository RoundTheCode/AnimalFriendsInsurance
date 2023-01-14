
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AnimalFriendsInsurance.Data.Entities
{
    /// <summary>
    /// Stores data for the customer
    /// </summary>
    public abstract class CustomerEntity
    {
        /// <summary>
        /// The unique identifier for the customer
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Customer first name
        /// </summary>
        public string? FirstName { get; init; }

        /// <summary>
        /// Customer surname
        /// </summary>
        public string? Surname { get; init; }

        /// <summary>
        /// Policy reference number
        /// </summary>
        public string? PolicyReferenceNumber { get; init; }

        /// <summary>
        /// Sets what happens when the model is created
        /// </summary>
        /// <param name="entity">A type of <see cref="EntityTypeBuilder<CustomerEntity>"/></param>
        internal static void OnModelCreating(EntityTypeBuilder<CustomerEntity> entity)
        {
            entity.HasKey(s => s.Id);
            entity.ToTable("Customer", "afi");
        }
    }
}
