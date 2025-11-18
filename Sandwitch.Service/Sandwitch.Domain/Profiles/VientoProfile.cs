using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Profiles
{
    /// <summary>
    /// Represents a <see cref="VientoProfile"/> class.
    /// </summary>
    public static class VientoProfile
    {
        /// <summary>
        /// Transforms to Dto
        /// </summary>
        /// <param name="entity">Injected <see cref="Viento"/></param>
        /// <returns>Instance of <see cref="BanderaDto"/></returns>
        public static VientoDto ToDto(this Viento @entity)
        {
            return new VientoDto
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
        /// <param name="entity">Injected <see cref="Viento"/></param>
        /// <returns>Instance of <see cref="CatalogDto"/></returns>
        public static CatalogDto ToCatalog(this Viento @entity)
        {
            return new CatalogDto
            {
                Id = @entity.Id,
                Name = @entity.Name,
                ImageUri = @entity.ImageUri,
            };
        }
    }
}
