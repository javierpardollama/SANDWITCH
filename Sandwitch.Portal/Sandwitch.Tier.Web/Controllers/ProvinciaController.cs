using Microsoft.AspNetCore.Mvc;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Web.Controllers
{
    [Route("api/provincia")]
    [Produces("application/json")]
    public class ProvinciaController : Controller
    {
        private readonly IProvinciaService Service;

        public ProvinciaController(IProvinciaService service)
        {
            this.Service = service;
        }
    }
}
