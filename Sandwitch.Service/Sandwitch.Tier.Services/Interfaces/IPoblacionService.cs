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
    /// Represents a <see cref="IPoblacionService"/> interface. Inherits <see cref="IBaseService"/>
    /// </summary>
    public interface IPoblacionService : IBaseService
    {
        /// <summary>
        /// Finds All Poblacion
        /// </summary>
        /// <returns>Instance of <see cref="Task{IList{ViewPoblacion}}"/></returns>
        public Task<IList<ViewPoblacion>> FindAllPoblacion();

        /// <summary>
        /// Finds Paginated Poblacion
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{ViewPage{ViewPoblacion}}"/></returns>
        public Task<ViewPage<ViewPoblacion>> FindPaginatedPoblacion(FilterPage @viewModel);
       
        /// <summary>
        /// Finds Poblacion By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Poblacion}"/></returns>
        public Task<Poblacion> FindPoblacionById(int @id);

        /// <summary>
        /// Finds Provincia By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Provincia}"/></returns>
        public Task<Provincia> FindProvinciaById(int @id);

        /// <summary>
        /// Removes Poblacion By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task"/></returns>
        public Task RemovePoblacionById(int @id);

        /// <summary>
        /// Updates Poblacion
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdatePoblacion"/></param>
        /// <returns>Instance of <see cref="Task{ViewPoblacion}"/></returns>
        public Task<ViewPoblacion> UpdatePoblacion(UpdatePoblacion @viewModel);

        /// <summary>
        /// Adds Poblacion
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddPoblacion"/></param>
        /// <returns>Instance of <see cref="Task{ViewPoblacion}"/></returns>
        public Task<ViewPoblacion> AddPoblacion(AddPoblacion @viewModel);

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddPoblacion"/></param>
        /// <returns>Instance of <see cref="Task{Poblacion}"/></returns>
        Task<Poblacion> CheckName(AddPoblacion @viewModel);

        /// <summary>
        /// Checks Name
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddPoblacion"/></param>
        /// <returns>Instance of <see cref="Task{Poblacion}"/></returns>
        Task<Poblacion> CheckName(UpdatePoblacion @viewModel);
    }
}
