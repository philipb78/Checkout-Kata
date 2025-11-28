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
        /// BAG Pricing Service
        /// </summary>
        private readonly IBagPricingService _bagPricingService;

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
        private double _specialPriceTotal = 0;

        /// <summary>
        /// Total Items Scanned
        /// </summary>
        private int _totalItems = 0;

        /// <summary>
        /// Check Out Service Constructor
        /// </summary>
        /// <param name="specialPriceRules">List Special Rules</param>
        public CheckoutService(List<SpecialPriceRuleBase> specialPriceRules, IProductRepository productRepository, IBagPricingService bagPricingService)
        {
            if (specialPriceRules == null)
            {
                throw new NullReferenceException(nameof(specialPriceRules) + " Is Null");
            }
            if (productRepository == null)
            {
                throw new NullReferenceException(nameof(productRepository) + " Is Null");
            }
            if (bagPricingService == null)
            {
                throw new NullReferenceException(nameof(bagPricingService) + " Is Null");
            }
            _specialPriceRules = specialPriceRules;
            _productRepository = productRepository;
            _bagPricingService = bagPricingService;
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

            double bagPrice = _bagPricingService.GetBagPrice(_totalItems);
            totalPrice += bagPrice;
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
            _totalItems++;
        }

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