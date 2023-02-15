using Domain.Entities;
using MediatR;

namespace Infrastructure.CQRS.Queries
{
    /// <summary>
    /// Record for GetAllTransactionsOfUser
    /// </summary>
    /// <param name="accountId"></param>
    public record GetAllTransactionsOfUserQuery(Guid accountId) : IRequest<List<TransactionInfo>>;
}
