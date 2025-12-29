using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Profiles;

/// <summary>
/// Represents a <see cref="StateProfile"/> class.
/// </summary>
public static class StateProfile
{
    /// <summary>
    /// Transforms to Dto
    /// </summary>
    /// <param name="entity">Injected <see cref="State"/></param>
    /// <returns>Instance of <see cref="StateDto"/></returns>
    public static StateDto ToDto(this State @entity)
    {
        return new StateDto
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
    /// <param name="entity">Injected <see cref="State"/></param>
    /// <returns>Instance of <see cref="CatalogDto"/></returns>
    public static CatalogDto ToCatalog(this State @entity)
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
    /// <param name="entity">Injected <see cref="State"/></param>
    /// <returns>Instance of <see cref="CatalogDto"/></returns>
    public static FinderDto ToFinder(this State @entity)
    {
        return new FinderDto
        {
            Id = @entity.Id,
            ImageUri = @entity.ImageUri,
            Name = @entity.Name,
            Group = nameof(State),
        };
    }
}
