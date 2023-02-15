using Domain.Entities;
using MediatR;

namespace Infrastructure.CQRS.Command
{
    /// <summary>
    /// Record for Create TransactionInfo Command
    /// </summary>
    /// <param name="transactionInfo"></param>
    public record CreateTransactionInfoCommand(TransactionInfo transactionInfo) : IRequest;
}
