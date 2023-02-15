using Application.Abstractions.CommandsInterface;
using Domain.Entities;
using System.Transactions;

namespace Infrastructure.CQRS.DataAccess
{

    /// <summary>
    /// Repository for TransactionInfo Command methods
    /// </summary>
    public sealed class TransactionInfoCommandRepository : ITransactionInfoCommandRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionInfoCommandRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        /// Inserts Transaction info in DB
        /// </summary>
        /// <param name="transactionInfo"></param>
        public void Insert(TransactionInfo transactionInfo)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                _dbContext.TransactionInfos.Add(transactionInfo);
                _dbContext.SaveChanges();
                scope.Complete();
            }
        }

        /// <summary>
        /// Updates transaction Information in DB
        /// </summary>
        /// <param name="transactionInfo"></param>
        public void Update(TransactionInfo transactionInfo)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                var existing = _dbContext.TransactionInfos.SingleOrDefault(b => b.Id == transactionInfo.Id);
                if (existing != null)
                {
                    _dbContext.Entry(transactionInfo).CurrentValues.SetValues(existing);
                    _dbContext.SaveChanges();
                }
                scope.Complete();
            }
        }
    }
}
