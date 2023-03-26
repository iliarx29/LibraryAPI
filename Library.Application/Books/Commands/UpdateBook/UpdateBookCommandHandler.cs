using FluentValidation;
using Library.Application.Abstractions;
using Library.Application.Books.Commands.CreateBook;
using Library.Application.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library.Application.Books.Commands.UpdateBook;
public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
{
    private readonly IApplicationContext _context;
    private readonly IValidator<UpdateBookCommand> _validator;

    public UpdateBookCommandHandler(IApplicationContext context, IValidator<UpdateBookCommand> validator)
    {
        _context = context;
        _validator = validator;
    }
    public async Task Handle(UpdateBookCommand command, CancellationToken cancellationToken)
    {
        _validator.ValidateAndThrow(command);
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == command.Id);

        if (book is null)
            throw new NotFoundException($"Book with id {command.Id} is not found");

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
