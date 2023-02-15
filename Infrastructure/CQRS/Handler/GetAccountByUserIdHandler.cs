using Application.Abstractions.QueriesInterface;
using Domain.Entities;
using Infrastructure.CQRS.Queries;
using MediatR;

namespace Infrastructure.CQRS.Handler
{
    /// <summary>
    /// Handler for GetAccountByUserId
    /// </summary>
    public class GetAccountByUserIdHandler : IRequestHandler<GetAccountByUserIdQuery, Account>
    {
        private readonly IAccountQueriesRepository _accountQueriesRepository;

        public GetAccountByUserIdHandler(IAccountQueriesRepository accountQueriesRepository)
        {
            _accountQueriesRepository = accountQueriesRepository;
        }
        public Task<Account> Handle(GetAccountByUserIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_accountQueriesRepository.GetByUserId(request.userId));
        }
    }
}
