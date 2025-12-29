using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Dtos;

namespace Sandwitch.Application.Profiles;

/// <summary>
/// Represents a <see cref="HistoricProfile"/> class.
/// </summary>
public static class HistoricProfile
{
    /// <summary>
    /// Transforms to ViewModel
    /// </summary>
    /// <param name="dto">Injected <see cref="HistoricDto"/></param>
    /// <returns>Instance of <see cref="ViewHistoric"/></returns>
    public static ViewHistoric ToViewModel(this HistoricDto @dto)
    {
        return new ViewHistoric
        {
          Id = @dto.Id,
          LastModified = @dto.LastModified,
          HighSeaDawn = @dto.HighSeaDawn,
          HighSeaSunset = @dto.HighSeaSunset,
          Beach = @dto.Beach?.ToViewModel(),
          LowSeaDawn = @dto.LowSeaDawn,
          LowSeaSunset = @dto.LowSeaSunset,
          Flag = @dto.Flag?.ToViewModel(),
          Temperature = @dto.Temperature,
          Speed = @dto.Speed,
          Wind = @dto.Wind?.ToViewModel()
        };
    }
}
