namespace RepositoryPatternDemo.DAL.Repositories
{
    using System.Linq;
    using RepositoryPatternDemo.Entity.Entities;

    /// <summary>
    /// Exposes members to manage Product Category entity.
    /// </summary>
    public interface IProductCategoryRepository : IBaseRepository<ProductCategory>
    {
        /// <summary>
        /// Gets Product Category table query.
        /// </summary>
        /// <param name="isTrackingRequired">Whether tracking is required or not in db entity</param>
        /// <returns>Queryable Product Category object</returns>
        IQueryable<ProductCategory> GetQueryableProductCategories(bool isTrackingRequired = true);
    }
}
