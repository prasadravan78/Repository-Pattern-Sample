namespace RepositoryPatternDemo.DAL.UnitOfWork
{    
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using RepositoryPatternDemo.Common.Constants;
    using RepositoryPatternDemo.Common.ExceptionHandling;
    using RepositoryPatternDemo.DAL.DBContext;
    using RepositoryPatternDemo.Entity.Entities;

    /// <summary>
    /// Manages multiple changes across repositories as a unit by sharing the database context.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Member Variables

        private readonly AppDbContext appDbContext;
        private bool disposed = false;

        #endregion Member Variables

        #region Constructors

        /// <summary>
        /// Default constructor.
        /// </summary>
        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        #endregion Constructors    

        #region Properties

        /// <summary>
        /// Gets application database context.
        /// </summary>
        public AppDbContext AppDbContext
        {
            get
            {
                return appDbContext;
            }
        }

        #endregion Properties

        #region Public Methods

        /// <summary>
        /// Saves all changes made to the context to the underlying database
        /// </summary>
        /// <returns>No. of affected records.</returns>
        public int Save(string userName = "")
        {
            int result = 0;

            try
            {
                AddTrackingInformation(userName);
                result = appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return (result);
        }

        /// <summary>
        /// Saves changes asynchronously in to the database.
        /// </summary>
        /// <returns>No. of affected records.</returns>
        public async Task<int> SaveAsync(string userName = "")
        {
            int result = 0;

            try
            {
                AddTrackingInformation(userName);
                result = await appDbContext.SaveChangesAsync().ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return (result);
        }

        /// <summary>
        /// Begins the transaction on the database Context
        /// </summary>
        public void BeginTransaction()
        {
            appDbContext.Database.BeginTransaction();            
        }

        /// <summary>
        /// Rollback the transaction on the database context
        /// </summary>
        public void RollbackTransaction()
        {
            appDbContext.Database.RollbackTransaction();
        }

        /// <summary>
        /// Commit the transaction on the database context
        /// </summary>
        public void Commit()
        {
            appDbContext.Database.CommitTransaction();
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Adds the tracking information including the timestamps and user details
        /// </summary>
        private void AddTrackingInformation(string userName = "")
        {
            var entities = appDbContext.ChangeTracker
                                  .Entries()
                                  .Where(x => x.Entity is BaseEntity &&
                                             (x.State == EntityState.Added ||
                                              x.State == EntityState.Modified));

            if (string.IsNullOrWhiteSpace(userName))
            {
                // Get user's name from Identity.            
                userName = Thread.CurrentPrincipal.Identity.Name;
            }

            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreationDate = DateTime.UtcNow;
                    ((BaseEntity)entity.Entity).CreatedBy = userName;
                }

                ((BaseEntity)entity.Entity).ModificationDate = DateTime.UtcNow;
                ((BaseEntity)entity.Entity).ModifiedBy = userName;
            }
        }

        /// <summary>
        /// Handles exception.
        /// </summary>
        /// <param name="exception">Exception</param>
        private void HandleException(Exception exception)
        {
            if (exception is DbUpdateConcurrencyException concurrencyEx)
            {
                // A custom exception for concurrency issues.
                throw new CustomException(Constants.AppError.ERROR_CONCURRENCY,
                                          concurrencyEx);
            }

            if (exception is DbUpdateException dbUpdateEx)
            {
                if (dbUpdateEx.InnerException != null &&
                    dbUpdateEx.InnerException.InnerException != null)
                {
                    if (dbUpdateEx.InnerException.InnerException is SqlException sqlException)
                    {
                        switch (sqlException.Number)
                        {
                            case 2627:
                                // Unique constraint error.
                                throw new CustomException("Record is not Unique", sqlException);

                            case 547:
                                // Constraint check violation.
                                throw new CustomException("Constraint Check Violation", sqlException);

                            case 2601:
                                // Duplicated key row error.
                                // Constraint violation exception.
                                throw new CustomException("Constraint Check Violation", sqlException);

                            default:
                                // A custom exception of yours for other DB issues
                                throw sqlException;
                        }
                    }

                    throw dbUpdateEx;
                }
            }
        }

        #endregion Private Methods

        #region IDisposable Support

        /// <summary>
        /// Disposes current instance of the service.
        /// This code added to correctly implement the disposable pattern.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: Uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the instance of context, db transaction.
        /// </summary>
        /// <param name="disposing">Disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (appDbContext != null)
                    {
                        appDbContext.Dispose();
                    }
                }

                // Free unmanaged resources (unmanaged objects) and override a finalizer below.
                // Set large fields to null.

                disposed = true;
            }
        }

        #endregion IDisposable Support
    }
}
