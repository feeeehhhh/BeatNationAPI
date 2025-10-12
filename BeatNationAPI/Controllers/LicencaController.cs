
using BeatNationAPI.Application.Command.Licencas.Request;
using BeatNationAPI.Application.Licencas.Command.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace BeatNationAPI.Controllers
{
    [Route("api/licencas")]
    [ApiController]
    public class LicencaController : ControllerBase
    {
        [HttpPost]
        [Route("presetcreate")]
        public async Task<PresetCreateResponse> Create(
           [FromServices] IMediator mediator,
           [FromBody] PresetCreateRequest command
         )
        {
            return await mediator.Send(command);
        }


        [HttpGet]
        [Route("presets")]
        public async Task<ActionResult<List<PresetCreateResponse>>> GetAllPresets(
        [FromServices] IMediator mediator)
        {
            var response = await mediator.Send(new PresetGetAllRequest());
            return Ok(response);
        }

    }
}
