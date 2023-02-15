using Domain.Entities;
using MediatR;

namespace Infrastructure.CQRS.Command
{
    /// <summary>
    /// Record for Update Account Command
    /// </summary>
    /// <param name="account"></param>
    public record UpdateAccountCommand(Account account) : IRequest;
}
