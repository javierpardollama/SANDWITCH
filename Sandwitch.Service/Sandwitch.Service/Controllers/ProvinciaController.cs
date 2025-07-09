using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Sandwitch.Application.Commands.Provincia;
using Sandwitch.Application.Queries.Provincia;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Updates;

namespace Sandwitch.Service.Controllers;

/// <summary>
///     Represents a <see cref="ProvinciaController" /> class. Inherits <see cref="ControllerBase" />
/// </summary>
/// <param name="mediator">Injected <see cref="IMediator" /></param>
[Route("api/provincia")]
[Produces("application/json")]
[ApiController]
[Authorize]
[EnableRateLimiting("Concurrency")]
public class ProvinciaController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Updates Provincia
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">BadRequest</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="408">RequestTimeout</response>
    /// <response code="404">NotFound</response>
    /// <response code="409">Conflict</response>
    /// <response code="503">ServiceUnavailable</response>
    /// <response code="500">InternalServerError</response>
    /// <param name="viewModel">Injected <see cref="UpdateProvincia" /></param>
    /// <returns>Instance of <see cref="Task{OkObjectResult}" /></returns>
    [HttpPut]
    [Route("updateprovincia")]
    public async Task<IActionResult> UpdateProvincia([FromBody] UpdateProvincia viewModel)
    {
        return Ok(await mediator.Send(new UpdateProvinciaCommand { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Finds All Provincia
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
    [HttpGet]
    [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
    [Route("findallprovincia")]
    public async Task<IActionResult> FindAllProvincia()
    {
        return Ok(await mediator.Send(new FindAllProvinciaQuery()));
    }

    /// <summary>
    ///     Finds Paginated Provincia
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
    [HttpPost]
    [Route("findpaginatedprovincia")]
    public async Task<IActionResult> FindPaginatedProvincia([FromBody] FilterPage viewModel)
    {
        return Ok(await mediator.Send(new FindPaginatedProvinciaQuery { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Adds Provincia
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">BadRequest</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="408">RequestTimeout</response>
    /// <response code="404">NotFound</response>
    /// <response code="409">Conflict</response>
    /// <response code="503">ServiceUnavailable</response>
    /// <response code="500">InternalServerError</response>
    /// <param name="viewModel">Injected <see cref="AddProvincia" /></param>
    /// <returns>Instance of <see cref="Task{OkObjectResult}" /></returns>
    [HttpPost]
    [Route("addprovincia")]
    public async Task<IActionResult> AddProvincia([FromBody] AddProvincia viewModel)
    {
        return Ok(await mediator.Send(new AddProvinciaCommand { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Removes Provincia By Id
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
    [HttpDelete]
    [Route("removeprovinciabyid/{id}")]
    public async Task<IActionResult> RemoveProvinciaById(int id)
    {
        await mediator.Send(new RemoveProvinciaByIdCommand { Id = id });

        return Ok();
    }
}