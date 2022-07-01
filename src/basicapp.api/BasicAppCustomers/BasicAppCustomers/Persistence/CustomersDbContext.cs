using BasicAppCustomers.Application;
using Microsoft.EntityFrameworkCore;

namespace BasicAppCustomers
{
    public class CustomersDbContext : DbContext
    {

        public DbSet<Customer> Customers { get; set; }

        public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasKey(x => x.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}