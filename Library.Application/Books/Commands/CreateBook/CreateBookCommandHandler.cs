using FluentValidation;
using Library.Application.Abstractions;
using Library.Domain.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.Books.Commands.CreateBook;
public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
{
    private readonly IApplicationContext _context;
    private readonly IValidator<CreateBookCommand> _validator;

    public CreateBookCommandHandler(IApplicationContext context, IValidator<CreateBookCommand> validator)
    {
        _context = context;
        _validator = validator;
    }
    public async Task<Book> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(command);

        var book = new Book()
        {
            ISBN = command.ISBN,
            Title = command.Title,
            Author = command.Author,
            Description = command.Description,
            Genre = command.Genre,
            TakingTime = command.TakingTime
        };

        await _context.Books.AddAsync(book, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return book;
    }
}
