using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Dtos;

namespace Sandwitch.Application.Profiles;

/// <summary>
/// Represents a <see cref="StateProfile"/> class.
/// </summary>
public static class StateProfile
{
    /// <summary>
    /// Transforms to Dto
    /// </summary>
    /// <param name="dto">Injected <see cref="StateDto"/></param>
    /// <returns>Instance of <see cref="ViewState"/></returns>
    public static ViewState ToViewModel(this StateDto @dto)
    {
        return new ViewState
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
    /// <param name="dto">Injected <see cref="PageDto{StateDto}"/></param>
    /// <returns>Instance of <see cref="ViewPage{ViewState}"/></returns>
    public static ViewPage<ViewState> ToPageViewModel(this PageDto<StateDto> @dto)
    {
        return new ViewPage<ViewState>
        {
            Index = @dto.Index,
            Length = @dto.Length,
            Size = @dto.Size,
            Items = [.. dto.Items.Select(x => x.ToViewModel())]
        };
    }
}
