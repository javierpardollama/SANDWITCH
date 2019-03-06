using Microsoft.AspNetCore.Mvc;
using Sandwitch.Tier.Entities.Classes;
using Sandwitch.Tier.Services.Interfaces;
using Sandwitch.Tier.ViewModels.Classes.Updates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandwitch.Tier.Web.Controllers
{
    [Route("api/arenal")]
    [Produces("application/json")]
    public class ArenalController : Controller
    { 
        private readonly IArenalService Service;

        public ArenalController(IArenalService service)
        {
            this.Service = service;
        }
    }
}
