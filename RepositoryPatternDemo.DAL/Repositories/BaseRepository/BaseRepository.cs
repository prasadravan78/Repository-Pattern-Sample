namespace RepositoryPatternDemo.DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using RepositoryPatternDemo.DAL.UnitOfWork;

    /// <summary>
    /// Provides data access methods using Entity Framework as a generic repository.
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        #region Member Variables

        private readonly DbContext context;
        private DbSet<TEntity> dbSet;

        #endregion Member Variables

        #region Constructors

        /// <summary>
        /// Initializes the context and dbSet.
        /// </summary>
        /// <param name="context">Db context</param>
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork != null)
            {
                context = unitOfWork.AppDbContext;
                dbSet = context.Set<TEntity>();
            }
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets table of the given entity as queryable.
        /// </summary>
        protected virtual IQueryable<TEntity> Table
        {
            get
            {
                return dbSet;
            }
        }

        /// <summary>
        /// Gets table of the given entity as queryable with no tracking.
        /// </summary>
        protected virtual IQueryable<TEntity> TableWithNoTracking
        {
            get
            {
                return dbSet.AsNoTracking();
            }
        }

        #endregion Properties

        #region Public Methods        

        /// <summary>
        /// Gets the Entity based on Id.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Entity</returns>
        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        /// <summary>
        /// Gets the Entity asynchronous based on Id.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Entity</returns>
        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await dbSet.FindAsync(id).ConfigureAwait(true);
        }

        /// <summary>
        /// Adds the entity to the context.
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            dbSet.Add(entity);
        }

        /// <summary>
        /// Adds a set of entities to the context.
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            dbSet.AddRange(entities);
        }

        /// <summary>
        /// Updates the Entity to the context.
        /// </summary>
        /// <param name="entity">Entities</param>
        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Updates a set of entities to the context.
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
            {
                Update(entity);
            }
        }

        /// <summary>
        /// Removes the entity from the context based on id.
        /// </summary>
        /// <param name="id">Id</param>
        public virtual void Remove(object id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            TEntity entityToDelete = dbSet.Find(id);
            Remove(entityToDelete);
        }

        /// <summary>
        /// Removes the Entity from the Context.
        /// </summary>
        /// <param name="entity">Entities</param>
        public virtual void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }

        /// <summary>
        /// Removes a set of entities from the context.
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Gets the collection of entities based on the optional filter, orderBy and includeProperties.
        /// </summary>
        /// <param name="filter">Lambda expression filter</param>
        /// <param name="orderBy">OrderBy delegate</param>
        /// <param name="includeProperties">Related objects delimited by comma</param>
        /// <returns>Entity collection</returns>
        protected virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                   string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// Gets the collection of entities asynchronous based on the optional filter, orderBy and includeProperties.
        /// </summary>
        /// <param name="filter">Lambda expression filter</param>
        /// <param name="orderBy">OrderBy delegate</param>
        /// <param name="includeProperties">Related objects delimited by comma</param>
        /// <returns>Entity collection</returns>
        protected virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
                                                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                                    string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync().ConfigureAwait(true);
            }
            else
            {
                return await query.ToListAsync().ConfigureAwait(true);
            }
        }

        #endregion Protected Methods
    }
}
