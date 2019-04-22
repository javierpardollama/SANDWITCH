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
    [Route("api/poblacion")]
    [Produces("application/json")]
    public class PoblacionController : Controller
    {
        private readonly IPoblacionService Service;

        public PoblacionController(IPoblacionService service)
        {
            this.Service = service;
        }

        [HttpPut]
        [Route("updatepoblacion")]
        public async Task<IActionResult> UpdatePoblacion([FromBody]UpdatePoblacion viewModel)
        {
            try
            {
                ViewPoblacion provincia = await this.Service.UpdatePoblacion(viewModel);

                return new JsonResult(provincia);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpGet]
        [Route("findallpoblacion")]
        public async Task<IActionResult> FindAllPoblacion()
        {
            ICollection<ViewPoblacion> poblaciones = await this.Service.FindAllPoblacion();

            return new JsonResult(poblaciones);
        }

        [HttpGet]
        [Route("findallpoblacionbyprovinciaid/{id}")]
        public async Task<IActionResult> FindAllPoblacionByProvinciaId(int id)
        {
            ICollection<ViewPoblacion> poblaciones = await this.Service.FindAllPoblacionByProvinciaId(id);

            return new JsonResult(poblaciones);
        }

        [HttpPost]
        [Route("addpoblacion")]
        public async Task<IActionResult> AddPoblacion([FromBody]AddPoblacion viewModel)
        {
            try
            {
                ViewPoblacion poblacion = await this.Service.AddPoblacion(viewModel);

                return new JsonResult(poblacion);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        [HttpDelete]
        [Route("removepoblacionbyid/{id}")]
        public async Task<IActionResult> RemovePoblacionById(int id)
        {
            try
            {
                await this.Service.RemovePoblacionById(id);

                return new JsonResult(StatusCode(200));
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }
    }
}
