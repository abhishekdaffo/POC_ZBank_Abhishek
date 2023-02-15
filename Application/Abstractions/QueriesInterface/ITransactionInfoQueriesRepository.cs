using Domain.Entities;

namespace Application.Abstractions.QueriesInterface
{
    /// <summary>
    /// Interface for TransactionInfoQueriesRepository
    /// </summary>
    public interface ITransactionInfoQueriesRepository
    {
        TransactionInfo GetById(Guid transactionInfoId);
        TransactionInfo GetByReferenceId(string transactionReference);
        List<TransactionInfo> GetAll();
        List<TransactionInfo> GetAllForAccount(Guid acountId);
    }
}
