using System.Threading.Tasks;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Sandwitch.Application.Commands.Poblacion;
using Sandwitch.Application.Queries.Poblacion;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Updates;

namespace Sandwitch.Service.Controllers.V1;

/// <summary>
///     Represents a <see cref="PoblacionController" /> class. Inherits <see cref="ControllerBase" />
/// </summary>
/// <param name="mediator">Injected <see cref="IMediator" /></param>
[ApiVersion(1.0)]
[ApiExplorerSettings(GroupName = "v1")]
[Route("api/v{v:apiVersion}/poblacion")]
[Produces("application/json")]
[ApiController]
[Authorize]
[EnableRateLimiting("Concurrency")]
public class PoblacionController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Updates Poblacion
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">BadRequest</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="408">RequestTimeout</response>
    /// <response code="404">NotFound</response>
    /// <response code="409">Conflict</response>
    /// <response code="503">ServiceUnavailable</response>
    /// <response code="500">InternalServerError</response>
    /// <param name="viewModel">Injected <see cref="UpdatePoblacion" /></param>
    /// <returns>Instance of <see cref="Task{OkObjectResult}" /></returns>
    [MapToApiVersion(1.0)]
    [HttpPut]
    [Route("updatepoblacion")]
    public async Task<IActionResult> UpdatePoblacion([FromBody] UpdatePoblacion viewModel)
    {
        return Ok(await mediator.Send(new UpdatePoblacionCommand { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Finds All Poblacion
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
    [Route("findallpoblacion")]
    public async Task<IActionResult> FindAllPoblacion()
    {
        return Ok(await mediator.Send(new FindAllPoblacionQuery()));
    }

    /// <summary>
    ///     Finds Paginated Poblacion
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
    [Route("findpaginatedpoblacion")]
    public async Task<IActionResult> FindPaginatedPoblacion([FromBody] FilterPage viewModel)
    {
        return Ok(await mediator.Send(new FindPaginatedPoblacionQuery { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Adds Poblacion
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">BadRequest</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="408">RequestTimeout</response>
    /// <response code="404">NotFound</response>
    /// <response code="409">Conflict</response>
    /// <response code="503">ServiceUnavailable</response>
    /// <response code="500">InternalServerError</response>
    /// <param name="viewModel">Injected <see cref="AddPoblacion" /></param>
    /// <returns>Instance of <see cref="Task{OkObjectResult}" /></returns>
    [MapToApiVersion(1.0)]
    [HttpPost]
    [Route("addpoblacion")]
    public async Task<IActionResult> AddPoblacion([FromBody] AddPoblacion viewModel)
    {
        return Ok(await mediator.Send(new AddPoblacionCommand { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Removes Poblacion By Id
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
    [Route("removepoblacionbyid/{id}")]
    public async Task<IActionResult> RemovePoblacionById(int id)
    {
        await mediator.Send(new RemovePoblacionByIdCommand { Id = id });

        return Ok();
    }
}