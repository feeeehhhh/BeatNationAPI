
using BeatNationAPI.Application.Command.Licencas.Request;
using BeatNationAPI.Application.Command.Licencas.Response;
using BeatNationAPI.Application.Licencas.Command.Request;
using BeatNationAPI.Application.Licencas.Command.Response;
using BeatNationAPI.Data;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BeatNationAPI.Controllers
{
    [Route("api/licencas")]
    [ApiController]
    public class LicencaController : ControllerBase
    {
        //Presets da Licencas
        // [Authorize]
        [HttpPost]
        [Route("presetcreate")]
        public async Task<PresetCreateResponse> Create(
           [FromServices] IMediator mediator,
           [FromBody] PresetCreateRequest command
         )
        {
            return await mediator.Send(command);
        }

        // [Authorize]
        [HttpDelete("presetdelete/{id}")]
        public async Task<IActionResult> DeletePreset(
            Guid id,
           [FromServices] IMediator mediator
         )
        {
            await mediator.Send(new PresetDeleteRequest(id));
            return NoContent();
        }

        //Licencas
        // [Authorize]
        [HttpPost]
        [Route("licencacreate")]
        public async Task<LicencaCreateResponse> CreateLicenca(
            [FromServices] IMediator mediator,
            [FromBody] LicencaCreateRequest command
        )
        {
            return await mediator.Send(command);


        }
        // [Authorize]
        [HttpDelete("licencadelete/{id}")]
        public async Task<IActionResult> DeleteLicenca(
            Guid Id,
           [FromServices] IMediator mediator
         )
        {
            await mediator.Send(new LicencaDeleteRequest(Id));
            return NoContent();
        }

        // [Authorize]
        [HttpPut("licencaupdate/{id}")]
        public async Task<IActionResult> UpdateLicenca(
            Guid Id,
           [FromServices] IMediator mediator,
           [FromBody] Application.Licencas.Command.Request.LicencaUpdateRequest command
         )
        {
            var commandComId = command with {Id =Id};
            await mediator.Send(commandComId);
            return NoContent();
        }

        // [Authorize]
        [HttpGet]
        [Route("presets")]
        public async Task<ActionResult<List<PresetCreateResponse>>> GetPresets(
        [FromServices] IMediator mediator)
        {
            var response = await mediator.Send(new PresetGetAllRequest());
            return Ok(response);
        }


        //  [Authorize]
        // [HttpGet]
        // [Route("licencas")]
        // public async Task<ActionResult<List<LicencaCreateResponse>>> GetLicencas(
        //     [FromServices] IMediator mediator
        // )
        // {
        //     var response = await mediator.Send(new LicencaGetRequest());
        //     return Ok(response);
        // }

    }
}
