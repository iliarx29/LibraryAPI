using FluentValidation;
using Library.Application.Abstractions;
using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Books.Commands.CreateBook;
public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Book>
{
    private readonly IApplicationContext _context;

    public CreateBookCommandHandler(IApplicationContext context)
    {
        _context = context;
    }
    public async Task<Book> Handle(CreateBookCommand command, CancellationToken cancellationToken)
    {     
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
