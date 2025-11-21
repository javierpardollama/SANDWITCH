using Sandwitch.Application.ViewModels.Views;
using Sandwitch.Domain.Dtos;

namespace Sandwitch.Application.Profiles
{
    /// <summary>
    /// Represents a <see cref="HistoricoProfile"/> class.
    /// </summary>
    public static class HistoricoProfile
    {
        /// <summary>
        /// Transforms to ViewModel
        /// </summary>
        /// <param name="dto">Injected <see cref="HistoricoDto"/></param>
        /// <returns>Instance of <see cref="ViewHistorico"/></returns>
        public static ViewHistorico ToViewModel(this HistoricoDto @dto)
        {
            return new ViewHistorico
            {
              Id = @dto.Id,
              LastModified = @dto.LastModified,
              AltaMarAlba = @dto.AltaMarAlba,
              AltaMarOcaso = @dto.AltaMarOcaso,
              Arenal = @dto.Arenal?.ToViewModel(),
              BajaMarAlba = @dto.BajaMarAlba,
              BajaMarOcaso = @dto.BajaMarOcaso,
              Bandera = @dto.Bandera?.ToViewModel(),
              Temperatura = @dto.Temperatura,
              Velocidad = @dto.Velocidad,
              Viento = @dto.Viento?.ToViewModel()
            };
        }
    }
}
