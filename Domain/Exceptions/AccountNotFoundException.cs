using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    /// <summary>
    /// Exception is thrown for Account Not Found
    /// </summary>
    public sealed class AccountNotFoundException : NotFoundException
    {
        public AccountNotFoundException(Guid accountId)
            : base($"The account with the Id {accountId} was not found.")
        {
        }
    }
}