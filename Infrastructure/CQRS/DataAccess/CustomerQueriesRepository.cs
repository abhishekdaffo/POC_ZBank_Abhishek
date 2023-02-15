using Application.Abstractions.QueriesInterface;
using Domain.Entities;
using Domain.Exceptions;

namespace Infrastructure.CQRS.DataAccess
{
    /// <summary>
    /// Repository for Customer Queries methods
    /// </summary>
    public sealed class CustomerQueriesRepository : ICustomerQueriesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerQueriesRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        /// Get Customer data by Id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        /// <exception cref="AccountNotFoundException"></exception>
        public Customer GetById(Guid customerId)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Id == customerId);
            if (customer == null) throw new AccountNotFoundException(customerId);

            return customer;
        }

        /// <summary>
        /// Gets all customers data
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAll()
        {
            return _dbContext.Customers.ToList();
        }

        /// <summary>
        /// Gets count of customers created Today
        /// </summary>
        /// <returns></returns>
        public int GetCustomersCreatedToday()
        {
            return _dbContext.Customers.Count(x => x.MemberSince > DateTime.Today);
        }
    }
}
