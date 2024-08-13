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
    /// Represents a <see cref="VientoController"/> class. Inherits <see cref="ControllerBase"/> 
    /// </summary>
    /// <param name="service">Injected <see cref="IVientoService"/></param>
    [Route("api/viento")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    [EnableRateLimiting("Concurrency")]
    public class VientoController(IVientoService @service) : ControllerBase
    {       
        /// <summary>
        /// Updates Viento
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddHistorico"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPut]
        [Route("updateviento")]
        public async Task<IActionResult> UpdateViento([FromBody]UpdateViento @viewModel) => new JsonResult(value: await @service.UpdateViento(@viewModel));

        /// <summary>
        /// Finds All Viento
        /// </summary>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
        [Route("findallviento")]
        public async Task<IActionResult> FindAllViento() => new JsonResult(value: await @service.FindAllViento());

        /// <summary>
        /// Finds Paginated Viento
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("findpaginatedviento")]
        public async Task<IActionResult> FindPaginatedViento([FromBody] FilterPage @viewModel) => new JsonResult(value: await @service.FindPaginatedViento(@viewModel));

        /// <summary>
        /// Finds All Historico By Viento Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [Route("findallhistoricobyvientoid/{id}")]
        public async Task<IActionResult> FindAllHistoricoByVientoId(int @id) => new JsonResult(value: await @service.FindAllHistoricoByVientoId(@id));

        /// <summary>
        /// Adds Viento
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddViento"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("addviento")]
        public async Task<IActionResult> AddViento([FromBody]AddViento @viewModel) => new JsonResult(value: await @service.AddViento(@viewModel));

        /// <summary>
        /// Removes Viento ById
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpDelete]
        [Route("removevientobyid/{id}")]
        public async Task<IActionResult> RemoveVientoById(int @id)
        {
            await @service.RemoveVientoById(@id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
