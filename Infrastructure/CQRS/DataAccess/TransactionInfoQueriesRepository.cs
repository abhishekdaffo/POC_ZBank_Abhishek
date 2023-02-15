using Application.Abstractions.QueriesInterface;
using Domain.Entities;
using Domain.Exceptions;

namespace Infrastructure.CQRS.DataAccess
{
    /// <summary>
    /// Repository for TransactionInfo Queries methods
    /// </summary>
    public sealed class TransactionInfoQueriesRepository : ITransactionInfoQueriesRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TransactionInfoQueriesRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        /// <summary>
        /// Gets Transaction Information by Id
        /// </summary>
        /// <param name="transactionInfoId"></param>
        /// <returns></returns>
        /// <exception cref="TransactionInfoNotFoundException"></exception>
        public TransactionInfo GetById(Guid transactionInfoId)
        {
            var transactionInfo = _dbContext.TransactionInfos.FirstOrDefault(x => x.Id == transactionInfoId);
            if (transactionInfo == null) throw new TransactionInfoNotFoundException(transactionInfoId);

            return transactionInfo;
        }

        /// <summary>
        /// Gets Transaction information based on reference
        /// </summary>
        /// <param name="transactionReference"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public TransactionInfo GetByReferenceId(string transactionReference)
        {
            var transactionInfo = _dbContext.TransactionInfos.FirstOrDefault(x => x.TransactionReference == transactionReference);
            if (transactionInfo == null) throw new Exception();

            return transactionInfo;
        }

        /// <summary>
        /// Gets all transaction information
        /// </summary>
        /// <returns></returns>
        public List<TransactionInfo> GetAll()
        {
            return _dbContext.TransactionInfos.ToList();
        }

        /// <summary>
        /// Gets list of all transactions against account
        /// </summary>
        /// <param name="acountId"></param>
        /// <returns></returns>
        public List<TransactionInfo> GetAllForAccount(Guid acountId)
        {
            return _dbContext.TransactionInfos.Where(x => x.AccountId == acountId).ToList();
        }
    }
}
