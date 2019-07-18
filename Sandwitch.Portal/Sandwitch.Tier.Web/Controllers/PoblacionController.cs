using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Web.Controllers
{
    [Route("api/poblacion")]
    [Produces("application/json")]
    public class PoblacionController : Controller
    {
        private readonly IPoblacionService Service;

        public PoblacionController(IPoblacionService service) => this.Service = service;

        [HttpPut]
        [Route("updatepoblacion")]
        public async Task<IActionResult> UpdatePoblacion([FromBody]UpdatePoblacion viewModel)
        {
            ViewPoblacion provincia = await Service.UpdatePoblacion(viewModel);

            return new JsonResult(provincia);
        }

        [HttpGet]
        [Route("findallpoblacion")]
        public async Task<IActionResult> FindAllPoblacion()
        {
            ICollection<ViewPoblacion> poblaciones = await Service.FindAllPoblacion();

            return new JsonResult(poblaciones);
        }

        [HttpGet]
        [Route("findallpoblacionbyprovinciaid/{id}")]
        public async Task<IActionResult> FindAllPoblacionByProvinciaId(int id)
        {
            ICollection<ViewPoblacion> poblaciones = await Service.FindAllPoblacionByProvinciaId(id);

            return new JsonResult(poblaciones);
        }

        [HttpPost]
        [Route("addpoblacion")]
        public async Task<IActionResult> AddPoblacion([FromBody]AddPoblacion viewModel)
        {
            ViewPoblacion poblacion = await Service.AddPoblacion(viewModel);

            return new JsonResult(poblacion);
        }

        [HttpDelete]
        [Route("removepoblacionbyid/{id}")]
        public async Task<IActionResult> RemovePoblacionById(int id)
        {
            await Service.RemovePoblacionById(id);

            return new JsonResult(StatusCode(200));
        }
    }
}
