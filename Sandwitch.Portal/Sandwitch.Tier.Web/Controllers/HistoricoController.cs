﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Web.Controllers
{
    [Route("api/historico")]
    [Produces("application/json")]
    public class HistoricoController : Controller
    {
        private readonly IHistoricoService Service;

        public HistoricoController(IHistoricoService service) => this.Service = service;

        [HttpPost]
        [Route("addhistorico")]
        public async Task<IActionResult> AddHistorico([FromBody]AddHistorico viewModel)
        {
            ViewHistorico historico = await Service.AddHistorico(viewModel);

            return new JsonResult(historico);
        }
    }
}
