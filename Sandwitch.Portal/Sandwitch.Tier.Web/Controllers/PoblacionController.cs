using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;

namespace Sandwitch.Tier.Web.Controllers
{
    [Route("api/poblacion")]
    [Produces("application/json")]
    [ApiController]
    public class PoblacionController : ControllerBase
    {
        private readonly IPoblacionService Service;

        public PoblacionController(IPoblacionService service) => Service = service;

        [HttpPut]
        [Route("updatepoblacion")]
        public async Task<IActionResult> UpdatePoblacion([FromBody]UpdatePoblacion viewModel) => new JsonResult(value: await Service.UpdatePoblacion(viewModel));

        [HttpGet]
        [Route("findallpoblacion")]
        public async Task<IActionResult> FindAllPoblacion() => new JsonResult(value: await Service.FindAllPoblacion());

        [HttpGet]
        [Route("findallpoblacionbyprovinciaid/{id}")]
        public async Task<IActionResult> FindAllPoblacionByProvinciaId(int id) => new JsonResult(value: await Service.FindAllPoblacionByProvinciaId(id));

        [HttpPost]
        [Route("addpoblacion")]
        public async Task<IActionResult> AddPoblacion([FromBody]AddPoblacion viewModel) => new JsonResult(value: await Service.AddPoblacion(viewModel));

        [HttpDelete]
        [Route("removepoblacionbyid/{id}")]
        public async Task<IActionResult> RemovePoblacionById(int id)
        {
            await Service.RemovePoblacionById(id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
