namespace BeatNationAPI.Controllers
{
    using BeatNationAPI.Application.Autentication.Command.Request;
    using BeatNationAPI.Application.Autentication.Command.Response;
    using MediatR;
    using BeatNationAPI.Application.Autentication.Command.Request;
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
            [FromBody] LoginUserRequest command
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

        [HttpPost("refresh")]
        public async Task<ActionResult<TokenResponseDto>> Refresh()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (string.IsNullOrWhiteSpace(refreshToken))
                return Unauthorized();

            var result = await _mediator.Send(
                new RefreshTokenRequest
                {
                    RefreshToken = refreshToken
                });

            if (result == null)
                return Unauthorized();

            Response.Cookies.Append(
                "refreshToken",
                result.RefreshToken,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.None,
                    Path = "/",
                    Expires = result.Expiration
                });

            return Ok(new
            {
                result.AccessToken,
                result.Expiration
            });
        }

        [HttpPost("refresh-test")]
        public async Task<ActionResult<TokenResponseDto>> RefreshTest(
        [FromBody] RefreshTokenRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(
        ForgotPasswordRequest command)
        {
            await _mediator.Send(command);

            return Ok();
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(
        ResetPasswordRequest command)
        {
            await _mediator.Send(command);
            return NoContent();
        }
    }
}