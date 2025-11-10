using Checkout.Interfaces;
using Checkout.SpecialPricesRules;

namespace Checkout.Services
{
    /// <summary>
    /// Checkout Service
    /// </summary>
    public class CheckoutService : ICheckoutService
    {
        /// <summary>
        /// List Of Special Price Rules
        /// </summary>
        private List<SpecialPriceRuleBase> _specialPriceRules;

        /// <summary>
        /// Total Price
        /// </summary>
        private double _totalPrice;

        /// <summary>
        /// Check Out Service Constructor
        /// </summary>
        /// <param name="specialPriceRules">List Special Rules</param>
        public CheckoutService(List<SpecialPriceRuleBase> specialPriceRules)
        {
            _specialPriceRules = specialPriceRules;
        }

        /// <summary>
        /// Get Total price
        /// </summary>
        /// <returns>Total Price</returns>
        public double GetTotalPrice()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="sku"></param>
        public void ScanItem(string sku)
        {
            throw new NotImplementedException();
        }
    }
}