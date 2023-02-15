using Application.Abstractions.QueriesInterface;
using Infrastructure.CQRS.Queries;
using MediatR;

namespace Infrastructure.CQRS.Handler
{
    /// <summary>
    /// Handler for GetCustomersCreatedToday
    /// </summary>
    public class GetCustomersCreatedTodayHandler : IRequestHandler<GetCustomersCreatedTodayQuery, int>
    {
        private readonly ICustomerQueriesRepository _customerQueriesRepository;

        public GetCustomersCreatedTodayHandler(ICustomerQueriesRepository customerQueriesRepository)
        {
            _customerQueriesRepository = customerQueriesRepository;
        }
        public Task<int> Handle(GetCustomersCreatedTodayQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_customerQueriesRepository.GetCustomersCreatedToday());
        }
    }
}
