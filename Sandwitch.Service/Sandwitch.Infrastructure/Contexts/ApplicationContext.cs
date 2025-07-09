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
    ///     Gets or Sets <see cref="DbSet{Provincia}" />
    /// </summary>
    public virtual DbSet<Provincia> Provincia { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{Poblacion}" />
    /// </summary>
    public virtual DbSet<Poblacion> Poblacion { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{Bandera}" />
    /// </summary>
    public virtual DbSet<Bandera> Bandera { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{Viento}" />
    /// </summary>
    public virtual DbSet<Viento> Viento { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{Arenal}" />
    /// </summary>
    public virtual DbSet<Arenal> Arenal { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{ArenalPoblacion}" />
    /// </summary>
    public virtual DbSet<ArenalPoblacion> ArenalPoblacion { get; set; }

    /// <summary>
    ///     Gets or Sets <see cref="DbSet{Historico}" />
    /// </summary>
    public virtual DbSet<Historico> Historico { get; set; }

    /// <summary>
    ///     Overrides Model Creation
    /// </summary>
    /// <param name="modelBuilder">Injected <see cref="ModelBuilder" /></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddCustomizedFilters();
    }
}