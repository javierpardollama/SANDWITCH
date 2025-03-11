using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Service.Controllers
{
    /// <summary>
    /// Represents a <see cref="ArenalController"/> class. Inherits <see cref="ControllerBase"/> 
    /// </summary>
    /// <param name="service">Injected <see cref="IArenalService"/></param>
    [Route("api/arenal")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    [EnableRateLimiting("Concurrency")]
    public class ArenalController(IArenalService @service) : ControllerBase
    {

        /// <summary>
        /// Updates Arenal
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="409">Conflict</response>
        /// <response code="401">Unauthorized</response>
        /// <param name="viewModel">Injected <see cref="UpdateArenal"/></param>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpPut]
        [Route("updatearenal")]
        public async Task<IActionResult> UpdateArenal([FromBody]UpdateArenal @viewModel) => Ok(value: await @service.UpdateArenal(@viewModel));

        /// <summary>
        /// Finds All Arenal
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="409">Conflict</response>
        /// <response code="401">Unauthorized</response>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpGet]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
        [Route("findallarenal")]
        public async Task<IActionResult> FindAllarenal() => Ok(value: await @service.FindAllArenal());

        /// <summary>
        /// Finds Paginated Arenal
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="409">Conflict</response>
        /// <response code="401">Unauthorized</response>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpPost]
        [Route("findpaginatedarenal")]
        public async Task<IActionResult> FindPaginatedArenal([FromBody] FilterPage @viewModel) => Ok(value: await @service.FindPaginatedArenal(@viewModel));

        /// <summary>
        /// Finds All Arenal By Poblacion Id
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="409">Conflict</response>
        /// <response code="401">Unauthorized</response>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpGet]
        [Route("findallarenalbypoblacionid/{id}")]
        public async Task<IActionResult> FindAllArenalByPoblacionId(int @id) => Ok(value: await @service.FindAllArenalByPoblacionId(@id));

        /// <summary>
        /// Finds All Historico By Arenal Id
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="409">Conflict</response>
        /// <response code="401">Unauthorized</response>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpGet]
        [Route("findallhistoricobyarenalid/{id}")]
        public async Task<IActionResult> FindAllHistoricoByArenalId(int @id) => Ok(value: await @service.FindAllHistoricoByArenalId(@id));

        /// <summary>
        /// Adds Arenal
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="409">Conflict</response>
        /// <response code="401">Unauthorized</response>
        /// <param name="viewModel">Injected <see cref="AddArenal"/></param>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpPost]
        [Route("addarenal")]
        public async Task<IActionResult> AddArenal([FromBody]AddArenal @viewModel) => Ok(value: await @service.AddArenal(@viewModel));

        /// <summary>
        /// Removes Arenal By Id
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="409">Conflict</response>
        /// <response code="401">Unauthorized</response>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpDelete]
        [Route("removearenalbyid/{id}")]
        public async Task<IActionResult> RemoveArenalById(int @id)
        {
            await service.RemoveArenalById(@id);

            return Ok();
        }
    }
}
