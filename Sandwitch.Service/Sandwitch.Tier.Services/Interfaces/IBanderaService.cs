using System.Collections.Generic;
using System.Threading.Tasks;

using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Services.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IBanderaService"/> interface. Inherits <see cref="IBaseService"/>
    /// </summary>
    public interface IBanderaService : IBaseService
    {
        /// <summary>
        /// Finds All Bandera
        /// </summary>
        /// <returns>Instance of <see cref="Task{IList{ViewBandera}}"/></returns>
        public Task<IList<ViewBandera>> FindAllBandera();

        /// <summary>
        /// Finds Paginated Bandera
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{ViewPage{ViewBandera}}"/></returns>
        public Task<ViewPage<ViewBandera>> FindPaginatedBandera(FilterPage @viewmodel);

        /// <summary>
        /// Finds All Historico By Poblacion Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{IList{ViewHistorico}}"/></returns>
        public Task<IList<ViewHistorico>> FindAllHistoricoByBanderaId(int @id);

        /// <summary>
        /// Finds Bandera By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Bandera}"/></returns>
        public Task<Bandera> FindBanderaById(int @id);

        /// <summary>
        /// Removes Bandera By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public Task RemoveBanderaById(int @id);

        /// <summary>
        /// Updates Bandera
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateBandera"/></param>
        /// <returns>Instance of <see cref="Task{ViewBandera}"/></returns>
        public Task<ViewBandera> UpdateBandera(UpdateBandera @viewModel);

        /// <summary>
        /// Adds Bandera
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddBandera"/></param>
        /// <returns>Instance of <see cref="Task{ViewBandera}"/></returns>
        public Task<ViewBandera> AddBandera(AddBandera @viewModel);

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddBandera"/></param>
        /// <returns>Instance of <see cref="Task{Bandera}"/></returns>
        public Task<Bandera> CheckName(AddBandera @viewModel);

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateBandera"/></param>
        /// <returns>Instance of <see cref="Task{Bandera}"/></returns>
        public Task<Bandera> CheckName(UpdateBandera @viewModel);
    }
}
