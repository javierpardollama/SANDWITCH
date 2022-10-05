
using System;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Sandwitch.Tier.Entities.Classes;

namespace Sandwitch.Tier.Contexts.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IApplicationContext"/> interface. Inherits <see cref="IDisposable"/>.
    /// </summary>
    public interface IApplicationContext : IDisposable
    {

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Provincia}"/>
        /// </summary>
        DbSet<Provincia> Provincia { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Poblacion}"/>
        /// </summary>
        DbSet<Poblacion> Poblacion { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Bandera}"/>
        /// </summary>
        DbSet<Bandera> Bandera { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Arenal}"/>
        /// </summary>
        DbSet<Arenal> Arenal { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{ArenalPoblacion}"/>
        /// </summary>
        DbSet<ArenalPoblacion> ArenalPoblacion { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Historico}"/>
        /// </summary>
        DbSet<Historico> Historico { get; set; }

        /// <summary>
        /// Saves Changes Syncronously
        /// </summary>
        /// <returns>Instance of <see cref="int"/></returns>
        int SaveChanges();

        /// <summary>
        /// Saves Changes Asyncronously
        /// </summary>
        /// <returns>Instance of <see cref="Task{int}"/></returns>
        Task<int> SaveChangesAsync();
    }
}
