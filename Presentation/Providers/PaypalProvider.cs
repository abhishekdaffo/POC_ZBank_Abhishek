using Application.Providers;

namespace Presentation.Providers
{
    /// <summary>
    /// Provider for Paypal
    /// </summary>
    public class PaypalProvider : IPaymentProvider
    {
        public bool ProcessPayment()
        {
            //We will process payment here
            return true;
        }
    }
}
