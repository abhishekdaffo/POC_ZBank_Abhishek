using MediatR;

namespace Infrastructure.CQRS.Queries
{
    /// <summary>
    /// Record for GetCustomerBalance
    /// </summary>
    /// <param name="customerId"></param>
    public record GetCustomerBalanceQuery(Guid customerId) : IRequest<decimal>;
}
