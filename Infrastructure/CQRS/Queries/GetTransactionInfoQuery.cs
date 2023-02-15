using Domain.Entities;
using MediatR;

namespace Infrastructure.CQRS.Queries
{
    /// <summary>
    /// Record for GetTransactionInfo
    /// </summary>
    /// <param name="referenceId"></param>
    public record GetTransactionInfoQuery(string referenceId) : IRequest<TransactionInfo>;
}
