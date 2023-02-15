using Application.Providers;

namespace Presentation.Providers
{
    /// <summary>
    /// Provider for Sms
    /// </summary>
    public class SmsProvider : IMessagePovider
    {
        public void NotifyUserTransfer(Guid userId, decimal transferAmount)
        {
            //We will send users SMS Here
        }
    }
}
