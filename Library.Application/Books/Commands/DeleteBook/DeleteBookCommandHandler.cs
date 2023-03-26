using Library.Application.Abstractions;
using Library.Application.Exceptions;
using MediatR;

namespace Library.Application.Books.Commands.DeleteBook;
public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
{
    private readonly IApplicationContext _context;

    public DeleteBookCommandHandler(IApplicationContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteBookCommand command, CancellationToken cancellationToken)
    {
        var book = await _context.Books.FindAsync(command.Id, cancellationToken);

        if (book is null)
            throw new NotFoundException($"Book with id {command.Id} is not found");

        _context.Books.Remove(book);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
