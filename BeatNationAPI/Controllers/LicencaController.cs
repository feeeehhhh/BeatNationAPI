
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
        //Presets da Licencas
        [HttpPost]
        [Route("presetcreate")]
        public async Task<PresetCreateResponse> Create(
           [FromServices] IMediator mediator,
           [FromBody] Application.Command.PresetCreateRequest command
         )
        {
            return await mediator.Send(command);
        }
        [HttpDelete]
        [Route("presetdelete")]
        public async Task<IActionResult> DeletePreset(
           [FromServices] IMediator mediator,
           [FromBody] Application.Licencas.Command.Request.PresetDeleteRequest command
         )
        {
            await mediator.Send(command);
            return NoContent();
        }

        //Licencas

        [HttpDelete]
        [Route("licencadelete")]
        public async Task<IActionResult> DeleteLicenca(
           [FromServices] IMediator mediator,
           [FromBody] Application.Licencas.Command.Request.LicencaDeleteRequest command
         )
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpPut]
        [Route("licencaupdate")]
        public async Task<IActionResult> UpdateLicenca(
           [FromServices] IMediator mediator,
           [FromBody] Application.Licencas.Command.Request.LicencaUpdateRequest command
         )
        {
            await mediator.Send(command);
            return NoContent();
        }

        [HttpGet]
        [Route("presets")]
        public async Task<ActionResult<List<PresetCreateResponse>>> GetPresets(
        [FromServices] IMediator mediator)
        {
            var response = await mediator.Send(new PresetGetAllRequest());
            return Ok(response);
        }

        [HttpGet]
        [Route("licencas")]
        public async Task<ActionResult<List<LicencaCreateResponse>>> GetLicencas(
        [FromServices] IMediator mediator)
        {
            var response = await mediator.Send(new LicencaGetRequest());
            return Ok(response);
        }
        


    }
}
