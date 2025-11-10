using Checkout.Models;

namespace Checkout.Interfaces
{
    /// <summary>
    /// Product Repository Interface
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="product">Product</param>
        void AddProduct(Product product);

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="sku">SKU</param>
        void DeleteProduct(string sku);

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns>All Products</returns>
        List<Product> GetAllProducts();

        /// <summary>
        /// Get Product
        /// </summary>
        /// <param name="sku">SKU</param>
        /// <returns>Product </returns>
        Product? GetProduct(string sku);

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="product">Product</param>
        void UpdateProduct(Product product);
    }
}