using Microsoft.AspNetCore.Mvc;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;
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
        public async Task<IActionResult> UpdatePoblacion(UpdatePoblacion viewModel)
        {
            Poblacion provincia = await this.Service.UpdatePoblacion(viewModel);

            return new JsonResult(provincia);
        }

        [HttpGet]
        [Route("findallpoblacion")]
        public async Task<IActionResult> FindAllPoblacion()
        {
            ICollection<Poblacion> poblaciones = await this.Service.FindAllPoblacion();

            return new JsonResult(poblaciones);
        }      

        [HttpPost]
        [Route("addpoblacion")]
        public async Task<IActionResult> AddPoblacion(AddPoblacion viewModel)
        {
            Poblacion poblacion = await this.Service.AddPoblacion(viewModel);

            return new JsonResult(poblacion);
        }

        [HttpDelete]
        [Route("removepoblacionbyid/{id}")]
        public async Task<IActionResult> RemoveProvinciaById(int id)
        {
            await this.Service.RemovePoblacionById(id);

            return new JsonResult(StatusCode(200));
        }
    }
}
