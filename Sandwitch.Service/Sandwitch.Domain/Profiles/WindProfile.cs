using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Profiles;

/// <summary>
/// Represents a <see cref="WindProfile"/> class.
/// </summary>
public static class WindProfile
{
    /// <summary>
    /// Transforms to Dto
    /// </summary>
    /// <param name="entity">Injected <see cref="Wind"/></param>
    /// <returns>Instance of <see cref="FlagDto"/></returns>
    public static WindDto ToDto(this Wind @entity)
    {
        return new WindDto
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
    /// <param name="entity">Injected <see cref="Wind"/></param>
    /// <returns>Instance of <see cref="CatalogDto"/></returns>
    public static CatalogDto ToCatalog(this Wind @entity)
    {
        return new CatalogDto
        {
            Id = @entity.Id,
            Name = @entity.Name,
            ImageUri = @entity.ImageUri,
        };
    }
}
