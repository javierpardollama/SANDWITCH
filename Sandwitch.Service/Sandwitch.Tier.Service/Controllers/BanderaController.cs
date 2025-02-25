using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Updates;

using System.Net;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Web.Controllers
{
    /// <summary>
    /// Represents a <see cref="BanderaController"/> class. Inherits <see cref="ControllerBase"/> 
    /// </summary>
    /// <param name="service">Injected <see cref="IBanderaService"/></param>
    [Route("api/bandera")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    [EnableRateLimiting("Concurrency")]
    public class BanderaController(IBanderaService @service) : ControllerBase
    {       
        /// <summary>
        /// Updates Bandera
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddHistorico"/></param>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpPut]
        [Route("updatebandera")]
        public async Task<IActionResult> UpdateBandera([FromBody]UpdateBandera @viewModel) => Ok(value: await @service.UpdateBandera(@viewModel));

        /// <summary>
        /// Finds All Bandera
        /// </summary>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpGet]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
        [Route("findallbandera")]
        public async Task<IActionResult> FindAllBandera() => Ok(value: await @service.FindAllBandera());

        /// <summary>
        /// Finds Paginated Bandera
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpPost]
        [Route("findpaginatedbandera")]
        public async Task<IActionResult> FindPaginatedBandera([FromBody] FilterPage @viewModel) => Ok(value: await @service.FindPaginatedBandera(@viewModel));

        /// <summary>
        /// Finds All Historico By Bandera Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpGet]
        [Route("findallhistoricobybanderaid/{id}")]
        public async Task<IActionResult> FindAllHistoricoByBanderaId(int @id) => Ok(value: await @service.FindAllHistoricoByBanderaId(@id));

        /// <summary>
        /// Adds Bandera
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddBandera"/></param>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpPost]
        [Route("addbandera")]
        public async Task<IActionResult> AddBandera([FromBody]AddBandera @viewModel) => Ok(value: await @service.AddBandera(@viewModel));

        /// <summary>
        /// Removes Bandera ById
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpDelete]
        [Route("removebanderabyid/{id}")]
        public async Task<IActionResult> RemoveBanderaById(int @id)
        {
            await @service.RemoveBanderaById(@id);

            return Ok();
        }
    }
}
