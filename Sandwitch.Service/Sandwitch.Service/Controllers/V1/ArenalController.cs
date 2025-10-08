using System.Threading.Tasks;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Sandwitch.Application.Commands.Arenal;
using Sandwitch.Application.Queries.Arenal;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Updates;

namespace Sandwitch.Service.Controllers.V1;

/// <summary>
///     Represents a <see cref="ArenalController" /> class. Inherits <see cref="ControllerBase" />
/// </summary>
/// <param name="mediator">Injected <see cref="IMediator" /></param>
[ApiVersion(1)]
[Route("api/v{v:apiVersion}/arenal")]
[Produces("application/json")]
[ApiController]
[Authorize]
[EnableRateLimiting("Concurrency")]
public class ArenalController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Updates Arenal
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">BadRequest</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="408">RequestTimeout</response>
    /// <response code="404">NotFound</response>
    /// <response code="409">Conflict</response>
    /// <response code="503">ServiceUnavailable</response>
    /// <response code="500">InternalServerError</response>
    /// <param name="viewModel">Injected <see cref="UpdateArenal" /></param>
    /// <returns>Instance of <see cref="Task{OkObjectResult}" /></returns>
    [MapToApiVersion(1)]
    [HttpPut]
    [Route("updatearenal")]
    public async Task<IActionResult> UpdateArenal([FromBody] UpdateArenal viewModel)
    {
        return Ok(await mediator.Send(new UpdateArenalCommand { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Finds All Arenal
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
    [Route("findallarenal")]
    public async Task<IActionResult> FindAllarenal()
    {
        return Ok(await mediator.Send(new FindAllArenalQuery()));
    }

    /// <summary>
    ///     Finds Paginated Arenal
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
    [Route("findpaginatedarenal")]
    public async Task<IActionResult> FindPaginatedArenal([FromBody] FilterPage viewModel)
    {
        return Ok(await mediator.Send(new FindPaginatedArenalQuery { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Finds All Historico By Arenal Id
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
    [Route("findallhistoricobyarenalid/{id}")]
    public async Task<IActionResult> FindAllHistoricoByArenalId(int id)
    {
        return Ok(await mediator.Send(new FindAllHistoricoByArenalIdQuery { Id = id }));
    }

    /// <summary>
    ///     Adds Arenal
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">BadRequest</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="408">RequestTimeout</response>
    /// <response code="409">Conflict</response>
    /// <response code="503">ServiceUnavailable</response>
    /// <response code="500">InternalServerError</response>
    /// <param name="viewModel">Injected <see cref="AddArenal" /></param>
    /// <returns>Instance of <see cref="Task{OkObjectResult}" /></returns>
    [MapToApiVersion(1)]
    [HttpPost]
    [Route("addarenal")]
    public async Task<IActionResult> AddArenal([FromBody] AddArenal viewModel)
    {
        return Ok(await mediator.Send(new AddArenalCommand { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Removes Arenal By Id
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
    [Route("removearenalbyid/{id}")]
    public async Task<IActionResult> RemoveArenalById(int id)
    {
        await mediator.Send(new RemoveArenalByIdCommand { Id = id });

        return Ok();
    }
}