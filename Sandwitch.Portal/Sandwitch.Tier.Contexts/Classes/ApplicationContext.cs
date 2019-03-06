using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Entities.Classes;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Contexts.Classes
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public DbSet<Provincia> Provincia { get; set; }

        public DbSet<Poblacion> Poblacion { get; set; }

        public DbSet<Bandera> Bandera { get; set; }

        public DbSet<Arenal> Arenal { get; set; }

        public DbSet<ArenalPoblacion> ArenalPoblacion { get; set; }

        public DbSet<Historico> Historico { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
