namespace RepositoryPatternDemo.DAL.Repositories
{
    using System.Linq;
    using RepositoryPatternDemo.DAL.UnitOfWork;
    using RepositoryPatternDemo.Entity.Entities;    

    /// <summary>
    /// Provides members to manage Product in database.
    /// </summary>
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        #region Constructors

        /// <summary>
        /// Sets db context using Unit of Work.
        /// </summary>
        /// <param name="context">Unit of work</param>
        public ProductRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion Constructors

        #region Public Methods

        /// <summary>
        /// Gets Product table query.
        /// </summary>
        /// <param name="isTrackingRequired">Whether tracking is required or not in db entity</param>
        /// <returns>Product table</returns>
        public IQueryable<Product> GetQueryableProducts(bool isTrackingRequired = true)
        {
            IQueryable<Product> result = null;

            if (isTrackingRequired)
            {
                result = Table.Where(k => k.IsActive);
            }
            else
            {
                result = TableWithNoTracking.Where(k => k.IsActive);
            }

            return result;
        }

        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods
    }
}
