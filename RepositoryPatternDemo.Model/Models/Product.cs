namespace RepositoryPatternDemo.Model.Models
{
    /// <summary>
    /// Holds the detail of Product entity.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Initializes the associated navigational and relational elements.
        /// </summary>
        public Product()
        {

        }

        /// <summary>
        /// Gets or Sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the Name.
        /// </summary>
        public string Name { get; set; }
    }
}
