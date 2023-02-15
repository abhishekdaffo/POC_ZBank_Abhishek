using Domain.Entities;
using Domain.Primitives;

namespace Domain.Entities
{
    /// <summary>
    /// Model for Customer
    /// </summary>
    public class Customer : Entity
    {
        public string FriendlyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime MemberSince { get; set; }

        public Account Account { get; set; }
    }
}
