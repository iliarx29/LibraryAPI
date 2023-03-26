using FluentValidation;
using Library.Application.Abstractions;
using Library.Application.Books.Commands.UpdateBook;
using Library.Application.Exceptions;
using Library.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Authentication.Commands.Register;
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly UserManager<User> _userManager;
    private readonly IValidator<RegisterCommand> _validator;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, UserManager<User> userManager, IValidator<RegisterCommand> validator)
    {
        _validator = validator;
         _jwtTokenGenerator = jwtTokenGenerator;
        _userManager = userManager;
    }

    //register method
    public async Task<AuthenticationResult> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(command);

        var user = new User { Email = command.Email, UserName = command.Name };

        var result = await _userManager.CreateAsync(user, command.Password);
        if (!result.Succeeded)
            throw new EmailDuplicateException("User already exists");

        // generate jwt token
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

}
