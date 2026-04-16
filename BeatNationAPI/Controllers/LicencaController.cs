
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
        [HttpPost]
        [Authorize(Roles = "Admin,Produtor")]
        [Route("presetcreate")]
        public async Task<ActionResult<PresetCreateResponse>> Create(
           [FromServices] IMediator mediator,
           [FromBody] PresetCreateRequest command
         )
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }


        
        [HttpGet]
        [Route("presets")]
        [Authorize(Roles = "Admin,Produtor")]
        public async Task<ActionResult<List<PresetCreateResponse>>> GetPresets(
        [FromServices] IMediator mediator)
        {
            var response = await mediator.Send(new PresetGetAllRequest());
            return Ok(response);
        }


        [HttpDelete("presetdelete/{id}")]
        [Authorize(Roles = "Admin,Produtor")]
        public async Task<IActionResult> DeletePreset(
            Guid id,
           [FromServices] IMediator mediator
         )
        {
            var result = await mediator.Send(new PresetDeleteRequest(id));
            return Ok(result);
        }

        [HttpPut("presetupdate/{id}")]
        [Authorize(Roles = "Admin,Produtor")]
        public async Task<IActionResult> UpdatePreset(
            Guid Id,
           [FromServices] IMediator mediator,
           [FromBody] Application.Licencas.Command.Request.PresetUpdateRequest command
         )
        {
            var commandComId = command with { Id = Id };
            var result = await mediator.Send(commandComId);
            return Ok(result);
        }


        //Licencas
        
        [HttpPost]
        [Route("licencacreate/{presetLicencaId}")]
        [Authorize(Roles = "Admin,Produtor")]
        public async Task<ActionResult<LicencaCreateResponse>> CreateLicenca(
            Guid presetLicencaId,
            [FromServices] IMediator mediator,
            [FromBody] LicencaCreateRequest command
        )
        {
            command.PresetLicencaId = presetLicencaId;
            var result = await mediator.Send(command);
            return Ok(result);


        }
        
        [HttpDelete("licencadelete/{id}")]
        [Authorize(Roles = "Admin,Produtor")]
        public async Task<IActionResult> DeleteLicenca(
            Guid Id,
           [FromServices] IMediator mediator
         )
        {
            var result = await mediator.Send(new LicencaDeleteRequest(Id));
            return Ok(result);
        }

        
        [HttpPut("licencaupdate/{id}")]
        [Authorize(Roles = "Admin,Produtor")]
        public async Task<IActionResult> UpdateLicenca(
            Guid Id,
           [FromServices] IMediator mediator,
           [FromBody] Application.Licencas.Command.Request.LicencaUpdateRequest command
         )
        {
            var commandComId = command with { Id = Id };
            var result = await mediator.Send(commandComId);
            return Ok(result);

        }
        // [Authorize]
        // [HttpGet("me")]
        // public IActionResult Me()
        // {
        //     var userId = User.FindFirst("sub")?.Value;
        //     return Ok(new { UserId = userId, Authenticated = User.Identity.IsAuthenticated });
        // }

        // [Authorize]
        // [HttpGet("debug-cookie")]
        // public IActionResult DebugCookie()
        // {
        //     var token = Request.Cookies["accessToken"];
        //     return Ok(token ?? "Cookie não encontrado");
        // }


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
