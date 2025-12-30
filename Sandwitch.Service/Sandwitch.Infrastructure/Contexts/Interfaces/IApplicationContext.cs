using Microsoft.EntityFrameworkCore;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Infrastructure.Contexts.Interfaces;

/// <summary>
///     Represents a <see cref="IApplicationContext" /> interface. Inherits <see cref="IDisposable" />.
/// </summary>
public interface IApplicationContext : IDisposable
{
    /// <summary>
    ///     Gets or Sets <see cref="DbSet{State}" />
    /// </summary>
    public DbSet<State> State { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{Town}" />
    /// </summary>
    public DbSet<Town> Town { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{Flag}" />
    /// </summary>
    public DbSet<Flag> Flag { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{Wind}" />
    /// </summary>
    public DbSet<Wind> Wind { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{Beach}" />
    /// </summary>
    public DbSet<Beach> Beach { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{BeachTown}" />
    /// </summary>
    public DbSet<BeachTown> BeachTown { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{Historic}" />
    /// </summary>
    public DbSet<Historic> Historic { get; set; }

    /// <summary>
    ///     Saves Changes Syncronously
    /// </summary>
    /// <returns>Instance of <see cref="int" /></returns>
    public int SaveChanges();

    /// <summary>
    ///     Saves Changes Asyncronously
    /// </summary>
    /// <param name="cancellationToken">Injected <see cref="CancellationToken" /></param>
    /// <returns>Instance of <see cref="Task{int}" /></returns>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}