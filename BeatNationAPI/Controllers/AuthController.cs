namespace BeatNationAPI.Controllers
{
    using BeatNationAPI.Application.Autentication.Command.Request;
    using BeatNationAPI.Application.Autentication.Command.Response;
    using MediatR;
    using Microsoft.AspNetCore.Identity.Data;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(
            [FromBody] LoginRequest command
        )
        {
            var result = await _mediator.Send(command);
            if (result == null)
                return Unauthorized();

            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterUserResponse>> Register(
        [FromBody] RegisterUserRequest command
        )
        {
            var result = await _mediator.Send(command);
            return Created("", result);
        }

    }
}