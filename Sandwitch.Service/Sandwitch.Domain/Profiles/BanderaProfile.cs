using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Profiles
{
    /// <summary>
    /// Represents a <see cref="BanderaProfile"/> class.
    /// </summary>
    public static class BanderaProfile
    {
        /// <summary>
        /// Transforms to Dto
        /// </summary>
        /// <param name="entity">Injected <see cref="Bandera"/></param>
        /// <returns>Instance of <see cref="BanderaDto"/></returns>
        public static BanderaDto ToDto(this Bandera @entity)
        {
            return new BanderaDto
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
        public static CatalogDto ToCatalog(this Bandera @entity)
        {
            return new CatalogDto
            {
                Id = @entity.Id,
                Name = @entity.Name,
                ImageUri = @entity.ImageUri
            };
        }
    }
}
