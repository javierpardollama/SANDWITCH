
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Service.Controllers
{
    /// <summary>
    /// Represents a <see cref="HistoricoController"/> class. Inherits <see cref="ControllerBase"/> 
    /// </summary>
    /// <param name="service">Injected <see cref="IHistoricoService"/></param>
    [Route("api/historico")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    [EnableRateLimiting("Concurrency")]
    public class HistoricoController(IHistoricoService @service) : ControllerBase
    {
        /// <summary>
        /// Adds Historico
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="408">RequestTimeout</response>
        /// <response code="409">Conflict</response>
        /// <response code="503">ServiceUnavailable</response>
        /// <response code="500">InternalServerError</response>
        /// <param name="viewModel">Injected <see cref="AddHistorico"/></param>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpPost]
        [Route("addhistorico")]
        public async Task<IActionResult> AddHistorico([FromBody] AddHistorico @viewModel) => Ok(value: await @service.AddHistorico(@viewModel));
    }
}
