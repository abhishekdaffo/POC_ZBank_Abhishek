using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    /// <summary>
    /// Exception for TransactionInfo
    /// </summary>
    public sealed class TransactionInfoNotFoundException : NotFoundException
    {
        public TransactionInfoNotFoundException(Guid transactionInfo)
            : base($"The Transaction Information with the Id {transactionInfo} was not found.")
        {
        }
    }
}