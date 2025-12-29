using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Dtos;

namespace Sandwitch.Application.Profiles;

/// <summary>
/// Represents a <see cref="BeachProfile"/> class.
/// </summary>
public static class BeachProfile
{
    /// <summary>
    /// Transforms to ViewModel
    /// </summary>
    /// <param name="dto">Injected <see cref="BeachDto"/></param>
    /// <returns>Instance of <see cref="ViewBeach"/></returns>
    public static ViewBeach ToViewModel(this BeachDto @dto)
    {
        return new ViewBeach
        {
            Id = @dto.Id,
            Name = @dto.Name,               
            LastModified = @dto.LastModified,
            Towns = [.. @dto.Towns.Select(x=> x.ToViewModel())],
            LastHistoric = @dto.LastHistoric?.ToViewModel()
        };
    }

    /// <summary>
    /// Transforms to ViewModel
    /// </summary>
    /// <param name="dto">Injected <see cref="PageDto{BeachDto}"/></param>
    /// <returns>Instance of <see cref="ViewPage{ViewBeach}"/></returns>
    public static ViewPage<ViewBeach> ToPageViewModel(this PageDto<BeachDto> @dto)
    {
        return new ViewPage<ViewBeach>
        {
            Index = @dto.Index,
            Length = @dto.Length,
            Size = @dto.Size,
            Items = [.. dto.Items.Select(x => x.ToViewModel())]
        };
    }
}
