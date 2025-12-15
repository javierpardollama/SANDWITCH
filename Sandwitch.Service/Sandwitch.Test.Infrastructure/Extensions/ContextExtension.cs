using Microsoft.EntityFrameworkCore;
using Sandwitch.Domain.Entities;
using Sandwitch.Infrastructure.Contexts;
using System;
using System.Linq;

namespace Sandwitch.Test.Infrastructure.Extensions;

public static class ContextExtension
{
    public static void Seed(this ApplicationContext @this) 
    {
        @this.Database.EnsureDeleted();
        @this.Database.EnsureCreated();

        if (!@this.Viento.Any())
        {
            @this.Viento.Add(new Viento
            {
                Id = 1,
                Name = "Norte",
                ImageUri = "URL/Norte_500.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
            @this.Viento.Add(new Viento
            {
                Id = 2,
                Name = "Noroeste",
                ImageUri = "URL/Noroeste_500.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
            @this.Viento.Add(new Viento
            {
                Id = 3,
                Name = "Oeste",
                ImageUri = "URL/Oeste_500.png",
                LastModified = DateTime.Now,
                Deleted = false
            });

            @this.SaveChanges();
        }

        if (!@this.Bandera.Any())
        {
            @this.Bandera.Add(new Bandera
            {
                Id = 1,
                Name = "Amarilla ",
                ImageUri = "URL/Amarilla_500.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
            @this.Bandera.Add(new Bandera
            {
                Id = 2,
                Name = "Negra",
                ImageUri = "URL/Negra_500.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
            @this.Bandera.Add(new Bandera
            {
                Id = 3,
                Name = "Roja",
                ImageUri = "URL/Roja_500.png",
                LastModified = DateTime.Now,
                Deleted = false
            });

            @this.SaveChanges();
        }

        if (!@this.Provincia.Any())
        {
            @this.Provincia.Add(new Provincia
            {
                Id = 1,
                Name = "Bizkaia",
                ImageUri = "URL/Bizkaia_500px.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
            @this.Provincia.Add(new Provincia
            {
                Id = 2,
                Name = "Gipuzkoa",
                ImageUri = "URL/Gipuzkoa_500px.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
            @this.Provincia.Add(new Provincia
            {
                Id = 3,
                Name = "Cantabria",
                ImageUri = "URL/Cantabria_500px.png",
                LastModified = DateTime.Now,
                Deleted = false
            });

            @this.SaveChanges();
        }

        if (!@this.Poblacion.Any())
        {
            @this.Poblacion.Add(new Poblacion
            {
                Id = 1,
                Name = "Zierbena",
                ImageUri = "URL/Zierbena_500px.png",
                ProvinciaId = 1,
                LastModified = DateTime.Now,
                Deleted = false
            });

            @this.Poblacion.Add(new Poblacion
            {
                Id = 2,
                Name = "Muskiz",
                ImageUri = "URL/Muskiz_500px.png",
                ProvinciaId = 1,
                LastModified = DateTime.Now,
                Deleted = false
            });

            @this.Poblacion.Add(new Poblacion
            {
                Id = 3,
                Name = "Getxo",
                ImageUri = "URL/Getxo_500px.png",
                ProvinciaId = 1,
                LastModified = DateTime.Now,
                Deleted = false
            });

            @this.SaveChanges();

        }

        if (!@this.Arenal.Any())
        {
            @this.Arenal.Add(new Arenal
            {
                Id = 1,
                Name = "Las Arenas",
                LastModified = DateTime.Now,
                Deleted = false,
                ArenalPoblaciones = [
                new()
            {
                ArenalId = 1,
                PoblacionId = 3,
            }
                ]
            });

            @this.Arenal.Add(new Arenal
            {
                Id = 2,
                Name = "La Arena",
                LastModified = DateTime.Now,
                Deleted = false,
                ArenalPoblaciones = [
                  new()
            {
                ArenalId = 2,
                PoblacionId = 2,
            }
                  ]
            });

            @this.SaveChanges();
        }
        if (!@this.Historico.Any())
        {
            @this.Historico.Add(new Historico()
            {
                Id = 1,
                LastModified = DateTime.Now,
                Deleted = false,
                BajaMarAlba = DateTime.Now.TimeOfDay,
                BajaMarOcaso = DateTime.Now.TimeOfDay,
                AltaMarAlba = DateTime.Now.TimeOfDay,
                AltaMarOcaso = DateTime.Now.TimeOfDay,
                Temperatura = 20,
                Velocidad = 0,
                ArenalId = 1,
                VientoId = 1,
                BanderaId = 1,
            });

            @this.SaveChanges();
        }            
    }
}
