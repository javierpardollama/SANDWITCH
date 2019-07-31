using Microsoft.EntityFrameworkCore;

using Sandwitch.Tier.Entities.Classes;

namespace Sandwitch.Tier.Contexts.Extensions
{
    public static class FiltersExtension
    {
        public static void AddCustomizedFilters(this ModelBuilder @this)
        {
            // Configure entity filters           
            @this.Entity<Provincia>().HasQueryFilter(p => !p.Deleted);
            @this.Entity<Poblacion>().HasQueryFilter(p => !p.Deleted);
            @this.Entity<Bandera>().HasQueryFilter(p => !p.Deleted);
            @this.Entity<Arenal>().HasQueryFilter(p => !p.Deleted);
            @this.Entity<ArenalPoblacion>().HasQueryFilter(p => !p.Deleted);
            @this.Entity<Historico>().HasQueryFilter(p => !p.Deleted);
        }
    }
}
