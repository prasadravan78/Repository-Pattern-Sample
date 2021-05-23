namespace RepositoryPatternDemo.Model.Models
{
    /// <summary>
    /// Holds the detail of ProductRelation entity.
    /// </summary>
    public class ProductCategoryRelation : BaseEntity
    {
        /// <summary>
        /// Initializes the associated navigational and relational elements.
        /// </summary>
        public ProductCategoryRelation()
        {

        }

        /// <summary>
        /// Gets or Sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or Sets the ProductName.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or Sets the ProductCategoryName.
        /// </summary>
        public string ProductCategoryName { get; set; }
    }
}
