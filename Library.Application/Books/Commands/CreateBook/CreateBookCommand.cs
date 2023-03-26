using Library.Domain.Entities;
using MediatR;

namespace Library.Application.Books.Commands.CreateBook;
public record CreateBookCommand
    (string ISBN,
    string Title,
    string Author,
    string Description,
    string Genre,
    DateTime TakingTime) : IRequest<Book>;
