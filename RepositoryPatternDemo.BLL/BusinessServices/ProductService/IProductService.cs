namespace RepositoryPatternDemo.BLL.BusinessServices.ProductService
{
    using System;
    using System.Collections.Generic;
    using RepositoryPatternDemo.Model.Models;

    /// <summary>
    /// Exposes members to manage Product entity.
    /// </summary>
    public interface IProductService : IDisposable
    {
        /// <summary>
        /// Gets Products.
        /// </summary>
        /// <returns>List of Product</returns>
        List<Product> GetProducts();

        /// <summary>
        /// Gets Product by Id.
        /// </summary>
        /// <param name="productId">Product id</param>
        /// <returns>Product by Id.</returns>
        Product GetProductById(int productId);

        /// <summary>
        /// Gets Product Category Relations.
        /// </summary>
        /// <returns>List of Product Category Relations</returns>
        List<ProductCategoryRelation> GetProductCategoryRelations();
    }
}
