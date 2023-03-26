using FluentValidation;
using Library.Application.Abstractions;
using Library.Application.Authentication.Commands.Register;
using Library.Application.Exceptions;
using Library.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.Authentication.Queries.Login;
public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IValidator<LoginQuery> _validator;

    public LoginQueryHandler(
        IJwtTokenGenerator jwtTokenGenerator,
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IValidator<LoginQuery> validator)
    {
        _validator = validator;
        _jwtTokenGenerator = jwtTokenGenerator;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(query);
        var user = await _userManager.FindByEmailAsync(query.Email);
        if (user is null)
            throw new NotFoundException("Wrong credentials");

        var result = await _signInManager.CheckPasswordSignInAsync(user, query.Password, false);

        if (!result.Succeeded)
            throw new NotFoundException("Wrong credentials");

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}

