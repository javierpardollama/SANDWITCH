using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Dtos;

namespace Sandwitch.Application.Profiles
{
    /// <summary>
    /// Represents a <see cref="ProvinciaProfile"/> class.
    /// </summary>
    public static class ProvinciaProfile
    {
        /// <summary>
        /// Transforms to Dto
        /// </summary>
        /// <param name="dto">Injected <see cref="ProvinciaDto"/></param>
        /// <returns>Instance of <see cref="ViewProvincia"/></returns>
        public static ViewProvincia ToViewModel(this ProvinciaDto @dto)
        {
            return new ViewProvincia
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
        /// <param name="dto">Injected <see cref="PageDto{ProvinciaDto}"/></param>
        /// <returns>Instance of <see cref="ViewPage{ViewProvincia}"/></returns>
        public static ViewPage<ViewProvincia> ToPageViewModel(this PageDto<ProvinciaDto> @dto)
        {
            return new ViewPage<ViewProvincia>
            {
                Index = @dto.Index,
                Length = @dto.Length,
                Size = @dto.Size,
                Items = dto.Items.Select(x => x.ToViewModel()).ToList()
            };
        }
    }
}
