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
    [Route("api/provincia")]
    [Produces("application/json")]
    public class ProvinciaController : Controller
    {
        private readonly IProvinciaService Service;

        public ProvinciaController(IProvinciaService service)
        {
            this.Service = service;
        }

        [HttpPut]
        [Route("updateprovincia")]
        public async Task<IActionResult> UpdateProvincia([FromBody]UpdateProvincia viewModel)
        {
            try
            {
                ViewProvincia provincia = await this.Service.UpdateProvincia(viewModel);

                return new JsonResult(provincia);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet]
        [Route("findallprovincia")]
        public async Task<IActionResult> FindAllProvincia()
        {
            ICollection<ViewProvincia> provincias = await this.Service.FindAllProvincia();

            return new JsonResult(provincias);
        }

        [HttpPost]
        [Route("addprovincia")]
        public async Task<IActionResult> AddProvincia([FromBody]AddProvincia viewModel)
        {
            try
            {
                ViewProvincia provincia = await this.Service.AddProvincia(viewModel);

                return new JsonResult(provincia);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpDelete]
        [Route("removeprovinciabyid/{id}")]
        public async Task<IActionResult> RemoveProvinciaById(int id)
        {
            try
            {
                await this.Service.RemoveProvinciaById(id);

                return new JsonResult(StatusCode(200));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
