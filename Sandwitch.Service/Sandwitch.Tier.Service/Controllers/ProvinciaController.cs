using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Filters;
using Sandwitch.Tier.ViewModels.Classes.Updates;

using System.Net;

namespace Sandwitch.Tier.Web.Controllers
{
    /// <summary>
    /// Represents a <see cref="ProvinciaController"/> class. Inherits <see cref="ControllerBase"/>
    /// </summary>
    [Route("api/provincia")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class ProvinciaController : ControllerBase
    {
        /// <summary>
        /// Instance of <see cref="IProvinciaService"/>
        /// </summary>
        private readonly IProvinciaService Service;

        /// <summary>
        /// Initializes a new Instance of <see cref="ProvinciaController"/>
        /// </summary>
        /// <param name="service">Injected <see cref="IProvinciaService"/></param>
        public ProvinciaController(IProvinciaService @service) => Service = @service;

        /// <summary>
        /// Updates Provincia
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateProvincia"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPut]
        [Route("updateprovincia")]
        public async Task<IActionResult> UpdateProvincia([FromBody]UpdateProvincia @viewModel) => new JsonResult(value: await Service.UpdateProvincia(@viewModel));

        /// <summary>
        /// Finds All Provincia
        /// </summary>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [Route("findallprovincia")]
        public async Task<IActionResult> FindAllProvincia() => new JsonResult(value: await Service.FindAllProvincia());

        /// <summary>
        /// Finds Paginated Provincia
        /// </summary>
        /// <param name="viewModel">Injected <see cref="FilterPage"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("findpaginatedprovincia")]
        public async Task<IActionResult> FindPaginatedProvincia([FromBody] FilterPage @viewModel) => new JsonResult(value: await Service.FindPaginatedProvincia(@viewModel));

        /// <summary>
        /// Adds Provincia
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddProvincia"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("addprovincia")]
        public async Task<IActionResult> AddProvincia([FromBody]AddProvincia @viewModel) => new JsonResult(value: await Service.AddProvincia(@viewModel));

        /// <summary>
        /// Removes Provincia By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpDelete]
        [Route("removeprovinciabyid/{id}")]
        public async Task<IActionResult> RemoveProvinciaById(int @id)
        {
            await Service.RemoveProvinciaById(@id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
