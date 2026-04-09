using BeatNationAPI.Application.Beats.Command.Request;
using BeatNationAPI.Application.Beats.Command.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BeatNationAPI.Controllers
{
    [Route("api/beats")]
    [ApiController]
    public class BeatController : ControllerBase
    {
        [HttpPost]
        [Route("beatcreate")]
        public async Task<BeatCreateResponse> BeatCreate(
           [FromServices] IMediator mediator,
           [FromBody] BeatCreateRequest command
         )
        {
            return await mediator.Send(command);

        }

        [HttpGet]
        [Route("beatget")]
        public async Task<ActionResult<List<BeatCreateResponse>>> BeatGet(
           [FromServices] IMediator mediator,
           [FromBody] BeatCreateResponse command
         )
        {
            var response = await mediator.Send(new BeatGetRequest());
            return Ok(response);
        }

        [HttpDelete]
        [Route("beatdelete")]
        public async Task<IActionResult> BeatDelete(
           [FromServices] IMediator mediator,
           [FromBody] BeatDeleteRequest command
         )
        {
            await mediator.Send(command);
            return NoContent();
        }

        // Assinatura assinado pro cloudflare r2

        [HttpPost]
        [Route("createupload")]
        public async Task<ActionResult<CreateUploadResponse>> CreateUpload(
           [FromServices] IMediator mediator,
           [FromBody] CreateUploadRequest command
         )
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
