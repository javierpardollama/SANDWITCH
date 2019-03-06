using Microsoft.AspNetCore.Mvc;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Interfaces;
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
    }
}
