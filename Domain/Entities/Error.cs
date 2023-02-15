using Domain.Primitives;

namespace Domain.Entities
{
    /// <summary>
    /// Model for Error
    /// </summary>
    public class Error : Entity
    {
        public string Values { get; set; }
        public DateTime Created { get; set; }
    }
}
