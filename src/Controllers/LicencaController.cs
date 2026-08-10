
// using src.features.Command.Licencas.Request;
// using src.features.Command.Licencas.Response;
// using src.features.Licencas.Command.Request;
// using src.features.Licencas.Command.Response;
// using src.infra.data;
// using MediatR;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// namespace src.Controllers
// {
//     [Authorize(Roles = "Admin,Produtor")]
//     [Route("api/licencas")]
//     [ApiController]
//     public class LicencaController : ControllerBase
//     {
//         //Licencas
        
//         [HttpPost]
//         [Route("licencacreate/{presetLicencaId}")]
//         public async Task<ActionResult<LicencaCreateResponse>> CreateLicenca(
//             Guid presetLicencaId,
//             [FromServices] IMediator mediator,
//             [FromBody] LicencaCreateRequest command
//         )
//         {
//             command.PresetLicencaId = presetLicencaId;
//             var result = await mediator.Send(command);
//             return Ok(result);


//         }
        
//         [HttpDelete("licencadelete/{id}")]
//         public async Task<IActionResult> DeleteLicenca(
//             Guid Id,
//            [FromServices] IMediator mediator
//          )
//         {
//             var result = await mediator.Send(new LicencaDeleteRequest(Id));
//             return Ok(result);
//         }

        
//         [HttpPut("licencaupdate/{id}")]
//         public async Task<IActionResult> UpdateLicenca(
//             Guid Id,
//            [FromServices] IMediator mediator,
//            [FromBody] features.Licencas.Command.Request.LicencaUpdateRequest command
//          )
//         {
//             var commandComId = command with { Id = Id };
//             var result = await mediator.Send(commandComId);
//             return Ok(result);

//         }
//         // [Authorize]
//         // [HttpGet("me")]
//         // public IActionResult Me()
//         // {
//         //     var userId = User.FindFirst("sub")?.Value;
//         //     return Ok(new { UserId = userId, Authenticated = User.Identity.IsAuthenticated });
//         // }

//         // [Authorize]
//         // [HttpGet("debug-cookie")]
//         // public IActionResult DebugCookie()
//         // {
//         //     var token = Request.Cookies["accessToken"];
//         //     return Ok(token ?? "Cookie não encontrado");
//         // }


//         //  [Authorize]
//         // [HttpGet]
//         // [Route("licencas")]
//         // public async Task<ActionResult<List<LicencaCreateResponse>>> GetLicencas(
//         //     [FromServices] IMediator mediator
//         // )
//         // {
//         //     var response = await mediator.Send(new LicencaGetRequest());
//         //     return Ok(response);
//         // }

//     }
// }
