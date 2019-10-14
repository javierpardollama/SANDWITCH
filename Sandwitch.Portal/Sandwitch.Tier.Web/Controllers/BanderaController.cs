using System.Net;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;

namespace Sandwitch.Tier.Web.Controllers
{
    [Route("api/bandera")]
    [Produces("application/json")]
    [ApiController]
    public class BanderaController : ControllerBase
    {
        private readonly IBanderaService Service;

        public BanderaController(IBanderaService service) => Service = service;

        [HttpPut]
        [Route("updatebandera")]
        public async Task<IActionResult> UpdateBandera([FromBody]UpdateBandera viewModel) => new JsonResult(value: await Service.UpdateBandera(viewModel));

        [HttpGet]
        [Route("findallbandera")]
        public async Task<IActionResult> FindAllBandera() => new JsonResult(value: await Service.FindAllBandera());

        [HttpPost]
        [Route("addbandera")]
        public async Task<IActionResult> AddBandera([FromBody]AddBandera viewModel) => new JsonResult(value: await Service.AddBandera(viewModel));

        [HttpDelete]
        [Route("removebanderabyid/{id}")]
        public async Task<IActionResult> RemoveBanderaById(int id)
        {
            await Service.RemoveBanderaById(id);

            return new JsonResult((int)HttpStatusCode.OK);
        }
    }
}
