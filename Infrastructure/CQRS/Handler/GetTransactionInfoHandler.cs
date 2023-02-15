using Application.Abstractions.QueriesInterface;
using Domain.Entities;
using Infrastructure.CQRS.Queries;
using MediatR;

namespace Infrastructure.CQRS.Handler
{
    /// <summary>
    ///  Handler for GetTransactionInfo
    /// </summary>
    public class GetTransactionInfoHandler : IRequestHandler<GetTransactionInfoQuery, TransactionInfo>
    {
        private readonly ITransactionInfoQueriesRepository _transactionInfoQueriesRepository;

        public GetTransactionInfoHandler(ITransactionInfoQueriesRepository transactionInfoQueriesRepository)
        {
            _transactionInfoQueriesRepository = transactionInfoQueriesRepository;
        }
        public Task<TransactionInfo> Handle(GetTransactionInfoQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_transactionInfoQueriesRepository.GetByReferenceId(request.referenceId));
        }
    }
}
