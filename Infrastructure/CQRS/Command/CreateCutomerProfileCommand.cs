using Domain.Entities;
using MediatR;

namespace Infrastructure.CQRS.Command
{
    /// <summary>
    /// Record for Create Cutomer Profile Command
    /// </summary>
    /// <param name="customer"></param>
    public record CreateCutomerProfileCommand(Customer customer) : IRequest;
}
