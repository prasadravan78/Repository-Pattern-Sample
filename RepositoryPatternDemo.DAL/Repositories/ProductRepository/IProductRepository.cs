namespace RepositoryPatternDemo.DAL.Repositories
{
    using System.Linq;
    using RepositoryPatternDemo.Entity.Entities;

    /// <summary>
    /// Exposes members to manage Product entity.
    /// </summary>
    public interface IProductRepository : IBaseRepository<Product>
    {
        /// <summary>
        /// Gets Product table query.
        /// </summary>
        /// <param name="isTrackingRequired">Whether tracking is required or not in db entity</param>
        /// <returns>Queryable Product object</returns>
        IQueryable<Product> GetQueryableProducts(bool isTrackingRequired = true);
    }
}
