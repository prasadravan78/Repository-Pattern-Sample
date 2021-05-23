namespace RepositoryPatternDemo.Entity.Entities
{
    /// <summary>
    /// Provides various properties for Product Category Relation.
    /// </summary>
    public class ProductCategoryRelation : BaseEntity
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets ProductId.
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets ProductCategoryId.
        /// </summary>
        public int ProductCategoryId { get; set; }

        /// <summary>
        /// Gets or sets Product.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Gets or sets ProductCategory.
        /// </summary>
        public ProductCategory ProductCategory { get; set; }
    }
}
