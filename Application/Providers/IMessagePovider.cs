namespace Application.Providers
{
    /// <summary>
    /// Interface for Message Provider
    /// </summary>
    public interface IMessagePovider
    {
        void NotifyUserTransfer(Guid userId, decimal transferAmount);
    }
}
