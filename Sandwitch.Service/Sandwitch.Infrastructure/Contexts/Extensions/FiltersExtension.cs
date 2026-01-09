using Microsoft.EntityFrameworkCore;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Infrastructure.Contexts.Extensions;

/// <summary>
///     Represents a <see cref="FiltersExtension" /> class.
/// </summary>
public static class FiltersExtension
{

    public const string SoftDeleteFilter = nameof(SoftDeleteFilter);

    /// <summary>
    ///     Extends Customized Filters
    /// </summary>
    /// <param name="this">Injected <see cref="ModelBuilder" /></param>
    public static void AddCustomizedFilters(this ModelBuilder @this)
    {
        // Configure entity filters           
        @this.Entity<State>().HasQueryFilter(SoftDeleteFilter, p => !p.Deleted);
        @this.Entity<Town>().HasQueryFilter(SoftDeleteFilter, p => !p.Deleted);
        @this.Entity<Flag>().HasQueryFilter(SoftDeleteFilter, p => !p.Deleted);
        @this.Entity<Wind>().HasQueryFilter(SoftDeleteFilter, p => !p.Deleted);
        @this.Entity<Beach>().HasQueryFilter(SoftDeleteFilter, p => !p.Deleted);
        @this.Entity<BeachTown>().HasQueryFilter(SoftDeleteFilter, p => !p.Deleted);
        @this.Entity<Historic>().HasQueryFilter(SoftDeleteFilter, p => !p.Deleted);
    }
}