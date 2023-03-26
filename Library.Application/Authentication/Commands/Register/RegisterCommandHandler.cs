using Library.Application.Abstractions;
using Library.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Authentication.Commands.Register;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IApplicationContext _context;

    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly UserManager<User> _userManager;

    public RegisterCommandHandler(IApplicationContext context, IJwtTokenGenerator jwtTokenGenerator, UserManager<User> userManager)
    {
        _context = context;
        _jwtTokenGenerator = jwtTokenGenerator;
        _userManager = userManager;
    }

    //register method
    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        //check if user already exists
        //if (_context.GetUserByEmail(command.Email) is not null)
        //{
        //    throw new DuplicateEmailException();
        //}
        var user = new User { Email = command.Email, UserName = command.Name };

        var result = await _userManager.CreateAsync(user, command.Password);
        if (!result.Succeeded)
            throw new Exception("User not added");

        // generate jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

}
