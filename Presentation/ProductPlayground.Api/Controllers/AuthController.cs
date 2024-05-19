using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductPlayground.Application.Features.Auth.Command.Login;
using ProductPlayground.Application.Features.Auth.Command.RefreshToken;
using ProductPlayground.Application.Features.Auth.Command.Register;
using ProductPlayground.Application.Features.Auth.Command.Revoke;
using ProductPlayground.Application.Features.Auth.Command.RevokeAll;

namespace ProductPlayground.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommandRequest request)
        {
            await mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        public async Task<IActionResult> Revoke(RevokeCommandRequest request)
        {
            var response = await mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RevokeAll()
        {
            var response = await mediator.Send(new RevokeAllCommandRequest());
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
