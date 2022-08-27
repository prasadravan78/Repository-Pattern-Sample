namespace RepositoryPatternDemo.DAL.UnitOfWork
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using RepositoryPatternDemo.DAL.DBContext;
    using RepositoryPatternDemo.Entity.Entities;

    /// <summary>
    /// Manages multiple changes across repositories as a unit by sharing the database context.
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext appDbContext;
        private bool disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="appDbContext">Dependacy of AppDbContext.</param>
        public UnitOfWork(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        /// <summary>
        /// Gets application database context.
        /// </summary>
        public AppDbContext AppDbContext
        {
            get
            {
                return this.appDbContext;
            }
        }

        /// <summary>
        /// Saves all changes made to the context to the underlying database.
        /// </summary>
        /// <param name="userName">User Name.</param>
        /// <returns>No. of affected records.</returns>
        public int Save(string userName = "")
        {
            int result = 0;

            try
            {
                this.AddTrackingInformation(userName);
                result = this.appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                UnitOfWorkHelpers.HandleException(ex);
            }

            return result;
        }

        /// <summary>
        /// Saves changes asynchronously in to the database.
        /// </summary>
        /// <param name="userName">User Name.</param>
        /// <returns>No. of affected records.</returns>
        public async Task<int> SaveAsync(string userName = "")
        {
            int result = 0;

            try
            {
                this.AddTrackingInformation(userName);
                result = await this.appDbContext.SaveChangesAsync().ConfigureAwait(true);
            }
            catch (Exception ex)
            {
                UnitOfWorkHelpers.HandleException(ex);
            }

            return result;
        }

        /// <summary>
        /// Begins the transaction on the database Context.
        /// </summary>
        public void BeginTransaction()
        {
            this.appDbContext.Database.BeginTransaction();
        }

        /// <summary>
        /// Rollback the transaction on the database context.
        /// </summary>
        public void RollbackTransaction()
        {
            this.appDbContext.Database.RollbackTransaction();
        }

        /// <summary>
        /// Commit the transaction on the database context.
        /// </summary>
        public void Commit()
        {
            this.appDbContext.Database.CommitTransaction();
        }

        /// <summary>
        /// Adds the tracking information including the timestamps and user details.
        /// </summary>
        private void AddTrackingInformation(string userName = "")
        {
            var entities = this.appDbContext.ChangeTracker
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
        /// Disposes current instance of the service.
        /// This code added to correctly implement the disposable pattern.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            this.Dispose(true);

            // TODO: Uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the instance of context, db transaction.
        /// </summary>
        /// <param name="disposing">Disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (this.appDbContext != null)
                    {
                        this.appDbContext.Dispose();
                    }
                }

                // Free unmanaged resources (unmanaged objects) and override a finalizer below.
                // Set large fields to null.
                this.disposed = true;
            }
        }
    }
}
