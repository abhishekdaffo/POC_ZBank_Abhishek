using Domain.Entities;

namespace Application.Abstractions.CommandsInterface
{
    /// <summary>
    /// Interface for CustomerCommandRepository
    /// </summary>
    public interface ICustomerCommandRepository
    {
        void Insert(Customer customer);
        void Update(Customer customer);
    }
}
