using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using Sandwitch.Tier.ViewModels.Classes.Views;

namespace Sandwitch.Tier.Web.Controllers
{
    [Route("api/bandera")]
    [Produces("application/json")]
    public class BanderaController : Controller
    {
        private readonly IBanderaService Service;

        public BanderaController(IBanderaService service) => this.Service = service;

        [HttpPut]
        [Route("updatebandera")]
        public async Task<IActionResult> UpdateBandera([FromBody]UpdateBandera viewModel)
        {
            ViewBandera bandera = await Service.UpdateBandera(viewModel);

            return new JsonResult(bandera);
        }

        [HttpGet]
        [Route("findallbandera")]
        public async Task<IActionResult> FindAllBandera()
        {
            ICollection<ViewBandera> banderas = await Service.FindAllBandera();

            return new JsonResult(banderas);
        }

        [HttpPost]
        [Route("addbandera")]
        public async Task<IActionResult> AddBandera([FromBody]AddBandera viewModel)
        {
            ViewBandera bandera = await Service.AddBandera(viewModel);

            return new JsonResult(bandera);
        }

        [HttpDelete]
        [Route("removebanderabyid/{id}")]
        public async Task<IActionResult> RemoveBanderaById(int id)
        {
            await Service.RemoveBanderaById(id);

            return new JsonResult(StatusCode(200));
        }
    }
}
