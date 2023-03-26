﻿using MediatR;

namespace Library.Application.Authentication.Queries.Login;
public record LoginQuery(string Email, string Password) : IRequest<AuthenticationResult>;
