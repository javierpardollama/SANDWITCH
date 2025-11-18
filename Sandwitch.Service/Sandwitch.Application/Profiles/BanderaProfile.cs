using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Dtos;

namespace Sandwitch.Application.Profiles
{
    /// <summary>
    /// Represents a <see cref="BanderaProfile"/> class.
    /// </summary>
    public static class BanderaProfile
    {
        /// <summary>
        /// Transforms to ViewModel
        /// </summary>
        /// <param name="dto">Injected <see cref="BanderaDto"/></param>
        /// <returns>Instance of <see cref="ViewBandera"/></returns>
        public static ViewBandera ToViewModel(this BanderaDto @dto)
        {
            return new ViewBandera
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
        /// <param name="dto">Injected <see cref="PageDto{BanderaDto}"/></param>
        /// <returns>Instance of <see cref="ViewPage{ViewBandera}"/></returns>
        public static ViewPage<ViewBandera> ToPageViewModel(this PageDto<BanderaDto> @dto)
        {
            return new ViewPage<ViewBandera>
            {
                Index = @dto.Index,
                Length = @dto.Length,
                Size = @dto.Size,
                Items = [.. dto.Items.Select(x => x.ToViewModel())]
            };
        }
    }
}
