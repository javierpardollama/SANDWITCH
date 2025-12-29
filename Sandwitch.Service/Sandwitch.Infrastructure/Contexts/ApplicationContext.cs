using Microsoft.EntityFrameworkCore;
using Sandwitch.Domain.Entities;
using Sandwitch.Infrastructure.Contexts.Extensions;
using Sandwitch.Infrastructure.Contexts.Interfaces;

namespace Sandwitch.Infrastructure.Contexts;

/// <summary>
///     Represents a <see cref="ApplicationContext" /> class. Inherits <see cref="DbContext" />. Implements
///     <see cref="IApplicationContext" />
/// </summary>
/// <param name="options">Injected <see cref="DbContextOptions{ApplicationContext}" /></param>
public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options), IApplicationContext
{
    /// <summary>
    ///     Gets or Sets <see cref="DbSet{State}" />
    /// </summary>
    public virtual DbSet<State> State { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{Town}" />
    /// </summary>
    public virtual DbSet<Town> Town { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{Flag}" />
    /// </summary>
    public virtual DbSet<Flag> Flag { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{Wind}" />
    /// </summary>
    public virtual DbSet<Wind> Wind { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{Beach}" />
    /// </summary>
    public virtual DbSet<Beach> Beach { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{BeachTown}" />
    /// </summary>
    public virtual DbSet<BeachTown> BeachTown { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{Historic}" />
    /// </summary>
    public virtual DbSet<Historic> Historic { get; set; }

    /// <summary>
    ///     Overrides Model Creation
    /// </summary>
    /// <param name="modelBuilder">Injected <see cref="ModelBuilder" /></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddCustomizedFilters();
    }
}