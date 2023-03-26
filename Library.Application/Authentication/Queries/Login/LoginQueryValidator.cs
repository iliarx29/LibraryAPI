using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Authentication.Queries.Login;
public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
	public LoginQueryValidator()
	{
		RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email address");
	}
}
