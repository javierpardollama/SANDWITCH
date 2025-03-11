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
    /// Represents a <see cref="ProvinciaController"/> class. Inherits <see cref="ControllerBase"/> 
    /// </summary>
    /// <param name="service">Injected <see cref="IArenalService"/></param>
    [Route("api/provincia")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    [EnableRateLimiting("Concurrency")]
    public class ProvinciaController(IProvinciaService @service) : ControllerBase
    {
        /// <summary>
        /// Updates Provincia
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="409">Conflict</response>
        /// <response code="401">Unauthorized</response>
        /// <param name="viewModel">Injected <see cref="UpdateProvincia"/></param>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpPut]
        [Route("updateprovincia")]
        public async Task<IActionResult> UpdateProvincia([FromBody]UpdateProvincia @viewModel) => Ok(value: await @service.UpdateProvincia(@viewModel));

        /// <summary>
        /// Finds All Provincia
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="409">Conflict</response>
        /// <response code="401">Unauthorized</response>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpGet]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
        [Route("findallprovincia")]
        public async Task<IActionResult> FindAllProvincia() => Ok(value: await @service.FindAllProvincia());

        /// <summary>
        /// Finds Paginated Provincia
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="409">Conflict</response>
        /// <response code="401">Unauthorized</response>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpPost]
        [Route("findpaginatedprovincia")]
        public async Task<IActionResult> FindPaginatedProvincia([FromBody] FilterPage @viewModel) => Ok(value: await @service.FindPaginatedProvincia(@viewModel));

        /// <summary>
        /// Adds Provincia
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="409">Conflict</response>
        /// <response code="401">Unauthorized</response>
        /// <param name="viewModel">Injected <see cref="AddProvincia"/></param>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpPost]
        [Route("addprovincia")]
        public async Task<IActionResult> AddProvincia([FromBody]AddProvincia @viewModel) => Ok(value: await @service.AddProvincia(@viewModel));

        /// <summary>
        /// Removes Provincia By Id
        /// </summary>
        /// <response code="200">Ok</response>
        /// <response code="409">Conflict</response>
        /// <response code="401">Unauthorized</response>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{OkObjectResult}"/></returns>
        [HttpDelete]
        [Route("removeprovinciabyid/{id}")]
        public async Task<IActionResult> RemoveProvinciaById(int @id)
        {
            await @service.RemoveProvinciaById(@id);

            return Ok();
        }
    }
}
