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
    /// Represents a <see cref="BanderaController"/> class. Inherits <see cref="ControllerBase"/>
    /// </summary>
    [Route("api/bandera")]
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class BanderaController : ControllerBase
    {
        /// <summary>
        /// Instance of <see cref="IBanderaService"/>
        /// </summary>
        private readonly IBanderaService Service;

        /// <summary>
        /// Initializes a new Instance of <see cref="BanderaController"/>
        /// </summary>
        /// <param name="service">Injected <see cref="IBanderaService"/></param>
        public BanderaController(IBanderaService @service) => Service = @service;

        /// <summary>
        /// Updates Bandera
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddHistorico"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPut]
        [Route("updatebandera")]
        public async Task<IActionResult> UpdateBandera([FromBody]UpdateBandera @viewModel) => new JsonResult(value: await Service.UpdateBandera(@viewModel));

        /// <summary>
        /// Finds All Bandera
        /// </summary>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [Route("findallbandera")]
        public async Task<IActionResult> FindAllBandera() => new JsonResult(value: await Service.FindAllBandera());

        /// <summary>
        /// Finds Paginated Bandera
        /// </summary>
        /// <param name="viewModel">Injected <see cref="PageBase"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("findpaginatedbandera")]
        public async Task<IActionResult> FindPaginatedBandera([FromBody] FilterPage @viewModel) => new JsonResult(value: await Service.FindPaginatedBandera(@viewModel));

        /// <summary>
        /// Finds All Historico By Bandera Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpGet]
        [Route("findallhistoricobybanderaid/{id}")]
        public async Task<IActionResult> FindAllHistoricoByBanderaId(int @id) => new JsonResult(value: await Service.FindAllHistoricoByBanderaId(@id));

        /// <summary>
        /// Adds Bandera
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddBandera"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpPost]
        [Route("addbandera")]
        public async Task<IActionResult> AddBandera([FromBody]AddBandera @viewModel) => new JsonResult(value: await Service.AddBandera(@viewModel));

        /// <summary>
        /// Removes Bandera ById
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="Task{JsonResult}"/></returns>
        [HttpDelete]
        [Route("removebanderabyid/{id}")]
        public async Task<IActionResult> RemoveBanderaById(int @id)
        {
            await Service.RemoveBanderaById(@id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
