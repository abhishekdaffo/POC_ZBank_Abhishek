using Domain.Entities;
using MediatR;

namespace Infrastructure.CQRS.Command
{
    /// <summary>
    /// Record for Customer Account Command
    /// </summary>
    /// <param name="account"></param>
    public record CreateCustomerAccountCommand(Account account) : IRequest;
}
