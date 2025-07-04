﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Services.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IArenalService"/> interface. Inherits <see cref="IBaseService"/>
    /// </summary>
    public interface IArenalService : IBaseService
    {
        /// <summary>
        /// Finds All Arenal
        /// </summary>
        /// <returns>Instance of <see cref="IList{ViewArenal}"/></returns>
        public Task<IList<ViewArenal>> FindAllArenal();

        /// <summary>
        /// Finds Paginated Arenal
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{ViewPage{ViewArenal}}"/></returns>
        public Task<ViewPage<ViewArenal>> FindPaginatedArenal(FilterPage @viewModel);
      
        /// <summary>
        /// Finds All Historico By Arenal Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{IList{ViewHistorico}}"/></returns>
        public Task<IList<ViewHistorico>> FindAllHistoricoByArenalId(int @id);

        /// <summary>
        /// Finds Arenal By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Arenal}"/></returns>
        public Task<Arenal> FindArenalById(int @id);

        /// <summary>
        /// Finds Poblacion By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Poblacion}"/></returns>
        public Task<Poblacion> FindPoblacionById(int @id);

        /// <summary>
        /// Finds Bandera By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Bandera}"/></returns>
        public Task<Bandera> FindBanderaById(int @id);

        /// <summary>
        /// Removes Arenal By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public Task RemoveArenalById(int @id);

        /// <summary>
        /// Updates Arenal
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateArenal"/></param>
        /// <returns>Instance of <see cref="Task{ViewArenal}"/></returns>
        public Task<ViewArenal> UpdateArenal(UpdateArenal @viewModel);

        /// <summary>
        /// Adds Arenal
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddArenal"/></param>
        /// <returns>Instance of <see cref="Task{ViewArenal}"/></returns>
        public Task<ViewArenal> AddArenal(AddArenal @viewModel);

        /// <summary>
        /// Adds Arenal Poblacion
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddArenal"/></param>
        /// <param name="entity">Injected <see cref="Arenal"/></param>
        public void AddArenalPoblacion(AddArenal @viewModel, Arenal @entity);

        /// <summary>
        /// Adds Historico
        /// </summary>
        /// <param name="entity">Injected <see cref="Arenal"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public Task AddHistorico(Arenal @entity);

        /// <summary>
        /// Updates Arenal Poblacion
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateArenal"/></param>
        /// <param name="entity">Injected <see cref="Arenal"/></param>
        public void UpdateArenalPoblacion(UpdateArenal @viewModel, Arenal @entity);

        /// <summary>
        /// Updates Historico
        /// </summary>
        /// <param name="entity">Injected <see cref="Arenal"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public Task UpdateHistorico(Arenal @entity);

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddArenal"/></param>
        /// <returns>Instance of <see cref="Task{Arenal}"/></returns>
        public Task<Arenal> CheckName(AddArenal @viewModel);

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateArenal"/></param>
        /// <returns>Instance of <see cref="Task{Arenal}"/></returns>
        public Task<Arenal> CheckName(UpdateArenal @viewModel);
    }
}
