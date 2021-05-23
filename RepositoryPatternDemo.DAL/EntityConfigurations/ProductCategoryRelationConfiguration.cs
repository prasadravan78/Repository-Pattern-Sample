namespace RepositoryPatternDemo.DAL.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RepositoryPatternDemo.Entity.Entities;    

    /// <summary>
    /// Provides Code first entity configuration for ProductCategory.
    /// </summary>
    public class ProductCategoryRelationConfiguration
    {
        /// <summary>
        /// Holds entity configuration for ProductCategoryRelation.
        /// </summary>
        public ProductCategoryRelationConfiguration(EntityTypeBuilder<ProductCategoryRelation> entityTypeBuilder)
        {
            #region Table, Key and Column Configuration

            entityTypeBuilder.HasKey(c => c.Id);

            entityTypeBuilder.Property(c => c.Id)
                             .ValueGeneratedOnAdd();

            //entityTypeBuilder.HasOne(k => k.Product)
            //                 .WithMany(k => k.ProductCategoryRelations)
            //                 .HasForeignKey(k=> k.ProductId)
            //                 .HasAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_ProdCat_ProdId_ProdCatId",1)))
            //                 .IsRequired();

            //entityTypeBuilder.HasOne(k => k.ProductCategory)
            //                 .WithMany(k => k.ProductCategoryRelations)
            //                 .HasForeignKey(k=> k.ProductCategoryId)
            //                 .HasAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_ProdCat_ProdId_ProdCatId", 2)))
            //                 .IsRequired();

            #endregion Table, Key and Column Configuration
        }
    }
}
