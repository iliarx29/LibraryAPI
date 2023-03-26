using Library.Application.Abstractions;
using Library.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Library.Application.Authentication.Queries.Login;
public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IApplicationContext _context;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public LoginQueryHandler(
        IApplicationContext context,
        IJwtTokenGenerator jwtTokenGenerator,
        UserManager<User> userManager,
        SignInManager<User> signInManager)
    {
        _context = context;
        _jwtTokenGenerator = jwtTokenGenerator;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {

        var user = await _userManager.FindByEmailAsync(query.Email);
        if (user is null)
            throw new Exception("wrong credentials");

        var result = await _signInManager.CheckPasswordSignInAsync(user, query.Password, false);

        if (!result.Succeeded)
            throw new Exception("wrong credentials");

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}

