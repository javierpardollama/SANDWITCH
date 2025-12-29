using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Profiles;

/// <summary>
/// Represents a <see cref="TownProfile"/> class.
/// </summary>
public static class TownProfile
{
    /// <summary>
    /// Transforms to Dto
    /// </summary>
    /// <param name="entity">Injected <see cref="Town"/></param>
    /// <returns>Instance of <see cref="TownDto"/></returns>
    public static TownDto ToDto(this Town @entity)
    {
        return new TownDto
        {
            Id = @entity.Id,
            Name = @entity.Name,
            ImageUri = @entity.ImageUri,
            LastModified = @entity.LastModified,
            State = entity.State?.ToCatalog()
        };
    }

    /// <summary>
    /// Transforms to Catalog Dto
    /// </summary>
    /// <param name="entity">Injected <see cref="Town"/></param>
    /// <returns>Instance of <see cref="CatalogDto"/></returns>
    public static CatalogDto ToCatalog(this Town @entity)
    {
        return new CatalogDto
        {
            Id = @entity.Id,
            Name = @entity.Name,
            ImageUri = @entity.ImageUri,
        };
    }

    /// <summary>
    /// Transforms to Finder Dto
    /// </summary>
    /// <param name="entity">Injected <see cref="Town"/></param>
    /// <returns>Instance of <see cref="CatalogDto"/></returns>
    public static FinderDto ToFinder(this Town @entity)
    {
        return new FinderDto
        {
            Id = @entity.Id,
            ImageUri = @entity.ImageUri,
            Name = @entity.Name,
            Group = nameof(Town),                
        };
    }
}
