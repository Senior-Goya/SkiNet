
using System.Linq;
using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected  override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            if(Database.ProviderName == "Microsoft.EntityFrameworkCore.Sqlite")
            {
                foreach(var entityType in model.Model.GetEntityTypes())
                {
                    var prop = entityType.ClrType.GetProperties().Where(p => p.PropertyType == typeof(decimal));
                    foreach(var p in prop)
                    {
                        model.Entity(entityType.Name).Property(p.Name).HasConversion<double>();
                    }

                }
            }
        }

    }
}