using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using Sandwitch.Tier.ViewModels.Classes.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Services.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IVientoService"/> interface. Inherits <see cref="IBaseService"/>
    /// </summary>
    public interface IVientoService : IBaseService
    {
        /// <summary>
        /// Finds All Viento
        /// </summary>
        /// <returns>Instance of <see cref="Task{IList{ViewViento}}"/></returns>
        public Task<IList<ViewViento>> FindAllViento();

        /// <summary>
        /// Finds Paginated Viento
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{ViewPage{ViewViento}}"/></returns>
        public Task<ViewPage<ViewViento>> FindPaginatedViento(FilterPage @viewModel);

        /// <summary>
        /// Finds All Historico By Poblacion Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{IList{ViewHistorico}}"/></returns>
        public Task<IList<ViewHistorico>> FindAllHistoricoByVientoId(int @id);

        /// <summary>
        /// Finds Viento By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Viento}"/></returns>
        public Task<Viento> FindVientoById(int @id);

        /// <summary>
        /// Removes Viento By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public Task RemoveVientoById(int @id);

        /// <summary>
        /// Updates Viento
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateViento"/></param>
        /// <returns>Instance of <see cref="Task{ViewViento}"/></returns>
        public Task<ViewViento> UpdateViento(UpdateViento @viewModel);

        /// <summary>
        /// Adds Viento
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddViento"/></param>
        /// <returns>Instance of <see cref="Task{ViewViento}"/></returns>
        public Task<ViewViento> AddViento(AddViento @viewModel);

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddViento"/></param>
        /// <returns>Instance of <see cref="Task{Viento}"/></returns>
        public Task<Viento> CheckName(AddViento @viewModel);

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateViento"/></param>
        /// <returns>Instance of <see cref="Task{Viento}"/></returns>
        public Task<Viento> CheckName(UpdateViento @viewModel);
    }
}
