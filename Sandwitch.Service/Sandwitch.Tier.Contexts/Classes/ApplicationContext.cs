
using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using Sandwitch.Tier.Contexts.Extensions;
using Sandwitch.Tier.Contexts.Interceptors;
using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Entities.Interfaces;

namespace Sandwitch.Tier.Contexts.Classes
{
    /// <summary>
    /// Represents a <see cref="ApplicationContext"/> class. Inherits <see cref="DbContext"/>. Implements <see cref="IApplicationContext"/>
    /// </summary>    
    /// <param name="options">Injected <see cref="DbContextOptions{ApplicationContext}"/></param>
    public class ApplicationContext(DbContextOptions<ApplicationContext> @options) : DbContext(@options), IApplicationContext
    {

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Provincia}"/>
        /// </summary>
        public virtual DbSet<Provincia> Provincia { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Poblacion}"/>
        /// </summary>
        public virtual DbSet<Poblacion> Poblacion { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Bandera}"/>
        /// </summary>
        public virtual DbSet<Bandera> Bandera { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Viento}"/>
        /// </summary>
        public virtual DbSet<Viento> Viento { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Arenal}"/>
        /// </summary>
        public virtual DbSet<Arenal> Arenal { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{ArenalPoblacion}"/>
        /// </summary>
        public virtual DbSet<ArenalPoblacion> ArenalPoblacion { get; set; }

        /// <summary>
        /// Gets or Sets <see cref="DbSet{Historico}"/>
        /// </summary>
        public virtual DbSet<Historico> Historico { get; set; }       

        /// <summary>
        /// Overrides Model Creation
        /// </summary>
        /// <param name="modelBuilder">Injected <see cref="ModelBuilder"/></param>
        protected override void OnModelCreating(ModelBuilder @modelBuilder) => @modelBuilder.AddCustomizedFilters();

        /// <summary>
        /// Saves Changes Syncronously
        /// </summary>
        /// <returns>Instance of <see cref="int"/></returns>
        public override int SaveChanges()
        {
            //UpdateSoftStatus();
            return base.SaveChanges();
        }

        /// <summary>
        /// Saves Changes Asyncronously
        /// </summary>
        /// <returns>Instance of <see cref="Task{int}"/></returns>
        public async Task<int> SaveChangesAsync()
        {
            //UpdateSoftStatus();
            return await base.SaveChangesAsync();
        }

        /// <summary>
        /// Overrides Tracking
        /// </summary>
        private void UpdateSoftStatus()
        {
            foreach (EntityEntry @entity in ChangeTracker.Entries<IBase>())
            {
                switch (@entity.State)
                {
                    case EntityState.Added:
                        @entity.Property(nameof(IBase.LastModified)).CurrentValue = DateTime.Now;
                        @entity.State = EntityState.Added;
                        @entity.Property(nameof(IBase.Deleted)).CurrentValue = false;
                        break;

                    case EntityState.Modified:
                        @entity.Property(nameof(IBase.LastModified)).CurrentValue = DateTime.Now;
                        @entity.State = EntityState.Modified;
                        @entity.Property(nameof(IBase.Deleted)).CurrentValue = false;
                        break;

                    case EntityState.Deleted:
                        @entity.Property(nameof(IBase.LastModified)).CurrentValue = DateTime.Now;
                        @entity.State = EntityState.Modified;
                        @entity.Property(nameof(IBase.Deleted)).CurrentValue = true;
                        break;
                }
            }
        }
    }
}
