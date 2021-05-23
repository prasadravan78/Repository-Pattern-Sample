namespace RepositoryPatternDemo.DAL.DBContext
{
    using Microsoft.EntityFrameworkCore;
    using RepositoryPatternDemo.DAL.EntityConfigurations;
    using RepositoryPatternDemo.Entity.Entities;

    /// <summary>
    /// Provides in-memory representation of database as a database context.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Configures various settings related to DB context.
        /// </summary>
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        /// <summary>
        /// Sets collection of given entity.
        /// </summary>
        /// <typeparam name="TEntity">Type of entity</typeparam>
        /// <returns>Collection the given entity</returns>
        public new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// Overridden method for adding entity and additional configurations while creating the model database.
        /// </summary>
        /// <param name="modelBuilder">Db model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder != null)
            {
                base.OnModelCreating(modelBuilder);
                _ = modelBuilder.Entity<ProductCategoryRelation>().HasIndex(k => new { k.ProductId, k.ProductCategoryId }).HasDatabaseName("IX_ProdCat_ProdId_ProdCatId");
                _ = new AuditLogConfiguration(modelBuilder.Entity<AuditLog>().ToTable("AuditLog"));
                _ = new ProductConfiguration(modelBuilder.Entity<Product>().ToTable("Product"));
                _ = new ProductCategoryConfiguration(modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory"));
                _ = new ProductCategoryRelationConfiguration(modelBuilder.Entity<ProductCategoryRelation>().ToTable("ProductCategoryRelation"));
            }
        }
    }
}
