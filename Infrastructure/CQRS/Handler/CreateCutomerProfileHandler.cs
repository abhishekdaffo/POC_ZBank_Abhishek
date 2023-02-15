using Application.Abstractions.CommandsInterface;
using Infrastructure.CQRS.Command;
using MediatR;

namespace Infrastructure.CQRS.Handler
{
    /// <summary>
    /// Handler for Customer Profile
    /// </summary>
    public class CreateCutomerProfileHandler : IRequestHandler<CreateCutomerProfileCommand, Unit>
    {
        private readonly ICustomerCommandRepository _customerCommandRepository;

        public CreateCutomerProfileHandler(ICustomerCommandRepository customerCommandRepository)
        {
            _customerCommandRepository = customerCommandRepository;
        }
        public Task<Unit> Handle(CreateCutomerProfileCommand request, CancellationToken cancellationToken)
        {
            _customerCommandRepository.Insert(request.customer);
            return Task.FromResult(Unit.Value);
        }
    }
}
