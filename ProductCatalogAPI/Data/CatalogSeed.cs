using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI.Data
{
    public static class CatalogSeed
    {
        public static void Seed(CatalogContext context)
        {
            if(!context.CatalogBrands.Any())
            {
                context.CatalogBrands.AddRange(GetPreConfiguredCatalogBrands());
                context.SaveChanges();

            }
        }
        private static IEnumerable<CatalogBrand>
            GetPreConfiguredCatalogBrands()
        {
            return new List<CatalogBrand>()
            {
                new CatalogBrand() {Brand="Tiffany & co."},
                new CatalogBrand() {Brand="DeBeers"},
                new CatalogBrand() {Brand="Graff"}
            }
        }
    }

}
