namespace RepositoryPatternDemo.Web.ViewModels
{
    using System.Collections.Generic;
    using RepositoryPatternDemo.Model.Models;    

    /// <summary>
    /// Holds the detail of ProductRelation view model.
    /// </summary>
    public class ProductCategoryRelationViewModel
    {
        /// <summary>
        /// Gets or Sets the Id.
        /// </summary>
        public List<ProductCategoryRelation> ProductCategoryRelations { get; set; }
    }
}
