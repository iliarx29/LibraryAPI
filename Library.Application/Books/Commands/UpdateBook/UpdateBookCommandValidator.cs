using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Books.Commands.UpdateBook;
public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
{
    public UpdateBookCommandValidator()
    {
        RuleFor(x => x.ISBN)
            .NotEmpty().WithMessage("Book must have an ISBN")
            .MaximumLength(17).WithMessage("ISBN must have maximum 17 length");

        RuleFor(x => x.Author).NotEmpty().WithMessage("Book must have an author");
        RuleFor(x => x.Title).NotEmpty().WithMessage("Book must have a title");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Book must have a description");
        RuleFor(x => x.Genre).NotEmpty().WithMessage("Book must have a genre");
    }
}
