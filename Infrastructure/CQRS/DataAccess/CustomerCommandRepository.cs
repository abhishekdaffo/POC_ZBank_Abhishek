using Domain.Entities;
using System.Transactions;
using Application.Abstractions.CommandsInterface;

namespace Infrastructure.CQRS.DataAccess
{
    /// <summary>
    /// Repository for Customer Command methods
    /// </summary>
    public sealed class CustomerCommandRepository : ICustomerCommandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerCommandRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        /// Insert customer data in DB
        /// </summary>
        /// <param name="customer"></param>
        public void Insert(Customer customer)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();
                scope.Complete();
            }
        }

        /// <summary>
        /// Update customers data in DB
        /// </summary>
        /// <param name="customer"></param>
        public void Update(Customer customer)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var existing = _dbContext.Customers.SingleOrDefault(b => b.Id == customer.Id);
                if (existing != null)
                {
                    _dbContext.Entry(customer).CurrentValues.SetValues(existing);
                    _dbContext.SaveChanges();
                }
                scope.Complete();
            }
        }
    }
}
