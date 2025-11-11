using Checkout.Constants;
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
        /// Scanned Items
        /// </summary>
        private List<Product> _scannedItems;

        /// <summary>
        /// Special Price Total
        /// </summary>
        private Double _specialPriceTotal = 0;

        /// <summary>
        /// Check Out Service Constructor
        /// </summary>
        /// <param name="specialPriceRules">List Special Rules</param>
        public CheckoutService(List<SpecialPriceRuleBase> specialPriceRules, IProductRepository productRepository)
        {
            _specialPriceRules = specialPriceRules;
            _productRepository = productRepository;
            _scannedItems = new List<Product>();
        }

        /// <summary>
        /// Get Total Price including Special Price Deals
        /// </summary>
        /// <returns>Total Price</returns>
        public double GetTotalPrice()
        {
            double totalPrice = 0;
            totalPrice += _specialPriceTotal;
            foreach (Product product in _scannedItems)
            {
                totalPrice += product.Price;
            }
            return totalPrice;
        }

   

        /// <summary>
        /// Scan Item
        /// </summary>
        /// <param name="sku">sku</param>
        public void ScanItem(string sku)
        {
            Product? product = _productRepository.GetProduct(sku);
            if (product == null)
            {
                throw new ArgumentException(MessageConstants.InvalidSKU);
            }
            else
            {
                _scannedItems.Add(product);
                CalculateSpecialPriceTotal();
            }
        }

        /// <summary>
        /// Reset Checkout
        /// </summary>
        /// <summary>
        /// Calculate Special Price Total
        /// Items will be removed from the main list that are included in this total
        /// </summary>
        private void CalculateSpecialPriceTotal()
        {
            foreach (SpecialPriceRuleBase specialPriceRule in _specialPriceRules)
            {
                _specialPriceTotal += specialPriceRule.ApplySpecialPrice(ref _scannedItems);
            }
        }
    }
}