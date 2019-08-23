using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;

namespace Sandwitch.Tier.Web.Controllers
{
    [Route("api/provincia")]
    [Produces("application/json")]
    public class ProvinciaController : Controller
    {
        private readonly IProvinciaService Service;

        public ProvinciaController(IProvinciaService service) => Service = service;

        [HttpPut]
        [Route("updateprovincia")]
        public async Task<IActionResult> UpdateProvincia([FromBody]UpdateProvincia viewModel) => new JsonResult(value: await Service.UpdateProvincia(viewModel));

        [HttpGet]
        [Route("findallprovincia")]
        public async Task<IActionResult> FindAllProvincia() => new JsonResult(value: await Service.FindAllProvincia());

        [HttpPost]
        [Route("addprovincia")]
        public async Task<IActionResult> AddProvincia([FromBody]AddProvincia viewModel) => new JsonResult(value: await Service.AddProvincia(viewModel));

        [HttpDelete]
        [Route("removeprovinciabyid/{id}")]
        public async Task<IActionResult> RemoveProvinciaById(int id)
        {
            await Service.RemoveProvinciaById(id);

            return new JsonResult(StatusCode(200));
        }
    }
}
