using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Dtos;

namespace Sandwitch.Application.Profiles;

/// <summary>
/// Represents a <see cref="WindProfile"/> class.
/// </summary>
public static class WindProfile
{
    /// <summary>
    /// Transforms to ViewModel
    /// </summary>
    /// <param name="dto">Injected <see cref="WindDto"/></param>
    /// <returns>Instance of <see cref="ViewWind"/></returns>
    public static ViewWind ToViewModel(this WindDto @dto)
    {
        return new ViewWind
        {
            Id = @dto.Id,
            Name = @dto.Name,
            ImageUri = @dto.ImageUri,
            LastModified = @dto.LastModified
        };
    }

    /// <summary>
    /// Transforms to ViewModel
    /// </summary>
    /// <param name="dto">Injected <see cref="PageDto{WindDto}"/></param>
    /// <returns>Instance of <see cref="ViewPage{ViewWind}"/></returns>
    public static ViewPage<ViewWind> ToPageViewModel(this PageDto<WindDto> @dto)
    {
        return new ViewPage<ViewWind>
        {
            Index = @dto.Index,
            Length = @dto.Length,
            Size = @dto.Size,
            Items = [.. dto.Items.Select(x => x.ToViewModel())]
        };
    }
}
