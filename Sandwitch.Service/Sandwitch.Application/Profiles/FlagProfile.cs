using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Dtos;

namespace Sandwitch.Application.Profiles;

/// <summary>
/// Represents a <see cref="FlagProfile"/> class.
/// </summary>
public static class FlagProfile
{
    /// <summary>
    /// Transforms to ViewModel
    /// </summary>
    /// <param name="dto">Injected <see cref="FlagDto"/></param>
    /// <returns>Instance of <see cref="ViewFlag"/></returns>
    public static ViewFlag ToViewModel(this FlagDto @dto)
    {
        return new ViewFlag
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
    /// <param name="dto">Injected <see cref="PageDto{FlagDto}"/></param>
    /// <returns>Instance of <see cref="ViewPage{ViewFlag}"/></returns>
    public static ViewPage<ViewFlag> ToPageViewModel(this PageDto<FlagDto> @dto)
    {
        return new ViewPage<ViewFlag>
        {
            Index = @dto.Index,
            Length = @dto.Length,
            Size = @dto.Size,
            Items = [.. dto.Items.Select(x => x.ToViewModel())]
        };
    }
}
