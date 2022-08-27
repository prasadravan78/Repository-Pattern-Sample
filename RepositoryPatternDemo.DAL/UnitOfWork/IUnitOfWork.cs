namespace RepositoryPatternDemo.DAL.UnitOfWork
{
    using System;
    using System.Threading.Tasks;
    using RepositoryPatternDemo.DAL.DBContext;

    /// <summary>
    /// Exposes members to manipulate database a single unit of work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets application database context.
        /// </summary>
        AppDbContext AppDbContext { get; }

        /// <summary>
        /// Saves changes in database.
        /// </summary>
        /// <returns>No. of affected records</returns>
        int Save(string userName = "");

        /// <summary>
        /// Saves changes in database asynchronously.
        /// </summary>
        /// <returns>No. of affected records</returns>
        Task<int> SaveAsync(string userName = "");

        /// <summary>
        /// Begins database transaction.
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Rollback all changes in current database transaction.
        /// </summary>
        void RollbackTransaction();

        /// <summary>
        /// Comments all changes in current database transaction.
        /// </summary>
        void Commit();
        void Dispose();
    }
}
