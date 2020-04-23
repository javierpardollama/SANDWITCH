﻿using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;

namespace Sandwitch.Tier.Web.Controllers
{
    /// <summary>
    /// Represents a <see cref="ProvinciaController"/> interface. Inherits <see cref="ControllerBase"/>
    /// </summary>
    [Route("api/provincia")]
    [Produces("application/json")]
    [ApiController]
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
        public ProvinciaController(IProvinciaService service) => Service = service;

        /// <summary>
        /// Updates Provincia
        /// </summary>
        /// <param name="viewModel">Injected <see cref="UpdateProvincia"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpPut]
        [Route("updateprovincia")]
        public async Task<IActionResult> UpdateProvincia([FromBody]UpdateProvincia viewModel) => new JsonResult(value: await Service.UpdateProvincia(viewModel));

        /// <summary>
        /// Finds All Provincia
        /// </summary>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpGet]
        [Route("findallprovincia")]
        public async Task<IActionResult> FindAllProvincia() => new JsonResult(value: await Service.FindAllProvincia());

        /// <summary>
        /// Adds Provincia
        /// </summary>
        /// <param name="viewModel">Injected <see cref="AddProvincia"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpPost]
        [Route("addprovincia")]
        public async Task<IActionResult> AddProvincia([FromBody]AddProvincia viewModel) => new JsonResult(value: await Service.AddProvincia(viewModel));

        /// <summary>
        /// Removes Provincia By Id
        /// </summary>
        /// <param name="viewModel">Injected <see cref="int"/></param>
        /// <returns>Instance of <see cref="JsonResult"/></returns>
        [HttpDelete]
        [Route("removeprovinciabyid/{id}")]
        public async Task<IActionResult> RemoveProvinciaById(int id)
        {
            await Service.RemoveProvinciaById(id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
