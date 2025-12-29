using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Profiles;

/// <summary>
/// Represents a <see cref="BeachProfile"/> class.
/// </summary>
public static class BeachProfile
{
    /// <summary>
    /// Transforms to Dto
    /// </summary>
    /// <param name="entity">Injected <see cref="Town"/></param>
    /// <returns>Instance of <see cref="TownDto"/></returns>
    public static BeachDto ToDto(this Beach @entity)
    {
        return new BeachDto
        {
            Id = @entity.Id,
            Name = @entity.Name,               
            LastModified = @entity.LastModified,
            Towns = [.. entity.BeachTowns.Select(x=> x.Town?.ToCatalog())],
            LastHistoric = entity.Historics.OrderByDescending(x=> x.LastModified).FirstOrDefault()?.ToDto()
        };
    }

    /// <summary>
    /// Transforms to Catalog Dto
    /// </summary>
    /// <param name="entity">Injected <see cref="Beach"/></param>
    /// <returns>Instance of <see cref="CatalogDto"/></returns>
    public static CatalogDto ToCatalog(this Beach @entity)
    {
        return new CatalogDto
        {
            Id = @entity.Id,
            Name = @entity.Name                
        };
    }
}
