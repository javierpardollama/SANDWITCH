
using Microsoft.EntityFrameworkCore;

using Sandwitch.Tier.Entities.Classes;

using System;
using System.Threading.Tasks;

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
        public DbSet<Provincia> Provincia { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Poblacion}"/>
        /// </summary>
        public DbSet<Poblacion> Poblacion { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Bandera}"/>
        /// </summary>
        public DbSet<Bandera> Bandera { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Viento}"/>
        /// </summary>
        public DbSet<Viento> Viento { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Arenal}"/>
        /// </summary>
        public DbSet<Arenal> Arenal { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{ArenalPoblacion}"/>
        /// </summary>
        public DbSet<ArenalPoblacion> ArenalPoblacion { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Historico}"/>
        /// </summary>
        public DbSet<Historico> Historico { get; set; }

        /// <summary>
        /// Saves Changes Syncronously
        /// </summary>
        /// <returns>Instance of <see cref="int"/></returns>
        public int SaveChanges();

        /// <summary>
        /// Saves Changes Asyncronously
        /// </summary>
        /// <returns>Instance of <see cref="Task{int}"/></returns>
        public Task<int> SaveChangesAsync();
    }
}
