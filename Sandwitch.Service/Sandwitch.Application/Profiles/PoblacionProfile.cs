using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Dtos;

namespace Sandwitch.Application.Profiles
{
    /// <summary>
    /// Represents a <see cref="PoblacionProfile"/> class.
    /// </summary>
    public static class PoblacionProfile
    {
        /// <summary>
        /// Transforms to ViewModel
        /// </summary>
        /// <param name="dto">Injected <see cref="PoblacionDto"/></param>
        /// <returns>Instance of <see cref="ViewPoblacion"/></returns>
        public static ViewPoblacion ToViewModel(this PoblacionDto @dto)
        {
            return new ViewPoblacion
            {
                Id = @dto.Id,
                Name = @dto.Name,
                ImageUri = @dto.ImageUri,
                LastModified = @dto.LastModified,
                Provincia = @dto.Provincia?.ToViewModel()
            };
        }

        /// <summary>
        /// Transforms to ViewModel
        /// </summary>
        /// <param name="dto">Injected <see cref="PageDto{PoblacionDto}"/></param>
        /// <returns>Instance of <see cref="ViewPage{ViewPoblacion}"/></returns>
        public static ViewPage<ViewPoblacion> ToPageViewModel(this PageDto<PoblacionDto> @dto)
        {
            return new ViewPage<ViewPoblacion>
            {
                Index = @dto.Index,
                Length = @dto.Length,
                Size = @dto.Size,
                Items = [.. dto.Items.Select(x => x.ToViewModel())]
            };
        }
    }
}
