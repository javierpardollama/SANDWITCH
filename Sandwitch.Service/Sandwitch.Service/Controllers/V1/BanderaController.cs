using System.Threading.Tasks;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Sandwitch.Application.Commands.Bandera;
using Sandwitch.Application.Queries.Bandera;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Updates;

namespace Sandwitch.Service.Controllers.V1;

/// <summary>
///     Represents a <see cref="BanderaController" /> class. Inherits <see cref="ControllerBase" />
/// </summary>
/// <param name="mediator">Injected <see cref="IMediator" /></param>
[ApiVersion(1)]
[Route("api/v{v:apiVersion}/bandera")]
[Produces("application/json")]
[ApiController]
[Authorize]
[EnableRateLimiting("Concurrency")]
public class BanderaController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Updates Bandera
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
    [MapToApiVersion(1)]
    [HttpPut]
    [Route("updatebandera")]
    public async Task<IActionResult> UpdateBandera([FromBody] UpdateBandera viewModel)
    {
        return Ok(await mediator.Send(new UpdateBanderaCommand { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Finds All Bandera
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
    [MapToApiVersion(1)]
    [HttpGet]
    [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
    [Route("findallbandera")]
    public async Task<IActionResult> FindAllBandera()
    {
        return Ok(await mediator.Send(new FindAllBanderaQuery()));
    }

    /// <summary>
    ///     Finds Paginated Bandera
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
    [MapToApiVersion(1)]
    [HttpPost]
    [Route("findpaginatedbandera")]
    public async Task<IActionResult> FindPaginatedBandera([FromBody] FilterPage viewModel)
    {
        return Ok(await mediator.Send(new FindPaginatedBanderaQuery { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Finds All Historico By Bandera Id
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">BadRequest</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="408">RequestTimeout</response>
    /// <response code="404">NotFound</response>
    /// <response code="409">Conflict</response>
    /// <response code="503">ServiceUnavailable</response>
    /// <response code="500">InternalServerError</response>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{OkObjectResult}" /></returns>
    [MapToApiVersion(1)]
    [HttpGet]
    [Route("findallhistoricobybanderaid/{id}")]
    public async Task<IActionResult> FindAllHistoricoByBanderaId(int id)
    {
        return Ok(await mediator.Send(new FindAllHistoricoByBanderaIdQuery { Id = id }));
    }

    /// <summary>
    ///     Adds Bandera
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">BadRequest</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="408">RequestTimeout</response>
    /// <response code="404">NotFound</response>
    /// <response code="409">Conflict</response>
    /// <response code="503">ServiceUnavailable</response>
    /// <response code="500">InternalServerError</response>
    /// <param name="viewModel">Injected <see cref="AddBandera" /></param>
    /// <returns>Instance of <see cref="Task{OkObjectResult}" /></returns>
    [MapToApiVersion(1)]
    [HttpPost]
    [Route("addbandera")]
    public async Task<IActionResult> AddBandera([FromBody] AddBandera viewModel)
    {
        return Ok(await mediator.Send(new AddBanderaCommand { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Removes Bandera ById
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">BadRequest</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="408">RequestTimeout</response>
    /// <response code="404">NotFound</response>
    /// <response code="409">Conflict</response>
    /// <response code="503">ServiceUnavailable</response>
    /// <response code="500">InternalServerError</response>
    /// <param name="id">Injected <see cref="int" /></param>
    /// <returns>Instance of <see cref="Task{OkObjectResult}" /></returns>
    [MapToApiVersion(1)]
    [HttpDelete]
    [Route("removebanderabyid/{id}")]
    public async Task<IActionResult> RemoveBanderaById(int id)
    {
        await mediator.Send(new RemoveBanderaByIdCommand { Id = id });

        return Ok();
    }
}