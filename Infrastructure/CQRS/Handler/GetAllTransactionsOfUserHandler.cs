using Application.Abstractions.QueriesInterface;
using Domain.Entities;
using Infrastructure.CQRS.Queries;
using MediatR;

namespace Infrastructure.CQRS.Handler
{
    /// <summary>
    /// Handler for GetAllTransactions
    /// </summary>
    public class GetAllTransactionsOfUserHandler : IRequestHandler<GetAllTransactionsOfUserQuery, List<TransactionInfo>>
    {
        private readonly ITransactionInfoQueriesRepository _transactionInfoQueriesRepository;

        public GetAllTransactionsOfUserHandler(ITransactionInfoQueriesRepository transactionInfoQueriesRepository)
        {
            _transactionInfoQueriesRepository = transactionInfoQueriesRepository;
        }
        public Task<List<TransactionInfo>> Handle(GetAllTransactionsOfUserQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_transactionInfoQueriesRepository.GetAllForAccount(request.accountId));
        }
    }
}
