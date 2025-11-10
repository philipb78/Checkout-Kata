using Checkout.Models;

namespace Checkout.SpecialPricesRules
{
    /// <summary>
    /// Special Price Rule Multi Buy.  Buy x of a product ,get special price rate .
    /// </summary>
    public class SpecialPriceRuleMultiBuy : SpecialPriceRuleBase
    {
        /// <summary>
        /// Number To Purchase To Get Special Price
        /// </summary>
        private int _numberRequired { get; set; }

        /// <summary>
        /// Special Price
        /// </summary>
        private double _specialPrice { get; set; }

        /// <summary>
        /// SKU Related To Rule
        /// </summary>
        private string _specialSKU { get; set; } = string.Empty;

        /// <summary>
        /// Special Price Rule Multi Buy Constructor
        /// </summary>
        /// <param name="sku"></param>
        /// <param name="specialPrice"></param>
        /// <param name="numberRequired"></param>
        public SpecialPriceRuleMultiBuy(string sku, double specialPrice, int numberRequired)
        {
            _specialSKU = sku;
            _specialPrice = specialPrice;
            _numberRequired = numberRequired;
        }

        /// <summary>
        /// Apply Special Price Using Rule Implementation
        /// </summary>
        /// <param name="scannedItems">Scanned Items</param>
        /// <returns>Special Price or 0 if not applied</returns>
        public override double ApplySpecialPrice(ref List<Product> scannedItems)
        {
            List<Product> specialProducts = scannedItems.Where(s => s.SKU == _specialSKU).ToList();
            if (specialProducts.Count == _numberRequired)
            {
                RemoveProductsForSpecialPrice(specialProducts, ref scannedItems);
                return _specialPrice;
            }
            else

            {
                return 0;
            }
        }

        /// <summary>
        /// Remove Products Where Applied
        /// </summary>
        /// <param name="productsToRemove">List Products To Remove</param>
        /// <param name="scannedItems">Scanned Item List</param>
        private void RemoveProductsForSpecialPrice(List<Product> productsToRemove, ref List<Product> scannedItems)
        {
            foreach (Product product in productsToRemove)
            {
                scannedItems.Remove(product);
            }
        }
    }
}