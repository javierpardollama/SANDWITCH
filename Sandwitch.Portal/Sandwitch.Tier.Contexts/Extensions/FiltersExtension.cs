using Microsoft.EntityFrameworkCore;

using Sandwitch.Tier.Entities.Classes;

namespace Sandwitch.Tier.Contexts.Extensions
{
    public static class FiltersExtension
    {
        public static void AddCustomizedFilters(this ModelBuilder modelBuilder)
        {
            // Configure entity filters           
            modelBuilder.Entity<Provincia>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<Poblacion>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<Bandera>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<Arenal>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<ArenalPoblacion>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<Historico>().HasQueryFilter(p => !p.Deleted);
        }
    }
}
