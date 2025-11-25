using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Profiles
{
    /// <summary>
    /// Represents a <see cref="PoblacionProfile"/> class.
    /// </summary>
    public static class PoblacionProfile
    {
        /// <summary>
        /// Transforms to Dto
        /// </summary>
        /// <param name="entity">Injected <see cref="Poblacion"/></param>
        /// <returns>Instance of <see cref="PoblacionDto"/></returns>
        public static PoblacionDto ToDto(this Poblacion @entity)
        {
            return new PoblacionDto
            {
                Id = @entity.Id,
                Name = @entity.Name,
                ImageUri = @entity.ImageUri,
                LastModified = @entity.LastModified,
                Provincia = entity.Provincia?.ToCatalog()
            };
        }

        /// <summary>
        /// Transforms to Catalog Dto
        /// </summary>
        /// <param name="entity">Injected <see cref="Poblacion"/></param>
        /// <returns>Instance of <see cref="CatalogDto"/></returns>
        public static CatalogDto ToCatalog(this Poblacion @entity)
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
        /// <param name="entity">Injected <see cref="Poblacion"/></param>
        /// <returns>Instance of <see cref="CatalogDto"/></returns>
        public static BuscadorDto ToFinder(this Poblacion @entity)
        {
            return new BuscadorDto
            {
                Id = @entity.Id,
                ImageUri = @entity.ImageUri,
                Name = @entity.Name,
                Group = nameof(Poblacion),                
            };
        }
    }
}
