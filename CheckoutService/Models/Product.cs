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
    }
}