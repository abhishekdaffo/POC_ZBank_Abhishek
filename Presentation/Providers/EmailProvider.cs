using Application.Providers;

namespace Presentation.Providers
{
    /// <summary>
    /// Provider for Email
    /// </summary>
    public class EmailProvider : IMessagePovider
    {
        public void NotifyUserTransfer(Guid userId, decimal transferAmount)
        {
            //We will send users Notification Here
        }
    }
}
