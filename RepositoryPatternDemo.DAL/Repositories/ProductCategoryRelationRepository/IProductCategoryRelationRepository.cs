namespace RepositoryPatternDemo.DAL.Repositories
{
    using System.Linq;
    using RepositoryPatternDemo.Entity.Entities;

    /// <summary>
    /// Exposes members to manage Product Category Relation entity.
    /// </summary>
    public interface IProductCategoryRelationRepository : IBaseRepository<ProductCategoryRelation>
    {
        /// <summary>
        /// Gets Product Category Relation table query.
        /// </summary>
        /// <param name="isTrackingRequired">Whether tracking is required or not in db entity</param>
        /// <returns>Queryable Product object</returns>
        IQueryable<ProductCategoryRelation> GetQueryableProductCategoryRelations(bool isTrackingRequired = true);
    }
}
