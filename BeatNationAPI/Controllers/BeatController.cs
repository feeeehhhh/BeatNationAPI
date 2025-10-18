using BeatNationAPI.Application.Beats.Command.Request;
using BeatNationAPI.Application.Beats.Command.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<List<BeatCreateResponse>> BeatGet(
           [FromServices] IMediator mediator,
           [FromBody] BeatGetRequest command
         )
        {
            return await mediator.Send(command);
        }

        [HttpDelete]
        [Route("beatdelete")]
        public async Task<IActionResult> BeatDelete(
           [FromServices] IMediator mediator,
           [FromBody] BeatDeleteRequest command
         )
        {
            var response = await mediator.Send(new BeatGetRequest());
            return Ok(response);
        }
    }
}
