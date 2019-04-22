using Microsoft.AspNetCore.Mvc;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using Sandwitch.Tier.ViewModels.Classes.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Web.Controllers
{
    [Route("api/arenal")]
    [Produces("application/json")]
    public class ArenalController : Controller
    {
        private readonly IArenalService Service;

        public ArenalController(IArenalService service)
        {
            this.Service = service;
        }

        [HttpPut]
        [Route("updatearenal")]
        public async Task<IActionResult> UpdateArenal([FromBody]UpdateArenal viewModel)
        {
            try
            {
                ViewArenal arenal = await this.Service.UpdateArenal(viewModel);

                return new JsonResult(arenal);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet]
        [Route("findallarenal")]
        public async Task<IActionResult> FindAllarenal()
        {
            ICollection<ViewArenal> arenales = await this.Service.FindAllArenal();

            return new JsonResult(arenales);
        }

        [HttpGet]
        [Route("findallarenalbypoblacionid/{id}")]
        public async Task<IActionResult> FindAllArenalByPoblacionId(int id)
        {
            ICollection<ViewArenal> arenales = await this.Service.FindAllArenalByPoblacionId(id);

            return new JsonResult(arenales);
        }

        [HttpPost]
        [Route("addarenal")]
        public async Task<IActionResult> AddArenal([FromBody]AddArenal viewModel)
        {
            try
            {
                ViewArenal arenal = await this.Service.AddArenal(viewModel);

                return new JsonResult(arenal);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpDelete]
        [Route("removearenalbyid/{id}")]
        public async Task<IActionResult> RemoveArenalById(int id)
        {
            try
            {
                await this.Service.RemoveArenalById(id);

                return new JsonResult(StatusCode(200));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
