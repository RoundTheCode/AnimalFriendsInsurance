using AnimalFriendsInsurance.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalFriendsInsurance.Data
{
    /// <summary>
    /// The Animal Friends Insurance Data Contenxt
    /// </summary>
    public class AnimalFriendsInsuranceDataContext : DbContext
    {
        /// <summary>
        /// Data set for the customers.
        /// </summary>
        public virtual DbSet<CustomerEntity> Customers { get; set; }

        /// <summary>
        /// Creates a new instance of <see cref="AnimalFriendsInsuranceDataContext"/>
        /// </summary>
        public AnimalFriendsInsuranceDataContext() : base()
        {

        }

        /// <summary>
        /// Creates a new instance of <see cref="AnimalFriendsInsuranceDataContext"/>
        /// </summary>
        /// <param name="options">Supplies options for the data context</param>
        public AnimalFriendsInsuranceDataContext(DbContextOptions<AnimalFriendsInsuranceDataContext> options) : base(options)
        {

        }

        /// <summary>
        /// Overrides when the model is created
        /// </summary>
        /// <param name="builder">An instance of <see cref="ModelBuilder"/></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            CustomerEntity.OnModelCreating(builder.Entity<CustomerEntity>());
            CustomerDateOfBirthEntity.OnModelCreating(builder.Entity<CustomerDateOfBirthEntity>());
            CustomerEmailEntity.OnModelCreating(builder.Entity<CustomerEmailEntity>());
        }
    }
}
