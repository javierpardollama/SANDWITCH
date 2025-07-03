using System.Collections.Generic;
using System.Threading.Tasks;
using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Finders;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Services.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IBuscadorService"/> interface. Inherits <see cref="IBaseService"/>
    /// </summary>
    public interface IBuscadorService : IBaseService
    {
        /// <summary>
        /// Finds All Buscador
        /// </summary>
        /// <returns>Instance of <see cref="Task{IList{ViewBuscador}}"/></returns>
        public Task<IList<ViewBuscador>> FindAllBuscador();

        /// <summary>
        /// Finds All Arenal By Buscador Id
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FinderArenal"/></param>
        /// <returns>Instance of <see cref="Task{IList{ViewArenal}}"/></returns>
        public Task<IList<ViewArenal>> FindAllArenalByBuscadorId(FinderArenal @viewModel);
    }
}