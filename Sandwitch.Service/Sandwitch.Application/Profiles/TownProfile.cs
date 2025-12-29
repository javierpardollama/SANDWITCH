using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Dtos;

namespace Sandwitch.Application.Profiles;

/// <summary>
/// Represents a <see cref="TownProfile"/> class.
/// </summary>
public static class TownProfile
{
    /// <summary>
    /// Transforms to ViewModel
    /// </summary>
    /// <param name="dto">Injected <see cref="TownDto"/></param>
    /// <returns>Instance of <see cref="ViewTown"/></returns>
    public static ViewTown ToViewModel(this TownDto @dto)
    {
        return new ViewTown
        {
            Id = @dto.Id,
            Name = @dto.Name,
            ImageUri = @dto.ImageUri,
            LastModified = @dto.LastModified,
            State = @dto.State?.ToViewModel()
        };
    }

    /// <summary>
    /// Transforms to ViewModel
    /// </summary>
    /// <param name="dto">Injected <see cref="PageDto{TownDto}"/></param>
    /// <returns>Instance of <see cref="ViewPage{ViewTown}"/></returns>
    public static ViewPage<ViewTown> ToPageViewModel(this PageDto<TownDto> @dto)
    {
        return new ViewPage<ViewTown>
        {
            Index = @dto.Index,
            Length = @dto.Length,
            Size = @dto.Size,
            Items = [.. dto.Items.Select(x => x.ToViewModel())]
        };
    }
}
