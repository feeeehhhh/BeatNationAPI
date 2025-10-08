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
        public async Task<BeatCreateResponse> Create(
           [FromServices]IMediator mediator,
           [FromBody]BeatCreateRequest command
         )
        {
            return  await mediator.Send(command);
        }
       
    }
}
