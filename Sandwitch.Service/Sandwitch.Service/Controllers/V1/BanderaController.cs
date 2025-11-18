using System.Threading.Tasks;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Sandwitch.Application.Commands.Bandera;
using Sandwitch.Application.Queries.Bandera;
using Sandwitch.Application.ViewModels.Additions;
using Sandwitch.Application.ViewModels.Filters;
using Sandwitch.Application.ViewModels.Updates;

namespace Sandwitch.Service.Controllers.V1;

/// <summary>
///     Represents a <see cref="BanderaController" /> class. Inherits <see cref="ControllerBase" />
/// </summary>
/// <param name="mediator">Injected <see cref="IMediator" /></param>
[ApiVersion(1.0)]
[ApiExplorerSettings(GroupName = "v1")]
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
    [MapToApiVersion(1.0)]
    [HttpPut]
    [Route("update")]
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
    [MapToApiVersion(1.0)]
    [HttpGet]
    [ResponseCache(Duration = 10, Location = ResponseCacheLocation.Any, NoStore = false)]
    [Route("all")]
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
    [MapToApiVersion(1.0)]
    [HttpPost]
    [Route("page")]
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
    [MapToApiVersion(1.0)]
    [HttpGet]
    [Route("all/historico/{id}")]
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
    [MapToApiVersion(1.0)]
    [HttpPost]
    [Route("add")]
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
    [MapToApiVersion(1.0)]
    [HttpDelete]
    [Route("remove/{id}")]
    public async Task<IActionResult> RemoveBanderaById(int id)
    {
        await mediator.Send(new RemoveBanderaByIdCommand { Id = id });

        return Ok();
    }
}