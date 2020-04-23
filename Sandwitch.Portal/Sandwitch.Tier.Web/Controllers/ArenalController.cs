﻿using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;

namespace Sandwitch.Tier.Web.Controllers
{
    /// <summary>
    /// Represents a <see cref="ArenalController"/> interface. Inherits <see cref="ControllerBase"/>
    /// </summary>
    [Route("api/arenal")]
    [Produces("application/json")]
    [ApiController]
    public class ArenalController : ControllerBase
    {
        /// <summary>
        /// Instance of <see cref="IArenalService"/>
        /// </summary>
        private readonly IArenalService Service;

        /// <summary>
        /// Initializes a new Instance of <see cref="ArenalController"/>
        /// </summary>
        /// <param name="service">Injected <see cref="IArenalService"/></param>
        public ArenalController(IArenalService service) => Service = service;

        /// <summary>
        /// Updates Arenal
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateArenal"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpPut]
        [Route("updatearenal")]
        public async Task<IActionResult> UpdateArenal([FromBody]UpdateArenal viewModel) => new JsonResult(value: await Service.UpdateArenal(viewModel));

        /// <summary>
        /// Finds All Arenal
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpGet]
        [Route("findallarenal")]
        public async Task<IActionResult> FindAllarenal() => new JsonResult(value: await Service.FindAllArenal());

        /// <summary>
        /// Finds All Arenal By Poblacion Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpGet]
        [Route("findallarenalbypoblacionid/{id}")]
        public async Task<IActionResult> FindAllArenalByPoblacionId(int id) => new JsonResult(value: await Service.FindAllArenalByPoblacionId(id));

        /// <summary>
        /// Finds All Historico By Arenal Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpGet]
        [Route("findallhistoricobyarenalid/{id}")]
        public async Task<IActionResult> FindAllHistoricoByArenalId(int id) => new JsonResult(value: await Service.FindAllHistoricoByArenalId(id));

        /// <summary>
        /// Adds Arenal
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddArenal"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpPost]
        [Route("addarenal")]
        public async Task<IActionResult> AddArenal([FromBody]AddArenal viewModel) => new JsonResult(value: await Service.AddArenal(viewModel));

        /// <summary>
        /// Removes Arenal By Id
        /// </summary>
        /// <param name="id">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpDelete]
        [Route("removearenalbyid/{id}")]
        public async Task<IActionResult> RemoveArenalById(int id)
        {
            await Service.RemoveArenalById(id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
