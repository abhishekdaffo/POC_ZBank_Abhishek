using Application.Abstractions.CommandsInterface;
using Infrastructure.CQRS.Command;
using MediatR;

namespace Infrastructure.CQRS.Handler
{
    /// <summary>
    /// Handler for TransactionInfo
    /// </summary>
    public class CreateTransactionInfoHandler : IRequestHandler<CreateTransactionInfoCommand, Unit>
    {
        private readonly ITransactionInfoCommandRepository _transactionInfoCommandRepository;

        public CreateTransactionInfoHandler(ITransactionInfoCommandRepository transactionInfoCommandRepository)
        {
            _transactionInfoCommandRepository = transactionInfoCommandRepository;
        }
        public Task<Unit> Handle(CreateTransactionInfoCommand request, CancellationToken cancellationToken)
        {
            _transactionInfoCommandRepository.Insert(request.transactionInfo);
            return Task.FromResult<Unit>(Unit.Value);
        }
    }
}
