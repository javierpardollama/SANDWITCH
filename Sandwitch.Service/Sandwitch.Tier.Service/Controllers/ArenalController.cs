using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Updates;

using System.Net;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Web.Controllers
{
    /// <summary>
    /// Represents a <see cref="ArenalController"/> class. Inherits <see cref="ControllerBase"/> 
    /// </summary>
    /// <param name="service">Injected <see cref="IArenalService"/></param>
    [Route("api/arenal")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class ArenalController(IArenalService @service) : ControllerBase
    {      

        /// <summary>
        /// Updates Arenal
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateArenal"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPut]
        [Route("updatearenal")]
        public async Task<IActionResult> UpdateArenal([FromBody]UpdateArenal @viewModel) => new JsonResult(value: await @service.UpdateArenal(@viewModel));

        /// <summary>
        /// Finds All Arenal
        /// </summary>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
        [Route("findallarenal")]
        public async Task<IActionResult> FindAllarenal() => new JsonResult(value: await @service.FindAllArenal());

        /// <summary>
        /// Finds Paginated Arenal
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("findpaginatedarenal")]
        public async Task<IActionResult> FindPaginatedArenal([FromBody] FilterPage @viewModel) => new JsonResult(value: await @service.FindPaginatedArenal(@viewModel));

        /// <summary>
        /// Finds All Arenal By Poblacion Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [Route("findallarenalbypoblacionid/{id}")]
        public async Task<IActionResult> FindAllArenalByPoblacionId(int @id) => new JsonResult(value: await @service.FindAllArenalByPoblacionId(@id));

        /// <summary>
        /// Finds All Historico By Arenal Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [Route("findallhistoricobyarenalid/{id}")]
        public async Task<IActionResult> FindAllHistoricoByArenalId(int @id) => new JsonResult(value: await @service.FindAllHistoricoByArenalId(@id));

        /// <summary>
        /// Adds Arenal
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddArenal"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("addarenal")]
        public async Task<IActionResult> AddArenal([FromBody]AddArenal @viewModel) => new JsonResult(value: await @service.AddArenal(@viewModel));

        /// <summary>
        /// Removes Arenal By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpDelete]
        [Route("removearenalbyid/{id}")]
        public async Task<IActionResult> RemoveArenalById(int @id)
        {
            await service.RemoveArenalById(@id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
