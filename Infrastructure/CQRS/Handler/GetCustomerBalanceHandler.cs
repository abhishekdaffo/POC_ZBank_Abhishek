using Application.Abstractions.QueriesInterface;
using Infrastructure.CQRS.Queries;
using MediatR;

namespace Infrastructure.CQRS.Handler
{
    /// <summary>
    /// Handler for GetCustomerBalance
    /// </summary>
    public class GetCustomerBalanceHandler : IRequestHandler<GetCustomerBalanceQuery, decimal>
    {
        private readonly IAccountQueriesRepository _accountQueriesRepository;

        public GetCustomerBalanceHandler(IAccountQueriesRepository accountQueriesRepository)
        {
            _accountQueriesRepository = accountQueriesRepository;
        }
        public Task<decimal> Handle(GetCustomerBalanceQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_accountQueriesRepository.GetAccountBalance(request.customerId));
        }
    }
}
