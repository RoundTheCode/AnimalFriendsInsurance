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
    /// Stores the customer's date of birth
    /// </summary>
    public class CustomerDateOfBirthEntity : CustomerEntity
    {
        /// <summary>
        /// The customer's date of birth
        /// </summary>
        public DateTime? DateOfBirth { get; init; }

        /// <summary>
        /// Sets what happens when the model is created
        /// </summary>
        /// <param name="entity">A type of <see cref="EntityTypeBuilder<CustomerDateOfBirthEntity>"/></param>
        internal static void OnModelCreating(EntityTypeBuilder<CustomerDateOfBirthEntity> entity)
        {
            entity.ToTable("CustomerDateOfBirth", "afi");
            entity.Property(s => s.DateOfBirth).HasColumnType("Date");
        }
    }
}
