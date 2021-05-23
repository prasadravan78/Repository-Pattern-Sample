namespace RepositoryPatternDemo.Entity.Entities
{
    using System.Collections.Generic;

    /// <summary>
    /// Provides various properties for Product.
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

        #region Relational and Navigation Properties

        /// <summary>
        /// Gets or sets ProductCategoryRelation collection.
        /// </summary>
        public virtual ICollection<ProductCategoryRelation> ProductCategoryRelations { get; set; }

        #endregion Relational and Navigation Properties
    }
}
