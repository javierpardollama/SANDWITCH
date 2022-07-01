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
    /// Represents a <see cref="PoblacionController"/> class. Inherits <see cref="ControllerBase"/>
    /// </summary>
    [Route("api/poblacion")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class PoblacionController : ControllerBase
    {
        /// <summary>
        /// Instance of <see cref="IPoblacionService"/>
        /// </summary>
        private readonly IPoblacionService Service;

        /// <summary>
        /// Initializes a new Instance of <see cref="PoblacionController"/>
        /// </summary>
        /// <param name="service">Injected <see cref="IPoblacionService"/></param>
        public PoblacionController(IPoblacionService @service) => Service = @service;

        /// <summary>
        /// Updates Poblacion
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdatePoblacion"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPut]
        [Route("updatepoblacion")]
        public async Task<IActionResult> UpdatePoblacion([FromBody]UpdatePoblacion @viewModel) => new JsonResult(value: await Service.UpdatePoblacion(@viewModel));

        /// <summary>
        /// Finds All Poblacion
        /// </summary>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [Route("findallpoblacion")]
        public async Task<IActionResult> FindAllPoblacion() => new JsonResult(value: await Service.FindAllPoblacion());

        /// <summary>
        /// Finds Paginated Poblacion
        /// </summary>
        /// <param name="viewModel">Injected <see cref="PageBase"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("findpaginatedpoblacion")]
        public async Task<IActionResult> FindPaginatedPoblacion([FromBody] FilterPage @viewModel) => new JsonResult(value: await Service.FindPaginatedPoblacion(@viewModel));

        /// <summary>
        /// Finds All Poblacion By Provincia Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [Route("findallpoblacionbyprovinciaid/{id}")]
        public async Task<IActionResult> FindAllPoblacionByProvinciaId(int @id) => new JsonResult(value: await Service.FindAllPoblacionByProvinciaId(@id));

        /// <summary>
        /// Adds Poblacion
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddPoblacion"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("addpoblacion")]
        public async Task<IActionResult> AddPoblacion([FromBody]AddPoblacion @viewModel) => new JsonResult(value: await Service.AddPoblacion(@viewModel));

        /// <summary>
        /// Removes Poblacion By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpDelete]
        [Route("removepoblacionbyid/{id}")]
        public async Task<IActionResult> RemovePoblacionById(int @id)
        {
            await Service.RemovePoblacionById(@id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
