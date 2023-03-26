using Library.API.Models;
using Library.Application.Authentication.Commands.Register;
using Library.Application.Authentication.Queries.Login;
using Library.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;
    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginQuery query)
    {
        var result = await _mediator.Send(query);

        var response = new AuthenticationResponse(Email: result.User.Email, Name: result.User.UserName, Token: result.Token);

        return Ok(response);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        var result = await _mediator.Send(command);

        var response = new AuthenticationResponse(Email: result.User.Email, Name: result.User.UserName, Token: result.Token);

        return Ok(response);
    }
}
