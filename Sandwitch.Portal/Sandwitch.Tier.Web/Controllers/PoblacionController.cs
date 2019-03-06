using Microsoft.AspNetCore.Mvc;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Web.Controllers
{
    [Route("api/poblacion")]
    [Produces("application/json")]
    public class PoblacionController
    {
        private readonly IPoblacionService Service;

        public PoblacionController(IPoblacionService service)
        {
            this.Service = service;
        }
    }
}
