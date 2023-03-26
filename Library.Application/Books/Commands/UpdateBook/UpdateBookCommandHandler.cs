using Library.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;
namespace Library.Application.Books.Commands.UpdateBook;
public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
{
    private readonly IApplicationContext _context;

    public UpdateBookCommandHandler(IApplicationContext context)
    {
        _context = context;
    }
    public async Task Handle(UpdateBookCommand command, CancellationToken cancellationToken)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == command.Id);

        if (book is null)
            throw new ArgumentNullException(nameof(book), "Book is null");

        book.ISBN = command.ISBN;
        book.Title = command.Title;
        book.Description = command.Description;
        book.Author = command.Author;
        book.Genre = command.Genre;
        book.TakingTime = command.TakingTime;

        _context.Books.Update(book);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
