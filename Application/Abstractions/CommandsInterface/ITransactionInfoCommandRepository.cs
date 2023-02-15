using Domain.Entities;

namespace Application.Abstractions.CommandsInterface
{
    /// <summary>
    /// Interface for TransactionInfoCommandRepository
    /// </summary>
    public interface ITransactionInfoCommandRepository
    {
        void Insert(TransactionInfo transactionInfo);
        void Update(TransactionInfo transactionInfo);
    }
}
