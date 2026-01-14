using Microsoft.EntityFrameworkCore;
using Sandwitch.Domain.Entities;
using Sandwitch.Infrastructure.Contexts;
using System;
using System.Linq;

namespace Sandwitch.Test.Infrastructure.Extensions;

/// <summary>
/// Represents a <see cref="ContextExtension"/> class.
/// </summary>
public static class ContextExtension
{
    /// <summary>
    /// Seeds
    /// </summary>
    /// <param name="this">Injected <see cref="ApplicationContext"/></param>
    public static void Seed(this ApplicationContext @this) 
    {
        @this.Database.EnsureDeleted();
        @this.Database.EnsureCreated();

        if (!@this.Wind.Any())
        {
            @this.Wind.Add(new Wind
            {
                Id = 1,
                Name = "Norte",
                ImageUri = "URL/Norte_500.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
            @this.Wind.Add(new Wind
            {
                Id = 2,
                Name = "Noroeste",
                ImageUri = "URL/Noroeste_500.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
            @this.Wind.Add(new Wind
            {
                Id = 3,
                Name = "Oeste",
                ImageUri = "URL/Oeste_500.png",
                LastModified = DateTime.Now,
                Deleted = false
            });

            @this.SaveChanges();
        }

        if (!@this.Flag.Any())
        {
            @this.Flag.Add(new Flag
            {
                Id = 1,
                Name = "Amarilla ",
                ImageUri = "URL/Amarilla_500.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
            @this.Flag.Add(new Flag
            {
                Id = 2,
                Name = "Negra",
                ImageUri = "URL/Negra_500.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
            @this.Flag.Add(new Flag
            {
                Id = 3,
                Name = "Roja",
                ImageUri = "URL/Roja_500.png",
                LastModified = DateTime.Now,
                Deleted = false
            });

            @this.SaveChanges();
        }

        if (!@this.State.Any())
        {
            @this.State.Add(new State
            {
                Id = 1,
                Name = "Bizkaia",
                ImageUri = "URL/Bizkaia_500px.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
            @this.State.Add(new State
            {
                Id = 2,
                Name = "Gipuzkoa",
                ImageUri = "URL/Gipuzkoa_500px.png",
                LastModified = DateTime.Now,
                Deleted = false
            });
            @this.State.Add(new State
            {
                Id = 3,
                Name = "Cantabria",
                ImageUri = "URL/Cantabria_500px.png",
                LastModified = DateTime.Now,
                Deleted = false
            });

            @this.SaveChanges();
        }

        if (!@this.Town.Any())
        {
            @this.Town.Add(new Town
            {
                Id = 1,
                Name = "Zierbena",
                ImageUri = "URL/Zierbena_500px.png",
                StateId = 1,
                LastModified = DateTime.Now,
                Deleted = false
            });

            @this.Town.Add(new Town
            {
                Id = 2,
                Name = "Muskiz",
                ImageUri = "URL/Muskiz_500px.png",
                StateId = 1,
                LastModified = DateTime.Now,
                Deleted = false
            });

            @this.Town.Add(new Town
            {
                Id = 3,
                Name = "Getxo",
                ImageUri = "URL/Getxo_500px.png",
                StateId = 1,
                LastModified = DateTime.Now,
                Deleted = false
            });

            @this.SaveChanges();

        }

        if (!@this.Beach.Any())
        {
            @this.Beach.Add(new Beach
            {
                Id = 1,
                Name = "Las Arenas",
                LastModified = DateTime.Now,
                Deleted = false,
                BeachTowns = [
                new()
            {
                BeachId = 1,
                TownId = 3,
            }
                ]
            });

            @this.Beach.Add(new Beach
            {
                Id = 2,
                Name = "La Arena",
                LastModified = DateTime.Now,
                Deleted = false,
                BeachTowns = [
                  new()
            {
                BeachId = 2,
                TownId = 2,
            }
                  ]
            });

            @this.SaveChanges();
        }
        if (!@this.Historic.Any())
        {
            @this.Historic.Add(new Historic()
            {
                Id = 1,
                LastModified = DateTime.Now,
                Deleted = false,
                LowSeaDawn = DateTime.Now.TimeOfDay,
                LowSeaSunset = DateTime.Now.TimeOfDay,
                HighSeaDawn = DateTime.Now.TimeOfDay,
                HighSeaSunset = DateTime.Now.TimeOfDay,
                Temperature = 20,
                Speed = 0,
                BeachId = 1,
                WindId = 1,
                FlagId = 1,
            });

            @this.SaveChanges();
        }            
    }
}
