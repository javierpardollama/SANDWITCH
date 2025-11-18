using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Dtos;

namespace Sandwitch.Application.Profiles
{
    /// <summary>
    ///     Represents a <see cref="ExceptionProfile" /> class
    /// </summary>
    public static class CatalogProfile
    {
        /// <summary>
        /// Transforms to ViewModel
        /// </summary>
        /// <param name="dto">Injected <see cref="CatalogDto"/></param>
        /// <returns>Instance of <see cref="ViewCatalog"/></returns>
        public static ViewCatalog ToViewModel(this CatalogDto @dto)
        {
            return new ViewCatalog
            {
                Id = @dto.Id,
                Name = @dto.Name,
                ImageUri = @dto.ImageUri,
            };
        }
    }
}
