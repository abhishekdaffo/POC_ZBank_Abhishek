using Application.Abstractions.CommandsInterface;
using Infrastructure.CQRS.Command;
using MediatR;

namespace Infrastructure.CQRS.Handler
{
    /// <summary>
    /// Handler for UpdateAccount
    /// </summary>
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, Unit>
    {
        private readonly IAccountCommandRepository _accountCommandRepository;

        public UpdateAccountHandler(IAccountCommandRepository accountCommandRepository)
        {
            _accountCommandRepository = accountCommandRepository;
        }
        public Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            _accountCommandRepository.Update(request.account);
            return Task.FromResult(Unit.Value);
        }
    }
}
