using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Dtos;

namespace Sandwitch.Application.Profiles;

/// <summary>
/// Represents a <see cref="FinderProfile"/> class.
/// </summary>
public static class FinderProfile
{
    /// <summary>
    /// Transforms to ViewModel
    /// </summary>
    /// <param name="dto">Injected <see cref="FinderDto"/></param>
    /// <returns>Instance of <see cref="ViewFinder"/></returns>
    public static ViewFinder ToViewModel(this FinderDto @dto)
    {
        return new ViewFinder
        {
            Id = @dto.Id,
            ImageUri = @dto.ImageUri,
            Name = @dto.Name,
            Group = @dto.Group,
        };
    }
}
