using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Entities.Classes;

namespace Sandwitch.Tier.Contexts.Classes
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Provincia> Provincia { get; set; }

        public DbSet<Poblacion> Poblacion { get; set; }

        public DbSet<Bandera> Bandera { get; set; }

        public DbSet<Arenal> Arenal { get; set; }

        public DbSet<ArenalPoblacion> ArenalPoblacion { get; set; }

        public DbSet<Historico> Historico { get; set; }

        public override int SaveChanges()
        {
            this.UpdateSoftStatus();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            this.UpdateSoftStatus();
            return await base.SaveChangesAsync();
        }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
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
