using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Profiles
{
    /// <summary>
    /// Represents a <see cref="ArenalProfile"/> class.
    /// </summary>
    public static class ArenalProfile
    {
        /// <summary>
        /// Transforms to Dto
        /// </summary>
        /// <param name="entity">Injected <see cref="Poblacion"/></param>
        /// <returns>Instance of <see cref="PoblacionDto"/></returns>
        public static ArenalDto ToDto(this Arenal @entity)
        {
            return new ArenalDto
            {
                Id = @entity.Id,
                Name = @entity.Name,               
                LastModified = @entity.LastModified,
                Poblaciones = [.. entity.ArenalPoblaciones.Select(x=> x.Poblacion?.ToCatalog())],
                LastHistorico = entity.Historicos.OrderByDescending(x=> x.LastModified).FirstOrDefault()?.ToDto()
            };
        }

        /// <summary>
        /// Transforms to Catalog Dto
        /// </summary>
        /// <param name="entity">Injected <see cref="Arenal"/></param>
        /// <returns>Instance of <see cref="CatalogDto"/></returns>
        public static CatalogDto ToCatalog(this Arenal @entity)
        {
            return new CatalogDto
            {
                Id = @entity.Id,
                Name = @entity.Name                
            };
        }
    }
}
