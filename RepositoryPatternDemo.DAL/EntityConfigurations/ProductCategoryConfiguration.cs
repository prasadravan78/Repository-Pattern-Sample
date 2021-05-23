namespace RepositoryPatternDemo.DAL.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RepositoryPatternDemo.Entity.Entities;

    /// <summary>
    /// Provides Code first entity configuration for ProductCategory.
    /// </summary>
    public class ProductCategoryConfiguration
    {
        /// <summary>
        /// Holds entity configuration for ProductCategory.
        /// </summary>
        public ProductCategoryConfiguration(EntityTypeBuilder<ProductCategory> entityTypeBuilder)
        {
            #region Table, Key and Column Configuration

            entityTypeBuilder.HasKey(c => c.Id);

            entityTypeBuilder.Property(c => c.Id)
                             .ValueGeneratedOnAdd();

            entityTypeBuilder.Property(c => c.Name)
                             .IsRequired()
                             .HasMaxLength(255);

            #endregion Table, Key and Column Configuration
        }
    }
}
