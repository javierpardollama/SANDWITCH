﻿using AutoMapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Sandwitch.Tier.Contexts.Interfaces;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Logging.Classes;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Views;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Services.Classes
{
    /// <summary>
    /// Represents a <see cref="HistoricoService"/> class. Inherits <see cref="BaseService"/>. Implements <see cref="IHistoricoService"/>
    /// </summary>
    public class HistoricoService : BaseService, IHistoricoService
    {
        /// <summary>
        /// Initializes a new Instance of <see cref="HistoricoService"/>
        /// </summary>
        /// <param name="context">Injected <see cref="IApplicationContext"/></param>
        /// <param name="mapper">Injected <see cref="IMapper"/></param>
        /// <param name="logger">Injected <see cref="ILogger"/></param>
        public HistoricoService(IApplicationContext @context,
                                IMapper @mapper,
                                ILogger<HistoricoService> @logger) : base(@context,
                                                                          @mapper,
                                                                          @logger)
        {
        }

        /// <summary>
        /// Finds Arenal By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Arenal}"/></returns>
        public async Task<Arenal> FindArenalById(int @id)
        {
            Arenal @arenal = await Context.Arenal
                .TagWith("FindArenalById")
                .AsQueryable()
                .AsSplitQuery()
                .Include(x => x.ArenalPoblaciones)
                .ThenInclude(x => x.Poblacion)
                .FirstOrDefaultAsync(x => x.Id == @id);

            if (@arenal == null)
            {
                // Log
                string @logData = nameof(@arenal)
                    + " with Id "
                    + @id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(nameof(@arenal)
                    + " with Id "
                    + @id
                    + " does not exist");
            }

            return @arenal;
        }

        /// <summary>
        /// Finds Bandera By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{Bandera}"/></returns>
        public async Task<Bandera> FindBanderaById(int @id)
        {
            Bandera @bandera = await Context.Bandera
                 .TagWith("FindBanderaById")
                 .FirstOrDefaultAsync(x => x.Id == @id);

            if (@bandera == null)
            {
                // Log
                string @logData = nameof(@bandera)
                    + " with Id "
                    + @id
                    + " was not found at "
                    + DateTime.Now.ToShortTimeString();

                Logger.WriteGetItemNotFoundLog(@logData);

                throw new Exception(nameof(@bandera)
                    + " with Id "
                    + @id
                    + " does not exist");
            }

            return @bandera;
        }

        /// <summary>
        /// Adds Historico
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddHistorico"/></param>
        /// <returns>Instance of <see cref="Task{ViewHistorico}"/></returns>
        public async Task<ViewHistorico> AddHistorico(AddHistorico @viewModel)
        {
            Historico @historico = new()
            {
                Arenal = await FindArenalById(@viewModel.ArenalId),
                Bandera = await FindBanderaById(@viewModel.BanderaId),
                BajaMarAlba = @viewModel.BajaMarAlba,
                BajaMarOcaso = @viewModel.BajaMarOcaso,
                AltaMarAlba = @viewModel.AltaMarAlba,
                AltaMarOcaso = @viewModel.AltaMarOcaso,
                Temperatura = @viewModel.Temperatura,
            };

            Context.Historico.Add(@historico);

            await Context.SaveChangesAsync();

            // Log
            string @logData = nameof(@historico)
                + " with Id "
                + historico.Id
                + " was added at "
                + DateTime.Now.ToShortTimeString();

            Logger.WriteInsertItemLog(@logData);

            return Mapper.Map<ViewHistorico>(@historico);
        }
    }
}
