using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Profiles;

/// <summary>
/// Represents a <see cref="FlagProfile"/> class.
/// </summary>
public static class FlagProfile
{
    /// <summary>
    /// Transforms to Dto
    /// </summary>
    /// <param name="entity">Injected <see cref="Flag"/></param>
    /// <returns>Instance of <see cref="FlagDto"/></returns>
    public static FlagDto ToDto(this Flag @entity)
    {
        return new FlagDto
        {
            Id = @entity.Id,
            Name = @entity.Name,
            ImageUri = @entity.ImageUri,
            LastModified = @entity.LastModified
        };
    }

    /// <summary>
    /// Transforms to Catalog Dto
    /// </summary>
    /// <param name="entity">Injected <see cref="ApplicationRole"/></param>
    /// <returns>Instance of <see cref="CatalogDto"/></returns>
    public static CatalogDto ToCatalog(this Flag @entity)
    {
        return new CatalogDto
        {
            Id = @entity.Id,
            Name = @entity.Name,
            ImageUri = @entity.ImageUri
        };
    }
}
