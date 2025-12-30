using Microsoft.EntityFrameworkCore;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Infrastructure.Contexts.Extensions;

/// <summary>
///     Represents a <see cref="FiltersExtension" /> class.
/// </summary>
public static class FiltersExtension
{
    /// <summary>
    ///     Extends Customized Filters
    /// </summary>
    /// <param name="this">Injected <see cref="ModelBuilder" /></param>
    public static void AddCustomizedFilters(this ModelBuilder @this)
    {
        // Configure entity filters           
        @this.Entity<State>().HasQueryFilter(p => !p.Deleted);
        @this.Entity<Town>().HasQueryFilter(p => !p.Deleted);
        @this.Entity<Flag>().HasQueryFilter(p => !p.Deleted);
        @this.Entity<Wind>().HasQueryFilter(p => !p.Deleted);
        @this.Entity<Beach>().HasQueryFilter(p => !p.Deleted);
        @this.Entity<BeachTown>().HasQueryFilter(p => !p.Deleted);
        @this.Entity<Historic>().HasQueryFilter(p => !p.Deleted);
    }
}