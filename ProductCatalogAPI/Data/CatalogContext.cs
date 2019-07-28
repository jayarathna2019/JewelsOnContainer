using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Data
{
    public class CatalogContext : DbContext
    {
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogBrand>(ConfigureCatalogBrand);
            modelBuilder.Entity<CatalogType>(ConfigureCatalogType);
            modelBuilder.Entity<CatalogItem>(ConfigureCatalogItem);
        }
        private void ConfigureCatalogBrand(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.ToTable("CatalogBrands");
            builder.Property(c => c.Id).IsRequired().ForSqlServerUseSequenceHiLo("Catalog_Brand_Hilo");
            builder.property(c => c.brand).IsRequired().HasMaxLength(100);
        }

        private void ConfigureCatalogType(EntityTypeBuilder<CatalogType>builder)
        {
           builder.ToTable("CatalogTypes");
           builder.Property(c => c.Id).IsRequired().ForSqlServerUseSequenceHiLo("Catalog_Type_HiLo");
           builder.property(c => c.type).IsRequired().HasMaxLength(100);
        }
        private void ConfigureCatalogItem(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("Catalog");
            builder.Property(c => c.Id).IsRequired().ForSqlServerUseSequenceHiLo("Catalog_HiLo");
            builder.property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.property(c => c.price).IsRequired();
            builder.HasOne(c => c.CatalogType).WithMany().HasForeignKey(c => c.CatalogTypeId);
            builder.HasOne(c => c.CatalogBrand).WithMany().HasForeignKey(c => c.CatalogBrandId);
        }
    }
}
