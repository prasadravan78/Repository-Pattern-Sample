namespace RepositoryPatternDemo.DAL.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RepositoryPatternDemo.Entity.Entities;

    /// <summary>
    /// Provides Code first entity configuration for Product.
    /// </summary>
    public class ProductConfiguration
    {
        /// <summary>
        /// Holds entity configuration for Product.
        /// </summary>
        public ProductConfiguration(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            #region Table, Key and Column Configuration

            entityTypeBuilder.HasKey(c => c.Id);

            entityTypeBuilder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                ;

            entityTypeBuilder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255)
                ;

            #endregion Table, Key and Column Configuration
        }
    }
}
