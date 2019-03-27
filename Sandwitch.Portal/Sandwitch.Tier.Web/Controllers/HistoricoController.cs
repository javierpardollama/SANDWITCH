using Microsoft.AspNetCore.Mvc;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Web.Controllers
{
    [Route("api/historico")]
    [Produces("application/json")]
    public class HistoricoController : Controller
    {
        private readonly IHistoricoService Service;

        public HistoricoController(IHistoricoService service)
        {
            this.Service = service;
        }

        [HttpPut]
        [Route("updatehistorico")]
        public async Task<IActionResult> UpdateHistorico([FromBody]UpdateHistorico viewModel)
        {
           Historico historico = await this.Service.UpdateHistorico(viewModel);

           return new JsonResult(historico);
        }        
    }
}
