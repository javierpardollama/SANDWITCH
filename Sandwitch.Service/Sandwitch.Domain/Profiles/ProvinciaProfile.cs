using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Profiles
{
    /// <summary>
    /// Represents a <see cref="ProvinciaProfile"/> class.
    /// </summary>
    public static class ProvinciaProfile
    {
        /// <summary>
        /// Transforms to Dto
        /// </summary>
        /// <param name="entity">Injected <see cref="Provincia"/></param>
        /// <returns>Instance of <see cref="ProvinciaDto"/></returns>
        public static ProvinciaDto ToDto(this Provincia @entity)
        {
            return new ProvinciaDto
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
        /// <param name="entity">Injected <see cref="Provincia"/></param>
        /// <returns>Instance of <see cref="CatalogDto"/></returns>
        public static CatalogDto ToCatalog(this Provincia @entity)
        {
            return new CatalogDto
            {
                Id = @entity.Id,
                Name = @entity.Name,
                ImageUri = @entity.ImageUri,
            };
        }

        /// <summary>
        /// Transforms to Buscador Dto
        /// </summary>
        /// <param name="entity">Injected <see cref="Provincia"/></param>
        /// <returns>Instance of <see cref="CatalogDto"/></returns>
        public static BuscadorDto ToFinder(this Provincia @entity)
        {
            return new BuscadorDto
            {
                Id = @entity.Id,
                ImageUri = @entity.ImageUri,
                Name = @entity.Name,
                Group = nameof(Provincia),
            };
        }
    }
}
