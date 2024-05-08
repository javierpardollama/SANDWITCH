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
    /// Represents a <see cref="ProvinciaController"/> class. Inherits <see cref="ControllerBase"/> 
    /// </summary>
    /// <param name="service">Injected <see cref="IArenalService"/></param>
    [Route("api/provincia")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    [EnableRateLimiting("fixed")]
    public class ProvinciaController(IProvinciaService @service) : ControllerBase
    {
        /// <summary>
        /// Updates Provincia
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateProvincia"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPut]
        [Route("updateprovincia")]
        public async Task<IActionResult> UpdateProvincia([FromBody]UpdateProvincia @viewModel) => new JsonResult(value: await @service.UpdateProvincia(@viewModel));

        /// <summary>
        /// Finds All Provincia
        /// </summary>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
        [Route("findallprovincia")]
        public async Task<IActionResult> FindAllProvincia() => new JsonResult(value: await @service.FindAllProvincia());

        /// <summary>
        /// Finds Paginated Provincia
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("findpaginatedprovincia")]
        public async Task<IActionResult> FindPaginatedProvincia([FromBody] FilterPage @viewModel) => new JsonResult(value: await @service.FindPaginatedProvincia(@viewModel));

        /// <summary>
        /// Adds Provincia
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddProvincia"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("addprovincia")]
        public async Task<IActionResult> AddProvincia([FromBody]AddProvincia @viewModel) => new JsonResult(value: await @service.AddProvincia(@viewModel));

        /// <summary>
        /// Removes Provincia By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpDelete]
        [Route("removeprovinciabyid/{id}")]
        public async Task<IActionResult> RemoveProvinciaById(int @id)
        {
            await @service.RemoveProvinciaById(@id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
