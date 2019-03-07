using Microsoft.AspNetCore.Mvc;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Web.Controllers
{
    [Route("api/bandera")]
    [Produces("application/json")]
    public class BanderaController : Controller
    {
        private readonly IBanderaService Service;

        public BanderaController(IBanderaService service)
        {
            this.Service = service;
        }

        [HttpPut]
        [Route("updatebandera")]
        public async Task<IActionResult> UpdateBandera(UpdateBandera viewModel)
        {
            Bandera bandera = await this.Service.UpdateBandera(viewModel);

            return new JsonResult(bandera);
        }

        [HttpGet]
        [Route("findallbandera}")]
        public async Task<IActionResult> FindAllBandera(int id)
        {
            ICollection<Bandera> banderas = await this.Service.FindAllBandera();

            return new JsonResult(banderas);
        }

        [HttpPost]
        [Route("addbandera")]
        public async Task<IActionResult> AddBandera(AddBandera viewModel)
        {
            Bandera bandera = await this.Service.AddBandera(viewModel);

            return new JsonResult(bandera);
        }

        [HttpDelete]
        [Route("RemoveBanderaById/{id}")]
        public async Task<IActionResult> RemoveBanderaById(int id)
        {
            await this.Service.RemoveBanderaById(id);

            return new JsonResult(StatusCode(200));
        }
    }
}
