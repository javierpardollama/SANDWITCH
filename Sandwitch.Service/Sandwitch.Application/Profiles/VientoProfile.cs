using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Dtos;

namespace Sandwitch.Application.Profiles;

/// <summary>
/// Represents a <see cref="VientoProfile"/> class.
/// </summary>
public static class VientoProfile
{
    /// <summary>
    /// Transforms to ViewModel
    /// </summary>
    /// <param name="dto">Injected <see cref="VientoDto"/></param>
    /// <returns>Instance of <see cref="ViewViento"/></returns>
    public static ViewViento ToViewModel(this VientoDto @dto)
    {
        return new ViewViento
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
    /// <param name="dto">Injected <see cref="PageDto{VientoDto}"/></param>
    /// <returns>Instance of <see cref="ViewPage{ViewViento}"/></returns>
    public static ViewPage<ViewViento> ToPageViewModel(this PageDto<VientoDto> @dto)
    {
        return new ViewPage<ViewViento>
        {
            Index = @dto.Index,
            Length = @dto.Length,
            Size = @dto.Size,
            Items = [.. dto.Items.Select(x => x.ToViewModel())]
        };
    }
}
