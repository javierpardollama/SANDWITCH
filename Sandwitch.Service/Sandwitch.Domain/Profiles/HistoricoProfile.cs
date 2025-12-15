using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Profiles;

/// <summary>
/// Represents a <see cref="HistoricoProfile"/> class.
/// </summary>
public static class HistoricoProfile
{
    /// <summary>
    /// Transforms to Dto
    /// </summary>
    /// <param name="entity">Injected <see cref="Historico"/></param>
    /// <returns>Instance of <see cref="HistoricoDto"/></returns>
    public static HistoricoDto ToDto(this Historico @entity)
    {
        return new HistoricoDto
        {
          Id = @entity.Id,
          LastModified = @entity.LastModified,
          AltaMarAlba = @entity.AltaMarAlba,
          AltaMarOcaso = @entity.AltaMarOcaso,
          Arenal = entity.Arenal?.ToCatalog(),
          BajaMarAlba = @entity.BajaMarAlba,
          BajaMarOcaso = entity.BajaMarOcaso,
          Bandera = entity.Bandera?.ToCatalog(),
          Temperatura = entity.Temperatura,
          Velocidad = entity.Velocidad,
          Viento = entity.Viento?.ToCatalog()
        };
    }
}
