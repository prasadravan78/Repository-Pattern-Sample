namespace RepositoryPatternDemo.DAL.EntityConfigurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using RepositoryPatternDemo.Entity.Entities;

    /// <summary>
    /// Provides Code first entity configuration for AuditLog.
    /// </summary>
    public class AuditLogConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuditLogConfiguration"/> class.
        /// </summary>
        /// <param name="entityTypeBuilder">Injects AuditLog dependancy.</param>
        public AuditLogConfiguration(EntityTypeBuilder<AuditLog> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(c => c.Id);

            entityTypeBuilder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                ;

            entityTypeBuilder.Property(c => c.Date)
                .IsRequired()
                ;

            entityTypeBuilder.Property(c => c.Level)
                .IsRequired()
                .HasMaxLength(50)
                ;

            entityTypeBuilder.Property(c => c.Logger)
                .IsRequired()
                .HasMaxLength(255)
                ;

            entityTypeBuilder.Property(c => c.Message)
                .IsRequired()
                .HasMaxLength(500)
                ;

            entityTypeBuilder.Property(c => c.UserId)
                .IsRequired()
                .HasMaxLength(200)
                ;

            entityTypeBuilder.Property(c => c.UserName)
                .IsRequired()
                .HasMaxLength(200)
                ;

            entityTypeBuilder.Property(c => c.Controller)
                .HasMaxLength(100)
                ;

            entityTypeBuilder.Property(c => c.Action)
                .HasMaxLength(100)
                ;
        }
    }
}
