using Sandwitch.Domain.Dtos;
using Sandwitch.Domain.Entities;

namespace Sandwitch.Domain.Profiles;

/// <summary>
/// Represents a <see cref="HistoricProfile"/> class.
/// </summary>
public static class HistoricProfile
{
    /// <summary>
    /// Transforms to Dto
    /// </summary>
    /// <param name="entity">Injected <see cref="Historic"/></param>
    /// <returns>Instance of <see cref="HistoricDto"/></returns>
    public static HistoricDto ToDto(this Historic @entity)
    {
        return new HistoricDto
        {
          Id = @entity.Id,
          LastModified = @entity.LastModified,
          HighSeaDawn = @entity.HighSeaDawn,
          HighSeaSunset = @entity.HighSeaSunset,
          Beach = entity.Beach?.ToCatalog(),
          LowSeaDawn = @entity.LowSeaDawn,
          LowSeaSunset = entity.LowSeaSunset,
          Flag = entity.Flag?.ToCatalog(),
          Temperature = entity.Temperature,
          Speed = entity.Speed,
          Wind = entity.Wind?.ToCatalog()
        };
    }
}
