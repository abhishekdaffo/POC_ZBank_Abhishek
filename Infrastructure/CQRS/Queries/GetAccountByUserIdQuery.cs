using Domain.Entities;
using MediatR;

namespace Infrastructure.CQRS.Queries
{
    /// <summary>
    /// Record for GetAccountByUserId
    /// </summary>
    /// <param name="userId"></param>
    public record GetAccountByUserIdQuery(Guid userId) : IRequest<Account>;
}
