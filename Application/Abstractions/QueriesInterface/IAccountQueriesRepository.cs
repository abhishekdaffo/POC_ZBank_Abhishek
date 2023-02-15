using Domain.Entities;

namespace Application.Abstractions.QueriesInterface
{
    /// <summary>
    /// Interface for AccountQueriesRepository
    /// </summary>
    public interface IAccountQueriesRepository
    {
        Account GetById(Guid accountId);
        Account GetByUserId(Guid userId);
        List<Account> GetAll();
        decimal GetAccountBalance(Guid userId);
    }
}
