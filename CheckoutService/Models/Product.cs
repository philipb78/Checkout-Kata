using System.ComponentModel.DataAnnotations;

namespace Checkout.Models
{
    /// <summary>
    /// Product Model
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Unit Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// SKU Code
        /// </summary>
        [Required]
        public string SKU { get; set; } = string.Empty;

        /// <summary>
        /// Product Constructor
        /// </summary>
        /// <param name="sku">sku</param>
        /// <param name="price">price</param>
        public Product(string sku, double price)
        {
            Price = price;
            SKU = sku;
        }
    }
}