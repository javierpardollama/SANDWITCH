using System.Threading.Tasks;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Sandwitch.Application.Queries.Buscador;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Finders;

namespace Sandwitch.Service.Controllers.V2;

/// <summary>
///     Represents a <see cref="BuscadorController" /> class. Inherits <see cref="ControllerBase" />
/// </summary>
/// <param name="mediator">Injected <see cref="IMediator" /></param>
[ApiVersion(2.0)]
[ApiExplorerSettings(GroupName = "v2")]
[Route("api/v{v:apiVersion}/buscador")]
[Produces("application/json")]
[ApiController]
[Authorize]
[EnableRateLimiting("Concurrency")]
public class BuscadorController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Finds All Buscador
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">BadRequest</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="408">RequestTimeout</response>
    /// <response code="404">NotFound</response>
    /// <response code="409">Conflict</response>
    /// <response code="503">ServiceUnavailable</response>
    /// <response code="500">InternalServerError</response>
    /// <returns>Instance of <see cref="Task{OkObjectResult}" /></returns>
    [MapToApiVersion(2.0)]
    [HttpGet]
    [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
    [Route("findallbuscador")]
    public async Task<IActionResult> FindAllBuscador()
    {
        return Ok(await mediator.Send(new FindAllBuscadorQuery()));
    }

    /// <summary>
    ///     Finds All Arenal By Buscador Id
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">BadRequest</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="408">RequestTimeout</response>
    /// <response code="404">NotFound</response>
    /// <response code="409">Conflict</response>
    /// <response code="503">ServiceUnavailable</response>
    /// <response code="500">InternalServerError</response>
    /// <param name="viewModel">Injected <see cref="FilterPage" /></param>
    /// <returns>Instance of <see cref="Task{OkObjectResult}" /></returns>
    [MapToApiVersion(2.0)]
    [HttpPost]
    [Route("findallarenalbybuscadorid")]
    public async Task<IActionResult> FindAllArenalByBuscadorId([FromBody] FinderArenal viewModel)
    {
        return Ok(await mediator.Send(new FindAllArenalByBuscadorIdQuery { ViewModel = viewModel }));
    }
}