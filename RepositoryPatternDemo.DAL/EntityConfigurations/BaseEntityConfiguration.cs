namespace RepositoryPatternDemo.DAL.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RepositoryPatternDemo.Entity.Entities;

    /// <summary>
    /// Provides Code first entity configuration for Base Entity.
    /// </summary>
    public class BaseEntityConfiguration
    {
        /// <summary>
        /// Holds entity configuration for the base entity.
        /// </summary>
        public BaseEntityConfiguration(EntityTypeBuilder<BaseEntity> entityTypeBuilder)
        {
            entityTypeBuilder.Property(c => c.IsActive)
                .HasDefaultValueSql("0")
               ;

            entityTypeBuilder.Property(c => c.CreatedBy)
                .IsRequired()
                .HasMaxLength(200)
                ;

            entityTypeBuilder.Property(c => c.CreationDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasPrecision(3)
                ;

            entityTypeBuilder.Property(c => c.ModifiedBy)
                .IsRequired()
                .HasMaxLength(200)
                ;

            entityTypeBuilder.Property(c => c.ModificationDate)
                .IsRequired()
                .HasColumnType("datetime2")
                .HasPrecision(3)
                ;

            entityTypeBuilder.Property(c => c.RowVersion)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .IsRowVersion()
                .IsConcurrencyToken()
                ;
        }
    }
}
