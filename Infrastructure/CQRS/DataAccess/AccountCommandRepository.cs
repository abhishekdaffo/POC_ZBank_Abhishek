using Application.Abstractions.CommandsInterface;
using Domain.Entities;
using System.Transactions;

namespace Infrastructure.CQRS.DataAccess
{
    /// <summary>
    /// Repository for Account Command methods
    /// </summary>
    public sealed class AccountCommandRepository : IAccountCommandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountCommandRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        /// Insert Account in DB
        /// </summary>
        /// <param name="account"></param>
        public void Insert(Account account)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                _dbContext.Accounts.Add(account);
                _dbContext.SaveChanges();
                scope.Complete();
            }
        }

        /// <summary>
        /// Update account in DB
        /// </summary>
        /// <param name="account"></param>
        public void Update(Account account)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var existing = _dbContext.Accounts.SingleOrDefault(b => b.Id == account.Id);
                if (existing != null)
                {
                    _dbContext.Entry(account).CurrentValues.SetValues(existing);
                    _dbContext.SaveChanges();
                }
                scope.Complete();
            }
        }
    }
}
