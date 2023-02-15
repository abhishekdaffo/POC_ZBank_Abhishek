namespace Application.Providers
{
    /// <summary>
    /// Interface for Payment
    /// </summary>
    public interface IPaymentProvider
    {
        bool ProcessPayment();
    }
}
