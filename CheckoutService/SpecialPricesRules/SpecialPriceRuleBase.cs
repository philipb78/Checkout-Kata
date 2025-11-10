using Checkout.Models;

namespace Checkout.SpecialPricesRules
{
    /// <summary>
    /// Base Class For Special Prices 
    /// </summary>
   public abstract class SpecialPriceRuleBase
    {
        /// <summary>
        /// Apply Special Price 
        /// </summary>
        /// <param name="scannedItems">List Of Scanned Items</param>
        /// <returns>If Actioned</returns>
        public abstract double ApplySpecialPrice(ref List<Product> scannedItems);
    }
}
