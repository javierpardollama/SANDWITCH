using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Dtos;

namespace Sandwitch.Application.Profiles;

/// <summary>
/// Represents a <see cref="BuscadorProfile"/> class.
/// </summary>
public static class BuscadorProfile
{
    /// <summary>
    /// Transforms to ViewModel
    /// </summary>
    /// <param name="dto">Injected <see cref="BuscadorDto"/></param>
    /// <returns>Instance of <see cref="ViewBuscador"/></returns>
    public static ViewBuscador ToViewModel(this BuscadorDto @dto)
    {
        return new ViewBuscador
        {
            Id = @dto.Id,
            ImageUri = @dto.ImageUri,
            Name = @dto.Name,
            Group = @dto.Group,
        };
    }
}
