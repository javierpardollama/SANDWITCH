using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;

namespace Sandwitch.Tier.Web.Controllers
{
    /// <summary>
    /// Represents a <see cref="HistoricoController"/> class. Inherits <see cref="ControllerBase"/>
    /// </summary>
    [Route("api/historico")]
    [Produces("application/json")]
    [ApiController]
    public class HistoricoController : ControllerBase
    {
        /// <summary>
        /// Instance of <see cref="IHistoricoService"/>
        /// </summary>
        private readonly IHistoricoService Service;

        /// <summary>
        /// Initializes a new Instance of <see cref="HistoricoController"/>
        /// </summary>
        /// <param name="service">Injected <see cref="IHistoricoService"/></param>
        public HistoricoController(IHistoricoService service) => Service = service;

        /// <summary>
        /// Adds Historico
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddHistorico"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpPost]
        [Route("addhistorico")]
        public async Task<IActionResult> AddHistorico([FromBody]AddHistorico viewModel) => new JsonResult(value: await Service.AddHistorico(viewModel));
    }
}
