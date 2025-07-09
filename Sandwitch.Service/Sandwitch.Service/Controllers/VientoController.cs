using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Sandwitch.Application.Commands.Viento;
using Sandwitch.Application.Queries.Viento;
using Sandwitch.Domain.ViewModels.Additions;
using Sandwitch.Domain.ViewModels.Filters;
using Sandwitch.Domain.ViewModels.Updates;

namespace Sandwitch.Service.Controllers;

/// <summary>
///     Represents a <see cref="VientoController" /> class. Inherits <see cref="ControllerBase" />
/// </summary>
/// <param name="mediator">Injected <see cref="IMediator" /></param>
[Route("api/viento")]
[Produces("application/json")]
[ApiController]
[Authorize]
[EnableRateLimiting("Concurrency")]
public class VientoController(IMediator mediator) : ControllerBase
{
    /// <summary>
    ///     Updates Viento
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
    [HttpPut]
    [Route("updateviento")]
    public async Task<IActionResult> UpdateViento([FromBody] UpdateViento viewModel)
    {
        return Ok(await mediator.Send(new UpdateVientoCommand { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Finds All Viento
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
    [Route("findallviento")]
    public async Task<IActionResult> FindAllViento()
    {
        return Ok(await mediator.Send(new FindAllVientoQuery()));
    }

    /// <summary>
    ///     Finds Paginated Viento
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
    [Route("findpaginatedviento")]
    public async Task<IActionResult> FindPaginatedViento([FromBody] FilterPage viewModel)
    {
        return Ok(await mediator.Send(new FindPaginatedVientoQuery { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Finds All Historico By Viento Id
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
    [HttpGet]
    [Route("findallhistoricobyvientoid/{id}")]
    public async Task<IActionResult> FindAllHistoricoByVientoId(int id)
    {
        return Ok(await mediator.Send(new FindAllHistoricoByVientoIdQuery { Id = id }));
    }

    /// <summary>
    ///     Adds Viento
    /// </summary>
    /// <response code="200">Ok</response>
    /// <response code="400">BadRequest</response>
    /// <response code="401">Unauthorized</response>
    /// <response code="408">RequestTimeout</response>
    /// <response code="404">NotFound</response>
    /// <response code="409">Conflict</response>
    /// <response code="503">ServiceUnavailable</response>
    /// <response code="500">InternalServerError</response>
    /// <param name="viewModel">Injected <see cref="AddViento" /></param>
    /// <returns>Instance of <see cref="Task{OkObjectResult}" /></returns>
    [HttpPost]
    [Route("addviento")]
    public async Task<IActionResult> AddViento([FromBody] AddViento viewModel)
    {
        return Ok(await mediator.Send(new AddVientoCommand { ViewModel = viewModel }));
    }

    /// <summary>
    ///     Removes Viento ById
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
    [Route("removevientobyid/{id}")]
    public async Task<IActionResult> RemoveVientoById(int id)
    {
        await mediator.Send(new RemoveVientoByIdCommand { Id = id });

        return Ok();
    }
}