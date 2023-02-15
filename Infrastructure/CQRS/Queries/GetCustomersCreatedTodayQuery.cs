using MediatR;

namespace Infrastructure.CQRS.Queries
{
    /// <summary>
    /// Record for GetCustomersCreatedToday
    /// </summary>
    public record GetCustomersCreatedTodayQuery() : IRequest<int>;
}
