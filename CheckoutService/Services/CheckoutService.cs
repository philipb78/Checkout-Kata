using Checkout.Interfaces;
using Checkout.Models;
using Checkout.SpecialPricesRules;

namespace Checkout.Services
{
    /// <summary>
    /// Checkout Service
    /// </summary>
    public class CheckoutService : ICheckoutService
    {
        /// <summary>
        /// Product Repository
        /// </summary>
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// List Of Special Price Rules
        /// </summary>
        private readonly List<SpecialPriceRuleBase> _specialPriceRules;

        /// <summary>
        /// Total Price
        /// </summary>
        private double _totalPrice;

        /// <summary>
        /// Check Out Service Constructor
        /// </summary>
        /// <param name="specialPriceRules">List Special Rules</param>
        public CheckoutService(List<SpecialPriceRuleBase> specialPriceRules, IProductRepository productRepository)
        {
            _specialPriceRules = specialPriceRules;
            _productRepository = productRepository;
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