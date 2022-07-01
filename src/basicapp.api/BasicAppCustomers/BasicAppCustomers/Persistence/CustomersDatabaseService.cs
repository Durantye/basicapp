using System.Collections.Generic;
using System.Linq;
using BasicAppCustomers.Application;

namespace BasicAppCustomers
{
    public class CustomersDatabaseService
    {
        private readonly CustomersDbContext _dbContext;

        public CustomersDatabaseService(CustomersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CustomerViewModel> GetAllCustomers()
        {
            return _dbContext.Customers.Select(x => new CustomerViewModel(x.Name, x.Email, x.Phone));
        }

        public void BuildDatabase()
        {
            RebuildDatabase();
            
            // create data:
            var data = new List<Customer>()
            {
                new Customer("Oliver", "oliver.james@gmail.com", "(555) 123-4422"),
                new Customer("Benjamin", "benjamin.lee@gmail.com", "(555) 442-3221"),
                new Customer("Henry", "henry.thomas@gmail.com", "(555) 419-9532")
            };

            _dbContext.Customers.AddRange(data);
            _dbContext.SaveChanges();
        }

        private void RebuildDatabase()
        {
            // create database
            var created = _dbContext.Database.EnsureCreated();
            if (created) return;
            
            // delete and re-create
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }
    }
}