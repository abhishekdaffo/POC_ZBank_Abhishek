using Domain.Entities;
using Domain.Primitives;

namespace Domain.Entities
{
    /// <summary>
    /// Model for TransactionInfo
    /// </summary>
    public class TransactionInfo : Entity
    {
        public string TransactionReference { get; set; }
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }
        public string ToBankName { get; set; }
        public string ToBankAccountNo { get; set; }
        public string PayeeName { get; set; }
        public string PayeePhone { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool Completed { get; set; }

        public Account Account { get; set; }
    }
}
