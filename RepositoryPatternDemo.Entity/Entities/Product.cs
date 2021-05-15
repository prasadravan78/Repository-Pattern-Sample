namespace RepositoryPatternDemo.Entity.Entities
{
    /// <summary>
    /// Provides various properties for audit logging.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name { get; set; }
    }
}
