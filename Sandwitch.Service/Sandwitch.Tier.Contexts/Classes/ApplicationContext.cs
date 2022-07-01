
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using Sandwitch.Tier.Contexts.Extensions;
using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Entities.Classes;

namespace Sandwitch.Tier.Contexts.Classes
{
    /// <summary>
    /// Represents a <see cref="ApplicationContext"/> class. Inherits <see cref="DbContext"/>. Implements <see cref="IApplicationContext"/>
    /// </summary>
    public class ApplicationContext : DbContext, IApplicationContext
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="ApplicationContext"/>
        /// </summary>
        /// <param name="options">Injected <see cref="DbContextOptions{ApplicationContext}"/></param>
        public ApplicationContext(DbContextOptions<ApplicationContext> @options) : base(@options)
        {
        }

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
        /// Saves Changes Syncronously
        /// </summary>
        /// <returns>Instance of <see cref="int"/></returns>
        public override int SaveChanges()
        {
            UpdateSoftStatus();
            return base.SaveChanges();
        }

        /// <summary>
        /// Saves Changes Asyncronously
        /// </summary>
        /// <returns>Instance of <see cref="Task{int}"/></returns>
        public async Task<int> SaveChangesAsync()
        {
            UpdateSoftStatus();
            return await base.SaveChangesAsync();
        }

        /// <summary>
        /// Overrides Tracking
        /// </summary>
        private void UpdateSoftStatus()
        {
            foreach (EntityEntry entity in ChangeTracker.Entries())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.CurrentValues["LastModified"] = DateTime.Now;
                        entity.State = EntityState.Added;
                        entity.CurrentValues["Deleted"] = false;
                        break;

                    case EntityState.Modified:
                        entity.CurrentValues["LastModified"] = DateTime.Now;
                        entity.State = EntityState.Modified;
                        entity.CurrentValues["Deleted"] = false;
                        break;

                    case EntityState.Deleted:
                        entity.CurrentValues["LastModified"] = DateTime.Now;
                        entity.State = EntityState.Modified;
                        entity.CurrentValues["Deleted"] = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Overrides Model Creation
        /// </summary>
        /// <param name="modelBuilder">Injected <see cref="ModelBuilder"/></param>
        protected override void OnModelCreating(ModelBuilder @modelBuilder)
        {
            @modelBuilder.AddCustomizedFilters();
        }
    }
}
