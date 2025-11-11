using Checkout.Interfaces;
using Checkout.Models;

namespace CheckOutTests
{
    /// <summary>
    /// Mock Implementation Of IProduct Repository
    /// </summary>
    public class MockProductRepository : IProductRepository
    {
        /// <summary>
        /// Test Products
        /// </summary>
        private readonly List<Product> _products;

        /// <summary>
        /// Mock Product Repository Constructor
        /// </summary>
        public MockProductRepository()
        {
            //Create Test Data
            _products = new List<Product>()
            {
                new Product("A", 50),
                new Product("B", 30),
                new Product("C", 20),
                new Product("D", 15)
            };
        }

        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="product">product</param>
        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="sku">sku</param>
        public void DeleteProduct(string sku)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get ALl Products
        /// </summary>
        /// <returns>List Of Products</returns>
        public List<Product> GetAllProducts()
        {
            return _products;
        }

        /// <summary>
        /// Gets SKU from Mock Data
        /// </summary>
        /// <param name="sku">sku</param>
        /// <returns>Mock Product</returns>
        public Product? GetProduct(string sku)
        {
            return _products.Where(p => p.SKU == sku).FirstOrDefault();
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="product"></param>
        public void UpdateProduct(Product product)
        {
           throw new NotImplementedException();
        }
    }
}