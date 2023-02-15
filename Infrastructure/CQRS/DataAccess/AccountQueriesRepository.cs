using Application.Abstractions.QueriesInterface;
using Domain.Entities;
using Domain.Exceptions;

namespace Infrastructure.CQRS.DataAccess
{
    /// <summary>
    /// Repository for Account Queries methods
    /// </summary>
    public sealed class AccountQueriesRepository : IAccountQueriesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountQueriesRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        /// Gets account based on Id
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        /// <exception cref="AccountNotFoundException"></exception>
        public Account GetById(Guid accountId)
        {
            var account = _dbContext.Accounts.FirstOrDefault(x => x.Id == accountId);
            if (account == null) throw new AccountNotFoundException(accountId);

            return account;
        }

        /// <summary>
        /// Gets Account based on userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Account GetByUserId(Guid userId)
        {
            var account = _dbContext.Accounts.FirstOrDefault(x => x.UserId == userId);
            if (account == null) throw new Exception();

            return account;
        }
        /// <summary>
        /// Gets list of all accounts
        /// </summary>
        /// <returns></returns>
        public List<Account> GetAll()
        {
            return _dbContext.Accounts.ToList();
        }

        /// <summary>
        /// Gets users account balance
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public decimal GetAccountBalance(Guid userId)
        {
            return GetByUserId(userId).AccountBalance;
        }
    }
}
