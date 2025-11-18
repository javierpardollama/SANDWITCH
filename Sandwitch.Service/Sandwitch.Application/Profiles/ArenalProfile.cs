using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Dtos;

namespace Sandwitch.Application.Profiles
{
    /// <summary>
    /// Represents a <see cref="ArenalProfile"/> class.
    /// </summary>
    public static class ArenalProfile
    {
        /// <summary>
        /// Transforms to ViewModel
        /// </summary>
        /// <param name="dto">Injected <see cref="ArenalDto"/></param>
        /// <returns>Instance of <see cref="ViewArenal"/></returns>
        public static ViewArenal ToViewModel(this ArenalDto @dto)
        {
            return new ViewArenal
            {
                Id = @dto.Id,
                Name = @dto.Name,               
                LastModified = @dto.LastModified,
                Poblaciones = [.. @dto.Poblaciones.Select(x=> x.ToViewModel())],
                LastHistorico = @dto.LastHistorico?.ToViewModel()
            };
        }

        /// <summary>
        /// Transforms to ViewModel
        /// </summary>
        /// <param name="dto">Injected <see cref="PageDto{ArenalDto}"/></param>
        /// <returns>Instance of <see cref="ViewPage{ViewArenal}"/></returns>
        public static ViewPage<ViewArenal> ToPageViewModel(this PageDto<ArenalDto> @dto)
        {
            return new ViewPage<ViewArenal>
            {
                Index = @dto.Index,
                Length = @dto.Length,
                Size = @dto.Size,
                Items = dto.Items.Select(x => x.ToViewModel()).ToList()
            };
        }
    }
}
