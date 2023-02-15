using Application.Abstractions.CommandsInterface;
using Infrastructure.CQRS.Command;
using MediatR;

namespace Infrastructure.CQRS.Handler
{
    /// <summary>
    /// Handler for Create Customer Account
    /// </summary>
    public class CreateCustomerAccountHandler : IRequestHandler<CreateCustomerAccountCommand, Unit>
    {
        private readonly IAccountCommandRepository _accountCommandRepository;

        public CreateCustomerAccountHandler(IAccountCommandRepository accountCommandRepository)
        {
            _accountCommandRepository = accountCommandRepository;
        }
        public Task<Unit> Handle(CreateCustomerAccountCommand request, CancellationToken cancellationToken)
        {
            _accountCommandRepository.Insert(request.account);
            return Task.FromResult(Unit.Value);
        }
    }
}
