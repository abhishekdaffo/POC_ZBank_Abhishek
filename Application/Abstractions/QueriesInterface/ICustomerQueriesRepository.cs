using Domain.Entities;

namespace Application.Abstractions.QueriesInterface
{
    /// <summary>
    /// Interface for CustomerQueriesRepository
    /// </summary>
    public interface ICustomerQueriesRepository
    {
        Customer GetById(Guid accountId);
        List<Customer> GetAll();
        int GetCustomersCreatedToday();
    }
}
