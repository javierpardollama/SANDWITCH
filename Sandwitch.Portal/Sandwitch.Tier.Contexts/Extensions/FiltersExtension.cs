using Microsoft.EntityFrameworkCore;

using Sandwitch.Tier.Entities.Classes;

namespace Sandwitch.Tier.Contexts.Extensions
{
    /// <summary>
    /// Represents a <see cref="FiltersExtension"/> class.
    /// </summary>
    public static class FiltersExtension
    {
        /// <summary>
        /// Extends Customized Filters
        /// </summary>
        /// <param name="this">Injected <see cref="ModelBuilder"/></param>
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
