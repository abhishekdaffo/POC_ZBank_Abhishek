using Domain.Entities;
using Domain.Primitives;

namespace Domain.Entities
{
    /// <summary>
    /// Model for Account
    /// </summary>
    public class Account : Entity
    {
        public Guid UserId { get; set; }
        public long AccountNumber { get; set; }
        public decimal AccountBalance { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? LastLoggedIn { get; set; }
        public DateTime? LastTransaction { get; set; }

        public Customer Customer { get; set; }
        public List<TransactionInfo> TransactionInfos { get; set; }
    }
}
