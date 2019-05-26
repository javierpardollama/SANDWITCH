using Microsoft.EntityFrameworkCore;
using Sandwitch.Tier.Entities.Classes;
using System;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Contexts.Interfaces
{
    public interface IApplicationContext : IDisposable
    {
        DbSet<Provincia> Provincia { get; set; }

        DbSet<Poblacion> Poblacion { get; set; }

        DbSet<Bandera> Bandera { get; set; }

        DbSet<Arenal> Arenal { get; set; }

        DbSet<ArenalPoblacion> ArenalPoblacion { get; set; }

        DbSet<Historico> Historico { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
