using System.Threading.Tasks;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Sandwitch.Application.Commands.Historico;
using Sandwitch.Domain.ViewModels.Additions;

namespace Sandwitch.Service.Controllers.V2;

/// <summary>
///     Represents a <see cref="HistoricoController" /> class. Inherits <see cref="ControllerBase" />
/// </summary>
/// <param name="mediator">Injected <see cref="IMediator" /></param>
[ApiVersion(2.0)]
[ApiExplorerSettings(GroupName = "v2")]
[Route("api/v{v:apiVersion}/historico")]
[Produces("application/json")]
[ApiController]
[Authorize]
[EnableRateLimiting("Concurrency")]
public class HistoricoController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Adds Historico
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">BadRequest</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="408">RequestTimeout</response>
    /// <response code="404">NotFound</response>
    /// <response code="409">Conflict</response>
    /// <response code="503">ServiceUnavailable</response>
    /// <response code="500">InternalServerError</response>
    /// <param name="viewModel">Injected <see cref="AddHistorico" /></param>
    /// <returns>Instance of <see cref="Task{OkObjectResult}" /></returns>
    [MapToApiVersion(2.0)]
    [HttpPost]
    [Route("addhistorico")]
    public async Task<IActionResult> AddHistorico([FromBody] AddHistorico viewModel)
    {
        return Ok(await mediator.Send(new AddHistoricoCommand { ViewModel = viewModel }));
    }
}