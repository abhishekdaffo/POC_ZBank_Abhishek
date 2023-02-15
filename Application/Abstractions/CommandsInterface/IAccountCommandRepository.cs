using Domain.Entities;

namespace Application.Abstractions.CommandsInterface
{
    /// <summary>
    /// Interface for AccountCommandRepository
    /// </summary>
    public interface IAccountCommandRepository
    {
        void Insert(Account account);
        void Update(Account account);
    }
}
