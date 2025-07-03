using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Filters;
using System.Threading.Tasks;
using Sandwitch.Tier.ViewModels.Classes.Finders;

namespace Sandwitch.Tier.Service.Controllers
{

    /// <summary>
    /// Represents a <see cref="BuscadorController"/> class. Inherits <see cref="ControllerBase"/> 
    /// </summary>
    /// <param name="service">Injected <see cref="IBuscadorService"/></param>
    [Route("api/buscador")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    [EnableRateLimiting("Concurrency")]
    public class BuscadorController(IBuscadorService @service) : ControllerBase
    {
        /// <summary>
        /// Finds All Buscador
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="408">RequestTimeout</response>
        /// <response code="404">NotFound</response>
        /// <response code="409">Conflict</response>
        /// <response code="503">ServiceUnavailable</response>
        /// <response code="500">InternalServerError</response>     
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpGet]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
        [Route("findallbuscador")]
        public async Task<IActionResult> FindAllBuscador() => Ok(value: await @service.FindAllBuscador());
        
        /// <summary>
        /// Finds All Arenal By Buscador Id
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="400">BadRequest</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="408">RequestTimeout</response>
        /// <response code="404">NotFound</response>
        /// <response code="409">Conflict</response>
        /// <response code="503">ServiceUnavailable</response>
        /// <response code="500">InternalServerError</response>     
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpPost]
        [Route("findallarenalbybuscadorid")]
        public async Task<IActionResult> FindAllArenalByBuscadorId([FromBody] FinderArenal @viewModel) => Ok(value: await @service.FindAllArenalByBuscadorId(@viewModel));
    }
}