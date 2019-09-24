using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Additions;
using Sandwitch.Tier.ViewModels.Classes.Updates;

namespace Sandwitch.Tier.Web.Controllers
{
    [Route("api/arenal")]
    [Produces("application/json")]
    [ApiController]
    public class ArenalController : ControllerBase
    {
        private readonly IArenalService Service;

        public ArenalController(IArenalService service) => Service = service;

        [HttpPut]
        [Route("updatearenal")]
        public async Task<IActionResult> UpdateArenal([FromBody]UpdateArenal viewModel) => new JsonResult(value: await Service.UpdateArenal(viewModel));

        [HttpGet]
        [Route("findallarenal")]
        public async Task<IActionResult> FindAllarenal() => new JsonResult(value: await Service.FindAllArenal());

        [HttpGet]
        [Route("findallarenalbypoblacionid/{id}")]
        public async Task<IActionResult> FindAllArenalByPoblacionId(int id) => new JsonResult(value: await Service.FindAllArenalByPoblacionId(id));

        [HttpPost]
        [Route("addarenal")]
        public async Task<IActionResult> AddArenal([FromBody]AddArenal viewModel) => new JsonResult(value: await Service.AddArenal(viewModel));

        [HttpDelete]
        [Route("removearenalbyid/{id}")]
        public async Task<IActionResult> RemoveArenalById(int id)
        {
            await Service.RemoveArenalById(id);

            return new JsonResult(StatusCode(200));
        }
    }
}
