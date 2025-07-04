﻿using System.Threading.Tasks;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Services.Interfaces
{
    /// <summary>
    /// Represents a <see cref="IBanderaService"/> interface. Inherits <see cref="IBaseService"/>
    /// </summary>
    public interface IHistoricoService : IBaseService
    {
        /// <summary>
        /// Finds Arenal By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Arenal}"/></returns>
        public Task<Arenal> FindArenalById(int @id);

        /// <summary>
        /// Finds Bandera By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Bandera}"/></returns>
        public Task<Bandera> FindBanderaById(int @id);

        /// <summary>
        /// Adds Historico
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddHistorico"/></param>
        /// <returns>Instance of <see cref="Task{ViewHistorico}"/></returns>
        public Task<ViewHistorico> AddHistorico(AddHistorico @viewModel);
    }
}
