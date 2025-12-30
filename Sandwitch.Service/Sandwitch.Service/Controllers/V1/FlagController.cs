using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Sandwitch.Application.Commands.Flag;
using Sandwitch.Application.Queries.Flag;
using Sandwitch.Application.ViewModels.Additions;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Updates;
using Sandwitch.Application.ViewModels.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sandwitch.Service.Controllers.V1;

/// <summary>
///     Represents a <see cref="FlagController" /> class. Inherits <see cref="ControllerBase" />
/// </summary>
/// <param name="mediator">Injected <see cref="IMediator" /></param>
[ApiVersion(1.0)]
[ApiExplorerSettings(GroupName = "v1")]
[Route("api/v{v:apiVersion}/flag")]
[Produces("application/json")]
[ApiController]
[Authorize]
[EnableRateLimiting("Concurrency")]
public class FlagController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Updates Flag
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">BadRequest</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="408">RequestTimeout</response>
    /// <response code="404">NotFound</response>
    /// <response code="409">Conflict</response>
    /// <response code="503">ServiceUnavailable</response>
    /// <response code="500">InternalServerError</response>
    /// <param name="viewModel">Injected <see cref="AddHistoric" /></param>
    /// <returns>Instance of <see cref="Task{OkObjectResult}" /></returns>
    [MapToApiVersion(1.0)]
    [HttpPut]
    [Route("update")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewTown))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> UpdateFlag([FromBody] UpdateFlag viewModel)
    {
        return Ok(await mediator.Send(new UpdateFlagCommand { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Finds All Flag
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
    [MapToApiVersion(1.0)]
    [HttpGet]
    [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
    [Route("all")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ViewCatalog>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> FindAllFlag()
    {
        return Ok(await mediator.Send(new FindAllFlagQuery()));
    }

    /// <summary>
    ///     Finds Paginated Flag
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
    [MapToApiVersion(1.0)]
    [HttpPost]
    [Route("page")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewPage<ViewTown>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> FindPaginatedFlag([FromBody] FilterPage viewModel)
    {
        return Ok(await mediator.Send(new FindPaginatedFlagQuery { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Finds All Historic By Flag Id
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
    [MapToApiVersion(1.0)]
    [HttpGet]
    [Route("all/Historic/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<ViewHistoric>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> FindAllHistoricByFlagId(int id)
    {
        return Ok(await mediator.Send(new FindAllHistoricByFlagIdQuery { Id = id }));
    }

    /// <summary>
    ///     Adds Flag
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">BadRequest</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="408">RequestTimeout</response>
    /// <response code="404">NotFound</response>
    /// <response code="409">Conflict</response>
    /// <response code="503">ServiceUnavailable</response>
    /// <response code="500">InternalServerError</response>
    /// <param name="viewModel">Injected <see cref="AddFlag" /></param>
    /// <returns>Instance of <see cref="Task{OkObjectResult}" /></returns>
    [MapToApiVersion(1.0)]
    [HttpPost]
    [Route("create")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ViewFlag))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> AddFlag([FromBody] AddFlag viewModel)
    {
        return Ok(await mediator.Send(new AddFlagCommand { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Removes Flag ById
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
    [MapToApiVersion(1.0)]
    [HttpDelete]
    [Route("remove/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status408RequestTimeout, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status503ServiceUnavailable, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> RemoveFlagById(int id)
    {
        await mediator.Send(new RemoveFlagByIdCommand { Id = id });

        return Ok();
    }
}