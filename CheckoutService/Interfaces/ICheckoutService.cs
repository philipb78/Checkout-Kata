namespace Checkout.Interfaces
{
    /// <summary>
    /// Checkout Service Interface
    /// </summary>
    public interface ICheckoutService
    {
        /// <summary>
        /// Gets Total Price For Session
        /// </summary>
        /// <returns>Total Amount</returns>
        double GetTotalPrice();

        /// <summary>
        /// Scan SKU Code
        /// </summary>
        /// <param name="sku">SKU</param>
        void ScanItem(string sku);

     
    }
}