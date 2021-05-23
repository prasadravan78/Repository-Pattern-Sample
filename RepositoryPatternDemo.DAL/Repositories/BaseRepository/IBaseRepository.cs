namespace RepositoryPatternDemo.DAL.Repositories
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Exposes members of generic repository.
    /// </summary>
    /// <typeparam name="TEntity">Generic entity</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        #region Public Methods        

        /// <summary>
        /// Gets the Entity Details based on the Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Entity</returns>
        TEntity GetById(object id);

        /// <summary>
        /// Gets the Entity Details asyncronously based on the Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Entity</returns>
        Task<TEntity> GetByIdAsync(object id);

        /// <summary>
        /// Adds the new entity into the collection of entities
        /// </summary>
        /// <param name="entity">Entity</param>
        void Add(TEntity entity);

        /// <summary>
        /// Adds a set of new entities into the collection of entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Updates the given entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Update(TEntity entity);

        /// <summary>
        /// Updates a set of entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Removes an entity based on the id
        /// </summary>
        /// <param name="id">Id</param>
        void Remove(object id);

        /// <summary>
        /// Removes the specified entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Remove(TEntity entity);

        /// <summary>
        /// Removes a set of specified entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void RemoveRange(IEnumerable<TEntity> entities);

        #endregion Public Methods
    }
}
